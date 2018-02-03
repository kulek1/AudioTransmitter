using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioTransmitter_Client
{

    public partial class Form1 : Form
    {
        #region VARIABLES
        public Point firstPoint;
        private bool mouseIsDown = false;
        private bool isStarted = false;
        private const int CS_DROPSHADOW = 0x00020000;
        private int ListItemID = 1;
        public int ListActiveItemID = 0;

        private static bool isMp3 = false;
        private static bool isLive = true;
        Color primary = Color.FromArgb(30, 26, 42);
        Color active = Color.FromArgb(171, 236, 64);
        #endregion

        List<Color> colors = new List<Color>();
        int currentColor = 0;
        int a = 1;

        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Button moveBarRef => moveBar;
        public ListView listViewRef => listView1;

        public Form1()
        {
            InitializeComponent();
            AddColors();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void comboBoxAudio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddColors()
        {
            colors.Add(Color.FromArgb(190, 50, 96));
            colors.Add(Color.FromArgb(3, 169, 244));
            colors.Add(Color.FromArgb(0, 150, 136));
            colors.Add(Color.FromArgb(156, 39, 176));
            colors.Add(Color.FromArgb(255, 87, 34));
            colors.Add(Color.FromArgb(255, 193, 7));
            colors.Add(Color.FromArgb(205, 220, 57));
            colors.Add(Color.FromArgb(190, 50, 96));
        }

        private void ListViewStyling()
        {

        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Brush brush = new SolidBrush(Color.FromArgb(51, 53, 76));
            e.Graphics.FillRectangle(brush, e.Bounds);
            using (var sf = new StringFormat())
            {
                using (var headerFont = new Font("Open Sans", 9, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.White, e.Bounds, sf);
                }
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawText();
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Streamer stream = new Streamer();
            // stream.startRecord();
            // WasapiProvider wp = new WasapiProvider();

            // WebServer ws = new WebServer(SendResponse, "http://localhost:8090/");
            // ws.Run();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            if (resizeButton.Text == "+")
            {
                resizeButton.Text = "-";
            }
            else
            {
                resizeButton.Text = "+";
            }
            WindowResizer resize = new WindowResizer(this);
            resize.fire();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miniButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (isMp3 && listView1.Items.Count == 0)
            {
                openFileDialog();
                return;
            }
            String ip = ipTextBox.Text;
            int port = Int32.Parse(portTextBox.Text);
            String address = "http://" + ip + ":" + port + "/";

            if (!isStarted)
            {
                // reset stopper state
                _stopper.Reset();
                // init webserver
                WebServer ws = new WebServer(this, port);
                Thread thread = new Thread(new ThreadStart(ws.StartLive));
                animateBtnTimer.Enabled = true;
                roundButton1.Image = Properties.Resources.ic_pause_black_24dp;
                isStarted = true;

                if (isLive)
                {
                    thread = new Thread(new ThreadStart(ws.StartLive));
                }
                else if (isMp3)
                {
                    thread = new Thread(new ThreadStart(ws.StartMp3));
                }
                thread.IsBackground = true;
                thread.Start();
                Thread.Sleep(1);
            }
            else
            {
                animateBtnTimer.Enabled = false;
                roundButton1.Image = Properties.Resources.ic_play_arrow_black_24dp;
                isStarted = false;

                StopMainThread();
            }
        }

        private static void StopMainThread()
        {
            // MessageBox.Show("Stopping main thread.");
            _stopper.Set();
        }

        private void animateBtnTimer_Tick(object sender, EventArgs e)
        {
            animateBtnTimer.Enabled = false;
            if (currentColor < colors.Count - 1)
            {
                this.roundButton1.BackColor = ColorTransition.getColorScale(a, colors[currentColor], colors[currentColor + 1]);

                if (a < 100)
                {
                    a++;
                }
                else
                {
                    a = 1;
                    currentColor++;
                }
            }
            else
            {
                a = 1;
                currentColor = 0;
            }
            animateBtnTimer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void openFileDialog()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\test";
            openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String fileName = Path.GetFileName(openFileDialog1.FileName);
                    String filePath = openFileDialog1.FileName;
                    string[] row = { fileName, filePath };

                    var listViewItem = new ListViewItem(row);

                    // add item to list
                    listView1.Items.Add(listViewItem);
                    ListItemID++;

                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //myStream.Get
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonStatusHelper(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Name == "liveStatus")
            {
                if (!isLive)
                {
                    liveStatus.BackColor = active;
                    mp3Status.BackColor = primary;
                    isLive = !isLive;
                    isMp3 = !isMp3;
                }
            }
            else
            {
                if (!isMp3)
                {
                    mp3Status.BackColor = active;
                    liveStatus.BackColor = primary;
                    isMp3 = !isMp3;
                    isLive = !isLive;
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            // uncheck previous item
            listView1.Items[ListActiveItemID].ForeColor = Color.White;
            listView1.Items[ListActiveItemID].Tag = false;

            int i = listView1.SelectedIndices[0];
            // string s = listView1.Items[i].Text;

            listView1.Items[i].ForeColor = active;
            listView1.Items[i].Tag = true;
            ListActiveItemID = i;
        }

        public static ManualResetEvent _stopper = new ManualResetEvent(false);

    }
}

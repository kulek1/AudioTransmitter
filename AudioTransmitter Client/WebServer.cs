using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Lame;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace AudioTransmitter_Client
{
    public class WebServer
    {
        #region Variables
        private TcpListener _listener;
        private static bool isRunning = true;
        private static bool isStreaming = true;
        static LameMP3FileWriter wri;
        private Stream inputStream;
        public StreamWriter outputStream;
        private static Form1 self;
        #endregion


        public WebServer(Form1 context, int port)
        {
            _listener = new TcpListener(port);
            // _listener = new TcpListener(IPAddress.Any, port);
            self = context;
            isStop();
            _listener.Start();
        }

        public void isStop()
        {
            var loop1Task = Task.Run(async () => {
                while (true)
                {
                    if (Form1._stopper.WaitOne(80, false))
                    {
                        Stop();
                        break;
                    }
                    await Task.Delay(2000);
                }
            });

        }

        public void StartLive()
        {
            isRunning = true;
            while (isRunning)
            {
                TcpClient client = _listener.AcceptTcpClient();
                // Thread thread = new Thread(() => fireLive(client));
                // thread.Start();
                // Thread.Sleep(1);
                fireLive(client);
            }
        }

        public void StartMp3()
        {
            ListView list = getListView();

            isRunning = true;
            while (isRunning)
            {
                ListViewItem item = list.Items[self.ListActiveItemID];
                String path = item.SubItems[1].Text;
                String fullpath = @path;

                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    Thread thread = new Thread(() => fireMp3(client, fullpath));
                    thread.Start();
                    Thread.Sleep(1);
                } catch (SocketException socketEx)
                {
                    MessageBox.Show("Tcp error");
                    Stop();
                }
            }
        }

        private ListView getListView()
        {
            ListView list = new ListView();
            self.listViewRef.Invoke(new MethodInvoker(delegate {
                foreach (ListViewItem item in self.listViewRef.Items)
                {
                    list.Items.Add((ListViewItem)item.Clone());
                }
            }));
            return list;
        }


        public void setHeader(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            string response = "HTTP/1.0 200 OK\r\n"
                + "Content-Type: audio/mpeg\r\n"
                + "Connection: close\r\n"
                + "\n";
            byte[] bytesResponse = Encoding.ASCII.GetBytes(response);
            stream.Write(bytesResponse, 0, bytesResponse.Length);
        }

        public void Stop()
        {
            isRunning = false;
            _listener.Stop();
        }

        public void fireLive(TcpClient client)
        {
            inputStream = new BufferedStream(client.GetStream());
            inputStream.ReadByte();
            
            NetworkStream stream = client.GetStream();
            string response = "HTTP/1.0 200 OK\r\n"
             + "Content-Type: audio/mpeg\r\n"
             + "\r\n";
            byte[] bytesResponse = Encoding.ASCII.GetBytes(response);
            stream.Write(bytesResponse, 0, bytesResponse.Length);

            outputStream = new StreamWriter(new BufferedStream(client.GetStream()));
            // outputStream.BaseStream
            try
            {
                // Start recording from loopback
                IWaveIn waveIn = new WasapiLoopbackCapture();
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                // Setup MP3 writer to output at 192kbit/sec (~1 minutes per MB)
                wri = new LameMP3FileWriter(stream, waveIn.WaveFormat, 192);
                waveIn.StartRecording();

                System.Threading.Thread.Sleep(5050);
            }
            catch (Exception e)
            {
                MessageBox.Show("error: " + e);
            }
            client.Close();
        }

        public void fireMp3(TcpClient client, String filePath)
        {
            inputStream = new BufferedStream(client.GetStream());
            inputStream.ReadByte();
           

            NetworkStream stream = client.GetStream();
            byte[] file = new byte[] {};
            try
            {
                file = File.ReadAllBytes(filePath);
            } catch (FileNotFoundException ioEx)
            {
                MessageBox.Show(ioEx.Message);
            }

            string response = "HTTP/1.0 200 OK\r\n"
             + "Content-Type: audio/mpeg\r\n"
             + "Content-Length: " + file.Length + "\r\n"
             + "\r\n";
            byte[] bytesResponse = Encoding.ASCII.GetBytes(response);
            stream.Write(bytesResponse, 0, bytesResponse.Length);
            stream.Write(file, 0, file.Length);

            inputStream = null; outputStream = null;
            client.Close();
            stream.Dispose();
        }

        public void AudioStream(NetworkStream stream)
        {
            try
            {

                string response = "HTTP/1.0 200 OK\r\n"
                + "Content-Type: audio/mpeg\r\n"
                + "Connection: close\r\n"
                + "\n";
                byte[] bytesResponse = Encoding.ASCII.GetBytes(response);
                stream.Write(bytesResponse, 0, bytesResponse.Length);


                // Start recording from loopback
                IWaveIn waveIn = new WasapiLoopbackCapture();
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                // Setup MP3 writer to output at 192kbit/sec (~1 minutes per MB)
                string mp3 = "test";
                wri = new LameMP3FileWriter(@"C:\test\test_output.mp3", waveIn.WaveFormat, 192);
                waveIn.StartRecording();

                byte[] sample = new byte[9999];
                // wri.Write(sample, 0, sample.Length);
                // stream.Write(sample, 0, sample.Length);

                // System.Threading.Thread.Sleep(40000);


                System.Threading.Thread.Sleep(4050);
                waveIn.StopRecording();
                // flush output to finish MP3 file correctly
                wri.Flush();
                // Dispose of objects
                waveIn.Dispose();
                wri.Dispose();
            }
            catch
            {

            }
            finally
            {
                stream.Close();
            }
        }
        static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            // signal that recording has finished
            isStreaming = false;
        }

        static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // write recorded data to MP3 writer
            if (wri != null)
            {
                wri.Write(e.Buffer, 0, e.BytesRecorded);
                // wri.Flush();
            }
        }

        public void handleGETConnection(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes("<!doctype html><html><body><h1>test server</h1></body></html>");


            string response = "HTTP/1.0 200 OK\r\n"
                + "Content-Type: text/html\r\n"
                + "Content-Length: " + data.Length
                + "Connection: close\r\n"
                + "\n";
            byte[] bytesResponse = Encoding.ASCII.GetBytes(response);

            stream.Write(bytesResponse, 0, bytesResponse.Length);
            stream.Write(data, 0, data.Length);
            /* using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write("<html><body>Hello There!</body></html>");
            } */
            stream.Dispose();
            stream.Flush();
            stream.Close();
        }
    }
}
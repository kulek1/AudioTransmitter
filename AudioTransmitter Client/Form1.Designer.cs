using System.Windows.Forms;

namespace AudioTransmitter_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.resizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.miniButton = new System.Windows.Forms.Button();
            this.moveBar = new System.Windows.Forms.Button();
            this.animateBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.liveLabel = new System.Windows.Forms.Label();
            this.mp3Label = new System.Windows.Forms.Label();
            this.mp3Status = new AudioTransmitter_Client.RoundButton();
            this.liveStatus = new AudioTransmitter_Client.RoundButton();
            this.roundButton1 = new AudioTransmitter_Client.RoundButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // resizeButton
            // 
            this.resizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.resizeButton.FlatAppearance.BorderSize = 0;
            this.resizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resizeButton.ForeColor = System.Drawing.Color.White;
            this.resizeButton.Location = new System.Drawing.Point(493, 138);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(199, 183);
            this.resizeButton.TabIndex = 2;
            this.resizeButton.Text = "+";
            this.resizeButton.UseVisualStyleBackColor = false;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closeButton.Location = new System.Drawing.Point(698, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 56);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // miniButton
            // 
            this.miniButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.miniButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.miniButton.FlatAppearance.BorderSize = 0;
            this.miniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.miniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.miniButton.Location = new System.Drawing.Point(572, -1);
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(120, 56);
            this.miniButton.TabIndex = 4;
            this.miniButton.Text = "-";
            this.miniButton.UseVisualStyleBackColor = false;
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            // 
            // moveBar
            // 
            this.moveBar.FlatAppearance.BorderSize = 0;
            this.moveBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveBar.Location = new System.Drawing.Point(0, 0);
            this.moveBar.Name = "moveBar";
            this.moveBar.Size = new System.Drawing.Size(566, 55);
            this.moveBar.TabIndex = 5;
            this.moveBar.UseVisualStyleBackColor = true;
            this.moveBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.moveBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.moveBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // animateBtnTimer
            // 
            this.animateBtnTimer.Interval = 1;
            this.animateBtnTimer.Tick += new System.EventHandler(this.animateBtnTimer_Tick);
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portTextBox.Font = new System.Drawing.Font("Open Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.ForeColor = System.Drawing.Color.White;
            this.portTextBox.Location = new System.Drawing.Point(170, 8);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.portTextBox.MaxLength = 6;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(208, 62);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "8081";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.portTextBox);
            this.panel1.Location = new System.Drawing.Point(61, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 81);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 41);
            this.label1.TabIndex = 8;
            this.label1.Text = "PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(24, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 41);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ipTextBox);
            this.panel2.Location = new System.Drawing.Point(61, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 81);
            this.panel2.TabIndex = 9;
            // 
            // ipTextBox
            // 
            this.ipTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.ipTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipTextBox.Font = new System.Drawing.Font("Open Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTextBox.ForeColor = System.Drawing.Color.White;
            this.ipTextBox.Location = new System.Drawing.Point(57, 7);
            this.ipTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.ipTextBox.MaxLength = 16;
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(319, 62);
            this.ipTextBox.TabIndex = 7;
            this.ipTextBox.Text = "127.0.0.1";
            this.ipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.panel3.Location = new System.Drawing.Point(817, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 800);
            this.panel3.TabIndex = 10;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.filePath});
            this.listView1.ForeColor = System.Drawing.SystemColors.Menu;
            this.listView1.Location = new System.Drawing.Point(943, 189);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(714, 807);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // fileName
            // 
            this.fileName.Text = "File name";
            this.fileName.Width = 400;
            // 
            // filePath
            // 
            this.filePath.Text = "Path";
            this.filePath.Width = 330;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(948, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 49);
            this.label3.TabIndex = 12;
            this.label3.Text = "Playlist";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(943, 1002);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(714, 75);
            this.button2.TabIndex = 13;
            this.button2.Text = "Add files";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // liveLabel
            // 
            this.liveLabel.AutoSize = true;
            this.liveLabel.Font = new System.Drawing.Font("Open Sans Light", 10F);
            this.liveLabel.ForeColor = System.Drawing.Color.White;
            this.liveLabel.Location = new System.Drawing.Point(127, 1036);
            this.liveLabel.Name = "liveLabel";
            this.liveLabel.Size = new System.Drawing.Size(75, 41);
            this.liveLabel.TabIndex = 14;
            this.liveLabel.Text = "LIVE";
            // 
            // mp3Label
            // 
            this.mp3Label.AutoSize = true;
            this.mp3Label.Font = new System.Drawing.Font("Open Sans Light", 10F);
            this.mp3Label.ForeColor = System.Drawing.Color.White;
            this.mp3Label.Location = new System.Drawing.Point(303, 1036);
            this.mp3Label.Name = "mp3Label";
            this.mp3Label.Size = new System.Drawing.Size(79, 41);
            this.mp3Label.TabIndex = 16;
            this.mp3Label.Text = "MP3";
            this.mp3Label.Click += new System.EventHandler(this.label4_Click);
            // 
            // mp3Status
            // 
            this.mp3Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(26)))), ((int)(((byte)(42)))));
            this.mp3Status.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mp3Status.FlatAppearance.BorderSize = 0;
            this.mp3Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mp3Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mp3Status.Location = new System.Drawing.Point(249, 1037);
            this.mp3Status.Name = "mp3Status";
            this.mp3Status.Size = new System.Drawing.Size(40, 40);
            this.mp3Status.TabIndex = 17;
            this.mp3Status.UseVisualStyleBackColor = false;
            this.mp3Status.Click += new System.EventHandler(this.buttonStatusHelper);
            // 
            // liveStatus
            // 
            this.liveStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(232)))), ((int)(((byte)(68)))));
            this.liveStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.liveStatus.FlatAppearance.BorderSize = 0;
            this.liveStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.liveStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.liveStatus.Location = new System.Drawing.Point(73, 1037);
            this.liveStatus.Name = "liveStatus";
            this.liveStatus.Size = new System.Drawing.Size(40, 40);
            this.liveStatus.TabIndex = 15;
            this.liveStatus.UseVisualStyleBackColor = false;
            this.liveStatus.Click += new System.EventHandler(this.buttonStatusHelper);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Image = ((System.Drawing.Image)(resources.GetObject("roundButton1.Image")));
            this.roundButton1.Location = new System.Drawing.Point(266, 463);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roundButton1.Size = new System.Drawing.Size(300, 300);
            this.roundButton1.TabIndex = 6;
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(819, 1137);
            this.Controls.Add(this.mp3Status);
            this.Controls.Add(this.mp3Label);
            this.Controls.Add(this.liveStatus);
            this.Controls.Add(this.liveLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.moveBar);
            this.Controls.Add(this.miniButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.resizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button miniButton;
        private System.Windows.Forms.Button moveBar;
        private RoundButton roundButton1;
        private System.Windows.Forms.Timer animateBtnTimer;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox ipTextBox;
        private Panel panel3;
        private ListView listView1;
        private Label label3;
        private Button button2;
        private ColumnHeader fileName;
        private ColumnHeader filePath;
        private Label liveLabel;
        private RoundButton liveStatus;
        private RoundButton mp3Status;
        private Label mp3Label;
    }
}


namespace pianote
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
            this.songList = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortA = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox50 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.serialPortB = new System.IO.Ports.SerialPort(this.components);
            this.serialPortC = new System.IO.Ports.SerialPort(this.components);
            this.serialPortPiano = new System.IO.Ports.SerialPort(this.components);
            this.serialPortArm = new System.IO.Ports.SerialPort(this.components);
            this.comInfoArm = new System.Windows.Forms.Label();
            this.comInfoPiano = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPortD = new System.IO.Ports.SerialPort(this.components);
            this.Mute = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            this.SuspendLayout();
            // 
            // songList
            // 
            this.songList.AccessibleDescription = "songs";
            this.songList.AllowDrop = true;
            this.songList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.songList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(132)))), ((int)(((byte)(175)))));
            this.songList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.songList.FormattingEnabled = true;
            this.songList.Items.AddRange(new object[] {
            "0: Costome Music"});
            this.songList.Location = new System.Drawing.Point(12, 85);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(140, 21);
            this.songList.TabIndex = 37;
            this.songList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button1_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 25000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(168, 418);
            this.trackBar1.Maximum = 120;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(45, 188);
            this.trackBar1.TabIndex = 38;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 40;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.ChangeTempo);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 607);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Tempo";
            // 
            // serialPortA
            // 
            this.serialPortA.PortName = "COM8";
            this.serialPortA.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.inCom);
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox14.Image = global::p.Properties.Resources._B9A66FF165A6EE2D4B6811C5A37DAA9506374A802D5534ED40_pimgpsh_fullsize_distr;
            this.pictureBox14.Location = new System.Drawing.Point(0, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(1182, 685);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 46;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox50
            // 
            this.pictureBox50.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox50.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox50.Location = new System.Drawing.Point(162, 147);
            this.pictureBox50.Name = "pictureBox50";
            this.pictureBox50.Size = new System.Drawing.Size(10, 10);
            this.pictureBox50.TabIndex = 21;
            this.pictureBox50.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox20.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox20.Image = global::p.Properties.Resources._263144;
            this.pictureBox20.Location = new System.Drawing.Point(162, 147);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(54, 54);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox20.TabIndex = 35;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.RecordMelody);
            // 
            // pictureBox19
            // 
            this.pictureBox19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox19.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox19.Image = global::p.Properties.Resources._149125;
            this.pictureBox19.Location = new System.Drawing.Point(162, 87);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(54, 54);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox19.TabIndex = 34;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Click += new System.EventHandler(this.ClickPlay);
            // 
            // pictureBox24
            // 
            this.pictureBox24.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox24.Location = new System.Drawing.Point(160, 85);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(58, 118);
            this.pictureBox24.TabIndex = 43;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox15.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox15.Location = new System.Drawing.Point(162, 223);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(10, 10);
            this.pictureBox15.TabIndex = 30;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox21.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox21.Image = global::p.Properties.Resources.refresh;
            this.pictureBox21.Location = new System.Drawing.Point(167, 625);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(45, 44);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox21.TabIndex = 39;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Click += new System.EventHandler(this.ResetTrackBar);
            // 
            // pictureBox23
            // 
            this.pictureBox23.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox23.Location = new System.Drawing.Point(160, 414);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(58, 259);
            this.pictureBox23.TabIndex = 42;
            this.pictureBox23.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox18.Image = global::p.Properties.Resources._126474;
            this.pictureBox18.Location = new System.Drawing.Point(162, 340);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(54, 54);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox18.TabIndex = 33;
            this.pictureBox18.TabStop = false;
            this.pictureBox18.Click += new System.EventHandler(this.Analyze);
            // 
            // pictureBox17
            // 
            this.pictureBox17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.Image = global::p.Properties.Resources._149427;
            this.pictureBox17.Location = new System.Drawing.Point(162, 223);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(54, 54);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox17.TabIndex = 32;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Click += new System.EventHandler(this.Recstop_sound);
            // 
            // pictureBox16
            // 
            this.pictureBox16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.Image = global::p.Properties.Resources._126513;
            this.pictureBox16.Location = new System.Drawing.Point(162, 280);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(54, 54);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 31;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Click += new System.EventHandler(this.Play_textwav);
            // 
            // pictureBox22
            // 
            this.pictureBox22.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox22.Location = new System.Drawing.Point(160, 221);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(58, 175);
            this.pictureBox22.TabIndex = 41;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox13.BackColor = System.Drawing.Color.Black;
            this.pictureBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox13.Location = new System.Drawing.Point(892, 85);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(89, 360);
            this.pictureBox13.TabIndex = 26;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox12.BackColor = System.Drawing.Color.Black;
            this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox12.Location = new System.Drawing.Point(773, 85);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(89, 360);
            this.pictureBox12.TabIndex = 25;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox11.BackColor = System.Drawing.Color.Black;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox11.Location = new System.Drawing.Point(654, 85);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(89, 360);
            this.pictureBox11.TabIndex = 24;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox10.BackColor = System.Drawing.Color.Black;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Location = new System.Drawing.Point(413, 85);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 360);
            this.pictureBox10.TabIndex = 23;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox9.BackColor = System.Drawing.Color.Black;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Location = new System.Drawing.Point(297, 85);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(89, 360);
            this.pictureBox9.TabIndex = 22;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox8.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Location = new System.Drawing.Point(1055, 85);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(119, 588);
            this.pictureBox8.TabIndex = 9;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox7.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(936, 85);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(119, 588);
            this.pictureBox7.TabIndex = 8;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox6.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(817, 85);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(119, 588);
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(698, 85);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(119, 588);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(579, 85);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(119, 588);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(460, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 588);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(341, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 588);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(222, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 588);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.notes_click);
            // 
            // pictureBox26
            // 
            this.pictureBox26.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox26.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox26.Location = new System.Drawing.Point(182, 12);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(18, 20);
            this.pictureBox26.TabIndex = 47;
            this.pictureBox26.TabStop = false;
            this.pictureBox26.Click += new System.EventHandler(this.pingClick);
            // 
            // serialPortB
            // 
            this.serialPortB.PortName = "COM2";
            this.serialPortB.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.inCom);
            // 
            // serialPortC
            // 
            this.serialPortC.PortName = "COM5";
            this.serialPortC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.inCom);
            // 
            // comInfoArm
            // 
            this.comInfoArm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comInfoArm.BackColor = System.Drawing.SystemColors.Info;
            this.comInfoArm.Location = new System.Drawing.Point(12, 44);
            this.comInfoArm.Name = "comInfoArm";
            this.comInfoArm.Size = new System.Drawing.Size(1162, 13);
            this.comInfoArm.TabIndex = 49;
            this.comInfoArm.Text = "Display Controller - Connection Info:";
            this.comInfoArm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comInfoPiano
            // 
            this.comInfoPiano.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comInfoPiano.BackColor = System.Drawing.SystemColors.Info;
            this.comInfoPiano.Location = new System.Drawing.Point(12, 65);
            this.comInfoPiano.Name = "comInfoPiano";
            this.comInfoPiano.Size = new System.Drawing.Size(1162, 13);
            this.comInfoPiano.TabIndex = 50;
            this.comInfoPiano.Text = " Piano  Controller - Connection Info:";
            this.comInfoPiano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.Location = new System.Drawing.Point(97, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Export";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.sendMelody);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(206, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(968, 20);
            this.label3.TabIndex = 52;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialPortD
            // 
            this.serialPortD.PortName = "COM6";
            this.serialPortD.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.inCom);
            // 
            // Mute
            // 
            this.Mute.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Mute.Location = new System.Drawing.Point(12, 12);
            this.Mute.Name = "Mute";
            this.Mute.Size = new System.Drawing.Size(79, 20);
            this.Mute.TabIndex = 53;
            this.Mute.Text = "Mute";
            this.Mute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mute.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 685);
            this.Controls.Add(this.Mute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comInfoPiano);
            this.Controls.Add(this.comInfoArm);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.pictureBox50);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox24);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox23);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.songList);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox14);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox50;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.ComboBox songList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.IO.Ports.SerialPort serialPortA;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.IO.Ports.SerialPort serialPortB;
        private System.IO.Ports.SerialPort serialPortC;
        private System.IO.Ports.SerialPort serialPortPiano;
        private System.IO.Ports.SerialPort serialPortArm;
        private System.Windows.Forms.Label comInfoArm;
        private System.Windows.Forms.Label comInfoPiano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.IO.Ports.SerialPort serialPortD;
        private System.Windows.Forms.Label Mute;
    }
}


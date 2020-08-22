using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Management;


namespace pianote
{
    public partial class Form1 : Form
    {
        int betweenRatio = 1, between;
        int minBetween = 40;
        int pressTime = 250;
        int[] melodyRec = new int[100];
        int[] melodyRecT = new int[100];
        int recP = 0;
        bool isRec = false;
        public string location, location_a;
        Color notePressC = Color.FromArgb(50, 20, 80);
        Color picturePressC = Color.Red;
        int pictureBlinkTime = 140;
        Dictionary<string, int[]> songs = new Dictionary<string, int[]>()
        {
            { "1: Twinkle Twinkle Little Star", new int[]{ 1, 1, 5, 5, 6, 6, 5, 4, 4, 3, 3, 2, 2, 1, 5, 5, 4, 4, 3, 3, 2, 5, 5, 4, 4, 3, 3, 2, 1, 1, 5, 5, 6, 6, 5, 4, 4, 3, 3, 2, 2, 1 } },
            { "1: Twinkle Twinkle Little Star@", new int[]{ 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 2 } },
            {"2: The Scientist",new int[]{  4, 5, 4, 8, 6, 6, 4, 5, 4, 8, 6, 6, 4, 5, 4, 6, 6, 6, 6, 5, 4, 4, 4, 5, 4, 8, 6, 6, 4, 5, 4, 8, 6, 6, 4, 5, 4, 6, 6, 6, 6, 5, 4 } },
            {"2: The Scientist@",new int[]{ 4, 4, 4, 2, 2, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 2, 2, 4, 2, 4, 4, 1, 4, 4, 4, 2, 2, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 2, 2, 4, 2, 4, 1 } },
            {"3: Hallelujah",new int[]{ 3,5,5,5,5,6,6,6,5,6,6,6,6,6,5,5,4,5,5,5,5,14,14,3,5,6,6,6,6,6,6,6,5,3,3,3,3,3,3,3,5,6,6,6,6,6,6,6,5,3,4,3,2,2,2,1,1,1,1,1} },
            {"3: Hallelujah@",new int[]{4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,  4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,2,4,1,4,4,2,4,2,4,2,4,2,4 } },
            {"4: I. Morning Mood",new int[]{ 5,3,2,1,2,3,5,3,2,1,2,3,2,3,5,3,5,6,3,6,5,3,2,1,1,5,3,2,1,2,3,5,3,2,1,2,3,2,3,5,3,5,6,3,6,7,12,11,3,3} },
            {"4: I. Morning Mood@",new int[]{4,4,4,4,4,4,4,4,4,4,8,8,8,8,4,4,4,4,4,4,4,4,4,2,4,4,4,4,4,4,4,4,4,4,4,8,8,8,8,4,4,4,4,4,4,4, 4, 4,2,4 } }
        };
       

        public int defaultType = 8;
        static public string text;
        public bool timerStopped = false;
        public static bool isRec_sound = false;
        public int baseTempo = 140;//beats per minute (how many quarters in 1 minute)
        public int tempo;//beats per minute (how many quarters in 1 minute)
        public float fullTime;//in miliseconds  
        public Form1()
        {
            InitializeComponent();
            foreach (var key in songs.Keys)
            {
                if(!key.Contains("@"))
                {
                    songList.Items.Add(key);
                }   
            }
            location = System.AppDomain.CurrentDomain.BaseDirectory;
            location_a = location.Replace("p\\p\\bin\\Debug\\", null);
            location_a = location_a.Replace('\\', '/');
            location_a = location_a + "acrcloud_sdk_csharp-master/ACRCloudRecognitionTest/ACRCloudRecognitionTest/bin/Release";
            tempo = baseTempo;
            fullTime = 60000*4 / tempo;//miliseconds per eigth
            label1.Text = baseTempo.ToString() + " bpm";
        }
        public void PlayMusicArry(int[] melody, int[] melodyT)
        {
            for (int i = 0; i < melody.Length; i++)
            {
                if (!isPlaying)
                    break;
                if (melody[i] != 0)
                {
                    int noteType = defaultType;
                    if (melodyT[i] != 0)
                        noteType = melodyT[i];
                    if (melody[i] != 14)
                    {
                        between = (int)Math.Floor((float)fullTime / (8 * betweenRatio));
                        if ((int)(between / 8) < minBetween)
                            between = minBetween*8;
                        PictureClick((PictureBox)this.Controls["pictureBox" + melody[i].ToString()], notePressC, (int)((fullTime / noteType) - (int)(between / 8)));
                        System.Threading.Thread.Sleep((int)(between/8));
                    }
                    else
                    {
                        System.Threading.Thread.Sleep((int)(fullTime / noteType));
                    }
                }
            }
            if(isPlaying)
                ClickPlay(pictureBox19,null);
        }
        private void RecordMelody(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                PictureBlink(sender, p.Properties.Resources._51, pictureBlinkTime);
                if (isRec)
                {
                    isRec = false;
                    pictureBox50.BackColor = Color.DarkGray;
                    Application.DoEvents();
                    songList.Text = "0: Costome Music";                    
                }
                else
                {
                    pictureBox50.BackColor = Color.Red;
                    Application.DoEvents();
                    melodyRec = new int[100];
                    recP = 0;
                    isRec = true;

                }
            }
        }
        public bool isPlaying = false;
        private void ClickPlay(object sender, EventArgs e)
        {
            
            if (songList.Text != "" && songs.ContainsKey(songList.Text +"@") || songList.Text.Contains("Costome Music"))
            {
                if (isPlaying)
                {
                    isPlaying = false;
                    pictureBox19.Image = p.Properties.Resources._149125;
                }
                else
                {
                    PictureBlink(sender, p.Properties.Resources._2_11, pictureBlinkTime);
                    toSound = false;
                    sendMelody(null, null);
                    toSound = true;
                    try
                    {
                        isPlaying = true;

                        pictureBox19.Image = p.Properties.Resources._2_2;
                        if (songList.Text.Contains("Costome Music"))
                            PlayMusicArry(melodyRec, melodyRecT);
                        else
                            PlayMusicArry(songs[songList.Text], songs[songList.Text + "@"]);

                    }
                    catch (KeyNotFoundException)
                    {
                    }

                }
            } 
        }
        private void Click_on_key(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z: notes_click(pictureBox1, null); break;
                case Keys.X: notes_click(pictureBox2, null); break;
                case Keys.C: notes_click(pictureBox3, null); break;
                case Keys.V: notes_click(pictureBox4, null); break;
                case Keys.B: notes_click(pictureBox5, null); break;
                case Keys.N: notes_click(pictureBox6, null); break;
                case Keys.M: notes_click(pictureBox7, null); break;
                case Keys.Oemcomma: notes_click(pictureBox8, null); break;
                case Keys.S: notes_click(pictureBox9, null); break;
                case Keys.D: notes_click(pictureBox10, null); break;
                case Keys.G: notes_click(pictureBox11, null); break;
                case Keys.H: notes_click(pictureBox12, null); break;
                case Keys.J: notes_click(pictureBox13, null); break;

            }


        }
        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            Click_on_key(e);
        }

        private void notes_click(object sender, EventArgs e)
        {
            string key_name = "";
            int key_number = 1;
            if (sender is PictureBox)
            {
                key_name = ((PictureBox)sender).Name.ToString();                
                key_name = key_name.Substring((key_name.Length - 2), 2);
                if (key_name[0] is 'x')
                {
                    key_name = key_name.Substring((key_name.Length - 1));
                }
                key_number = Int32.Parse(key_name);
                PictureClick(sender, notePressC, pressTime);
                if (isRec)
                {
                    melodyRec[recP] = key_number;
                    recP++;
                }
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


        }
        //mic stuff
        #region Default Instance
        private static Form1 defaultInstance;
        public static Form1 Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Form1();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        #endregion
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        private void Recstop_sound(object sender, System.EventArgs e)
        {
            if (!isPlaying)
            {


                if (!timerStopped)
                    PictureBlink(sender, p.Properties.Resources._41, pictureBlinkTime);
                if (isRec_sound)//start stop
                {
                    timer1.Stop();
                    isRec_sound = false;
                    pictureBox15.BackColor = Color.DarkGray;
                    Application.DoEvents();
                    Record("save recsound " + location + "\\test.wav", "", 0, 0);
                    Record("close recsound", "", 0, 0);


                }
                else//start record
                {
                    isRec_sound = true;
                    pictureBox15.BackColor = Color.Red;
                    Application.DoEvents();
                    Record("open new Type waveaudio Alias recsound", "", 0, 0);
                    Record("record recsound", "", 0, 0);
                    timer1.Start();

                }
            }
        }
        private void Play_textwav(object sender, System.EventArgs e)
        {
            if (!isPlaying)
            {
                PictureBlink(sender, p.Properties.Resources._11, pictureBlinkTime);
                (new Microsoft.VisualBasic.Devices.Audio()).Play(location + "\\test.wav");
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {

            timerStopped = true;
            Recstop_sound(pictureBox17, null);
            timerStopped = false;

        }
        private void Analyze(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                PictureBlink(sender, p.Properties.Resources._3, pictureBlinkTime);
                label3.Text = "";
                using (StreamWriter sw = File.CreateText(location_a + "\\title.txt"))
                {
                    sw.WriteLine("");
                }
                try
                {
                    System.Diagnostics.Process.Start(location_a + "\\ACRCloudRecognitionTest.exe");

                    do
                    {
                        try
                        {
                            using (StreamReader sr = File.OpenText(location_a + "\\title.txt"))
                            {
                                text = sr.ReadLine();
                            }
                        }
                        catch { }

                    }
                    while (text == "");
                    label3.Text = text;
                    var tempItem = "";
                    foreach (var item in songList.Items)
                    {
                        if (item.ToString().Contains(text))
                        {
                            tempItem = item.ToString();
                            break;

                        }
                    }
                    if (tempItem.Contains(text))
                    {
                        songList.Text = tempItem;                             
                        for (int i = 0; i < 5; i++)
                        {
                            PictureBlink(sender, p.Properties.Resources._3_green1, 600);
                            System.Threading.Thread.Sleep(400);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PictureBlink(sender, p.Properties.Resources._3_red, 600);
                            System.Threading.Thread.Sleep(400);
                        }
                    }
                        
                    Application.DoEvents();
                }
                catch (Exception ee)
                {
                    label3.Text = "Error: " + ee.Message ; 
                }
            }
        }
        private void ResetTrackBar(object sender, EventArgs e)
        {
            trackBar1.Value = 40;
            ChangeTempo(null, null);
            PictureBlink(sender, p.Properties.Resources.reseticon_b, pictureBlinkTime);
        }
        private void ChangeTempo(object sender, EventArgs e)
        {
            tempo = baseTempo * trackBar1.Value / 40;
            fullTime = 60000 * 4 / tempo;//miliseconds per eigth
            label1.Text = tempo.ToString() + " bpm";
        }
        public void sendNote(int outNote,int outType)
        {
            try
            {
                char data = (char)outNote;
                serialPortPiano.Write(data.ToString());
                data = (char)outType;
                serialPortA.Write(data.ToString());
            }
            catch { }
        }
        public string txt;
        public bool pinged = false;
        private void inCom(object sender, SerialDataReceivedEventArgs e)
        {
            var s = sender as SerialPort;            
            txt = s.ReadExisting().ToString();
            if (txt.Contains("|"))
            {
                pinged = true;
                pianoPrint("|");
                try { serialPortPiano.PortName = s.PortName;
                    pianoSuc = true;
                }
                catch { pianoPrint("two arduino on the same com (" + s.PortName.ToString() + ")   "); };
                try { s.Close(); /* close the serial port*/}
                catch { pianoPrint("   ping(|) e: couldn't close (" + s.PortName.ToString() +")   "); }
                try { serialPortPiano.Open(); /* open the serial port*/}
                catch { pianoPrint("   ping(|) e: couldn't open (" + s.PortName.ToString() +")   "); }             
            }
            else if(txt.Contains("&"))
            {
                pinged = true;
                armPrint("&");
                try { serialPortArm.PortName = s.PortName; armSuc = true; }
                catch { armPrint("two arduino on the same com (" + s.PortName.ToString() + ")   ");};                
                try { s.Close(); /* close the serial port*/}
                catch { armPrint("   ping(&) e: couldn't close (" + s.PortName.ToString() + ")   "); }
                try { serialPortArm.Open(); /* open the serial port*/}
                catch { armPrint("   ping(&) e: couldn't open (" + s.PortName.ToString() + ")   "); }
            }            
        }
        delegate void SetTextCallback(string text);
        private void pianoPrint(string text)
        {
            if (this.comInfoPiano.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(pianoPrint);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lableText("",text);
            }
        }
        private void armPrint(string text)
        {
            if (this.comInfoArm.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(armPrint);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lableText(text, "");
            }
        }
        public void lableText (string text1, string text2)
        {
            if (comInfoArm.Text.Length <= ("Display Controller - Connection Info:").Length + 164 || text1 == "")//192
                comInfoArm.Text += text1;
            else
            {
                comInfoArm.Text = "Display Controller - Connection Info:";
                comInfoArm.Text += text1;
            }
            Application.DoEvents();
            if (comInfoPiano.Text.Length <= (" Piano  Controller - Connection Info:").Length + 164 || text2 == "")//192
                comInfoPiano.Text += text2;
            else
            {
                comInfoPiano.Text = " Piano  Controller - Connection Info:";
                comInfoPiano.Text += text2;
            }
            Application.DoEvents();
        }
        public void PictureClick(object sender, Color press, int time)
        {
            var p = sender as PictureBox;
            Color back = p.BackColor;
            p.BackColor = press;
            Application.DoEvents();
            System.Threading.Thread.Sleep(time);
            p.BackColor = back;
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);///between
        }
        bool pianoSuc = false, armSuc = false;
        private void pingClick(object sender, EventArgs e)
        {
            pianoSuc = false;
            armSuc = false;
            int stop = 0;
            while (!pianoSuc || !armSuc )
            {
                stop++;
                if (stop > 1)
                    break;
                try { PictureClick(sender, Color.CadetBlue, pressTime); } catch { }

                try { serialPortPiano.Close(); /* close the serial port*/} catch { label3.Text += "piano"; }
                try { serialPortArm.Close(); /* close the serial port*/} catch { label3.Text += "arm"; }
                try { serialPortA.Open(); /* open the serial port*/} catch { label3.Text += "a "; }
                try { serialPortB.Open(); /* open the serial port*/} catch { label3.Text += "b "; }
                try { serialPortC.Open(); /* open the serial port*/} catch { label3.Text += "c "; }
                try { serialPortD.Open(); /* open the serial port*/} catch { label3.Text += "d "; }

                try { serialPortA.Write("#" + 9.ToString() + "$"); } catch { label3.Text += "a "; }
                try { serialPortB.Write("#" + 9.ToString() + "$"); } catch { label3.Text += "b "; }
                try { serialPortC.Write("#" + 9.ToString() + "$"); } catch { label3.Text += "c "; }
                try { serialPortD.Write("#" + 9.ToString() + "$"); } catch { label3.Text += "d "; }
            }
        }
        public void PictureBlink(object sender, Image im, int time)
        {
            var p = sender as PictureBox;
            Image back = p.Image;
            p.Image = im;
            Application.DoEvents();
            System.Threading.Thread.Sleep(time);
            p.Image = back;
            Application.DoEvents();
        }
        int packetAmount;
        int packetlen = 5;
        string selectedMelody;
        bool isBusy=false;
        bool toSound = true;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        private void sendMelody(object sender, EventArgs e)
        {
            if (!pinged)
            {
                pingClick(pictureBox26, null);
                System.Threading.Thread.Sleep(500);
            }

            if (pinged)
            {
                bool pianoSuccess = false, armSuccess = false;
                int packetDelay = 250;                

                try { serialPortArm.Close(); /* close the serial port*/}
                catch { lableText("   e: serial Port Arm could't close (" + serialPortArm.PortName.ToString() + ")   ", ""); }

                if (toSound)
                {
                    try { serialPortPiano.Close(); /* close the serial port*/}
                    catch { lableText("", "   e: serial Port Piano could't close (" + serialPortPiano.PortName.ToString() + ")   "); }
                }

                System.Threading.Thread.Sleep(300);
                Application.DoEvents();

                try { serialPortArm.Open(); /* close the serial port*/}
                catch { lableText("   e: serial Port Arm could't open (" + serialPortArm.PortName.ToString() + ")   ", ""); }

                System.Threading.Thread.Sleep(300);
                Application.DoEvents();
                if (toSound)
                {
                    try { serialPortPiano.Open(); /* close the serial port*/}
                    catch { lableText("", "   e: serial Port Piano could't open (" + serialPortPiano.PortName.ToString() + ")   "); }
                }
                System.Threading.Thread.Sleep(100);

                if (!isBusy && songList.Text != "" && songs.ContainsKey(songList.Text + "@") || songList.Text.Contains("Costome Music"))
                {
                    
                    isBusy = true;
                    selectedMelody = songList.Text;
                    if (toSound)
                    {
                        sendTempo();
                        System.Threading.Thread.Sleep(500);
                    }                        
                    if (songs.ContainsKey(selectedMelody) && songs.ContainsKey(selectedMelody + "@"))
                    {
                        packetAmount = (int)Math.Ceiling((float)songs[selectedMelody].Length / packetlen);

                        try
                        {
                            if (toSound)
                            {
                                try { serialPortPiano.Write("#1%"); lableText("", "#1%"); }
                                catch { }
                            }
                            try { serialPortArm.Write("#1%"); lableText("#1%", ""); }
                            catch { }
                            System.Threading.Thread.Sleep(packetDelay);
                            for (int i = 0; i < packetAmount; i++)
                            {
                                string packet = "";
                                for (int j = (i * packetlen); (j < ((i + 1) * packetlen)) && (j < songs[selectedMelody].Length); j++)
                                {
                                    packet += ((char)songs[selectedMelody][j]).ToString();
                                    packet += ((char)songs[selectedMelody + "@"][j]).ToString();
                                }

                                pianoSuccess = false;
                                armSuccess = false;
                                try
                                {
                                    if (toSound)
                                    {
                                        serialPortPiano.Write("%" + packet + "%");
                                        pianoSuccess = true;
                                    }
                                    
                                }
                                catch { }

                                try
                                {
                                    serialPortArm.Write("%" + packet + "%");
                                    armSuccess = true;
                                }
                                catch { }

                                foreach (char k in ("%" + packet + "%"))
                                {
                                    if (pianoSuccess && armSuccess)
                                        lableText(k.ToString(), k.ToString());
                                    else if (pianoSuccess)
                                        lableText("", k.ToString());
                                    else if (armSuccess)
                                        lableText(k.ToString(), "");
                                    System.Threading.Thread.Sleep((int)(packetDelay / (("%" + packet + "%").Length)));
                                }
                            }
                            if (toSound)
                            {
                                try { serialPortPiano.Write("%0$"); lableText("", "%0$"); }
                                catch { }
                            }
                            try { serialPortArm.Write("%0$"); lableText("%0$", ""); }
                            catch { }
                        }
                        catch { }
                    }
                    else if (selectedMelody.Contains("Costome Music"))
                    {
                        packetAmount = (int)Math.Ceiling((float)melodyRec.Length / packetlen);
                        try
                        {
                            if (toSound)
                            {
                                try { serialPortPiano.Write("#1%"); lableText("", "#1%"); }
                                catch { }
                            }
                            try { serialPortArm.Write("#1%"); lableText("#1%", ""); }
                            catch { }
                            System.Threading.Thread.Sleep(packetDelay);
                            bool doBreak = false;
                            for (int i = 0; (i < packetAmount) && (!doBreak); i++)
                            {
                                string packet = "";
                                for (int j = (i * packetlen); (j < ((i + 1) * packetlen)) && (j < melodyRec.Length); j++)
                                {
                                    packet += ((char)melodyRec[j]).ToString();
                                    packet += ((char)defaultType).ToString();
                                    if (melodyRec[j] < 1 || melodyRec[j] > 14)
                                    {
                                        doBreak = true;
                                        break;
                                    }
                                }
                                pianoSuccess = false;
                                armSuccess = false;
                                try
                                {
                                    if (toSound)
                                    {
                                        serialPortPiano.Write("%" + packet + "%");
                                        pianoSuccess = true;
                                    }
                                }
                                catch { }

                                try
                                {
                                    serialPortArm.Write("%" + packet + "%"); lableText("%" + packet + "%", "");
                                    armSuccess = true;
                                }
                                catch { }

                                foreach (char k in ("%" + packet + "%"))
                                {
                                    if (pianoSuccess && armSuccess)
                                        lableText(k.ToString(), k.ToString());
                                    else if (pianoSuccess)
                                        lableText("", k.ToString());
                                    else if (armSuccess)
                                        lableText(k.ToString(), "");
                                    System.Threading.Thread.Sleep((int)(packetDelay / (("%" + packet + "%").Length)));
                                }
                            }
                            if (toSound)
                            {
                                try { serialPortPiano.Write("%0$"); lableText("", "%0$"); }
                                catch { }
                            }
                            try { serialPortArm.Write("%0$"); lableText("%0$", ""); }
                            catch { }
                        }
                        catch { }
                    }
                    if (armSuccess)
                    {
                        string[] splitMelodyName = selectedMelody.Split(':');
                        sendArm(Int32.Parse(splitMelodyName[0]));
                    }
                }
                isBusy = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try { serialPortPiano.Write("*"); lableText("", "*"); }
            catch { }
        }

        public void sendTempo()
        {
            try
            {
                int command = 4;
                int meot = 0, asarot = 0, yehidot = 0;
                meot = (int)(tempo / 100);
                asarot = (int)((tempo - meot) / 10);
                yehidot = tempo - meot - asarot;
                serialPortPiano.Write("#" + command.ToString() + tempo.ToString() + "$");                
                lableText("", "#" + command.ToString() + tempo.ToString() + "$");
            }
            catch { }
        }
        ///////////// works perfectly ////////////
        public void sendArm(int melodyNum) 
        {
            try
            {                
                if (!(melodyNum>=0 && melodyNum <=99))
                {
                    melodyNum = 0;
                }
                serialPortArm.Write( melodyNum.ToString() + "$");
                lableText( melodyNum.ToString() + "$", "");
            }
            catch { }
        }
    }
}
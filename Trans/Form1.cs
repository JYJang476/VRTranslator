using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.CoreAudioApi.Interfaces;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Trans
{
    public partial class frm_trans : Form
    {
        public static frm_trans Instance { get; private set; } = null;
        //public TcpClient client2;
        public Socket tcpsock;
        TcpListener main_server;

        int recindex = 0;

        SoundRecording sr = new SoundRecording();
        WebSockets wss = new WebSockets();
        SoundPlay sp = new SoundPlay();
        SoundDevice sd = new SoundDevice();
        Overlay ovr = new Overlay();

        public float maxp, minp = 0.0f;
        public int deviceindex = 0;
        public bool voicerec;

        bool isStart = false;

        string s_ori, s_sor;

        bool wv_state;
        public frm_trans()
        {
            Instance = this;
            InitializeComponent();
        }

        public byte[] Header(Socket client, FileInfo FI)
        {
            byte[] _data2 = new byte[FI.Length];
            try
            {
                FileStream FS = new FileStream(FI.FullName, FileMode.Open, FileAccess.Read);

                FS.Read(_data2, 0, _data2.Length);
                FS.Close();
                
                string _buf = "HTTP/1.1 200 ok\r\n";
                _buf += "Data: " + FI.CreationTime.ToString() + "\r\n";
                _buf += "server: Myung server\r\n";
                _buf += "Content-Length: " + _data2.Length.ToString() + "\r\n";
                _buf += "charset=UTF-8\r\n";
                _buf += "content-type:text/html\r\n";
                _buf += "\r\n";
                client.Send(Encoding.UTF8.GetBytes(_buf));

            }
            catch
            {
                String _buf = "HTTP/1.1 100 BedRequest ok\r\n";
                _buf += "server: Myung server\r\n";
                _buf += "content-type:text/html\r\n";
                _buf += "\r\n";
                client.Send(Encoding.Default.GetBytes(_buf));
                _data2 = Encoding.Default.GetBytes("Bed Request");
            }
            return _data2;
        }

        public string EncodeWS(string source)
        {
            string result = Convert.ToBase64String(SHA1.Create().ComputeHash(
                Encoding.UTF8.GetBytes(source.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11")));

            return result;
        }


        void ClientListner(Socket ser)
        {
            while (true)
            {
                Socket client1 = ser.Accept();

                try
                {
                    string file = "";
                    byte[] _data = new byte[4096];
                    client1.Receive(_data, _data.Length, SocketFlags.None);                    
                    
                    if (_data.Length > 0)
                    {
                        file = "D:\\Source\\Trans\\Trans\\bin\\x64\\Debug\\index.html";
                        FileInfo FI = new FileInfo(file);
                        client1.Send(Header(client1, FI));
                    }
                }
                catch { }
                finally
                {
                    client1.Close();
                }
            }
        }
        
        public void wsserver(TcpListener server)
        {
            
            TcpClient client2 = server.AcceptTcpClient();

            tcpsock = client2.Client;
            NetworkStream stream = client2.GetStream();

            while (true)
            {
                while (!stream.DataAvailable) ;

                Byte[] bytes = new Byte[client2.Available];

                stream.Read(bytes, 0, bytes.Length);

                if (bytes.Length > 0)
                {
                    string s_data = Encoding.Default.GetString(bytes);

                    if (s_data.IndexOf("websocket") > -1)
                    {
                        wss.SendData(stream, bytes, tcpsock);

                        wss.SendMsg("3:" + s_ori);
                    }
                    else
                    {
                        string webdata = GetDecodedData(bytes);
                        string pardata = webdata.Replace(webdata[0] + ":", null);

                        if (webdata[0].ToString() == "0")
                        {
                            //ovr.Overlay_Close();

                            this.Invoke(new Action(delegate () // this == Form 이다. Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방하다.
                            {
                            //Invoke를 통해 lbl_Result 컨트롤에 결과값을 업데이트한다.
                            
                                //byte[] cbyte = Encoding.ASCII.GetBytes(GetJSONResult(GetTranslate(pardata)));
                            //ovr.Overlay_Send(Encoding.ASCII.GetString(cbyte));
                                Overlay.transtext = GetJSONResult(GetTranslate(pardata));
                                txtt.Text += Overlay.transtext + "\n\r";
                            }));                            
                        }
                        else if(webdata[0].ToString() == "1")
                        {
                            if (voicerec)
                            {
                                this.Invoke(new Action(delegate () // this == Form 이다. Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방하다.
                                {
                                //Invoke를 통해 lbl_Result 컨트롤에 결과값을 업데이트한다.

                                    tm_wave.Start();
                                }));
                            }                            
                        }
                    }
                }
            }
        }

        public static string GetDecodedData(byte[] buffer)
        {
            byte b = buffer[1];
            int dataLength = 0;
            int totalLength = 0;
            int keyIndex = 0;

            if (b - 128 <= 125)
            {
                dataLength = b - 128;
                keyIndex = 2;
                totalLength = dataLength + 6;
            }

            if (b - 128 == 126)
            {
                dataLength = BitConverter.ToInt16(new byte[] { buffer[3], buffer[2] }, 0);
                keyIndex = 4;
                totalLength = dataLength + 8;
            }

            if (b - 128 == 127)
            {
                dataLength = (int)BitConverter.ToInt64(new byte[] { buffer[9], buffer[8], buffer[7], buffer[6], buffer[5], buffer[4], buffer[3], buffer[2] }, 0);
                keyIndex = 10;
                totalLength = dataLength + 14;
            }


            byte[] key = new byte[] { buffer[keyIndex], buffer[keyIndex + 1], buffer[keyIndex + 2], buffer[keyIndex + 3] };

            int dataIndex = keyIndex + 4;
            int count = 0;
            for (int i = dataIndex; i < totalLength; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ key[count % 4]);
                count++;
            }

            return Encoding.UTF8.GetString(buffer, dataIndex, dataLength);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9999);
            Socket server2 = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            server2.Bind(ipep);
            server2.Listen(20);

            txt_ori.SelectedIndex = 0;
            txt_sor.SelectedIndex = 2;

            s_ori = "en-US";
            s_sor = "ko-KR";

            maxp = 0.007f;
            minp = 0.002f;

            Thread th = new Thread(() => ClientListner(server2));
            th.IsBackground = true;
            th.Start();

        }



        private string GetJSONResult(string result)
        {
            int startpos = result.IndexOf("translatedText\":") + "translatedText\":".Length;
            string ex1 = result.Substring(startpos, result.IndexOf(",", startpos + 1) - startpos);
            //string ex2 = "156Text23";
            ex1 = ex1.Replace("\"", null).Trim();


            return ex1;
        }

        private string GetTranslate(string source)
        {
            string url = "https://openapi.naver.com/v1/papago/n2mt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "TSPPTAT5tUdJoJqFU5_d");
            request.Headers.Add("X-Naver-Client-Secret", "q4l5yahpoZ");
            request.Method = "POST";
            string query = source;
            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=" + txt_ori.Text + "&target=" + txt_sor.Text + "&text=" + query);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();
            stream.Close();
            response.Close();
            reader.Close();

            return text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                main_server = wss.CreateServer();

                Thread th1 = new Thread(() => wsserver(main_server));
                th1.Start();

                ProcessStartInfo psi = new ProcessStartInfo("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe");
                psi.Arguments = "--incognito --disable-extensions -app=http://127.0.0.1:9999/ --unsafely-treat-insecure-origin-as-secure=http://127.0.0.1:9999";

                Process.Start(psi);
                isStart = true;
            }
            else if (isStart)
            {
                wss.SendMsg("1:1111");

            }

        }


        private void SendMsg(string msg)
        {
            //tcpsock.Connect(ipep);
            byte[] messages = Encoding.UTF8.GetBytes(msg);

            byte[] dt = new byte[messages.Length + 2];
            dt[0] = 129;
            dt[1] = (byte)messages.Length;
            for (int i = 0; i < messages.Length; i++)
            {

                dt[i + 2] = messages[i];
            }

            tcpsock.Send(dt);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            /*
            if (!wv_state)
            {
                wss.SendMsg("1:1111");
                wv_state = true;
            }
            */
            wss.SendMsg("1:1111");

            //sd.SetDeviceEnable();

        }

        private void tm_wave_Tick(object sender, EventArgs e)
        {


            //float lvl = defaultDevice.AudioMeterInformation.MasterPeakValue;
            

            //EnumDevice[0].AudioMeterInformation.PeakValues[0];

            try
            {
                if (wv_state)
                {

                    float lvl = sd.GetMaskPeekValue(deviceindex);

                    if (lvl <= minp)
                    {

                        
                        sr.RecordStop(recindex);
                        //recindex++;
                        //wss.SendMsg("3:en-US");
                        wv_state = false;
                        //_tmex.Start();
                        label1.Text = "Stop:" + lvl.ToString();
                        
                    }

                }
                else if (!wv_state)
                {
                    float lvl = sd.GetMaskPeekValue(deviceindex);

                    if (lvl >= maxp)
                    {

                        //wss.SendMsg("1:en-US");
                        sr.RecordStart(recindex);
                        recindex++;
                        wv_state = true;

                        label1.Text = "Start:" + lvl.ToString();

                        lbsolist.Items.Add(DateTime.Now.ToString("hh-mm-ss"));
                    }
                }
                
            }
            catch
            {

            }
            
            
        }
    
        private void _tmex_Tick(object sender, EventArgs e)
        {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDeviceCollection EnumDevice = devEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            MMDevice dd = devEnum.GetDevice(EnumDevice[0].ID);
            float lvl = dd.AudioMeterInformation.MasterPeakValue;//EnumDevice[0].AudioMeterInformation.PeakValues[0];


            if (lvl <= 0.01f)
            {
                wss.SendMsg("0:en-US");
                wv_state = false;

                label1.Text = wv_state.ToString();
                _tmex.Stop();
            }
            else
            {
                _tmex.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (wv_state)
            {
                wss.SendMsg("0:1111");
                wv_state = false;
            }
        }



        private void lbsolist_DoubleClick(object sender, EventArgs e)
        {
            sp.SetSound("d:\\sounds\\sound" + lbsolist.SelectedIndex + ".wav");
            sp.Play();
        }

        private void btchange_Click(object sender, EventArgs e)
        {

                SendMsg("3:" + s_ori);

        }

        private void txt_ori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_ori.Text == "Japanese")
            {
                s_ori = "ja-JR";
            }
            else if (txt_ori.Text == "Korean")
            {
                s_ori = "ko-KR";
                
            }
            else if (txt_ori.Text == "English")
            {
                s_ori = "en-US";                
            }

            
        }

        private void frm_trans_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] killproc = Process.GetProcessesByName("chrome");

            foreach (Process proc in killproc)
            {
                //Console.WriteLine(proc.MainWindowTitle);
                if (proc.MainWindowTitle == "127.0.0.1:9999")
                {
                    proc.CloseMainWindow();

                    break;
                }
            }

            ovr.Overlay_Close();

        }

        private void button1_Click(object sender, EventArgs e)        {

            //byte[] bt = Encoding.UTF32.GetBytes("안녕");


            //Overlay.ChangeTxt("안녕");
            // Overlay.transtext = "안녕";
            if (Overlay.transof)
            {
                Overlay.transof = false;
            }
            else if(!Overlay.transof)
            {
                Overlay.transof = true;
            }
           // ovr.Overlay_Send(Encoding.UTF32.GetString(bt));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Overlay.transtext = "테스트입니다";
        }

        private void txt_sor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_sor.Text == "Japanese")
            {
                s_sor = "ja-JR";
            }
            else if (txt_sor.Text == "Korean")
            {
                s_sor = "ko-KR";

            }
            else if (txt_sor.Text == "English")
            {
                s_sor = "en-US";
            }
        }


        private void bt_setting_Click(object sender, EventArgs e)
        {
            frm_Setting fs = new frm_Setting();
            fs.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;

namespace Trans
{
    class WebSockets
    {

        public Socket tcpsock;
        TcpListener main_server;

        private byte[] Header(Socket client, FileInfo FI)
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

        public string EncodeWS(string source)
        {
            string result = Convert.ToBase64String(SHA1.Create().ComputeHash(
                Encoding.UTF8.GetBytes(source.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11")));

            return result;
        }


        private string GetJSONResult(string result)
        {
            int startpos = result.IndexOf("translatedText\":") + "translatedText\":".Length;
            string ex1 = result.Substring(startpos, result.IndexOf(",", startpos + 1) - startpos);

            ex1 = ex1.Replace("\"", null).Trim();


            return ex1;
        }

        private string GetTranslate(string source)
        {
            string url = "https://openapi.naver.com/v1/language/translate";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "");
            request.Headers.Add("X-Naver-Client-Secret", "");
            request.Method = "POST";
            
            string query = source;
            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=" + new frm_trans().txt_ori.Text + "&target=" + new frm_trans().txt_sor.Text + "&text=" + query);
            request.ContentType = "application/x-www-form-urlencoded";
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

        public void SendMsg(string msg)
        {
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

        public void SendData(NetworkStream buf_nt, byte[] bytes, Socket sock)
        {
            tcpsock = sock;

            string s_data = Encoding.Default.GetString(bytes);

            string keypos = s_data.Substring(s_data.IndexOf("Key: ") + 5, s_data.IndexOf("\r\n", s_data.IndexOf("Key: ") + 5) - (s_data.IndexOf("Key: ") + 5));

            string _buf = "HTTP/1.1 101 Switching Protocols\r\n";
            _buf += "Upgrade: websocket\r\n";
            _buf += "Connection: Upgrade\r\n";
            _buf += "charset=UTF-8\r\n";
            _buf += "Sec-WebSocket-Accept: " + EncodeWS(keypos) + "\r\n";

            _buf += "\r\n";

            byte[] res = Encoding.UTF8.GetBytes(_buf);

            buf_nt.Write(res, 0, res.Length);

        }

        public TcpListener CreateServer()
        {
            main_server = new TcpListener(IPAddress.Parse("127.0.0.1"), 49514);
            main_server.Start();

            return main_server;
        }
    }
}

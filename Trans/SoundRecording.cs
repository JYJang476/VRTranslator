using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;
namespace Trans
{
    class SoundRecording
    {
        WaveIn sourceStream;
        WebSockets wss = new WebSockets();
        WaveFileWriter waveWriter = null;

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.WriteData(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        public void RecordStart(int recindex)
        {
            int deviceNumber = 0;

            string saveLocation = "d:\\sounds\\sound" + recindex.ToString() + ".wav";

            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);
            
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            waveWriter = new NAudio.Wave.WaveFileWriter(saveLocation, sourceStream.WaveFormat);

            sourceStream.StartRecording();
        }

        public void RecordStop(int recindex)
        {


            sourceStream.StopRecording();


        }
    }
}

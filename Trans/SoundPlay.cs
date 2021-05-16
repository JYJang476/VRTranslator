using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;

namespace Trans
{
    class SoundPlay
    {
        SoundPlayer wp;
        public void SetSound(string surl)
        {
            wp = new SoundPlayer(surl);
            
        }

        public void Play()
        {
            wp.PlaySync();
        }
        public void Stop()
        {
            wp.Stop();
        }
    }
}

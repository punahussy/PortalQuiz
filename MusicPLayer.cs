using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portalquiz
{
    public class MusicPLayer
    {
        static System.Media.SoundPlayer musicPlayer = 
            new System.Media.SoundPlayer(textures.musica);

        bool isPlaying;

        public void Toggle()
        {
            if (isPlaying)
                Stop();
            else
                Play();
        }

        public void Play()
        {
            musicPlayer.Play();
            isPlaying = true;
            
        }

        public void Stop()
        {
            musicPlayer.Stop();
            isPlaying = false;
        }
    }
}

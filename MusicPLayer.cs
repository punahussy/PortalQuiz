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

        static Thread MusicPlayerThread = new Thread(() => musicPlayer.Play());

        public static void PlayMusic()
        {
            MusicPlayerThread.Start();
        }

        public static void StopMusic()
        {
            MusicPlayerThread.Abort();
        }
    }
}

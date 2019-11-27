using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portalquiz
{
    public class Spikes : IGameObject
    {
        public int X { get; }
        public int Y { get; }

        public int Width { get; }
        public int Height { get; }


        public Bitmap Texture {
            get
            {
                if (IsActive)
                    return textures.spikes;
                else
                    return textures.SpikesUnactive;
            } }

        public Spikes(int x, int y)
        {
            X = x;
            Y = y;
            Width = Form1.TileSize;
            Height = Form1.TileSize;
        }

        public bool IsActive = true;

        //Телепортирует игрока в начало уровня (убивает)
        public void OnCollision(Player player)
        {
            if (IsActive)
            {
                player.Move(player.startPos);
                player.DeltaX = 0;
                player.DeltaY = 0;
            }

        }
    }
}

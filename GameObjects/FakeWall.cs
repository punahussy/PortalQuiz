using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portalquiz.GameObjects
{
    public class FakeWall : IGameObject
    {
        public int X { get; }

        public int Y { get; }

        public int Width { get; }

        public int Height { get; }

        public Bitmap Texture { get { return textures.wall2; } }

        public FakeWall(int x, int y)
        {
            X = x;
            Y = y;
            Width = Height = Form1.TileSize;
        }

        public void OnCollision(Player player)
        {
           
        }
    }
}

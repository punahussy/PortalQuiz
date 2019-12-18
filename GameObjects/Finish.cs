using System.Drawing;

namespace Portalquiz
{
    //Конец уровня 
    public class Finish : IGameObject
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        private const int DefaultWidth = 64;
        private const int DefaultHeight = 64;

        public Bitmap Texture { get { return textures.finish; } }

        public bool IsReached { get; private set; }

        public Finish(int x, int y)
        {
            X = x;
            Y = y;
            Width = DefaultWidth;
            Height = DefaultHeight;
            IsReached = false;
        }

        public void OnCollision(Player player)
        {
            IsReached = true;
        }
    }
}

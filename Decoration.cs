using System.Drawing;

namespace Portalquiz
{

    //Декорации
    public class Decoration : IGameObject
    {
        public int X { get; }
        public int Y { get; }

        public int Width { get; }
        public int Height { get; }

        public Bitmap Texture { get; }

        private const int DefaultWidth = 32;
        private const int DefaultHeight = 32;

        public Decoration(int x, int y)
        {
            X = x;
            Y = y;
            Width = DefaultWidth;
            Height = DefaultHeight;
            Texture = decTextures.grass1;
            
        }

        public Decoration(int x, int y, Bitmap texture, double scale)
        {
            X = x;
            Y = y;
            Width = (int)(DefaultWidth * scale);
            Height = (int)(DefaultHeight * scale);
            Texture = texture;
        }

        public void OnCollision(Player player) { }
    }
}

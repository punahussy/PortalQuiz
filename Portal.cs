using System.Drawing;

namespace Portalquiz
{
    //Портал
    public class Portal : IGameObject
    {
        //Текстура портала
        public Bitmap Texture
        {
            get
            {
                var texture = textures.portal;
                if (LinkedPortal == null)
                    texture = textures.outportal;
                return texture;
            }
        }

        //Параметры портала
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        private const int defaultWidth = 90;
        private const int defaultHeight = 90;

        //Выходной портал
        public Portal LinkedPortal;

        //Конструктор для входного портала
        public Portal(int x, int y, Portal linkedPortal)
        {
            X = x;
            Y = y;
            Width = defaultWidth;
            Height = defaultHeight;
            LinkedPortal = linkedPortal;
        }

        //Конструктор для выходного портала
        public Portal(int x, int y)
        {
            X = x;
            Y = y;
            Width = defaultWidth;
            Height = defaultHeight;
        }

        //Телепортация игрока в портал выхода
        public void OnCollision(Player player)
        {
            if (LinkedPortal != null)
            {
                player.Move(LinkedPortal.X, LinkedPortal.Y + LinkedPortal.Height / 2);
            }
        }

    }
}

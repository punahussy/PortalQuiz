using System.Drawing;

namespace Portalquiz
{
    //Стена
    public class Wall : IGameObject
    {
        public Bitmap Texture { get { return textures.wall2; } }

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            Width = Form1.TileSize;
            Height = Form1.TileSize;
        }

        //Останавливает игрока при столкновении
        public void OnCollision(Player player)
        {
            if (player.DeltaX < 0)
                player.DeltaX = 0;
            else if (player.DeltaX > 0)
                player.DeltaX = 0;

            if (player.DeltaY < 0)
                if (Y - player.Y - Form1.TileSize != 0)
                    player.DeltaY = 0;
                else player.DeltaY = 0;

            else if (player.DeltaY > 0)
                if (Y + Form1.TileSize - player.Y != 0)
                    player.DeltaY = 0;
                else player.DeltaY = 0;
        }
    }
}

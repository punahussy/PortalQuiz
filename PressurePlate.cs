using System;
using System.Drawing;

namespace Portalquiz
{
    public class PressurePlate : IGameObject
    {
        public int X { get; }
        public int Y { get; }

        public int Width { get; }
        public int Height { get; }

        public Bitmap Texture => throw new NotImplementedException();

        private const int DefaultWidth = 64;
        private const int DefaultHeight = 64;

        //Нажата ли кнопка
        //private bool IsPressed;

        public PressurePlate(int x, int y)
        {
            X = x;
            Y = y;
            Width = DefaultWidth;
            Height = DefaultHeight;
        }

        public void OnCollision(Player player)
        {
            //IsPressed = false;
        }
    }
}

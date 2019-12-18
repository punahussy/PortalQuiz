using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Portalquiz
{
    //Объект игрок
    public class Player
    {
        public Bitmap Texture { get; private set; }

        private Dictionary<directions, Bitmap> playerTextures = new Dictionary<directions, Bitmap>
        {
            { directions.up, textures.playerUp },
            { directions.down, textures.playerDown },
            { directions.right, textures.playerRight },
            { directions.left, textures.playerLeft }
        };

        public int X { get; private set; }
        public int Y { get; private set; }
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Tuple<int, int> startPos;

        //Конструктор
        public Player()
        {
            Width = Form1.TileSize - 8;
            Height = Form1.TileSize - 8;
            Texture = textures.playerRight;
        }

        //Конструктор с начальными координатами
        public Player(Tuple<int, int> coords) : this()
        {
            startPos = coords;
            X = coords.Item1;
            Y = coords.Item2;
        }

        public Player(int x, int y) : this()
        {
            startPos = Tuple.Create(x, y);
            X = x;
            Y = y;
        }

        //Проверяет, сталкивается ли игрок с объектом
        public bool IsCollide(IGameObject obj)
        {
            int tempX = X;
            int tempY = Y;
            int tempW = Width;
            int tempH = Height;


            //При входе в портал телепортация происходит только после прохождения половины портала
            if (obj is Portal)
            {
                tempW -= obj.Width / 2;
                tempH -= obj.Height / 2;
                tempY += Height / 2;
            }

            //Игрок умрет только если наступит на шипы
            else if (obj is Spikes)
            {
                tempW -= (int)(obj.Width * 0.15);
                tempH -= (int)(obj.Height * 0.15);
            }

            //Проверит следующие координаты игрока на столкновение со стеной
            else if (obj is Wall)
            {
                tempX += DeltaX;
                tempY += DeltaY;
            }

            return CheckCollision(obj, tempX, tempY, tempW, tempH);
            
        }

        private static bool CheckCollision(IGameObject obj, int X, int Y, int Width, int Height)
        {
            bool isCollide;
            //Поиск коллизии с объектом
            if (X < obj.X + obj.Width &&
                X + Width > obj.X &&
                Y < obj.Y + obj.Height &&
                Y + Height > obj.Y)
            {
                isCollide = true;
            }
            else isCollide = false;
            return isCollide;
        }

        //Двигает игрока на deltaX и deltaY
        public void Move()
        {
            X += DeltaX;
            Y += DeltaY;
            DeltaX = 0;
            DeltaY = 0;
        }

        //Двмигает игрока на указанные х и у
        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        //Помещает игрока в позицию playerCoordinates
        public void Move(Tuple<int, int> playerCoordinates)
        {
            X = playerCoordinates.Item1;
            Y = playerCoordinates.Item2;
        }

        public void Turn(directions direction)
        {
            Texture = playerTextures[direction];
        }
    }
}

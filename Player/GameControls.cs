using System.Collections.Generic;
using System.Windows.Forms;

namespace Portalquiz
{
    //Делегат, хранящий в себе команду, выполняемую при нажатии клавиш
    delegate void OnPressCommand();

    //Статический класс управления игры
    static class GameControls
    {
        //Обработка нажатия клавиш
        public static void Controls(object sender, KeyEventArgs e)
        {
            if (e != null && Commands.ContainsKey(e.KeyCode))
                Commands[e.KeyCode]();
        }

        //Скорость игрока
        private const int Speed = 8;

        //Словарь действий по нажатию клавиш
        private static Dictionary<Keys, OnPressCommand> Commands = new Dictionary<Keys, OnPressCommand>
        {
            { Keys.W, MoveUp },
            { Keys.S, MoveDown },
            { Keys.A, MoveLeft },
            { Keys.D, MoveRight },
            { Keys.Up, MoveUp},
            { Keys.Down, MoveDown },
            { Keys.Left, MoveLeft },
            { Keys.Right, MoveRight },
            { Keys.M, () => Form1.musPlayer.Toggle() },
            { Keys.X, () => Form1.player.Move(Form1.player.X + 1, Form1.player.Y + 1) },
            { Keys.Z, () => Form1.player.Move(Form1.player.X - 1, Form1.player.Y - 1)},
            { Keys.Escape,

               () =>  
               {
                var answer = MessageBox.Show("Вы точно хотите выйти?", "Выход их игры", MessageBoxButtons.YesNo);
                if(answer == DialogResult.Yes)
                   {
                       Form1.musPlayer.Stop();
                       Application.Exit();
                   }
               }
            },
        };


        static void MoveUp()
        {
            Form1.player.DeltaY -= Speed;
            if (!Form1.debug)
                Form1.player.Turn(directions.up);
        }

        static void MoveDown()
        {
            Form1.player.DeltaY += Speed;
            if (!Form1.debug)
                Form1.player.Turn(directions.down);
        }

        static void MoveRight()
        {
            Form1.player.DeltaX += Speed;
            if (!Form1.debug)
                Form1.player.Turn(directions.right);
        }

        static void MoveLeft()
        {
            Form1.player.DeltaX -= Speed;
            if (!Form1.debug)
                Form1.player.Turn(directions.left);
        }


    }

    public enum directions
    {
        up,
        down,
        right,
        left
    }
}

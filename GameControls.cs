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
            { Keys.W, () => Form1.player.DeltaY -= Speed},
            { Keys.S, () => Form1.player.DeltaY += Speed},
            { Keys.A, () => Form1.player.DeltaX -= Speed},
            { Keys.D, () => Form1.player.DeltaX += Speed},
            { Keys.Up,() => Form1.player.DeltaY -= Speed},
            { Keys.Down, () => Form1.player.DeltaY += Speed },
            { Keys.Left, () => Form1.player.DeltaX -= Speed },
            { Keys.Right, () => Form1.player.DeltaX += Speed },
            { Keys.Escape,

               () =>  
               {
                var answer = MessageBox.Show("Вы точно хотите выйти?", "Выход их игры", MessageBoxButtons.YesNo);
                if(answer == DialogResult.Yes) 
                    Application.Exit();
               }
            },
        };
    }
}

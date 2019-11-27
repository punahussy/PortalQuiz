using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Portalquiz
{

    public partial class Form1 : Form
    {
        //Размеры поля в клетках по TileSize пиксела
        const int TilesWide = 16;
        const int TilesHeight = 10;
        //Размер текстуры клетки
        public const int TileSize = 64;

        #region Уровни
        //Текущий уровень
        private Level currentLevel = Levels[0];
        private int currentLevelNumber = 0;
        //Массив доступных уровней
        private static Level[] Levels = LevelCreator.CreateLevels(GameLevels.LevelMaps);
        #endregion

        public Form1()
        {
            InitializeComponent();
            

            //Устранение мерцания
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint, true);
            UpdateStyles();

            //Запрет разворачивания окна
            MaximizeBox = false;
            
            //Установка размера игровой области
            ClientSize = new Size(TileSize * TilesWide, TileSize * TilesHeight); 
            //Назначение обработчика нажатия клавиш
            KeyDown += new KeyEventHandler(GameControls.Controls);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer musicPlayer = new System.Media.SoundPlayer();
            musicPlayer.SoundLocation = @"C:\Users\raket\OneDrive\ed\C#\FormGeme\FormGeme\bin\Debug\music\music.wav";
            musicPlayer.Load();
            musicPlayer.Play();
            TopMost = true;
        }

        //Обновление на тик таймера
        private void Timer_tick(object sender, EventArgs e)
        {
            
            label1.Text = currentLevelNumber.ToString() + " Уровень";
            currentLevel.ElapsedTime++;
            label2.Text = "Время: " + Math.Round(currentLevel.ElapsedTime / 30, 1).ToString();
            CheckCollisions();
            player.Move();
            FinishLevel();
            Refresh();

        }

        //Игрок
        public static Player player = new Player(Levels[0].PlayerCoordinates);

        //Отрисовка игры
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Отрисовка всех объектов уровня
            foreach (IGameObject obj in currentLevel)
            {
                g.DrawImage(obj.Texture,
                    new Rectangle(obj.X, obj.Y, obj.Width, obj.Height));
            }

            //Отрисовка игрока
            g.DrawImage(player.Texture, new Rectangle(player.X, player.Y, player.Width, player.Height));
            
        }

        //Проверяет столкновения игрока с игровыми объектами
        private void CheckCollisions()
        {

            foreach (IGameObject obj in currentLevel)
            {

                if (player.IsCollide(obj))
                {
                    obj.OnCollision(player);
                    if (obj is Finish)
                        currentLevelNumber++;
                    break;
                }

            }
        }

        //Заканчивает уровень или игру, если все уровни пройдены
        public void FinishLevel()
        {
            if (currentLevel.LevelFinish.IsReached)
            {
                if (currentLevelNumber < Levels.Length)
                {
                    currentLevel = Levels[currentLevelNumber];
                    player.Move(currentLevel.PlayerCoordinates);
                    player.startPos = currentLevel.PlayerCoordinates;
                    Thread.Sleep(100);
                }
                else
                {
                    timer1.Stop();
                    string records = "Вы прошли игру! \n Итоги: \n";
                    for (int i = 0; i < Levels.Length; i++)
                    {   
                        records += String.Format("На {0} уровень затрачено {1}с \n", 
                            i, Math.Round(Levels[i].ElapsedTime/30,1)); 
                    }
                    MessageBox.Show(records, "Поздравляем!", MessageBoxButtons.OK);
                    Application.ExitThread();

                }
            }
        }
    }
}

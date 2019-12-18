using System;
using System.Collections;
using System.Collections.Generic;

namespace Portalquiz
{
    //Игровой уровень
    public class Level : IEnumerable
    {
        //Координаты игрока
        public Tuple<int,int> PlayerCoordinates;

        //Стены уровня
        public List<Wall> LevelWalls = new List<Wall>();

        //Порталы уровня
        public List<Portal> LevelPortals = new List<Portal>();

        //Шипы уровня
        public List<Spikes> LevelSpikes = new List<Spikes>();

        //Финиш уровня
        public Finish LevelFinish { get; set; }

        //Кнопки уровня
        public List<PressurePlate> LevelPressurePlates = new List<PressurePlate>();

        //Декорации на уровне
        public List<Decoration> LevelDecorations = new List<Decoration>();

        //Время в тиках, затраченное на прохождение
        private int elapsedTime;
        public double ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = (int)value;
                if (LevelSpikes != null)
                {
                    SpikesTimer++;
                    if (SpikesTimer == (30 * SpikesPeriod))
                    {
                        SpikesTimer = 0;
                        ToggleSpikes();
                    }
                }
            }
        }
        private int SpikesTimer = 0;
        //Время, через которое переключаются шипы в секундах
        public int SpikesPeriod = 2;

        //Создание пустого уровня со стандартными координатами игрока и финиша
        public Level()
        {
            PlayerCoordinates = Tuple.Create(128, 64);
            LevelFinish = new Finish(600, 200);
        }

        //Переключение шипов
        private void ToggleSpikes()
        {
            foreach (Spikes spikes in LevelSpikes)
            {
                spikes.IsActive = !spikes.IsActive;
            }

        }

        //Реализация IEnumerable для перебора объектов уровня
        public IEnumerator GetEnumerator()
        {
            if (LevelWalls != null)
            {
                foreach (Wall wall in LevelWalls)
                    yield return wall;
            }
            if (LevelSpikes != null)
            {
                foreach (Spikes spikes in LevelSpikes)
                    yield return spikes;
            }
            if (LevelPortals != null)
            {
                foreach (Portal portal in LevelPortals)
                {
                    yield return portal;
                    if (portal.LinkedPortal != null)
                        yield return portal.LinkedPortal;
                }
            }
            if (LevelDecorations != null)
            {
                foreach (Decoration decoration in LevelDecorations)
                    yield return decoration;
            }            
            yield return LevelFinish;
        }
    }
}

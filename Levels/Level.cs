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

        //Финиш уровня
        public Finish LevelFinish { get; private set; }

        //Все игровые объекты уровня 
        public List<IGameObject> LevelObjects = new List<IGameObject>();

        //Время в тиках, затраченное на прохождение
        private int elapsedTime;
        public double ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = (int)value;
                SpikesTimer++;
                if (SpikesTimer == (30 * SpikesPeriod))
                {
                    SpikesTimer = 0;
                    ToggleSpikes();
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

        public void SetFinish(Finish finish)
        {
            LevelFinish = finish;
        }

        //Переключение шипов
        private void ToggleSpikes()
        {
            foreach (var obj in LevelObjects)
            {
                if (obj is Spikes spikes)
                    spikes.IsActive = !spikes.IsActive;
            }

        }

        //Реализация IEnumerable для перебора объектов уровня
        public IEnumerator GetEnumerator()
        {
            if (LevelObjects != null)
            {
                foreach (IGameObject obj in LevelObjects)
                {
                    yield return obj;
                    if (obj is Portal portal)
                    {
                        yield return portal.LinkedPortal;
                    }
                }
            }
            
            yield return LevelFinish;
        }
    }
}

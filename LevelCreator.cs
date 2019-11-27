using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portalquiz
{
    //Делегат, хранящий метод создания игрового объекта
    delegate IGameObject CreateObject(int x, int y);

    //Содержит  карты уровней и методы генерации уровней
    public static class LevelCreator
    {
        private const int TileSize = Form1.TileSize;

        //Значение символов при создании карт
        private static Dictionary<char, CreateObject> DefineObject = new Dictionary<char, CreateObject>
        {
            {'W', (x,y) => new Wall(x,y)},
            {'F', (x,y) => new Finish(x,y)},
            {'G', (x,y) => new Decoration(x,y,decTextures.grass1, 1)},
            {'g', (x,y) => new Decoration(x+16,y+16,decTextures.grass1, 0.5) },
            {'R', (x,y) => new Decoration(x,y,decTextures.roses, 1) },
            {'r', (x,y) => new Decoration(x+16,y+16,decTextures.roses, 0.5) },
            {'L', (x,y) => new Decoration(x,y,decTextures.puddle1, 2)},
            {'S', (x,y) => new Spikes(x,y) },
            {'A', (x,y) => new Decoration(x,y,decTextures.water, 2) },

        };

        //Обозначния порталов
        private static char[] PortalSymbols = new char[]
        {
            'P','p',
            'O','o',
        };

        private const char PlayerSymbol = 'C';

        //Возвращает массив уровней, построенных по картам
        public static Level[] CreateLevels(List<string> LevelMaps)
        {
            //Массив уровней
            Level[] gameLevels = new Level[LevelMaps.Count];
            //Перебирает карты в массиве LevelMaps
            for (int map = 0; map < LevelMaps.Count; map++)
            {
                IsCorrect(LevelMaps[map]);
                gameLevels[map] = BuildMap(LevelMaps[map]);
            }
            return gameLevels;
            
        }

        //Проверяет, корректен ли уровень
        private static void IsCorrect(string map)
        {
            foreach (char symbol in map)
            {
                int players = 0;
                int finishes = 0;
                if (symbol == PlayerSymbol)
                    players++;
                if (symbol == 'F')
                    finishes++;
                if (players > 1)
                    throw new Exception("Игроков больше чем 1!");
                if (finishes > 1)
                    throw new Exception("Финишей больше чем 1!");
            }
        }

        //Строит уровень по карте
        private static Level BuildMap(string LevelMap)
        {
            //Уровень
            Level currentLevel = new Level();
            //Деление карты на строчки
            var Rows = LevelMap.Split('\n');
            //Порталы уровня и заданная им буква
            Dictionary<char, Portal> inPortals = new Dictionary<char, Portal>();
            Dictionary<char, Portal> outPortals = new Dictionary<char, Portal>();

            //Перебор по столбцу (у)
            for (int y = 0; y < Rows.Length; y++)
            {
                //Обрабатываемая строка
                char[] currentRow = Rows[y].Where(symbol => symbol != ' ').ToArray();
                //Перебор по строке (х)
                for (int x = 0; x < currentRow.Length; x++)
                {
                    //Рассматриваемый символ
                    var currentObjChar = currentRow[x];
                    //Если он есть в словаре, создает его и располагает в нужной клетке уровня
                    if (DefineObject.ContainsKey(currentObjChar))
                    {
                        Place(currentLevel, DefineObject[currentObjChar](x * TileSize, y * TileSize));
                    }
                    //Если нет, проверяет, может ли он быть порталом
                    else if (PortalSymbols.Contains(currentObjChar))
                    {
                        //Создает два словаря для входных и выходных порталов
                        if (Char.IsUpper(currentObjChar))
                            inPortals.Add(currentObjChar, new Portal(x * TileSize, y * TileSize));
                        else
                            outPortals.Add(currentObjChar, new Portal(x * TileSize, y * TileSize));
                    }
                    //Если это игрок, устанавливает его стартовую позицию на уровне
                    else if (currentObjChar == PlayerSymbol)
                        currentLevel.PlayerCoordinates = Tuple.Create(x * TileSize, y * TileSize);
                }
            }
            //Создание порталов уровня
            currentLevel.LevelPortals = CreatePortals(inPortals, outPortals);
            return currentLevel;
        }

        //Создает список порталов
        private static List<Portal> CreatePortals(Dictionary<char, Portal> inPortals,
                                                  Dictionary<char, Portal> outPortals)
        {
            foreach (var key in inPortals.Keys)
            {
                if (outPortals.ContainsKey(Char.ToLower(key)))
                    inPortals[key].LinkedPortal = outPortals[Char.ToLower(key)];
            }
            return inPortals.Values.ToList();
        }

        //Размещает объект obj на уровне level
        private static void Place(Level level, IGameObject obj)
        {
            if (obj is Wall)
                level.LevelWalls.Add((Wall)(obj));
            else if (obj is Decoration)
                level.LevelDecorations.Add((Decoration)obj);
            else if (obj is Finish)
                level.LevelFinish = new Finish(obj.X, obj.Y);
            else if (obj is Spikes)
                level.LevelSpikes.Add((Spikes)obj);
            else if (obj is PressurePlate)
                level.LevelPressurePlates.Add((PressurePlate)obj);
            else
                throw new NotImplementedException("Установка этого игрового объекта не назначена");

        }

    }
}

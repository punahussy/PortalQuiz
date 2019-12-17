using System.Collections.Generic;

namespace Portalquiz
{
    public static class GameLevels
    {
        //Карты уровней игры
        public static List<string> LevelMaps = new List<string>
        {
            //0 Уровень
            @"W W W W W W W W W W W W W W W W
              W - - - - - - - - - - - - - - W
              W - - - - - - - - - - - - - - W              
              W - - - - r G R - g - - - - - W
              W - - C r R r G r r g F - - - W
              W - - - - g G - - g - - - - - W
              W - - - - - - - - - - - - - - W
              W - - - - - - - - - - - - - - W
              W - - - - - - - - - - - - - - W
              W W W W W W W W W W W W W W W W",

            //0.5 уровень
            @"W W W W W W W W W W W W W W W W
              W S S S S S S S S S S S S S S W
              W S S S S - - F - - S S S S S W              
              W S S S - S W W W - - S S S S W
              W S S S - W - C G W - S S S S W
              W S S S - W - r - W - S S S S W
              W S S S - W W - W W R S S S S W
              W S S S - - g - - r - S S S S W
              W S S S S S S S S S S S S S S W
              W W W W W W W W W W W W W W W W",

            //1 уровень
             @"W W W W W W W W W W W W W W W W
              W - - W - r - o - G g W - - - W
              W - - W - G R r G - r W - O - W              
              W - - W - - - F g - - W - - - W
              W - - W W W W W W W W W - - - W
              W - r - G - - - - - r g - - - W
              W g G G R - - - - g G R - - - W
              W g R G G - - C - L r r - - - W
              W - - - - - - - - - G - - - - W
              W W W W W W W W W W W W W W W W",

            //2 уровень
            @"W W W W W W W W W W W W W W W W
              W r r G W R r R g R g R r R r W
              W G C - W - g g g r - - o - - W              
              W - - - S - - - - - - - - - - W
              W - R - S - - - L - - W W W W W
              W G - G W - - - - - - - - - - W
              W - = - W - r R r - - - F - - W
              W - O - W g G r G g - - - - - W
              W - - - W - - - - - - - - - - W
              W W W W W W W W W W W W W W W W",

            //3 уровень
            @"A A A A A A A A A A A W W W W W
              A W W W W W A A A A A W - O - W
              A W - p - W A A A A A W - - - W              
              A W - - - W A A A A A W - C - W
              A W - F - W A A A A A W W W W W
              A W W W W W W W W A A A A A A A
              A W - - - S - - - W A A A A A A
              A W - o - S - P - W A A A A A A
              A W - - - S - - - W A A A A A A
              A W W W W W W W W A A A A A A A",

            //4 уровень
            @"W W W W W W W W W W W W W W W W
              W G r G S S - S r - - W A A A W
              W C r g S S - S G O - W A A A W              
              W g - R S S - S R g - W A A A W
              W S S S W W W W W W W R L G G W
              W - - - W g G - - g W - - r - W
              W S S S W - - - o - W - g G - W
              W - - - S F - - - - W - r - G W
              W - - - S - - - - - W - - r - W
              W W W W W W W W W W W W W W W W",

            //5 уровень
            @"W W W W W W W W W W W W W W W W
              W C W - - - S - O - W - W p g W
              W - W - W W W - - - S - W - - W              
              W - W - - r W r - r W - W W F W
              W g W W W - W W W W - - - - W W
              W - r - - - - - r - S W - L - W
              W W W W - W W W S W W W W W - W
              W - - - - W R g - W o - S P - W
              W - W W W W - r G - - - S - g W
              W - - - S - - W W W W W W W W W
              W W W W W W W",

              
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cocbasebuilder
{
    public static class GlobalVar
    {
        public const int PopulationSize = 500;
        public const int MaxScore = 1000;
        public const int TileSize = 42;
        public const int BaseShape = 0;
        public const int TotalBuildings = 12;
        public const int Generations = 200;
        public const bool PlaceAdjacent=false;
        public const int buffer = 7;
        public const int ScoreCutoff = 4500000;
        public const int BuildingScoreCutoff = 999999;
        public const double elitepop = 0.142;
        public const double mergeCount = 2;
    }
}

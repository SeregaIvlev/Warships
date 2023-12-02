using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warships
{
    public class BattleField
    {

        public bool[,] shipPlacement = new bool[10, 10];
        public bool[,] shipDestroyed = new bool[10, 10];
        public bool[,] shooted = new bool[10, 10];
        public bool[,] hitted = new bool[10, 10];
        public bool[,] forbiddenToShot = new bool[10, 10];
        public bool[,] forbiddenToPlace = new bool[10, 10];

    }
}

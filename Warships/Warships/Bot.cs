using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warships
{
    public class Bot
    {
        public string nickname = "AI";
        public Image icon = Image.FromFile("avs/0.png");
        BattleField bf = new BattleField();
        public Bot() {
            Miscleanous.FillRandomly(bf);
        }
        public bool ShotToBot(Point p)
        {
            if (bf.shipPlacement[p.X, p.Y])
            {
                bf.shipDestroyed[p.X, p.Y] = true;
                return true;
            }
            else
                return false;
        }
        public Point ShotByBot()
        {
            
            Random r = new Random();
            int x, y;
            do
            {
                x = r.Next(10);
                y = r.Next(10);
            } while (bf.shooted[x, y] == true);
            bf.shooted[x, y] = true;
            Point point = new Point(x,y);
            return point;
        }
        public bool IsDestroyedWhole(int pX, int pY)
        {
            int X = pX; 
            int Y = pY;
            while (X > 0 && bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == true) X--;
            if (bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == false) return false;

            X = pX;
            Y = pY;
            while (X < 9 && bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == true) X++;
            if (bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == false) return false;

            X = pX;
            Y = pY;
            while (Y > 0 && bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == true) Y--;
            if (bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == false) return false;

            X = pX;
            Y = pY;
            while (Y < 9 && bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == true) Y++;
            if (bf.shipPlacement[X, Y] == true && bf.shipDestroyed[X, Y] == false) return false;

            return true;
        }
        public bool AllIsDestroyed()
        {
            return Miscleanous.AllIsDestroyed(bf);
        }
        
    }
}

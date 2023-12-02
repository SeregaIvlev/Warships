using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warships
{
    internal static class Miscleanous
    {
        public enum battleType
        {
            vsEasyBot,
            vsMediumBot,
            vsHardBot,
            Server,
            Client
        }
        public static bool AllIsDestroyed(BattleField bf)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (bf.shipPlacement[i, j] == true && bf.shipDestroyed[i, j] == false) return false;
                }
            return true;
        }
        public static bool IsPossibleToPlaceHere(BattleField bf, int shipSize, bool rotated, int x, int y) 
        {
            while(shipSize != 0)
            {
                if(x >= 0 && x < 10 && y >= 0 && y < 10 && bf.forbiddenToPlace[x, y] == false)
                {
                    shipSize--;
                    if (rotated)
                        y++;
                    else
                        x++;
                }
                else
                    return false;
            }
            return true;
        }
        public static void PlaceShip(BattleField bf, int shipSize, bool rotated, int x, int y)
        {
            for(int i = 0; i < shipSize; i++)
            {
                bf.shipPlacement[x, y] = true;
                ForbidAround(bf.forbiddenToPlace, x,y);
                if(rotated) y++;
                else x++;
            }
        }
        public static void ForbidAround(bool[,] forbidden, int x, int y)
        {
            forbidden[x, y] = true;

            if (x > 0) forbidden[x - 1, y] = true;
            if (y > 0) forbidden[x, y - 1] = true;
            if (x < 9) forbidden[x + 1, y] = true;
            if (y < 9) forbidden[x, y + 1] = true;

            if (x > 0 && y > 0) forbidden[x - 1, y - 1] = true;
            if (x > 0 && y < 9) forbidden[x - 1, y + 1] = true;
            if (x < 9 && y > 0) forbidden[x + 1, y - 1] = true;
            if (x < 9 && y < 9) forbidden[x + 1, y + 1] = true;
        }
        public static void FillLines(Bitmap bmp, int x, int y)
        {
            x = x * 50;
            y = y * 50;
            using (var graphics = Graphics.FromImage(bmp))
            {
                Pen blackPen = new Pen(Color.Red, 1);
                graphics.DrawLine(blackPen, x+8, y, x + 49, y + 12);
                graphics.DrawLine(blackPen, x + 1, y + 5, x + 50, y + 20);
                graphics.DrawLine(blackPen, x+30, y, x + 49, y + 5);
                graphics.DrawLine(blackPen, x + 1, y + 5, x + 49, y + 20);
                graphics.DrawLine(blackPen, x + 1, y + 23, x + 50, y + 38);
                graphics.DrawLine(blackPen, x+1, y + 13, x + 49, y + 28);
                graphics.DrawLine(blackPen, x+1, y + 32, x + 49, y + 47);
                graphics.DrawLine(blackPen, x+1, y + 40, x + 30, y + 49);
            }
        }


        public static Image selectPreview()
        {
            return null;
        }

        public static void FillRandomly(BattleField bf)
        {
            Random r = new Random();
            int x, y;
            bool rotated;

            int shipSize = 4;
            for (int i = 0; i < 1; i++)
            {
                do
                {
                    x = r.Next(10);
                    y = r.Next(10);
                    rotated = r.Next() % 2 == 0;
                } while (!Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                Miscleanous.PlaceShip(bf, shipSize, rotated, x, y);
            }
            shipSize = 3;
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    x = r.Next(10);
                    y = r.Next(10);
                    rotated = r.Next() % 2 == 0;
                } while (!Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                Miscleanous.PlaceShip(bf, shipSize, rotated, x, y);
            }
            shipSize = 2;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    x = r.Next(10);
                    y = r.Next(10);
                    rotated = r.Next() % 2 == 0;
                } while (!Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                Miscleanous.PlaceShip(bf, shipSize, rotated, x, y);
            }
            shipSize = 1;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x = r.Next(10);
                    y = r.Next(10);
                    rotated = r.Next() % 2 == 0;
                } while (!Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                Miscleanous.PlaceShip(bf, shipSize, rotated, x, y);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Warships.Miscleanous;

namespace Warships
{
    public partial class Layout : Form
    {
        Game g;
        BattleField bf = new BattleField();

        Bitmap RawOcean = new Bitmap("water-4.jpg");
        Pen blackPen = new Pen(Color.Black, 3);
        Image ship_1 = Image.FromFile("1.png");

        public Layout(Game g)
        {
            this.g = g;
            InitializeComponent();
        }


        int[] shipCount = new int[4] { 4, 3, 2, 1 };

        bool dragActive = true;
        bool rotated = false;
        int shipSize = 1;
        int lastX = 1;
        int lastY = 1;
        public void updateLayout()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (bf.forbiddenToPlace[i, j] == true && bf.shipPlacement[i, j] == false) Miscleanous.FillLines(RawOcean, i, j);

            using (var graphics = Graphics.FromImage(RawOcean))
            {
                graphics.DrawImage(ship_1, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
            }
            select_1_ship.Text = ": " + shipCount[0];
            select_2_ship.Text = ": " + shipCount[1];
            select_3_ship.Text = ": " + shipCount[2];
            select_4_ship.Text = ": " + shipCount[3];
            pictureBox1.Image = RawOcean;

        }
        public void resetLayout()
        {
            bf.forbiddenToPlace = new bool[10,10];
            bf.shipPlacement = new bool[10, 10];
            RawOcean = new Bitmap("water-4.jpg");
            shipCount = new int[4] { 4, 3, 2, 1 };
            updateLayout();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (true && dragActive) //left click 
            {
                shipSize = GetSizeOfShip();
                if (shipSize != -1)
                    if (Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, lastX, lastY))
                    {
                        Miscleanous.PlaceShip(bf, shipSize, rotated, lastX, lastY);
                        updateLayout();

                        shipCount[shipSize - 1]--;
                        if (shipCount[0] == 0) { select_1_ship.Checked = false; select_1_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[1] == 0) { select_2_ship.Checked = false; select_2_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[2] == 0) { select_3_ship.Checked = false; select_3_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[3] == 0) { select_4_ship.Checked = false; select_4_ship.Enabled = false; selectNextShip(); }
                    }
            }
        }
        private void selectNextShip()
        {
            if (shipCount[0] != 0) select_1_ship.Checked = true;
            else if (shipCount[1] != 0) select_2_ship.Checked = true;
            else if (shipCount[2] != 0) select_3_ship.Checked = true;
            else if (shipCount[3] != 0) select_4_ship.Checked = true;
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)  //анимация
        {
            int X = e.Location.X;
            int Y = e.Location.Y;
            X = X / 50;
            Y = Y / 50;
            if (X % 50 >= 25) X++;
            if (Y % 50 >= 25) Y++;

            if (X != lastX || Y != lastY)
            {
                Bitmap ocean = new Bitmap(RawOcean);
                using (var graphics = Graphics.FromImage(ocean))
                {
                    graphics.DrawImage(ship_1, X * 50 + 5, Y * 50 + 5, 40, 40);
                }
                pictureBox1.Image = ocean;
                lastX = X;
                lastY = Y;
            }

        }
        private int GetSizeOfShip()
        {
            if (select_1_ship.Checked) return 1;
            else if (select_2_ship.Checked) return 2;
            else if (select_3_ship.Checked) return 3;
            else if (select_4_ship.Checked) return 4;
            else return -1;
        }
        private void RotateButton_Click(object sender, EventArgs e)
        {
            rotated = !rotated;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (shipCount[0] == 0 && shipCount[1] == 0 && shipCount[2] == 0 && shipCount[3] == 0)
            {
                int bt = 0;
                Battle bf = new Battle(g);
                bf.Show();
                this.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            resetLayout();
        }
    }
}

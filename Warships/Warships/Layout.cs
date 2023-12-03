using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Warships.Miscleanous;
using System.Security.Policy;

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


            select_1_ship.Text = ": " + shipCount[0];
            select_2_ship.Text = ": " + shipCount[1];
            select_3_ship.Text = ": " + shipCount[2];
            select_4_ship.Text = ": " + shipCount[3];

            pictureBox1.Image = RawOcean;

        }
        public void resetLayout()
        {
            bf.forbiddenToPlace = new bool[10, 10];
            bf.shipPlacement = new bool[10, 10];
            RawOcean = new Bitmap("water-4.jpg");

            shipCount = new int[4] { 4, 3, 2, 1 };
            select_1_ship.Enabled = true;
            select_2_ship.Enabled = true;
            select_3_ship.Enabled = true;
            select_4_ship.Enabled = true;
            selectNextShip();
            shipSize = GetSizeOfShip();

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
                        Image icon = selectShipIcon(shipSize, rotated, true);
                        int xSize = 40;
                        int ySize = 40;
                        if (rotated)
                            ySize *= shipSize;
                        else
                            xSize *= shipSize;
                        using (var graphics = Graphics.FromImage(RawOcean))
                            graphics.DrawImage(icon, lastX * 50 + 5, lastY * 50 + 5, xSize, ySize);

                        shipCount[shipSize - 1]--;
                        updateLayout();
                        if (shipCount[0] == 0) { select_1_ship.Checked = false; select_1_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[1] == 0) { select_2_ship.Checked = false; select_2_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[2] == 0) { select_3_ship.Checked = false; select_3_ship.Enabled = false; selectNextShip(); }
                        if (shipCount[3] == 0) { select_4_ship.Checked = false; select_4_ship.Enabled = false; selectNextShip(); }
                        shipSize = GetSizeOfShip();
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
            Bitmap ocean = new Bitmap(RawOcean);
            int X = e.Location.X;
            int Y = e.Location.Y;
            int dz = 10;
            shipSize = GetSizeOfShip();
            if (X >= dz && X<= 500-dz && Y >= dz && Y <= 500 - dz && shipSize != -1)
            {
                X = X / 50;
                Y = Y / 50;
                if (X % 50 >= 25) X++;
                if (Y % 50 >= 25) Y++;

                using (var graphics = Graphics.FromImage(ocean))
                {
                    Image icon = selectShipIcon(shipSize, rotated, IsPossibleToPlaceHere(bf, shipSize, rotated, X,Y));
                    int xSize = 40;
                    int ySize = 40;
                    if (rotated)
                        ySize *= shipSize;
                    else
                        xSize *= shipSize;
                    graphics.DrawImage(icon, X * 50 + 5, Y * 50 + 5, xSize, ySize);
                }
                lastX = X;
                lastY = Y;
            }
            
            pictureBox1.Image = ocean;

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
                g.FirstBF = bf;
                Battle btlWindow = new Battle(g);
                btlWindow.Show();
                this.Close();
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                bf = (BattleField)formatter.Deserialize(stream);
                stream.Close();
            }
            shipCount = new int[4] { 0, 0,0,0 };

            updateLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shipCount[0] == 0 && shipCount[1] == 0 && shipCount[2] == 0 && shipCount[3] == 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, bf);
                    stream.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetLayout();
            updateLayout();
        }
    }
}

using Microsoft.VisualBasic.Devices;
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
    public partial class Battle : Form
    {
        BattleField bf;

        int battleType = 0;
        bool youCanShoot = false;
        bool botCanShoot = false;
        Bot bot;

        int lastX = 1;
        int lastY = 1;
        public Battle(Game g)
        {
            InitializeComponent();
            bot = new Bot();
            label1.Text = g.FirstName;
            label2.Text = g.SecondName;
            pictureBox4.Image = g.SecondAve;
            pictureBox3.Image = g.FirstAve;
            //battleType = role;
        }
        Image ship_1 = Image.FromFile("1.png");
        Bitmap myField = new Bitmap("water-4.jpg");
        Bitmap enemyField = new Bitmap("water-4.jpg");
        Image redKrest = Image.FromFile("red_krest.png");
        Image aim = Image.FromFile("aim.png");
        Image exp = Image.FromFile("exp.png");
        Image mis = Image.FromFile("black_krest.png");
        private void Battle_Load(object sender, EventArgs e)
        {

            pictureBox2.Image = enemyField;
            using (var graphics = Graphics.FromImage(myField))
            {
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (bf.shipPlacement[i, j])
                            graphics.DrawImage(ship_1, i * 50 + 5, j * 50 + 5, 40, 40);
                    }
            }
            pictureBox1.Image = myField;
            if (battleType == 0)
            {

                pictureBox2.Image = enemyField;
                label3.Text = "Ваш выстрел!";
                youCanShoot = true;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (youCanShoot && bf.shooted[lastX, lastY] == false && bf.forbiddenToShot[lastX, lastY] == false)
            {
                Point point = new Point(lastX, lastY);
                bool res = bot.ShotToBot(point);
                bf.shooted[lastX, lastY] = true;

                using (var graphics = Graphics.FromImage(enemyField))
                {
                    if (res == true) //если попали
                    {
                        graphics.DrawImage(exp, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        bf.hitted[lastX, lastY] = true;
                        if (bot.IsDestroyedWhole(lastX, lastY))  //если полностью уничтожили корабль противника
                        {
                            int X = lastX;
                            int Y = lastY;
                            while (X > 0 && bf.hitted[X, Y] == true) { Miscleanous.ForbidAround(bf.forbiddenToShot, X, Y); X--; }
                            X = lastX; Y = lastY;
                            while (X < 9 && bf.hitted[X, Y] == true) { Miscleanous.ForbidAround(bf.forbiddenToShot, X, Y); X++; }
                            X = lastX; Y = lastY;
                            while (Y > 0 && bf.hitted[X, Y] == true) { Miscleanous.ForbidAround(bf.forbiddenToShot, X, Y); Y--; }
                            X = lastX; Y = lastY;
                            while (Y < 9 && bf.hitted[X, Y] == true) { Miscleanous.ForbidAround(bf.forbiddenToShot, X, Y); Y++; }

                            for (int i = 0; i < 10; i++)
                                for (int j = 0; j < 10; j++)
                                    if (bf.hitted[i, j] == false && bf.forbiddenToShot[i, j] == true)
                                        Miscleanous.FillLines(enemyField, i, j);
                        }
                        if (bot.AllIsDestroyed()) { this.Close(); MessageBox.Show("Победа!!!"); }
                    }
                    else
                    {
                        graphics.DrawImage(mis, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        youCanShoot = false;
                        botCanShoot = true;
                        label3.Text = "Выстрел противника!";
                    }
                }
                
                
  
                if (battleType == 0 && botCanShoot)
                {
                    bool enemyMissed = false;
                    do
                    {
                        Point p = bot.ShotByBot();
                        using (var graphics = Graphics.FromImage(myField))
                        {
                            if (bf.shipPlacement[p.X, p.Y])
                            {
                                bf.shipDestroyed[p.X, p.Y] = true;
                                if (AllIsDestroyed(bf)) { this.Close(); MessageBox.Show("поражение!!!"); }
                                graphics.DrawImage(exp, p.X * 50 + 5, p.Y * 50 + 5, 40, 40);
                            }
                            else
                            {
                                graphics.DrawImage(mis, p.X * 50 + 5, p.Y * 50 + 5, 40, 40);
                                enemyMissed = true;
                            }

                        }
                        pictureBox1.Image = myField;
                        System.Threading.Thread.Sleep(800);
                        pictureBox1.Update();

                    } while (!enemyMissed);
                    botCanShoot = false;
                    youCanShoot = true;
                    label3.Text = "Ваш выстрел!";
                } 
            }

        }
            private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;
                X = X / 50;
                Y = Y / 50;
                if (X % 50 >= 25) X++;
                if (Y % 50 >= 25) Y++;

                if (X != lastX || Y != lastY)
                {
                    Bitmap enemyFieldEnimated = new Bitmap(enemyField);
                    using (var graphics = Graphics.FromImage(enemyFieldEnimated))
                    {
                        /*if (shooted[X, Y]) {
                            graphics.DrawImage(redKrest, X * 50 + 5, Y * 50 + 5, 40, 40);
                        } else
                        {
                            graphics.DrawImage(aim, X * 50 + 5, Y * 50 + 5, 40, 40);
                        }*/
                    }
                    pictureBox2.Image = enemyFieldEnimated;
                    lastX = X;
                    lastY = Y;
                }
            }
        
    }
}

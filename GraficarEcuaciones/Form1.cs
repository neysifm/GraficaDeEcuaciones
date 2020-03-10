using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraficarEcuaciones
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Drawing.Pen mylapiz1 = new System.Drawing.Pen(System.Drawing.Color.Black);
        System.Drawing.Pen mylapiz2 = new System.Drawing.Pen(System.Drawing.Color.Red);


        private void respunto()
        {
            //VARIABLES

            double pen, intery, tang, interx1, ang;
            double px1, px2, py1, py2, yy2, Y, x, yy;

            try
            {
                px1 = Convert.ToDouble(textbox6.Text);
                px2 = Convert.ToDouble(textbox8.Text);   
                py1 = Convert.ToDouble(textbox2.Text);   
                py2 = Convert.ToDouble(textbox7.Text);
                Y = 1;

                pen = ((py2 - py1) / (px2 - px1));
                txbpendiente.Text = pen.ToString(); 

                // FORMULA GENERAL DE ECUACION

                yy = ((py2 - py1) / (px2 - px1));
                yy2 = yy + ((py1 * -1) * -1);

                if (pen < 0) // CONDICION SI X ES NEGATIVO
                {
                    x = (pen * -1);
                    txbA.Text = x.ToString();
                    Y = 1;
                    txbB.Text = Y.ToString();
                    yy2 = yy2 * -1;
                    txbC.Text = yy2.ToString();

                    interx1 = ((yy2 * -1) / Math.Abs(pen));
                    txtix.Text = interx1.ToString();

                    intery = yy2 * -1;
                    txtiy.Text = intery.ToString();

                }
                else
                {
                    txbA.Text = pen.ToString();
                    Y = 1;
                    txbB.Text = Y.ToString();
                    txbC.Text = yy2.ToString();

                    interx1 = ((yy2 * -1) / Math.Abs(pen));
                    txtix.Text = interx1.ToString();

                    txtiy.Text = yy2.ToString();
                }

                tang = (((Math.Atan(pen)) * 180) / Math.PI);

                if (tang < 0)
                {
                    ang = tang + 180;
                    Txbangulox.Text = ang.ToString();
                }
                else
                {
                    Txbangulox.Text = tang.ToString();
                }
            }catch (OverflowException e) { }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int xcentro = pictureBox1.Width / 2;
            int ycentro = pictureBox1.Height / 2;
            e.Graphics.TranslateTransform(xcentro, ycentro);
            e.Graphics.ScaleTransform(1, -1);
            e.Graphics.DrawLine(mylapiz1, xcentro * -10, 0, xcentro * 10, 0); // EJE X
            e.Graphics.DrawLine(mylapiz1, 0, ycentro * 10, 0, ycentro * -10); // EJE Y
        }

        private void resolvercs()
        {
            double pen, interx, intery, tang, interx1, ang;
            double fga, fgb, fgc;

            fga = Convert.ToDouble(txbA.Text);
            fgb = Convert.ToDouble(txbB.Text);  
            fgc = Convert.ToDouble(txbC.Text);

            pen = (-1 * (fga / fgb)); // RESOLVER LA PENDIENTE
            txbpendiente.Text = pen.ToString();

            tang = ((Math.Atan(pen)) * 180) / Math.PI;

            if (tang < 0)
            {
                ang = tang + 180;
                Txbangulox.Text = ang.ToString();
            }
            else
            {
                Txbangulox.Text = tang.ToString();
            }

            interx1 = fgc * -1;
            interx = interx1 / fga;
            txtix.Text = interx.ToString();

            intery = interx1 / fgb;
            txtiy.Text = intery.ToString();
        }

        private void graficar1()
        {
            System.Drawing.Graphics ent = this.pictureBox1.CreateGraphics();
            int xcentro = pictureBox1.Width / 2;
            int ycentro = pictureBox1.Height / 2;
            ent.TranslateTransform(xcentro, ycentro);
            ent.ScaleTransform(1, -1);

            double a, b;
            a = Convert.ToDouble(txtix.Text);
            b = Convert.ToDouble(txtiy.Text);

            if (a < -40 || a > 40 || b < -40 || b > 40)
            {
                //PINTAR LAS RAYAS
                for (int c = -xcentro; c <= xcentro; c += 4)
                {
                    ent.DrawLine(mylapiz1, -1 * 2, c * 2, 1 * 2, c * 2);
                    ent.DrawLine(mylapiz1,  c * 2, 1 * 2, c * 2, -1 * 2);
                }

                double x1, y1, punto1, c3, punto1a, x11, y11, c11, punto2, punto2a;

                x1 = Convert.ToDouble(txbA.Text);
                y1 = Convert.ToDouble(txbB.Text);
                c3 = Convert.ToDouble(txbC.Text);

                x11 = x1 * 2;
                y11 = y1 * 2;
                c11 = c3 * 2;

                //RESOLVER LA ECUACION CUANDO X TIENDE A -100
                punto1 = (((x1 * -100) + c3) * -1);
                punto1a = ((punto1 / y1) * 2);

                //RESOLVER LA ECUACION CUANDO X TIENDE A 100
                punto2 = (((x1 * 100) + c3) * -1);
                punto2a = ((punto1 / y1) * 2);

                double x22, x23;
                x22 = -100 * 2;
                x23 = 100 * 2;

                Point ucord1 = new Point((int)x22, (int)punto1a);
                Point ucord2 = new Point((int)x23, (int)punto2a);

                ent.DrawLine(mylapiz2, (int)x22, (int)punto1a, (int)x23, (int)punto2a);
            }
            else
            {
                if (a < -20 || a> 20 || b < -20 || b > 20)
                {
                    for (int c = -xcentro; c <=xcentro; c += 2)
                    {
                        ent.DrawLine(mylapiz1, -1 * 5, c * 5, 1 * 5, c * 5);
                        ent.DrawLine(mylapiz1, c * 5, 1 * 5, c * 5, -1 * 5);
                    }

                    double x1, y1, miau, c3, miau2, x11, y11, c11, miau11, miau22;

                    x1 = Convert.ToDouble(txbA.Text);
                    y1 = Convert.ToDouble(txbB.Text);
                    c3 = Convert.ToDouble(txbC.Text);

                    x11 = x1 * 5;
                    y11 = y1 * 5;
                    c11 = c3 * 5;

                    miau = (((x1 * -100) + c3) * -1);
                    miau2 = ((miau / y1) * 5);

                    miau11 = (((x1 * 100) + c3) * -1);
                    miau22 = ((miau11 / y1) * 5);

                    double x22, x23;
                    x22 = -100 * 5;
                    x23 = 100 * 5;

                    Point ucord1 = new Point((int)x22, (int)miau2);
                    Point ucord2 = new Point((int)x22, (int)miau22);

                    ent.DrawLine(mylapiz2, (int)x22, (int)miau2, (int)x23, (int)miau22);
                }
                else
                {
                    for (int c = -xcentro; c <= xcentro; c += 1)
                    {
                        ent.DrawLine(mylapiz1, -1 * 20, c * 20, 1 * 20, c * 20);
                        ent.DrawLine(mylapiz1, c * 20, 1 * 20, c * 20, -1 * 20);
                    }

                    double x1, y1, miau, c3, miau2, x11, y11, c11, miau11, miau22;

                    x1 = Convert.ToDouble(txbA.Text);
                    y1 = Convert.ToDouble(txbB.Text);
                    c3 = Convert.ToDouble(txbC.Text);

                    x11 = x1 * 20;
                    y11 = y1 * 20;
                    c11 = c3 * 20;

                    miau = (((x1 * -100) + c3) * -1);
                    miau2 = ((miau / y1) * 20);

                    miau11 = (((x1 * 100) + c3) * -1);
                    miau22 = ((miau11 / y1) * 20);

                    double x22, x23;
                    x22 = -100 * 20;
                    x23 = 100 * 20;

                    Point ucord1 = new Point((int)x22, (int)miau2);
                    Point ucord2 = new Point((int)x22, (int)miau22);

                    ent.DrawLine(mylapiz2, (int)x22, (int)miau2, (int)x23, (int)miau22);
                }
            }
        }

        private void btnresolver1_Click(object sender, EventArgs e)
        {
            if (txbA.Text == "" && txbB.Text == "" && txbC.Text == "" && textbox6.Text == "" && textbox2.Text == "" && textbox7.Text == "" && textbox8.Text == "")
            {
                MessageBox.Show("Ingrese Valores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txbA.Text == "" || txbB.Text == "" || txbC.Text == "")
                {
                    respunto();
                    if ((textbox6.Text != textbox8.Text) && (textbox7.Text != textbox2.Text))
                    {
                        graficar1();
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (textbox6.Text == "" || textbox2.Text == "" || textbox7.Text == "" || textbox8.Text == "")
                    {
                        resolvercs();
                        graficar1();
                    }
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txbpendiente.Clear();
            Txbangulox.Clear();
            txtix.Clear();
            txtiy.Clear();
        }

        private void txbA_MouseClick(object sender, MouseEventArgs e)
        {
            textbox2.ReadOnly = true;
            textbox6.ReadOnly = true;
            textbox7.ReadOnly = true;
            textbox8.ReadOnly = true;

            textbox2.Clear();
            textbox6.Clear();
            textbox7.Clear();
            textbox8.Clear();

            txbA.ReadOnly = false;
            txbB.ReadOnly = false;
            txbC.ReadOnly = false;
        }

        private void textbox6_MouseClick(object sender, MouseEventArgs e)
        {
            txbA.ReadOnly = true;
            txbB.ReadOnly = true;
            txbC.ReadOnly = true;

            txbA.Clear();
            txbB.Clear();
            txbC.Clear();

            textbox2.ReadOnly = false;
            textbox6.ReadOnly = false;
            textbox7.ReadOnly = false;
            textbox8.ReadOnly = false;
        }
    }
}

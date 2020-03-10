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
                px1 = Convert.ToDouble(txbA.Text);
                px2 = Convert.ToDouble(txbB.Text);   // HAY QUE VERIFICAR QUE LOS TEXTBOX SEAN
                py1 = Convert.ToDouble(txbC.Text);   // LOS CORRETOS,PARA ONTENER LOS DATOS DE LAS VARIABLES
                py2 = Convert.ToDouble(metroTextBox4.Text);
                Y = 1;

                pen = ((py2 - py1) / (px2 - px1));
               // txbpendiente.Text = pen.ToString(); revisa que tenga el nombre de txbpendiente

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
                   // txtix.Text = interx1.ToString();

                    intery = yy2 * -1;
                  //  txtiy.Text = intery.ToString();

                }
                else
                {
                    txbA.Text = pen.ToString();
                    Y = 1;
                    txbB.Text = Y.ToString();
                    txbC.Text = yy2.ToString();

                    interx1 = ((yy2 * -1) / Math.Abs(pen));
                    // txtix.Text = interx1.ToString();

                   // txtiy.Text = yy2.ToString();
                }

                tang = (((Math.Atan(pen)) * 180) / Math.PI);

                if (tang < 0)
                {
                    ang = tang + 180;
                 //   Txbangulox.Text = ang.ToString();
                }
                else
                {
                    //   Txbangulox.Text = tang.ToString();
                }
            }catch (OverflowException e) { }

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
               // Txbangulox.Text = ang.ToString();
            }
            else
            {
                //   Txbangulox.Text = tang.ToString();
            }

            interx1 = fgc * -1;
            interx = interx1 / fga;
            //   txtix.Text = interx.ToString();

            intery = interx1 / fgb;
          //  txtiy.Text = intery.ToString();
        }
    }
}

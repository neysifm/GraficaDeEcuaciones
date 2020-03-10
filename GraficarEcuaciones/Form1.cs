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
                px1 = Convert.ToDouble(metroTextBox1.Text);
                px2 = Convert.ToDouble(metroTextBox2.Text);   // HAY QUE VERIFICAR QUE LOS TEXTBOX SEAN
                py1 = Convert.ToDouble(metroTextBox3.Text);   // LOS CORRETOS,PARA ONTENER LOS DATOS DE LAS VARIABLES
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

                }

            }

        }
    }
}

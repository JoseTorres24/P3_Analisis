using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Analisis
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Sistema de ecuaciones //Adaptacion del codigo C++
            comboEcuaciones.Items.Add("Gauss-Jordan Ecuaciones");
            //Metodos de Raices // adaptacion de archivo de python
            comboRaices.Items.Add("Newton-Raphson Metodos");
            //Metodos de Interpolacion
            comboInterpolacion.Items.Add("Diferencias Divididas");//Forms 1
            comboInterpolacion.Items.Add("Interpolacion Lineal");//Forms 2
            comboInterpolacion.Items.Add("Polinomio de interpolacion Unico");//Forms 3
        }
        // Cargamos los metodos en el primer combobox
        private void comboInterpolacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            string metodoSeleccionado = comboInterpolacion.SelectedItem?.ToString();

            switch (metodoSeleccionado)
            {
                case "Diferencias Divididas":
                    {
                        Form1 form1 = new Form1();
                        form1.ShowDialog();

                        break;

                    }
                case "Interpolacion Lineal":
                    {
                        Form2 form2 = new Form2();
                        form2.ShowDialog();

                        break;

                    }
                case "Polinomio de interpolacion Unico":
                    {
                        Form3 form3 = new Form3();
                        form3.ShowDialog();

                        break;

                    }

            }
        }

        private void comboRaices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Newton_Raphson ventana1= new Newton_Raphson();
            ventana1.ShowDialog();
        }

        private void comboEcuaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GaussMatrices ventana2 = new GaussMatrices();
            ventana2.ShowDialog();
        }
    }
}

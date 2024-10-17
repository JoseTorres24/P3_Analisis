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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboCantidad1.Items.Add("1");
            comboCantidad1.Items.Add("2");
            comboCantidad1.Items.Add("3");
            comboCantidad1.Items.Add("4");
            comboCantidad1.Items.Add("5");
            comboCantidad1.Items.Add("6");
            comboCantidad1.Items.Add("7");
        }

        private void comboCantidad1_SelectedIndexChanged(object sender, EventArgs e)
        { //Agregamos filas que obviamente seran vacias
            if (int.TryParse(comboCantidad1.SelectedItem.ToString(), out int cantidad))
            {
                datosTabla1.Rows.Clear();
                for (int i = 0; i < cantidad; i++)
                {
                    datosTabla1.Rows.Add(""); // Agregamos una fila vacía  
                }
            }
        }
    }
}

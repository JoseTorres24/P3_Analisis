using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;




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
            string metodoSeleccionado = comboRaices.SelectedItem?.ToString();

            if (metodoSeleccionado == "Newton-Raphson Metodos")
            {
                Newton_Raphson ventana = new Newton_Raphson();
                ventana.ShowDialog();
            }
        }

        private void comboEcuaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodoSeleccionado = comboEcuaciones.SelectedItem.ToString();
            if (metodoSeleccionado == "Gauss-Jordan Ecuaciones")
            {
                // Aquí construimos la ruta al ejecutable de manera relativa
                string executablePath = GetExecutablePath("GaussJordan.exe");

                // Mostrar la ruta generada para verificar
                MessageBox.Show($"Ruta generada: {executablePath}", "Ruta de Ejecución");

                if (File.Exists(executablePath))
                {
                    try
                    {
                        // Mostrar mensaje de confirmación antes de ejecutar
                        MessageBox.Show("Archivo encontrado. Intentando ejecutar...");

                        using (Process process = new Process())
                        {
                            process.StartInfo.FileName = executablePath;
                            process.StartInfo.UseShellExecute = true; // Cambiar a true si UseShellExecute=false no funciona
                            process.StartInfo.CreateNoWindow = false;  // Cambia a false para ver la ventana si es necesario
                            process.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar el programa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"El archivo GaussJordan.exe no se encuentra en la ruta especificada:\n\n{executablePath}",
                                    "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Método para obtener la ruta completa del archivo .exe de manera relativa
        private string GetExecutablePath(string executableName)
        {
            // Usar el directorio base de la aplicación
            string basePath = AppDomain.CurrentDomain.BaseDirectory; // Esto apunta a la carpeta bin de tu proyecto
            return Path.Combine(basePath, executableName); // Combina el directorio base con el nombre del ejecutable
        }


    }
}

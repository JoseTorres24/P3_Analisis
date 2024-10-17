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
                textResultado1.Clear();
                for (int i = 0; i < cantidad; i++)
                {
                    datosTabla1.Rows.Add(""); // Agregamos una fila vacía  
                }
            }
        }

        private void botonPolinomioUnico_Click(object sender, EventArgs e)
        {
            // Validar que el valorX1 sea numérico
            if (!double.TryParse(valorX1.Text, out double x1))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para X.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que todas las celdas de la tabla sean numéricas y obtener los valores de X y Y
            List<double> valoresX = new List<double>();
            List<double> valoresY = new List<double>();
            foreach (DataGridViewRow row in datosTabla1.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null ||
                    !double.TryParse(row.Cells[0].Value.ToString(), out double x) ||
                    !double.TryParse(row.Cells[1].Value.ToString(), out double y))
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos en la tabla.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                valoresX.Add(x); // Agregamos el valor X
                valoresY.Add(y); // Agregamos el valor Y
            }

            // Verificar que haya suficientes datos
            int cantidadDatos = valoresX.Count;
            if (cantidadDatos < 2)
            {
                MessageBox.Show("Se necesitan al menos 2 puntos para calcular el polinomio.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la matriz aumentada para el sistema de ecuaciones
            double[,] matriz = new double[cantidadDatos, cantidadDatos + 1]; // Matriz aumentada

            // Llenar la matriz con las potencias de X y los valores de Y
            for (int i = 0; i < cantidadDatos; i++)
            {
                for (int j = 0; j < cantidadDatos; j++)
                {
                    matriz[i, j] = Math.Pow(valoresX[i], j); // Coeficientes de las potencias de X
                }
                matriz[i, cantidadDatos] = valoresY[i]; // Agregar los valores de Y como términos independientes
            }

            // Mostrar las ecuaciones generadas en textResultado1
            textResultado1.Clear();
            textResultado1.AppendText("Sistema de ecuaciones generado:\r\n");
            for (int i = 0; i < cantidadDatos; i++)
            {
                string ecuacion = "";
                for (int j = 0; j < cantidadDatos; j++)
                {
                    ecuacion += $"{matriz[i, j]}a{j} + ";
                }
                ecuacion = ecuacion.TrimEnd('+', ' ') + $" = {matriz[i, cantidadDatos]}\r\n";
                textResultado1.AppendText(ecuacion);
            }

            // Resolver la matriz usando el método de Gauss-Jordan
            double[] coeficientes = ResolverGaussJordan(matriz, cantidadDatos);

            // Mostrar la matriz Gauss-Jordan en textResultado1
            textResultado1.AppendText("\r\nMatriz en forma Gauss-Jordan:\r\n");
            for (int i = 0; i < cantidadDatos; i++)
            {
                for (int j = 0; j <= cantidadDatos; j++)
                {
                    textResultado1.AppendText(matriz[i, j].ToString("F4") + "\t");
                }
                textResultado1.AppendText("\r\n");
            }

            // Construir el polinomio interpolado
            string polinomio = "y(x) = ";
            for (int i = 0; i < coeficientes.Length; i++)
            {
                polinomio += $"{coeficientes[i]:F4}x^{i} + ";
            }
            polinomio = polinomio.TrimEnd('+', ' '); // Eliminar el último '+'

            // Mostrar el polinomio interpolado
            textResultado1.AppendText($"\r\nPolinomio interpolado:\r\n{polinomio}\r\n");

            // Realizar la interpolación para el valor dado de X
            double yInterpolado = 0;
            for (int i = 0; i < coeficientes.Length; i++)
            {
                yInterpolado += coeficientes[i] * Math.Pow(x1, i);
            }

            // Mostrar el resultado interpolado
            textResultado1.AppendText($"\r\nValor interpolado para x = {x1}: y(x) = {yInterpolado:F4}\r\n");
        }

        // Método para resolver el sistema de ecuaciones mediante Gauss-Jordan
        private double[] ResolverGaussJordan(double[,] matriz, int n)
        {
            for (int i = 0; i < n; i++)
            {
                // Hacer que el pivote sea 1 dividiendo la fila
                double pivote = matriz[i, i];
                if (pivote == 0)
                {
                    // Evitar división por cero
                    for (int k = i + 1; k < n; k++)
                    {
                        if (matriz[k, i] != 0)
                        {
                            // Intercambiar filas
                            for (int j = 0; j <= n; j++)
                            {
                                double temp = matriz[i, j];
                                matriz[i, j] = matriz[k, j];
                                matriz[k, j] = temp;
                            }
                            break;
                        }
                    }
                    pivote = matriz[i, i];
                }
                for (int j = 0; j <= n; j++)
                {
                    matriz[i, j] /= pivote;
                }

                // Hacer que los elementos debajo y encima del pivote sean 0
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = matriz[k, i];
                        for (int j = 0; j <= n; j++)
                        {
                            matriz[k, j] -= factor * matriz[i, j];
                        }
                    }
                }
            }

            // Extraer los coeficientes de la última columna
            double[] coeficientes = new double[n];
            for (int i = 0; i < n; i++)
            {
                coeficientes[i] = matriz[i, n];
            }

            return coeficientes;
        }


    }
}

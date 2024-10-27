using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//Interpolacion Lineal
namespace P3_Analisis
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Jala pa todo :)))

        private void botonMetodoLineal_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar las entradas en los TextBox
                string valor1 = textValor1.Text;
                string valor2 = textValor2.Text;
                string valorInterpolar = textInterpolar.Text;

                // Expresión regular para permitir solo números o funciones sin(), cos(), tan(), ln(), exp(), sqrt()
                string patronFuncion = @"^(sin|cos|tan|ln|exp|sqrt)\(\d+(\.\d+)?\)$|^\d+(\.\d+)?$";

                // Validar las tres entradas
                if (!Regex.IsMatch(valor1, patronFuncion) || !Regex.IsMatch(valor2, patronFuncion) || !Regex.IsMatch(valorInterpolar, patronFuncion))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos en formato de función (sin, cos, tan, ln, exp, sqrt) o números.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Evaluar los valores ingresados en las funciones o números
                string funcion1, funcion2, funcionInterpolar;
                double y1 = EvaluarFuncion(valor1, out funcion1); // Evaluar la función en x1
                double y2 = EvaluarFuncion(valor2, out funcion2); // Evaluar la función en x2
                double xInterpolar = EvaluarFuncion(valorInterpolar, out funcionInterpolar); // Valor a interpolar

                // Verificar si el valor a interpolar está entre los dos valores
                if (!(xInterpolar >= Math.Min(y1, y2) && xInterpolar <= Math.Max(y1, y2)))
                {
                    MessageBox.Show("El valor a interpolar debe estar entre los dos valores ingresados.", "Interval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si pasa las validaciones, ejecutamos la interpolación lineal (aproximada)
                double valorInterpolado = InterpolacionLineal(0, y1, 1, y2, xInterpolar); // Aproximación simple

                // Verificar si el resultado es NaN o Infinito
                if (double.IsNaN(valorInterpolado) || double.IsInfinity(valorInterpolado))
                {
                    MessageBox.Show("El resultado es inválido (NaN o Infinito). Verifique los valores ingresados.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar el resultado en el TextBox
                textResultadoLineal.Text = $"Resultado de la Interpolación Lineal:\r\n"
                                         + $"{funcion1} = {y1}\r\n" // Mostramos la función ingresada para el valor 1
                                         + $"{funcion2} = {y2}\r\n" // Mostramos la función ingresada para el valor 2
                                         + $"Interpolando {funcionInterpolar}:\r\n"
                                         + $"Resultado Aproximado: {valorInterpolado}";
            }
            catch (Exception ex)
            {
                // Captura cualquier error no anticipado y muestra un mensaje
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para evaluar la función o número ingresado
        private double EvaluarFuncion(string input, out string funcionFormateada)
        {
            try
            {
                if (input.StartsWith("sin("))
                {
                    string numero = input.Substring(4, input.Length - 5); // Extraer el número dentro de la función
                    double valorEnGrados = double.Parse(numero);
                    double valorEnRadianes = valorEnGrados * (Math.PI / 180); // Convertir grados a radianes
                    funcionFormateada = $"sin({valorEnGrados})"; // Mantener la función original para mostrar en la salida
                    return Math.Sin(valorEnRadianes);
                }
                else if (input.StartsWith("cos("))
                {
                    string numero = input.Substring(4, input.Length - 5);
                    double valorEnGrados = double.Parse(numero);
                    double valorEnRadianes = valorEnGrados * (Math.PI / 180); // Convertir grados a radianes
                    funcionFormateada = $"cos({valorEnGrados})";
                    return Math.Cos(valorEnRadianes);
                }
                else if (input.StartsWith("tan("))
                {
                    string numero = input.Substring(4, input.Length - 5);
                    double valorEnGrados = double.Parse(numero);
                    double valorEnRadianes = valorEnGrados * (Math.PI / 180); // Convertir grados a radianes
                    funcionFormateada = $"tan({valorEnGrados})";
                    return Math.Tan(valorEnRadianes);
                }
                else if (input.StartsWith("ln("))
                {
                    string numero = input.Substring(3, input.Length - 4);
                    double valor = double.Parse(numero);
                    if (valor <= 0)
                    {
                        throw new ArgumentException("ln(x) no está definido para valores ≤ 0");
                    }
                    funcionFormateada = $"ln({numero})";
                    return Math.Log(valor); // ln(x) no necesita conversión, ya está en base natural
                }
                else if (input.StartsWith("exp("))
                {
                    string numero = input.Substring(4, input.Length - 5);
                    funcionFormateada = $"exp({numero})";
                    return Math.Exp(double.Parse(numero)); // exp(x) = e^x
                }
                else if (input.StartsWith("sqrt("))
                {
                    string numero = input.Substring(5, input.Length - 6);
                    double valor = double.Parse(numero);
                    if (valor < 0)
                    {
                        throw new ArgumentException("sqrt(x) no está definido para valores negativos");
                    }
                    funcionFormateada = $"sqrt({numero})";
                    return Math.Sqrt(valor); // sqrt(x) = √x
                }
                else
                {
                    // Si es un número directo
                    funcionFormateada = input; // Mantener el número como está
                    return double.Parse(input);
                }
            }
            catch (FormatException)
            {
                throw new FormatException("El formato del número o función es incorrecto.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al evaluar la función: {ex.Message}");
            }
        }

        // Método para la interpolación lineal (sin valor exacto de la función)
        private double InterpolacionLineal(double x1, double y1, double x2, double y2, double x)
        {
            try
            {
                double resultado = y1 + (y2 - y1) * (x - x1) / (x2 - x1);
                if (double.IsNaN(resultado) || double.IsInfinity(resultado))
                {
                    throw new Exception("El resultado de la interpolación es inválido (NaN o Infinito).");
                }
                return resultado;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("División por cero detectada durante la interpolación.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la interpolación lineal: {ex.Message}");
            }
        }




    }
}

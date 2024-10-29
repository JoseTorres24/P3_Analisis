using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace P3_Analisis
{
    public partial class GaussMatrices : Form
    {
        private List<TextBox> textBoxesA; // Para los coeficientes de la matriz A
        private List<TextBox> textBoxesB; // Para los términos independientes

        public GaussMatrices()
        {
            InitializeComponent();
            textBoxesA = new List<TextBox>();
            textBoxesB = new List<TextBox>();
            rbResolverSistema.Checked = false;
            rbCalcularDeterminante.Checked = false;
            rbCalcularInversa.Checked = false;
        }

        // Evento de carga del formulario
        private void GaussMatrices_Load(object sender, EventArgs e)
        {
            rbResolverSistema.Checked = false;
            rbCalcularDeterminante.Checked = false;
            rbCalcularInversa.Checked = false;
        }

        // Método para ejecutar la acción seleccionada
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTamanoMatriz.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Por favor, ingrese un tamaño de matriz válido (N > 0).");
                return;
            }

            if (rbResolverSistema.Checked)
            {
                ResolveSystem(n);
            }
            else if (rbCalcularDeterminante.Checked)
            {
                double determinant = CalculateDeterminant(n);
                lstResultados.Items.Clear();
                lstResultados.Items.Add($"Determinante: {determinant}");
            }
            else if (rbCalcularInversa.Checked)
            {
                double[,] inverseMatrix = CalculateInverse(n);
                DisplayMatrix(inverseMatrix);
            }
        }

        // Método para resolver un sistema de ecuaciones
        private void ResolveSystem(int n)
        {
            double[,] A = new double[n, n]; // Matriz de coeficientes
            double[] B = new double[n]; // Vector de términos independientes

            // Obtener los valores de la matriz A y el vector B de los TextBoxes
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (double.TryParse(textBoxesA[i * n + j].Text, out double value))
                    {
                        A[i, j] = value;
                    }
                }
                if (double.TryParse(textBoxesB[i].Text, out double bValue))
                {
                    B[i] = bValue;
                }
            }

            double[] result = GaussianElimination(A, B);
            lstResultados.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                lstResultados.Items.Add($"x{i + 1} = {result[i]}");
            }
        }

        // Método para calcular el determinante
        private double CalculateDeterminant(int n)
        {
            double[,] A = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (double.TryParse(textBoxesA[i * n + j].Text, out double value))
                    {
                        A[i, j] = value;
                    }
                }
            }

            double det = 1;
            for (int i = 0; i < n; i++)
            {
                double pivot = A[i, i];
                if (Math.Abs(pivot) < 1e-10) return 0;
                det *= pivot;

                for (int j = i + 1; j < n; j++)
                {
                    double factor = A[j, i] / pivot;
                    for (int k = i; k < n; k++)
                    {
                        A[j, k] -= factor * A[i, k];
                    }
                }
            }
            return det;
        }

        // Método para calcular la inversa de una matriz
        private double[,] CalculateInverse(int n)
        {
            double[,] A = new double[n, n];
            double[,] I = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (double.TryParse(textBoxesA[i * n + j].Text, out double value))
                    {
                        A[i, j] = value;
                    }
                }
                I[i, i] = 1; // Inicializar matriz identidad
            }

            for (int i = 0; i < n; i++)
            {
                double pivot = A[i, i];
                if (Math.Abs(pivot) < 1e-10) return null;

                for (int j = 0; j < n; j++)
                {
                    A[i, j] /= pivot;
                    I[i, j] /= pivot;
                }

                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        double factor = A[j, i];
                        for (int k = 0; k < n; k++)
                        {
                            A[j, k] -= factor * A[i, k];
                            I[j, k] -= factor * I[i, k];
                        }
                    }
                }
            }
            return I;
        }

        // Método para mostrar una matriz en la ListBox
        private void DisplayMatrix(double[,] matrix)
        {
            lstResultados.Items.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = string.Join(", ", Enumerable.Range(0, matrix.GetLength(1)).Select(j => matrix[i, j].ToString("F2")));
                lstResultados.Items.Add(row);
            }
        }

        // Método de salida
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para realizar eliminación de Gauss
        private double[] GaussianElimination(double[,] A, double[] B)
        {
            int n = B.Length;

            for (int i = 0; i < n; i++)
            {
                double max = Math.Abs(A[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(A[k, i]) > max)
                    {
                        max = Math.Abs(A[k, i]);
                        maxRow = k;
                    }
                }

                // Intercambiar filas
                for (int k = i; k < n; k++)
                {
                    double temp = A[maxRow, k];
                    A[maxRow, k] = A[i, k];
                    A[i, k] = temp;
                }
                double tempB = B[maxRow];
                B[maxRow] = B[i];
                B[i] = tempB;

                // Hacer ceros debajo del pivote
                for (int k = i + 1; k < n; k++)
                {
                    double factor = A[k, i] / A[i, i];
                    for (int j = i; j < n; j++)
                    {
                        A[k, j] -= factor * A[i, j];
                    }
                    B[k] -= factor * B[i];
                }
            }

            // Sustitución hacia atrás
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = B[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= A[i, j] * x[j];
                }
                x[i] /= A[i, i];
            }

            return x;
        }

        // Evento que se dispara cuando se cambia el estado del radio button para resolver el sistema
        private void rbResolverSistema_CheckedChanged(object sender, EventArgs e)
        {
            // Limpiar los controles existentes
            ClearDynamicControls();

            // Verificar si el radio button está seleccionado
            if (rbResolverSistema.Checked)
            {
                if (int.TryParse(txtTamanoMatriz.Text, out int n) && n > 0)
                {
                    GenerateInputControls(n); // Genera los controles dinámicos
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un tamaño de matriz válido (N > 0).");
                }
            }
        }


        // Método para generar los controles de entrada dinámicamente
        private void GenerateInputControls(int n)
        {
            // Clear the panel before adding new controls
            panelControlesDinamicos.Controls.Clear();
            textBoxesA.Clear();
            textBoxesB.Clear();

            // Enable auto-scrolling if necessary
            panelControlesDinamicos.AutoScroll = true;

            // Create labels and TextBoxes for the coefficients of matrix A
            for (int i = 0; i < n; i++) // Loop for the rows
            {
                // Create a panel for each row
                FlowLayoutPanel panel = new FlowLayoutPanel
                {
                    Width = panelControlesDinamicos.Width - 20, // Adjust the width of the panel
                    Height = 30,
                    AutoSize = true,
                    FlowDirection = FlowDirection.LeftToRight
                };

                for (int j = 0; j < n; j++) // Loop for the columns
                {
                    // Create TextBox for the coefficients of matrix A
                    TextBox txtA = new TextBox
                    {
                        Width = 40,
                        Name = $"txtA_{i}_{j}",
                        PlaceholderText = $"a{i + 1}{j + 1}" // Placeholder to facilitate input
                    };
                    panel.Controls.Add(txtA);
                    textBoxesA.Add(txtA); // Save reference

                    // Add a plus sign for the independent terms
                    if (j < n - 1)
                    {
                        Label label = new Label
                        {
                            Text = "+",
                            AutoSize = true
                        };
                        panel.Controls.Add(label);
                    }
                }

                // Create TextBox for the independent term B
                TextBox txtB = new TextBox
                {
                    Width = 40,
                    Name = $"txtB_{i}",
                    PlaceholderText = $"b{i + 1}" // Placeholder to facilitate input
                };
                panel.Controls.Add(txtB);
                textBoxesB.Add(txtB); // Save reference

                // Add the row panel to the dynamic panel
                panelControlesDinamicos.Controls.Add(panel);
            }

            // Ensure the dynamic panel is visible
            panelControlesDinamicos.Visible = true;

            // Ensure the panel is added to the form's controls if it hasn't been added yet
            if (!this.Controls.Contains(panelControlesDinamicos))
            {
                this.Controls.Add(panelControlesDinamicos);
            }
        }


        // Método para limpiar los controles dinámicos
        private void ClearDynamicControls()
        {
            panelControlesDinamicos.Controls.Clear(); // Limpia los controles en el panel
            textBoxesA.Clear();
            textBoxesB.Clear();
        }

    }
}

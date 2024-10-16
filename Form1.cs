using System.Text;
using System.Windows.Forms;

namespace P3_Analisis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            datosTabla.Hide();
            comboCantidad.Hide();
            botonDiferencias.Hide();
            tamañoTxt.Hide();
            valorX.Hide();
            LabelIngresar.Hide();
            labelResultado.Hide();
            textResultado.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            boxMetodos.Items.Add("Diferencias Divididas de Newton");
            boxMetodos.Items.Add("Polinomio de Interpolacion Unico");
            boxMetodos.Items.Add("Interpolacion Lineal");
            comboCantidad.Items.Add("1");
            comboCantidad.Items.Add("2");
            comboCantidad.Items.Add("3");
            comboCantidad.Items.Add("4");
            comboCantidad.Items.Add("5");
            comboCantidad.Items.Add("6");
            comboCantidad.Items.Add("7");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejo de clic en celdas (opcional)  
        }

        private void comboCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboCantidad.SelectedItem.ToString(), out int cantidad))
            {
                datosTabla.Rows.Clear();
                for (int i = 0; i < cantidad; i++)
                {
                    datosTabla.Rows.Add(""); // Agregamos una fila vacía  
                }
            }
        }

        private void boxMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxMetodos.SelectedItem != null &&
                boxMetodos.SelectedItem.ToString() == "Diferencias Divididas de Newton")
            {
                datosTabla.Show();
                comboCantidad.Show();
                botonDiferencias.Show();
                tamañoTxt.Show();
                valorX.Show();
                LabelIngresar.Show();
                labelResultado.Show();
                textResultado.Show();
            }
            else
            {
                datosTabla.Hide();
                comboCantidad.Hide();
                botonDiferencias.Hide();
                tamañoTxt.Hide();
                valorX.Hide();
                LabelIngresar.Hide();
                labelResultado.Hide();
                textResultado.Hide();
            }
        }

        private void valorX_TextChanged(object sender, EventArgs e)
        {
            // Manejo del texto cambiado (opcional)  
        }

        private void botonDiferencias_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(valorX.Text, out double valorIngresado))
            {
                MessageBox.Show("Por favor, ingrese un número válido en el campo 'valorX'.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboCantidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione la cantidad en el combo 'Cantidad'.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(comboCantidad.SelectedItem.ToString(), out int cantidadSeleccionada) || cantidadSeleccionada < 1 || cantidadSeleccionada > 7)
            {
                MessageBox.Show("Por favor, seleccione un valor entre 1 y 7.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si la tabla tiene filas con datos
            bool tablaVacia = true;
            foreach (DataGridViewRow row in datosTabla.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la fila nueva vacía
                                            // Si alguna celda en la fila contiene datos, la tabla no está vacía
                if (!string.IsNullOrEmpty(row.Cells[0].Value?.ToString()) && !string.IsNullOrEmpty(row.Cells[1].Value?.ToString()))
                {
                    tablaVacia = false;
                    break;
                }
            }

            if (tablaVacia)
            {
                MessageBox.Show("Por favor, ingrese al menos un par de valores en la tabla.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que todas las celdas contienen números válidos
            foreach (DataGridViewRow row in datosTabla.Rows)
            {
                if (row.IsNewRow) continue;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!string.IsNullOrEmpty(cell.Value?.ToString()) && !double.TryParse(cell.Value.ToString(), out _))
                    {
                        MessageBox.Show("Por favor, asegúrese de que todas las celdas contengan números válidos.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Procedimiento de interpolación  
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            foreach (DataGridViewRow row in datosTabla.Rows)
            {
                if (row.IsNewRow) continue;
                if (double.TryParse(row.Cells[0].Value?.ToString(), out double x) && double.TryParse(row.Cells[1].Value?.ToString(), out double y))
                {
                    xValues.Add(x);
                    yValues.Add(y);
                }
            }

            // Calcular el resultado  
            string resultado = InterpolacionNewton(xValues, yValues, valorIngresado);
            textResultado.Text = resultado; // Mostrar resultado en el textBox  
        }


        private string InterpolacionNewton(List<double> x, List<double> y, double valorX)
        {
            int n = x.Count;
            double[,] diferenciasDivididas = new double[n, n];

            // Inicializar la tabla de diferencias divididas con los valores de y
            for (int i = 0; i < n; i++)
            {
                diferenciasDivididas[i, 0] = y[i];
            }

            // Calcular las diferencias divididas
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    diferenciasDivididas[i, j] = (diferenciasDivididas[i + 1, j - 1] - diferenciasDivididas[i, j - 1]) / (x[i + j] - x[i]);
                }
            }

            StringBuilder polinomio = new StringBuilder();
            StringBuilder ecuacionesIntermedias = new StringBuilder();
            double resultado = diferenciasDivididas[0, 0];

            // Añadir el término constante
            polinomio.AppendLine($"{diferenciasDivididas[0, 0]:0.##}"); // Salto de línea después de cada operación

            // Construir el polinomio de Newton
            for (int i = 1; i < n; i++)
            {
                double term = diferenciasDivididas[0, i];
                StringBuilder terminoPolinomio = new StringBuilder($"{diferenciasDivididas[0, i]:0.##}");

                // Calcular los productos (x - x0)(x - x1)...(x - xi-1)
                for (int j = 0; j < i; j++)
                {
                    term *= (valorX - x[j]);
                    terminoPolinomio.Append($"(x - {x[j]:0.##})");
                }

                resultado += term;

                // Añadir el término al polinomio con un salto de línea
                polinomio.AppendLine($" + {terminoPolinomio}");

                // Mostrar ecuación intermedia para el coeficiente actual con salto de línea
                ecuacionesIntermedias.AppendLine($"a_{i} = {diferenciasDivididas[0, i]:0.##}");
            }

            // Insertar encabezado para el polinomio y agregar el resultado con saltos de línea
            polinomio.Insert(0, "P(x) = ");
            polinomio.AppendLine($"\nEl resultado para P({valorX}) es: {resultado:0.##}");

            // Retornar las ecuaciones intermedias y el polinomio final, cada operación en una nueva línea
            return ecuacionesIntermedias.ToString() + "\n" + polinomio.ToString();
        }


    }
}

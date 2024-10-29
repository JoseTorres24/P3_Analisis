using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MathNet.Symbolics; // Importa Math.NET Symbolics
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace P3_Analisis
{
    public partial class Newton_Raphson : Form
    {
        public Newton_Raphson()
        {
            InitializeComponent();
        }

        private void Newton_Raphson_Load(object sender, EventArgs e)
        {
            comboMetodos.Items.Add("Newton-Raphson Clasico");
            comboMetodos.Items.Add("Newton-Raphson Relajado");
            comboMetodos.Items.Add("Newton-Raphson Mejorado");
        }

        private void comboMetodos_SelectedIndexChanged(object sender, EventArgs e) { }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            // Validar valor inicial
            if (string.IsNullOrWhiteSpace(textValorInicial.Text) || !double.TryParse(textValorInicial.Text, out double valorInicial))
            {
                MessageBox.Show("Por favor, ingrese un valor inicial válido.");
                return;
            }

            // Validar función
            string funcion = textFuncion.Text;
            if (!IsValidFunction(funcion))
            {
                MessageBox.Show("Por favor, ingrese una función válida que contenga la variable 'x'.");
                return;
            }

            textResultados.Clear();
            double resultado;

            // Elegir el método según la selección del usuario
            switch (comboMetodos.SelectedItem.ToString())
            {
                case "Newton-Raphson Clasico":
                    resultado = NewtonRaphsonClasico(funcion, valorInicial);
                    break;
                case "Newton-Raphson Relajado":
                    resultado = NewtonRaphsonRelajado(funcion, valorInicial, 0.5); // Puedes ajustar el valor de lambda
                    break;
                case "Newton-Raphson Mejorado":
                    resultado = NewtonRaphsonMejorado(funcion, valorInicial);
                    break;
                default:
                    MessageBox.Show("Seleccione un método.");
                    return;
            }

            textResultados.AppendText(double.IsNaN(resultado) ? "No se encontró una raíz." : $"Resultado final: {resultado}\n");
        }

        public double NewtonRaphsonClasico(string funcExpr, double initialGuess, double tol = 1e-6, int maxIter = 1000)
        {
            double currentGuess = initialGuess;
            int iter = 0;
            StringBuilder resultBuilder = new StringBuilder();

            // Encabezado para los resultados
            resultBuilder.AppendLine("Método Newton-Raphson (Clásico):");
            resultBuilder.AppendLine($"Función: {funcExpr}");
            resultBuilder.AppendLine($"Valor inicial: {initialGuess}");
            resultBuilder.AppendLine("Iteraciones:");

            while (iter < maxIter)
            {
                double fValue = EvaluateFunction(funcExpr, currentGuess);
                double fPrimeValue = DerivadaNumerica(funcExpr, currentGuess);

                // Verificar si f(x) o f'(x) son NaN o infinitos antes de continuar
                if (double.IsNaN(fValue) || double.IsInfinity(fValue))
                {
                    resultBuilder.AppendLine($"Error en la evaluación de f(x) en la iteración {iter + 1}. El valor de f(x) es indefinido o fuera de dominio.");
                    textResultados.AppendText(resultBuilder.ToString());
                    MessageBox.Show("Error: La función no es evaluable en el valor dado (fuera del dominio o indefinido).");
                    return double.NaN;
                }

                if (double.IsNaN(fPrimeValue) || double.IsInfinity(fPrimeValue))
                {
                    resultBuilder.AppendLine($"Error en la evaluación de f'(x) en la iteración {iter + 1}. La derivada es indefinida o no evaluable.");
                    textResultados.AppendText(resultBuilder.ToString());
                    MessageBox.Show("Error: La derivada no es evaluable en el valor dado.");
                    return double.NaN;
                }

                double nextGuess = currentGuess - fValue / fPrimeValue;
                double error = Math.Abs(nextGuess - currentGuess);

                // Agregar detalles de la iteración
                resultBuilder.AppendLine($"Iteración {iter + 1}:");
                resultBuilder.AppendLine($"   Aproximación = {nextGuess}");
                resultBuilder.AppendLine($"   f(x) = {fValue}");
                resultBuilder.AppendLine($"   f'(x) = {fPrimeValue}");
                resultBuilder.AppendLine($"   Error = {error}");

                // Verificar condiciones de tolerancia
                if (Math.Abs(fValue) < tol || error < tol)
                {
                    resultBuilder.AppendLine($"Raíz encontrada: {nextGuess}");
                    textResultados.AppendText(resultBuilder.ToString());
                    return nextGuess;
                }

                currentGuess = nextGuess;
                iter++;
            }

            // Si se alcanza el máximo de iteraciones sin encontrar una raíz
            resultBuilder.AppendLine("Se alcanzó el número máximo de iteraciones sin encontrar una raíz con la precisión deseada.");
            textResultados.AppendText(resultBuilder.ToString());
            MessageBox.Show("No se encontró una raíz con la precisión deseada.");
            return double.NaN;
        }

        public double NewtonRaphsonRelajado(string funcExpr, double initialGuess, double lambda = 0.5, double tol = 1e-6, int maxIter = 1000)
        {
            double currentGuess = initialGuess;
            int iter = 0;
            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.AppendLine("Método Newton-Raphson (Relajado):");
            resultBuilder.AppendLine($"Función: {funcExpr}");
            resultBuilder.AppendLine($"Valor inicial: {initialGuess}");
            resultBuilder.AppendLine($"Factor de relajación (λ): {lambda}");
            resultBuilder.AppendLine("Iteraciones:");

            while (iter < maxIter)
            {
                double fValue = EvaluateFunction(funcExpr, currentGuess);
                double fPrimeValue = DerivadaNumerica(funcExpr, currentGuess);

                if (double.IsNaN(fValue) || double.IsInfinity(fValue) || double.IsNaN(fPrimeValue) || double.IsInfinity(fPrimeValue))
                {
                    resultBuilder.AppendLine($"Error en la iteración {iter + 1}. Función o derivada indefinida.");
                    textResultados.AppendText(resultBuilder.ToString());
                    return double.NaN;
                }

                double nextGuess = currentGuess - lambda * (fValue / fPrimeValue);
                double error = Math.Abs(nextGuess - currentGuess);

                resultBuilder.AppendLine($"Iteración {iter + 1}: Aproximación = {nextGuess}, Error = {error}");

                if (Math.Abs(fValue) < tol || error < tol)
                {
                    resultBuilder.AppendLine($"Raíz encontrada: {nextGuess}");
                    textResultados.AppendText(resultBuilder.ToString());
                    return nextGuess;
                }

                currentGuess = nextGuess;
                iter++;
            }

            resultBuilder.AppendLine("Máximo de iteraciones alcanzado sin encontrar una raíz.");
            textResultados.AppendText(resultBuilder.ToString());
            return double.NaN;
        }

        public double NewtonRaphsonMejorado(string funcExpr, double initialGuess, double tol = 1e-6, int maxIter = 1000)
        {
            double currentGuess = initialGuess;
            int iter = 0;
            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.AppendLine("Método Newton-Raphson (Mejorado):");
            resultBuilder.AppendLine($"Función: {funcExpr}");
            resultBuilder.AppendLine($"Valor inicial: {initialGuess}");
            resultBuilder.AppendLine("Iteraciones:");

            while (iter < maxIter)
            {
                double fValue = EvaluateFunction(funcExpr, currentGuess);
                double fPrimeValue = DerivadaNumerica(funcExpr, currentGuess);
                double fDoublePrimeValue = DerivadaNumerica(EvaluateDerivative(funcExpr), currentGuess); // Segunda derivada

                if (double.IsNaN(fValue) || double.IsInfinity(fValue) || double.IsNaN(fPrimeValue) || double.IsInfinity(fPrimeValue))
                {
                    resultBuilder.AppendLine($"Error en la iteración {iter + 1}. Función o derivada indefinida.");
                    textResultados.AppendText(resultBuilder.ToString());
                    return double.NaN;
                }

                double correctionFactor = 1 - (fValue * fDoublePrimeValue) / (2 * fPrimeValue * fPrimeValue);
                double nextGuess = currentGuess - correctionFactor * (fValue / fPrimeValue);
                double error = Math.Abs(nextGuess - currentGuess);

                resultBuilder.AppendLine($"Iteración {iter + 1}: Aproximación = {nextGuess}, Error = {error}");

                if (Math.Abs(fValue) < tol || error < tol)
                {
                    resultBuilder.AppendLine($"Raíz encontrada: {nextGuess}");
                    textResultados.AppendText(resultBuilder.ToString());
                    return nextGuess;
                }

                currentGuess = nextGuess;
                iter++;
            }

            resultBuilder.AppendLine("Máximo de iteraciones alcanzado sin encontrar una raíz.");
            textResultados.AppendText(resultBuilder.ToString());
            return double.NaN;
        }

        private double DerivadaNumerica(string funcExpr, double x, double h = 1e-5)
        {
            double fxh1 = EvaluateFunction(funcExpr, x + h);
            double fxh2 = EvaluateFunction(funcExpr, x - h);
            return (fxh1 - fxh2) / (2 * h);
        }

        private double EvaluateFunction(string funcExpr, double x)
        {
            try
            {
                // Parsear la expresión usando Math.NET Symbolics
                var expression = Expr.Parse(funcExpr);

                // Crear un diccionario con el valor de la variable 'x'
                var variables = new Dictionary<string, FloatingPoint> { { "x", (FloatingPoint)x } };

                // Evaluar la expresión usando el valor de 'x'
                var result = expression.Evaluate(variables);

                // Convertir el resultado a un valor de tipo double
                return (double)result.RealValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al evaluar la función: {ex.Message}");
                return double.NaN;
            }
        }

        private bool IsValidFunction(string funcExpr)
        {
            var validPattern = @"^[0-9+\-*/().^ex ln sin cos tan]+$";
            return Regex.IsMatch(funcExpr, validPattern) && funcExpr.Contains("x");
        }

        private string EvaluateDerivative(string funcExpr)
        {
            var expr = Expr.Parse(funcExpr);
            return expr.Differentiate("x").ToString();
        }

        private void textValorInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y punto decimal en el valor inicial
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textResultados.Text = "";
            textFuncion.Text = "";
            textValorInicial.Text = "";
        }
    }
}


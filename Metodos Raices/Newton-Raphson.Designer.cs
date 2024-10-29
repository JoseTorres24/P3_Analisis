

namespace P3_Analisis
{
    partial class Newton_Raphson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textFuncion = new TextBox();
            textValorInicial = new TextBox();
            label2 = new Label();
            buttonCalcular = new Button();
            buttonLimpiar = new Button();
            comboMetodos = new ComboBox();
            textResultados = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 43);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Ingresar Funcion :";
            // 
            // textFuncion
            // 
            textFuncion.Location = new Point(246, 43);
            textFuncion.Margin = new Padding(4);
            textFuncion.Name = "textFuncion";
            textFuncion.Size = new Size(298, 26);
            textFuncion.TabIndex = 1;
            // 
            // textValorInicial
            // 
            textValorInicial.Location = new Point(246, 97);
            textValorInicial.Margin = new Padding(4);
            textValorInicial.Name = "textValorInicial";
            textValorInicial.Size = new Size(298, 26);
            textValorInicial.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 99);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 2;
            label2.Text = "Ingresar Valor Inicial :";
            // 
            // buttonCalcular
            // 
            buttonCalcular.BackColor = Color.Lime;
            buttonCalcular.Location = new Point(96, 143);
            buttonCalcular.Margin = new Padding(4);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(107, 31);
            buttonCalcular.TabIndex = 4;
            buttonCalcular.Text = "Calcular";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.BackColor = Color.OrangeRed;
            buttonLimpiar.Location = new Point(232, 201);
            buttonLimpiar.Margin = new Padding(4);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(107, 31);
            buttonLimpiar.TabIndex = 5;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = false;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // comboMetodos
            // 
            comboMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMetodos.FormattingEnabled = true;
            comboMetodos.Location = new Point(266, 147);
            comboMetodos.Name = "comboMetodos";
            comboMetodos.Size = new Size(241, 27);
            comboMetodos.TabIndex = 6;
            comboMetodos.SelectedIndexChanged += comboMetodos_SelectedIndexChanged;
            // 
            // textResultados
            // 
            textResultados.Font = new Font("Arial", 10F, FontStyle.Bold);
            textResultados.Location = new Point(12, 239);
            textResultados.Multiline = true;
            textResultados.Name = "textResultados";
            textResultados.ReadOnly = true;
            textResultados.ScrollBars = ScrollBars.Vertical;
            textResultados.Size = new Size(673, 398);
            textResultados.TabIndex = 7;
            // 
            // Newton_Raphson
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1383, 649);
            Controls.Add(textResultados);
            Controls.Add(comboMetodos);
            Controls.Add(buttonLimpiar);
            Controls.Add(buttonCalcular);
            Controls.Add(textValorInicial);
            Controls.Add(label2);
            Controls.Add(textFuncion);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Newton_Raphson";
            Text = "Newton_Raphson";
            Load += Newton_Raphson_Load;
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Label label1;
        private TextBox textFuncion;
        private TextBox textValorInicial;
        private Label label2;
        private Button buttonCalcular;
        private Button buttonLimpiar;
        private ComboBox comboMetodos;
        private TextBox textResultados;
    }
}
namespace P3_Analisis
{
    partial class Form3
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
            label2 = new Label();
            tamañoTxt = new Label();
            comboCantidad1 = new ComboBox();
            LabelIngresar = new Label();
            valorX1 = new TextBox();
            datosTabla1 = new DataGridView();
            x = new DataGridViewTextBoxColumn();
            Y = new DataGridViewTextBoxColumn();
            textResultado1 = new TextBox();
            labelResultado = new Label();
            botonPolinomioUnico = new Button();
            ((System.ComponentModel.ISupportInitialize)datosTabla1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(139, 33);
            label2.Name = "label2";
            label2.Size = new Size(167, 20);
            label2.TabIndex = 4;
            label2.Text = "Metodos de Interpolacion";
            // 
            // tamañoTxt
            // 
            tamañoTxt.AutoSize = true;
            tamañoTxt.Location = new Point(38, 102);
            tamañoTxt.Name = "tamañoTxt";
            tamañoTxt.Size = new Size(165, 15);
            tamañoTxt.TabIndex = 7;
            tamañoTxt.Text = "Tamaño en cantidad de datos:";
            // 
            // comboCantidad1
            // 
            comboCantidad1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCantidad1.FormattingEnabled = true;
            comboCantidad1.Location = new Point(209, 99);
            comboCantidad1.Name = "comboCantidad1";
            comboCantidad1.Size = new Size(72, 23);
            comboCantidad1.TabIndex = 8;
            comboCantidad1.SelectedIndexChanged += comboCantidad1_SelectedIndexChanged;
            // 
            // LabelIngresar
            // 
            LabelIngresar.AutoSize = true;
            LabelIngresar.Location = new Point(38, 156);
            LabelIngresar.Name = "LabelIngresar";
            LabelIngresar.Size = new Size(106, 15);
            LabelIngresar.TabIndex = 9;
            LabelIngresar.Text = "Ingresar valor de x:";
            // 
            // valorX1
            // 
            valorX1.Location = new Point(150, 153);
            valorX1.Name = "valorX1";
            valorX1.Size = new Size(131, 23);
            valorX1.TabIndex = 10;
            // 
            // datosTabla1
            // 
            datosTabla1.AllowUserToAddRows = false;
            datosTabla1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datosTabla1.Columns.AddRange(new DataGridViewColumn[] { x, Y });
            datosTabla1.Location = new Point(38, 208);
            datosTabla1.Name = "datosTabla1";
            datosTabla1.Size = new Size(242, 232);
            datosTabla1.TabIndex = 11;
            // 
            // x
            // 
            x.HeaderText = "X";
            x.Name = "x";
            // 
            // Y
            // 
            Y.HeaderText = "Y";
            Y.Name = "Y";
            // 
            // textResultado1
            // 
            textResultado1.Enabled = false;
            textResultado1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textResultado1.Location = new Point(353, 128);
            textResultado1.Multiline = true;
            textResultado1.Name = "textResultado1";
            textResultado1.Size = new Size(591, 416);
            textResultado1.TabIndex = 12;
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(353, 97);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 13;
            labelResultado.Text = "Resultado";
            // 
            // botonPolinomioUnico
            // 
            botonPolinomioUnico.Location = new Point(30, 478);
            botonPolinomioUnico.Name = "botonPolinomioUnico";
            botonPolinomioUnico.Size = new Size(242, 34);
            botonPolinomioUnico.TabIndex = 14;
            botonPolinomioUnico.Text = "Ejecutar Metodo de Polinomio Unico";
            botonPolinomioUnico.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 570);
            Controls.Add(botonPolinomioUnico);
            Controls.Add(labelResultado);
            Controls.Add(textResultado1);
            Controls.Add(datosTabla1);
            Controls.Add(valorX1);
            Controls.Add(LabelIngresar);
            Controls.Add(comboCantidad1);
            Controls.Add(tamañoTxt);
            Controls.Add(label2);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)datosTabla1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label tamañoTxt;
        private ComboBox comboCantidad1;
        private Label LabelIngresar;
        private TextBox valorX1;
        private DataGridView datosTabla1;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn Y;
        private TextBox textResultado1;
        private Label labelResultado;
        private Button botonPolinomioUnico;
    }
}
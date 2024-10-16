namespace P3_Analisis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boxMetodos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            botonDiferencias = new Button();
            datosTabla = new DataGridView();
            x = new DataGridViewTextBoxColumn();
            Y = new DataGridViewTextBoxColumn();
            comboCantidad = new ComboBox();
            tamañoTxt = new Label();
            LabelIngresar = new Label();
            valorX = new TextBox();
            textResultado = new TextBox();
            labelResultado = new Label();
            ((System.ComponentModel.ISupportInitialize)datosTabla).BeginInit();
            SuspendLayout();
            // 
            // boxMetodos
            // 
            boxMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMetodos.FormattingEnabled = true;
            boxMetodos.Location = new Point(12, 81);
            boxMetodos.Name = "boxMetodos";
            boxMetodos.Size = new Size(240, 23);
            boxMetodos.TabIndex = 0;
            boxMetodos.SelectedIndexChanged += boxMetodos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 63);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione Metodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(199, 20);
            label2.Name = "label2";
            label2.Size = new Size(167, 20);
            label2.TabIndex = 2;
            label2.Text = "Metodos de Interpolacion";
            // 
            // botonDiferencias
            // 
            botonDiferencias.Location = new Point(539, 240);
            botonDiferencias.Name = "botonDiferencias";
            botonDiferencias.Size = new Size(250, 31);
            botonDiferencias.TabIndex = 3;
            botonDiferencias.Text = "Ejecutar Diferencias Divididas de Newton";
            botonDiferencias.UseVisualStyleBackColor = true;
            botonDiferencias.Click += botonDiferencias_Click;
            // 
            // datosTabla
            // 
            datosTabla.AllowUserToAddRows = false;
            datosTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datosTabla.Columns.AddRange(new DataGridViewColumn[] { x, Y });
            datosTabla.Location = new Point(3, 162);
            datosTabla.Name = "datosTabla";
            datosTabla.Size = new Size(240, 230);
            datosTabla.TabIndex = 4;
            datosTabla.CellContentClick += dataGridView1_CellContentClick;
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
            // comboCantidad
            // 
            comboCantidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCantidad.FormattingEnabled = true;
            comboCantidad.Location = new Point(717, 159);
            comboCantidad.Name = "comboCantidad";
            comboCantidad.Size = new Size(72, 23);
            comboCantidad.TabIndex = 5;
            comboCantidad.SelectedIndexChanged += comboCantidad_SelectedIndexChanged;
            // 
            // tamañoTxt
            // 
            tamañoTxt.AutoSize = true;
            tamañoTxt.Location = new Point(539, 162);
            tamañoTxt.Name = "tamañoTxt";
            tamañoTxt.Size = new Size(165, 15);
            tamañoTxt.TabIndex = 6;
            tamañoTxt.Text = "Tamaño en cantidad de datos:";
            // 
            // LabelIngresar
            // 
            LabelIngresar.AutoSize = true;
            LabelIngresar.Location = new Point(539, 204);
            LabelIngresar.Name = "LabelIngresar";
            LabelIngresar.Size = new Size(106, 15);
            LabelIngresar.TabIndex = 7;
            LabelIngresar.Text = "Ingresar valor de x:";
            // 
            // valorX
            // 
            valorX.Location = new Point(651, 201);
            valorX.Name = "valorX";
            valorX.Size = new Size(138, 23);
            valorX.TabIndex = 8;
            valorX.TextChanged += valorX_TextChanged;
            // 
            // textResultado
            // 
            textResultado.Enabled = false;
            textResultado.Font = new Font("Arial", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textResultado.Location = new Point(263, 159);
            textResultado.Multiline = true;
            textResultado.Name = "textResultado";
            textResultado.Size = new Size(255, 294);
            textResultado.TabIndex = 9;
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(263, 132);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 10;
            labelResultado.Text = "Resultado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 488);
            Controls.Add(labelResultado);
            Controls.Add(textResultado);
            Controls.Add(valorX);
            Controls.Add(LabelIngresar);
            Controls.Add(tamañoTxt);
            Controls.Add(comboCantidad);
            Controls.Add(datosTabla);
            Controls.Add(botonDiferencias);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(boxMetodos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)datosTabla).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox boxMetodos;
        private Label label1;
        private Label label2;
        private Button botonDiferencias;
        private DataGridView datosTabla;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn Y;
        private ComboBox comboCantidad;
        private Label tamañoTxt;
        private Label LabelIngresar;
        private TextBox valorX;
        private TextBox textResultado;
        private Label labelResultado;
    }
}

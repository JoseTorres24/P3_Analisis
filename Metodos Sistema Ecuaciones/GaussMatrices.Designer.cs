namespace P3_Analisis
{
    partial class GaussMatrices
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
            lblTitulo = new Label();
            groupBoxOpciones = new GroupBox();
            rbCalcularInversa = new RadioButton();
            rbCalcularDeterminante = new RadioButton();
            rbResolverSistema = new RadioButton();
            btnEjecutar = new Button();
            txtTamanoMatriz = new TextBox();
            lblTamano = new Label();
            lstResultados = new ListBox();
            btnSalir = new Button();
            panelControlesDinamicos = new Panel();
            groupBoxOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resolución de Sistemas de Ecuaciones";
            // 
            // groupBoxOpciones
            // 
            groupBoxOpciones.Controls.Add(rbCalcularInversa);
            groupBoxOpciones.Controls.Add(rbCalcularDeterminante);
            groupBoxOpciones.Controls.Add(rbResolverSistema);
            groupBoxOpciones.Location = new Point(670, 27);
            groupBoxOpciones.Name = "groupBoxOpciones";
            groupBoxOpciones.Size = new Size(300, 120);
            groupBoxOpciones.TabIndex = 1;
            groupBoxOpciones.TabStop = false;
            groupBoxOpciones.Text = "Opciones";
            // 
            // rbCalcularInversa
            // 
            rbCalcularInversa.AutoSize = true;
            rbCalcularInversa.Location = new Point(20, 90);
            rbCalcularInversa.Name = "rbCalcularInversa";
            rbCalcularInversa.Size = new Size(108, 19);
            rbCalcularInversa.TabIndex = 2;
            rbCalcularInversa.TabStop = true;
            rbCalcularInversa.Text = "Calcular Inversa";
            rbCalcularInversa.UseVisualStyleBackColor = true;
            // 
            // rbCalcularDeterminante
            // 
            rbCalcularDeterminante.AutoSize = true;
            rbCalcularDeterminante.Location = new Point(20, 60);
            rbCalcularDeterminante.Name = "rbCalcularDeterminante";
            rbCalcularDeterminante.Size = new Size(143, 19);
            rbCalcularDeterminante.TabIndex = 1;
            rbCalcularDeterminante.TabStop = true;
            rbCalcularDeterminante.Text = "Calcular Determinante";
            rbCalcularDeterminante.UseVisualStyleBackColor = true;
            // 
            // rbResolverSistema
            // 
            rbResolverSistema.AutoSize = true;
            rbResolverSistema.Location = new Point(20, 30);
            rbResolverSistema.Name = "rbResolverSistema";
            rbResolverSistema.Size = new Size(191, 19);
            rbResolverSistema.TabIndex = 0;
            rbResolverSistema.TabStop = true;
            rbResolverSistema.Text = "Resolver Sistema de Ecuaciones";
            rbResolverSistema.UseVisualStyleBackColor = true;
            rbResolverSistema.CheckedChanged += rbResolverSistema_CheckedChanged;

            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(120, 494);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(250, 30);
            btnEjecutar.TabIndex = 2;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // txtTamanoMatriz
            // 
            txtTamanoMatriz.Location = new Point(603, 47);
            txtTamanoMatriz.Name = "txtTamanoMatriz";
            txtTamanoMatriz.Size = new Size(50, 23);
            txtTamanoMatriz.TabIndex = 3;
            // 
            // lblTamano
            // 
            lblTamano.AutoSize = true;
            lblTamano.Location = new Point(592, 29);
            lblTamano.Name = "lblTamano";
            lblTamano.Size = new Size(72, 15);
            lblTamano.TabIndex = 4;
            lblTamano.Text = "Tamaño (N):";
            // 
            // lstResultados
            // 
            lstResultados.Enabled = false;
            lstResultados.FormattingEnabled = true;
            lstResultados.ItemHeight = 15;
            lstResultados.Location = new Point(636, 197);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(435, 274);
            lstResultados.TabIndex = 5;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(695, 494);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(250, 30);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelControlesDinamicos
            // 
            panelControlesDinamicos.Location = new Point(35, 71);
            panelControlesDinamicos.Name = "panelControlesDinamicos";
            panelControlesDinamicos.Size = new Size(515, 345);
            panelControlesDinamicos.TabIndex = 0;
            panelControlesDinamicos.AutoScroll = true; // Habilitar el scroll automático si es necesario
            this.Controls.Add(panelControlesDinamicos); // Asegúrate de agregar el panel a los controles del formulario
            // 
            // GaussMatrices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 627);
            Controls.Add(btnSalir);
            Controls.Add(lstResultados);
            Controls.Add(lblTamano);
            Controls.Add(btnEjecutar);
            Controls.Add(txtTamanoMatriz);
            Controls.Add(groupBoxOpciones);
            Controls.Add(lblTitulo);
            Controls.Add(panelControlesDinamicos);
            Name = "GaussMatrices";
            Text = "GaussMatrices";
            Load += GaussMatrices_Load;
            groupBoxOpciones.ResumeLayout(false);
            groupBoxOpciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelControlesDinamicos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBoxOpciones;
        private System.Windows.Forms.RadioButton rbCalcularInversa;
        private System.Windows.Forms.RadioButton rbCalcularDeterminante;
        private System.Windows.Forms.RadioButton rbResolverSistema;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtTamanoMatriz;
        private System.Windows.Forms.Label lblTamano;
        private System.Windows.Forms.ListBox lstResultados;
        private System.Windows.Forms.Button btnSalir;

        #endregion
    }
}
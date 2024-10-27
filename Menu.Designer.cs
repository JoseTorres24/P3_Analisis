namespace P3_Analisis
{
    partial class Menu
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
            comboEcuaciones = new ComboBox();
            comboRaices = new ComboBox();
            comboInterpolacion = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboEcuaciones
            // 
            comboEcuaciones.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEcuaciones.FormattingEnabled = true;
            comboEcuaciones.Location = new Point(66, 390);
            comboEcuaciones.Name = "comboEcuaciones";
            comboEcuaciones.Size = new Size(164, 23);
            comboEcuaciones.TabIndex = 0;
            comboEcuaciones.SelectedIndexChanged += comboEcuaciones_SelectedIndexChanged;
            // 
            // comboRaices
            // 
            comboRaices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRaices.FormattingEnabled = true;
            comboRaices.Location = new Point(309, 390);
            comboRaices.Name = "comboRaices";
            comboRaices.Size = new Size(164, 23);
            comboRaices.TabIndex = 1;
            comboRaices.SelectedIndexChanged += comboRaices_SelectedIndexChanged;
            // 
            // comboInterpolacion
            // 
            comboInterpolacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboInterpolacion.FormattingEnabled = true;
            comboInterpolacion.Location = new Point(554, 390);
            comboInterpolacion.Name = "comboInterpolacion";
            comboInterpolacion.Size = new Size(164, 23);
            comboInterpolacion.TabIndex = 2;
            comboInterpolacion.SelectedIndexChanged += comboInterpolacion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei", 16F, FontStyle.Bold);
            label1.Location = new Point(359, 115);
            label1.Name = "label1";
            label1.Size = new Size(49, 28);
            label1.TabIndex = 3;
            label1.Text = "PIA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei Light", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(176, 159);
            label2.Name = "label2";
            label2.Size = new Size(416, 24);
            label2.TabIndex = 4;
            label2.Text = "METODOS REALIZADOS EN CADA PROYECTO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12.25F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(51, 352);
            label3.Name = "label3";
            label3.Size = new Size(188, 19);
            label3.TabIndex = 5;
            label3.Text = "Sistema de Ecuaciones";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(264, 351);
            label4.Name = "label4";
            label4.Size = new Size(243, 18);
            label4.TabIndex = 6;
            label4.Text = "Metodos para encontrar Raices";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(531, 353);
            label5.Name = "label5";
            label5.Size = new Size(214, 18);
            label5.TabIndex = 7;
            label5.Text = "Metodos para Interpolacion";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 621);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboInterpolacion);
            Controls.Add(comboRaices);
            Controls.Add(comboEcuaciones);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboEcuaciones;
        private ComboBox comboRaices;
        private ComboBox comboInterpolacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
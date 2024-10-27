namespace P3_Analisis
{
    partial class Form2
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
            LabelIngresar = new Label();
            textInterpolar = new TextBox();
            textValor1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            textValor2 = new TextBox();
            textResultadoLineal = new TextBox();
            botonMetodoLineal = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(174, 24);
            label2.Name = "label2";
            label2.Size = new Size(167, 20);
            label2.TabIndex = 3;
            label2.Text = "Metodos de Interpolacion";
            // 
            // LabelIngresar
            // 
            LabelIngresar.AutoSize = true;
            LabelIngresar.Location = new Point(40, 183);
            LabelIngresar.Name = "LabelIngresar";
            LabelIngresar.Size = new Size(99, 15);
            LabelIngresar.TabIndex = 8;
            LabelIngresar.Text = "Valor a Interpolar:";
            // 
            // textInterpolar
            // 
            textInterpolar.Location = new Point(152, 180);
            textInterpolar.Name = "textInterpolar";
            textInterpolar.Size = new Size(139, 23);
            textInterpolar.TabIndex = 9;
            // 
            // textValor1
            // 
            textValor1.Location = new Point(91, 115);
            textValor1.Name = "textValor1";
            textValor1.Size = new Size(124, 23);
            textValor1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 118);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 11;
            label1.Text = "Valor 1:";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(257, 121);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 13;
            label3.Text = "Valor 2:";
            // 
            // textValor2
            // 
            textValor2.Location = new Point(308, 118);
            textValor2.Name = "textValor2";
            textValor2.Size = new Size(124, 23);
            textValor2.TabIndex = 12;
            // 
            // textResultadoLineal
            // 
            textResultadoLineal.Enabled = false;
            textResultadoLineal.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textResultadoLineal.Location = new Point(107, 272);
            textResultadoLineal.Multiline = true;
            textResultadoLineal.Name = "textResultadoLineal";
            textResultadoLineal.Size = new Size(310, 235);
            textResultadoLineal.TabIndex = 14;
            // 
            // botonMetodoLineal
            // 
            botonMetodoLineal.Location = new Point(189, 230);
            botonMetodoLineal.Name = "botonMetodoLineal";
            botonMetodoLineal.Size = new Size(152, 23);
            botonMetodoLineal.TabIndex = 15;
            botonMetodoLineal.Text = "Ejecutar Metodo";
            botonMetodoLineal.UseVisualStyleBackColor = true;
            botonMetodoLineal.Click += botonMetodoLineal_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 571);
            Controls.Add(botonMetodoLineal);
            Controls.Add(textResultadoLineal);
            Controls.Add(label3);
            Controls.Add(textValor2);
            Controls.Add(label1);
            Controls.Add(textValor1);
            Controls.Add(textInterpolar);
            Controls.Add(LabelIngresar);
            Controls.Add(label2);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label LabelIngresar;
        private TextBox textInterpolar;
        private TextBox textValor1;
        private Label label1;
        private Label label3;
        private TextBox textValor2;
        private TextBox textResultadoLineal;
        private Button botonMetodoLineal;
    }
}
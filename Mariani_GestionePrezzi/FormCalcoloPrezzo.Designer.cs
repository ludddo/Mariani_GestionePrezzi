namespace Mariani_GestionePrezzi
{
    partial class FormCalcoloPrezzo
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
            this.comboBoxProdotti = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxMargine = new System.Windows.Forms.Label();
            this.buttonCalcolaPrezzo = new System.Windows.Forms.Button();
            this.labelPrezzoFinale = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxProdotti
            // 
            this.comboBoxProdotti.FormattingEnabled = true;
            this.comboBoxProdotti.Location = new System.Drawing.Point(138, 104);
            this.comboBoxProdotti.Name = "comboBoxProdotti";
            this.comboBoxProdotti.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProdotti.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(138, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleziona Prodotto";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(299, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBoxMargine
            // 
            this.textBoxMargine.AutoSize = true;
            this.textBoxMargine.ForeColor = System.Drawing.Color.Crimson;
            this.textBoxMargine.Location = new System.Drawing.Point(299, 84);
            this.textBoxMargine.Name = "textBoxMargine";
            this.textBoxMargine.Size = new System.Drawing.Size(109, 13);
            this.textBoxMargine.TabIndex = 3;
            this.textBoxMargine.Text = "Margine di Guadagno";
            // 
            // buttonCalcolaPrezzo
            // 
            this.buttonCalcolaPrezzo.Location = new System.Drawing.Point(138, 190);
            this.buttonCalcolaPrezzo.Name = "buttonCalcolaPrezzo";
            this.buttonCalcolaPrezzo.Size = new System.Drawing.Size(96, 31);
            this.buttonCalcolaPrezzo.TabIndex = 4;
            this.buttonCalcolaPrezzo.Text = "Calcola Prezzo";
            this.buttonCalcolaPrezzo.UseVisualStyleBackColor = true;
            this.buttonCalcolaPrezzo.Click += new System.EventHandler(this.buttonCalcolaPrezzo_Click_1);
            // 
            // labelPrezzoFinale
            // 
            this.labelPrezzoFinale.AutoSize = true;
            this.labelPrezzoFinale.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrezzoFinale.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPrezzoFinale.Location = new System.Drawing.Point(272, 294);
            this.labelPrezzoFinale.Name = "labelPrezzoFinale";
            this.labelPrezzoFinale.Size = new System.Drawing.Size(247, 42);
            this.labelPrezzoFinale.TabIndex = 5;
            this.labelPrezzoFinale.Text = "Prezzo Finale";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCalcoloPrezzo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPrezzoFinale);
            this.Controls.Add(this.buttonCalcolaPrezzo);
            this.Controls.Add(this.textBoxMargine);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProdotti);
            this.Name = "FormCalcoloPrezzo";
            this.Text = "FormCalcoloPrezzo";
            this.Load += new System.EventHandler(this.FormCalcoloPrezzo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProdotti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label textBoxMargine;
        private System.Windows.Forms.Button buttonCalcolaPrezzo;
        private System.Windows.Forms.Label labelPrezzoFinale;
        private System.Windows.Forms.Button button1;
    }
}
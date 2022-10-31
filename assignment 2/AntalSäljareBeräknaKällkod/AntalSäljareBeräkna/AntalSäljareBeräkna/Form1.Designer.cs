
namespace AntalSäljareBeräkna
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPersonnummer = new System.Windows.Forms.TextBox();
            this.textBoxDistrikt = new System.Windows.Forms.TextBox();
            this.textBoxAntalSåldaArtiklar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxResultat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNamn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Antal säljare i säljkår:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(16, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(334, 184);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(230, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Namn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personnummer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Distrikt:";
            // 
            // textBoxPersonnummer
            // 
            this.textBoxPersonnummer.Enabled = false;
            this.textBoxPersonnummer.Location = new System.Drawing.Point(162, 271);
            this.textBoxPersonnummer.MaxLength = 11;
            this.textBoxPersonnummer.Name = "textBoxPersonnummer";
            this.textBoxPersonnummer.Size = new System.Drawing.Size(189, 26);
            this.textBoxPersonnummer.TabIndex = 7;
            this.textBoxPersonnummer.TextChanged += new System.EventHandler(this.textBoxPersonnummer_TextChanged);
            // 
            // textBoxDistrikt
            // 
            this.textBoxDistrikt.Enabled = false;
            this.textBoxDistrikt.Location = new System.Drawing.Point(162, 303);
            this.textBoxDistrikt.MaxLength = 100;
            this.textBoxDistrikt.Name = "textBoxDistrikt";
            this.textBoxDistrikt.Size = new System.Drawing.Size(189, 26);
            this.textBoxDistrikt.TabIndex = 8;
            this.textBoxDistrikt.TextChanged += new System.EventHandler(this.textBoxDistrikt_TextChanged);
            // 
            // textBoxAntalSåldaArtiklar
            // 
            this.textBoxAntalSåldaArtiklar.Enabled = false;
            this.textBoxAntalSåldaArtiklar.Location = new System.Drawing.Point(162, 335);
            this.textBoxAntalSåldaArtiklar.MaxLength = 9;
            this.textBoxAntalSåldaArtiklar.Name = "textBoxAntalSåldaArtiklar";
            this.textBoxAntalSåldaArtiklar.Size = new System.Drawing.Size(189, 26);
            this.textBoxAntalSåldaArtiklar.TabIndex = 9;
            this.textBoxAntalSåldaArtiklar.TextChanged += new System.EventHandler(this.textBoxAntalSåldaArtiklar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Antal sålda artiklar:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Beräkna";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Spara i fil:";
            // 
            // textBoxResultat
            // 
            this.textBoxResultat.Location = new System.Drawing.Point(175, 399);
            this.textBoxResultat.Name = "textBoxResultat";
            this.textBoxResultat.Size = new System.Drawing.Size(176, 26);
            this.textBoxResultat.TabIndex = 13;
            this.textBoxResultat.Text = "resultat.txt";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(357, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 405);
            this.panel1.TabIndex = 14;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(370, 50);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(597, 375);
            this.textBox6.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Utmatning:";
            // 
            // textBoxNamn
            // 
            this.textBoxNamn.Enabled = false;
            this.textBoxNamn.Location = new System.Drawing.Point(162, 240);
            this.textBoxNamn.MaxLength = 100;
            this.textBoxNamn.Name = "textBoxNamn";
            this.textBoxNamn.Size = new System.Drawing.Size(189, 26);
            this.textBoxNamn.TabIndex = 17;
            this.textBoxNamn.TextChanged += new System.EventHandler(this.textBoxNamn_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 433);
            this.Controls.Add(this.textBoxNamn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxResultat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAntalSåldaArtiklar);
            this.Controls.Add(this.textBoxDistrikt);
            this.Controls.Add(this.textBoxPersonnummer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Antal säljare beräkna";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPersonnummer;
        private System.Windows.Forms.TextBox textBoxDistrikt;
        private System.Windows.Forms.TextBox textBoxAntalSåldaArtiklar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxResultat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNamn;
    }
}


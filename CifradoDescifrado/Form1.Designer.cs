namespace CifradoDescifrado
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
            this.label2 = new System.Windows.Forms.Label();
            this.textDescifrado = new System.Windows.Forms.TextBox();
            this.textCifrado = new System.Windows.Forms.TextBox();
            this.comboPadding = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDescifrado = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTipoCifrado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEncadenamiento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textIV = new System.Windows.Forms.TextBox();
            this.buttonCifrado = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textUuid = new System.Windows.Forms.TextBox();
            this.buttonUuid = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.comboLongKey = new System.Windows.Forms.ComboBox();
            this.generateKeyButton = new System.Windows.Forms.Button();
            this.textGenerateKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonCalcularMac = new System.Windows.Forms.Button();
            this.textBoxMAC = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTextMAC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textKeyMAC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxPaddingMAC = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxMAC = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto Cifrado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(19, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto Descifrado";
            // 
            // textDescifrado
            // 
            this.textDescifrado.Location = new System.Drawing.Point(124, 150);
            this.textDescifrado.Multiline = true;
            this.textDescifrado.Name = "textDescifrado";
            this.textDescifrado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textDescifrado.Size = new System.Drawing.Size(761, 71);
            this.textDescifrado.TabIndex = 2;
            // 
            // textCifrado
            // 
            this.textCifrado.Location = new System.Drawing.Point(124, 32);
            this.textCifrado.Multiline = true;
            this.textCifrado.Name = "textCifrado";
            this.textCifrado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textCifrado.Size = new System.Drawing.Size(761, 74);
            this.textCifrado.TabIndex = 3;
            this.textCifrado.TextChanged += new System.EventHandler(this.textCifrado_TextChanged);
            // 
            // comboPadding
            // 
            this.comboPadding.FormattingEnabled = true;
            this.comboPadding.Items.AddRange(new object[] {
            "PKCS7",
            "None",
            "ANSIX923",
            "ISO10126",
            "Zeros"});
            this.comboPadding.Location = new System.Drawing.Point(121, 292);
            this.comboPadding.Name = "comboPadding";
            this.comboPadding.Size = new System.Drawing.Size(149, 21);
            this.comboPadding.TabIndex = 4;
            this.comboPadding.SelectedIndexChanged += new System.EventHandler(this.comboPadding_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(67, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Padding";
            // 
            // buttonDescifrado
            // 
            this.buttonDescifrado.Location = new System.Drawing.Point(667, 356);
            this.buttonDescifrado.Name = "buttonDescifrado";
            this.buttonDescifrado.Size = new System.Drawing.Size(114, 23);
            this.buttonDescifrado.TabIndex = 6;
            this.buttonDescifrado.Text = "Descifrar";
            this.buttonDescifrado.UseVisualStyleBackColor = true;
            this.buttonDescifrado.Click += new System.EventHandler(this.buttonDescifrado_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(13, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Creado por Felipe Rodríguez Fonte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(390, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de Cifrado";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboTipoCifrado
            // 
            this.comboTipoCifrado.FormattingEnabled = true;
            this.comboTipoCifrado.Items.AddRange(new object[] {
            "DES",
            "3DES"});
            this.comboTipoCifrado.Location = new System.Drawing.Point(490, 236);
            this.comboTipoCifrado.Name = "comboTipoCifrado";
            this.comboTipoCifrado.Size = new System.Drawing.Size(149, 21);
            this.comboTipoCifrado.TabIndex = 8;
            this.comboTipoCifrado.SelectedIndexChanged += new System.EventHandler(this.comboTipoCifrado_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(26, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Encadenamiento";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboEncadenamiento
            // 
            this.comboEncadenamiento.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.comboEncadenamiento.FormattingEnabled = true;
            this.comboEncadenamiento.Items.AddRange(new object[] {
            "CBC",
            "ECB"});
            this.comboEncadenamiento.Location = new System.Drawing.Point(121, 342);
            this.comboEncadenamiento.Name = "comboEncadenamiento";
            this.comboEncadenamiento.Size = new System.Drawing.Size(149, 21);
            this.comboEncadenamiento.TabIndex = 10;
            this.comboEncadenamiento.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(452, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "IV";
            // 
            // textIV
            // 
            this.textIV.Location = new System.Drawing.Point(490, 287);
            this.textIV.Name = "textIV";
            this.textIV.Size = new System.Drawing.Size(149, 20);
            this.textIV.TabIndex = 14;
            // 
            // buttonCifrado
            // 
            this.buttonCifrado.Location = new System.Drawing.Point(490, 356);
            this.buttonCifrado.Name = "buttonCifrado";
            this.buttonCifrado.Size = new System.Drawing.Size(114, 23);
            this.buttonCifrado.TabIndex = 15;
            this.buttonCifrado.Text = "Cifrar";
            this.buttonCifrado.UseVisualStyleBackColor = true;
            this.buttonCifrado.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(67, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Clave";
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(121, 239);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(240, 20);
            this.textKey.TabIndex = 17;
            this.textKey.TextChanged += new System.EventHandler(this.textKey_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "uuid";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textUuid
            // 
            this.textUuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUuid.Location = new System.Drawing.Point(61, 64);
            this.textUuid.Name = "textUuid";
            this.textUuid.Size = new System.Drawing.Size(522, 23);
            this.textUuid.TabIndex = 19;
            // 
            // buttonUuid
            // 
            this.buttonUuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUuid.Location = new System.Drawing.Point(623, 61);
            this.buttonUuid.Name = "buttonUuid";
            this.buttonUuid.Size = new System.Drawing.Size(131, 34);
            this.buttonUuid.TabIndex = 20;
            this.buttonUuid.Text = "Generate uuid";
            this.buttonUuid.UseVisualStyleBackColor = true;
            this.buttonUuid.Click += new System.EventHandler(this.buttonUuid_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 454);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.textCifrado);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textDescifrado);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttonCifrado);
            this.tabPage1.Controls.Add(this.buttonDescifrado);
            this.tabPage1.Controls.Add(this.textKey);
            this.tabPage1.Controls.Add(this.textIV);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboPadding);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboTipoCifrado);
            this.tabPage1.Controls.Add(this.comboEncadenamiento);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt/Decrypt";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.comboLongKey);
            this.tabPage2.Controls.Add(this.generateKeyButton);
            this.tabPage2.Controls.Add(this.textGenerateKey);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.buttonUuid);
            this.tabPage2.Controls.Add(this.textUuid);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(917, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Utilidades";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(365, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 19);
            this.label11.TabIndex = 25;
            this.label11.Text = "Lenght key";
            // 
            // comboLongKey
            // 
            this.comboLongKey.FormattingEnabled = true;
            this.comboLongKey.Items.AddRange(new object[] {
            "16",
            "24",
            "32"});
            this.comboLongKey.Location = new System.Drawing.Point(462, 168);
            this.comboLongKey.Name = "comboLongKey";
            this.comboLongKey.Size = new System.Drawing.Size(121, 21);
            this.comboLongKey.TabIndex = 24;
            this.comboLongKey.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // generateKeyButton
            // 
            this.generateKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateKeyButton.Location = new System.Drawing.Point(623, 130);
            this.generateKeyButton.Name = "generateKeyButton";
            this.generateKeyButton.Size = new System.Drawing.Size(131, 29);
            this.generateKeyButton.TabIndex = 23;
            this.generateKeyButton.Text = "Generate key";
            this.generateKeyButton.UseVisualStyleBackColor = true;
            this.generateKeyButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textGenerateKey
            // 
            this.textGenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGenerateKey.Location = new System.Drawing.Point(61, 130);
            this.textGenerateKey.Name = "textGenerateKey";
            this.textGenerateKey.Size = new System.Drawing.Size(522, 23);
            this.textGenerateKey.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 19);
            this.label10.TabIndex = 21;
            this.label10.Text = "key";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.buttonCalcularMac);
            this.tabPage3.Controls.Add(this.textBoxMAC);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBoxTextMAC);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.textKeyMAC);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.comboBoxPaddingMAC);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.comboBoxMAC);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(917, 428);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Firmas";
            // 
            // buttonCalcularMac
            // 
            this.buttonCalcularMac.Location = new System.Drawing.Point(366, 301);
            this.buttonCalcularMac.Name = "buttonCalcularMac";
            this.buttonCalcularMac.Size = new System.Drawing.Size(114, 23);
            this.buttonCalcularMac.TabIndex = 28;
            this.buttonCalcularMac.Text = "Calcular";
            this.buttonCalcularMac.UseVisualStyleBackColor = true;
            this.buttonCalcularMac.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxMAC
            // 
            this.textBoxMAC.Location = new System.Drawing.Point(127, 126);
            this.textBoxMAC.Multiline = true;
            this.textBoxMAC.Name = "textBoxMAC";
            this.textBoxMAC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMAC.Size = new System.Drawing.Size(761, 60);
            this.textBoxMAC.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(69, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Firma";
            // 
            // textBoxTextMAC
            // 
            this.textBoxTextMAC.Location = new System.Drawing.Point(127, 37);
            this.textBoxTextMAC.Multiline = true;
            this.textBoxTextMAC.Name = "textBoxTextMAC";
            this.textBoxTextMAC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextMAC.Size = new System.Drawing.Size(761, 71);
            this.textBoxTextMAC.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(22, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 15);
            this.label13.TabIndex = 19;
            this.label13.Text = "Texto Sin Cifrar";
            // 
            // textKeyMAC
            // 
            this.textKeyMAC.Location = new System.Drawing.Point(127, 204);
            this.textKeyMAC.Name = "textKeyMAC";
            this.textKeyMAC.Size = new System.Drawing.Size(240, 20);
            this.textKeyMAC.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(73, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "Clave";
            // 
            // comboBoxPaddingMAC
            // 
            this.comboBoxPaddingMAC.FormattingEnabled = true;
            this.comboBoxPaddingMAC.Items.AddRange(new object[] {
            "PKCS7",
            "None",
            "ANSIX923",
            "ISO10126",
            "Zeros",
            "EMV"});
            this.comboBoxPaddingMAC.Location = new System.Drawing.Point(124, 263);
            this.comboBoxPaddingMAC.Name = "comboBoxPaddingMAC";
            this.comboBoxPaddingMAC.Size = new System.Drawing.Size(149, 21);
            this.comboBoxPaddingMAC.TabIndex = 22;
            this.comboBoxPaddingMAC.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaddingMAC_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(404, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "Tipo de Firma";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(69, 269);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "Padding";
            // 
            // comboBoxMAC
            // 
            this.comboBoxMAC.FormattingEnabled = true;
            this.comboBoxMAC.Items.AddRange(new object[] {
            "SHA256",
            "SHA512",
            "MAC X9.19"});
            this.comboBoxMAC.Location = new System.Drawing.Point(492, 204);
            this.comboBoxMAC.Name = "comboBoxMAC";
            this.comboBoxMAC.Size = new System.Drawing.Size(149, 21);
            this.comboBoxMAC.TabIndex = 24;
            this.comboBoxMAC.SelectedIndexChanged += new System.EventHandler(this.comboBoxMAC_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(952, 517);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Herramientas Criptográficas";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textDescifrado;
        public System.Windows.Forms.TextBox textCifrado;
        public System.Windows.Forms.ComboBox comboPadding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDescifrado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboTipoCifrado;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboEncadenamiento;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textIV;
        private System.Windows.Forms.Button buttonCifrado;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textUuid;
        private System.Windows.Forms.Button buttonUuid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button generateKeyButton;
        public System.Windows.Forms.TextBox textGenerateKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboLongKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonCalcularMac;
        public System.Windows.Forms.TextBox textBoxMAC;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBoxTextMAC;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox textKeyMAC;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox comboBoxPaddingMAC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox comboBoxMAC;
    }
}


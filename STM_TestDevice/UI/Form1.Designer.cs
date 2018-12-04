namespace STM_TestDevice
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonOpenCom = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxGPIB = new System.Windows.Forms.TextBox();
            this.buttonGPIB = new System.Windows.Forms.Button();
            this.buttonReadRES = new System.Windows.Forms.Button();
            this.buttonReadVolDC = new System.Windows.Forms.Button();
            this.buttonCurrDC = new System.Windows.Forms.Button();
            this.buttonResetGPIB = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test send STM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(350, 150);
            this.textBox1.TabIndex = 1;
            // 
            // buttonOpenCom
            // 
            this.buttonOpenCom.Location = new System.Drawing.Point(12, 37);
            this.buttonOpenCom.Name = "buttonOpenCom";
            this.buttonOpenCom.Size = new System.Drawing.Size(121, 23);
            this.buttonOpenCom.TabIndex = 15;
            this.buttonOpenCom.Text = "Open COM";
            this.buttonOpenCom.UseVisualStyleBackColor = true;
            this.buttonOpenCom.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // textBoxGPIB
            // 
            this.textBoxGPIB.Location = new System.Drawing.Point(257, 13);
            this.textBoxGPIB.Name = "textBoxGPIB";
            this.textBoxGPIB.Size = new System.Drawing.Size(100, 20);
            this.textBoxGPIB.TabIndex = 16;
            this.textBoxGPIB.Text = "GPIB0::5::INSTR";
            // 
            // buttonGPIB
            // 
            this.buttonGPIB.Location = new System.Drawing.Point(257, 40);
            this.buttonGPIB.Name = "buttonGPIB";
            this.buttonGPIB.Size = new System.Drawing.Size(100, 23);
            this.buttonGPIB.TabIndex = 17;
            this.buttonGPIB.Text = "Open GPIB";
            this.buttonGPIB.UseVisualStyleBackColor = true;
            this.buttonGPIB.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReadRES
            // 
            this.buttonReadRES.Location = new System.Drawing.Point(431, 78);
            this.buttonReadRES.Name = "buttonReadRES";
            this.buttonReadRES.Size = new System.Drawing.Size(184, 23);
            this.buttonReadRES.TabIndex = 18;
            this.buttonReadRES.Text = "Read Resistance";
            this.buttonReadRES.UseVisualStyleBackColor = true;
            this.buttonReadRES.Click += new System.EventHandler(this.buttonReadRES_Click);
            // 
            // buttonReadVolDC
            // 
            this.buttonReadVolDC.Location = new System.Drawing.Point(431, 121);
            this.buttonReadVolDC.Name = "buttonReadVolDC";
            this.buttonReadVolDC.Size = new System.Drawing.Size(184, 23);
            this.buttonReadVolDC.TabIndex = 19;
            this.buttonReadVolDC.Text = "Read Vol DC";
            this.buttonReadVolDC.UseVisualStyleBackColor = true;
            this.buttonReadVolDC.Click += new System.EventHandler(this.buttonReadVolDC_Click);
            // 
            // buttonCurrDC
            // 
            this.buttonCurrDC.Location = new System.Drawing.Point(431, 165);
            this.buttonCurrDC.Name = "buttonCurrDC";
            this.buttonCurrDC.Size = new System.Drawing.Size(184, 23);
            this.buttonCurrDC.TabIndex = 20;
            this.buttonCurrDC.Text = "Read Curr DC";
            this.buttonCurrDC.UseVisualStyleBackColor = true;
            this.buttonCurrDC.Click += new System.EventHandler(this.buttonCurrDC_Click);
            // 
            // buttonResetGPIB
            // 
            this.buttonResetGPIB.Location = new System.Drawing.Point(431, 205);
            this.buttonResetGPIB.Name = "buttonResetGPIB";
            this.buttonResetGPIB.Size = new System.Drawing.Size(184, 23);
            this.buttonResetGPIB.TabIndex = 21;
            this.buttonResetGPIB.Text = "Reset GPIB";
            this.buttonResetGPIB.UseVisualStyleBackColor = true;
            this.buttonResetGPIB.Click += new System.EventHandler(this.buttonResetGPIB_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(431, 245);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(184, 39);
            this.buttonExport.TabIndex = 22;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 452);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonResetGPIB);
            this.Controls.Add(this.buttonCurrDC);
            this.Controls.Add(this.buttonReadVolDC);
            this.Controls.Add(this.buttonReadRES);
            this.Controls.Add(this.buttonGPIB);
            this.Controls.Add(this.textBoxGPIB);
            this.Controls.Add(this.buttonOpenCom);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOpenCom;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxGPIB;
        private System.Windows.Forms.Button buttonGPIB;
        private System.Windows.Forms.Button buttonReadRES;
        private System.Windows.Forms.Button buttonReadVolDC;
        private System.Windows.Forms.Button buttonCurrDC;
        private System.Windows.Forms.Button buttonResetGPIB;
        private System.Windows.Forms.Button buttonExport;
    }
}


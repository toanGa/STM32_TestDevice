using System;

namespace STM_TestDevice.UI
{
    partial class BatteryTest
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOpenCom = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonMainViewConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.button15 = new System.Windows.Forms.Button();
            this.textBoxReportFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonViewConfig = new System.Windows.Forms.Button();
            this.buttonChangeConfigFile = new System.Windows.Forms.Button();
            this.textBoxConfigFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageSetting);
            this.tabControl1.Location = new System.Drawing.Point(409, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.panel1);
            this.tabPageMain.Controls.Add(this.buttonMainViewConfig);
            this.tabPageMain.Controls.Add(this.buttonLoadConfig);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(773, 519);
            this.tabPageMain.TabIndex = 12;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOpenCom);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(31, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 104);
            this.panel1.TabIndex = 2;
            // 
            // buttonOpenCom
            // 
            this.buttonOpenCom.Location = new System.Drawing.Point(13, 33);
            this.buttonOpenCom.Name = "buttonOpenCom";
            this.buttonOpenCom.Size = new System.Drawing.Size(121, 23);
            this.buttonOpenCom.TabIndex = 17;
            this.buttonOpenCom.Text = "Open COM";
            this.buttonOpenCom.UseVisualStyleBackColor = true;
            this.buttonOpenCom.Click += new System.EventHandler(this.buttonOpenCom_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // buttonMainViewConfig
            // 
            this.buttonMainViewConfig.Location = new System.Drawing.Point(160, 189);
            this.buttonMainViewConfig.Name = "buttonMainViewConfig";
            this.buttonMainViewConfig.Size = new System.Drawing.Size(112, 39);
            this.buttonMainViewConfig.TabIndex = 1;
            this.buttonMainViewConfig.Text = "View Config";
            this.buttonMainViewConfig.UseVisualStyleBackColor = true;
            this.buttonMainViewConfig.Click += new System.EventHandler(this.buttonViewConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(31, 189);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(112, 39);
            this.buttonLoadConfig.TabIndex = 0;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.button15);
            this.tabPageSetting.Controls.Add(this.textBoxReportFile);
            this.tabPageSetting.Controls.Add(this.label2);
            this.tabPageSetting.Controls.Add(this.buttonViewConfig);
            this.tabPageSetting.Controls.Add(this.buttonChangeConfigFile);
            this.tabPageSetting.Controls.Add(this.textBoxConfigFile);
            this.tabPageSetting.Controls.Add(this.label1);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(773, 519);
            this.tabPageSetting.TabIndex = 13;
            this.tabPageSetting.Text = "Setting";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(532, 119);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(103, 23);
            this.button15.TabIndex = 6;
            this.button15.Text = "Change";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // textBoxReportFile
            // 
            this.textBoxReportFile.Location = new System.Drawing.Point(35, 122);
            this.textBoxReportFile.Name = "textBoxReportFile";
            this.textBoxReportFile.Size = new System.Drawing.Size(479, 20);
            this.textBoxReportFile.TabIndex = 5;
            this.textBoxReportFile.Text = "result_battery.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Report File";
            // 
            // buttonViewConfig
            // 
            this.buttonViewConfig.Location = new System.Drawing.Point(94, 11);
            this.buttonViewConfig.Name = "buttonViewConfig";
            this.buttonViewConfig.Size = new System.Drawing.Size(90, 26);
            this.buttonViewConfig.TabIndex = 3;
            this.buttonViewConfig.Text = "ViewConfig";
            this.buttonViewConfig.UseVisualStyleBackColor = true;
            this.buttonViewConfig.Click += new System.EventHandler(this.buttonViewConfig_Click);
            // 
            // buttonChangeConfigFile
            // 
            this.buttonChangeConfigFile.Location = new System.Drawing.Point(532, 41);
            this.buttonChangeConfigFile.Name = "buttonChangeConfigFile";
            this.buttonChangeConfigFile.Size = new System.Drawing.Size(103, 23);
            this.buttonChangeConfigFile.TabIndex = 2;
            this.buttonChangeConfigFile.Text = "Change";
            this.buttonChangeConfigFile.UseVisualStyleBackColor = true;
            // 
            // textBoxConfigFile
            // 
            this.textBoxConfigFile.Location = new System.Drawing.Point(35, 43);
            this.textBoxConfigFile.Name = "textBoxConfigFile";
            this.textBoxConfigFile.Size = new System.Drawing.Size(479, 20);
            this.textBoxConfigFile.TabIndex = 1;
            this.textBoxConfigFile.Text = "ConfigBatery.xlsx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Config File";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 135);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(183, 135);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 184);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(165, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(183, 184);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 235);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(165, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(183, 235);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(161, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 284);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(165, 23);
            this.button11.TabIndex = 11;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(183, 284);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(161, 23);
            this.button12.TabIndex = 10;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // BatteryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 660);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "BatteryTest";
            this.Text = "BatteryTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatteryTest_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.Button buttonChangeConfigFile;
        private System.Windows.Forms.TextBox textBoxConfigFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonViewConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button buttonMainViewConfig;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOpenCom;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox textBoxReportFile;
        private System.Windows.Forms.Label label2;
    }
}
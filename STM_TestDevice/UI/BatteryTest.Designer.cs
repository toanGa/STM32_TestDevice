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
            this.button13 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDataCom = new System.Windows.Forms.Button();
            this.comboBoxData = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonControlCom = new System.Windows.Forms.Button();
            this.comboBoxControl = new System.Windows.Forms.ComboBox();
            this.buttonMainViewConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOpenReportFile = new System.Windows.Forms.Button();
            this.textBoxReportFile = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxAutoDrawChart = new System.Windows.Forms.CheckBox();
            this.textBoxTimerDrawChart = new System.Windows.Forms.TextBox();
            this.buttonChangeTimerDrawChart = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxConfigFile = new System.Windows.Forms.TextBox();
            this.buttonOpenConfigFile = new System.Windows.Forms.Button();
            this.buttonViewConfig = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGenReportFile = new System.Windows.Forms.TextBox();
            this.textBoxNumsRowCreate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonReportFile = new System.Windows.Forms.Button();
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
            this.serialPortControl = new System.IO.Ports.SerialPort(this.components);
            this.serialPortData = new System.IO.Ports.SerialPort(this.components);
            this.richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.timerUpdateData = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxFomatChart = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonFomatChart = new System.Windows.Forms.Button();
            this.buttonOpenFileFomatChart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageSetting);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(409, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.button13);
            this.tabPageMain.Controls.Add(this.panel2);
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
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(31, 254);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(241, 60);
            this.button13.TabIndex = 4;
            this.button13.Text = "Test";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonDataCom);
            this.panel2.Controls.Add(this.comboBoxData);
            this.panel2.Location = new System.Drawing.Point(343, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 104);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Data COM";
            // 
            // buttonDataCom
            // 
            this.buttonDataCom.Location = new System.Drawing.Point(12, 54);
            this.buttonDataCom.Name = "buttonDataCom";
            this.buttonDataCom.Size = new System.Drawing.Size(121, 23);
            this.buttonDataCom.TabIndex = 17;
            this.buttonDataCom.Text = "Open COM";
            this.buttonDataCom.UseVisualStyleBackColor = true;
            this.buttonDataCom.Click += new System.EventHandler(this.buttonDataCom_Click);
            // 
            // comboBoxData
            // 
            this.comboBoxData.FormattingEnabled = true;
            this.comboBoxData.Location = new System.Drawing.Point(12, 29);
            this.comboBoxData.Name = "comboBoxData";
            this.comboBoxData.Size = new System.Drawing.Size(121, 21);
            this.comboBoxData.TabIndex = 16;
            this.comboBoxData.DropDown += new System.EventHandler(this.comboBoxData_DropDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonControlCom);
            this.panel1.Controls.Add(this.comboBoxControl);
            this.panel1.Location = new System.Drawing.Point(31, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 104);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Control COM";
            // 
            // buttonControlCom
            // 
            this.buttonControlCom.Location = new System.Drawing.Point(12, 54);
            this.buttonControlCom.Name = "buttonControlCom";
            this.buttonControlCom.Size = new System.Drawing.Size(121, 23);
            this.buttonControlCom.TabIndex = 17;
            this.buttonControlCom.Text = "Open COM";
            this.buttonControlCom.UseVisualStyleBackColor = true;
            this.buttonControlCom.Click += new System.EventHandler(this.buttonControlCom_Click);
            // 
            // comboBoxControl
            // 
            this.comboBoxControl.FormattingEnabled = true;
            this.comboBoxControl.Location = new System.Drawing.Point(12, 29);
            this.comboBoxControl.Name = "comboBoxControl";
            this.comboBoxControl.Size = new System.Drawing.Size(121, 21);
            this.comboBoxControl.TabIndex = 16;
            this.comboBoxControl.DropDown += new System.EventHandler(this.comboBoxControl_DropDown);
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
            this.tabPageSetting.Controls.Add(this.panel6);
            this.tabPageSetting.Controls.Add(this.panel5);
            this.tabPageSetting.Controls.Add(this.panel4);
            this.tabPageSetting.Controls.Add(this.label5);
            this.tabPageSetting.Controls.Add(this.label2);
            this.tabPageSetting.Controls.Add(this.label1);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(773, 519);
            this.tabPageSetting.TabIndex = 13;
            this.tabPageSetting.Text = "Setting";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.buttonOpenReportFile);
            this.panel6.Controls.Add(this.textBoxReportFile);
            this.panel6.Location = new System.Drawing.Point(24, 186);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(630, 59);
            this.panel6.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Path:";
            // 
            // buttonOpenReportFile
            // 
            this.buttonOpenReportFile.Location = new System.Drawing.Point(542, 17);
            this.buttonOpenReportFile.Name = "buttonOpenReportFile";
            this.buttonOpenReportFile.Size = new System.Drawing.Size(84, 23);
            this.buttonOpenReportFile.TabIndex = 6;
            this.buttonOpenReportFile.Text = "Change";
            this.buttonOpenReportFile.UseVisualStyleBackColor = true;
            this.buttonOpenReportFile.Click += new System.EventHandler(this.buttonOpenReportFile_Click);
            // 
            // textBoxReportFile
            // 
            this.textBoxReportFile.Location = new System.Drawing.Point(51, 20);
            this.textBoxReportFile.Name = "textBoxReportFile";
            this.textBoxReportFile.Size = new System.Drawing.Size(485, 20);
            this.textBoxReportFile.TabIndex = 5;
            this.textBoxReportFile.Text = "result_battery.xlsx";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.checkBoxAutoDrawChart);
            this.panel5.Controls.Add(this.textBoxTimerDrawChart);
            this.panel5.Controls.Add(this.buttonChangeTimerDrawChart);
            this.panel5.Location = new System.Drawing.Point(24, 288);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(627, 100);
            this.panel5.TabIndex = 17;
            // 
            // checkBoxAutoDrawChart
            // 
            this.checkBoxAutoDrawChart.AutoSize = true;
            this.checkBoxAutoDrawChart.Location = new System.Drawing.Point(17, 19);
            this.checkBoxAutoDrawChart.Name = "checkBoxAutoDrawChart";
            this.checkBoxAutoDrawChart.Size = new System.Drawing.Size(101, 17);
            this.checkBoxAutoDrawChart.TabIndex = 15;
            this.checkBoxAutoDrawChart.Text = "Auto draw chart";
            this.checkBoxAutoDrawChart.UseVisualStyleBackColor = true;
            this.checkBoxAutoDrawChart.CheckedChanged += new System.EventHandler(this.checkBoxAutoDrawChart_CheckedChanged);
            // 
            // textBoxTimerDrawChart
            // 
            this.textBoxTimerDrawChart.Location = new System.Drawing.Point(17, 51);
            this.textBoxTimerDrawChart.Name = "textBoxTimerDrawChart";
            this.textBoxTimerDrawChart.Size = new System.Drawing.Size(78, 20);
            this.textBoxTimerDrawChart.TabIndex = 8;
            this.textBoxTimerDrawChart.Text = "30";
            this.textBoxTimerDrawChart.TextChanged += new System.EventHandler(this.textBoxTimerDrawChart_TextChanged);
            // 
            // buttonChangeTimerDrawChart
            // 
            this.buttonChangeTimerDrawChart.Location = new System.Drawing.Point(118, 48);
            this.buttonChangeTimerDrawChart.Name = "buttonChangeTimerDrawChart";
            this.buttonChangeTimerDrawChart.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeTimerDrawChart.TabIndex = 9;
            this.buttonChangeTimerDrawChart.Text = "Change";
            this.buttonChangeTimerDrawChart.UseVisualStyleBackColor = true;
            this.buttonChangeTimerDrawChart.Click += new System.EventHandler(this.buttonTimerDrawChart_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.textBoxConfigFile);
            this.panel4.Controls.Add(this.buttonOpenConfigFile);
            this.panel4.Controls.Add(this.buttonViewConfig);
            this.panel4.Location = new System.Drawing.Point(24, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(630, 100);
            this.panel4.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Path:";
            // 
            // textBoxConfigFile
            // 
            this.textBoxConfigFile.Location = new System.Drawing.Point(51, 12);
            this.textBoxConfigFile.Name = "textBoxConfigFile";
            this.textBoxConfigFile.Size = new System.Drawing.Size(485, 20);
            this.textBoxConfigFile.TabIndex = 1;
            this.textBoxConfigFile.Text = "ConfigBatery.xlsx";
            // 
            // buttonOpenConfigFile
            // 
            this.buttonOpenConfigFile.Location = new System.Drawing.Point(542, 9);
            this.buttonOpenConfigFile.Name = "buttonOpenConfigFile";
            this.buttonOpenConfigFile.Size = new System.Drawing.Size(84, 23);
            this.buttonOpenConfigFile.TabIndex = 2;
            this.buttonOpenConfigFile.Text = "Change";
            this.buttonOpenConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenConfigFile.Click += new System.EventHandler(this.buttonChangeConfigFile_Click);
            // 
            // buttonViewConfig
            // 
            this.buttonViewConfig.Location = new System.Drawing.Point(16, 51);
            this.buttonViewConfig.Name = "buttonViewConfig";
            this.buttonViewConfig.Size = new System.Drawing.Size(83, 32);
            this.buttonViewConfig.TabIndex = 3;
            this.buttonViewConfig.Text = "ViewConfig";
            this.buttonViewConfig.UseVisualStyleBackColor = true;
            this.buttonViewConfig.Click += new System.EventHandler(this.buttonViewConfig_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "3. Timer draw chart (s) - 0 to turn OFF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Report File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Config File";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.buttonReportFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(773, 519);
            this.tabPage1.TabIndex = 14;
            this.tabPage1.Text = "Tool";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBoxGenReportFile);
            this.panel3.Controls.Add(this.textBoxNumsRowCreate);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(29, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 81);
            this.panel3.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Path:";
            // 
            // textBoxGenReportFile
            // 
            this.textBoxGenReportFile.Location = new System.Drawing.Point(55, 15);
            this.textBoxGenReportFile.Name = "textBoxGenReportFile";
            this.textBoxGenReportFile.Size = new System.Drawing.Size(512, 20);
            this.textBoxGenReportFile.TabIndex = 11;
            this.textBoxGenReportFile.Text = "E:\\ReportGenerate.xlsx";
            // 
            // textBoxNumsRowCreate
            // 
            this.textBoxNumsRowCreate.Location = new System.Drawing.Point(122, 55);
            this.textBoxNumsRowCreate.Name = "textBoxNumsRowCreate";
            this.textBoxNumsRowCreate.Size = new System.Drawing.Size(91, 20);
            this.textBoxNumsRowCreate.TabIndex = 14;
            this.textBoxNumsRowCreate.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Numbers row create:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "1. Create Report file";
            // 
            // buttonReportFile
            // 
            this.buttonReportFile.Location = new System.Drawing.Point(29, 122);
            this.buttonReportFile.Name = "buttonReportFile";
            this.buttonReportFile.Size = new System.Drawing.Size(139, 31);
            this.buttonReportFile.TabIndex = 12;
            this.buttonReportFile.Text = "Generate";
            this.buttonReportFile.UseVisualStyleBackColor = true;
            this.buttonReportFile.Click += new System.EventHandler(this.buttonReportFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 135);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 34);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(183, 135);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 34);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 184);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(165, 33);
            this.button7.TabIndex = 7;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(183, 184);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 33);
            this.button8.TabIndex = 8;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 235);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(165, 33);
            this.button9.TabIndex = 9;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(183, 235);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(161, 33);
            this.button10.TabIndex = 12;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 284);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(165, 33);
            this.button11.TabIndex = 11;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(183, 284);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(161, 33);
            this.button12.TabIndex = 10;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button_Click);
            // 
            // serialPortControl
            // 
            this.serialPortControl.BaudRate = 115200;
            this.serialPortControl.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortControl_DataReceived);
            // 
            // serialPortData
            // 
            this.serialPortData.BaudRate = 115200;
            this.serialPortData.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortData_DataReceived);
            // 
            // richTextBoxDebug
            // 
            this.richTextBoxDebug.Location = new System.Drawing.Point(13, 364);
            this.richTextBoxDebug.Name = "richTextBoxDebug";
            this.richTextBoxDebug.Size = new System.Drawing.Size(374, 221);
            this.richTextBoxDebug.TabIndex = 13;
            this.richTextBoxDebug.Text = "";
            // 
            // timerUpdateData
            // 
            this.timerUpdateData.Interval = 10000;
            this.timerUpdateData.Tick += new System.EventHandler(this.timerUpdateData_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "2. Fomat chart";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Path:";
            // 
            // textBoxFomatChart
            // 
            this.textBoxFomatChart.Location = new System.Drawing.Point(55, 15);
            this.textBoxFomatChart.Name = "textBoxFomatChart";
            this.textBoxFomatChart.Size = new System.Drawing.Size(512, 20);
            this.textBoxFomatChart.TabIndex = 11;
            this.textBoxFomatChart.Text = "E:\\ReportGenerate.xlsx";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel7.Controls.Add(this.buttonOpenFileFomatChart);
            this.panel7.Controls.Add(this.buttonFomatChart);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.textBoxFomatChart);
            this.panel7.Location = new System.Drawing.Point(29, 222);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(657, 84);
            this.panel7.TabIndex = 17;
            // 
            // buttonFomatChart
            // 
            this.buttonFomatChart.Location = new System.Drawing.Point(17, 45);
            this.buttonFomatChart.Name = "buttonFomatChart";
            this.buttonFomatChart.Size = new System.Drawing.Size(107, 28);
            this.buttonFomatChart.TabIndex = 16;
            this.buttonFomatChart.Text = "Fomat Chart";
            this.buttonFomatChart.UseVisualStyleBackColor = true;
            this.buttonFomatChart.Click += new System.EventHandler(this.buttonFomatChart_Click);
            // 
            // buttonOpenFileFomatChart
            // 
            this.buttonOpenFileFomatChart.Location = new System.Drawing.Point(585, 12);
            this.buttonOpenFileFomatChart.Name = "buttonOpenFileFomatChart";
            this.buttonOpenFileFomatChart.Size = new System.Drawing.Size(60, 23);
            this.buttonOpenFileFomatChart.TabIndex = 17;
            this.buttonOpenFileFomatChart.Text = "Open";
            this.buttonOpenFileFomatChart.UseVisualStyleBackColor = true;
            this.buttonOpenFileFomatChart.Click += new System.EventHandler(this.buttonOpenFileFomatChart_Click);
            // 
            // BatteryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 660);
            this.Controls.Add(this.richTextBoxDebug);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BatteryTest_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
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
        private System.IO.Ports.SerialPort serialPortControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonControlCom;
        private System.Windows.Forms.ComboBox comboBoxControl;
        private System.IO.Ports.SerialPort serialPortData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDataCom;
        private System.Windows.Forms.ComboBox comboBoxData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxDebug;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Timer timerUpdateData;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.CheckBox checkBoxAutoDrawChart;
        private System.Windows.Forms.TextBox textBoxNumsRowCreate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonReportFile;
        private System.Windows.Forms.TextBox textBoxGenReportFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonChangeTimerDrawChart;
        private System.Windows.Forms.TextBox textBoxTimerDrawChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOpenReportFile;
        private System.Windows.Forms.TextBox textBoxReportFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonViewConfig;
        private System.Windows.Forms.Button buttonOpenConfigFile;
        private System.Windows.Forms.TextBox textBoxConfigFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxFomatChart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonFomatChart;
        private System.Windows.Forms.Button buttonOpenFileFomatChart;
    }
}
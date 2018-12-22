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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.buttonViewBatStat = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLogStatusBat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDataCom = new System.Windows.Forms.Button();
            this.comboBoxData = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonControlCom = new System.Windows.Forms.Button();
            this.comboBoxControl = new System.Windows.Forms.ComboBox();
            this.buttonMainViewConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.buttonFileConfig = new System.Windows.Forms.Button();
            this.buttonDeviceConfig = new System.Windows.Forms.Button();
            this.panelFileConfig = new System.Windows.Forms.Panel();
            this.panelDeviceConfig = new System.Windows.Forms.Panel();
            this.buttonConfig1 = new System.Windows.Forms.Button();
            this.buttonConfig10 = new System.Windows.Forms.Button();
            this.buttonConfig12 = new System.Windows.Forms.Button();
            this.buttonConfig11 = new System.Windows.Forms.Button();
            this.buttonConfig2 = new System.Windows.Forms.Button();
            this.buttonConfig3 = new System.Windows.Forms.Button();
            this.buttonConfig4 = new System.Windows.Forms.Button();
            this.buttonConfig6 = new System.Windows.Forms.Button();
            this.buttonConfig9 = new System.Windows.Forms.Button();
            this.buttonConfig8 = new System.Windows.Forms.Button();
            this.buttonConfig7 = new System.Windows.Forms.Button();
            this.buttonConfig5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOpenReportFile = new System.Windows.Forms.Button();
            this.textBoxReportFile = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxConfigFile = new System.Windows.Forms.TextBox();
            this.buttonOpenConfigFile = new System.Windows.Forms.Button();
            this.buttonViewConfig = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxAutoDrawChart = new System.Windows.Forms.CheckBox();
            this.textBoxTimerDrawChart = new System.Windows.Forms.TextBox();
            this.buttonChangeTimerDrawChart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageTool = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonOpenFileFomatChart = new System.Windows.Forms.Button();
            this.buttonFomatChart = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxFomatChart = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGenReportFile = new System.Windows.Forms.TextBox();
            this.textBoxNumsRowCreate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonReportFile = new System.Windows.Forms.Button();
            this.tabPageHelp = new System.Windows.Forms.TabPage();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.serialPortControl = new System.IO.Ports.SerialPort(this.components);
            this.serialPortData = new System.IO.Ports.SerialPort(this.components);
            this.richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.timerUpdateData = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPageRunning = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.batteryDetailControl = new STM_TestDevice.UI.BatteryDetailControl();
            this.labelSysInfo = new System.Windows.Forms.Label();
            this.timerSystemChecking = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelFileConfig.SuspendLayout();
            this.panelDeviceConfig.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPageTool.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageHelp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageRunning.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageSetting);
            this.tabControl.Controls.Add(this.tabPageRunning);
            this.tabControl.Controls.Add(this.tabPageTool);
            this.tabControl.Controls.Add(this.tabPageHelp);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(42, 20);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1036, 659);
            this.tabControl.TabIndex = 0;
            // 
            // buttonViewBatStat
            // 
            this.buttonViewBatStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewBatStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewBatStat.Location = new System.Drawing.Point(711, 19);
            this.buttonViewBatStat.Name = "buttonViewBatStat";
            this.buttonViewBatStat.Size = new System.Drawing.Size(196, 33);
            this.buttonViewBatStat.TabIndex = 9;
            this.buttonViewBatStat.Text = "View";
            this.buttonViewBatStat.UseVisualStyleBackColor = true;
            this.buttonViewBatStat.Click += new System.EventHandler(this.buttonViewBatStat_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(497, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Detail Battery status";
            // 
            // textBoxLogStatusBat
            // 
            this.textBoxLogStatusBat.Location = new System.Drawing.Point(493, 63);
            this.textBoxLogStatusBat.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLogStatusBat.Multiline = true;
            this.textBoxLogStatusBat.Name = "textBoxLogStatusBat";
            this.textBoxLogStatusBat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLogStatusBat.Size = new System.Drawing.Size(415, 513);
            this.textBoxLogStatusBat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Data COM";
            // 
            // buttonDataCom
            // 
            this.buttonDataCom.BackColor = System.Drawing.Color.Transparent;
            this.buttonDataCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataCom.ForeColor = System.Drawing.Color.White;
            this.buttonDataCom.Location = new System.Drawing.Point(225, 53);
            this.buttonDataCom.Name = "buttonDataCom";
            this.buttonDataCom.Size = new System.Drawing.Size(88, 29);
            this.buttonDataCom.TabIndex = 17;
            this.buttonDataCom.Text = "Open COM";
            this.buttonDataCom.UseVisualStyleBackColor = false;
            this.buttonDataCom.Click += new System.EventHandler(this.buttonDataCom_Click);
            // 
            // comboBoxData
            // 
            this.comboBoxData.FormattingEnabled = true;
            this.comboBoxData.Location = new System.Drawing.Point(84, 55);
            this.comboBoxData.Name = "comboBoxData";
            this.comboBoxData.Size = new System.Drawing.Size(121, 23);
            this.comboBoxData.TabIndex = 16;
            this.comboBoxData.DropDown += new System.EventHandler(this.comboBoxData_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Control COM";
            // 
            // buttonControlCom
            // 
            this.buttonControlCom.BackColor = System.Drawing.Color.Transparent;
            this.buttonControlCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControlCom.ForeColor = System.Drawing.Color.White;
            this.buttonControlCom.Location = new System.Drawing.Point(225, 10);
            this.buttonControlCom.Name = "buttonControlCom";
            this.buttonControlCom.Size = new System.Drawing.Size(88, 31);
            this.buttonControlCom.TabIndex = 17;
            this.buttonControlCom.Text = "Open COM";
            this.buttonControlCom.UseVisualStyleBackColor = false;
            this.buttonControlCom.Click += new System.EventHandler(this.buttonControlCom_Click);
            // 
            // comboBoxControl
            // 
            this.comboBoxControl.FormattingEnabled = true;
            this.comboBoxControl.Location = new System.Drawing.Point(84, 12);
            this.comboBoxControl.Name = "comboBoxControl";
            this.comboBoxControl.Size = new System.Drawing.Size(121, 23);
            this.comboBoxControl.TabIndex = 16;
            this.comboBoxControl.DropDown += new System.EventHandler(this.comboBoxControl_DropDown);
            // 
            // buttonMainViewConfig
            // 
            this.buttonMainViewConfig.BackColor = System.Drawing.Color.Transparent;
            this.buttonMainViewConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMainViewConfig.ForeColor = System.Drawing.Color.White;
            this.buttonMainViewConfig.Location = new System.Drawing.Point(225, 94);
            this.buttonMainViewConfig.Name = "buttonMainViewConfig";
            this.buttonMainViewConfig.Size = new System.Drawing.Size(88, 39);
            this.buttonMainViewConfig.TabIndex = 1;
            this.buttonMainViewConfig.Text = "View Config";
            this.buttonMainViewConfig.UseVisualStyleBackColor = false;
            this.buttonMainViewConfig.Click += new System.EventHandler(this.buttonViewConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.BackColor = System.Drawing.Color.Transparent;
            this.buttonLoadConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadConfig.ForeColor = System.Drawing.Color.White;
            this.buttonLoadConfig.Location = new System.Drawing.Point(6, 94);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(199, 39);
            this.buttonLoadConfig.TabIndex = 0;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = false;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.panelDeviceConfig);
            this.tabPageSetting.Controls.Add(this.panelFileConfig);
            this.tabPageSetting.Controls.Add(this.panel9);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 24);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(1028, 631);
            this.tabPageSetting.TabIndex = 13;
            this.tabPageSetting.Text = "Setting";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel9.Controls.Add(this.SidePanel);
            this.panel9.Controls.Add(this.buttonFileConfig);
            this.panel9.Controls.Add(this.buttonDeviceConfig);
            this.panel9.Location = new System.Drawing.Point(5, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(153, 578);
            this.panel9.TabIndex = 15;
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.SidePanel.Location = new System.Drawing.Point(3, 38);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 49);
            this.SidePanel.TabIndex = 2;
            // 
            // buttonFileConfig
            // 
            this.buttonFileConfig.FlatAppearance.BorderSize = 0;
            this.buttonFileConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFileConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFileConfig.ForeColor = System.Drawing.Color.White;
            this.buttonFileConfig.Location = new System.Drawing.Point(16, 97);
            this.buttonFileConfig.Name = "buttonFileConfig";
            this.buttonFileConfig.Size = new System.Drawing.Size(134, 43);
            this.buttonFileConfig.TabIndex = 1;
            this.buttonFileConfig.Text = "File config";
            this.buttonFileConfig.UseVisualStyleBackColor = true;
            this.buttonFileConfig.Click += new System.EventHandler(this.buttonFileConfig_Click);
            // 
            // buttonDeviceConfig
            // 
            this.buttonDeviceConfig.FlatAppearance.BorderSize = 0;
            this.buttonDeviceConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeviceConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeviceConfig.ForeColor = System.Drawing.Color.White;
            this.buttonDeviceConfig.Location = new System.Drawing.Point(16, 41);
            this.buttonDeviceConfig.Name = "buttonDeviceConfig";
            this.buttonDeviceConfig.Size = new System.Drawing.Size(134, 43);
            this.buttonDeviceConfig.TabIndex = 0;
            this.buttonDeviceConfig.Text = "Device config";
            this.buttonDeviceConfig.UseVisualStyleBackColor = true;
            this.buttonDeviceConfig.Click += new System.EventHandler(this.buttonDeviceConfig_Click);
            // 
            // panelFileConfig
            // 
            this.panelFileConfig.Controls.Add(this.panel6);
            this.panelFileConfig.Controls.Add(this.panel4);
            this.panelFileConfig.Controls.Add(this.panel5);
            this.panelFileConfig.Location = new System.Drawing.Point(180, 12);
            this.panelFileConfig.Name = "panelFileConfig";
            this.panelFileConfig.Size = new System.Drawing.Size(697, 471);
            this.panelFileConfig.TabIndex = 14;
            // 
            // panelDeviceConfig
            // 
            this.panelDeviceConfig.Controls.Add(this.panel2);
            this.panelDeviceConfig.Controls.Add(this.panel1);
            this.panelDeviceConfig.Location = new System.Drawing.Point(180, 19);
            this.panelDeviceConfig.Name = "panelDeviceConfig";
            this.panelDeviceConfig.Size = new System.Drawing.Size(725, 520);
            this.panelDeviceConfig.TabIndex = 14;
            // 
            // buttonConfig1
            // 
            this.buttonConfig1.FlatAppearance.BorderSize = 0;
            this.buttonConfig1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig1.ForeColor = System.Drawing.Color.White;
            this.buttonConfig1.Location = new System.Drawing.Point(44, 11);
            this.buttonConfig1.Name = "buttonConfig1";
            this.buttonConfig1.Size = new System.Drawing.Size(255, 61);
            this.buttonConfig1.TabIndex = 1;
            this.buttonConfig1.Text = "button1";
            this.buttonConfig1.UseVisualStyleBackColor = true;
            this.buttonConfig1.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig10
            // 
            this.buttonConfig10.FlatAppearance.BorderSize = 0;
            this.buttonConfig10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig10.ForeColor = System.Drawing.Color.White;
            this.buttonConfig10.Location = new System.Drawing.Point(322, 276);
            this.buttonConfig10.Name = "buttonConfig10";
            this.buttonConfig10.Size = new System.Drawing.Size(246, 26);
            this.buttonConfig10.TabIndex = 12;
            this.buttonConfig10.Text = "button10";
            this.buttonConfig10.UseVisualStyleBackColor = true;
            this.buttonConfig10.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig12
            // 
            this.buttonConfig12.FlatAppearance.BorderSize = 0;
            this.buttonConfig12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig12.ForeColor = System.Drawing.Color.White;
            this.buttonConfig12.Location = new System.Drawing.Point(322, 310);
            this.buttonConfig12.Name = "buttonConfig12";
            this.buttonConfig12.Size = new System.Drawing.Size(246, 26);
            this.buttonConfig12.TabIndex = 10;
            this.buttonConfig12.Text = "button12";
            this.buttonConfig12.UseVisualStyleBackColor = true;
            this.buttonConfig12.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig11
            // 
            this.buttonConfig11.FlatAppearance.BorderSize = 0;
            this.buttonConfig11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig11.ForeColor = System.Drawing.Color.White;
            this.buttonConfig11.Location = new System.Drawing.Point(44, 310);
            this.buttonConfig11.Name = "buttonConfig11";
            this.buttonConfig11.Size = new System.Drawing.Size(255, 23);
            this.buttonConfig11.TabIndex = 11;
            this.buttonConfig11.Text = "button11";
            this.buttonConfig11.UseVisualStyleBackColor = true;
            this.buttonConfig11.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig2
            // 
            this.buttonConfig2.FlatAppearance.BorderSize = 0;
            this.buttonConfig2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig2.ForeColor = System.Drawing.Color.White;
            this.buttonConfig2.Location = new System.Drawing.Point(322, 11);
            this.buttonConfig2.Name = "buttonConfig2";
            this.buttonConfig2.Size = new System.Drawing.Size(246, 61);
            this.buttonConfig2.TabIndex = 2;
            this.buttonConfig2.Text = "button2";
            this.buttonConfig2.UseVisualStyleBackColor = true;
            this.buttonConfig2.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig3
            // 
            this.buttonConfig3.FlatAppearance.BorderSize = 0;
            this.buttonConfig3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig3.ForeColor = System.Drawing.Color.White;
            this.buttonConfig3.Location = new System.Drawing.Point(44, 83);
            this.buttonConfig3.Name = "buttonConfig3";
            this.buttonConfig3.Size = new System.Drawing.Size(255, 62);
            this.buttonConfig3.TabIndex = 3;
            this.buttonConfig3.Text = "button3";
            this.buttonConfig3.UseVisualStyleBackColor = true;
            this.buttonConfig3.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig4
            // 
            this.buttonConfig4.FlatAppearance.BorderSize = 0;
            this.buttonConfig4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig4.ForeColor = System.Drawing.Color.White;
            this.buttonConfig4.Location = new System.Drawing.Point(322, 85);
            this.buttonConfig4.Name = "buttonConfig4";
            this.buttonConfig4.Size = new System.Drawing.Size(246, 60);
            this.buttonConfig4.TabIndex = 4;
            this.buttonConfig4.Text = "button4";
            this.buttonConfig4.UseVisualStyleBackColor = true;
            this.buttonConfig4.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig6
            // 
            this.buttonConfig6.FlatAppearance.BorderSize = 0;
            this.buttonConfig6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig6.ForeColor = System.Drawing.Color.White;
            this.buttonConfig6.Location = new System.Drawing.Point(322, 159);
            this.buttonConfig6.Name = "buttonConfig6";
            this.buttonConfig6.Size = new System.Drawing.Size(246, 63);
            this.buttonConfig6.TabIndex = 6;
            this.buttonConfig6.Text = "button6";
            this.buttonConfig6.UseVisualStyleBackColor = true;
            this.buttonConfig6.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig9
            // 
            this.buttonConfig9.FlatAppearance.BorderSize = 0;
            this.buttonConfig9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig9.ForeColor = System.Drawing.Color.White;
            this.buttonConfig9.Location = new System.Drawing.Point(44, 276);
            this.buttonConfig9.Name = "buttonConfig9";
            this.buttonConfig9.Size = new System.Drawing.Size(255, 26);
            this.buttonConfig9.TabIndex = 9;
            this.buttonConfig9.Text = "button9";
            this.buttonConfig9.UseVisualStyleBackColor = true;
            this.buttonConfig9.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig8
            // 
            this.buttonConfig8.FlatAppearance.BorderSize = 0;
            this.buttonConfig8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig8.ForeColor = System.Drawing.Color.White;
            this.buttonConfig8.Location = new System.Drawing.Point(322, 242);
            this.buttonConfig8.Name = "buttonConfig8";
            this.buttonConfig8.Size = new System.Drawing.Size(246, 25);
            this.buttonConfig8.TabIndex = 8;
            this.buttonConfig8.Text = "button8";
            this.buttonConfig8.UseVisualStyleBackColor = true;
            this.buttonConfig8.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig7
            // 
            this.buttonConfig7.FlatAppearance.BorderSize = 0;
            this.buttonConfig7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig7.ForeColor = System.Drawing.Color.White;
            this.buttonConfig7.Location = new System.Drawing.Point(44, 242);
            this.buttonConfig7.Name = "buttonConfig7";
            this.buttonConfig7.Size = new System.Drawing.Size(255, 25);
            this.buttonConfig7.TabIndex = 7;
            this.buttonConfig7.Text = "button7";
            this.buttonConfig7.UseVisualStyleBackColor = true;
            this.buttonConfig7.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonConfig5
            // 
            this.buttonConfig5.FlatAppearance.BorderSize = 0;
            this.buttonConfig5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig5.ForeColor = System.Drawing.Color.White;
            this.buttonConfig5.Location = new System.Drawing.Point(44, 159);
            this.buttonConfig5.Name = "buttonConfig5";
            this.buttonConfig5.Size = new System.Drawing.Size(255, 63);
            this.buttonConfig5.TabIndex = 5;
            this.buttonConfig5.Text = "button5";
            this.buttonConfig5.UseVisualStyleBackColor = true;
            this.buttonConfig5.Click += new System.EventHandler(this.button_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.buttonOpenReportFile);
            this.panel6.Controls.Add(this.textBoxReportFile);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(5, 126);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(683, 93);
            this.panel6.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Path:";
            // 
            // buttonOpenReportFile
            // 
            this.buttonOpenReportFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenReportFile.ForeColor = System.Drawing.Color.White;
            this.buttonOpenReportFile.Location = new System.Drawing.Point(600, 30);
            this.buttonOpenReportFile.Name = "buttonOpenReportFile";
            this.buttonOpenReportFile.Size = new System.Drawing.Size(84, 23);
            this.buttonOpenReportFile.TabIndex = 6;
            this.buttonOpenReportFile.Text = "Change";
            this.buttonOpenReportFile.UseVisualStyleBackColor = true;
            this.buttonOpenReportFile.Click += new System.EventHandler(this.buttonOpenReportFile_Click);
            // 
            // textBoxReportFile
            // 
            this.textBoxReportFile.Location = new System.Drawing.Point(51, 33);
            this.textBoxReportFile.Name = "textBoxReportFile";
            this.textBoxReportFile.Size = new System.Drawing.Size(547, 21);
            this.textBoxReportFile.TabIndex = 5;
            this.textBoxReportFile.Text = "result_battery.xlsx";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.ForestGreen;
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.textBoxConfigFile);
            this.panel4.Controls.Add(this.buttonOpenConfigFile);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.buttonViewConfig);
            this.panel4.Location = new System.Drawing.Point(5, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(684, 116);
            this.panel4.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(16, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Path:";
            // 
            // textBoxConfigFile
            // 
            this.textBoxConfigFile.Location = new System.Drawing.Point(51, 37);
            this.textBoxConfigFile.Name = "textBoxConfigFile";
            this.textBoxConfigFile.Size = new System.Drawing.Size(547, 21);
            this.textBoxConfigFile.TabIndex = 1;
            this.textBoxConfigFile.Text = "ConfigBatery.xlsx";
            // 
            // buttonOpenConfigFile
            // 
            this.buttonOpenConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenConfigFile.ForeColor = System.Drawing.Color.White;
            this.buttonOpenConfigFile.Location = new System.Drawing.Point(600, 36);
            this.buttonOpenConfigFile.Name = "buttonOpenConfigFile";
            this.buttonOpenConfigFile.Size = new System.Drawing.Size(84, 22);
            this.buttonOpenConfigFile.TabIndex = 2;
            this.buttonOpenConfigFile.Text = "Change";
            this.buttonOpenConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenConfigFile.Click += new System.EventHandler(this.buttonChangeConfigFile_Click);
            // 
            // buttonViewConfig
            // 
            this.buttonViewConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewConfig.ForeColor = System.Drawing.Color.White;
            this.buttonViewConfig.Location = new System.Drawing.Point(16, 66);
            this.buttonViewConfig.Name = "buttonViewConfig";
            this.buttonViewConfig.Size = new System.Drawing.Size(83, 32);
            this.buttonViewConfig.TabIndex = 3;
            this.buttonViewConfig.Text = "ViewConfig";
            this.buttonViewConfig.UseVisualStyleBackColor = true;
            this.buttonViewConfig.Click += new System.EventHandler(this.buttonViewConfig_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.checkBoxAutoDrawChart);
            this.panel5.Controls.Add(this.textBoxTimerDrawChart);
            this.panel5.Controls.Add(this.buttonChangeTimerDrawChart);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(5, 221);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(684, 133);
            this.panel5.TabIndex = 17;
            // 
            // checkBoxAutoDrawChart
            // 
            this.checkBoxAutoDrawChart.AutoSize = true;
            this.checkBoxAutoDrawChart.ForeColor = System.Drawing.Color.White;
            this.checkBoxAutoDrawChart.Location = new System.Drawing.Point(17, 39);
            this.checkBoxAutoDrawChart.Name = "checkBoxAutoDrawChart";
            this.checkBoxAutoDrawChart.Size = new System.Drawing.Size(110, 19);
            this.checkBoxAutoDrawChart.TabIndex = 15;
            this.checkBoxAutoDrawChart.Text = "Auto draw chart";
            this.checkBoxAutoDrawChart.UseVisualStyleBackColor = true;
            this.checkBoxAutoDrawChart.CheckedChanged += new System.EventHandler(this.checkBoxAutoDrawChart_CheckedChanged);
            // 
            // textBoxTimerDrawChart
            // 
            this.textBoxTimerDrawChart.Location = new System.Drawing.Point(17, 71);
            this.textBoxTimerDrawChart.Name = "textBoxTimerDrawChart";
            this.textBoxTimerDrawChart.Size = new System.Drawing.Size(78, 21);
            this.textBoxTimerDrawChart.TabIndex = 8;
            this.textBoxTimerDrawChart.Text = "30";
            this.textBoxTimerDrawChart.TextChanged += new System.EventHandler(this.textBoxTimerDrawChart_TextChanged);
            // 
            // buttonChangeTimerDrawChart
            // 
            this.buttonChangeTimerDrawChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeTimerDrawChart.ForeColor = System.Drawing.Color.White;
            this.buttonChangeTimerDrawChart.Location = new System.Drawing.Point(118, 68);
            this.buttonChangeTimerDrawChart.Name = "buttonChangeTimerDrawChart";
            this.buttonChangeTimerDrawChart.Size = new System.Drawing.Size(75, 26);
            this.buttonChangeTimerDrawChart.TabIndex = 9;
            this.buttonChangeTimerDrawChart.Text = "Change";
            this.buttonChangeTimerDrawChart.UseVisualStyleBackColor = true;
            this.buttonChangeTimerDrawChart.Click += new System.EventHandler(this.buttonTimerDrawChart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Config File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Report File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "3. Timer draw chart (s) - 0 to turn OFF";
            // 
            // tabPageTool
            // 
            this.tabPageTool.Controls.Add(this.panel7);
            this.tabPageTool.Controls.Add(this.panel3);
            this.tabPageTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageTool.Location = new System.Drawing.Point(4, 24);
            this.tabPageTool.Name = "tabPageTool";
            this.tabPageTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTool.Size = new System.Drawing.Size(1028, 631);
            this.tabPageTool.TabIndex = 14;
            this.tabPageTool.Text = "Tool";
            this.tabPageTool.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))));
            this.panel7.Controls.Add(this.buttonOpenFileFomatChart);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.buttonFomatChart);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.textBoxFomatChart);
            this.panel7.Location = new System.Drawing.Point(10, 176);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(877, 113);
            this.panel7.TabIndex = 17;
            // 
            // buttonOpenFileFomatChart
            // 
            this.buttonOpenFileFomatChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFileFomatChart.ForeColor = System.Drawing.Color.White;
            this.buttonOpenFileFomatChart.Location = new System.Drawing.Point(585, 36);
            this.buttonOpenFileFomatChart.Name = "buttonOpenFileFomatChart";
            this.buttonOpenFileFomatChart.Size = new System.Drawing.Size(60, 23);
            this.buttonOpenFileFomatChart.TabIndex = 17;
            this.buttonOpenFileFomatChart.Text = "Open";
            this.buttonOpenFileFomatChart.UseVisualStyleBackColor = true;
            this.buttonOpenFileFomatChart.Click += new System.EventHandler(this.buttonOpenFileFomatChart_Click);
            // 
            // buttonFomatChart
            // 
            this.buttonFomatChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFomatChart.ForeColor = System.Drawing.Color.White;
            this.buttonFomatChart.Location = new System.Drawing.Point(14, 68);
            this.buttonFomatChart.Name = "buttonFomatChart";
            this.buttonFomatChart.Size = new System.Drawing.Size(139, 33);
            this.buttonFomatChart.TabIndex = 16;
            this.buttonFomatChart.Text = "Fomat Chart";
            this.buttonFomatChart.UseVisualStyleBackColor = true;
            this.buttonFomatChart.Click += new System.EventHandler(this.buttonFomatChart_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(14, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Path:";
            // 
            // textBoxFomatChart
            // 
            this.textBoxFomatChart.Location = new System.Drawing.Point(55, 39);
            this.textBoxFomatChart.Name = "textBoxFomatChart";
            this.textBoxFomatChart.Size = new System.Drawing.Size(512, 20);
            this.textBoxFomatChart.TabIndex = 11;
            this.textBoxFomatChart.Text = "E:\\ReportGenerate.xlsx";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(14, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "2. Fomat chart";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBoxGenReportFile);
            this.panel3.Controls.Add(this.textBoxNumsRowCreate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.buttonReportFile);
            this.panel3.Location = new System.Drawing.Point(10, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 141);
            this.panel3.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Path:";
            // 
            // textBoxGenReportFile
            // 
            this.textBoxGenReportFile.Location = new System.Drawing.Point(55, 40);
            this.textBoxGenReportFile.Name = "textBoxGenReportFile";
            this.textBoxGenReportFile.Size = new System.Drawing.Size(512, 20);
            this.textBoxGenReportFile.TabIndex = 11;
            this.textBoxGenReportFile.Text = "E:\\ReportGenerate.xlsx";
            // 
            // textBoxNumsRowCreate
            // 
            this.textBoxNumsRowCreate.Location = new System.Drawing.Point(122, 76);
            this.textBoxNumsRowCreate.Name = "textBoxNumsRowCreate";
            this.textBoxNumsRowCreate.Size = new System.Drawing.Size(79, 20);
            this.textBoxNumsRowCreate.TabIndex = 14;
            this.textBoxNumsRowCreate.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Numbers row create:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "1. Create Report file";
            // 
            // buttonReportFile
            // 
            this.buttonReportFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReportFile.ForeColor = System.Drawing.Color.White;
            this.buttonReportFile.Location = new System.Drawing.Point(14, 102);
            this.buttonReportFile.Name = "buttonReportFile";
            this.buttonReportFile.Size = new System.Drawing.Size(139, 31);
            this.buttonReportFile.TabIndex = 12;
            this.buttonReportFile.Text = "Generate";
            this.buttonReportFile.UseVisualStyleBackColor = true;
            this.buttonReportFile.Click += new System.EventHandler(this.buttonReportFile_Click);
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.Controls.Add(this.textBoxHelp);
            this.tabPageHelp.Location = new System.Drawing.Point(4, 24);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelp.Size = new System.Drawing.Size(1028, 631);
            this.tabPageHelp.TabIndex = 15;
            this.tabPageHelp.Text = "Help";
            this.tabPageHelp.UseVisualStyleBackColor = true;
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.textBoxHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHelp.ForeColor = System.Drawing.Color.White;
            this.textBoxHelp.Location = new System.Drawing.Point(6, 6);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHelp.Size = new System.Drawing.Size(901, 576);
            this.textBoxHelp.TabIndex = 0;
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
            this.richTextBoxDebug.Location = new System.Drawing.Point(6, 63);
            this.richTextBoxDebug.Name = "richTextBoxDebug";
            this.richTextBoxDebug.Size = new System.Drawing.Size(465, 513);
            this.richTextBoxDebug.TabIndex = 13;
            this.richTextBoxDebug.Text = "";
            // 
            // timerUpdateData
            // 
            this.timerUpdateData.Interval = 10000;
            this.timerUpdateData.Tick += new System.EventHandler(this.timerUpdateData_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.buttonDataCom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxControl);
            this.panel1.Controls.Add(this.comboBoxData);
            this.panel1.Controls.Add(this.buttonMainViewConfig);
            this.panel1.Controls.Add(this.buttonControlCom);
            this.panel1.Controls.Add(this.buttonLoadConfig);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 143);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OliveDrab;
            this.panel2.Controls.Add(this.buttonConfig1);
            this.panel2.Controls.Add(this.buttonConfig5);
            this.panel2.Controls.Add(this.buttonConfig10);
            this.panel2.Controls.Add(this.buttonConfig7);
            this.panel2.Controls.Add(this.buttonConfig12);
            this.panel2.Controls.Add(this.buttonConfig8);
            this.panel2.Controls.Add(this.buttonConfig11);
            this.panel2.Controls.Add(this.buttonConfig9);
            this.panel2.Controls.Add(this.buttonConfig2);
            this.panel2.Controls.Add(this.buttonConfig6);
            this.panel2.Controls.Add(this.buttonConfig3);
            this.panel2.Controls.Add(this.buttonConfig4);
            this.panel2.Location = new System.Drawing.Point(4, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 352);
            this.panel2.TabIndex = 14;
            // 
            // tabPageRunning
            // 
            this.tabPageRunning.Controls.Add(this.label14);
            this.tabPageRunning.Controls.Add(this.richTextBoxDebug);
            this.tabPageRunning.Controls.Add(this.buttonViewBatStat);
            this.tabPageRunning.Controls.Add(this.label13);
            this.tabPageRunning.Controls.Add(this.textBoxLogStatusBat);
            this.tabPageRunning.Location = new System.Drawing.Point(4, 24);
            this.tabPageRunning.Name = "tabPageRunning";
            this.tabPageRunning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRunning.Size = new System.Drawing.Size(1028, 631);
            this.tabPageRunning.TabIndex = 16;
            this.tabPageRunning.Text = "Running";
            this.tabPageRunning.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(172, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "Log Debug";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(7, 593);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(185, 34);
            this.button13.TabIndex = 4;
            this.button13.Text = "Test";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.Transparent;
            this.tabPageMain.Controls.Add(this.textBox1);
            this.tabPageMain.Controls.Add(this.panelMain);
            this.tabPageMain.Controls.Add(this.button13);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1028, 631);
            this.tabPageMain.TabIndex = 12;
            this.tabPageMain.Text = "Main";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelSysInfo);
            this.panelMain.Controls.Add(this.batteryDetailControl);
            this.panelMain.Location = new System.Drawing.Point(7, 7);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1015, 582);
            this.panelMain.TabIndex = 5;
            // 
            // batteryDetailControl
            // 
            this.batteryDetailControl.Location = new System.Drawing.Point(9, 39);
            this.batteryDetailControl.Name = "batteryDetailControl";
            this.batteryDetailControl.Size = new System.Drawing.Size(1002, 536);
            this.batteryDetailControl.TabIndex = 0;
            // 
            // labelSysInfo
            // 
            this.labelSysInfo.AutoSize = true;
            this.labelSysInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSysInfo.Location = new System.Drawing.Point(13, 10);
            this.labelSysInfo.Name = "labelSysInfo";
            this.labelSysInfo.Size = new System.Drawing.Size(377, 24);
            this.labelSysInfo.TabIndex = 1;
            this.labelSysInfo.Text = "System not running, please go to Setting tab";
            // 
            // timerSystemChecking
            // 
            this.timerSystemChecking.Enabled = true;
            this.timerSystemChecking.Interval = 1000;
            this.timerSystemChecking.Tick += new System.EventHandler(this.timerSystemChecking_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(242, 596);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(417, 21);
            this.textBox1.TabIndex = 6;
            // 
            // BatteryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "BatteryTest";
            this.Text = "BatteryTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BatteryTest_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPageSetting.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panelFileConfig.ResumeLayout(false);
            this.panelDeviceConfig.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPageTool.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageHelp.ResumeLayout(false);
            this.tabPageHelp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPageRunning.ResumeLayout(false);
            this.tabPageRunning.PerformLayout();
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button buttonConfig1;
        private System.Windows.Forms.Button buttonConfig2;
        private System.Windows.Forms.Button buttonConfig3;
        private System.Windows.Forms.Button buttonConfig4;
        private System.Windows.Forms.Button buttonConfig5;
        private System.Windows.Forms.Button buttonConfig6;
        private System.Windows.Forms.Button buttonConfig7;
        private System.Windows.Forms.Button buttonConfig8;
        private System.Windows.Forms.Button buttonConfig9;
        private System.Windows.Forms.Button buttonConfig10;
        private System.Windows.Forms.Button buttonConfig11;
        private System.Windows.Forms.Button buttonConfig12;
        private System.Windows.Forms.Button buttonMainViewConfig;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.IO.Ports.SerialPort serialPortControl;
        private System.Windows.Forms.Button buttonControlCom;
        private System.Windows.Forms.ComboBox comboBoxControl;
        private System.IO.Ports.SerialPort serialPortData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDataCom;
        private System.Windows.Forms.ComboBox comboBoxData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxDebug;
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
        private System.Windows.Forms.TabPage tabPageTool;
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
        private System.Windows.Forms.TextBox textBoxLogStatusBat;
        private System.Windows.Forms.TabPage tabPageHelp;
        private System.Windows.Forms.TextBox textBoxHelp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonViewBatStat;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button buttonFileConfig;
        private System.Windows.Forms.Button buttonDeviceConfig;
        private System.Windows.Forms.Panel panelFileConfig;
        private System.Windows.Forms.Panel panelDeviceConfig;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPageRunning;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Panel panelMain;
        private BatteryDetailControl batteryDetailControl;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label labelSysInfo;
        private System.Windows.Forms.Timer timerSystemChecking;
        private System.Windows.Forms.TextBox textBox1;
    }
}
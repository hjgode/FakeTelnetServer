namespace TelnetFake
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.btnTestScreen = new System.Windows.Forms.Button();
            this.listTestCodes = new System.Windows.Forms.ListBox();
            this.btnSendCode = new System.Windows.Forms.Button();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.listBoxTestScreens = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(527, 11);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 32);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(257, 299);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(370, 136);
            this.txtLog.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(527, 48);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(100, 32);
            this.btnStopServer.TabIndex = 0;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(306, 11);
            this.numericWidth.Maximum = new decimal(new int[] {
            132,
            0,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(49, 20);
            this.numericWidth.TabIndex = 5;
            this.numericWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(306, 48);
            this.numericHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(49, 20);
            this.numericHeight.TabIndex = 5;
            this.numericHeight.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // btnTestScreen
            // 
            this.btnTestScreen.Location = new System.Drawing.Point(361, 48);
            this.btnTestScreen.Name = "btnTestScreen";
            this.btnTestScreen.Size = new System.Drawing.Size(106, 32);
            this.btnTestScreen.TabIndex = 6;
            this.btnTestScreen.Text = "test screen";
            this.btnTestScreen.UseVisualStyleBackColor = true;
            this.btnTestScreen.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // listTestCodes
            // 
            this.listTestCodes.FormattingEnabled = true;
            this.listTestCodes.Location = new System.Drawing.Point(268, 86);
            this.listTestCodes.Name = "listTestCodes";
            this.listTestCodes.Size = new System.Drawing.Size(199, 121);
            this.listTestCodes.TabIndex = 7;
            // 
            // btnSendCode
            // 
            this.btnSendCode.Location = new System.Drawing.Point(472, 178);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(73, 28);
            this.btnSendCode.TabIndex = 8;
            this.btnSendCode.Text = "send code";
            this.btnSendCode.UseVisualStyleBackColor = true;
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(472, 266);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(106, 27);
            this.btnSendTest.TabIndex = 9;
            this.btnSendTest.Text = "Send Test";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBoxTestScreens
            // 
            this.listBoxTestScreens.FormattingEnabled = true;
            this.listBoxTestScreens.Location = new System.Drawing.Point(268, 224);
            this.listBoxTestScreens.Name = "listBoxTestScreens";
            this.listBoxTestScreens.Size = new System.Drawing.Size(198, 69);
            this.listBoxTestScreens.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 24);
            this.button2.TabIndex = 11;
            this.button2.Text = "^";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(475, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 24);
            this.button3.TabIndex = 11;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(537, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 24);
            this.button5.TabIndex = 11;
            this.button5.Text = ">";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(506, 148);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 24);
            this.button6.TabIndex = 11;
            this.button6.Text = "v";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(475, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 24);
            this.button4.TabIndex = 11;
            this.button4.Text = "M";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(537, 148);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 24);
            this.button7.TabIndex = 11;
            this.button7.Text = "C";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 447);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxTestScreens);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.btnSendCode);
            this.Controls.Add(this.listTestCodes);
            this.Controls.Add(this.btnTestScreen);
            this.Controls.Add(this.numericHeight);
            this.Controls.Add(this.numericWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Name = "Form1";
            this.Text = "TelnetHost";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Button btnTestScreen;
        private System.Windows.Forms.ListBox listTestCodes;
        private System.Windows.Forms.Button btnSendCode;
        private System.Windows.Forms.Button btnSendTest;
        private System.Windows.Forms.ListBox listBoxTestScreens;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
    }
}


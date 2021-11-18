
namespace PushMyShip
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
            this.components = new System.ComponentModel.Container();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.bgwHostProcess = new System.ComponentModel.BackgroundWorker();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nnudSpeed = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudDesiredSpeed = new CommonToolLib.UI.NamedNumericUpDown();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHost
            // 
            this.btnHost.Location = new System.Drawing.Point(12, 41);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(75, 23);
            this.btnHost.TabIndex = 0;
            this.btnHost.Text = "Host";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(93, 15);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 2;
            // 
            // bgwHostProcess
            // 
            this.bgwHostProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHostProcess_DoWork);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(181, 368);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nnudSpeed
            // 
            this.nnudSpeed.Location = new System.Drawing.Point(199, 70);
            this.nnudSpeed.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nnudSpeed.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudSpeed.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nnudSpeed.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudSpeed.Name = "nnudSpeed";
            this.nnudSpeed.Size = new System.Drawing.Size(146, 50);
            this.nnudSpeed.TabIndex = 4;
            this.nnudSpeed.Title = "Speed";
            this.nnudSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudDesiredSpeed
            // 
            this.nnudDesiredSpeed.Location = new System.Drawing.Point(199, 126);
            this.nnudDesiredSpeed.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nnudDesiredSpeed.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudDesiredSpeed.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nnudDesiredSpeed.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudDesiredSpeed.Name = "nnudDesiredSpeed";
            this.nnudDesiredSpeed.Size = new System.Drawing.Size(146, 50);
            this.nnudDesiredSpeed.TabIndex = 5;
            this.nnudDesiredSpeed.Title = "Desired Speed";
            this.nnudDesiredSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(199, 182);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(146, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 465);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.nnudDesiredSpeed);
            this.Controls.Add(this.nnudSpeed);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnHost);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.ComponentModel.BackgroundWorker bgwHostProcess;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private CommonToolLib.UI.NamedNumericUpDown nnudSpeed;
        private CommonToolLib.UI.NamedNumericUpDown nnudDesiredSpeed;
        private System.Windows.Forms.Button btnSend;
    }
}


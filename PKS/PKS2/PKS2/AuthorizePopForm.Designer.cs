namespace PKS2
{
    partial class AuthorizePopForm
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
            this.tbPopPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPopHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSmtpPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSmtpHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bConfirm = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmailAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPopPort
            // 
            this.tbPopPort.Location = new System.Drawing.Point(243, 218);
            this.tbPopPort.Name = "tbPopPort";
            this.tbPopPort.Size = new System.Drawing.Size(195, 27);
            this.tbPopPort.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "POP3 порт";
            // 
            // tbPopHost
            // 
            this.tbPopHost.Location = new System.Drawing.Point(243, 165);
            this.tbPopHost.Name = "tbPopHost";
            this.tbPopHost.Size = new System.Drawing.Size(195, 27);
            this.tbPopHost.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "POP3 хост";
            // 
            // tbSmtpPort
            // 
            this.tbSmtpPort.Location = new System.Drawing.Point(42, 218);
            this.tbSmtpPort.Name = "tbSmtpPort";
            this.tbSmtpPort.Size = new System.Drawing.Size(195, 27);
            this.tbSmtpPort.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "SMTP порт";
            // 
            // tbSmtpHost
            // 
            this.tbSmtpHost.Location = new System.Drawing.Point(42, 165);
            this.tbSmtpHost.Name = "tbSmtpHost";
            this.tbSmtpHost.Size = new System.Drawing.Size(195, 27);
            this.tbSmtpHost.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "SMTP хост";
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(154, 265);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(171, 34);
            this.bConfirm.TabIndex = 30;
            this.bConfirm.Text = "Подтвердить";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(42, 112);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(396, 27);
            this.tbPassword.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Пароль";
            // 
            // tbEmailAddress
            // 
            this.tbEmailAddress.Location = new System.Drawing.Point(42, 59);
            this.tbEmailAddress.Name = "tbEmailAddress";
            this.tbEmailAddress.Size = new System.Drawing.Size(396, 27);
            this.tbEmailAddress.TabIndex = 27;
            this.tbEmailAddress.Leave += new System.EventHandler(this.tbEmailAddress_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Почтовый адрес";
            // 
            // AuthorizePopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 335);
            this.Controls.Add(this.tbPopPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPopHost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSmtpPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSmtpHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmailAddress);
            this.Controls.Add(this.label1);
            this.Name = "AuthorizePopForm";
            this.Text = "AuthorizePopForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbPopPort;
        private Label label5;
        private TextBox tbPopHost;
        private Label label6;
        private TextBox tbSmtpPort;
        private Label label4;
        private TextBox tbSmtpHost;
        private Label label3;
        private Button bConfirm;
        private TextBox tbPassword;
        private Label label2;
        private TextBox tbEmailAddress;
        private Label label1;
    }
}
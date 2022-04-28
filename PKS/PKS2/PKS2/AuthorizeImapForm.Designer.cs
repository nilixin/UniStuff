namespace PKS2
{
    partial class AuthorizeImapForm
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
            this.tbImapPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbImapHost = new System.Windows.Forms.TextBox();
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
            // tbImapPort
            // 
            this.tbImapPort.Location = new System.Drawing.Point(241, 219);
            this.tbImapPort.Name = "tbImapPort";
            this.tbImapPort.Size = new System.Drawing.Size(195, 27);
            this.tbImapPort.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "IMAP порт";
            // 
            // tbImapHost
            // 
            this.tbImapHost.Location = new System.Drawing.Point(241, 166);
            this.tbImapHost.Name = "tbImapHost";
            this.tbImapHost.Size = new System.Drawing.Size(195, 27);
            this.tbImapHost.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "IMAP хост";
            // 
            // tbSmtpPort
            // 
            this.tbSmtpPort.Location = new System.Drawing.Point(40, 219);
            this.tbSmtpPort.Name = "tbSmtpPort";
            this.tbSmtpPort.Size = new System.Drawing.Size(195, 27);
            this.tbSmtpPort.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "SMTP порт";
            // 
            // tbSmtpHost
            // 
            this.tbSmtpHost.Location = new System.Drawing.Point(40, 166);
            this.tbSmtpHost.Name = "tbSmtpHost";
            this.tbSmtpHost.Size = new System.Drawing.Size(195, 27);
            this.tbSmtpHost.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "SMTP хост";
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(152, 266);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(171, 34);
            this.bConfirm.TabIndex = 17;
            this.bConfirm.Text = "Подтвердить";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(40, 113);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(396, 27);
            this.tbPassword.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Пароль";
            // 
            // tbEmailAddress
            // 
            this.tbEmailAddress.Location = new System.Drawing.Point(40, 60);
            this.tbEmailAddress.Name = "tbEmailAddress";
            this.tbEmailAddress.Size = new System.Drawing.Size(396, 27);
            this.tbEmailAddress.TabIndex = 14;
            this.tbEmailAddress.Leave += new System.EventHandler(this.tbEmailAddress_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Почтовый адрес";
            // 
            // AuthorizeImapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 335);
            this.Controls.Add(this.tbImapPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbImapHost);
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
            this.Name = "AuthorizeImapForm";
            this.Text = "AuthorizeImapForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbImapPort;
        private Label label5;
        private TextBox tbImapHost;
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
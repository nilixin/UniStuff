namespace v3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.lServerIP = new System.Windows.Forms.Label();
            this.bDownload = new System.Windows.Forms.Button();
            this.bUpload = new System.Windows.Forms.Button();
            this.bChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLocalFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(12, 48);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(312, 27);
            this.tbServerIp.TabIndex = 0;
            // 
            // lServerIP
            // 
            this.lServerIP.AutoSize = true;
            this.lServerIP.Location = new System.Drawing.Point(12, 25);
            this.lServerIP.Name = "lServerIP";
            this.lServerIP.Size = new System.Drawing.Size(82, 20);
            this.lServerIP.TabIndex = 1;
            this.lServerIP.Text = "IP сервера";
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(12, 203);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(120, 29);
            this.bDownload.TabIndex = 2;
            this.bDownload.Text = "Скачать";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // bUpload
            // 
            this.bUpload.Location = new System.Drawing.Point(204, 203);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(120, 29);
            this.bUpload.TabIndex = 3;
            this.bUpload.Text = "Загрузить";
            this.bUpload.UseVisualStyleBackColor = true;
            this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
            // 
            // bChoose
            // 
            this.bChoose.Location = new System.Drawing.Point(230, 153);
            this.bChoose.Name = "bChoose";
            this.bChoose.Size = new System.Drawing.Size(94, 29);
            this.bChoose.TabIndex = 4;
            this.bChoose.Text = "Обзор";
            this.bChoose.UseVisualStyleBackColor = true;
            this.bChoose.Click += new System.EventHandler(this.bChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Локальная папка";
            // 
            // tbLocalFolder
            // 
            this.tbLocalFolder.Location = new System.Drawing.Point(12, 154);
            this.tbLocalFolder.Name = "tbLocalFolder";
            this.tbLocalFolder.Size = new System.Drawing.Size(212, 27);
            this.tbLocalFolder.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название файла";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 101);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(312, 27);
            this.tbFileName.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLocalFolder);
            this.Controls.Add(this.bChoose);
            this.Controls.Add(this.bUpload);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.lServerIP);
            this.Controls.Add(this.tbServerIp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label lServerIP;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.Button bChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocalFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileName;
    }
}

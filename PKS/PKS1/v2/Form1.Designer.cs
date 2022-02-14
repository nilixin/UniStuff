using System;
using System.Windows.Forms;

namespace v2
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
            this.components = new System.ComponentModel.Container();
            this.tbFtpUrl = new System.Windows.Forms.TextBox();
            this.tbFtpUsername = new System.Windows.Forms.TextBox();
            this.tbFtpPassword = new System.Windows.Forms.TextBox();
            this.bFtpConnect = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.bRemoteHome = new System.Windows.Forms.Button();
            this.bLocalHome = new System.Windows.Forms.Button();
            this.bNewRemoteFolder = new System.Windows.Forms.Button();
            this.bNewRemoteFile = new System.Windows.Forms.Button();
            this.bDownload = new System.Windows.Forms.Button();
            this.bUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lFtpConnectionStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lServer = new System.Windows.Forms.Label();
            this.lvRemote = new System.Windows.Forms.ListView();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.bRemoteRefresh = new System.Windows.Forms.Button();
            this.bLocalRefresh = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bTftpUpload = new System.Windows.Forms.Button();
            this.bTftpDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFtpUrl
            // 
            this.tbFtpUrl.Location = new System.Drawing.Point(12, 32);
            this.tbFtpUrl.Name = "tbFtpUrl";
            this.tbFtpUrl.Size = new System.Drawing.Size(179, 27);
            this.tbFtpUrl.TabIndex = 0;
            // 
            // tbFtpUsername
            // 
            this.tbFtpUsername.Location = new System.Drawing.Point(197, 32);
            this.tbFtpUsername.Name = "tbFtpUsername";
            this.tbFtpUsername.Size = new System.Drawing.Size(179, 27);
            this.tbFtpUsername.TabIndex = 1;
            // 
            // tbFtpPassword
            // 
            this.tbFtpPassword.Location = new System.Drawing.Point(382, 32);
            this.tbFtpPassword.Name = "tbFtpPassword";
            this.tbFtpPassword.Size = new System.Drawing.Size(179, 27);
            this.tbFtpPassword.TabIndex = 2;
            // 
            // bFtpConnect
            // 
            this.bFtpConnect.Location = new System.Drawing.Point(567, 30);
            this.bFtpConnect.Name = "bFtpConnect";
            this.bFtpConnect.Size = new System.Drawing.Size(132, 29);
            this.bFtpConnect.TabIndex = 3;
            this.bFtpConnect.Text = "Подключиться";
            this.bFtpConnect.UseVisualStyleBackColor = true;
            this.bFtpConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(705, 30);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(112, 29);
            this.bReset.TabIndex = 4;
            this.bReset.Text = "Сбросить";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bRemoteHome
            // 
            this.bRemoteHome.Location = new System.Drawing.Point(72, 369);
            this.bRemoteHome.Name = "bRemoteHome";
            this.bRemoteHome.Size = new System.Drawing.Size(54, 29);
            this.bRemoteHome.TabIndex = 6;
            this.bRemoteHome.Text = "🏠";
            this.bRemoteHome.UseVisualStyleBackColor = true;
            this.bRemoteHome.Click += new System.EventHandler(this.bRemoteHome_Click);
            // 
            // bLocalHome
            // 
            this.bLocalHome.Location = new System.Drawing.Point(808, 369);
            this.bLocalHome.Name = "bLocalHome";
            this.bLocalHome.Size = new System.Drawing.Size(54, 29);
            this.bLocalHome.TabIndex = 11;
            this.bLocalHome.Text = "🏠";
            this.bLocalHome.UseVisualStyleBackColor = true;
            this.bLocalHome.Click += new System.EventHandler(this.bLocalHome_Click);
            // 
            // bNewRemoteFolder
            // 
            this.bNewRemoteFolder.Location = new System.Drawing.Point(132, 369);
            this.bNewRemoteFolder.Name = "bNewRemoteFolder";
            this.bNewRemoteFolder.Size = new System.Drawing.Size(54, 29);
            this.bNewRemoteFolder.TabIndex = 8;
            this.bNewRemoteFolder.Text = "📁";
            this.bNewRemoteFolder.UseVisualStyleBackColor = true;
            this.bNewRemoteFolder.Click += new System.EventHandler(this.bNewRemoteFolder_Click);
            // 
            // bNewRemoteFile
            // 
            this.bNewRemoteFile.Location = new System.Drawing.Point(192, 369);
            this.bNewRemoteFile.Name = "bNewRemoteFile";
            this.bNewRemoteFile.Size = new System.Drawing.Size(54, 29);
            this.bNewRemoteFile.TabIndex = 9;
            this.bNewRemoteFile.Text = "📜";
            this.bNewRemoteFile.UseVisualStyleBackColor = true;
            this.bNewRemoteFile.Click += new System.EventHandler(this.bNewRemoteFile_Click);
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(410, 140);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(54, 29);
            this.bDownload.TabIndex = 7;
            this.bDownload.Text = "▶️";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // bUpload
            // 
            this.bUpload.Location = new System.Drawing.Point(410, 175);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(54, 29);
            this.bUpload.TabIndex = 12;
            this.bUpload.Text = "◀️";
            this.bUpload.UseVisualStyleBackColor = true;
            this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // lFtpConnectionStatus
            // 
            this.lFtpConnectionStatus.AutoSize = true;
            this.lFtpConnectionStatus.Location = new System.Drawing.Point(12, 62);
            this.lFtpConnectionStatus.Name = "lFtpConnectionStatus";
            this.lFtpConnectionStatus.Size = new System.Drawing.Size(149, 20);
            this.lFtpConnectionStatus.TabIndex = 5;
            this.lFtpConnectionStatus.Text = "lFtpConnectionStatus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Файлы на сервере";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Локальные файлы";
            // 
            // lServer
            // 
            this.lServer.AutoSize = true;
            this.lServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lServer.Location = new System.Drawing.Point(12, 9);
            this.lServer.Name = "lServer";
            this.lServer.Size = new System.Drawing.Size(35, 20);
            this.lServer.TabIndex = 12;
            this.lServer.Text = "FTP";
            // 
            // lvRemote
            // 
            this.lvRemote.HideSelection = false;
            this.lvRemote.LabelEdit = true;
            this.lvRemote.Location = new System.Drawing.Point(12, 140);
            this.lvRemote.MultiSelect = false;
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(392, 224);
            this.lvRemote.TabIndex = 5;
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.DoubleClick += new System.EventHandler(this.lvRemote_DoubleClick);
            // 
            // lvLocal
            // 
            this.lvLocal.HideSelection = false;
            this.lvLocal.LabelEdit = true;
            this.lvLocal.Location = new System.Drawing.Point(470, 140);
            this.lvLocal.MultiSelect = false;
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(392, 224);
            this.lvLocal.TabIndex = 10;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.DoubleClick += new System.EventHandler(this.lvLocal_DoubleClick);
            // 
            // bRemoteRefresh
            // 
            this.bRemoteRefresh.Location = new System.Drawing.Point(12, 369);
            this.bRemoteRefresh.Name = "bRemoteRefresh";
            this.bRemoteRefresh.Size = new System.Drawing.Size(54, 29);
            this.bRemoteRefresh.TabIndex = 15;
            this.bRemoteRefresh.Text = "🔁";
            this.bRemoteRefresh.UseVisualStyleBackColor = true;
            this.bRemoteRefresh.Click += new System.EventHandler(this.bRemoteRefresh_Click);
            // 
            // bLocalRefresh
            // 
            this.bLocalRefresh.Location = new System.Drawing.Point(748, 369);
            this.bLocalRefresh.Name = "bLocalRefresh";
            this.bLocalRefresh.Size = new System.Drawing.Size(54, 29);
            this.bLocalRefresh.TabIndex = 16;
            this.bLocalRefresh.Text = "🔁";
            this.bLocalRefresh.UseVisualStyleBackColor = true;
            this.bLocalRefresh.Click += new System.EventHandler(this.bLocalRefresh_Click);
            // 
            // bTftpUpload
            // 
            this.bTftpUpload.Enabled = false;
            this.bTftpUpload.Location = new System.Drawing.Point(410, 335);
            this.bTftpUpload.Name = "bTftpUpload";
            this.bTftpUpload.Size = new System.Drawing.Size(54, 29);
            this.bTftpUpload.TabIndex = 18;
            this.bTftpUpload.Text = "T ◀️";
            this.bTftpUpload.UseVisualStyleBackColor = true;
            // 
            // bTftpDownload
            // 
            this.bTftpDownload.Enabled = false;
            this.bTftpDownload.Location = new System.Drawing.Point(410, 300);
            this.bTftpDownload.Name = "bTftpDownload";
            this.bTftpDownload.Size = new System.Drawing.Size(54, 29);
            this.bTftpDownload.TabIndex = 17;
            this.bTftpDownload.Text = "T ▶️";
            this.bTftpDownload.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 419);
            this.Controls.Add(this.bTftpUpload);
            this.Controls.Add(this.bTftpDownload);
            this.Controls.Add(this.bLocalRefresh);
            this.Controls.Add(this.bRemoteRefresh);
            this.Controls.Add(this.bNewRemoteFile);
            this.Controls.Add(this.bNewRemoteFolder);
            this.Controls.Add(this.bLocalHome);
            this.Controls.Add(this.bRemoteHome);
            this.Controls.Add(this.lvLocal);
            this.Controls.Add(this.lvRemote);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.tbFtpUrl);
            this.Controls.Add(this.lServer);
            this.Controls.Add(this.bUpload);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lFtpConnectionStatus);
            this.Controls.Add(this.bFtpConnect);
            this.Controls.Add(this.tbFtpPassword);
            this.Controls.Add(this.tbFtpUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFtpUrl;
        private System.Windows.Forms.TextBox tbFtpUsername;
        private System.Windows.Forms.TextBox tbFtpPassword;
        private System.Windows.Forms.Button bFtpConnect;
        private System.Windows.Forms.Label lFtpConnectionStatus;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lServer;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.Button bRemoteHome;
        private System.Windows.Forms.Button bLocalHome;
        private System.Windows.Forms.Button bNewRemoteFolder;
        private System.Windows.Forms.Button bNewRemoteFile;
        private System.Windows.Forms.Button bRemoteRefresh;
        private System.Windows.Forms.Button bLocalRefresh;
        private ToolTip toolTip;
        private Button bTftpUpload;
        private Button bTftpDownload;
    }
}

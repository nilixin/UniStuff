namespace PKS2
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSent = new System.Windows.Forms.TabPage();
            this.lAttachmentStatus = new System.Windows.Forms.Label();
            this.bAttach = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRecipientAddress = new System.Windows.Forms.TextBox();
            this.tabPageReceived = new System.Windows.Forms.TabPage();
            this.dgvInboxMessages = new System.Windows.Forms.DataGridView();
            this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.bAuthorize = new System.Windows.Forms.Button();
            this.lUserEmailAddress = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bAuthorizePop = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageSent.SuspendLayout();
            this.tabPageReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboxMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSent);
            this.tabControl1.Controls.Add(this.tabPageReceived);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 456);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSent
            // 
            this.tabPageSent.Controls.Add(this.lAttachmentStatus);
            this.tabPageSent.Controls.Add(this.bAttach);
            this.tabPageSent.Controls.Add(this.bSend);
            this.tabPageSent.Controls.Add(this.label4);
            this.tabPageSent.Controls.Add(this.tbBody);
            this.tabPageSent.Controls.Add(this.label3);
            this.tabPageSent.Controls.Add(this.tbSubject);
            this.tabPageSent.Controls.Add(this.label2);
            this.tabPageSent.Controls.Add(this.tbRecipientAddress);
            this.tabPageSent.Location = new System.Drawing.Point(4, 29);
            this.tabPageSent.Name = "tabPageSent";
            this.tabPageSent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSent.Size = new System.Drawing.Size(768, 423);
            this.tabPageSent.TabIndex = 0;
            this.tabPageSent.Text = "Отправленные";
            this.tabPageSent.UseVisualStyleBackColor = true;
            // 
            // lAttachmentStatus
            // 
            this.lAttachmentStatus.AutoSize = true;
            this.lAttachmentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lAttachmentStatus.Location = new System.Drawing.Point(614, 356);
            this.lAttachmentStatus.Name = "lAttachmentStatus";
            this.lAttachmentStatus.Size = new System.Drawing.Size(0, 28);
            this.lAttachmentStatus.TabIndex = 10;
            // 
            // bAttach
            // 
            this.bAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAttach.Location = new System.Drawing.Point(647, 383);
            this.bAttach.Name = "bAttach";
            this.bAttach.Size = new System.Drawing.Size(115, 34);
            this.bAttach.TabIndex = 9;
            this.bAttach.Text = "Вложить";
            this.bAttach.UseVisualStyleBackColor = true;
            this.bAttach.Click += new System.EventHandler(this.bAttach_Click);
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSend.Location = new System.Drawing.Point(6, 383);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(175, 34);
            this.bSend.TabIndex = 8;
            this.bSend.Text = "Отправить";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сообщение";
            // 
            // tbBody
            // 
            this.tbBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBody.Location = new System.Drawing.Point(6, 132);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBody.Size = new System.Drawing.Size(756, 245);
            this.tbBody.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тема";
            // 
            // tbSubject
            // 
            this.tbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubject.Location = new System.Drawing.Point(6, 79);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(756, 27);
            this.tbSubject.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес получателя";
            // 
            // tbRecipientAddress
            // 
            this.tbRecipientAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecipientAddress.Location = new System.Drawing.Point(6, 26);
            this.tbRecipientAddress.Name = "tbRecipientAddress";
            this.tbRecipientAddress.Size = new System.Drawing.Size(756, 27);
            this.tbRecipientAddress.TabIndex = 2;
            // 
            // tabPageReceived
            // 
            this.tabPageReceived.Controls.Add(this.dgvInboxMessages);
            this.tabPageReceived.Controls.Add(this.label6);
            this.tabPageReceived.Location = new System.Drawing.Point(4, 29);
            this.tabPageReceived.Name = "tabPageReceived";
            this.tabPageReceived.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReceived.Size = new System.Drawing.Size(768, 423);
            this.tabPageReceived.TabIndex = 1;
            this.tabPageReceived.Text = "Полученные";
            this.tabPageReceived.UseVisualStyleBackColor = true;
            // 
            // dgvInboxMessages
            // 
            this.dgvInboxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInboxMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInboxMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFrom,
            this.ColumnDate,
            this.ColumnSubject});
            this.dgvInboxMessages.Location = new System.Drawing.Point(6, 26);
            this.dgvInboxMessages.MultiSelect = false;
            this.dgvInboxMessages.Name = "dgvInboxMessages";
            this.dgvInboxMessages.RowHeadersWidth = 51;
            this.dgvInboxMessages.RowTemplate.Height = 29;
            this.dgvInboxMessages.Size = new System.Drawing.Size(756, 364);
            this.dgvInboxMessages.TabIndex = 7;
            this.dgvInboxMessages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInboxMessages_CellClick);
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.HeaderText = "Отправитель";
            this.ColumnFrom.MinimumWidth = 6;
            this.ColumnFrom.Name = "ColumnFrom";
            this.ColumnFrom.Width = 125;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Дата";
            this.ColumnDate.MinimumWidth = 6;
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Width = 125;
            // 
            // ColumnSubject
            // 
            this.ColumnSubject.HeaderText = "Тема";
            this.ColumnSubject.MinimumWidth = 6;
            this.ColumnSubject.Name = "ColumnSubject";
            this.ColumnSubject.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Письма";
            // 
            // bAuthorize
            // 
            this.bAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAuthorize.Location = new System.Drawing.Point(342, 12);
            this.bAuthorize.Name = "bAuthorize";
            this.bAuthorize.Size = new System.Drawing.Size(220, 34);
            this.bAuthorize.TabIndex = 9;
            this.bAuthorize.Text = "Авторизация (SMTP/IMAP)";
            this.bAuthorize.UseVisualStyleBackColor = true;
            this.bAuthorize.Click += new System.EventHandler(this.bAuthorize_Click);
            // 
            // lUserEmailAddress
            // 
            this.lUserEmailAddress.AutoSize = true;
            this.lUserEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lUserEmailAddress.Location = new System.Drawing.Point(22, 9);
            this.lUserEmailAddress.Name = "lUserEmailAddress";
            this.lUserEmailAddress.Size = new System.Drawing.Size(55, 28);
            this.lUserEmailAddress.TabIndex = 9;
            this.lUserEmailAddress.Text = "NaN";
            // 
            // bAuthorizePop
            // 
            this.bAuthorizePop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAuthorizePop.Location = new System.Drawing.Point(568, 12);
            this.bAuthorizePop.Name = "bAuthorizePop";
            this.bAuthorizePop.Size = new System.Drawing.Size(220, 34);
            this.bAuthorizePop.TabIndex = 10;
            this.bAuthorizePop.Text = "Авторизация (POP3)";
            this.bAuthorizePop.UseVisualStyleBackColor = true;
            this.bAuthorizePop.Click += new System.EventHandler(this.bAuthorizePop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.bAuthorizePop);
            this.Controls.Add(this.lUserEmailAddress);
            this.Controls.Add(this.bAuthorize);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(818, 492);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSent.ResumeLayout(false);
            this.tabPageSent.PerformLayout();
            this.tabPageReceived.ResumeLayout(false);
            this.tabPageReceived.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInboxMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageSent;
        private Button bSend;
        private Label label4;
        private TextBox tbBody;
        private Label label3;
        private TextBox tbSubject;
        private Label label2;
        private TextBox tbRecipientAddress;
        private TabPage tabPageReceived;
        private Button bAuthorize;
        private Label lUserEmailAddress;
        private Button bAttach;
        private Label lAttachmentStatus;
        private Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dgvInboxMessages;
        private DataGridViewTextBoxColumn ColumnFrom;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnSubject;
        private Button bAuthorizePop;
    }
}
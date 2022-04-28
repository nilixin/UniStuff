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
            this.bAuthorize = new System.Windows.Forms.Button();
            this.cbChosenProtocols = new System.Windows.Forms.ComboBox();
            this.dgvInbox = new System.Windows.Forms.DataGridView();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lConnection = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.bPin = new System.Windows.Forms.Button();
            this.lPinnedStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // bAuthorize
            // 
            this.bAuthorize.Location = new System.Drawing.Point(253, 12);
            this.bAuthorize.Name = "bAuthorize";
            this.bAuthorize.Size = new System.Drawing.Size(242, 29);
            this.bAuthorize.TabIndex = 0;
            this.bAuthorize.Text = "Авторизация";
            this.bAuthorize.UseVisualStyleBackColor = true;
            this.bAuthorize.Click += new System.EventHandler(this.bAuthorize_Click);
            // 
            // cbChosenProtocols
            // 
            this.cbChosenProtocols.FormattingEnabled = true;
            this.cbChosenProtocols.Items.AddRange(new object[] {
            "SMTP - IMAP",
            "SMTP - POP3"});
            this.cbChosenProtocols.Location = new System.Drawing.Point(12, 12);
            this.cbChosenProtocols.Name = "cbChosenProtocols";
            this.cbChosenProtocols.Size = new System.Drawing.Size(235, 28);
            this.cbChosenProtocols.TabIndex = 1;
            // 
            // dgvInbox
            // 
            this.dgvInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInbox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.From,
            this.Date,
            this.Subject});
            this.dgvInbox.Location = new System.Drawing.Point(12, 123);
            this.dgvInbox.Name = "dgvInbox";
            this.dgvInbox.RowHeadersWidth = 51;
            this.dgvInbox.RowTemplate.Height = 29;
            this.dgvInbox.Size = new System.Drawing.Size(483, 492);
            this.dgvInbox.TabIndex = 2;
            this.dgvInbox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInbox_CellClick);
            // 
            // From
            // 
            this.From.HeaderText = "Отправитель";
            this.From.MinimumWidth = 6;
            this.From.Name = "From";
            this.From.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.Width = 125;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Тема";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Просмотр входящих";
            // 
            // lConnection
            // 
            this.lConnection.AutoSize = true;
            this.lConnection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lConnection.Location = new System.Drawing.Point(501, 12);
            this.lConnection.Name = "lConnection";
            this.lConnection.Size = new System.Drawing.Size(67, 28);
            this.lConnection.TabIndex = 4;
            this.lConnection.Text = "string";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(501, 123);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(483, 27);
            this.tbTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(501, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отправление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Кому";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Тема";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(501, 176);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(483, 27);
            this.tbSubject.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Тело письма";
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(501, 229);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBody.Size = new System.Drawing.Size(483, 351);
            this.tbBody.TabIndex = 10;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(501, 586);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(138, 29);
            this.bSend.TabIndex = 12;
            this.bSend.Text = "Отправить";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bPin
            // 
            this.bPin.Location = new System.Drawing.Point(645, 586);
            this.bPin.Name = "bPin";
            this.bPin.Size = new System.Drawing.Size(138, 29);
            this.bPin.TabIndex = 13;
            this.bPin.Text = "Вложить";
            this.bPin.UseVisualStyleBackColor = true;
            this.bPin.Click += new System.EventHandler(this.bPin_Click);
            // 
            // lPinnedStatus
            // 
            this.lPinnedStatus.AutoSize = true;
            this.lPinnedStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lPinnedStatus.Location = new System.Drawing.Point(789, 587);
            this.lPinnedStatus.Name = "lPinnedStatus";
            this.lPinnedStatus.Size = new System.Drawing.Size(67, 28);
            this.lPinnedStatus.TabIndex = 14;
            this.lPinnedStatus.Text = "string";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 627);
            this.Controls.Add(this.lPinnedStatus);
            this.Controls.Add(this.bPin);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.lConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInbox);
            this.Controls.Add(this.cbChosenProtocols);
            this.Controls.Add(this.bAuthorize);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bAuthorize;
        private ComboBox cbChosenProtocols;
        private DataGridView dgvInbox;
        private Label label1;
        private Label lConnection;
        private TextBox tbTo;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tbSubject;
        private Label label6;
        private TextBox tbBody;
        private Button bSend;
        private Button bPin;
        private Label lPinnedStatus;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Subject;
    }
}
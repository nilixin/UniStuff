namespace PKS2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSent = new System.Windows.Forms.TabPage();
            this.bSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRecipientAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSentMessages = new System.Windows.Forms.TextBox();
            this.tabPageReceived = new System.Windows.Forms.TabPage();
            this.bAuthorize = new System.Windows.Forms.Button();
            this.lUserEmailAddress = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьИмяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageSent.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPageSent);
            this.tabControl1.Controls.Add(this.tabPageReceived);
            this.tabControl1.Location = new System.Drawing.Point(12, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSent
            // 
            this.tabPageSent.Controls.Add(this.bSend);
            this.tabPageSent.Controls.Add(this.label4);
            this.tabPageSent.Controls.Add(this.tbBody);
            this.tabPageSent.Controls.Add(this.label3);
            this.tabPageSent.Controls.Add(this.tbSubject);
            this.tabPageSent.Controls.Add(this.label2);
            this.tabPageSent.Controls.Add(this.tbRecipientAddress);
            this.tabPageSent.Controls.Add(this.label1);
            this.tabPageSent.Controls.Add(this.tbSentMessages);
            this.tabPageSent.Location = new System.Drawing.Point(4, 29);
            this.tabPageSent.Name = "tabPageSent";
            this.tabPageSent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSent.Size = new System.Drawing.Size(768, 396);
            this.tabPageSent.TabIndex = 0;
            this.tabPageSent.Text = "Отправленные";
            this.tabPageSent.UseVisualStyleBackColor = true;
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSend.Location = new System.Drawing.Point(647, 356);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(115, 34);
            this.bSend.TabIndex = 8;
            this.bSend.Text = "Отправить";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сообщение";
            // 
            // tbBody
            // 
            this.tbBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBody.Location = new System.Drawing.Point(227, 132);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBody.Size = new System.Drawing.Size(535, 218);
            this.tbBody.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тема";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(227, 79);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(535, 27);
            this.tbSubject.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес получателя";
            // 
            // tbRecipientAddress
            // 
            this.tbRecipientAddress.Location = new System.Drawing.Point(227, 26);
            this.tbRecipientAddress.Name = "tbRecipientAddress";
            this.tbRecipientAddress.Size = new System.Drawing.Size(535, 27);
            this.tbRecipientAddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отправленные сообщения";
            // 
            // tbSentMessages
            // 
            this.tbSentMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSentMessages.Location = new System.Drawing.Point(6, 26);
            this.tbSentMessages.Multiline = true;
            this.tbSentMessages.Name = "tbSentMessages";
            this.tbSentMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSentMessages.Size = new System.Drawing.Size(215, 364);
            this.tbSentMessages.TabIndex = 0;
            // 
            // tabPageReceived
            // 
            this.tabPageReceived.Location = new System.Drawing.Point(4, 29);
            this.tabPageReceived.Name = "tabPageReceived";
            this.tabPageReceived.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReceived.Size = new System.Drawing.Size(768, 396);
            this.tabPageReceived.TabIndex = 1;
            this.tabPageReceived.Text = "Полученные";
            this.tabPageReceived.UseVisualStyleBackColor = true;
            // 
            // bAuthorize
            // 
            this.bAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAuthorize.Location = new System.Drawing.Point(620, 31);
            this.bAuthorize.Name = "bAuthorize";
            this.bAuthorize.Size = new System.Drawing.Size(164, 34);
            this.bAuthorize.TabIndex = 9;
            this.bAuthorize.Text = "Авторизироваться";
            this.bAuthorize.UseVisualStyleBackColor = true;
            this.bAuthorize.Click += new System.EventHandler(this.bAuthorize_Click);
            // 
            // lUserEmailAddress
            // 
            this.lUserEmailAddress.AutoSize = true;
            this.lUserEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lUserEmailAddress.Location = new System.Drawing.Point(22, 28);
            this.lUserEmailAddress.Name = "lUserEmailAddress";
            this.lUserEmailAddress.Size = new System.Drawing.Size(55, 28);
            this.lUserEmailAddress.TabIndex = 9;
            this.lUserEmailAddress.Text = "NaN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настроитьИмяToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // настроитьИмяToolStripMenuItem
            // 
            this.настроитьИмяToolStripMenuItem.Name = "настроитьИмяToolStripMenuItem";
            this.настроитьИмяToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.настроитьИмяToolStripMenuItem.Text = "Настроить имя";
            this.настроитьИмяToolStripMenuItem.Click += new System.EventHandler(this.настроитьИмяToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.lUserEmailAddress);
            this.Controls.Add(this.bAuthorize);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(818, 492);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSent.ResumeLayout(false);
            this.tabPageSent.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private Label label1;
        private TextBox tbSentMessages;
        private TabPage tabPageReceived;
        private Button bAuthorize;
        private Label lUserEmailAddress;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem параметрыToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem настроитьИмяToolStripMenuItem;
    }
}
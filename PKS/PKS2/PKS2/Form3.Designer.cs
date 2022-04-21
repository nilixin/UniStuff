namespace PKS2
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSourceAddress = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.wvBody = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvBody)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отправитель";
            // 
            // tbSourceAddress
            // 
            this.tbSourceAddress.Location = new System.Drawing.Point(12, 32);
            this.tbSourceAddress.Name = "tbSourceAddress";
            this.tbSourceAddress.Size = new System.Drawing.Size(298, 27);
            this.tbSourceAddress.TabIndex = 1;
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(12, 85);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(298, 27);
            this.tbSubject.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тема";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 547);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Вложенные файлы";
            // 
            // lvAttachments
            // 
            this.lvAttachments.Location = new System.Drawing.Point(12, 570);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(298, 146);
            this.lvAttachments.TabIndex = 8;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.Tile;
            this.lvAttachments.Click += new System.EventHandler(this.lvAttachments_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lInfo);
            this.panel1.Location = new System.Drawing.Point(12, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 406);
            this.panel1.TabIndex = 9;
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Location = new System.Drawing.Point(3, 7);
            this.lInfo.MaximumSize = new System.Drawing.Size(300, 400);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(39, 20);
            this.lInfo.TabIndex = 11;
            this.lInfo.Text = "NaN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Свойства";
            // 
            // wvBody
            // 
            this.wvBody.AllowExternalDrop = true;
            this.wvBody.CreationProperties = null;
            this.wvBody.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvBody.Location = new System.Drawing.Point(316, 12);
            this.wvBody.Name = "wvBody";
            this.wvBody.Size = new System.Drawing.Size(687, 704);
            this.wvBody.TabIndex = 11;
            this.wvBody.ZoomFactor = 1D;
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(316, 12);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBody.Size = new System.Drawing.Size(687, 704);
            this.tbBody.TabIndex = 12;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 728);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.wvBody);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvAttachments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSourceAddress);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbSourceAddress;
        private TextBox tbSubject;
        private Label label2;
        private Label label4;
        private ListView lvAttachments;
        private Panel panel1;
        private Label lInfo;
        private Label label5;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvBody;
        private TextBox tbBody;
    }
}
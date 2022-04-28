namespace PKS2
{
    partial class MessageForm
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
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProperties = new System.Windows.Forms.TextBox();
            this.lvPinned = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.wvBody = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.wvBody)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(12, 32);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(776, 27);
            this.tbFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "От кого";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тема";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(12, 85);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(776, 27);
            this.tbSubject.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тело письма";
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(12, 138);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBody.Size = new System.Drawing.Size(776, 422);
            this.tbBody.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Свойства";
            // 
            // tbProperties
            // 
            this.tbProperties.Location = new System.Drawing.Point(12, 586);
            this.tbProperties.Multiline = true;
            this.tbProperties.Name = "tbProperties";
            this.tbProperties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProperties.Size = new System.Drawing.Size(382, 98);
            this.tbProperties.TabIndex = 6;
            // 
            // lvPinned
            // 
            this.lvPinned.Location = new System.Drawing.Point(400, 586);
            this.lvPinned.MultiSelect = false;
            this.lvPinned.Name = "lvPinned";
            this.lvPinned.Size = new System.Drawing.Size(388, 98);
            this.lvPinned.TabIndex = 8;
            this.lvPinned.UseCompatibleStateImageBehavior = false;
            this.lvPinned.Click += new System.EventHandler(this.lvPinned_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 563);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вложения";
            // 
            // wvBody
            // 
            this.wvBody.AllowExternalDrop = true;
            this.wvBody.CreationProperties = null;
            this.wvBody.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvBody.Location = new System.Drawing.Point(12, 138);
            this.wvBody.Name = "wvBody";
            this.wvBody.Size = new System.Drawing.Size(776, 422);
            this.wvBody.TabIndex = 10;
            this.wvBody.ZoomFactor = 1D;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 696);
            this.Controls.Add(this.wvBody);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvPinned);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbProperties);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFrom);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.wvBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbFrom;
        private Label label1;
        private Label label2;
        private TextBox tbSubject;
        private Label label3;
        private TextBox tbBody;
        private Label label4;
        private TextBox tbProperties;
        private ListView lvPinned;
        private Label label5;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvBody;
    }
}
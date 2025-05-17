namespace HotelBook
{
    partial class AdminPanel
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.addAdminPanel = new System.Windows.Forms.Button();
            this.removeAdminPanel = new System.Windows.Forms.Button();
            this.backAdminPanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(513, 502);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // addAdminPanel
            // 
            this.addAdminPanel.Location = new System.Drawing.Point(644, 65);
            this.addAdminPanel.Name = "addAdminPanel";
            this.addAdminPanel.Size = new System.Drawing.Size(135, 67);
            this.addAdminPanel.TabIndex = 1;
            this.addAdminPanel.Text = "ADD";
            this.addAdminPanel.UseVisualStyleBackColor = true;
            this.addAdminPanel.Click += new System.EventHandler(this.addAdminPanel_Click);
            // 
            // removeAdminPanel
            // 
            this.removeAdminPanel.Location = new System.Drawing.Point(644, 186);
            this.removeAdminPanel.Name = "removeAdminPanel";
            this.removeAdminPanel.Size = new System.Drawing.Size(135, 62);
            this.removeAdminPanel.TabIndex = 2;
            this.removeAdminPanel.Text = "REMOVE";
            this.removeAdminPanel.UseVisualStyleBackColor = true;
            this.removeAdminPanel.Click += new System.EventHandler(this.removeAdminPanel_Click);
            // 
            // backAdminPanel
            // 
            this.backAdminPanel.Location = new System.Drawing.Point(711, 446);
            this.backAdminPanel.Name = "backAdminPanel";
            this.backAdminPanel.Size = new System.Drawing.Size(149, 68);
            this.backAdminPanel.TabIndex = 3;
            this.backAdminPanel.Text = "BACK";
            this.backAdminPanel.UseVisualStyleBackColor = true;
            this.backAdminPanel.Click += new System.EventHandler(this.backAdminPanel_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 526);
            this.Controls.Add(this.backAdminPanel);
            this.Controls.Add(this.removeAdminPanel);
            this.Controls.Add(this.addAdminPanel);
            this.Controls.Add(this.richTextBox1);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button addAdminPanel;
        private System.Windows.Forms.Button removeAdminPanel;
        private System.Windows.Forms.Button backAdminPanel;
    }
}
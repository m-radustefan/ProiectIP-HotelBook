namespace HotelBook
{
    partial class LogIn
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
            this.label2 = new System.Windows.Forms.Label();
            this.loginLogIn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.login_username = new System.Windows.Forms.RichTextBox();
            this.login_pass = new System.Windows.Forms.MaskedTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "PASSWORD";
            // 
            // loginLogIn
            // 
            this.loginLogIn.Location = new System.Drawing.Point(320, 290);
            this.loginLogIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginLogIn.Name = "loginLogIn";
            this.loginLogIn.Size = new System.Drawing.Size(156, 46);
            this.loginLogIn.TabIndex = 6;
            this.loginLogIn.Text = "LOG IN";
            this.loginLogIn.UseVisualStyleBackColor = true;
            this.loginLogIn.Click += new System.EventHandler(this.loginLogIn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 391);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "IESIRE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // login_username
            // 
            this.login_username.Location = new System.Drawing.Point(239, 102);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(334, 27);
            this.login_username.TabIndex = 9;
            this.login_username.Text = "";
            this.login_username.TextChanged += new System.EventHandler(this.login_username_TextChanged);
            // 
            // login_pass
            // 
            this.login_pass.Location = new System.Drawing.Point(239, 191);
            this.login_pass.Name = "login_pass";
            this.login_pass.Size = new System.Drawing.Size(334, 26);
            this.login_pass.TabIndex = 10;
            this.login_pass.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.login_pass_MaskInputRejected);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.despreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 36);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "DespreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(84, 32);
            this.despreToolStripMenuItem.Text = "Despre";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.DespreToolStripMenuItem_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(811, 458);
            this.Controls.Add(this.login_pass);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.loginLogIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginLogIn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox login_username;
        private System.Windows.Forms.MaskedTextBox login_pass;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
    }
}
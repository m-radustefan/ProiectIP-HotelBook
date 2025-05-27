namespace HotelBook
{
    partial class RoomPanel
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
            this.addRoomPanel = new System.Windows.Forms.Button();
            this.backRoomPanel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.removeRoomPanel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.idRoomPanel = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TYPE";
            // 
            // addRoomPanel
            // 
            this.addRoomPanel.Location = new System.Drawing.Point(497, 60);
            this.addRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addRoomPanel.Name = "addRoomPanel";
            this.addRoomPanel.Size = new System.Drawing.Size(130, 44);
            this.addRoomPanel.TabIndex = 1;
            this.addRoomPanel.Text = "ADD";
            this.addRoomPanel.UseVisualStyleBackColor = true;
            this.addRoomPanel.Click += new System.EventHandler(this.addRoomPanel_Click);
            // 
            // backRoomPanel
            // 
            this.backRoomPanel.Location = new System.Drawing.Point(636, 378);
            this.backRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backRoomPanel.Name = "backRoomPanel";
            this.backRoomPanel.Size = new System.Drawing.Size(130, 48);
            this.backRoomPanel.TabIndex = 2;
            this.backRoomPanel.Text = "BACK";
            this.backRoomPanel.UseVisualStyleBackColor = true;
            this.backRoomPanel.Click += new System.EventHandler(this.backRoomPanel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(216, 69);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(170, 32);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "PRICE";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(216, 149);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(170, 32);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // removeRoomPanel
            // 
            this.removeRoomPanel.Location = new System.Drawing.Point(497, 149);
            this.removeRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeRoomPanel.Name = "removeRoomPanel";
            this.removeRoomPanel.Size = new System.Drawing.Size(130, 44);
            this.removeRoomPanel.TabIndex = 6;
            this.removeRoomPanel.Text = "REMOVE";
            this.removeRoomPanel.UseVisualStyleBackColor = true;
            this.removeRoomPanel.Click += new System.EventHandler(this.removeRoomPanel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID";
            // 
            // idRoomPanel
            // 
            this.idRoomPanel.Location = new System.Drawing.Point(216, 221);
            this.idRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idRoomPanel.Name = "idRoomPanel";
            this.idRoomPanel.Size = new System.Drawing.Size(170, 32);
            this.idRoomPanel.TabIndex = 8;
            this.idRoomPanel.Text = "";
            this.idRoomPanel.TextChanged += new System.EventHandler(this.idRoomPanel_TextChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "DespreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.despreToolStripMenuItem.Text = "Despre";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.DespreToolStripMenuItem_Click);
            // 
            // RoomPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idRoomPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeRoomPanel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.backRoomPanel);
            this.Controls.Add(this.addRoomPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomPanel";
            this.Text = "RoomPanel";
            this.Load += new System.EventHandler(this.RoomPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addRoomPanel;
        private System.Windows.Forms.Button backRoomPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button removeRoomPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox idRoomPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
    }
}
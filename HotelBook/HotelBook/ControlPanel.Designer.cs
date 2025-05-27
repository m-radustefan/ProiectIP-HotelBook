namespace HotelBook
{
    partial class ControlPanel
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
            this.bookedControlPanel = new System.Windows.Forms.Button();
            this.checkoutControlPanel = new System.Windows.Forms.Button();
            this.readytobookControlPanel = new System.Windows.Forms.Button();
            this.backControlPanel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookedControlPanel
            // 
            this.bookedControlPanel.Location = new System.Drawing.Point(288, 574);
            this.bookedControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bookedControlPanel.Name = "bookedControlPanel";
            this.bookedControlPanel.Size = new System.Drawing.Size(186, 61);
            this.bookedControlPanel.TabIndex = 1;
            this.bookedControlPanel.Text = "BOOKED";
            this.bookedControlPanel.UseVisualStyleBackColor = true;
            this.bookedControlPanel.Click += new System.EventHandler(this.bookedControlPanel_Click);
            // 
            // checkoutControlPanel
            // 
            this.checkoutControlPanel.Location = new System.Drawing.Point(517, 574);
            this.checkoutControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkoutControlPanel.Name = "checkoutControlPanel";
            this.checkoutControlPanel.Size = new System.Drawing.Size(173, 61);
            this.checkoutControlPanel.TabIndex = 2;
            this.checkoutControlPanel.Text = "CHECK OUT";
            this.checkoutControlPanel.UseVisualStyleBackColor = true;
            this.checkoutControlPanel.Click += new System.EventHandler(this.checkoutControlPanel_Click);
            // 
            // readytobookControlPanel
            // 
            this.readytobookControlPanel.Location = new System.Drawing.Point(728, 574);
            this.readytobookControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.readytobookControlPanel.Name = "readytobookControlPanel";
            this.readytobookControlPanel.Size = new System.Drawing.Size(174, 61);
            this.readytobookControlPanel.TabIndex = 3;
            this.readytobookControlPanel.Text = "READY TO BOOK";
            this.readytobookControlPanel.UseVisualStyleBackColor = true;
            this.readytobookControlPanel.Click += new System.EventHandler(this.readytobookControlPanel_Click);
            // 
            // backControlPanel
            // 
            this.backControlPanel.Location = new System.Drawing.Point(1012, 612);
            this.backControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backControlPanel.Name = "backControlPanel";
            this.backControlPanel.Size = new System.Drawing.Size(151, 60);
            this.backControlPanel.TabIndex = 4;
            this.backControlPanel.Text = "BACK";
            this.backControlPanel.UseVisualStyleBackColor = true;
            this.backControlPanel.Click += new System.EventHandler(this.backControlPanel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 51);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 498);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.menuStrip1.Size = new System.Drawing.Size(1200, 36);
            this.menuStrip1.TabIndex = 6;
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
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.backControlPanel);
            this.Controls.Add(this.readytobookControlPanel);
            this.Controls.Add(this.checkoutControlPanel);
            this.Controls.Add(this.bookedControlPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bookedControlPanel;
        private System.Windows.Forms.Button checkoutControlPanel;
        private System.Windows.Forms.Button readytobookControlPanel;
        private System.Windows.Forms.Button backControlPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
    }
}
namespace HotelBook
{
    partial class Reservation
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
            this.dataGridReservation = new System.Windows.Forms.DataGridView();
            this.backReservation = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridReservation
            // 
            this.dataGridReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservation.Location = new System.Drawing.Point(39, 45);
            this.dataGridReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridReservation.Name = "dataGridReservation";
            this.dataGridReservation.RowHeadersWidth = 62;
            this.dataGridReservation.RowTemplate.Height = 28;
            this.dataGridReservation.Size = new System.Drawing.Size(794, 372);
            this.dataGridReservation.TabIndex = 0;
            this.dataGridReservation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReservation_CellContentClick);
            // 
            // backReservation
            // 
            this.backReservation.Location = new System.Drawing.Point(752, 438);
            this.backReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backReservation.Name = "backReservation";
            this.backReservation.Size = new System.Drawing.Size(112, 56);
            this.backReservation.TabIndex = 1;
            this.backReservation.Text = "BACK";
            this.backReservation.UseVisualStyleBackColor = true;
            this.backReservation.Click += new System.EventHandler(this.backReservation_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(876, 33);
            this.menuStrip1.TabIndex = 2;
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
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(876, 506);
            this.Controls.Add(this.backReservation);
            this.Controls.Add(this.dataGridReservation);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reservation";
            this.Text = "Reservation";
            this.Load += new System.EventHandler(this.Reservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReservation;
        private System.Windows.Forms.Button backReservation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
    }
}
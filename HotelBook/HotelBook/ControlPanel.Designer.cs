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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bookedControlPanel
            // 
            this.bookedControlPanel.Location = new System.Drawing.Point(256, 437);
            this.bookedControlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bookedControlPanel.Name = "bookedControlPanel";
            this.bookedControlPanel.Size = new System.Drawing.Size(165, 49);
            this.bookedControlPanel.TabIndex = 1;
            this.bookedControlPanel.Text = "BOOKED";
            this.bookedControlPanel.UseVisualStyleBackColor = true;
            this.bookedControlPanel.Click += new System.EventHandler(this.bookedControlPanel_Click);
            // 
            // checkoutControlPanel
            // 
            this.checkoutControlPanel.Location = new System.Drawing.Point(464, 437);
            this.checkoutControlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkoutControlPanel.Name = "checkoutControlPanel";
            this.checkoutControlPanel.Size = new System.Drawing.Size(154, 49);
            this.checkoutControlPanel.TabIndex = 2;
            this.checkoutControlPanel.Text = "CHECK OUT";
            this.checkoutControlPanel.UseVisualStyleBackColor = true;
            this.checkoutControlPanel.Click += new System.EventHandler(this.checkoutControlPanel_Click);
            // 
            // readytobookControlPanel
            // 
            this.readytobookControlPanel.Location = new System.Drawing.Point(653, 437);
            this.readytobookControlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readytobookControlPanel.Name = "readytobookControlPanel";
            this.readytobookControlPanel.Size = new System.Drawing.Size(155, 49);
            this.readytobookControlPanel.TabIndex = 3;
            this.readytobookControlPanel.Text = "READY TO BOOK";
            this.readytobookControlPanel.UseVisualStyleBackColor = true;
            this.readytobookControlPanel.Click += new System.EventHandler(this.readytobookControlPanel_Click);
            // 
            // backControlPanel
            // 
            this.backControlPanel.Location = new System.Drawing.Point(900, 490);
            this.backControlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backControlPanel.Name = "backControlPanel";
            this.backControlPanel.Size = new System.Drawing.Size(134, 48);
            this.backControlPanel.TabIndex = 4;
            this.backControlPanel.Text = "BACK";
            this.backControlPanel.UseVisualStyleBackColor = true;
            this.backControlPanel.Click += new System.EventHandler(this.backControlPanel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(917, 398);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.backControlPanel);
            this.Controls.Add(this.readytobookControlPanel);
            this.Controls.Add(this.checkoutControlPanel);
            this.Controls.Add(this.bookedControlPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bookedControlPanel;
        private System.Windows.Forms.Button checkoutControlPanel;
        private System.Windows.Forms.Button readytobookControlPanel;
        private System.Windows.Forms.Button backControlPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
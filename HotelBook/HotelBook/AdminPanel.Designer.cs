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
            this.addAdminPanel = new System.Windows.Forms.Button();
            this.removeAdminPanel = new System.Windows.Forms.Button();
            this.backAdminPanel = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // addAdminPanel
            // 
            this.addAdminPanel.Location = new System.Drawing.Point(1103, 45);
            this.addAdminPanel.Name = "addAdminPanel";
            this.addAdminPanel.Size = new System.Drawing.Size(135, 67);
            this.addAdminPanel.TabIndex = 1;
            this.addAdminPanel.Text = "ADD";
            this.addAdminPanel.UseVisualStyleBackColor = true;
            this.addAdminPanel.Click += new System.EventHandler(this.addAdminPanel_Click);
            // 
            // removeAdminPanel
            // 
            this.removeAdminPanel.Location = new System.Drawing.Point(1103, 166);
            this.removeAdminPanel.Name = "removeAdminPanel";
            this.removeAdminPanel.Size = new System.Drawing.Size(135, 62);
            this.removeAdminPanel.TabIndex = 2;
            this.removeAdminPanel.Text = "REMOVE";
            this.removeAdminPanel.UseVisualStyleBackColor = true;
            this.removeAdminPanel.Click += new System.EventHandler(this.removeAdminPanel_Click);
            // 
            // backAdminPanel
            // 
            this.backAdminPanel.Location = new System.Drawing.Point(1103, 431);
            this.backAdminPanel.Name = "backAdminPanel";
            this.backAdminPanel.Size = new System.Drawing.Size(135, 68);
            this.backAdminPanel.TabIndex = 3;
            this.backAdminPanel.Text = "BACK";
            this.backAdminPanel.UseVisualStyleBackColor = true;
            this.backAdminPanel.Click += new System.EventHandler(this.backAdminPanel_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.RowHeadersWidth = 62;
            this.dataGridViewEmployees.RowTemplate.Height = 28;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(1009, 502);
            this.dataGridViewEmployees.TabIndex = 4;
            this.dataGridViewEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployees_CellContentClick);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 526);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.backAdminPanel);
            this.Controls.Add(this.removeAdminPanel);
            this.Controls.Add(this.addAdminPanel);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addAdminPanel;
        private System.Windows.Forms.Button removeAdminPanel;
        private System.Windows.Forms.Button backAdminPanel;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
    }
}
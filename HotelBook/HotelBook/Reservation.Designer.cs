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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReservation
            // 
            this.dataGridReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservation.Location = new System.Drawing.Point(38, 25);
            this.dataGridReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridReservation.Name = "dataGridReservation";
            this.dataGridReservation.RowHeadersWidth = 62;
            this.dataGridReservation.RowTemplate.Height = 28;
            this.dataGridReservation.Size = new System.Drawing.Size(706, 298);
            this.dataGridReservation.TabIndex = 0;
            this.dataGridReservation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReservation_CellContentClick);
            // 
            // backReservation
            // 
            this.backReservation.Location = new System.Drawing.Point(668, 350);
            this.backReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backReservation.Name = "backReservation";
            this.backReservation.Size = new System.Drawing.Size(100, 45);
            this.backReservation.TabIndex = 1;
            this.backReservation.Text = "BACK";
            this.backReservation.UseVisualStyleBackColor = true;
            this.backReservation.Click += new System.EventHandler(this.backReservation_Click);
            // 
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(779, 405);
            this.Controls.Add(this.backReservation);
            this.Controls.Add(this.dataGridReservation);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reservation";
            this.Text = "Reservation";
            this.Load += new System.EventHandler(this.Reservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReservation;
        private System.Windows.Forms.Button backReservation;
    }
}
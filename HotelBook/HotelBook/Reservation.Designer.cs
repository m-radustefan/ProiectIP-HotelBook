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
            this.dataGridReservation.Location = new System.Drawing.Point(43, 31);
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
            this.backReservation.Name = "backReservation";
            this.backReservation.Size = new System.Drawing.Size(112, 56);
            this.backReservation.TabIndex = 1;
            this.backReservation.Text = "BACK";
            this.backReservation.UseVisualStyleBackColor = true;
            this.backReservation.Click += new System.EventHandler(this.backReservation_Click);
            // 
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 506);
            this.Controls.Add(this.backReservation);
            this.Controls.Add(this.dataGridReservation);
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
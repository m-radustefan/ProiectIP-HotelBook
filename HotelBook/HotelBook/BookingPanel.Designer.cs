﻿namespace HotelBook
{
    partial class BookingPanel
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
            this.bookBookingPanel = new System.Windows.Forms.Button();
            this.backBookingPanel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridBookingPanel = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.emailBookingPanel = new System.Windows.Forms.RichTextBox();
            this.lastnameBookingPanel = new System.Windows.Forms.RichTextBox();
            this.nightsBookingPanel = new System.Windows.Forms.RichTextBox();
            this.phoneBookingPanel = new System.Windows.Forms.RichTextBox();
            this.firstnameBookingPanel = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBookingPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // bookBookingPanel
            // 
            this.bookBookingPanel.Location = new System.Drawing.Point(556, 119);
            this.bookBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookBookingPanel.Name = "bookBookingPanel";
            this.bookBookingPanel.Size = new System.Drawing.Size(129, 45);
            this.bookBookingPanel.TabIndex = 5;
            this.bookBookingPanel.Text = "BOOK";
            this.bookBookingPanel.UseVisualStyleBackColor = true;
            this.bookBookingPanel.Click += new System.EventHandler(this.bookBookingPanel_Click);
            // 
            // backBookingPanel
            // 
            this.backBookingPanel.Location = new System.Drawing.Point(556, 301);
            this.backBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBookingPanel.Name = "backBookingPanel";
            this.backBookingPanel.Size = new System.Drawing.Size(129, 42);
            this.backBookingPanel.TabIndex = 6;
            this.backBookingPanel.Text = "BACK";
            this.backBookingPanel.UseVisualStyleBackColor = true;
            this.backBookingPanel.Click += new System.EventHandler(this.backBookingPanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "FIRST NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "LAST NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "PHONE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "E-MAIL";
            // 
            // dataGridBookingPanel
            // 
            this.dataGridBookingPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBookingPanel.Location = new System.Drawing.Point(110, 10);
            this.dataGridBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridBookingPanel.Name = "dataGridBookingPanel";
            this.dataGridBookingPanel.RowHeadersWidth = 62;
            this.dataGridBookingPanel.RowTemplate.Height = 28;
            this.dataGridBookingPanel.Size = new System.Drawing.Size(407, 66);
            this.dataGridBookingPanel.TabIndex = 11;
            this.dataGridBookingPanel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBookingPanel_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "NIGHTS";
            // 
            // emailBookingPanel
            // 
            this.emailBookingPanel.Location = new System.Drawing.Point(110, 245);
            this.emailBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailBookingPanel.Name = "emailBookingPanel";
            this.emailBookingPanel.Size = new System.Drawing.Size(408, 32);
            this.emailBookingPanel.TabIndex = 14;
            this.emailBookingPanel.Text = "";
            this.emailBookingPanel.TextChanged += new System.EventHandler(this.emailBookingPanel_TextChanged);
            // 
            // lastnameBookingPanel
            // 
            this.lastnameBookingPanel.Location = new System.Drawing.Point(110, 147);
            this.lastnameBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastnameBookingPanel.Name = "lastnameBookingPanel";
            this.lastnameBookingPanel.Size = new System.Drawing.Size(408, 33);
            this.lastnameBookingPanel.TabIndex = 15;
            this.lastnameBookingPanel.Text = "";
            this.lastnameBookingPanel.TextChanged += new System.EventHandler(this.lastnameBookingPanel_TextChanged);
            // 
            // nightsBookingPanel
            // 
            this.nightsBookingPanel.Location = new System.Drawing.Point(110, 291);
            this.nightsBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nightsBookingPanel.Name = "nightsBookingPanel";
            this.nightsBookingPanel.Size = new System.Drawing.Size(408, 34);
            this.nightsBookingPanel.TabIndex = 16;
            this.nightsBookingPanel.Text = "";
            this.nightsBookingPanel.TextChanged += new System.EventHandler(this.nightsBookingPanel_TextChanged);
            // 
            // phoneBookingPanel
            // 
            this.phoneBookingPanel.Location = new System.Drawing.Point(110, 196);
            this.phoneBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneBookingPanel.Name = "phoneBookingPanel";
            this.phoneBookingPanel.Size = new System.Drawing.Size(408, 33);
            this.phoneBookingPanel.TabIndex = 17;
            this.phoneBookingPanel.Text = "";
            this.phoneBookingPanel.TextChanged += new System.EventHandler(this.phoneBookingPanel_TextChanged);
            // 
            // firstnameBookingPanel
            // 
            this.firstnameBookingPanel.Location = new System.Drawing.Point(110, 101);
            this.firstnameBookingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.firstnameBookingPanel.Name = "firstnameBookingPanel";
            this.firstnameBookingPanel.Size = new System.Drawing.Size(408, 31);
            this.firstnameBookingPanel.TabIndex = 18;
            this.firstnameBookingPanel.Text = "";
            this.firstnameBookingPanel.TextChanged += new System.EventHandler(this.firstnameBookingPanel_TextChanged);
            // 
            // BookingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.firstnameBookingPanel);
            this.Controls.Add(this.phoneBookingPanel);
            this.Controls.Add(this.nightsBookingPanel);
            this.Controls.Add(this.lastnameBookingPanel);
            this.Controls.Add(this.emailBookingPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridBookingPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backBookingPanel);
            this.Controls.Add(this.bookBookingPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BookingPanel";
            this.Text = "BookingPanel";
            this.Load += new System.EventHandler(this.BookingPanel_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBookingPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bookBookingPanel;
        private System.Windows.Forms.Button backBookingPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridBookingPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox emailBookingPanel;
        private System.Windows.Forms.RichTextBox lastnameBookingPanel;
        private System.Windows.Forms.RichTextBox nightsBookingPanel;
        private System.Windows.Forms.RichTextBox phoneBookingPanel;
        private System.Windows.Forms.RichTextBox firstnameBookingPanel;
    }
}
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bookedControlPanel = new System.Windows.Forms.Button();
            this.checkoutControlPanel = new System.Windows.Forms.Button();
            this.readytobookControlPanel = new System.Windows.Forms.Button();
            this.backControlPanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(108, 54);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(954, 441);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // bookedControlPanel
            // 
            this.bookedControlPanel.Location = new System.Drawing.Point(288, 546);
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
            this.checkoutControlPanel.Location = new System.Drawing.Point(522, 546);
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
            this.readytobookControlPanel.Location = new System.Drawing.Point(735, 546);
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
            this.backControlPanel.Location = new System.Drawing.Point(1013, 613);
            this.backControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backControlPanel.Name = "backControlPanel";
            this.backControlPanel.Size = new System.Drawing.Size(151, 60);
            this.backControlPanel.TabIndex = 4;
            this.backControlPanel.Text = "BACK";
            this.backControlPanel.UseVisualStyleBackColor = true;
            this.backControlPanel.Click += new System.EventHandler(this.backControlPanel_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.backControlPanel);
            this.Controls.Add(this.readytobookControlPanel);
            this.Controls.Add(this.checkoutControlPanel);
            this.Controls.Add(this.bookedControlPanel);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bookedControlPanel;
        private System.Windows.Forms.Button checkoutControlPanel;
        private System.Windows.Forms.Button readytobookControlPanel;
        private System.Windows.Forms.Button backControlPanel;
    }
}
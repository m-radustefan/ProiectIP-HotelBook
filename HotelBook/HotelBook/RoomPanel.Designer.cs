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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "TYPE";
            // 
            // addRoomPanel
            // 
            this.addRoomPanel.Location = new System.Drawing.Point(442, 48);
            this.addRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addRoomPanel.Name = "addRoomPanel";
            this.addRoomPanel.Size = new System.Drawing.Size(116, 35);
            this.addRoomPanel.TabIndex = 1;
            this.addRoomPanel.Text = "ADD";
            this.addRoomPanel.UseVisualStyleBackColor = true;
            this.addRoomPanel.Click += new System.EventHandler(this.addRoomPanel_Click);
            // 
            // backRoomPanel
            // 
            this.backRoomPanel.Location = new System.Drawing.Point(565, 302);
            this.backRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backRoomPanel.Name = "backRoomPanel";
            this.backRoomPanel.Size = new System.Drawing.Size(116, 38);
            this.backRoomPanel.TabIndex = 2;
            this.backRoomPanel.Text = "BACK";
            this.backRoomPanel.UseVisualStyleBackColor = true;
            this.backRoomPanel.Click += new System.EventHandler(this.backRoomPanel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(192, 55);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(152, 26);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "PRICE";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(192, 119);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(152, 26);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // removeRoomPanel
            // 
            this.removeRoomPanel.Location = new System.Drawing.Point(442, 119);
            this.removeRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeRoomPanel.Name = "removeRoomPanel";
            this.removeRoomPanel.Size = new System.Drawing.Size(116, 35);
            this.removeRoomPanel.TabIndex = 6;
            this.removeRoomPanel.Text = "REMOVE";
            this.removeRoomPanel.UseVisualStyleBackColor = true;
            this.removeRoomPanel.Click += new System.EventHandler(this.removeRoomPanel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID";
            // 
            // idRoomPanel
            // 
            this.idRoomPanel.Location = new System.Drawing.Point(192, 177);
            this.idRoomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idRoomPanel.Name = "idRoomPanel";
            this.idRoomPanel.Size = new System.Drawing.Size(152, 26);
            this.idRoomPanel.TabIndex = 8;
            this.idRoomPanel.Text = "";
            this.idRoomPanel.TextChanged += new System.EventHandler(this.idRoomPanel_TextChanged);
            // 
            // RoomPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.idRoomPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeRoomPanel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.backRoomPanel);
            this.Controls.Add(this.addRoomPanel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomPanel";
            this.Text = "RoomPanel";
            this.Load += new System.EventHandler(this.RoomPanel_Load);
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
    }
}
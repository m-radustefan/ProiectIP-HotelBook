namespace HotelBook
{
    partial class Home
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
            this.logout = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.control = new System.Windows.Forms.Button();
            this.rooms = new System.Windows.Forms.Button();
            this.reservations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(262, 366);
            this.logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(149, 53);
            this.logout.TabIndex = 2;
            this.logout.Text = "LOG OUT";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // admin
            // 
            this.admin.Location = new System.Drawing.Point(262, 134);
            this.admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(149, 53);
            this.admin.TabIndex = 4;
            this.admin.Text = "ADMIN";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // control
            // 
            this.control.Location = new System.Drawing.Point(262, 58);
            this.control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(149, 53);
            this.control.TabIndex = 5;
            this.control.Text = "CONTROL";
            this.control.UseVisualStyleBackColor = true;
            this.control.Click += new System.EventHandler(this.control_Click);
            // 
            // rooms
            // 
            this.rooms.Location = new System.Drawing.Point(262, 214);
            this.rooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(149, 53);
            this.rooms.TabIndex = 7;
            this.rooms.Text = "ROOMS";
            this.rooms.UseVisualStyleBackColor = true;
            this.rooms.Click += new System.EventHandler(this.rooms_Click);
            // 
            // reservations
            // 
            this.reservations.Location = new System.Drawing.Point(262, 297);
            this.reservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(149, 53);
            this.reservations.TabIndex = 8;
            this.reservations.Text = "RESERVATIONS";
            this.reservations.UseVisualStyleBackColor = true;
            this.reservations.Click += new System.EventHandler(this.reservations_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(711, 512);
            this.Controls.Add(this.reservations);
            this.Controls.Add(this.rooms);
            this.Controls.Add(this.control);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.logout);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Button control;
        private System.Windows.Forms.Button rooms;
        private System.Windows.Forms.Button reservations;
    }
}


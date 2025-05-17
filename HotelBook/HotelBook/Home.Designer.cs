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
            this.register = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.control = new System.Windows.Forms.Button();
            this.booking = new System.Windows.Forms.Button();
            this.rooms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(295, 472);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(168, 66);
            this.logout.TabIndex = 2;
            this.logout.Text = "LOG OUT";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(295, 299);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(168, 66);
            this.register.TabIndex = 3;
            this.register.Text = "REGISTER";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // admin
            // 
            this.admin.Location = new System.Drawing.Point(295, 211);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(168, 66);
            this.admin.TabIndex = 4;
            this.admin.Text = "ADMIN";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // control
            // 
            this.control.Location = new System.Drawing.Point(295, 39);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(168, 66);
            this.control.TabIndex = 5;
            this.control.Text = "CONTROL";
            this.control.UseVisualStyleBackColor = true;
            this.control.Click += new System.EventHandler(this.control_Click);
            // 
            // booking
            // 
            this.booking.Location = new System.Drawing.Point(295, 125);
            this.booking.Name = "booking";
            this.booking.Size = new System.Drawing.Size(168, 66);
            this.booking.TabIndex = 6;
            this.booking.Text = "BOOKING";
            this.booking.UseVisualStyleBackColor = true;
            this.booking.Click += new System.EventHandler(this.booking_Click);
            // 
            // rooms
            // 
            this.rooms.Location = new System.Drawing.Point(295, 388);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(168, 66);
            this.rooms.TabIndex = 7;
            this.rooms.Text = "ROOMS";
            this.rooms.UseVisualStyleBackColor = true;
            this.rooms.Click += new System.EventHandler(this.rooms_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.rooms);
            this.Controls.Add(this.booking);
            this.Controls.Add(this.control);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.register);
            this.Controls.Add(this.logout);
            this.Name = "Home";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Button control;
        private System.Windows.Forms.Button booking;
        private System.Windows.Forms.Button rooms;
    }
}


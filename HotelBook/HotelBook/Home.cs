using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelBook.Domain;
using HotelBook.Services;
using Microsoft.Win32;

namespace HotelBook
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            ConfigureAccessControls();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ConfigureAccessControls();
        }

        private void ConfigureAccessControls()
        {
            if (!SessionManager.IsLoggedIn)
                throw new InvalidOperationException("No user in session – did you forget to log in?");

            var allButtons = new[]
            {
                control,
                admin,
                rooms,
                reservations,
                logout
            };

            // Dezactivăm tot și setăm back-color uniform
            var normalColor = SystemColors.ButtonFace;
            foreach (var btn in allButtons)
            {
                btn.Enabled = false;
                btn.UseVisualStyleBackColor = false;
                btn.BackColor = ControlPaint.Dark(normalColor, 0.05f);
            }

            // Log out rămâne întotdeauna activ
            logout.Enabled = true;
            logout.BackColor = normalColor;

            // Activăm butoanele permise pe rol
            switch (SessionManager.CurrentUser.Role)
            {
                case Role.Admin:
                    // acces total
                    foreach (var btn in allButtons)
                    {
                        btn.Enabled = true;
                        btn.BackColor = normalColor;
                    }
                    break;

                case Role.Receptionist:
                    control.Enabled = true;
                    control.BackColor = normalColor;
                    rooms.Enabled = true;
                    rooms.BackColor = normalColor;
                    reservations.Enabled = true;
                    reservations.BackColor = normalColor;
                    break;

                case Role.Cleaner:
                    control.Enabled = true;
                    control.BackColor = normalColor;
                    reservations.Enabled = true;
                    reservations.BackColor = normalColor;
                    break;

                    // poți adăuga alte roluri aici...
            }
        }



        // ------------  NAVIGAŢIE  ----------------------------------

        private void control_Click(object sender, EventArgs e)
        {
            NavigateTo(new ControlPanel());   // Control → ControlPanel
        }

        private void admin_Click(object sender, EventArgs e)
        {
            NavigateTo(new AdminPanel());     // Admin → AdminPanel
        }

        private void rooms_Click(object sender, EventArgs e)
        {
            NavigateTo(new RoomPanel());
        }


        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            Hide();
            using (var login = new LogIn())   // revenim la LogIn
            {
                login.ShowDialog();
            }
            Close();
        }

        private void reservations_Click_1(object sender, EventArgs e)
        {
            Hide();
            using (var rp = new Reservation())
                rp.ShowDialog(this);
            Show();
        }

        private void NavigateTo(Form target)
        {
            Hide();
            using (target)
            {
                target.ShowDialog(this);
            }
            Show();
        }
    }
}

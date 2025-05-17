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
            // aici chemăm logica de iniţializare a drepturilor
            ConfigureAccessControls();
        }


        /// <summary>Activează/dezactivează butoanele în funcţie de rolul utilizatorului.</summary>
        private void ConfigureAccessControls()
        {
            if (!SessionManager.IsLoggedIn)
                throw new InvalidOperationException("No user in session – did you forget to log in?");

            Role role = SessionManager.CurrentUser.Role;

            bool isAdmin = role == Role.Admin;

            admin.Visible = admin.Enabled = isAdmin;
            register.Visible = register.Enabled = isAdmin;
        }

        // ------------  NAVIGAŢIE  ----------------------------------

        private void control_Click(object sender, EventArgs e)
        {
            NavigateTo(new ControlPanel());   // Control → ControlPanel
        }

        private void booking_Click(object sender, EventArgs e)
        {
            NavigateTo(new BookingPanel());   // Booking → BookingPanel
        }

        private void admin_Click(object sender, EventArgs e)
        {
            NavigateTo(new AdminPanel());     // Admin → AdminPanel
        }

        private void register_Click(object sender, EventArgs e)
        {
            NavigateTo(new AdminRegister());  // Register → AdminRegister
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

        /// <summary>
        /// Ascunde fereastra curentă, arată target Form ca dialog modal şi revine.
        /// </summary>
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

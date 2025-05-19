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

            // Închidem toate butoanele (în afară de Logout, care rămâne mereu vizibil)
            control.Visible = control.Enabled = false;
            admin.Visible = admin.Enabled = false;
            register.Visible = register.Enabled = false;
            rooms.Visible = rooms.Enabled = false;
            logout.Visible = logout.Enabled = true;

            switch (role)
            {
                case Role.Admin:
                    // Admin are acces la tot
                    control.Visible = control.Enabled = true;
                    admin.Visible = admin.Enabled = true;
                    register.Visible = register.Enabled = true;
                    rooms.Visible = rooms.Enabled = true;
                    break;

                case Role.Cleaner:
                    // Cleaner: doar Control, Rooms și Logout
                    control.Visible = control.Enabled = true;
                    rooms.Visible = rooms.Enabled = true;
                    break;

                case Role.Receptionist:
                    // Receptionist: Control, Rooms și (dacă vrei) Register + Logout
                    control.Visible = control.Enabled = true;
                    rooms.Visible = rooms.Enabled = true;
                    break;

                    // poți adăuga și alte roluri după nevoie
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

        private void reservations_Click_1(object sender, EventArgs e)
        {
            Hide();
            using (var rp = new Reservation())
                rp.ShowDialog(this);
            Show();
        }
    }
}

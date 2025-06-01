/***************************************************************************
 *                                                                         *
 *  File:        Home.cs                                                   *
 *  Copyright:   (c) 2025, Munteanu Radu Stefan                            *
 *  E-mail:      radu-stefan.munteanu@student.tuiasi.ro                    *
 *  Description: Formularul principal Home oferă interfața de navigație    *
 *  pentru utilizatorii autentificați în aplicația HotelBook. Accesul la   *
 *  diferitele secțiuni (admin, camere, rezervări, control) este controlat *
 *  pe baza rolului utilizatorului (Admin, Recepționer, Curățenie etc).    *
 *  Funcționalitatea include și deconectarea utilizatorului.               *
 *                                                                         *
 *  This program is free software; you can redistribute it and/or modify   *
 *  it under the terms of the GNU General Public License as published by   *
 *  the Free Software Foundation. This program is distributed in the       *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even    *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR    *
 *  PURPOSE. See the GNU General Public License for more details.          *
 *                                                                         *
 **************************************************************************/


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
        // Constructorul formularului Home – initializeaza interfata si configureaza accesul pe baza rolului
        public Home()
        {
            InitializeComponent();
            ConfigureAccessControls();
        }
        // Eveniment apelat la incarcarea formularului – reaplica regulile de acces

        private void Home_Load(object sender, EventArgs e)
        {
            ConfigureAccessControls();
        }
        // Configureaza butoanele din interfata in functie de rolul utilizatorului autentificat

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

            var normalColor = SystemColors.ButtonFace;
            foreach (var btn in allButtons)
            {
                btn.Enabled = false;
                btn.UseVisualStyleBackColor = false;
                btn.BackColor = ControlPaint.Dark(normalColor, 0.05f);
            }

            logout.Enabled = true;
            logout.BackColor = normalColor;

            switch (SessionManager.CurrentUser.Role)
            {
                case Role.Admin:
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

            }
        }



        // Navigheaza catre fereastra ControlPanel

        private void control_Click(object sender, EventArgs e)
        {
            NavigateTo(new ControlPanel());   
        }
        // Navigheaza catre fereastra AdminPanel

        private void admin_Click(object sender, EventArgs e)
        {
            NavigateTo(new AdminPanel());     
        }
        // Navigheaza catre fereastra RoomPanel

        private void rooms_Click(object sender, EventArgs e)
        {
            NavigateTo(new RoomPanel());
        }

        // Deconecteaza utilizatorul si revine la fereastra de autentificare

        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            Hide();
            using (var login = new LogIn())   
            {
                login.ShowDialog();
            }
            Close();
        }
        // Navigheaza catre fereastra Reservation si revine la intoarcere

        private void reservations_Click_1(object sender, EventArgs e)
        {
            Hide();
            using (var rp = new Reservation())
                rp.ShowDialog(this);
            Show();
        }
        // Navigheaza catre o fereastra data si revine la inchiderea acesteia

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

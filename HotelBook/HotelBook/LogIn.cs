/****************************************************************************
 *                                                                          *
 *  File:        LogIn.cs                                                   *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                            *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                    *
 *  Description: Acest fișier definește formularul LogIn, care permite      *
 *  autentificarea angajaților în aplicația HotelBook. Formularul validează *
 *  combinația de utilizator și parolă, inițiază sesiunea curentă pe baza   *
 *  rolului identificat și redirecționează utilizatorul către interfața     *
 *  principală. În caz de autentificare eșuată, se afișează un mesaj de     *
 *  eroare.                                                                 *
 *                                                                          *
 *  This program is free software; you can redistribute it and/or modify    *
 *  it under the terms of the GNU General Public License as published by    *
 *  the Free Software Foundation. This program is distributed in the        *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even     *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR     *
 *  PURPOSE. See the GNU General Public License for more details.           *
 *                                                                          *
 ***************************************************************************/


using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HotelBook.Domain;
using HotelBook.Services;

namespace HotelBook
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            login_pass.UseSystemPasswordChar = true;
            this.FormClosing += CloseApp;
            helpToolStripMenuItem.Click += HelpToolStripMenuItem_Click;
            despreToolStripMenuItem.Click += DespreToolStripMenuItem_Click;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }


        private void CloseApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void loginLogIn_Click(object sender, EventArgs e)
        {
            string user = login_username.Text.Trim();
            string pass = login_pass.Text.Trim();

            var emp = EmployeeService
                .GetAll()
                .FirstOrDefault(x =>
                    x.Username.Equals(user, StringComparison.OrdinalIgnoreCase)
                    && x.Password == pass
                );

            if (emp == null)
            {
                MessageBox.Show(
                    "Invalid credentials!",
                    "Authentication error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                login_pass.Clear();
                login_username.Focus();
                return;
            }

            SessionManager.Login(new User(emp.Username, emp.Role));

            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void login_username_TextChanged(object sender, EventArgs e) { }
        private void login_pass_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // presupunem că fișierul se numește Hotel.chm și e copiat în bin\Debug
            var helpFile = Path.Combine(Application.StartupPath, "Hotel.chm");
            if (File.Exists(helpFile))
                Help.ShowHelp(this, helpFile);
            else
                MessageBox.Show(
                    "Fișierul de ajutor Hotel.chm nu a fost găsit:\n" + helpFile,
                    "Help lipsă",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
        }

        private void DespreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Echipa:\n– Padurariu Matei-Ionut \n– Munteanu Radu-Stefan \n– Bardasu Alexandru-Ionut \n- Rusu Eduard-Ionut",
                "Despre",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}

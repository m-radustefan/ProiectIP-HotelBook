/**************************************************************************
 *                                                                        *
 *  File:        AdminRegister.cs                                         *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa AdminRegister, care         *
 *  gestionează interfața pentru înregistrarea angajaților noi în         *
 *  aplicația HotelBook. Include validarea datelor, verificarea           *
 *  duplicatelor, atribuirea rolurilor și adăugarea angajaților în baza   *
 *  de date SQLite.                                                       *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
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

namespace HotelBook
{
    public partial class AdminRegister : Form
    {
        // Constructorul formularului AdminRegister – initializeaza interfata si popularea ComboBox-ului cu roluri

        public AdminRegister()
        {
            InitializeComponent();
            this.FormClosing += Form_Closing;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new[]
            {
                Role.Admin.ToString(),
                Role.Cleaner.ToString(),
                Role.Receptionist.ToString()
            });
            comboBox1.SelectedIndex = 0;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        // Evenimentul de incarcare al formularului – neutilizat momentan

        private void AdminRegister_Load(object sender, EventArgs e)
        {
            
        }

        // Eveniment declansat la apasarea butonului Submit – valideaza datele si adauga un angajat nou

        private void submitAdminRegister_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(richTextBox1.Text) ||
                string.IsNullOrWhiteSpace(richTextBox2.Text) ||
                string.IsNullOrWhiteSpace(richTextBox3.Text) ||
                string.IsNullOrWhiteSpace(richTextBox4.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show(
                    "Toate câmpurile sunt obligatorii",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string first = richTextBox1.Text.Trim();
            string last = richTextBox2.Text.Trim();
            string user = richTextBox3.Text.Trim();
            string pass = richTextBox4.Text.Trim();

            bool exists = EmployeeService
                .GetAll()
                .Any(empe => empe.Username.Equals(user, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                MessageBox.Show(
                    "Username dublat",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            
            if (!Enum.TryParse<Role>(
                    comboBox1.SelectedItem.ToString(),
                    true,
                    out Role rol))
                rol = Role.Admin;


            
            var emp = new Employee
            {
                FirstName = first,
                LastName = last,
                Username = user,
                Password = pass,
                Role = rol
            };
            EmployeeService.Add(emp);

            
            MessageBox.Show(
                "S-a adăugat partenerul cu succes",
                "Succes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

           
            ClearForm();
            richTextBox1.Focus();
        }
        // Reseteaza toate campurile formularului

        private void ClearForm()
        {
            richTextBox1.Clear();   
            richTextBox2.Clear();   
            richTextBox3.Clear();   
            richTextBox4.Clear();   
            comboBox1.SelectedIndex = 0; 
        }

        // Eveniment declansat la apasarea butonului Back – inchide formularul curent

        private void backAdminRegister_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


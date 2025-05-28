/**************************************************************************
 *                                                                        *
 *  File:        AdminPanel.cs                                            *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa AdminPanel, care            *
 *  gestionează interfața principală pentru administrarea angajaților în  *
 *  aplicația HotelBook. Permite vizualizarea, adăugarea și eliminarea    *
 *  angajaților, precum și navigarea către alte componente ale aplicației.*
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
    public partial class AdminPanel : Form
    {
        // Constructorul formularului AdminPanel – initializeaza interfata si incarca lista angajatilor

        public AdminPanel()
        {
            InitializeComponent();
            this.FormClosing += Form_Closing;
            LoadEmployees();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        // Evenimentul de incarcare al formularului – in prezent nu face nimic, poate fi folosit pentru initializari suplimentare

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            
        }

        // Incarca lista tuturor angajatilor si o afiseaza in DataGridView

        private void LoadEmployees()
        {
            
            var list = EmployeeService.GetAll().ToList();

            dataGridViewEmployees.DataSource = list;
            
        }

        // Incearca sa obtina ID-ul angajatului selectat in DataGridView

        private bool TryGetSelectedEmployeeId(out int id)
        {
            id = 0;
            if (dataGridViewEmployees.CurrentRow == null)
                return false;

           
            id = Convert.ToInt32(dataGridViewEmployees
                    .CurrentRow
                    .Cells["Id"]
                    .Value);
            return true;
        }

        // Eveniment declansat la apasarea butonului "ADD" – deschide formularul de inregistrare a unui nou administrator

        private void addAdminPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var reg = new AdminRegister())
                reg.ShowDialog(this);
            LoadEmployees();
            Show();
        }

        // Eveniment declansat la apasarea butonului "REMOVE" – elimina angajatul selectat din lista

        private void removeAdminPanel_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployeeId(out int id))
            {
                MessageBox.Show(
                    "Selectează un angajat înainte de a apăsa REMOVE.",
                    "Nicio selecție",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            EmployeeService.Remove(id);
            LoadEmployees();
        }

        // Eveniment declansat la apasarea butonului "BACK" – revine la formularul principal (Home)

        private void backAdminPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        // Eveniment asociat cu un click pe celulele din DataGridView – momentan nefolosit
        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

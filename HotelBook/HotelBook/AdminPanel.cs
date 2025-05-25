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
        public AdminPanel()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // Dacă nu ai nimic special de făcut la Load, las-o goală.
        }


        private void LoadEmployees()
        {
            // Transformăm IEnumerable<Employee> în List pentru binding şi refresh
            var list = EmployeeService.GetAll().ToList();

            dataGridViewEmployees.DataSource = list;
            // Ascundem coloane nedorite (dacă e cazul)
            // dataGridViewEmployees.Columns["Password"].Visible = false;
        }

        private bool TryGetSelectedEmployeeId(out int id)
        {
            id = 0;
            if (dataGridViewEmployees.CurrentRow == null)
                return false;

            // Preluăm valoarea din coloana „Id”
            id = Convert.ToInt32(dataGridViewEmployees
                    .CurrentRow
                    .Cells["Id"]
                    .Value);
            return true;
        }

        private void addAdminPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var reg = new AdminRegister())
                reg.ShowDialog(this);
            LoadEmployees();
            Show();
        }

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

        private void backAdminPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

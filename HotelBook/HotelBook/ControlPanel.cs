/**************************************************************************
 *                                                                        *
 *  File:        ControlPanel.cs                                          *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Formularul ControlPanel permite gestiunea stării         *
 *  camerelor într-un hotel: rezervare, check-out, și readucerea în       *
 *  starea "ReadyToBook". Această interfață este destinată personalului   *
 *  de recepție și curățenie, în funcție de permisiunile de rol.          *
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelBook.Domain;
using HotelBook.Services;

namespace HotelBook
{
    public partial class ControlPanel : Form
    {
        // Cand fereastra devine activa (revine in prim-plan), reincarca lista camerelor

        public ControlPanel()
        {
            InitializeComponent();

            this.Activated += ControlPanel_Activated;
            helpToolStripMenuItem.Click += HelpToolStripMenuItem_Click;
            despreToolStripMenuItem.Click += DespreToolStripMenuItem_Click;
        }
        // La incarcarea ferestrei: configureaza DataGridView-ul si incarca camerele

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadRooms();
        }
        // Eveniment care reincarca camerele cand formularul devine activ

        private void ControlPanel_Activated(object sender, EventArgs e)
        {
            LoadRooms();
        }
        // Incarca lista camerelor in DataGridView

        private void LoadRooms()
        {
            var list = RoomService.GetAll().ToList();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Price"].HeaderText = "Price (€)";
        }
        // Returneaza camera selectata din grila sau null daca nu e nimic selectat

        private Room GetSelectedRoom()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            return dataGridView1
                .SelectedRows[0]
                .DataBoundItem as Room;
        }
        // Butonul "Book": deschide BookingPanel daca o camera este disponibila

        private void bookedControlPanel_Click(object sender, EventArgs e)
        {
            var room = GetSelectedRoom();
            if (room == null)
            {
                MessageBox.Show("Selectați mai întâi o cameră.", "Atentie",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (room.Status != RoomStatus.ReadyToBook)
            {
                MessageBox.Show("Eroare: doar camerele cu status 'ReadyToBook' pot fi rezervate.",
                                "Operație nepermisă",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            Hide();
            using (var bp = new BookingPanel(room))
                bp.ShowDialog(this);
            Show();

            LoadRooms();
        }
        // Butonul "Check Out": seteaza statusul camerei si sterge rezervarea

        private void checkoutControlPanel_Click(object sender, EventArgs e)
        {
            var room = GetSelectedRoom();
            if (room == null)
            {
                MessageBox.Show("Selectați mai întâi o cameră.", "Atentie",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (room.Status != RoomStatus.Booked)
            {
                MessageBox.Show("Eroare: doar camerele cu status 'Booked' pot face 'Check Out'.",
                                "Operație nepermisă",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            room.Status = RoomStatus.CheckOut;
            RoomService.Update(room);

            ReservationService.RemoveByRoom(room.Id);

            LoadRooms();
        }

        // Butonul "ReadyToBook": marcheaza camera ca fiind disponibila din nou

        private void readytobookControlPanel_Click(object sender, EventArgs e)
        {
            var room = GetSelectedRoom();
            if (room == null)
            {
                MessageBox.Show(
                    "Selectați mai întâi o cameră.",
                    "Atentie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (room.Status != RoomStatus.CheckOut)
            {
                MessageBox.Show(
                    "Eroare: doar camerele cu status 'CheckOut' pot fi marcate 'ReadyToBook'.",
                    "Operație nepermisă",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            room.Status = RoomStatus.ReadyToBook;
            RoomService.Update(room);
            LoadRooms();
        }
        // Butonul "Back": revine la formularul principal (Home)

        private void backControlPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }
        // Evenimente nefolosite, generate de designer

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

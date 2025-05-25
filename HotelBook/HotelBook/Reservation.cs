/**************************************************************************
 *                                                                        *
 *  File:        Reservation.cs                                           *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește formularul Reservation, care      *
 *  afișează într-un DataGridView toate rezervările existente din sistem. *
 *  Rezervările sunt sortate și afișate cu informații personalizate în    *
 *  antet, iar câmpurile interne precum ID-ul camerei sunt ascunse.       *
 *  Interfața permite navigarea înapoi la ecranul principal al aplicației.*
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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            this.Load += Reservation_Load;
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            // Configurăm DataGridView
            dataGridReservation.ReadOnly = true;
            dataGridReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReservation.MultiSelect = false;
            dataGridReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReservation.RowHeadersVisible = false;
            dataGridReservation.AllowUserToAddRows = false;
            dataGridReservation.AllowUserToDeleteRows = false;

            // Încarcă toate rezervările din BD
            var list = ReservationService.GetAll()
                        .OrderBy(r => r.RoomType)
                        .ThenBy(r => r.LastName)
                        .ToList();
            dataGridReservation.DataSource = list;

            // Personalizează antetele
            if (dataGridReservation.Columns["RoomType"] != null)
                dataGridReservation.Columns["RoomType"].HeaderText = "Tip cameră";
            if (dataGridReservation.Columns["Nights"] != null)
                dataGridReservation.Columns["Nights"].HeaderText = "Nopți";
            if (dataGridReservation.Columns["FirstName"] != null)
                dataGridReservation.Columns["FirstName"].HeaderText = "Prenume";
            if (dataGridReservation.Columns["LastName"] != null)
                dataGridReservation.Columns["LastName"].HeaderText = "Nume";
            if (dataGridReservation.Columns["Phone"] != null)
                dataGridReservation.Columns["Phone"].HeaderText = "Telefon";
            if (dataGridReservation.Columns["Email"] != null)
                dataGridReservation.Columns["Email"].HeaderText = "Email";

            // Ascunde câmpurile interne
            if (dataGridReservation.Columns["Id"] != null)
                dataGridReservation.Columns["Id"].Visible = false;
            if (dataGridReservation.Columns["RoomId"] != null)
                dataGridReservation.Columns["RoomId"].Visible = false;
        }

        private void backReservation_Click(object sender, EventArgs e)
        {
            // Navighează direct la Home
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }


        // Handler gol
        private void dataGridReservation_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}


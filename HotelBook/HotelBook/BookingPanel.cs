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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelBook.Domain;
using HotelBook.Services;  

namespace HotelBook
{
    public partial class BookingPanel : Form
    {
        private readonly Room _room;

        // Constructorul formularului – initializeaza componenta si salveaza camera primita ca parametru

        public BookingPanel(Room room)
        {
            InitializeComponent();
            _room = room ?? throw new ArgumentNullException(nameof(room));
            this.Load += BookingPanel_Load_1;
        }

        // Evenimentul de incarcare al formularului – configureaza DataGridView-ul si afiseaza informatiile camerei

        private void BookingPanel_Load_1(object sender, EventArgs e)
        {
            
            dataGridBookingPanel.ReadOnly = true;
            dataGridBookingPanel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridBookingPanel.MultiSelect = false;
            dataGridBookingPanel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBookingPanel.RowHeadersVisible = false;
            dataGridBookingPanel.AllowUserToAddRows = false;
            dataGridBookingPanel.AllowUserToDeleteRows = false;

            
            dataGridBookingPanel.DataSource = new[] { _room }.ToList();

            
            if (dataGridBookingPanel.Columns["Id"] != null)
                dataGridBookingPanel.Columns["Id"].Visible = false;
            if (dataGridBookingPanel.Columns["Type"] != null)
                dataGridBookingPanel.Columns["Type"].HeaderText = "Tip cameră";
            if (dataGridBookingPanel.Columns["Status"] != null)
                dataGridBookingPanel.Columns["Status"].HeaderText = "Status";
            if (dataGridBookingPanel.Columns["Price"] != null)
                dataGridBookingPanel.Columns["Price"].HeaderText = "Preț €/noapte";
        }

        // Eveniment declansat la apasarea butonului de rezervare – valideaza datele si inregistreaza rezervarea

        private void bookBookingPanel_Click(object sender, EventArgs e)
        {
            
            string first = firstnameBookingPanel.Text.Trim();
            string last = lastnameBookingPanel.Text.Trim();
            string phone = phoneBookingPanel.Text.Trim();
            string email = emailBookingPanel.Text.Trim();
            string nightsText = nightsBookingPanel.Text.Trim();

            if (string.IsNullOrEmpty(first) ||
                string.IsNullOrEmpty(last) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email) ||
                !int.TryParse(nightsText, out int nights) ||
                nights <= 0)
            {
                MessageBox.Show(
                    "Completează TOATE câmpurile și un număr de nopți > 0.",
                    "Date incomplete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Creare obiect rezervare si salvare in baza de date

            var rez = new HotelBook.Domain.Reservation
            {
                RoomId = _room.Id,
                RoomType = _room.Type,
                Nights = nights,
                FirstName = first,
                LastName = last,
                Phone = phone,
                Email = email
            };
            ReservationService.Add(rez);

            // Actualizare status camera

            _room.Status = RoomStatus.Booked;
            RoomService.Update(_room);

            // Afisare mesaj de confirmare cu totalul de plata

            double total = _room.Price * nights;
            MessageBox.Show(
                $"Rezervare realizată cu succes!\n\n" +
                $"Cameră: {_room.Type}\n" +
                $"Nopți: {nights}\n" +
                $"Preț/noapte: {_room.Price:F2} €\n\n" +
                $"Total de plată: {total:F2} €",
                "Confirmare Rezervare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            
            Close();
        }

        // Butonul de revenire la ControlPanel – ascunde BookingPanel si deschide ControlPanel

        private void backBookingPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var cp = new ControlPanel())
                cp.ShowDialog(this);
            Close();
        }

        // Evenimente neutilizate (pentru modificarile din textboxuri si grid)

        private void dataGridBookingPanel_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void firstnameBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void lastnameBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void phoneBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void emailBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void nightsBookingPanel_TextChanged(object sender, EventArgs e) { }
    }
}

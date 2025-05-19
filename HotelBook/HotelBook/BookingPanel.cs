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
using HotelBook.Services;  // dacă ai un BookingService

namespace HotelBook
{
    public partial class BookingPanel : Form
    {
        private readonly Room _room;

        /// <summary>
        /// Primește camera selectată din ControlPanel.
        /// </summary>
        public BookingPanel(Room room)
        {
            InitializeComponent();
            _room = room ?? throw new ArgumentNullException(nameof(room));
            // Legăm handler‐ul Load care e definit în Designer ca BookingPanel_Load_1
            this.Load += BookingPanel_Load_1;
        }

        /// <summary>
        /// Load-ul formularului: configurăm DataGridView și afișăm camera.
        /// </summary>
        private void BookingPanel_Load_1(object sender, EventArgs e)
        {
            // Configurare DataGridView
            dataGridBookingPanel.ReadOnly = true;
            dataGridBookingPanel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridBookingPanel.MultiSelect = false;
            dataGridBookingPanel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBookingPanel.RowHeadersVisible = false;
            dataGridBookingPanel.AllowUserToAddRows = false;
            dataGridBookingPanel.AllowUserToDeleteRows = false;

            // Afișăm doar camera selectată
            dataGridBookingPanel.DataSource = new[] { _room }.ToList();

            // Personalizăm antetele coloanelor
            if (dataGridBookingPanel.Columns["Id"] != null)
                dataGridBookingPanel.Columns["Id"].Visible = false;
            if (dataGridBookingPanel.Columns["Type"] != null)
                dataGridBookingPanel.Columns["Type"].HeaderText = "Tip cameră";
            if (dataGridBookingPanel.Columns["Status"] != null)
                dataGridBookingPanel.Columns["Status"].HeaderText = "Status";
            if (dataGridBookingPanel.Columns["Price"] != null)
                dataGridBookingPanel.Columns["Price"].HeaderText = "Preț €/noapte";
        }

        /// <summary>
        /// Click pe BOOK: validăm date, salvăm rezervarea, schimbăm statusul și afișăm totalul.
        /// </summary>
        private void bookBookingPanel_Click(object sender, EventArgs e)
        {
            // 1) Citim și validăm câmpurile
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

            // 2) Persistăm rezervarea
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

            // 3) Schimbăm statusul camerei
            _room.Status = RoomStatus.Booked;
            RoomService.Update(_room);

            // 4) Calculăm și afișăm totalul
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

            // 5) Închidem BookingPanel ca să revenim la ControlPanel
            Close();
        }

        /// <summary>
        /// Click pe BACK: ne întoarcem la ControlPanel.
        /// </summary>
        private void backBookingPanel_Click(object sender, EventArgs e)
        {
            Hide();
            using (var cp = new ControlPanel())
                cp.ShowDialog(this);
            Close();
        }

        // Handlere goale generate de Designer (le poți șterge dacă nu le folosești)
        private void dataGridBookingPanel_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void firstnameBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void lastnameBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void phoneBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void emailBookingPanel_TextChanged(object sender, EventArgs e) { }
        private void nightsBookingPanel_TextChanged(object sender, EventArgs e) { }
    }
}

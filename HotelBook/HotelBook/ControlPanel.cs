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
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();

            // Legăm evenimentul Activated ca să reîncărcăm lista la fiecare revenire
            this.Activated += ControlPanel_Activated;
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            // Setări inițiale pentru DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadRooms();
        }

        private void ControlPanel_Activated(object sender, EventArgs e)
        {
            // De fiecare dată când această fereastră devine activă, reîncărcăm camerele
            LoadRooms();
        }

        private void LoadRooms()
        {
            // Obținem lista de camere și o legăm la grid
            var list = RoomService.GetAll().ToList();
            dataGridView1.DataSource = list;
        }

        // Helper: preia obiectul Room de pe rândul selectat
        private Room GetSelectedRoom()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            return dataGridView1
                .SelectedRows[0]
                .DataBoundItem as Room;
        }

        private void bookedControlPanel_Click(object sender, EventArgs e)
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

            if (room.Status != RoomStatus.ReadyToBook)
            {
                MessageBox.Show(
                    "Eroare: doar camerele cu status 'ReadyToBook' pot fi marcate 'Booked'.",
                    "Operație nepermisă",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // schimbăm status, salvăm și refresh
            room.Status = RoomStatus.Booked;
            RoomService.Update(room);
            LoadRooms();

            // navigăm în BookingPanel
            Hide();
            using (var bp = new BookingPanel())
                bp.ShowDialog(this);
            Show();
        }

        private void checkoutControlPanel_Click(object sender, EventArgs e)
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

            if (room.Status != RoomStatus.Booked)
            {
                MessageBox.Show(
                    "Eroare: doar camerele cu status 'Booked' pot face 'Check Out'.",
                    "Operație nepermisă",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            room.Status = RoomStatus.CheckOut;
            RoomService.Update(room);
            LoadRooms();
        }

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

        private void backControlPanel_Click(object sender, EventArgs e)
        {
            // Revenim la Home
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        // Dacă designer-ul a generat handler-e goale, le poți păstra sau șterge:
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

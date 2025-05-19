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
    public partial class RoomPanel : Form
    {
        public RoomPanel()
        {
            InitializeComponent();
            this.Load += RoomPanel_Load;
        }

        private void RoomPanel_Load(object sender, EventArgs e)
        {
            // momentan nu avem acțiuni la load
        }

        private void addRoomPanel_Click(object sender, EventArgs e)
        {
            // 1) Tipul camerei
            string type = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show(
                    "Tipul camerei este obligatoriu.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                richTextBox1.Focus();
                return;
            }

            // 2) Prețul
            if (!double.TryParse(richTextBox2.Text.Trim(), out double price) || price < 0)
            {
                MessageBox.Show(
                    "Preț invalid. Introdu o valoare numerică ≥ 0.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                richTextBox2.Focus();
                return;
            }

            // 3) Adăugăm camera
            var room = new Room
            {
                Type = type,
                Status = RoomStatus.ReadyToBook,
                Price = price
            };
            RoomService.Add(room);

            MessageBox.Show(
                "Camera a fost adăugată cu succes!",
                "Succes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Reset UI
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox1.Focus();
        }

        private void removeRoomPanel_Click(object sender, EventArgs e)
        {
            // 1) Citim ID-ul
            string idText = idRoomPanel.Text.Trim();
            if (!int.TryParse(idText, out int id) || id <= 0)
            {
                MessageBox.Show(
                    "Introduceți un ID numeric valid (>0).",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                idRoomPanel.Focus();
                return;
            }

            // 2) Ștergem camera și reindexăm
            RoomService.Remove(id);

            MessageBox.Show(
                $"Camera cu ID {id} a fost ștearsă și restul s-au reindexat corespunzător.",
                "Ștergere reușită",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Reset UI
            idRoomPanel.Clear();
            idRoomPanel.Focus();
        }

        private void backRoomPanel_Click(object sender, EventArgs e)
        {
            // Înapoi la Home
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        // Handler-e generate de Designer (le puteți șterge dacă nu le folosiți)
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void richTextBox2_TextChanged(object sender, EventArgs e) { }
        private void idRoomPanel_TextChanged(object sender, EventArgs e) { }
    }
}


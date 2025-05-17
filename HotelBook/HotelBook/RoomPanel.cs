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
        }

        private void RoomPanel_Load(object sender, EventArgs e)
        {
            // nu facem nimic aici pentru moment
        }

        private void addRoomPanel_Click(object sender, EventArgs e)
        {
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

            // creăm și salvăm camera
            var room = new Room
            {
                Type = type,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);

            // **Alertă de succes**:
            MessageBox.Show(
                "Camera a fost adăugată cu succes!",
                "Succes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            richTextBox1.Clear();
            richTextBox1.Focus();
        }


        private void backRoomPanel_Click(object sender, EventArgs e)
        {
            // Navigăm înapoi la Home
            Hide();
            using (var home = new Home())
            {
                home.ShowDialog(this);
            }
            Close();
        }

        // dacă ai generat accident în Designer, poţi lăsa goale:
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }

    }
}

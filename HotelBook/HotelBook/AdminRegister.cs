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
        public AdminRegister()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new[]
            {
                Role.Admin.ToString(),
                Role.Cleaner.ToString(),
                Role.Receptionist.ToString()
            });
            comboBox1.SelectedIndex = 0;
        }


        private void AdminRegister_Load(object sender, EventArgs e)
        {
            // Dacă nu ai nimic special de făcut la Load, las-o goală.
        }


        private void submitAdminRegister_Click(object sender, EventArgs e)
        {
            // 1. Validare câmpuri
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

            // 2. Verificare username duplicat
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

            // 3. Parse role
            if (!Enum.TryParse<Role>(
                    comboBox1.SelectedItem.ToString(),
                    true,
                    out Role rol))
                rol = Role.Admin;


            // 4. Adaug în baza SQLite
            var emp = new Employee
            {
                FirstName = first,
                LastName = last,
                Username = user,
                Password = pass,
                Role = rol
            };
            EmployeeService.Add(emp);

            // 5. Feedback
            MessageBox.Show(
                "S-a adăugat partenerul cu succes",
                "Succes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // 6. NU mai închide formularul! În schimb, golește câmpurile ca să poți introduce alt angajat:
            ClearForm();
            richTextBox1.Focus();
        }

        private void ClearForm()
        {
            richTextBox1.Clear();   // FirstName
            richTextBox2.Clear();   // LastName
            richTextBox3.Clear();   // Username
            richTextBox4.Clear();   // Password
            comboBox1.SelectedIndex = 0; // Reset la primul element (Admin)
        }


        private void backAdminRegister_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


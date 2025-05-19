using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelBook.Domain;     //  DLL-ul Domain
using HotelBook.Services;   //  DLL-ul Services

namespace HotelBook
{
    public partial class LogIn : Form
    {
        
        public LogIn()
        {
            InitializeComponent();
            // setări vizuale pentru password box
            richTextBox2.Multiline = false;
            richTextBox2.SelectionProtected = true;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // dacă ai nevoie de vreun init, pune-l aici
        }

        private void loginLogIn_Click(object sender, EventArgs e)
        {
            string user = richTextBox1.Text.Trim();
            string pass = richTextBox2.Text.Trim();

            // Căutăm în baza de date un angajat cu username + password
            var emp = EmployeeService
                .GetAll()
                .FirstOrDefault(x =>
                    x.Username.Equals(user, StringComparison.OrdinalIgnoreCase)
                    && x.Password == pass
                );

            if (emp == null)
            {
                MessageBox.Show(
                    "Invalid credentials!",
                    "Authentication error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                richTextBox2.Clear();
                richTextBox1.Focus();
                return;
            }

            // Înregistrăm sesiunea cu rolul găsit
            SessionManager.Login(new User(emp.Username, emp.Role));

            // Navigăm la Home
            Hide();
            using (var home = new Home())
            {
                home.ShowDialog(this);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

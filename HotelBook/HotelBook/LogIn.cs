using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            // ascund vizual parola – RichTextBox n-are PasswordChar,
            // dar putem dezactiva ScrollBars & selectare:
            richTextBox2.Multiline = false;
            richTextBox2.SelectionProtected = true;
        }

        // LogIn.cs  (în aceeaşi clasă LogIn, sub constructor)
        private void LogIn_Load(object sender, EventArgs e)
        {
            // Dacă nu ai nimic de făcut la încărcare, las-o goală.
        }


        /// <summary>
        /// Click pe butonul LOG IN
        /// </summary>
        private void loginLogIn_Click(object sender, EventArgs e)
        {
            string user = richTextBox1.Text.Trim();
            string pass = richTextBox2.Text.Trim();

            //  TODO: înlocuiește cu verificare în B.D. când vei avea repository.
            bool isAdmin = user.Equals("admin", StringComparison.OrdinalIgnoreCase)
                           && pass == "admin";

            if (isAdmin)
            {
                // setăm sesiunea şi rolul
                SessionManager.Login(new User(user, Role.Admin));

                Hide();                 // ascundem LogIn
                using (var home = new Home())
                {
                    home.ShowDialog();  // rulăm Home modal
                }
                Close();                // închidem LogIn după ce Home dispare
            }
            else
            {
                MessageBox.Show("Invalid credentials!",
                                "Authentication error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // opţional: curăţăm câmpul parolă
                richTextBox2.Clear();
                richTextBox2.Focus();
            }
        }
    }
}


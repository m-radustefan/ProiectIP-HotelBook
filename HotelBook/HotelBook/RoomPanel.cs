/**************************************************************************
 *                                                                        *
 *  File:        RoomPanel.cs                                             *
 *  Copyright:   (c) 2025, Bardasu Alexandru Ioan                         *
 *  E-mail:      alexandru-ioan.bardasu@student.tuiasi.ro                 *
 *  Description: Acest fișier definește formularul RoomPanel, care        *
 *  permite adăugarea și ștergerea camerelor din aplicația de gestionare  *
 *  a rezervărilor hoteliere. Interfața grafică oferă controale pentru    *
 *  introducerea tipului și prețului camerei, precum și pentru eliminarea *
 *  unei camere după ID,                                                  *
 *  cu validări și mesaje de feedback pentru utilizator.                  *
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
    public partial class RoomPanel : Form
    {    
        // Constructorul formularului – initializeaza componenta si ataseaza handler-ul de Load

        public RoomPanel()
        {
            InitializeComponent();
            this.Load += RoomPanel_Load;
            helpToolStripMenuItem.Click += HelpToolStripMenuItem_Click;
            despreToolStripMenuItem.Click += DespreToolStripMenuItem_Click;
        }
        // Handler apelat la incarcarea formularului – poate fi folosit pentru initializari viitoare

        private void RoomPanel_Load(object sender, EventArgs e)
        {
            
        }
        // Butonul "Adauga camera" – valideaza inputul si adauga o camera noua

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

            // Verifica daca pretul introdus este numeric si pozitiv

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

            // Creeaza si adauga camera

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

            
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox1.Focus();
        }
        // Butonul "Sterge camera" – valideaza ID-ul si sterge camera respectiva

        private void removeRoomPanel_Click(object sender, EventArgs e)
        {
            
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

            // Sterge camera si afiseaza mesaj de confirmare

            RoomService.Remove(id);

            MessageBox.Show(
                $"Camera cu ID {id} a fost ștearsă și restul s-au reindexat corespunzător.",
                "Ștergere reușită",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Curata campul de input

            idRoomPanel.Clear();
            idRoomPanel.Focus();
        }
        // Butonul "Back" – revine la ecranul principal

        private void backRoomPanel_Click(object sender, EventArgs e)
        {
            
            Hide();
            using (var home = new Home())
                home.ShowDialog(this);
            Close();
        }

        // Handlere neutilizate pentru evenimente TextChanged – lasate goale intentionat

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void richTextBox2_TextChanged(object sender, EventArgs e) { }
        private void idRoomPanel_TextChanged(object sender, EventArgs e) { }

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


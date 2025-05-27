using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBook
{
    internal static class Program
    {
        // Atribut necesar pentru aplicatii Windows Forms (permite rularea in modul single-threaded pentru UI)

        [STAThread]                 
        private static void Main()
        {
            // Activeaza stiluri vizuale moderne pentru controalele Windows Forms

            Application.EnableVisualStyles();
            // Seteaza randarea textului pentru compatibilitate cu vechiul motor GDI

            Application.SetCompatibleTextRenderingDefault(false);
            // Ruleaza aplicatia incepand cu fereastra de logare


            Application.Run(new LogIn());  
        }
    }
}

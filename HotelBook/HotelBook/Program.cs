using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBook
{
    internal static class Program
    {
        [STAThread]                 // necesar pentru WinForms
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // PORNEȘTE aplicația – alege formularul inițial
            Application.Run(new LogIn());   // sau new Home(), după cum decizi
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProgram
{
    static class Program
    {
        public static string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=C:\\work\\Data.mdb";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=C:\\Users\\tumur\\Documents\\Database1.mdb";
            //Application.Run(new MainForm());
            Application.Run(new ExamForm());
        }
    }
}

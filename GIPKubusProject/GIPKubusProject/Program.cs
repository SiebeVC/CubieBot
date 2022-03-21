using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace GIPKubusProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] waardes;
            waardes = DatabaseMethods.DatabaseRead("select [Username] from [tblLast]");

            string user = waardes[0];

            Application.Run(new KubusSolverForm(user));
        }
    }
}

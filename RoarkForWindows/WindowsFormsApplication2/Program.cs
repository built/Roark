using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static DateTime expires = DateTime.Parse("09/30/2008");
        const string expirationMsg = "This version of Roark is OLD.\nYou can keep using it, but there's probably a new version out.\nVisit the Roark website for a new version. Thanks!";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (DateTime.Now > expires) MessageBox.Show(expirationMsg, "Warning: Old Version");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainEditor());
        }
    }
}

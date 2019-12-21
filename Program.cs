using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Boolean desktop_launch = false;
            if(args.Length > 0)
            {
                if(args[0].Equals("-desktop"))
                {
                    desktop_launch = true;
                }
            }
            Application.Run(new MainCalendar(desktop_launch));
        }
    }
}

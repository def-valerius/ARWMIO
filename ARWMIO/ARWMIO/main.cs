using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ARWMIO
{
    static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            formMain formMain01 = new formMain();
            if (args.Length == 2)
            {
                formMain01.setParameters(args[0] == "-a", args[1]);
                //"debug" MessageBox.Show(args[0] + ". no of args: " + args.Length.ToString());
            }

            Application.Run(formMain01);
        }
    }
}

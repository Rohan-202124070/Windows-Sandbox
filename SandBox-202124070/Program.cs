using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBox_202124070
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool terminateExcution = false;

            if (args.Length == 0)
            {
                Application.Run(new InitFormWin());
            }
            else
            {
                do
                {
                    terminateExcution = true;
                    CommandExcution commandExcution = new CommandExcution();
                    commandExcution.excuteCommands(args);
                } while (!terminateExcution);
            }

        }
    }
}

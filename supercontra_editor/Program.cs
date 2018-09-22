using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace contra_editor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
#if DEBUG
            Environment.CurrentDirectory = "..\\Release";
#endif
            if (Form1.RunChecks()) return;
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

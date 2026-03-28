using System;
using System.Windows.Forms;

namespace UserInterface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MainForm mainForm;

            ApplicationConfiguration.Initialize();
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
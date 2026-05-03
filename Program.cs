using System;
using System.Windows.Forms;

namespace LinguaSeries
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var splash = new Forms.SplashForm())
            {
                splash.ShowDialog();
            }

            Application.Run(new Forms.WelcomeForm());
        }
    }
}

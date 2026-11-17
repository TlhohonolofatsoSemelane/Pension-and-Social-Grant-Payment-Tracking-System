using System;
using System.Windows.Forms;
using PensionGrantTracker.Views;

namespace PensionGrantTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            bool again = true;
            while (again)
            {
                LoginForm login = new LoginForm();
                if (login.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                MainForm main = new MainForm(login.LoggedInUser);
                main.ShowDialog();
                again = main.LoggedOut;
            }
        }
    }
}

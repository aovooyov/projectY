using System.Windows;

namespace YDirect
{
    partial class App : Application
    {
        public void ApplicationStart(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var loginWindow = new StartWindow();

            if (loginWindow.ShowDialog() != true)
                return;

            var mainWindow = new MainWindow();
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}

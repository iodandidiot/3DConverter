using System;
using System.Windows;
using Autofac;

namespace _3DConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContainer _container;


        public App()
        {
            var bootstrapper = new Bootstrapper();
            _container = bootstrapper.Bootstrap();
        }


        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _container.Resolve<MainWindow>();
            //this.Resources.Add("MainViewModel", mainViewModel);
            mainWindow.Show();
        }
    }
}
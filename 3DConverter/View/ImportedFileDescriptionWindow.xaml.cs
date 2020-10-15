using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _3DConverter
{
    /// <summary>
    /// Interaction logic for FileDescriptionWindow.xaml
    /// </summary>
    public partial class ImportedFileDescriptionWindow : Window
    {
        private readonly MainWindow _mainWindow;

        public ImportedFileDescriptionWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _mainWindow.Closed += MainWindowClosed;
            InitializeComponent();
        }

        private void MainWindowClosed(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
using System.Linq;
using System.Windows;

namespace _3DConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly IDropFileHandler _dropFileHandler;

        public MainWindow(MainViewModel viewModel, IDropFileHandler dropFileHandler)
        {
            _viewModel = viewModel;
            _dropFileHandler = dropFileHandler;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void FileDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            var file = (string[]) e.Data.GetData(DataFormats.FileDrop);

            if (file?.FirstOrDefault() != null)
            {
                _viewModel.DropFile(await _dropFileHandler.GetFileDropAsync(file.First()));
            }
        }
    }
}
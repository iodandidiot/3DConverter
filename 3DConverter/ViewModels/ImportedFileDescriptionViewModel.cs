using System;
using System.Windows.Media;

namespace _3DConverter.ViewModels
{
    public class ImportedFileDescriptionViewModel : FileDescriptionViewModelBase
    {
        private readonly Func<ImportedFileDescriptionWindow> _fileDescriptionWindowFunc;
        private ImportedFileModel _importedFileModel;
        private RelayCommand _deleteFileCommand;
        private ImportedFileDescriptionWindow _fileDescriptionWindow;


        public override string FileOriginalPath => _importedFileModel.FileOriginalPath;

        public override string FileName => _importedFileModel.FileName;

        public int ConvertedCount => _importedFileModel.ConvertedCount;

        public override Brush Background => Brushes.IndianRed;

        public override RelayCommand DeleteFileCommand
        {
            get { return _deleteFileCommand ??= new RelayCommand(obj => { _importedFileModel.DeleteFile(); }); }
        }


        public ImportedFileDescriptionViewModel(Func<ImportedFileDescriptionWindow> fileDescriptionWindowFunc)
        {
            _fileDescriptionWindowFunc = fileDescriptionWindowFunc;
        }

        protected override void OnClosed(object? sender, EventArgs e)
        {
            _importedFileModel.FileDeleted -= OnFileModelDeleted;
        }

        public void OpenFileDescription(ImportedFileModel importedFileModel)
        {
            _importedFileModel = importedFileModel;
            _importedFileModel.FileDeleted += OnFileModelDeleted;

            _fileDescriptionWindow = _fileDescriptionWindowFunc();
            _fileDescriptionWindow.DataContext = this;
            _fileDescriptionWindow.Show();
        }

        private void OnFileModelDeleted()
        {
            _fileDescriptionWindow?.Close();
        }
    }
}
using System;
using System.Windows.Media;
using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public class ConvertedFileDescriptionViewModel : FileDescriptionViewModelBase
    {
        private IConvertibleFile _convertibleFile;
        private float _progress;
        private RelayCommand _deleteFileCommand;
        private readonly Func<ConvertedFileDescriptionWindow> _fileDescriptionWindowFunc;
        private ConvertedFileDescriptionWindow _fileDescriptionWindow;


        public override string FileOriginalPath => _convertibleFile.FileOriginalPath;

        public override string FileName => _convertibleFile.FileName;

        public override Brush Background => Brushes.DarkSeaGreen;

        public override RelayCommand DeleteFileCommand
        {
            get { return _deleteFileCommand ??= new RelayCommand(obj => { _convertibleFile.DeleteFile(); }); }
        }

        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public ConvertedFileDescriptionViewModel(Func<ConvertedFileDescriptionWindow> fileDescriptionWindowFunc)
        {
            _fileDescriptionWindowFunc = fileDescriptionWindowFunc;
        }

        protected override void OnClosed(object? sender, EventArgs e)
        {
            _convertibleFile.UpdateProgress -= OnUpdateProgress;
            _convertibleFile.FileDeleted -= OnFileDeleted;
        }

        public void OpenFileDescription(IConvertibleFile convertibleFile)
        {
            _convertibleFile = convertibleFile;
            _convertibleFile.UpdateProgress += OnUpdateProgress;
            _convertibleFile.FileDeleted += OnFileDeleted;

            _fileDescriptionWindow = _fileDescriptionWindowFunc();
            _fileDescriptionWindow.Closed += OnClosed;
            _fileDescriptionWindow.DataContext = this;
            _fileDescriptionWindow.Show();
        }

        private void OnFileDeleted()
        {
            _fileDescriptionWindow?.Close();
        }

        private void OnUpdateProgress(float value)
        {
            Progress = value;
        }
    }
}
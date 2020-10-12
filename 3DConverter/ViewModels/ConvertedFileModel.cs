using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public class ConvertedFileViewModel : ViewModelBase
    {
        private readonly FileDescriptionViewModel _fileDescriptionWindow;
        private readonly IConvertibleFile _convertibleFile;
        private float _progress;
        private RelayCommand _addCommand;

        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public string FileType => _convertibleFile.FileType;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    _fileDescriptionWindow.OpenFileDescription(_convertibleFile);
                });
            }
        }

        public ConvertedFileViewModel(IConvertibleFile convertibleFile, FileDescriptionViewModel fileDescriptionWindow)
        {
            _convertibleFile = convertibleFile;
            _fileDescriptionWindow = fileDescriptionWindow;
            _convertibleFile.UpdateProgress += OnUpdateProgress;
        }

        private void OnUpdateProgress(float value)
        {
            Progress = value;
        }
    }
}
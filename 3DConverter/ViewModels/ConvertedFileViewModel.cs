using System;
using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public class ConvertedFileViewModel : ViewModelBase
    {
        private readonly ConvertedFileDescriptionViewModel _convertedFileDescriptionWindow;
        private IConvertibleFile _convertibleFile;
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

        public string FileType => _convertibleFile.FileName;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    _convertedFileDescriptionWindow.OpenFileDescription(_convertibleFile);
                });
            }
        }

        public event Action<ConvertedFileViewModel> FileDeleted;

        public ConvertedFileViewModel(ConvertedFileDescriptionViewModel convertedFileDescriptionWindow)
        {
            _convertedFileDescriptionWindow = convertedFileDescriptionWindow;
        }

        public ConvertedFileViewModel WithModel(IConvertibleFile convertibleFile)
        {
            _convertibleFile = convertibleFile;
            _convertibleFile.UpdateProgress += OnUpdateProgress;
            _convertibleFile.FileDeleted += () => FileDeleted?.Invoke(this);
            return this;
        }

        private void OnUpdateProgress(float value)
        {
            Progress = value;
        }
    }
}
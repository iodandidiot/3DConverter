using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public class FileDescriptionViewModel : ViewModelBase
    {
        private IConvertibleFile _convertibleFile;
        private float _progress;

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


        public void OpenFileDescription(IConvertibleFile convertibleFile)
        {
            _convertibleFile = convertibleFile;
            var taskWindow = new FileDescriptionWindow {DataContext = this};
            taskWindow.Show();
        }
    }
}
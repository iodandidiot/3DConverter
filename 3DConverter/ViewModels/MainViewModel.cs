using System.Collections.ObjectModel;
using _3DConverter.Converter.ConvertibleFiles;
using _3DConverter.ViewModels;

namespace _3DConverter
{
    public class MainViewModel : ViewModelBase
    {
        private readonly FileDescriptionViewModel _fileDescription;
        private readonly IFileViewModelFactory _viewModelFactory;

        public ObservableCollection<ConvertedFileViewModel> ConvertedFileModels { get; set; }

        public ObservableCollection<ImportedFileViewModel> ImportedFileModels { get; set; }

        public MainViewModel(FileDescriptionViewModel fileDescription, IFileViewModelFactory viewModelFactory)
        {
            _fileDescription = fileDescription;
            _viewModelFactory = viewModelFactory;
            ImportedFileModels = new ObservableCollection<ImportedFileViewModel>();
            ConvertedFileModels = new ObservableCollection<ConvertedFileViewModel>
                {new ConvertedFileViewModel(new StepConvertibleFile(), fileDescription)};
        }


        public void DropFile(DropFileModel model)
        {
            ImportedFileModels.Add(_viewModelFactory.CreateImportedFileModels(model));
        }
    }
}
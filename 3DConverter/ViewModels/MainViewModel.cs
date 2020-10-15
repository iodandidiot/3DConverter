using System.Collections.ObjectModel;
using _3DConverter.Converter;
using _3DConverter.ConverterModule;

namespace _3DConverter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFileViewModelFactory _viewModelFactory;
        private readonly IConvertedFileFactory _convertedFileFactory;
        private bool _stepChecked;
        private bool _stlChecked;
        private bool _objChecked;

        private ConvertType _convertType = ConvertType.Step;

        public ObservableCollection<ConvertedFileViewModel> ConvertedFileModels { get; set; }

        public ObservableCollection<ImportedFileViewModel> ImportedFileModels { get; set; }

        public bool StepChecked
        {
            get => _stepChecked;
            set
            {
                if (value)
                {
                    _convertType = ConvertType.Step;
                    StlChecked = false;
                    ObjChecked = false;
                }

                _stepChecked = value;
                OnPropertyChanged();
            }
        }

        public bool StlChecked
        {
            get => _stlChecked;
            set
            {
                if (value)
                {
                    _convertType = ConvertType.Stl;
                    StepChecked = false;
                    ObjChecked = false;
                }

                _stlChecked = value;
                OnPropertyChanged();
            }
        }

        public bool ObjChecked
        {
            get => _objChecked;
            set
            {
                if (value)
                {
                    _convertType = ConvertType.Obj;
                    StlChecked = false;
                    StepChecked = false;
                }

                _objChecked = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(
            IFileViewModelFactory viewModelFactory,
            IConvertedFileFactory convertedFileFactory)
        {
            _viewModelFactory = viewModelFactory;
            _convertedFileFactory = convertedFileFactory;
            ImportedFileModels = new ObservableCollection<ImportedFileViewModel>();
            ConvertedFileModels = new ObservableCollection<ConvertedFileViewModel>();
            _stepChecked = true;
        }


        public void DropFile(ImportedFileModel model)
        {
            var importedFileViewModel = _viewModelFactory.CreateImportedFileModel(model);
            importedFileViewModel.ConvertClicked += OnConvertClicked;
            ImportedFileModels.Add(importedFileViewModel);

            importedFileViewModel.FileDeleted += OnImportedFileDeleted;
        }

        private void OnImportedFileDeleted(ImportedFileViewModel viewModel)
        {
            viewModel.FileDeleted -= OnImportedFileDeleted;
            ImportedFileModels.Remove(viewModel);
        }

        private void OnConvertClicked(ImportedFileModel model, ImportedFileViewModel importedFileViewModel)
        {
            var convertedFile = _convertedFileFactory.GetConvertibleFile(model, _convertType);

            void SubscribeAction(float p)
            {
                if (p >= 100)
                {
                    convertedFile.UpdateProgress -= SubscribeAction;
                }

                importedFileViewModel.OnProgress(p);
            }

            convertedFile.UpdateProgress += SubscribeAction;

            var convertedFileViewModel = _viewModelFactory.CreateConvertedFileViewModel(convertedFile);
            convertedFileViewModel.FileDeleted += OnConvertFileDeleted;
            ConvertedFileModels.Add(convertedFileViewModel);
        }

        private void OnConvertFileDeleted(ConvertedFileViewModel model)
        {
            model.FileDeleted -= OnConvertFileDeleted;
            ConvertedFileModels.Remove(model);
        }
    }
}
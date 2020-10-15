using System;
using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public class FileViewModelFactory : IFileViewModelFactory
    {
        private readonly Func<ImportedFileViewModel> _importedFileViewModel;
        private readonly Func<ConvertedFileViewModel> _convertedFileViewModel;

        public FileViewModelFactory(Func<ImportedFileViewModel> importedFileViewModel,
            Func<ConvertedFileViewModel> convertedFileViewModel)
        {
            _importedFileViewModel = importedFileViewModel;
            _convertedFileViewModel = convertedFileViewModel;
        }

        public ImportedFileViewModel CreateImportedFileModel(ImportedFileModel model)
        {
            return _importedFileViewModel.Invoke().WithModel(model);
        }

        public ConvertedFileViewModel CreateConvertedFileViewModel(IConvertibleFile model)
        {
            return _convertedFileViewModel.Invoke().WithModel(model);
        }
    }
}
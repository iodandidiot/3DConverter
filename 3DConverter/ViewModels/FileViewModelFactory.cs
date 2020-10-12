using System;

namespace _3DConverter.ViewModels
{
    public class FileViewModelFactory : IFileViewModelFactory
    {
        private readonly Func<ImportedFileViewModel> _importedFileViewModel;

        public FileViewModelFactory(Func<ImportedFileViewModel> importedFileViewModel)
        {
            _importedFileViewModel = importedFileViewModel;
        }

        public ImportedFileViewModel CreateImportedFileModels(DropFileModel model)
        {
            return _importedFileViewModel.Invoke().WithModel(model);
        }
    }
}
namespace _3DConverter.ViewModels
{
    public interface IFileViewModelFactory
    {
        ImportedFileViewModel CreateImportedFileModels(ImportedFileModel model);
    }
}
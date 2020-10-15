using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ViewModels
{
    public interface IFileViewModelFactory
    {
        ImportedFileViewModel CreateImportedFileModel(ImportedFileModel model);
        ConvertedFileViewModel CreateConvertedFileViewModel(IConvertibleFile model);
    }
}
using System.Threading.Tasks;

namespace _3DConverter
{
    public interface IDropFileHandler
    {
        Task<ImportedFileModel> GetFileDropAsync(string dropFile);
    }
}
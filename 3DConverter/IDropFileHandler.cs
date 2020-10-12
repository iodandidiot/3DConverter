using System.Threading.Tasks;

namespace _3DConverter
{
    public interface IDropFileHandler
    {
        Task<DropFileModel> GetFileDropAsync(string dropFile);
    }
}
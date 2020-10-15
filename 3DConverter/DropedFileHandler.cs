using System.IO;
using System.Threading.Tasks;

namespace _3DConverter
{
    public class DropFileHandler : IDropFileHandler
    {
        private const string FilePattern = ".shapr";

        public async Task<ImportedFileModel> GetFileDropAsync(string dropFile)
        {
            if (!dropFile.EndsWith(FilePattern))
                return null;

            byte[] result;

            await using (var sourceStream = File.Open(dropFile, FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int) sourceStream.Length).ConfigureAwait(false);
            }

            return new ImportedFileModel(Path.GetFileName(dropFile), result, dropFile);
        }
    }
}
namespace _3DConverter
{
    public class ImportedFileModel
    {
        public string FileName { get; }
        public byte[] Result { get; }

        public ImportedFileModel(string fileName, byte[] result)
        {
            FileName = fileName;
            Result = result;
        }
    }
}
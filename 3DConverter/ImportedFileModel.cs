using System;
using _3DConverter.Converter;

namespace _3DConverter
{
    public class ImportedFileModel : IDeletableModel
    {
        public string FileName { get; }
        public byte[] Result { get; }
        public string FileOriginalPath { get; }

        public int ConvertedCount { get; private set; }

        public ConvertProcessType ConvertProcessType { get; private set; }

        public event Action FileDeleted;
        public event Action<ConvertProcessType> ConvertProcessTypeChanged;

        public ImportedFileModel(string fileName, byte[] result, string fileOriginalPath)
        {
            FileName = fileName;
            Result = result;
            FileOriginalPath = fileOriginalPath;
        }

        public void DeleteFile()
        {
            FileDeleted?.Invoke();
        }

        public void ChangeConvertProcessType(ConvertProcessType type)
        {
            ConvertProcessType = type;
            ConvertProcessTypeChanged?.Invoke(type);

            if (type == ConvertProcessType.End)
            {
                ConvertedCount++;
            }
        }
    }
}
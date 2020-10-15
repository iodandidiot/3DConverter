using System;

namespace _3DConverter.Converter.ConvertibleFiles
{
    public interface IConvertibleFile : IDeletableModel
    {
        void Convert();

        event Action<float> UpdateProgress;

        string FileName { get; }

        string FileOriginalPath { get; }
    }
}
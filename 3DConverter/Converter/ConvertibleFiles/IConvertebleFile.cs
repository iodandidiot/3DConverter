using System;

namespace _3DConverter.Converter.ConvertibleFiles
{
    public interface IConvertibleFile
    {
        void Convert();

        event Action<float> UpdateProgress;

        string FileType { get; }
    }
}
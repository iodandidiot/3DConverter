using System.Threading.Tasks;
using _3DConverter.Converter;
using _3DConverter.Converter.ConvertibleFiles;

namespace _3DConverter.ConverterModule
{
    public interface IConvertedFileFactory
    {
        IConvertibleFile GetConvertibleFile(ImportedFileModel fileModel, ConvertType type);
    }
}
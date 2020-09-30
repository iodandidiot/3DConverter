using System.Threading.Tasks;
using _3DConverter.ConverterModule.ConvertibleFiles;

namespace _3DConverter.ConverterModule
{
    public interface IConverter
    {
        Task ConvertAsync(IConvertibleFile file);
    }
}
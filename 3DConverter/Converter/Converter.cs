using System.Threading.Tasks;
using _3DConverter.ConverterModule;
using _3DConverter.ConverterModule.ConvertibleFiles;

namespace _3DConverter.Converter
{
    public class Converter : IConverter
    {
        public Task ConvertAsync(IConvertibleFile file)
        {
            return file.ConvertAsync;
        }
    }
}

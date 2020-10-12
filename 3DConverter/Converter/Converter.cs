using System.Threading.Tasks;
using _3DConverter.Converter.ConvertibleFiles;
using _3DConverter.ConverterModule;

namespace _3DConverter.Converter
{
    public class Converter : IConverter
    {
        public Task ConvertAsync(IConvertibleFile file)
        {
            return file.ConvertAsync();
        }
    }
}

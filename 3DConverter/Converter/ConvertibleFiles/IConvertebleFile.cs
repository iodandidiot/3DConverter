using System.Threading.Tasks;

namespace _3DConverter.ConverterModule.ConvertibleFiles
{
    public interface IConvertibleFile
    {
        Task ConvertAsync { get; set; }
    }
}

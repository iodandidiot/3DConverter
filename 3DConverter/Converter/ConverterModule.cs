using _3DConverter.ConverterModule;
using Autofac;

namespace _3DConverter.Converter
{
    public class ConverterModule : Module
    {
        protected override void Load(ContainerBuilder container)
        {
            container.RegisterType<ConvertedFileFactory>().As<IConvertedFileFactory>();
        }
    }
}
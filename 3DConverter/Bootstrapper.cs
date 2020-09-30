using Autofac;

namespace _3DConverter
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
        }

        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterModule<Converter.ConverterModule>();

            return builder.Build();
        }
    }
}
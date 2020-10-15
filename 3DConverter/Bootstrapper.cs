using _3DConverter.ViewModels;
using Autofac;

namespace _3DConverter
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterType<ImportedFileDescriptionWindow>().ExternallyOwned();
            builder.RegisterType<ConvertedFileDescriptionWindow>().ExternallyOwned();
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<ConvertedFileDescriptionViewModel>().SingleInstance();
            builder.RegisterType<ImportedFileDescriptionViewModel>().SingleInstance();
            builder.RegisterType<DropFileHandler>().As<IDropFileHandler>().ExternallyOwned();
            builder.RegisterType<ImportedFileViewModel>().ExternallyOwned();
            builder.RegisterType<ConvertedFileViewModel>().ExternallyOwned();
            builder.RegisterType<FileViewModelFactory>().As<IFileViewModelFactory>().SingleInstance();

            builder.RegisterModule<Converter.ConverterModule>();

            return builder.Build();
        }
    }
}
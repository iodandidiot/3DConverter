using _3DConverter.Converter.ConvertibleFiles;
using _3DConverter.ConverterModule;

namespace _3DConverter.Converter
{
    public class ConvertedFileFactory : IConvertedFileFactory
    {
        public IConvertibleFile GetConvertibleFile(ImportedFileModel fileModel, ConvertType type)
        {
            var convertible = type switch
            {
                ConvertType.Step => (IConvertibleFile) new StepConvertibleFile(fileModel),
                ConvertType.Stl => new StlConvertibleFile(fileModel),
                ConvertType.Obj => new ObjConvertibleFile(fileModel),
                _ => new StepConvertibleFile(fileModel)
            };

            convertible.Convert();
            return convertible;
        }
    }
}
namespace _3DConverter.Converter.ConvertibleFiles
{
    public class ObjConvertibleFile : ConvertibleFileBase
    {
        public override string FileName { get; }
        protected override int ConvertDelay => 10;

        public ObjConvertibleFile(ImportedFileModel fileModel) : base(fileModel)
        {
            FileName = fileModel.FileName.Replace(".shapr", ".obj");
        }
    }
}
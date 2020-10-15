namespace _3DConverter.Converter.ConvertibleFiles
{
    public class StlConvertibleFile : ConvertibleFileBase
    {
        public override string FileName { get; }
        protected override int ConvertDelay => 50;

        public StlConvertibleFile(ImportedFileModel fileModel) : base(fileModel)
        {
            FileName = fileModel.FileName.Replace(".shapr", ".stl");
        }
    }
}
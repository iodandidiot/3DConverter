namespace _3DConverter.Converter.ConvertibleFiles
{
    public class StepConvertibleFile : ConvertibleFileBase
    {
        public override string FileName { get; }
        protected override int ConvertDelay => 100;

        public StepConvertibleFile(ImportedFileModel fileModel) : base(fileModel)
        {
            FileName = fileModel.FileName.Replace(".shapr", ".step");
        }
    }
}
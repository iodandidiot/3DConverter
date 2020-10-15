using System;
using System.Threading;
using System.Threading.Tasks;

namespace _3DConverter.Converter.ConvertibleFiles
{
    public abstract class ConvertibleFileBase : IConvertibleFile, IDisposable
    {
        private float _progress;
        private readonly ImportedFileModel _fileModel;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public abstract string FileName { get; }

        public string FileOriginalPath => _fileModel.FileOriginalPath;
        protected abstract int ConvertDelay { get; }

        public event Action<float> UpdateProgress;
        public event Action FileDeleted;

        protected ConvertibleFileBase(ImportedFileModel fileModel)
        {
            _fileModel = fileModel;
            _fileModel.FileDeleted += OnDeleted;
        }

        private void OnDeleted()
        {
            if (_progress < 100)
            {
                DeleteFile();
            }
        }

        public async void Convert()
        {
            _fileModel.ChangeConvertProcessType(ConvertProcessType.Start);
            await ConvertInternalAsync();
        }

        private async Task ConvertInternalAsync()
        {
            var progressByte = 100f / _fileModel.Result.Length;

            foreach (var _ in _fileModel.Result)
            {
                await Task.Delay(ConvertDelay);

                if (_cts.IsCancellationRequested)
                    return;

                _progress += progressByte;
                UpdateProgress?.Invoke(_progress);
            }

            _fileModel.FileDeleted -= OnDeleted;
            _fileModel.ChangeConvertProcessType(ConvertProcessType.End);
        }

        public void DeleteFile()
        {
            if (_progress < 100)
            {
                _fileModel.ChangeConvertProcessType(ConvertProcessType.Cancel);
            }

            FileDeleted?.Invoke();
            _fileModel.FileDeleted -= OnDeleted;
            _cts.Cancel();
        }

        public void Dispose()
        {
            DeleteFile();
        }
    }
}
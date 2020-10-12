using System;
using System.Threading;
using System.Threading.Tasks;

namespace _3DConverter.Converter.ConvertibleFiles
{
    public class StepConvertibleFile : IConvertibleFile, IDisposable
    {
        private float _progress;
        private readonly ImportedFileModel _fileModel;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public event Action<float> UpdateProgress;

        public string FileType { get; }

        public StepConvertibleFile(ImportedFileModel fileModel)
        {
            _fileModel = fileModel;
        }

        public async void Convert()
        {
            await ConvertAsync();
        }

        private async Task ConvertAsync()
        {
            var progressByte = 100 / _fileModel.Result.Length;

            foreach (var b in _fileModel.Result)
            {
                await Task.Delay(100);

                if (_cts.IsCancellationRequested)
                    return;

                _progress += progressByte;
                UpdateProgress?.Invoke(_progress);
            }
        }

        public void Dispose()
        {
            _cts.Cancel();
        }
    }
}
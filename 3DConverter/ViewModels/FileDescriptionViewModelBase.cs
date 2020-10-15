using System;
using System.Windows.Media;

namespace _3DConverter.ViewModels
{
    public abstract class FileDescriptionViewModelBase : ViewModelBase
    {

        public abstract string FileOriginalPath { get; }
        public abstract string FileName { get; }
        public abstract Brush Background { get; }
        public abstract RelayCommand DeleteFileCommand { get; }


        protected abstract void OnClosed(object? sender, EventArgs e);
    }
}
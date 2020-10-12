using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace _3DConverter.ViewModels
{
    public class ImportedFileViewModel : ViewModelBase
    {
        private ImportedFileModel _importedFile;
        private float _progress;
        private Visibility _progressBarEnable;
        private RelayCommand _convertCommand;

        public string FileName => _importedFile?.FileName;

        public Visibility ProgressBarVisibility
        {
            get => _progressBarEnable;
            set
            {
                _progressBarEnable = value;
                OnPropertyChanged();
            }
        }

        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ConvertCommand
        {
            get { return _convertCommand ??= new RelayCommand(obj => { ; }); }
        }

        public ImportedFileViewModel WithModel(ImportedFileModel importedFile)
        {
            ProgressBarVisibility = Visibility.Hidden;
            Progress = 90f;
            _importedFile = importedFile;

            return this;
        }
    }
}
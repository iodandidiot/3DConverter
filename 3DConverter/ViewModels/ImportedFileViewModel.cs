using System;
using System.Windows;
using _3DConverter.Converter;

namespace _3DConverter.ViewModels
{
    public class ImportedFileViewModel : ViewModelBase
    {
        private readonly ImportedFileDescriptionViewModel _descriptionViewModel;

        private ImportedFileModel _importedFile;

        private float _progress;
        private Visibility _progressBarEnable;
        private Visibility _buttonVisibility;

        private RelayCommand _convertCommand;
        private RelayCommand _descriptionCommand;


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

        public Visibility ButtonVisibility
        {
            get => _buttonVisibility;
            set
            {
                _buttonVisibility = value;
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
            get
            {
                return _convertCommand ??= new RelayCommand(obj => { ConvertClicked?.Invoke(_importedFile, this); });
            }
        }

        public RelayCommand DescriptionCommand
        {
            get
            {
                return _descriptionCommand ??= new RelayCommand(obj =>
                {
                    _descriptionViewModel.OpenFileDescription(_importedFile);
                });
            }
        }

        public event Action<ImportedFileModel, ImportedFileViewModel> ConvertClicked;
        public event Action<ImportedFileViewModel> FileDeleted;

        public ImportedFileViewModel(ImportedFileDescriptionViewModel descriptionViewModel)
        {
            _descriptionViewModel = descriptionViewModel;
        }

        public ImportedFileViewModel WithModel(ImportedFileModel importedFile)
        {
            SetProgressBarVisibility(Visibility.Hidden);
            _importedFile = importedFile;
            _importedFile.ConvertProcessTypeChanged += ConvertProcessTypeChanged;
            _importedFile.FileDeleted += OnFileDeleted;
            return this;
        }

        private void OnFileDeleted()
        {
            _importedFile.ConvertProcessTypeChanged -= ConvertProcessTypeChanged;
            _importedFile.FileDeleted -= OnFileDeleted;
            FileDeleted?.Invoke(this);
        }

        private void ConvertProcessTypeChanged(ConvertProcessType type)
        {
            switch (type)
            {
                case ConvertProcessType.Start:
                    SetButtonVisibility(Visibility.Hidden);
                    SetProgressBarVisibility(Visibility.Visible);
                    break;
                case ConvertProcessType.End:
                    SetButtonVisibility(Visibility.Visible);
                    SetProgressBarVisibility(Visibility.Hidden);
                    Progress = 0;
                    break;
                case ConvertProcessType.Cancel:
                    SetButtonVisibility(Visibility.Visible);
                    SetProgressBarVisibility(Visibility.Hidden);
                    Progress = 0;
                    break;
            }
        }

        private void SetProgressBarVisibility(Visibility visibility)
        {
            if (ProgressBarVisibility != visibility)
            {
                ProgressBarVisibility = visibility;
            }
        }

        private void SetButtonVisibility(Visibility visibility)
        {
            if (ButtonVisibility != visibility)
            {
                ButtonVisibility = visibility;
            }
        }

        public void OnProgress(float progress)
        {
            Progress = progress;
        }
    }
}
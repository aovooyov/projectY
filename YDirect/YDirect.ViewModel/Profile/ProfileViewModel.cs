using System;
using System.Windows.Forms;
using System.Windows.Input;
using YDirect.Model;

namespace YDirect.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        private string _certificateFolderPath;
        private string _profileName;
        private EventHandler _createProfile;

        public string ProfileName
        {
            get { return _profileName; }
            set
            {
                _profileName = value;
                OnPropertyChanged(() => ProfileName);
            }
        }

        public string CertificateFolderPath
        {
            get { return _certificateFolderPath; }
            set
            {
                _certificateFolderPath = value;
                OnPropertyChanged(() => CertificateFolderPath);
            }
        }

        public event EventHandler CreateProfile
        {
            add { _createProfile += value; }
            remove { _createProfile -= value; }
        }

        public ICommand CertificateFolderPathDialogCommand
        {
            get { return new RelayCommand(CertificateFolderPathDialog); }
        }

        public ICommand CreateCommand
        {
            get { return new RelayCommand(Create); }
        }

        private void CertificateFolderPathDialog()
        {
            var dialog = new FolderBrowserDialog
                         {
                             RootFolder = Environment.SpecialFolder.Desktop
                         };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CertificateFolderPath = dialog.SelectedPath;
        }

        private void Create()
        {
            if (string.IsNullOrEmpty(ProfileName))
            {
                Error("Введите имя профиля");
                return;
            }

            if (string.IsNullOrEmpty(CertificateFolderPath))
            {
                Error("Выбирете путь к папке сетификата яндекс.директ");
                return;
            }

            if (!Facade.Instance.CreatePfx(ProfileName, CertificateFolderPath))
            {
                Error("Ошибка чтения файлов или такой профиль уже существует");
                return;
            }

            ProfileName = CertificateFolderPath = string.Empty;

            if (_createProfile != null)
                _createProfile(this, EventArgs.Empty);
        }
    }
}

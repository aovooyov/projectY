using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YDirect.Model;

namespace YDirect.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _profile;
        private string _password;
        private string[] _profiles;
        private bool _sandbox;

        public string Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged(() => Profile);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(() => Password);
            }
        }

        public string[] Profiles
        {
            get
            {
                if (_profiles == null)
                    UpdateProfiles();

                return _profiles;
            }
            private set
            {
                _profiles = value;
                OnPropertyChanged(() => Profiles);
            }
        }

        public bool Sandbox
        {
            get { return _sandbox; }
            set
            {
                _sandbox = value;
                OnPropertyChanged(() => Sandbox);
                OnPropertyChanged(() => IsEnabled);
            }
        }

        public bool IsEnabled
        {
            get { return !Sandbox; }
        }

        public ICommand LoginCommand { get { return new RelayCommand(Login); } }
        public ICommand RemoveCommand { get { return new RelayCommand(Remove); } }

        private void Login()
        {
            if (IsEnabled)
            {
                if (string.IsNullOrEmpty(Profile))
                {
                    Asterisk("Выбирете профиль");
                    return;
                }

                if (string.IsNullOrEmpty(Password))
                {
                    Asterisk("Пароль то, введи!");
                    return;
                }
            }

            try
            {
                if (Sandbox)
                    Facade.Instance.Sandbox();
                else
                    Facade.Instance.Login(Profile, Password);

                DialogResult(true);
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                    Error(exception.InnerException.Message);

                Error(exception.Message);
            }
        }

        private void Remove()
        {
            if (string.IsNullOrEmpty(Profile))
            {
                Asterisk("Выбирете профиль");
                return;
            }

            if (!Confirm("Уверен в своих действиях?"))
                return;

            if (!Facade.Instance.RemoveProfile(Profile))
            {
                Error("Ошибка удаления сертификата, скорее всего файл тупо не найден - мать твою, ёпта");
                return;
            }

            UpdateProfiles();
        }

        public void UpdateProfiles()
        {
            Profiles = Facade.Instance.GetProfiles();
        }
    }
}

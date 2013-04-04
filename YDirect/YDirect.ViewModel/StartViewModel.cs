
namespace YDirect.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private LoginViewModel _login;
        private ProfileViewModel _profile;

        public StartViewModel()
        {
            _login = new LoginViewModel();
            _profile = new ProfileViewModel();
            _profile.CreateProfile += (s, a) => _login.UpdateProfiles();
        }

        public LoginViewModel Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(() => Login);
            }
        }

        public ProfileViewModel Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged(() => Profile);
            }
        }
    }
}

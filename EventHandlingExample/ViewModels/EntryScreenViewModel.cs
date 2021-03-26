using AuthControl.Models;
using EventHandlingExample.Common;
using EventHandlingExample.PubSubEvents;
using EventHandlingExample.Services;

namespace EventHandlingExample.ViewModels
{
    public class EntryScreenViewModel : BaseViewModel
    {
        private EventAggregator _eventAggregator = Singleton<EventAggregator>.Instance;
        private string _userLoggedInfo;
        private bool _isUserLogged;

        public EntryScreenViewModel()
        {
            _eventAggregator.GetEvent<UserLoggedEvent>().Subscribe(OnUserLogged);
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
        }

        public string UserLoggedInfo
        {
            get => _userLoggedInfo;
            set
            {
                _userLoggedInfo = value;
                OnPropertyChanged(nameof(UserLoggedInfo));
            }
        }

        public bool IsUserLogged
        {
            get => _isUserLogged;
            set
            {
                _isUserLogged = value;
                OnPropertyChanged(nameof(IsUserLogged));
            }
        }

        public void Login(string username, string password)
        {
            AuthService.Login(username, password);
            IsUserLogged = AuthService.IsLogged;
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
        }

        public void OnUserLogged(LoginInfo args)
        {
            Login(args.UserName, args.Password);
        }
    }
}

using AuthControl.Models;
using EventHandlingExample.Common;
using EventHandlingExample.Services;
using System.Windows.Input;

namespace EventHandlingExample.ViewModels
{
    public class EntryScreenViewModel : BaseViewModel
    {
        private string _userLoggedInfo;
        private bool _isUserLogged;
        private ICommand _userLoggedCommand;

        public EntryScreenViewModel()
        {
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
            UserLoggedCommand = new RelayCommand<LoginInfo>((x) => Login(x.UserName, x.Password));
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

        public ICommand UserLoggedCommand
        {
            get { return _userLoggedCommand; }
            set
            {
                _userLoggedCommand = value;
                OnPropertyChanged(nameof(UserLoggedCommand));
            }
        }

        public void Login(string username, string password)
        {
            AuthService.Login(username, password);
            IsUserLogged = AuthService.IsLogged;
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
        }
    }
}

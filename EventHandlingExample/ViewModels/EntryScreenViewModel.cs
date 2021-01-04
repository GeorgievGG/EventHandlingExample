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
        // TODO: Command field

        public EntryScreenViewModel()
        {
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
            // TODO: Assign command
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

        // TODO: Command property

        public void Login(string username, string password)
        {
            AuthService.Login(username, password);
            IsUserLogged = AuthService.IsLogged;
            UserLoggedInfo = AuthService.GetUserLoggedInfo();
        }
    }
}

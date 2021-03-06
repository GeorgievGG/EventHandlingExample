﻿using EventHandlingExample.Services;

namespace EventHandlingExample.ViewModels
{
    public class EntryScreenViewModel : BaseViewModel
    {
        private string _userLoggedInfo;
        private bool _isUserLogged;

        public EntryScreenViewModel()
        {
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
    }
}

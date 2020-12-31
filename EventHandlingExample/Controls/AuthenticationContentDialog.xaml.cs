using AuthControl.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace EventHandlingExample.Controls
{
    public sealed partial class AuthenticationContentDialog : ContentDialog
    {
        public event EventHandler<LoginInfo> UserLogged;

        public AuthenticationContentDialog()
        {
            this.InitializeComponent();
        }

        private void OnUserLogged(object sender, LoginInfo args)
        {
            this.UserLogged?.Invoke(sender, args);
        }
    }
}

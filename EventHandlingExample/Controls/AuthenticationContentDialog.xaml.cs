using AuthControl.Models;
using EventHandlingExample.Common;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EventHandlingExample.Controls
{
    public sealed partial class AuthenticationContentDialog : ContentDialog
    {
        public AuthenticationContentDialog()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty UserLoggedCommandProperty = DependencyProperty.Register(
            nameof(UserLoggedCommand), typeof(ICommand), typeof(AuthenticationContentDialog), new PropertyMetadata(default(ICommand)));

        public ICommand UserLoggedCommand
        {
            get => (ICommand)GetValue(UserLoggedCommandProperty);
            set => SetValue(UserLoggedCommandProperty, value);
        }
    }
}

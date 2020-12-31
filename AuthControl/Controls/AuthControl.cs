using AuthControl.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AuthControl.Controls
{
    public sealed class AuthControl : Control
    {
        private const string UsernameBoxName = "UsernameBox";
        private const string PasswordBoxName = "PasswordBox";
        private const string LogginButtonName = "LoginButton";

        private TextBox usernameBox;
        private PasswordBox passwordBox;
        private Button loginButton;

        public AuthControl()
        {
            this.DefaultStyleKey = typeof(AuthControl);
        }

        public event EventHandler<LoginInfo> UserLogged;

        public static readonly DependencyProperty UsernameInputProperty =
            DependencyProperty.Register(nameof(UsernameInput), typeof(string), typeof(AuthControl), new PropertyMetadata(string.Empty));

        public string UsernameInput
        {
            get { return (string)GetValue(UsernameInputProperty); }
            set { SetValue(UsernameInputProperty, value); }
        }

        public static readonly DependencyProperty IsLoginButtonEnabledProperty =
            DependencyProperty.Register(nameof(IsLoginButtonEnabled), typeof(bool), typeof(AuthControl), new PropertyMetadata(false));

        public bool IsLoginButtonEnabled
        {
            get { return (bool)GetValue(IsLoginButtonEnabledProperty); }
            set { SetValue(IsLoginButtonEnabledProperty, value); }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= OnPasswordChanged;
            }

            passwordBox = GetTemplateChild(PasswordBoxName) as PasswordBox;

            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += OnPasswordChanged;
            }

            if (usernameBox != null)
            {
                usernameBox.TextChanged -= OnUsernameBoxChanged;
            }

            usernameBox = GetTemplateChild(UsernameBoxName) as TextBox;

            if (usernameBox != null)
            {
                usernameBox.TextChanged += OnUsernameBoxChanged;
            }

            if (loginButton != null)
            {
                loginButton.Click -= OnLoginButtonClicked;
            }

            loginButton = GetTemplateChild(LogginButtonName) as Button;

            if (loginButton != null)
            {
                loginButton.Click += OnLoginButtonClicked;
            }
        }

        private void OnUsernameBoxChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            IsLoginButtonEnabled = !string.IsNullOrWhiteSpace(textBox.Text) && !string.IsNullOrWhiteSpace(passwordBox.Password);
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            IsLoginButtonEnabled = !string.IsNullOrWhiteSpace(UsernameInput) && !string.IsNullOrWhiteSpace(passwordBox.Password);
        }

        private void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            // INFO: Best place to invoke Login request logic;

            UserLogged?.Invoke(this, new LoginInfo(UsernameInput, passwordBox.Password));
        }
    }
}

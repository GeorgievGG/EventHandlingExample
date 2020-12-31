namespace EventHandlingExample.Services
{
    public static class AuthService
    {
        private const string LoggedText = "Welcome, {0}";
        private const string NotLoggedText = "Please, log in to use the app";

        public static bool IsLogged { get; private set; }

        public static string UserName { get; private set; }

        public static void Login(string username, string password)
        {
            IsLogged = true;
            UserName = username;
        }

        public static string GetUserLoggedInfo()
        {
            if (AuthService.IsLogged)
            {
                return string.Format(LoggedText, AuthService.UserName);
            }

            return NotLoggedText;
        }
    }
}

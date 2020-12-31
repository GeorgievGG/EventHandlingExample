namespace AuthControl.Models
{
    public class LoginInfo
    {
        public LoginInfo(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}

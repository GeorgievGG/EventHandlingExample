using AuthControl.Models;
using EventHandlingExample.Common;
using Windows.UI.Xaml.Controls;

namespace EventHandlingExample.Controls
{
    public sealed partial class AuthenticationContentDialog : ContentDialog
    {
        private EventAggregator _eventAggregator = Singleton<EventAggregator>.Instance;

        public AuthenticationContentDialog()
        {
            this.InitializeComponent();
        }

        private void OnUserLogged(object sender, LoginInfo args)
        {
            _eventAggregator.GetEvent<UserLoggedEvent>().Publish(args);
        }
    }
}

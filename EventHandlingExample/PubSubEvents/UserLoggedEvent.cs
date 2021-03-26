using AuthControl.Models;
using EventHandlingExample.Common;

namespace EventHandlingExample.PubSubEvents
{
    public class UserLoggedEvent : PubSubEvent<LoginInfo>
    {
    }
}

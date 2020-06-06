using System.Net.Mail;

namespace SWLAPI.DataProvider.Entity
{
    public abstract class UserRegistrationInvitation
    {
        public string IdentifierHash { get; set; }
        public UserCommunicationChannel.Types CommunicationChannelType { get; set; }
        public string Token { get; set; }
    }
}
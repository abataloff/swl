using SWLAPI.DB;

namespace SWLAPI.DataProvider
{
    public class ApplicationDataProvider
    {
        public ApplicationDataProvider(string connectionString)
        {
            UserCommunicationChannels = new UserCommunicationChannelsEntityProvider(connectionString);
            Invitations = new InvitationsEntityProvider(connectionString);
        }

        public IUsersEntityProvider Users { get; private set; }
        public IUserCommunicationChannelsEntityProvider UserCommunicationChannels { get; private set; }
        public IUserAuthenticationTokensEntityProvider UserAuthenticationTokens { get; private set; }
        public IInvitationsEntityProvider Invitations { get; private set; }
    }
}
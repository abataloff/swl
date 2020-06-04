using System;
using SWLAPI.DataProvider;

namespace SWLAPI.Services
{
    internal class MainEventBusListener
    {
        private readonly MainEventBus _mainEventBus;
        private readonly ApplicationDataProvider _applicationDataProvider;
        private readonly MailSender _mailSender;

        public MainEventBusListener(MainEventBus mainEventBus,
            ApplicationDataProvider applicationDataProvider, MailSender mailSender)
        {
            _mainEventBus = mainEventBus;
            _applicationDataProvider = applicationDataProvider;
            _mailSender = mailSender;
        }

        public void InitListeners()
        {
            _mainEventBus.AuthenticationByEmailLinkRequested += MainEventBusOnAuthenticationByEmailLinkRequested;
            _mainEventBus.InviteUserByEmailRequested += MainEventBusOnInviteUserByEmailRequested;
        }

        private void MainEventBusOnInviteUserByEmailRequested(object sender, InviteByEmailEventArgs inviteByEmailEventArgs)
        {
            _mailSender.SendInvitation(inviteByEmailEventArgs.Email);
        }

        private void MainEventBusOnAuthenticationByEmailLinkRequested(object sender,
            AuthByEmailLinkEventArgs authByEmailLinkEventArgs)
        {
            var userCommunicationChannels =
                _applicationDataProvider.UserCommunicationChannels.GetByEmail(authByEmailLinkEventArgs.Email);
            if (userCommunicationChannels != null)
            {
                var token = _applicationDataProvider.UserAuthenticationTokens.Create();
                token.Token = Guid.NewGuid().ToString();
                token.User = userCommunicationChannels.User;
                _applicationDataProvider.UserAuthenticationTokens.Push(token);
            }
            else
            {
                _mainEventBus.DoInviteUserByEmailRequested(this, authByEmailLinkEventArgs.Email);
            }
        }
    }
}
using System;
using System.Net.Mail;
using SWLAPI.ClassesExtension;
using SWLAPI.DataProvider;
using SWLAPI.DataProvider.Entity;

namespace SWLAPI.Services
{
    public class MailSender
    {
        private readonly ApplicationDataProvider _applicationDataProvider;

        public MailSender(ApplicationDataProvider applicationDataProvider)
        {
            _applicationDataProvider = applicationDataProvider;
        }

        public void SendInvitation(MailAddress email)
        {
            var invitation = _applicationDataProvider.Invitations.Create();
            invitation.CommunicationChannelType = UserCommunicationChannel.Types.Email;
            invitation.IdentifierHash = email.GetSHA1();
            invitation.Token = Guid.NewGuid().ToString();
            _applicationDataProvider.Invitations.Push(invitation);
            // TODO: Реализовать отправку писем
        }
    }
}
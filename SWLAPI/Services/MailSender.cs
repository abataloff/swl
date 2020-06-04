using System;
using System.Net.Mail;
using SWLAPI.DataProvider;

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
            invitation.Email = email;
            invitation.Token = Guid.NewGuid().ToString();
            _applicationDataProvider.Invitations.Push(invitation);
            // TODO: Реализовать отправку писем
        }
    }
}
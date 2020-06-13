using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using SWLAPI.ClassesExtension;
using SWLAPI.DataProvider;
using SWLAPI.DataProvider.Entity;

namespace SWLAPI.Services
{
    public class MailSender
    {
        private readonly ApplicationDataProvider _applicationDataProvider;
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _from;

        public MailSender(ApplicationDataProvider applicationDataProvider, IConfiguration config)
        {
            _applicationDataProvider = applicationDataProvider;
            var section = config.GetSection("mailer");
            _smtpClient = new SmtpClient
            {
                Host = section.GetValue<string>("Host"),
                Port = section.GetValue<int>("Port"),
                EnableSsl = section.GetValue<bool>("SSL"),
                Credentials = new NetworkCredential(section.GetValue<string>("Username"),
                    section.GetValue<string>("Password")),
            };
            _from = new MailAddress(section.GetValue<string>("From"));
        }

        public void SendInvitation(MailAddress email)
        {
            var invitation = _applicationDataProvider.Invitations.Create();
            invitation.CommunicationChannelType = UserCommunicationChannel.Types.Email;
            invitation.IdentifierHash = email.GetSHA1();
            invitation.Token = Guid.NewGuid().ToString();
            _applicationDataProvider.Invitations.Push(invitation);

            var msg = new MailMessage
            {
                Body = invitation.Token,
                BodyEncoding = Encoding.UTF8,
                Subject = "Приглашение на регистрацию",
                SubjectEncoding = Encoding.UTF8,
                From = _from,
            };
            msg.To.Add(email);
            _smtpClient.Send(msg);
        }
    }
}
using System.Net.Mail;

namespace SWLAPI.DataProvider.Entity
{
    public abstract class Invitation
    {
        public MailAddress Email { get; set; }
        public string Token { get; set; }
    }
}
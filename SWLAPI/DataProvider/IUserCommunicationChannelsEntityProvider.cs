using System.Net.Mail;
using SWLAPI.DB.Entity;

namespace SWLAPI.DataProvider
{
    public interface IUserCommunicationChannelsEntityProvider:IEntityProvider<UserCommunicationChannel>
    {
        UserCommunicationChannel GetByEmail(MailAddress email);
    }
}
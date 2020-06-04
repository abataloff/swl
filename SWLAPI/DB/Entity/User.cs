using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWLAPI.ClassesExtension;

namespace SWLAPI.DB.Entity
{
    public class User : SWLAPI.DataProvider.Entity.User
    {
        public const string TableName = "users";
        public ulong Id { get; set; }

        private User(ulong userId)
        {
            throw new System.NotImplementedException();
        }

        // public static User FindByEmail(DB.Context.Context dbContext, MailAddress mailAddress)
        // {
        //     var retVal = default(User);
        //
        //     // var ucc = dbContext.UserCommunicationChannels.FirstOrDefault();
        //     // // var ucc = dbContext.UserCommunicationChannels.FirstOrDefault(channels =>
        //     // //     channels.Type == UserCommunicationChannel.Types.Email
        //     // //     && channels.IdentifierHash == mailAddress.GetSHA1().ToString());
        //     // if (ucc != default)
        //     // {
        //     //     retVal = dbContext.Users.FirstOrDefault(u => u.Id == ucc.Id);
        //     // }
        //
        //     return retVal;
        // }
        public static User FromDb(ulong userId)
        {
            return new User(userId);
        }
    }
}
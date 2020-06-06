using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SWLAPI.DataProvider;

namespace SWLAPI.DB.Entity
{
    [Table("user_communication_channels")]
    public class UserCommunicationChannel : SWLAPI.DataProvider.Entity.UserCommunicationChannel
    {
        public static class Columns
        {
            public const int Id = 0;
            public const int Type = 1;
            public const int UserId = 2;
            public const int IdentifierHash = 3;
        }

        private readonly ulong _id;

        private UserCommunicationChannel(ulong id)
        {
            _id = id;
        }

        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id
        {
            get { return _id; }
        }

        private ulong UserId
        {
            get { throw new NotImplementedException();}
            set { throw new NotImplementedException(); }
        }

        public override SWLAPI.DataProvider.Entity.User User {
            get
            {
                return Entity.User.FromDb(UserId);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public static UserCommunicationChannel FromDb(ulong id)
        {
            return new UserCommunicationChannel(id);
        }
    }
}
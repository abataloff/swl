using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.Data.Sqlite;
using SWLAPI.ClassesExtension;
using SWLAPI.DataProvider;
using SWLAPI.DB.Entity;

namespace SWLAPI.DB
{
    public class UserCommunicationChannelsEntityProvider : IUserCommunicationChannelsEntityProvider
    {
        private readonly string _connectionString;

        public UserCommunicationChannelsEntityProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Entity.UserCommunicationChannel GetByEmail(MailAddress email)
        {
            var retVal = default(Entity.UserCommunicationChannel);
            var identifierHash = email.GetSHA1();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    $@"SELECT *
                      FROM user_communication_channels 
                      WHERE identifier_hash='$identifier_hash' AND type='Email';";
                command.Parameters.Add(new SqliteParameter("$identifier_hash", identifierHash));

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    retVal = Entity.UserCommunicationChannel.FromDb((ulong)
                        reader.GetInt64(Entity.UserCommunicationChannel.Columns.Id));
                }

                connection.Close();
            }

            return retVal;
        }

        public UserCommunicationChannel Create()
        {
            throw new System.NotImplementedException();
        }

        public void Push(UserCommunicationChannel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Microsoft.Data.Sqlite;
using SWLAPI.ClassesExtension;
using SWLAPI.DataProvider;
using SWLAPI.DataProvider.Entity;

namespace SWLAPI.DB
{
    public class InvitationsEntityProvider : IInvitationsEntityProvider
    {
        private readonly string _connectionString;

        public InvitationsEntityProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserRegistrationInvitation Create()
        {
            return new Entity.UserRegistrationInvitation();
        }

        public void Push(UserRegistrationInvitation userRegistrationInvitation)
        {
            Push(userRegistrationInvitation as Entity.UserRegistrationInvitation);
        }

        private void Push(Entity.UserRegistrationInvitation userRegistrationInvitation)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                if (userRegistrationInvitation.InDb)
                {
                    command.CommandText =
                        $"UPDATE user_registration_invitations SET id=$id, communication_channel_type=$communication_channel_type identifier_hash=$identifier_hash, token=$token";
                    command.Parameters.Add(new SqliteParameter("$id", userRegistrationInvitation.Id));
                }
                else
                {
                    command.CommandText =
                        $@"INSERT INTO user_registration_invitations (id, communication_channel_type, identifier_hash, token)
                      VALUES (null, $communication_channel_type, $identifier_hash, $token)";
                }

                command.Parameters.Add(new SqliteParameter("$identifier_hash",
                    userRegistrationInvitation.IdentifierHash));
                command.Parameters.Add(new SqliteParameter("$token", userRegistrationInvitation.Token));
                command.Parameters.Add(new SqliteParameter("communication_channel_type",
                    userRegistrationInvitation.CommunicationChannelType));

                var obj = command.ExecuteScalar();

                connection.Close();
            }
        }
    }
}
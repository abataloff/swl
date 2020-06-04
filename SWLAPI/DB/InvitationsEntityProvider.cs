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

        public Invitation Create()
        {
            return new Entity.Invitation();
        }

        public void Push(Invitation invitation)
        {
            Push(invitation as Entity.Invitation);
        }

        private void Push(Entity.Invitation invitation)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                if (invitation.InDb)
                {
                    
                    command.CommandText = $"UPDATE invitations SET id=$id, email= $email, token=$token";
                    command.Parameters.Add(new SqliteParameter("$id", invitation.Id));
                }
                else
                {
                    command.CommandText =
                        $@"INSERT INTO invitations (id, email, token)
                      VALUES (null, $email, $token)";
                }

                command.Parameters.Add(new SqliteParameter("$email", invitation.Email.GetSHA1()));
                command.Parameters.Add(new SqliteParameter("$token", invitation.Token));

                var obj = command.ExecuteScalar();

                connection.Close();
            }
        }
    }
}
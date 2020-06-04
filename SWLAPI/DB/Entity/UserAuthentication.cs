// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using SWLAPI.Authentication;
// namespace SWLAPI.DB.Entity
// {
//     [Table("user_authentications")]
//     public class UserAuthentication
//     {   
//         [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//         public ulong Id { get; set; }
//
//         [Column("type")]
//         public UserAuthenticationType Type { get; set; }
//         
//         [Column("user_id")]
//         public User User { get; set; }
//     }
// }
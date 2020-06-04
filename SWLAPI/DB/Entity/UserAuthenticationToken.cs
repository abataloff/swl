using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWLAPI.DB.Entity
{
    public class UserAuthenticationToken:SWLAPI.DataProvider.Entity.UserAuthenticationToken
    {
        public override string Token { get; set; }
        public override DataProvider.Entity.User User { get; set; }
    }
}
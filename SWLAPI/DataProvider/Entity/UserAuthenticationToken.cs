namespace SWLAPI.DataProvider.Entity
{
    public abstract class UserAuthenticationToken
    {
        public abstract string Token { get; set; }
        public abstract User User { get; set; }
    }
}
namespace SWLAPI.DB.Entity
{
    public class UserRegistrationInvitation: SWLAPI.DataProvider.Entity.UserRegistrationInvitation
    {
        private ulong _id;
        // TODO: Переименовать поле
        private bool _inDb = false;

        public UserRegistrationInvitation()
        {
        }

        public bool InDb
        {
            get { return _inDb; }
            private set { _inDb = value; }
        }

        public ulong Id
        {
            get { return _id; }
            set
            {   
                _id = value;
                InDb = true;
            }

        }

        private UserRegistrationInvitation(ulong id)
        {
            Id = id;
        }

        public UserRegistrationInvitation FromDb(ulong id)
        {
            return new UserRegistrationInvitation(id);
        }
    }
}
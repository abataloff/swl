namespace SWLAPI.DB.Entity
{
    public class Invitation: SWLAPI.DataProvider.Entity.Invitation
    {
        private ulong _id;
        // TODO: Переименовать поле
        private bool _inDb = false;

        public Invitation()
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

        private Invitation(ulong id)
        {
            Id = id;
        }

        public Invitation FromDb(ulong id)
        {
            return new Invitation(id);
        }
    }
}
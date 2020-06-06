using System.Threading.Tasks;
using Remotion.Linq.Clauses;

namespace SWLAPI.DataProvider.Entity
{
    public abstract class UserCommunicationChannel
    {
        public enum Types
        {
            Email
        }
        public abstract User User { get; set; }
    }
}
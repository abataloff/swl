using System.Threading.Tasks;
using Remotion.Linq.Clauses;

namespace SWLAPI.DataProvider.Entity
{
    public abstract class UserCommunicationChannel
    {
        public abstract User User { get; set; }
    }
}
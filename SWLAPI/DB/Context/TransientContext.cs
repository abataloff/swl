using Microsoft.EntityFrameworkCore;

namespace SWLAPI.DB.Context
{
    public class TransientContext : Context
    {
        public TransientContext(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}

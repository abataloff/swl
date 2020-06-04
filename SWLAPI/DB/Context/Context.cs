using SWLAPI.DB.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SWLAPI.DB.Context
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; } 
        // public DbSet<UserCommunicationChannel> UserCommunicationChannels { get; set; }
        // public DbSet<UserAuthenticationToken> UserAuthenticationTokens { get; set; }

        public Context() : base()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory((new LoggerFactory()).AddConsole());
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Event>()
            //     .HasIndex(e => new { e.RoomId, e.From });
            //
            // modelBuilder.Entity<User>()
            //     .HasIndex(u => new { u.Code })
            //     .IsUnique();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void OnBeforeSaving()
        {
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is ITimestampable).ToList();

            addedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = DateTime.Now;
            });

            var updatedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is ITimestampable).ToList();

            updatedEntities.ForEach(E =>
            {
                E.Property("ModifiedAt").CurrentValue = DateTime.Now;
            });
        }
    }
}

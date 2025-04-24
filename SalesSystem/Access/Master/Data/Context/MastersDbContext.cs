using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System.Reflection;

namespace Master.Data.Context
{
    public class MastersDbContext : DbContext
    {
        readonly IDomainEventDispatcher? _Dispatcher;

        public MastersDbContext(DbContextOptions<MastersDbContext> options, IDomainEventDispatcher? dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet

        public DbSet<DbCurrency> CurrencyItems => Set<DbCurrency>();

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion

        #region Save Changes

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_Dispatcher == null)
            {
                return result;
            }

            // dispatch events only if save was successful
            HasDomainEventsBase[] entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _Dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        #endregion
    }
}

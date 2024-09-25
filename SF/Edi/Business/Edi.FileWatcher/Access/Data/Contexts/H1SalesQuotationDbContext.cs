using Microsoft.EntityFrameworkCore;

namespace Edi.FileWatcher.Access.Data.Contexts;

/// <summary>
/// The database context for H1.Sales.Edi entities.
/// </summary>
public class H1SalesQuotationDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    /// <summary>
    /// Creates a <see cref="H1SalesQuotationDbContext"/>.
    /// </summary>
    public H1SalesQuotationDbContext(DbContextOptions<H1SalesQuotationDbContext> options,
    IDomainEventDispatcher? dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public H1SalesQuotationDbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSet

    public DbSet<DbExternalSalesPriceInformationView> ExternalPriceView => Set<DbExternalSalesPriceInformationView>();

    #endregion

    #region OnModelCreating

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion

    #region SaveChanges

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null)
        {
            ChangeTracker.Clear();
           //await base.DisposeAsync();
            return result;
        }

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
        ChangeTracker.Clear();
        //await base.DisposeAsync();
        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }

    #endregion
}

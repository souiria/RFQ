using Microsoft.EntityFrameworkCore;

namespace Edi.FileWatcher.Access.Data.Contexts;

/// <summary>
/// The database context for H1.Sales.Edi entities.
/// </summary>
public class Unit4DbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    /// <summary>
    /// Creates a <see cref="H1SalesQuotationDbContext"/>.
    /// </summary>
    public Unit4DbContext(DbContextOptions<Unit4DbContext> options,
    IDomainEventDispatcher? dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public Unit4DbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSet

    public DbSet<DbAlgBatchInput> AlgBatchInputs => Set<DbAlgBatchInput>();
    public DbSet<DbAlgProductInput> AlgProductInputs => Set<DbAlgProductInput>();
    public DbSet<DbMinAlgArticle> MinAlgArticles => Set<DbMinAlgArticle>();
    public DbSet<DbUnit4SalesOrdersView> Unit4SalesOrdersView => Set<DbUnit4SalesOrdersView>();

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
       // await base.DisposeAsync();
        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }

    #endregion
}

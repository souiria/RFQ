using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.Data.Contexts;

/// <summary>
/// The database context for H1.Sales.Edi entities.
/// </summary>
internal class H1SalesEdiDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    /// <summary>
    /// Creates a <see cref="H1SalesEdiDbContext"/>.
    /// </summary>
    public H1SalesEdiDbContext(DbContextOptions<H1SalesEdiDbContext> options,
    IDomainEventDispatcher? dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public H1SalesEdiDbContext(DbContextOptions options) : base(options)
    {
      //Database.SetCommandTimeout(60);
    }

    #region DbSet

    public DbSet<DbEdiFileDataUpload> EdiFileDataUploads => Set<DbEdiFileDataUpload>();
    public DbSet<DbEdiFileDataUploadDuplicate> DbEdiFileDataUploadDuplicates => Set<DbEdiFileDataUploadDuplicate>();
    public DbSet<DbEdiInvoiceInformation> EdiInvoiceInformation => Set<DbEdiInvoiceInformation>();
    public DbSet<DbEdiCustomerParameter> EdiCustomerParameters => Set<DbEdiCustomerParameter>();

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
        try
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
        catch (Exception ex)
        {
            //await base.DisposeAsync();
            throw;
        }
    }

    public override int SaveChanges()
    {     
       return SaveChangesAsync().GetAwaiter().GetResult();
    }

    //public override void Dispose()
    //{
    //    base.Dispose();
    //    GC.SuppressFinalize(this);
    //}
    #endregion
}

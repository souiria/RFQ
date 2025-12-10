using CDb;
using CDb.Data.Context;
using CDb.Data.Model.Components;
using CDb.Enums;
using SharedKernel;

namespace Unit.Tests.CDb
{
    [TestFixture]
    public class CDbContextUnitTests
    {

        #region Test Data Constants
        readonly Guid _TestCableId;
        readonly Guid _TestCableId2;
        #endregion

        #region Setup and Teardown
        ServiceProvider _ServiceProvider;
        string _DatabaseName;
        public CDbContextUnitTests()
        {
            _TestCableId = Guid.Parse("20250804-0000-0001-0001-0000DEADBEEF");
            _TestCableId2 = Guid.Parse("20250804-0000-0001-0002-0000DEADBEEF");

            _ServiceProvider = null!;
            _DatabaseName = string.Empty;
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            // Mock IDomainEventsDispatcher
            Mock<IDomainEventsDispatcher> mockDispatcher = new Mock<IDomainEventsDispatcher>();
            IEnumerable<IDomainEvent> anyDomainEvents = It.IsAny<IEnumerable<IDomainEvent>>();
            CancellationToken anyCancellationToken = It.IsAny<CancellationToken>();
            mockDispatcher
                .Setup(d => d.DispatchAsync(anyDomainEvents, anyCancellationToken))
                .Returns(Task.CompletedTask);

            // Register the mock dispatcher
            serviceCollection.AddSingleton(mockDispatcher.Object);

            // Configure in-memory database with a stable name for the test run
            _DatabaseName = $"TestCDb_{Guid.NewGuid()}";
            serviceCollection.AddDbContext<CDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: _DatabaseName)
                       .EnableSensitiveDataLogging()
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Warning);
            });

            _ServiceProvider = serviceCollection.BuildServiceProvider();

            // Ensure database is created using a scoped context
            using IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up database
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Database.EnsureDeleted();
            }

            // Dispose service provider
            _ServiceProvider?.Dispose();
        }
        #endregion

        #region Database Connection Tests

        [Test]
        [Category("Unit")]
        public async Task CDbContext_0CanConnectToDatabase_ReturnsTrue()
        {
            // Arrange
            using IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();

            // Act
            bool canConnect = await context.Database.CanConnectAsync();

            // Assert
            Assert.That(canConnect, Is.True, "Should be able to connect to the in-memory database");
        }

        [Test]
        [Category("Unit")]
        public void CDbContext_1HasRequiredDbSets_AllDbSetsAreNotNull()
        {
            // Arrange
            using IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();

            // Assert - Master tables
            Assert.That(context.Database, Is.Not.Null, "Database should not be null");
            Assert.That(context.CoverTypes, Is.Not.Null, "CoverTypes DbSet should not be null");
            Assert.That(context.WireTypes, Is.Not.Null, "WireTypes DbSet should not be null");
            Assert.That(context.TerminalFamilys, Is.Not.Null, "TerminalFamilys DbSet should not be null");

            // Assert - Main tables
            Assert.That(context.Components, Is.Not.Null, "Components DbSet should not be null");
            Assert.That(context.AuditEvents, Is.Not.Null, "AuditEvents DbSet should not be null");
            Assert.That(context.PartNumbers, Is.Not.Null, "PartNumbers DbSet should not be null");

            // Assert - Component tables
            Assert.That(context.Cables, Is.Not.Null, "Cables DbSet should not be null");
            Assert.That(context.Clips, Is.Not.Null, "Clips DbSet should not be null");
            Assert.That(context.Connectors, Is.Not.Null, "Connectors DbSet should not be null");
            Assert.That(context.Wires, Is.Not.Null, "Wires DbSet should not be null");
        }

        #endregion

        #region CRUD Operations Tests

        [Test]
        [Category("Unit")]
        public async Task CDbContext_2CreateAndRetrieveCable_ReturnsCorrectData()
        {
            // Arrange
            DbCable cable = new DbCable();
            cable.Id = _TestCableId;
            cable.ComponentType = ComponentType.Cable;
            cable.Name = "TEST-CABLE-001";
            cable.SheetNumber = 99001;
            cable.Issue = "TEST";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.75m;
            cable.Comment = "Unit test cable";
            cable.Color = ColorType.B;
            cable.WireCount = 4;
            cable.Length = 100.5m;
            cable.IsShielded = true;
            cable.Created = DateTime.UtcNow;
            cable.CreatedById = Guid.NewGuid();

            // Act - Create
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Cables.Add(cable);
                int saveResult = await context.SaveChangesAsync();

                // Assert - Save operation
                EqualConstraint equalTo1 = Is.EqualTo(1);
                Assert.That(saveResult, equalTo1, "Should save one record");
            }

            // Act - Retrieve (need a new scope for in-memory to simulate real behavior)
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext retrieveContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                DbCable? retrievedCable = await retrieveContext.Cables
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == _TestCableId);

                // Assert - Retrieved data
                Assert.That(retrievedCable, Is.Not.Null, "Cable should be retrieved");
                EqualConstraint equalToTestCable = Is.EqualTo("TEST-CABLE-001");
                Assert.That(retrievedCable.Name, equalToTestCable);
                EqualConstraint equalToTypeCable = Is.EqualTo(ComponentType.Cable);
                Assert.That(retrievedCable.ComponentType, equalToTypeCable);
                EqualConstraint equalToWireCount4 = Is.EqualTo(4);
                Assert.That(retrievedCable.WireCount, equalToWireCount4);
                Assert.That(retrievedCable.IsShielded, Is.True);
            }
        }

        [Test]
        [Category("Unit")]
        public async Task CDbContext_3UpdateComponent_ReflectsChanges()
        {
            string originalName = "ORIGINAL-NAME";
            string updatedName = "UPDATED-NAME";
            string originalComment = "Original comment";
            string updatedComment = "Updated comment";

            // Arrange - Create a component first
            DbCable cable = new DbCable();
            cable.Id = _TestCableId2;
            cable.ComponentType = ComponentType.Cable;
            cable.Name = originalName;
            cable.SheetNumber = 99003;
            cable.Issue = "TEST";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.75m;
            cable.Comment = originalComment;
            cable.Color = ColorType.R;
            cable.WireCount = 4;
            cable.Length = 100.5m;
            cable.IsShielded = true;
            cable.Created = DateTime.UtcNow;
            cable.CreatedById = Guid.NewGuid();

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Cables.Add(cable);
                await context.SaveChangesAsync();
            }

            // Act - Update the component (use a new scope with tracking enabled)
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext updateContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                
                // IMPORTANT: Use AsTracking() to override the global NoTracking behavior
                DbCable? cableToUpdate = await updateContext.Cables
                    .AsTracking()
                    .FirstOrDefaultAsync(c => c.Id == _TestCableId2);
                
                Assert.That(cableToUpdate, Is.Not.Null, "Cable should exist before update");

                cableToUpdate.Name = updatedName;
                cableToUpdate.Comment = updatedComment;
                cableToUpdate.Color = ColorType.B;
                cableToUpdate.WireCount = 8;
                cableToUpdate.Updated = DateTime.UtcNow;
                cableToUpdate.UpdatedById = Guid.NewGuid();

                int updateResult = await updateContext.SaveChangesAsync();

                // Assert
                EqualConstraint equalTo1 = Is.EqualTo(1);
                Assert.That(updateResult, equalTo1, "Should update one record");
            }

            // Verify the changes (use a separate scope)
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext verifyContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                DbCable? updatedCable = await verifyContext.Cables
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == _TestCableId2);

                Assert.That(updatedCable, Is.Not.Null, "Updated cable should not be null");
                EqualConstraint equalToUpdatedName = Is.EqualTo(updatedName);
                Assert.That(updatedCable.Name, equalToUpdatedName);
                EqualConstraint equalToUpdatedComment = Is.EqualTo(updatedComment);
                Assert.That(updatedCable.Comment, equalToUpdatedComment);
                EqualConstraint equalToColorB = Is.EqualTo(ColorType.B);
                Assert.That(updatedCable.Color, equalToColorB);
                EqualConstraint equalToWireCount8 = Is.EqualTo(8);
                Assert.That(updatedCable.WireCount, equalToWireCount8);
            }
        }

        [Test]
        [Category("Unit")]
        public async Task CDbContext_4DeleteComponent_RemovesFromDatabase()
        {
            // Arrange - Create two cables
            DbCable cable1 = new DbCable();
            cable1.Id = _TestCableId;
            cable1.ComponentType = ComponentType.Cable;
            cable1.Name = "DELETE-TEST-001";
            cable1.SheetNumber = 99004;
            cable1.Issue = "TEST";
            cable1.ComponentStatus = ComponentStatus.CurrentValid;
            cable1.Weight = 0.5m;
            cable1.Comment = "Cable to delete";
            cable1.Color = ColorType.W;
            cable1.WireCount = 2;
            cable1.Length = 50.0m;
            cable1.IsShielded = false;
            cable1.Created = DateTime.UtcNow;
            cable1.CreatedById = Guid.NewGuid();

            DbCable cable2 = new DbCable();
            cable2.Id = _TestCableId2;
            cable2.ComponentType = ComponentType.Cable;
            cable2.Name = "DELETE-TEST-002";
            cable2.SheetNumber = 99005;
            cable2.Issue = "TEST";
            cable2.ComponentStatus = ComponentStatus.CurrentValid;
            cable2.Weight = 0.6m;
            cable2.Comment = "Another cable to delete";
            cable2.Color = ColorType.B;
            cable2.WireCount = 3;
            cable2.Length = 75.0m;
            cable2.IsShielded = true;
            cable2.Created = DateTime.UtcNow;
            cable2.CreatedById = Guid.NewGuid();

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Cables.AddRange(cable1, cable2);
                await context.SaveChangesAsync();
            }

            // Act - Delete first cable
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext deleteContext1 = scope.ServiceProvider.GetRequiredService<CDbContext>();
                DbCable? cableToDelete1 = await deleteContext1.Cables.FirstOrDefaultAsync(c => c.Id == _TestCableId);
                Assert.That(cableToDelete1, Is.Not.Null, "Cable 1 should exist before deletion");

                deleteContext1.Cables.Remove(cableToDelete1);
                await deleteContext1.SaveChangesAsync();
            }

            // Act - Delete second cable
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext deleteContext2 = scope.ServiceProvider.GetRequiredService<CDbContext>();
                DbCable? cableToDelete2 = await deleteContext2.Cables.FirstOrDefaultAsync(c => c.Id == _TestCableId2);
                Assert.That(cableToDelete2, Is.Not.Null, "Cable 2 should exist before deletion");

                deleteContext2.Cables.Remove(cableToDelete2);
                await deleteContext2.SaveChangesAsync();
            }

            // Verify deletion
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext verifyContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                DbCable? deletedCable1 = await verifyContext.Cables
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == _TestCableId);
                DbCable? deletedCable2 = await verifyContext.Cables
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == _TestCableId2);

                Assert.That(deletedCable1, Is.Null, "Cable 1 should no longer exist after deletion");
                Assert.That(deletedCable2, Is.Null, "Cable 2 should no longer exist after deletion");
            }
        }

        #endregion

        #region Additional Unit Tests

        [Test]
        [Category("Unit")]
        public async Task CDbContext_5CreateMultipleCables_ReturnsCorrectCount()
        {
            // Arrange
            List<DbCable> cables = new List<DbCable>();
            DbCable cable1 = new DbCable();
            cable1.Id = Guid.NewGuid();
            cable1.ComponentType = ComponentType.Cable;
            cable1.Name = "MULTI-TEST-001";
            cable1.SheetNumber = 99006;
            cable1.Issue = "TEST";
            cable1.ComponentStatus = ComponentStatus.CurrentValid;
            cable1.Weight = 0.5m;
            cable1.Comment = "First multi test cable";
            cable1.Color = ColorType.R;
            cable1.WireCount = 2;
            cable1.Length = 50.0m;
            cable1.IsShielded = false;
            cable1.Created = DateTime.UtcNow;
            cable1.CreatedById = Guid.NewGuid();

            DbCable cable2 = new DbCable();
            cable2.Id = Guid.NewGuid();
            cable2.ComponentType = ComponentType.Cable;
            cable2.Name = "MULTI-TEST-002";
            cable2.SheetNumber = 99007;
            cable2.Issue = "TEST";
            cable2.ComponentStatus = ComponentStatus.CurrentValid;
            cable2.Weight = 0.7m;
            cable2.Comment = "Second multi test cable";
            cable2.Color = ColorType.B;
            cable2.WireCount = 4;
            cable2.Length = 100.0m;
            cable2.IsShielded = true;
            cable2.Created = DateTime.UtcNow;
            cable2.CreatedById = Guid.NewGuid();

            DbCable cable3 = new DbCable();
            cable3.Id = Guid.NewGuid();
            cable3.ComponentType = ComponentType.Cable;
            cable3.Name = "MULTI-TEST-003";
            cable3.SheetNumber = 99008;
            cable3.Issue = "TEST";
            cable3.ComponentStatus = ComponentStatus.CurrentValid;
            cable3.Weight = 0.9m;
            cable3.Comment = "Third multi test cable";
            cable3.Color = ColorType.W;
            cable3.WireCount = 6;
            cable3.Length = 150.0m;
            cable3.IsShielded = false;
            cable3.Created = DateTime.UtcNow;
            cable3.CreatedById = Guid.NewGuid();

            cables.Add(cable1);
            cables.Add(cable2);
            cables.Add(cable3);

            // Act
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Cables.AddRange(cables);
                int saveResult = await context.SaveChangesAsync();

                // Assert
                EqualConstraint equalTo3 = Is.EqualTo(3);
                Assert.That(saveResult, equalTo3, "Should save three records");
            }

            // Verify count
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext verifyContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                int count = await verifyContext.Cables.CountAsync();
                GreaterThanOrEqualConstraint greaterThanOrEqualTo3 = Is.GreaterThanOrEqualTo(3);
                Assert.That(count, greaterThanOrEqualTo3, "Should have at least 3 cables in database");
            }
        }

        [Test]
        [Category("Unit")]
        public async Task CDbContext_6QueryCablesByColor_ReturnsFilteredResults()
        {
            // Arrange
            List<DbCable> cables = new List<DbCable>();
            DbCable cable1 = new DbCable();
            cable1.Id = Guid.NewGuid();
            cable1.ComponentType = ComponentType.Cable;
            cable1.Name = "RED-CABLE-001";
            cable1.SheetNumber = 99009;
            cable1.Issue = "TEST";
            cable1.ComponentStatus = ComponentStatus.CurrentValid;
            cable1.Weight = 0.5m;
            cable1.Comment = "Red cable";
            cable1.Color = ColorType.R;
            cable1.WireCount = 2;
            cable1.Length = 50.0m;
            cable1.IsShielded = false;
            cable1.Created = DateTime.UtcNow;
            cable1.CreatedById = Guid.NewGuid();

            DbCable cable2 = new DbCable();
            cable2.Id = Guid.NewGuid();
            cable2.ComponentType = ComponentType.Cable;
            cable2.Name = "BLUE-CABLE-001";
            cable2.SheetNumber = 99010;
            cable2.Issue = "TEST";
            cable2.ComponentStatus = ComponentStatus.CurrentValid;
            cable2.Weight = 0.6m;
            cable2.Comment = "Blue cable";
            cable2.Color = ColorType.B;
            cable2.WireCount = 3;
            cable2.Length = 75.0m;
            cable2.IsShielded = true;
            cable2.Created = DateTime.UtcNow;
            cable2.CreatedById = Guid.NewGuid();

            DbCable cable3 = new DbCable();
            cable3.Id = Guid.NewGuid();
            cable3.ComponentType = ComponentType.Cable;
            cable3.Name = "RED-CABLE-002";
            cable3.SheetNumber = 99011;
            cable3.Issue = "TEST";
            cable3.ComponentStatus = ComponentStatus.CurrentValid;
            cable3.Weight = 0.7m;
            cable3.Comment = "Another red cable";
            cable3.Color = ColorType.R;
            cable3.WireCount = 4;
            cable3.Length = 100.0m;
            cable3.IsShielded = false;
            cable3.Created = DateTime.UtcNow;
            cable3.CreatedById = Guid.NewGuid();

            cables.Add(cable1);
            cables.Add(cable2);
            cables.Add(cable3);

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
                context.Cables.AddRange(cables);
                await context.SaveChangesAsync();
            }

            // Act
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                CDbContext queryContext = scope.ServiceProvider.GetRequiredService<CDbContext>();
                List<DbCable> redCables = await queryContext.Cables
                    .AsNoTracking()
                    .Where(c => c.Color == ColorType.R)
                    .ToListAsync();

                // Assert
                Assert.That(redCables, Is.Not.Null);
                EqualConstraint equalTo2 = Is.EqualTo(2);
                Assert.That(redCables.Count, equalTo2, "Should find exactly 2 red cables");
                bool redCablesAllRed = redCables.All(c => c.Color == ColorType.R);
                Assert.That(redCablesAllRed, Is.True, "All cables should be red");
            }
        }

        #endregion
    }
}
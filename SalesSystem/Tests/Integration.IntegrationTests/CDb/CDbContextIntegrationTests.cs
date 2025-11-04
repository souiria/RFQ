using CDb;
using CDb.Data.Context;
using CDb.Data.Model.Components;
using CDb.Data.Model.Masters;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Extensions;
using CDb.Services;

namespace Integration.Tests.CDb
{
    [TestFixture]
    public class CDbContextIntegrationTests
    {
        ServiceProvider _ServiceProvider;

        #region Test Data Constants
        readonly Guid _TestCableId;
        readonly Guid _TestCableId2;
        #endregion

        public CDbContextIntegrationTests()
        {
            _TestCableId = Guid.Parse("20250804-0000-0001-0001-0000DEADBEEF");
            _TestCableId2 = Guid.Parse("20250804-0000-0001-0002-0000DEADBEEF");
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            // Get the directory where the test assembly is located
            string testDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            // Navigate up to find the project root or specify the exact path to appsettings.json
            string thePath = Path.Combine(testDirectory, "..", "..", "..", "CDb");
            string projectRoot = Path.GetFullPath(thePath);
            
            // Configure appsettings.json with the correct path
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(projectRoot)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Debug: Log the configuration path and connection string
            Console.WriteLine($"Looking for appsettings.json in: {projectRoot}");
            string? connectionString = configuration.GetConnectionString("Database");
            Console.WriteLine($"Connection String: {connectionString ?? "NOT FOUND"}");

            // Add configuration to services
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq();
            });
            serviceCollection.AddInfrastructure(configuration);

            _ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown()
        {
            _ServiceProvider?.Dispose();
        }

        #region Database Connection Tests

        [Test]
        [Category("Integration")]
        public async Task CDbContext_0CanConnectToDatabase_ReturnsTrue()
        {
            // Act
            using CDbContext context = _ServiceProvider.GetRequiredService<CDbContext>();
            bool canConnect = await context.Database.CanConnectAsync();

            // Assert
            Assert.That(canConnect, Is.True, "Should be able to connect to the database");
        }

        [Test]
        [Category("Integration")]
        public void CDbContext_1HasRequiredDbSets_AllDbSetsAreNotNull()
        {
            using CDbContext context = _ServiceProvider.GetRequiredService<CDbContext>();
            // Assert - Master tables
            Assert.That(context.Database, Is.Not.Null, "ClipTypes DbSet should not be null");
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
        [Category("Integration")]
        public async Task CDbContext_2CreateAndRetrieveCable_ReturnsCorrectData()
        {
            // Arrange
            using CDbContext context = _ServiceProvider.GetRequiredService<CDbContext>();

            DbCable cable = new DbCable();
            cable.Id = _TestCableId;
            cable.ComponentType = ComponentType.Cable;
            cable.Name = "TEST-CABLE-001";
            cable.SheetNumber = 99001;
            cable.Issue = "TEST";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.75m;
            cable.Comment = "Integration test cable";
            cable.Color = ColorType.B;
            cable.WireCount = 4;
            cable.Length = 100.5m;
            cable.IsShielded = true;
            cable.Created = DateTime.UtcNow;
            cable.CreatedById = Guid.NewGuid();

            // Act - Create
            context.Cables.Add(cable);
            int saveResult = await context.SaveChangesAsync();

            // Assert - Save operation
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(saveResult, equalConstraint, "Should save one record");

            // Act - Retrieve
            DbCable? retrievedCable = await context.Cables
                .FirstOrDefaultAsync(c => c.Id == _TestCableId);

            // Assert - Retrieved data
            Assert.That(retrievedCable, Is.Not.Null, "Cable should be retrieved");
            equalConstraint = Is.EqualTo("TEST-CABLE-001");
            Assert.That(retrievedCable.Name, equalConstraint);
            equalConstraint = Is.EqualTo(ComponentType.Cable);
            Assert.That(retrievedCable.ComponentType, equalConstraint);
            equalConstraint = Is.EqualTo(4);
            Assert.That(retrievedCable.WireCount, equalConstraint);
            NUnit.Framework.Constraints.TrueConstraint boolConstraint = Is.True;
            Assert.That(retrievedCable.IsShielded, boolConstraint);
        }

        [Test]
        [Category("Integration")]
        public async Task CDbContext_3UpdateComponent_ReflectsChanges()
        {
            // Arrange - Create a component first
            using CDbContext context = _ServiceProvider.GetRequiredService<CDbContext>();

            DbCable cable = new DbCable();
            cable.Id = _TestCableId2;
            cable.ComponentType = ComponentType.Cable;
            cable.Name = "ORIGINAL-NAME";
            cable.SheetNumber = 99003;
            cable.Issue = "Original comment";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.75m;
            cable.Comment = "Integration test cable";
            cable.Color = ColorType.R;
            cable.WireCount = 4;
            cable.Length = 100.5m;
            cable.IsShielded = true;
            cable.Created = DateTime.UtcNow;
            cable.CreatedById = Guid.NewGuid();

            context.Cables.Add(cable);
            await context.SaveChangesAsync();

            // Act - Update the component
            cable.Name = "UPDATED-NAME";
            cable.Comment = "Updated comment";
            cable.Color = ColorType.B;
            cable.WireCount = 8;
            cable.Updated = DateTime.UtcNow;
            cable.UpdatedById = Guid.NewGuid();

            int updateResult = await context.SaveChangesAsync();

            // Assert
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(updateResult, equalConstraint, "Should update one record");

            // Verify the changes
            DbCable? updatedCable = await context.Cables
                .FirstOrDefaultAsync(c => c.Id == _TestCableId2);

            Assert.That(updatedCable, Is.Not.Null, "Updated cable should not be null");
            equalConstraint = Is.EqualTo("UPDATED-NAME");
            Assert.That(updatedCable.Name, equalConstraint);
            equalConstraint = Is.EqualTo("Updated comment");
            Assert.That(updatedCable.Comment, equalConstraint);
            equalConstraint = Is.EqualTo(ColorType.B);
            Assert.That(updatedCable.Color, equalConstraint);
            equalConstraint = Is.EqualTo(8);
            Assert.That(updatedCable.WireCount, equalConstraint);
        }

        [Test]
        public async Task CDbContext_4DeleteComponent_RemovesFromDatabase()
        {
            // Arrange
            using CDbContext context = _ServiceProvider.GetRequiredService<CDbContext>();

            DbCable? cable = context.Cables.FirstOrDefault(c => c.Id == _TestCableId);

            Assert.That(cable, Is.Not.Null, "Cable should exist before deletion");
            context.Cables.Remove(cable);
            await context.SaveChangesAsync();

            cable = context.Cables.FirstOrDefault(c => c.Id == _TestCableId2);

            Assert.That(cable, Is.Not.Null, "Cable should exist before deletion");
            context.Cables.Remove(cable);
            await context.SaveChangesAsync();

            // Verify deletion
            DbCable? deletedCable = await context.Cables
                .FirstOrDefaultAsync(c => c.Id == _TestCableId);
            Assert.That(deletedCable, Is.Null, "Cable should no longer exist after deletion");

            deletedCable = await context.Cables
                .FirstOrDefaultAsync(c => c.Id == _TestCableId2);
            Assert.That(deletedCable, Is.Null, "Cable should no longer exist after deletion");
        }

        #endregion
    }
}
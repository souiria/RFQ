using CDb;
using CDb.Data.Context;
using CDb.Data.Model.Components;
using CDb.Enums;
using CDb.Extensions;
using SharedKernel;

namespace Unit.Tests.CDb
{
    [TestFixture]
    public class CompositeComponentsUnitTests
    {
        ServiceProvider _ServiceProvider;
        string _DatabaseName;

        #region Test Data Constants
        readonly Guid _ClipId;
        readonly Guid _CableId;
        #endregion

        public CompositeComponentsUnitTests()
        {
            _ClipId = Guid.Parse("20250731-0000-0099-0001-0000DEADBEEF");
            _CableId = Guid.Parse("20250731-0000-0099-0020-0000DEADBEEF");

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

            // Configure in-memory database with a unique name for the test run
            Guid databaseGuid = Guid.NewGuid();
            _DatabaseName = $"TestCDb_{databaseGuid}";
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
            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Database.EnsureCreated();
            scope.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up database
            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Database.EnsureDeleted();
            scope.Dispose();

            // Dispose service provider
            _ServiceProvider?.Dispose();
        }

        #region Composite Component Tests

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_1CreateCableAndClip_SavesCorrectly()
        {
            // Arrange - Create Cable
            DbCable cable = new DbCable();
            cable.Id = _CableId;
            cable.ComponentType = ComponentType.Cable;
            string cableEnumDescription = ComponentType.Cable.GetEnumDescription();
            cable.Name = $"{cableEnumDescription}-020";
            cable.SheetNumber = 90020;
            cable.Issue = "A";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.5m;
            cable.Comment = "A standard blue cable used in various applications.";
            cable.Color = ColorType.B;
            cable.WireCount = 8;
            cable.Length = 150m;
            cable.IsShielded = true;
            DateTime utcNow = DateTime.UtcNow;
            cable.Created = utcNow;
            Guid createdById = Guid.NewGuid();
            cable.CreatedById = createdById;

            // Arrange - Create Clip
            DbClip clip = new DbClip();
            clip.Id = _ClipId;
            clip.ComponentType = ComponentType.Clip;
            string clipEnumDescription = ComponentType.Clip.GetEnumDescription();
            clip.Name = $"{clipEnumDescription}-001";
            clip.SheetNumber = 90001;
            clip.Issue = "A";
            clip.ComponentStatus = ComponentStatus.CurrentValid;
            clip.Weight = 0.5m;
            clip.Comment = "A clip used in various harnesses.";
            Guid clipTypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip.ClipTypeId = clipTypeId;
            clip.TieType = TieType.PLASTIC_CLIP;
            clip.DimensionCode = "W60x42";
            clip.ThicknessCode = "T1.5";
            clip.Length = 60m;
            clip.IsDoubleHarness = false;
            clip.ClipOrientationStart = 0;
            clip.ClipOrientationEnd = 90;
            DateTime clipCreated = DateTime.UtcNow;
            clip.Created = clipCreated;
            Guid clipCreatedById = Guid.NewGuid();
            clip.CreatedById = clipCreatedById;

            // Act - Save both components
            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Cables.Add(cable);
            context.Clips.Add(clip);
            int saveResult = await context.SaveChangesAsync();
            scope.Dispose();

            // Assert - Save operation
            NUnit.Framework.Constraints.EqualConstraint equalTo2 = Is.EqualTo(2);
            Assert.That(saveResult, equalTo2, "Should save two records");

            // Verify - Retrieve and check cable
            IServiceScope verifyScope1 = _ServiceProvider.CreateScope();
            CDbContext verifyContext1 = verifyScope1.ServiceProvider.GetRequiredService<CDbContext>();
            DbCable? retrievedCable = await verifyContext1.Cables
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _CableId);
            verifyScope1.Dispose();

            Assert.That(retrievedCable, Is.Not.Null, "Cable should be retrieved");
            string expectedCableName = $"{cableEnumDescription}-020";
            NUnit.Framework.Constraints.EqualConstraint equalToCableName = Is.EqualTo(expectedCableName);
            Assert.That(retrievedCable.Name, equalToCableName);
            NUnit.Framework.Constraints.EqualConstraint equalToWireCount = Is.EqualTo(8);
            Assert.That(retrievedCable.WireCount, equalToWireCount);
            Assert.That(retrievedCable.IsShielded, Is.True);
            NUnit.Framework.Constraints.EqualConstraint equalToColor = Is.EqualTo(ColorType.B);
            Assert.That(retrievedCable.Color, equalToColor);

            // Verify - Retrieve and check clip
            IServiceScope verifyScope2 = _ServiceProvider.CreateScope();
            CDbContext verifyContext2 = verifyScope2.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? retrievedClip = await verifyContext2.Clips
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _ClipId);
            verifyScope2.Dispose();

            Assert.That(retrievedClip, Is.Not.Null, "Clip should be retrieved");
            string expectedClipName = $"{clipEnumDescription}-001";
            NUnit.Framework.Constraints.EqualConstraint equalToClipName = Is.EqualTo(expectedClipName);
            Assert.That(retrievedClip.Name, equalToClipName);
            NUnit.Framework.Constraints.EqualConstraint equalToTieType = Is.EqualTo(TieType.PLASTIC_CLIP);
            Assert.That(retrievedClip.TieType, equalToTieType);
            NUnit.Framework.Constraints.EqualConstraint equalToLength = Is.EqualTo(60m);
            Assert.That(retrievedClip.Length, equalToLength);
        }

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_2GetAllComponents_ReturnsCorrectCount()
        {
            // Arrange - Create test data
            DbCable cable = new DbCable();
            cable.Id = _CableId;
            cable.ComponentType = ComponentType.Cable;
            string cableEnumDescription = ComponentType.Cable.GetEnumDescription();
            cable.Name = $"{cableEnumDescription}-020";
            cable.SheetNumber = 90020;
            cable.Issue = "A";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.5m;
            cable.Comment = "Test cable";
            cable.Color = ColorType.B;
            cable.WireCount = 8;
            cable.Length = 150m;
            cable.IsShielded = true;
            DateTime cableCreated = DateTime.UtcNow;
            cable.Created = cableCreated;
            Guid cableCreatedById = Guid.NewGuid();
            cable.CreatedById = cableCreatedById;

            DbClip clip = new DbClip();
            clip.Id = _ClipId;
            clip.ComponentType = ComponentType.Clip;
            string clipEnumDescription = ComponentType.Clip.GetEnumDescription();
            clip.Name = $"{clipEnumDescription}-001";
            clip.SheetNumber = 90001;
            clip.Issue = "A";
            clip.ComponentStatus = ComponentStatus.CurrentValid;
            clip.Weight = 0.5m;
            clip.Comment = "Test clip";
            Guid clipTypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip.ClipTypeId = clipTypeId;
            clip.TieType = TieType.PLASTIC_CLIP;
            clip.DimensionCode = "W60x42";
            clip.ThicknessCode = "T1.5";
            clip.Length = 60m;
            clip.IsDoubleHarness = false;
            clip.ClipOrientationStart = 0;
            clip.ClipOrientationEnd = 90;
            DateTime clipCreated = DateTime.UtcNow;
            clip.Created = clipCreated;
            Guid clipCreatedById = Guid.NewGuid();
            clip.CreatedById = clipCreatedById;

            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Cables.Add(cable);
            context.Clips.Add(clip);
            await context.SaveChangesAsync();
            scope.Dispose();

            // Act - Retrieve all components
            IServiceScope queryScope = _ServiceProvider.CreateScope();
            CDbContext queryContext = queryScope.ServiceProvider.GetRequiredService<CDbContext>();
            int cableCount = await queryContext.Cables.CountAsync();
            int clipCount = await queryContext.Clips.CountAsync();
            queryScope.Dispose();

            // Assert
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint greaterThanOrEqual1 = Is.GreaterThanOrEqualTo(1);
            Assert.That(cableCount, greaterThanOrEqual1, "Should have at least 1 cable");
            Assert.That(clipCount, greaterThanOrEqual1, "Should have at least 1 clip");
        }

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_3GetClipById_ReturnsCorrectClip()
        {
            // Arrange - Create clip
            DbClip clip = new DbClip();
            clip.Id = _ClipId;
            clip.ComponentType = ComponentType.Clip;
            string clipEnumDescription = ComponentType.Clip.GetEnumDescription();
            clip.Name = $"{clipEnumDescription}-001";
            clip.SheetNumber = 90001;
            clip.Issue = "A";
            clip.ComponentStatus = ComponentStatus.CurrentValid;
            clip.Weight = 0.5m;
            clip.Comment = "Test clip for retrieval";
            Guid clipTypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip.ClipTypeId = clipTypeId;
            clip.TieType = TieType.PLASTIC_CLIP;
            clip.DimensionCode = "W60x42";
            clip.ThicknessCode = "T1.5";
            clip.Length = 60m;
            clip.IsDoubleHarness = false;
            clip.ClipOrientationStart = 0;
            clip.ClipOrientationEnd = 90;
            DateTime clipCreated = DateTime.UtcNow;
            clip.Created = clipCreated;
            Guid clipCreatedById = Guid.NewGuid();
            clip.CreatedById = clipCreatedById;

            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Clips.Add(clip);
            await context.SaveChangesAsync();
            scope.Dispose();

            // Act - Retrieve clip by ID
            IServiceScope queryScope = _ServiceProvider.CreateScope();
            CDbContext queryContext = queryScope.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? retrievedClip = await queryContext.Clips
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _ClipId);
            queryScope.Dispose();

            // Assert
            Assert.That(retrievedClip, Is.Not.Null, "Clip should be retrieved");
            NUnit.Framework.Constraints.EqualConstraint equalToClipId = Is.EqualTo(_ClipId);
            Assert.That(retrievedClip.Id, equalToClipId);
            string expectedClipName = $"{clipEnumDescription}-001";
            NUnit.Framework.Constraints.EqualConstraint equalToClipName = Is.EqualTo(expectedClipName);
            Assert.That(retrievedClip.Name, equalToClipName);
            NUnit.Framework.Constraints.EqualConstraint equalToComponentType = Is.EqualTo(ComponentType.Clip);
            Assert.That(retrievedClip.ComponentType, equalToComponentType);
        }

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_4UpdateClip_ReflectsChanges()
        {
            string clipEnumDescription = ComponentType.Clip.GetEnumDescription();
            string originalName = $"{clipEnumDescription}-001";
            string updatedName = "DELETEME";
            string originalComment = "Original clip comment";
            string updatedComment = "DELETEME";
            decimal originalLength = 60m;
            decimal updatedLength = 111.11m;

            // Arrange - Create clip
            DbClip clip = new DbClip();
            clip.Id = _ClipId;
            clip.ComponentType = ComponentType.Clip;
            clip.Name = originalName;
            clip.SheetNumber = 90001;
            clip.Issue = "A";
            clip.ComponentStatus = ComponentStatus.CurrentValid;
            clip.Weight = 0.5m;
            clip.Comment = originalComment;
            Guid clipTypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip.ClipTypeId = clipTypeId;
            clip.TieType = TieType.PLASTIC_CLIP;
            clip.DimensionCode = "W60x42";
            clip.ThicknessCode = "T1.5";
            clip.Length = originalLength;
            clip.IsDoubleHarness = false;
            clip.ClipOrientationStart = 0;
            clip.ClipOrientationEnd = 90;
            DateTime clipCreated = DateTime.UtcNow;
            clip.Created = clipCreated;
            Guid clipCreatedById = Guid.NewGuid();
            clip.CreatedById = clipCreatedById;

            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Clips.Add(clip);
            await context.SaveChangesAsync();
            scope.Dispose();

            // Act - Update the clip
            IServiceScope updateScope = _ServiceProvider.CreateScope();
            CDbContext updateContext = updateScope.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? clipToUpdate = await updateContext.Clips
                .AsTracking()
                .FirstOrDefaultAsync(c => c.Id == _ClipId);

            Assert.That(clipToUpdate, Is.Not.Null, "Clip should exist before update");

            clipToUpdate.Name = updatedName;
            clipToUpdate.Comment = updatedComment;
            clipToUpdate.Length = updatedLength;
            DateTime updatedTime = DateTime.UtcNow;
            clipToUpdate.Updated = updatedTime;
            Guid updatedById = Guid.NewGuid();
            clipToUpdate.UpdatedById = updatedById;

            int updateResult = await updateContext.SaveChangesAsync();
            updateScope.Dispose();

            // Assert
            NUnit.Framework.Constraints.EqualConstraint equalTo1 = Is.EqualTo(1);
            Assert.That(updateResult, equalTo1, "Should update one record");

            // Verify the changes
            IServiceScope verifyScope = _ServiceProvider.CreateScope();
            CDbContext verifyContext = verifyScope.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? updatedClip = await verifyContext.Clips
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _ClipId);
            verifyScope.Dispose();

            Assert.That(updatedClip, Is.Not.Null, "Updated clip should not be null");
            NUnit.Framework.Constraints.EqualConstraint equalToUpdatedName = Is.EqualTo(updatedName);
            Assert.That(updatedClip.Name, equalToUpdatedName);
            NUnit.Framework.Constraints.EqualConstraint equalToUpdatedComment = Is.EqualTo(updatedComment);
            Assert.That(updatedClip.Comment, equalToUpdatedComment);
            NUnit.Framework.Constraints.EqualConstraint equalToUpdatedLength = Is.EqualTo(updatedLength);
            Assert.That(updatedClip.Length, equalToUpdatedLength);
        }

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_5DeleteCableAndClip_RemovesFromDatabase()
        {
            // Arrange - Create cable and clip
            DbCable cable = new DbCable();
            cable.Id = _CableId;
            cable.ComponentType = ComponentType.Cable;
            string cableEnumDescription = ComponentType.Cable.GetEnumDescription();
            cable.Name = $"{cableEnumDescription}-020";
            cable.SheetNumber = 90020;
            cable.Issue = "A";
            cable.ComponentStatus = ComponentStatus.CurrentValid;
            cable.Weight = 0.5m;
            cable.Comment = "Cable to delete";
            cable.Color = ColorType.B;
            cable.WireCount = 8;
            cable.Length = 150m;
            cable.IsShielded = true;
            DateTime cableCreated = DateTime.UtcNow;
            cable.Created = cableCreated;
            Guid cableCreatedById = Guid.NewGuid();
            cable.CreatedById = cableCreatedById;

            DbClip clip = new DbClip();
            clip.Id = _ClipId;
            clip.ComponentType = ComponentType.Clip;
            string clipEnumDescription = ComponentType.Clip.GetEnumDescription();
            clip.Name = $"{clipEnumDescription}-001";
            clip.SheetNumber = 90001;
            clip.Issue = "A";
            clip.ComponentStatus = ComponentStatus.CurrentValid;
            clip.Weight = 0.5m;
            clip.Comment = "Clip to delete";
            Guid clipTypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip.ClipTypeId = clipTypeId;
            clip.TieType = TieType.PLASTIC_CLIP;
            clip.DimensionCode = "W60x42";
            clip.ThicknessCode = "T1.5";
            clip.Length = 60m;
            clip.IsDoubleHarness = false;
            clip.ClipOrientationStart = 0;
            clip.ClipOrientationEnd = 90;
            DateTime clipCreated = DateTime.UtcNow;
            clip.Created = clipCreated;
            Guid clipCreatedById = Guid.NewGuid();
            clip.CreatedById = clipCreatedById;

            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Cables.Add(cable);
            context.Clips.Add(clip);
            await context.SaveChangesAsync();
            scope.Dispose();

            // Act - Delete clip
            IServiceScope deleteScope1 = _ServiceProvider.CreateScope();
            CDbContext deleteContext1 = deleteScope1.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? clipToDelete = await deleteContext1.Clips.FirstOrDefaultAsync(c => c.Id == _ClipId);
            Assert.That(clipToDelete, Is.Not.Null, "Clip should exist before deletion");

            deleteContext1.Clips.Remove(clipToDelete);
            await deleteContext1.SaveChangesAsync();
            deleteScope1.Dispose();

            // Act - Delete cable
            IServiceScope deleteScope2 = _ServiceProvider.CreateScope();
            CDbContext deleteContext2 = deleteScope2.ServiceProvider.GetRequiredService<CDbContext>();
            DbCable? cableToDelete = await deleteContext2.Cables.FirstOrDefaultAsync(c => c.Id == _CableId);
            Assert.That(cableToDelete, Is.Not.Null, "Cable should exist before deletion");

            deleteContext2.Cables.Remove(cableToDelete);
            await deleteContext2.SaveChangesAsync();
            deleteScope2.Dispose();

            // Verify deletion
            IServiceScope verifyScope = _ServiceProvider.CreateScope();
            CDbContext verifyContext = verifyScope.ServiceProvider.GetRequiredService<CDbContext>();
            DbClip? deletedClip = await verifyContext.Clips
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _ClipId);
            DbCable? deletedCable = await verifyContext.Cables
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == _CableId);
            verifyScope.Dispose();

            Assert.That(deletedClip, Is.Null, "Clip should no longer exist after deletion");
            Assert.That(deletedCable, Is.Null, "Cable should no longer exist after deletion");
        }

        [Test]
        [Category("Unit")]
        public async Task CompositeComponents_6QueryComponentsByType_ReturnsFilteredResults()
        {
            // Arrange - Create multiple cables and clips
            List<DbCable> cables = new List<DbCable>();
            DbCable cable1 = new DbCable();
            Guid cable1Id = Guid.NewGuid();
            cable1.Id = cable1Id;
            cable1.ComponentType = ComponentType.Cable;
            cable1.Name = "CABLE-001";
            cable1.SheetNumber = 90021;
            cable1.Issue = "A";
            cable1.ComponentStatus = ComponentStatus.CurrentValid;
            cable1.Weight = 0.5m;
            cable1.Comment = "First test cable";
            cable1.Color = ColorType.R;
            cable1.WireCount = 4;
            cable1.Length = 100m;
            cable1.IsShielded = false;
            DateTime cable1Created = DateTime.UtcNow;
            cable1.Created = cable1Created;
            Guid cable1CreatedById = Guid.NewGuid();
            cable1.CreatedById = cable1CreatedById;

            DbCable cable2 = new DbCable();
            Guid cable2Id = Guid.NewGuid();
            cable2.Id = cable2Id;
            cable2.ComponentType = ComponentType.Cable;
            cable2.Name = "CABLE-002";
            cable2.SheetNumber = 90022;
            cable2.Issue = "A";
            cable2.ComponentStatus = ComponentStatus.CurrentValid;
            cable2.Weight = 0.7m;
            cable2.Comment = "Second test cable";
            cable2.Color = ColorType.B;
            cable2.WireCount = 8;
            cable2.Length = 150m;
            cable2.IsShielded = true;
            DateTime cable2Created = DateTime.UtcNow;
            cable2.Created = cable2Created;
            Guid cable2CreatedById = Guid.NewGuid();
            cable2.CreatedById = cable2CreatedById;

            cables.Add(cable1);
            cables.Add(cable2);

            List<DbClip> clips = new List<DbClip>();
            DbClip clip1 = new DbClip();
            Guid clip1Id = Guid.NewGuid();
            clip1.Id = clip1Id;
            clip1.ComponentType = ComponentType.Clip;
            clip1.Name = "CLIP-001";
            clip1.SheetNumber = 90002;
            clip1.Issue = "A";
            clip1.ComponentStatus = ComponentStatus.CurrentValid;
            clip1.Weight = 0.3m;
            clip1.Comment = "First test clip";
            Guid clip1TypeId = Guid.Parse("76AD0414-D24A-4884-B76E-51317470BADF");
            clip1.ClipTypeId = clip1TypeId;
            clip1.TieType = TieType.PLASTIC_CLIP;
            clip1.DimensionCode = "W50x40";
            clip1.ThicknessCode = "T1.0";
            clip1.Length = 50m;
            clip1.IsDoubleHarness = false;
            clip1.ClipOrientationStart = 0;
            clip1.ClipOrientationEnd = 45;
            DateTime clip1Created = DateTime.UtcNow;
            clip1.Created = clip1Created;
            Guid clip1CreatedById = Guid.NewGuid();
            clip1.CreatedById = clip1CreatedById;

            clips.Add(clip1);

            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Cables.AddRange(cables);
            context.Clips.AddRange(clips);
            await context.SaveChangesAsync();
            scope.Dispose();

            // Act - Query cables
            IServiceScope queryScope1 = _ServiceProvider.CreateScope();
            CDbContext queryContext1 = queryScope1.ServiceProvider.GetRequiredService<CDbContext>();
            List<DbCable> retrievedCables = await queryContext1.Cables
                .AsNoTracking()
                .Where(c => c.ComponentType == ComponentType.Cable)
                .ToListAsync();
            queryScope1.Dispose();

            // Assert
            Assert.That(retrievedCables, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalTo2 = Is.EqualTo(2);
            Assert.That(retrievedCables.Count, equalTo2, "Should find exactly 2 cables");
            bool allCables = retrievedCables.All(c => c.ComponentType == ComponentType.Cable);
            Assert.That(allCables, Is.True, "All components should be cables");

            // Act - Query clips
            IServiceScope queryScope2 = _ServiceProvider.CreateScope();
            CDbContext queryContext2 = queryScope2.ServiceProvider.GetRequiredService<CDbContext>();
            List<DbClip> retrievedClips = await queryContext2.Clips
                .AsNoTracking()
                .Where(c => c.ComponentType == ComponentType.Clip)
                .ToListAsync();
            queryScope2.Dispose();

            // Assert
            Assert.That(retrievedClips, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalTo1 = Is.EqualTo(1);
            Assert.That(retrievedClips.Count, equalTo1, "Should find exactly 1 clip");
            bool allClips = retrievedClips.All(c => c.ComponentType == ComponentType.Clip);
            Assert.That(allClips, Is.True, "All components should be clips");
        }

        #endregion
    }
}
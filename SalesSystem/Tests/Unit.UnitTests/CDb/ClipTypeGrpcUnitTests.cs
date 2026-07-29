using CDb;
using CDb.Data.Context;
using CDb.Data.Interface;
using CDb.Data.Model.Masters;
using CDb.Data.Repository;
using CDb.Data.Time;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Extensions;
using ServiceCollectionExtensions = CDb.Extensions.ServiceCollectionExtensions;
using CDb.Services;

namespace Unit.Tests.CDb
{
    [TestFixture]
    public class ClipTypeGrpcUnitTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;
        string _DatabaseName;

        #region Constants
        readonly Guid _CrudClipTypeId;
        #endregion

        public ClipTypeGrpcUnitTests()
        {
            _CrudClipTypeId = Guid.Parse("20250728-0000-0000-0001-0000DEADBEEF");
            _ServiceProvider = null!;
            _CDbAccessService = null!;
            _GrpcService = null!;
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

            // Add required infrastructure services
            serviceCollection.AddScoped(typeof(ICDbReadRepository<>), typeof(CDbRepository<>));
            serviceCollection.AddScoped(typeof(ICDbRepository<>), typeof(CDbRepository<>));
            serviceCollection.AddScoped<ICDbContext>(sp => sp.GetRequiredService<CDbContext>());

            // Add IDateTimeProvider
            serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // Add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Warning);
            });

            // Register all CQRS handlers using Scrutor
            serviceCollection.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtensions))
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            serviceCollection.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtensions))
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventsHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            serviceCollection.AddGrpc();
            serviceCollection.AddSingleton<ICDbAccessService, CDbAccessService>();

            _ServiceProvider = serviceCollection.BuildServiceProvider();

            // Ensure database is created using a scoped context
            IServiceScope scope = _ServiceProvider.CreateScope();
            CDbContext context = scope.ServiceProvider.GetRequiredService<CDbContext>();
            context.Database.EnsureCreated();
            scope.Dispose();

            // Initialize services
            _CDbAccessService = new CDbAccessService(_ServiceProvider, true);
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
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

        [Test]
        [Category("Unit")]
        public void SayHelloTest()
        {
            // Arrange
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "ClipTypeGrpcUnitTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            // Act
            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            // Assert
            string replyString = "Hello ClipTypeGrpcUnitTests";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetAllClipTypeGrpcsTest()
        {
            // Arrange
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbClipTypeGrpc adds 7 records to the database
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(5);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetByIdClipTypeGrpcTest()
        {
            // Arrange
            // First, get all ClipTypes to see what IDs are actually available
            ClipTypeGrpcRequest getAllRequest = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            getAllRequest.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext getAllContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> allResponse = _GrpcService.ReadClipTypeGrpc(getAllRequest, getAllContext);

            // Ensure we have at least one ClipType in the database
            NUnit.Framework.Constraints.GreaterThanConstraint greaterThanZeroConstraint = Is.GreaterThan(0);
            Assert.That(allResponse.Result.ClipTypeGrpcs.Count, greaterThanZeroConstraint, "No ClipTypes found in database for testing");

            // Get the first ClipType's ID for our test
            string validId = allResponse.Result.ClipTypeGrpcs[0].Id;

            // Now test FilterCdbDataGrpc with a valid ID
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.FilterExpression = $"Id != null && Id == \"{validId}\"";
            request.DatabaseList = "CLIPTYPEGRPC";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(validId);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs[0].Id, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetByCodeClipTypeGrpcTest()
        {
            // Arrange
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.FilterExpression = $"Code != null && Code == \"DOUBLE\"";
            request.DatabaseList = "CLIPTYPEGRPC";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(1);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public async Task CreateClipTypeGrpcTest()
        {
            // Check if the test clip already exists using the filter API
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            string clipTypeIdString = _CrudClipTypeId.ToString().ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{clipTypeIdString}\"";
            filterRequest.DatabaseList = "CLIPTYPEGRPC";
            ServerCallContext filterContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act - Check if exists
            Task<CdbFilterResponseGrpc> filterResponse = _GrpcService.FilterCdbDataGrpc(filterRequest, filterContext);

            // Assert - Should not exist yet
            Assert.That(filterResponse.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterResponse.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);

            // Arrange - Create new ClipType
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new ClipTypeGrpc object to add
            ClipTypeGrpc clipTypeGrpc = new ClipTypeGrpc();
            clipTypeGrpc.Code = "CREATED";
            clipTypeGrpc.Description = "Created";
            clipTypeGrpc.Id = clipTypeIdString;
            request.ClipTypeGrpcsToCreate.Add(clipTypeGrpc);

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateClipTypeGrpc));

            // Act - Create
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateClipTypeGrpc(request, serverCallContext);

            // Assert - Creation successful
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        // Private helper method to create a mock ServerCallContext
        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                method: methodName,
                host: "localhost",
                deadline: deadline,
                requestHeaders: metadata,
                cancellationToken: CancellationToken.None,
                peer: "10.0.0.25:5001",
                authContext: null,
                contextPropagationToken: null,
                writeHeadersFunc: (metadata) => Task.CompletedTask,
                writeOptionsGetter: () => new WriteOptions(),
                writeOptionsSetter: (writeOptions) => { }
            );
            return serverCallContext;
        }
    }
}
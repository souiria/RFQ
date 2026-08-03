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
    public class ClipTypesIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudClipTypeId;
        #endregion

        public ClipTypesIntegrationTests()
        {
            _CrudClipTypeId = "20250728-0000-0000-0001-0000DEADBEEF"; // crud test clip type ID
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
            serviceCollection.AddGrpc();
            serviceCollection.AddInfrastructure(configuration);
            serviceCollection.AddSingleton<ICDbAccessService, CDbAccessService>();

            _ServiceProvider = serviceCollection.BuildServiceProvider();
            
            // Pass the service provider with registered services
            _CDbAccessService = new CDbAccessService(_ServiceProvider, true); // yeah, I'm using the real service here, not a mock
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _ServiceProvider?.Dispose();
        }

        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "ClipTypesIntegrationTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello ClipTypesIntegrationTests";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllClipTypesTest()
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
            // The HasData in the DbClipType adds 7 records to the database
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(5);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);
        }

        //[Test]
        //[Category("Integration")]

        //public void GetActiveClipTypesTest()
        //{
        //    ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
        //    grpcRequestParameter.BoolValue = true;
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

        //    Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
        //    Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(4);
        //    Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        //}

        //[Test]
        //[Category("Integration")]

        //public void GetNotActiveClipTypesTest()
        //{
        //    ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
        //    grpcRequestParameter.BoolValue = false; // Only not active clip types
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

        //    Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
        //    Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        //}
        [Test]
        [Category("Integration")]
        public void GetByIdClipTypeTest()
        {
            // Arrange
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "CLIPTYPEGRPC";
            request.FilterExpression = $"Id != null && Id == \"CDD0D832-7ED0-4141-953C-2A1909DD5181\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbClipType adds UNKNOWN CLIP TYPE
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);

            // Check if the ClipTypeGrpc has the expected ID
            EqualConstraint idConstraint = Is.EqualTo("CDD0D832-7ED0-4141-953C-2A1909DD5181");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string clipTypeId = response.Result.ListClipTypes.ClipTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(clipTypeId, idConstraint);
            // Check if the ClipTypeGrpc has the expected Name
            EqualConstraint codeConstraint = Is.EqualTo("DOUBLE");
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs[0].Code, codeConstraint);
            // Check if the ClipTypeGrpc has the expected Description
            EqualConstraint descriptionConstraint = Is.EqualTo("Double");
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs[0].Description, descriptionConstraint);

        }

        [Test]
        [Category("Integration")]
        public void GetByCodeClipTypeTest()
        {
            // Arrange
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "CLIPTYPEGRPC";
            request.FilterExpression = $"Code != null && Code == \"OVALSHAPED\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbClipType adds OVALSHAPED CLIP TYPE
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);

            // Check if the ClipTypeGrpc has the expected ID
            EqualConstraint codeConstraint = Is.EqualTo("OVALSHAPED");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string clipTypeId = response.Result.ListClipTypes.ClipTypeGrpcs[0].Code.ToUpper(cultureInfo);
            Assert.That(clipTypeId, codeConstraint);

        }

        [Test]
        [Category("Integration")]
        public async Task CreateClipTypeTest()
        {
            // Check if the test clip already exists
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "CLIPTYPEGRPC";
            request.FilterExpression = $"Id != null && Id == \"{_CrudClipTypeId}\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);

            // Arrange
            ClipTypeGrpcRequest createRequest = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            createRequest.GrpcRequestParameter = grpcRequestParameter;

            // Create a new ClipTypeGrpc object to add
            ClipTypeGrpc clipTypeGrpc = new ClipTypeGrpc();
            clipTypeGrpc.Code = "CREATED";
            clipTypeGrpc.Description = "Created";
            clipTypeGrpc.Id = _CrudClipTypeId;
            createRequest.ClipTypeGrpcsToCreate.Add(clipTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateClipTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateClipTypeGrpc(createRequest, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        //TODO: Fix Tests for Update
        //[Test]
        //[Category("Integration")]
        //public async Task UpdateClipTypeTest()
        //{
        //    // Check if the test clip already exists
        //    ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadById;
        //    grpcRequestParameter.StringValue = _CrudClipTypeId; // test id  
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

        //    // Act
        //    Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

        //    ClipTypeGrpc theClip = response.Result.ClipTypeGrpcs[0];

        //    // Arrange
        //    request = new ClipTypeGrpcRequest();
        //    grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.Update;
        //    request.GrpcRequestParameter = grpcRequestParameter;

        //    // Do some updates ClipTypeGrpc object to add
        //    theClip.Code = "DELETEME";
        //    theClip.Description = "DELETEME";
        //    theClip.IsActive = false;
        //    request.ClipTypeGrpcsToUpdate.Add(theClip);

        //    serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateClipTypeGrpc));

        //    // Act
        //    CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateClipTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(crudResponse, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
        //    Assert.That(crudResponse.SaveSuccess, statusConstraint);
        //}

        [Test]
        [Category("Integration")]

        public async Task XDeleteClipTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbClipType? dbClipType = await dbContext.ClipTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudClipTypeId);
            Assert.That(dbClipType, Is.Not.Null, "The ClipType to delete was not found in the database.");
            dbContext.ClipTypes.Remove(dbClipType);
            await dbContext.SaveChangesAsync();

            // Check if the test clip already exists
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "CLIPTYPEGRPC";
            request.FilterExpression = $"Id != null && Id == \"{_CrudClipTypeId}\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.ListClipTypes.ClipTypeGrpcs.Count, countConstraint);

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
namespace CdbAccess.Tests
{
    public class WireTypesTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudWireTypeId;
        #endregion

        public WireTypesTests()
        {
            _CrudWireTypeId = "20250730-0000-0000-0015-0000DEADBEEF"; // crud test wire type ID
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            string currentDirectory = Directory.GetCurrentDirectory();
            // Configure appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            
            // Add configuration to services
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq();
            });
            serviceCollection.AddGrpc();
            serviceCollection.AddInfrastructure(configuration);
            serviceCollection.AddSingleton<ICDbAccessService, CDbAccessService>();

            _ServiceProvider = serviceCollection.BuildServiceProvider();
            
            // Pass the service provider with registered services
            _CDbAccessService = new CDbAccessService(_ServiceProvider, false); // yeah, I'm using the real service here, not a mock
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _ServiceProvider?.Dispose();
        }

        [Test]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "WireTypesTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello WireTypesTests";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        public void GetAllWireTypesTest()
        {
            // Arrange
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbWireType adds 7 records to the database
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(7);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByIdWireTypeTest()
        {
            // Arrange
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = "A7821889-8F42-4745-8DB1-026485ADFDE7"; // G3C wire type  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbWireType adds G3C wire type
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);

            // Check if the WireTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("A7821889-8F42-4745-8DB1-026485ADFDE7");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string wireTypeId = response.Result.WireTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(wireTypeId, idConstraint);
            // Check if the WireTypeGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("G3C");
            Assert.That(response.Result.WireTypeGrpcs[0].Code, codeConstraint);
            // Check if the WireTypeGrpc has the expected Description
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("G3C");
            Assert.That(response.Result.WireTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        public void GetByCodeWireTypeTest()
        {
            // Arrange
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByCode;
            grpcRequestParameter.StringValue = "G3C"; // G3C wire type  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbWireType adds G3C wire type
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);

            // Check if the WireTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("G3C");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string wireTypeId = response.Result.WireTypeGrpcs[0].Code.ToUpper(cultureInfo);
            Assert.That(wireTypeId, codeConstraint);

        }
        [Test]
        public async Task CreateWireTypeTest()
        {
            // Check if the test wire already exists
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudWireTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);

            // Arrange
            request = new WireTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new WireTypeGrpc object to add
            WireTypeGrpc wireTypeGrpc = new WireTypeGrpc();
            wireTypeGrpc.Code = "CREATED";
            wireTypeGrpc.Description = "Created";
            wireTypeGrpc.Id = _CrudWireTypeId;
            request.WireTypeGrpcsToCreate.Add(wireTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateWireTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateWireTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        [Test]
        public async Task UpdateWireTypeTest()
        {
            // Check if the test wire already exists
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudWireTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);

            WireTypeGrpc theWire = response.Result.WireTypeGrpcs[0];

            // Arrange
            request = new WireTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates WireTypeGrpc object to add
            theWire.Code = "DELETEME";
            theWire.Description = "DELETEME";
            theWire.IsActive = false;
            request.WireTypeGrpcsToUpdate.Add(theWire);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateWireTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateWireTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        public async Task XDeleteWireTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbWireType? dbWireType = await dbContext.WireTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudWireTypeId);
            Assert.That(dbWireType, Is.Not.Null, "The WireType to delete was not found in the database.");
            dbContext.WireTypes.Remove(dbWireType);
            await dbContext.SaveChangesAsync();

            // Check if the test wire already exists
            WireTypeGrpcRequest request = new WireTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudWireTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadWireTypeGrpc));

            // Act
            Task<ListWireTypeGrpc> response = _GrpcService.ReadWireTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.WireTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.WireTypeGrpcs.Count, countConstraint);

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
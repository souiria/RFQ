namespace CdbAccess.Tests
{
    public class CrimpingProcessTypesTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudCrimpingProcessTypeId;
        #endregion

        public CrimpingProcessTypesTests()
        {
            _CrudCrimpingProcessTypeId = "20250728-0000-0000-0003-0000DEADBEEF"; // crud test crimpigProcess type ID
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
        public void GetAllCrimpingProcessTypesTest()
        {
            // Arrange
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCrimpingProcessType adds 7 records to the database
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(4);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByIdCrimpingProcessTypeTest()
        {
            // Arrange
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = "D48A67F0-716D-485B-858A-47FECB598133"; // Unknown crimping process type
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCrimpingProcessType adds Unknown crimping process type
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);

            // Check if the CrimpingProcessTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("D48A67F0-716D-485B-858A-47FECB598133");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string crimpigProcessTypeId = response.Result.CrimpingProcessTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(crimpigProcessTypeId, idConstraint);
            // Check if the CrimpingProcessTypeGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.CrimpingProcessTypeGrpcs[0].Code, codeConstraint);
            // Check if the CrimpingProcessTypeGrpc has the expected Description
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.CrimpingProcessTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        public void GetByCodeCrimpingProcessTypeTest()
        {
            // Arrange
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByCode;
            grpcRequestParameter.StringValue = "Unknown";
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCrimpingProcessType adds Unknown crimping process type
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);

            // Check if the CrimpingProcessTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            string crimpigProcessTypeId = response.Result.CrimpingProcessTypeGrpcs[0].Code;
            Assert.That(crimpigProcessTypeId, codeConstraint);

        }
        [Test]
        public async Task CreateCrimpingProcessTypeTest()
        {
            // Check if the test crimpigProcess already exists
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCrimpingProcessTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);

            // Arrange
            request = new CrimpingProcessTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new CrimpingProcessTypeGrpc object to add
            CrimpingProcessTypeGrpc crimpigProcessTypeGrpc = new CrimpingProcessTypeGrpc();
            crimpigProcessTypeGrpc.Code = "CREATED";
            crimpigProcessTypeGrpc.Description = "Created";
            crimpigProcessTypeGrpc.Id = _CrudCrimpingProcessTypeId;
            request.CrimpingProcessTypeGrpcsToCreate.Add(crimpigProcessTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateCrimpingProcessTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        [Test]
        public async Task UpdateCrimpingProcessTypeTest()
        {
            // Check if the test crimpigProcess already exists
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCrimpingProcessTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);

            CrimpingProcessTypeGrpc theCrimpingProcess = response.Result.CrimpingProcessTypeGrpcs[0];

            // Arrange
            request = new CrimpingProcessTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates CrimpingProcessTypeGrpc object to add
            theCrimpingProcess.Code = "DELETEME";
            theCrimpingProcess.Description = "DELETEME";
            theCrimpingProcess.IsActive = false;
            request.CrimpingProcessTypeGrpcsToUpdate.Add(theCrimpingProcess);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateCrimpingProcessTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        public async Task XDeleteCrimpingProcessTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbCrimpingProcessType? dbCrimpingProcessType = await dbContext.CrimpingProcessTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudCrimpingProcessTypeId);
            Assert.That(dbCrimpingProcessType, Is.Not.Null, "The CrimpingProcessType to delete was not found in the database.");
            dbContext.CrimpingProcessTypes.Remove(dbCrimpingProcessType);
            await dbContext.SaveChangesAsync();

            // Check if the test crimpigProcess already exists
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCrimpingProcessTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));

            // Act
            Task<ListCrimpingProcessTypeGrpc> response = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CrimpingProcessTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.CrimpingProcessTypeGrpcs.Count, countConstraint);

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
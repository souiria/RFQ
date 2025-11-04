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
    public class CoverTypesIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudCoverTypeId;
        #endregion

        public CoverTypesIntegrationTests()
        {
            _CrudCoverTypeId = "20250729-0000-0000-0003-0000DEADBEEF"; // crud test cover type ID
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
        [Category("Integration")]
        public void GetAllCoverTypesTest()
        {
            // Arrange
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCoverType adds 7 records to the database
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(4);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);
        }
        [Test]
        [Category("Integration")]
        public void GetByIdCoverTypeTest()
        {
            // Arrange
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = "44985F7A-9BAD-45AA-9C57-DA426DA40D29"; // Unknown cover type
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCoverType adds Unknown cover type
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);

            // Check if the CoverTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("44985F7A-9BAD-45AA-9C57-DA426DA40D29");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string coverTypeId = response.Result.CoverTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(coverTypeId, idConstraint);
            // Check if the CoverTypeGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.CoverTypeGrpcs[0].Code, codeConstraint);
            // Check if the CoverTypeGrpc has the expected Description
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.CoverTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        [Category("Integration")]
        public void GetByCodeCoverTypeTest()
        {
            // Arrange
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByCode;
            grpcRequestParameter.StringValue = "Unknown";
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbCoverType adds Unknown cover type
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);

            // Check if the CoverTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            string coverTypeId = response.Result.CoverTypeGrpcs[0].Code;
            Assert.That(coverTypeId, codeConstraint);

        }
        [Test]
        [Category("Integration")]
        public async Task CreateCoverTypeTest()
        {
            // Check if the test cover already exists
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCoverTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);

            // Arrange
            request = new CoverTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new CoverTypeGrpc object to add
            CoverTypeGrpc coverTypeGrpc = new CoverTypeGrpc();
            coverTypeGrpc.Code = "CREATED";
            coverTypeGrpc.Description = "Created";
            coverTypeGrpc.Id = _CrudCoverTypeId;
            request.CoverTypeGrpcsToCreate.Add(coverTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateCoverTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateCoverTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        [Test]
        [Category("Integration")]
        public async Task UpdateCoverTypeTest()
        {
            // Check if the test cover already exists
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCoverTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);

            CoverTypeGrpc theCover = response.Result.CoverTypeGrpcs[0];

            // Arrange
            request = new CoverTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates CoverTypeGrpc object to add
            theCover.Code = "DELETEME";
            theCover.Description = "DELETEME";
            theCover.IsActive = false;
            request.CoverTypeGrpcsToUpdate.Add(theCover);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateCoverTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateCoverTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        [Category("Integration")]
        public async Task XDeleteCoverTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbCoverType? dbCoverType = await dbContext.CoverTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudCoverTypeId);
            Assert.That(dbCoverType, Is.Not.Null, "The CoverType to delete was not found in the database.");
            dbContext.CoverTypes.Remove(dbCoverType);
            await dbContext.SaveChangesAsync();

            // Check if the test cover already exists
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudCoverTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));

            // Act
            Task<ListCoverTypeGrpc> response = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.CoverTypeGrpcs.Count, countConstraint);

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
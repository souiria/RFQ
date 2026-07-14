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
    public class FileTypesIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        //readonly string _CrudFileTypeId;
        #endregion

        public FileTypesIntegrationTests()
        {
            //_CrudFileTypeId = "20250728-0000-0001-0003-0000DEADBEEF"; // crud test file type ID
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
            HelloRequest request = new HelloRequest();
            request.Name = "FileTypesIntegrationTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello FileTypesIntegrationTests";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllFileTypesTest()
        {
            // Arrange
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbFileType adds 7 records to the database
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(4);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);
        }
        [Test]
        [Category("Integration")]
        public void GetByIdFileTypeTest()
        {
            // Arrange
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "FILETYPEGRPC";
            request.FilterExpression = $"Id != null && Id.ToUpperInvariant() == \"B481C105-2C10-49F6-912F-5EDF771BAD1C\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbFileType adds Generic file TYPE
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs.Count, countConstraint);

            // Check if the FileTypeGrpc has the expected ID
            EqualConstraint idConstraint = Is.EqualTo("B481C105-2C10-49F6-912F-5EDF771BAD1C");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string fileTypeId = response.Result.ListFileTypes.FileTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(fileTypeId, idConstraint);
            // Check if the FileTypeGrpc has the expected Name
            EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs[0].Name, codeConstraint);
            // Check if the FileTypeGrpc has the expected Description
            EqualConstraint descriptionConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        [Category("Integration")]
        public void GetByNameFileTypeTest()
        {
            // Arrange
            CdbFilterRequestGrpc request = new CdbFilterRequestGrpc();
            request.DatabaseList = "FILETYPEGRPC";
            request.FilterExpression = $"Name != null && Name.ToUpperInvariant() == \"TUBULAR\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            // Act
            Task<CdbFilterResponseGrpc> response = _GrpcService.FilterCdbDataGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbFileType adds Generic file TYPE
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ListFileTypes.FileTypeGrpcs.Count, countConstraint);

            // Check if the FileTypeGrpc has the expected ID
            EqualConstraint nameConstraint = Is.EqualTo("TUBULAR");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string fileTypeId = response.Result.ListFileTypes.FileTypeGrpcs[0].Name.ToUpper(cultureInfo);
            Assert.That(fileTypeId, nameConstraint);

        }
        //[Test]
        //public async Task CreateFileTypeTest()
        //{
        //    // Check if the test file already exists
        //    FileTypeGrpcRequest request = new FileTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadById;
        //    grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

        //    // Act
        //    Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

        //    // Assert
        //    // Once run, if deadbeef is in the database, this will fail
        //    Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        //    Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

        //    // Arrange
        //    request = new FileTypeGrpcRequest();
        //    grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.Create;
        //    request.GrpcRequestParameter = grpcRequestParameter;

        //    // Create a new FileTypeGrpc object to add
        //    FileTypeGrpc fileTypeGrpc = new FileTypeGrpc();
        //    fileTypeGrpc.Name = "CREATED";
        //    fileTypeGrpc.Description = "Created";
        //    fileTypeGrpc.Id = _CrudFileTypeId;
        //    request.FileTypeGrpcsToCreate.Add(fileTypeGrpc);

        //    serverCallContext = CreateServerContext(nameof(_GrpcService.CreateFileTypeGrpc));

        //    // Act
        //    CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateFileTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(crudResponse, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
        //    Assert.That(crudResponse.SaveSuccess, statusConstraint);
        //}

        //[Test]
        //public async Task UpdateFileTypeTest()
        //{
        //    // Check if the test file already exists
        //    FileTypeGrpcRequest request = new FileTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadById;
        //    grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

        //    // Act
        //    Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

        //    FileTypeGrpc theFile = response.Result.FileTypeGrpcs[0];

        //    // Arrange
        //    request = new FileTypeGrpcRequest();
        //    grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.Update;
        //    request.GrpcRequestParameter = grpcRequestParameter;

        //    // Do some updates FileTypeGrpc object to add
        //    theFile.Name = "DELETEME";
        //    theFile.Description = "DELETEME";
        //    theFile.IsActive = false;
        //    request.FileTypeGrpcsToUpdate.Add(theFile);

        //    serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateFileTypeGrpc));

        //    // Act
        //    CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateFileTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(crudResponse, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
        //    Assert.That(crudResponse.SaveSuccess, statusConstraint);
        //}
        //[Test]
        //public async Task XDeleteFileTypeTest()
        //{
        //    // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
        //    CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
        //    DbFileType? dbFileType = await dbContext.FileTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudFileTypeId);
        //    Assert.That(dbFileType, Is.Not.Null, "The FileType to delete was not found in the database.");
        //    dbContext.FileTypes.Remove(dbFileType);
        //    await dbContext.SaveChangesAsync();

        //    // Check if the test file already exists
        //    FileTypeGrpcRequest request = new FileTypeGrpcRequest();
        //    GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
        //    grpcRequestParameter.RequestType = (int)RequestType.ReadById;
        //    grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
        //    request.GrpcRequestParameter = grpcRequestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

        //    // Act
        //    Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

        //    // Assert
        //    Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        //    Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

        //}

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
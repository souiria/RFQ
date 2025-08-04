using System.Globalization;
using CDb;
using CDb.Data.Context;
using CDb.Data.Model.Masters;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Extensions;
using CDb.Services;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace CdbAccess.Tests
{
    public class FileTypesTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudFileTypeId;
        #endregion

        public FileTypesTests()
        {
            _CrudFileTypeId = "20250728-0000-0001-0003-0000DEADBEEF"; // crud test file type ID
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
            request.Name = "FileTypesTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello FileTypesTests";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
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
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(7);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByIdFileTypeTest()
        {
            // Arrange
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = "17D27E0B-CF12-41BF-B28D-1A2433F3D61B"; // Generic file TYPE  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbFileType adds Generic file TYPE
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

            // Check if the FileTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("17D27E0B-CF12-41BF-B28D-1A2433F3D61B");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string fileTypeId = response.Result.FileTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(fileTypeId, idConstraint);
            // Check if the FileTypeGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Generic");
            Assert.That(response.Result.FileTypeGrpcs[0].Name, codeConstraint);
            // Check if the FileTypeGrpc has the expected Description
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("Generic");
            Assert.That(response.Result.FileTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        public void GetByNameFileTypeTest()
        {
            // Arrange
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByName;
            grpcRequestParameter.StringValue = "Generic"; // Generic file TYPE  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbFileType adds Generic file TYPE
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

            // Check if the FileTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("GENERIC");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string fileTypeId = response.Result.FileTypeGrpcs[0].Name.ToUpper(cultureInfo);
            Assert.That(fileTypeId, nameConstraint);

        }
        [Test]
        public async Task CreateFileTypeTest()
        {
            // Check if the test file already exists
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

            // Arrange
            request = new FileTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new FileTypeGrpc object to add
            FileTypeGrpc fileTypeGrpc = new FileTypeGrpc();
            fileTypeGrpc.Name = "CREATED";
            fileTypeGrpc.Description = "Created";
            fileTypeGrpc.Id = _CrudFileTypeId;
            request.FileTypeGrpcsToCreate.Add(fileTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateFileTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateFileTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        [Test]
        public async Task UpdateFileTypeTest()
        {
            // Check if the test file already exists
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

            FileTypeGrpc theFile = response.Result.FileTypeGrpcs[0];

            // Arrange
            request = new FileTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates FileTypeGrpc object to add
            theFile.Name = "DELETEME";
            theFile.Description = "DELETEME";
            theFile.IsActive = false;
            request.FileTypeGrpcsToUpdate.Add(theFile);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateFileTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateFileTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        public async Task XDeleteFileTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbFileType? dbFileType = await dbContext.FileTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudFileTypeId);
            Assert.That(dbFileType, Is.Not.Null, "The FileType to delete was not found in the database.");
            dbContext.FileTypes.Remove(dbFileType);
            await dbContext.SaveChangesAsync();

            // Check if the test file already exists
            FileTypeGrpcRequest request = new FileTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudFileTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadFileTypeGrpc));

            // Act
            Task<ListFileTypeGrpc> response = _GrpcService.ReadFileTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.FileTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.FileTypeGrpcs.Count, countConstraint);

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
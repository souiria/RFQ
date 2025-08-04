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
    public class ClipTypesTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _CrudClipTypeId;
        #endregion

        public ClipTypesTests()
        {
            _CrudClipTypeId = "20250728-0000-0000-0001-0000DEADBEEF"; // crud test clip type ID
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
            request.Name = "ClipTypesTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello ClipTypesTests";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
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
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(7);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByIdClipTypeTest()
        {
            // Arrange
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = "EDE18A04-94EC-4086-8BC1-8AF8553BBF5B"; // UNKNOWN CLIP TYPE  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbClipType adds UNKNOWN CLIP TYPE
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

            // Check if the ClipTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("EDE18A04-94EC-4086-8BC1-8AF8553BBF5B");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string clipTypeId = response.Result.ClipTypeGrpcs[0].Id.ToUpper(cultureInfo);
            Assert.That(clipTypeId, idConstraint);
            // Check if the ClipTypeGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("UNKNOWN");
            Assert.That(response.Result.ClipTypeGrpcs[0].Code, codeConstraint);
            // Check if the ClipTypeGrpc has the expected Description
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("Unknown");
            Assert.That(response.Result.ClipTypeGrpcs[0].Description, descriptionConstraint);

        }
        [Test]
        public void GetByCodeClipTypeTest()
        {
            // Arrange
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByCode;
            grpcRequestParameter.StringValue = "UNKNOWN"; // UNKNOWN CLIP TYPE  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            // The HasData in the DbClipType adds UNKNOWN CLIP TYPE
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

            // Check if the ClipTypeGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("UNKNOWN");
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string clipTypeId = response.Result.ClipTypeGrpcs[0].Code.ToUpper(cultureInfo);
            Assert.That(clipTypeId, codeConstraint);

        }
        [Test]
        public async Task CreateClipTypeTest()
        {
            // Check if the test clip already exists
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudClipTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            // Once run, if deadbeef is in the database, this will fail
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

            // Arrange
            request = new ClipTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Create a new ClipTypeGrpc object to add
            ClipTypeGrpc clipTypeGrpc = new ClipTypeGrpc();
            clipTypeGrpc.Code = "CREATED";
            clipTypeGrpc.Description = "Created";
            clipTypeGrpc.Id = _CrudClipTypeId;
            request.ClipTypeGrpcsToCreate.Add(clipTypeGrpc);

            serverCallContext = CreateServerContext(nameof(_GrpcService.CreateClipTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.CreateClipTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }

        [Test]
        public async Task UpdateClipTypeTest()
        {
            // Check if the test clip already exists
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudClipTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

            ClipTypeGrpc theClip = response.Result.ClipTypeGrpcs[0];

            // Arrange
            request = new ClipTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates ClipTypeGrpc object to add
            theClip.Code = "DELETEME";
            theClip.Description = "DELETEME";
            theClip.IsActive = false;
            request.ClipTypeGrpcsToUpdate.Add(theClip);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateClipTypeGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateClipTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        public async Task XDeleteClipTypeTest()
        {
            // there is no Grpc endpoint to delete this type of data, so we have to use the database context directly
            CDbContext dbContext = _ServiceProvider.GetRequiredService<CDbContext>();
            DbClipType? dbClipType = await dbContext.ClipTypes.FirstOrDefaultAsync(ct => ct.Id.ToString() == _CrudClipTypeId);
            Assert.That(dbClipType, Is.Not.Null, "The ClipType to delete was not found in the database.");
            dbContext.ClipTypes.Remove(dbClipType);
            await dbContext.SaveChangesAsync();

            // Check if the test clip already exists
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CrudClipTypeId; // test id  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            // Act
            Task<ListClipTypeGrpc> response = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(response.Result.ClipTypeGrpcs.Count, countConstraint);

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
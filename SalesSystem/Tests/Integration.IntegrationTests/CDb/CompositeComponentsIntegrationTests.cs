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
    public class CompositeComponentsIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;
        ServiceProvider _ServiceProvider;

        #region Constants
        readonly string _ClipId;
        readonly string _CableId;
        #endregion

        public CompositeComponentsIntegrationTests()
        {
            _ClipId = "20250731-0000-0099-0001-0000DEADBEEF"; // clip
            _CableId = "20250731-0000-0099-0020-0000DEADBEEF"; // cable
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
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "CompositeComponentsIntegrationTests";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello CompositeComponentsIntegrationTests";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }
        [Test]
        [Category("Integration")]
        public void CreateCompositeComponentTest()
        {
            // create a blue cable composite component
            CompositeComponentGrpc cable = new CompositeComponentGrpc(); // will be a cable and  the component sheet number will be 90020
            ComponentGrpc cableComponentData = new ComponentGrpc();
            cable.ComponentGrpc = cableComponentData;
            cable.ComponentGrpc.Id = _CableId;
            cable.ComponentGrpc.Name = $"{ComponentType.Cable.GetEnumDescription()}-020";
            cable.ComponentGrpc.ComponentType = (int)ComponentType.Cable;
            cable.ComponentGrpc.SheetNumber = 90020;
            cable.ComponentGrpc.Issue = "A";
            cable.ComponentGrpc.Weight = 0.5;
            cable.ComponentGrpc.Comment = "A standard blue cable used in various applications.";
            cable.ComponentGrpc.ComponentStatus = (int)ComponentStatus.CurrentValid;
            // add specific properties for the cable
            CableGrpc cablePartData = new CableGrpc();
            cable.CableGrpc = cablePartData;
            cable.CableGrpc.Id = _CableId;
            cable.CableGrpc.WireCount = 8;
            cable.CableGrpc.IsShielded = true;
            cable.CableGrpc.Length = 150;
            cable.CableGrpc.Color = (int)ColorType.B; // Blue

            // create a clip composite component
            CompositeComponentGrpc clip = new CompositeComponentGrpc(); // will be a clip and  the component sheet number will be 90001
            ComponentGrpc clipComponentData = new ComponentGrpc();
            clip.ComponentGrpc = clipComponentData;
            clip.ComponentGrpc.Id = _ClipId;
            clip.ComponentGrpc.Name = $"{ComponentType.Clip.GetEnumDescription()}-001";
            clip.ComponentGrpc.ComponentType = (int)ComponentType.Clip;
            clip.ComponentGrpc.SheetNumber = 90001;
            clip.ComponentGrpc.Issue = "A";
            clip.ComponentGrpc.Weight = 0.5;
            clip.ComponentGrpc.Comment = "A clip used in various harnesses.";
            clip.ComponentGrpc.ComponentStatus = (int)ComponentStatus.CurrentValid;
            // add specific properties for the clip
            ClipGrpc clipPartData = new ClipGrpc();
            clip.ClipGrpc = clipPartData;
            clip.ClipGrpc.Id = _ClipId;
            clip.ClipGrpc.ClipTypeId = "76AD0414-D24A-4884-B76E-51317470BADF"; // TIEWRAP
            clip.ClipGrpc.TieType = (int)TieType.PLASTIC_CLIP;
            clip.ClipGrpc.DimensionCode = "W60x42";
            clip.ClipGrpc.ThicknessCode = "T1.5";
            clip.ClipGrpc.Length = 60;
            clip.ClipGrpc.IsDoubleHarness = false;
            clip.ClipGrpc.ClipOrientationStart = 0;
            clip.ClipGrpc.ClipOrientationEnd = 90;

            // persist the components
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.CompositeComponentGrpcsToCreate.Add(cable);
            request.CompositeComponentGrpcsToCreate.Add(clip);
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateCompositeComponentGrpc));

            Task<CDbCrudGrpcResponse> getCompositeComponentGrpcReply = _GrpcService.CreateCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply, Is.Not.Null);
            Assert.That(getCompositeComponentGrpcReply.Result.SaveSuccess, Is.True);
        }
        [Test]
        [Category("Integration")]
        public void GetAllCompositeComponentsTest()
        {
            // Arrange
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // Act
            Task<ListCompositeComponentGrpc> response = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);

            // Assert
            // There should be 2 records in the database, one for the cable and one for the clip
            Assert.That(response, Is.Not.Null);
            NUnit.Framework.Constraints.GreaterThanOrEqualConstraint countConstraint = Is.GreaterThanOrEqualTo(2);
            Assert.That(response.Result.CompositeComponentGrpcs.Count, countConstraint);
        }
        [Test]
        [Category("Integration")]
        public void GetByIdCompositeComponentTest()
        {
            // Arrange
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ClipId;  
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // Act
            Task<ListCompositeComponentGrpc> response = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CompositeComponentGrpcs.Count, countConstraint);

            // Check if the CompositeComponentGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(_ClipId);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string wireTypeId = response.Result.CompositeComponentGrpcs[0].ComponentGrpc.Id.ToUpper(cultureInfo);
            Assert.That(wireTypeId, idConstraint);
            // Check if the CompositeComponentGrpc has the expected Name
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo($"{ComponentType.Clip.GetEnumDescription()}-001");
            Assert.That(response.Result.CompositeComponentGrpcs[0].ComponentGrpc.Name, nameConstraint);

        }
        [Test]
        [Category("Integration")]
        public async Task UpdateCompositeComponentTest()
        {
            // Get the clip by ID to update it
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ClipId;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // Act
            Task<ListCompositeComponentGrpc> response = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CompositeComponentGrpcs.Count, countConstraint);

            // Check if the CompositeComponentGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(_ClipId);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string clipId = response.Result.CompositeComponentGrpcs[0].ComponentGrpc.Id.ToUpper(cultureInfo);
            Assert.That(clipId, idConstraint);

            CompositeComponentGrpc theClip = response.Result.CompositeComponentGrpcs[0];

            // Arrange
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            request.GrpcRequestParameter = grpcRequestParameter;

            // Do some updates CompositeComponentGrpc object to add
            theClip.ComponentGrpc.Name = "DELETEME";
            theClip.ComponentGrpc.Comment = "DELETEME";
            theClip.ClipGrpc.Length = 111.11;
            request.CompositeComponentGrpcsToUpdate.Add(theClip);

            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateCompositeComponentGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.UpdateCompositeComponentGrpc(request, serverCallContext);

            // Assert
            Assert.That(crudResponse, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint statusConstraint = Is.EqualTo(true);
            Assert.That(crudResponse.SaveSuccess, statusConstraint);
        }
        [Test]
        [Category("Integration")]
        public async Task XDeleteCompositeComponentTest()
        {
            // Get the components and delete them all
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;

            // get the clip by ID to delete it
            grpcRequestParameter.StringValue = _ClipId;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // Act
            Task<ListCompositeComponentGrpc> response = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(response.Result.CompositeComponentGrpcs.Count, countConstraint);

            // Check if the CompositeComponentGrpc has the expected ID
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(_ClipId);
            CultureInfo invariantCultureInfo = CultureInfo.InvariantCulture;
            string clipId = response.Result.CompositeComponentGrpcs[0].ComponentGrpc.Id.ToUpper(invariantCultureInfo);
            Assert.That(clipId, idConstraint);

            //////// the clip is this one
            CompositeComponentGrpc theClip = response.Result.CompositeComponentGrpcs[0];

            // get the cable by ID to delete it

            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CableId;
            request.GrpcRequestParameter = grpcRequestParameter;

            serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // Act
            response = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);

            // Assert
            Assert.That(response.Result.CompositeComponentGrpcs, Is.Not.Null);
            Assert.That(response.Result.CompositeComponentGrpcs.Count, countConstraint);

            // Check if the CompositeComponentGrpc has the expected ID
            idConstraint = Is.EqualTo(_CableId);
            string cableId = response.Result.CompositeComponentGrpcs[0].ComponentGrpc.Id.ToUpper(invariantCultureInfo);
            Assert.That(cableId, idConstraint);

            //////// the cable is this one
            CompositeComponentGrpc theCable = response.Result.CompositeComponentGrpcs[0];

            // Delete the clip and cable
            grpcRequestParameter.RequestType = (int)RequestType.Delete;
            request.GrpcRequestParameter = grpcRequestParameter;
            request.CompositeComponentGrpcsToDelete.Add(theClip);
            request.CompositeComponentGrpcsToDelete.Add(theCable);
            serverCallContext = CreateServerContext(nameof(_GrpcService.DeleteCompositeComponentGrpc));

            // Act
            CDbCrudGrpcResponse crudResponse = await _GrpcService.DeleteCompositeComponentGrpc(request, serverCallContext);
            // Assert
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
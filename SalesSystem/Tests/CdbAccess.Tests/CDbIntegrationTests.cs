namespace CdbAccess.Tests
{
    public class CDbIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;

        // create an id for the component

        readonly string _ReadByIdCompositeCableComponentId;

        public CDbIntegrationTests()
        {

            _ReadByIdCompositeCableComponentId = "83e2c52d-3728-4ceb-a57b-b9234995b45e";
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _CDbAccessService = new CDbAccessService(serviceProvider, true);
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
        }
        [Test]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }
        // ClipType Tests
        [Test]
        public void GetAllClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
            grpcRequestParameter.BoolValue = true;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(4);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetNotActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
            grpcRequestParameter.BoolValue = false; // Only not active clip types
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        // CompositeComponent Tests
        [Test]
        public void GetAllComponentsTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            Task<ListCompositeComponentGrpc> getCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(2);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByComponentSheetNumberCompositeComponentTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByComponentSheetNumber;
            grpcRequestParameter.IntValue = 90001; // Use a known component sheet number
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            Task<ListCompositeComponentGrpc> getCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);

            // check the name and sheet number of the component
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-001");
            NUnit.Framework.Constraints.EqualConstraint sheetNumberConstraint = Is.EqualTo(90001);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.SheetNumber, sheetNumberConstraint);

            // Cablle specific things $"JCAB-001"
            NUnit.Framework.Constraints.EqualConstraint componentTypeConstraint = Is.EqualTo((int)ComponentType.Cable);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.ComponentType, componentTypeConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.G);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);        
        }
        [Test]
        public void GetByIdCompositeComponentTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ReadByIdCompositeCableComponentId; // Use a known component id, see SampleCDbAccessDataService
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // try to read back by id
            Task<ListCompositeComponentGrpc> readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);

            // check the name and sheet number of the component
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-001");
            NUnit.Framework.Constraints.EqualConstraint sheetNumberConstraint = Is.EqualTo(90001);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.SheetNumber, sheetNumberConstraint);
            
            // green cable specific things
            NUnit.Framework.Constraints.EqualConstraint componentTypeConstraint = Is.EqualTo((int)ComponentType.Cable);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.ComponentType, componentTypeConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.G);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);
        }
        // Private helper method to create a mock ServerCallContext
        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: methodName
                                            , host: "localhost"
                                            , deadline: deadline
                                            , requestHeaders: metadata
                                            , cancellationToken: CancellationToken.None
                                            , peer: "10.0.0.25:5001"
                                            , authContext: null
                                            , contextPropagationToken: null
                                            , writeHeadersFunc: (metadata) => Task.CompletedTask
                                            , writeOptionsGetter: () => new WriteOptions()
                                            , writeOptionsSetter: (writeOptions) => { }
                                            );
            return serverCallContext;
        }
    }
}

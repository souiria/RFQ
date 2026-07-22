using CDb;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Services;

namespace Unit.Tests.CDb
{
    class CrimpingProcessTypeGrpcUnitTests
    {
        CDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;

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
        [Category("Unit")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);
            string replyString = "Hello TestName";
            Assert.That(helloReply, Is.Not.Null);
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCrimpingProcessTypeGrpcTest_Success()
        {
            CrimpingProcessTypeGrpcRequest request = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = new GrpcRequestParameter();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));
            Task<ListCrimpingProcessTypeGrpc> crimpingProcessTypeGrpc = _GrpcService.ReadCrimpingProcessTypeGrpc(request, serverCallContext);
            EqualConstraint equalConstraint = Is.EqualTo(5);
        }

        [Test]
        [Category("Unit")]
        public void GetCrimpingProcessTypeByIdGrpcTest_Success()
        {
            // First, get all CrimpingProcessTypes to find a valid ID
            CrimpingProcessTypeGrpcRequest getAllRequest = new CrimpingProcessTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            getAllRequest.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext getAllContext = CreateServerContext(nameof(_GrpcService.ReadCrimpingProcessTypeGrpc));
            
            Task<ListCrimpingProcessTypeGrpc> allResponse = _GrpcService.ReadCrimpingProcessTypeGrpc(getAllRequest, getAllContext);
            
            // Ensure we have at least one CrimpingProcessType in the database
            GreaterThanConstraint gtConstraint = Is.GreaterThan(0);
            Assert.That(allResponse.Result.CrimpingProcessTypeGrpcs.Count, gtConstraint, 
                "No CrimpingProcessTypes found in database for testing");
            
            // Get the first CrimpingProcessType's ID for our filter test
            string validId = allResponse.Result.CrimpingProcessTypeGrpcs[0].Id;
            
            // Now test the filter with a valid ID
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "CRIMPINGPROCESSTYPEGRPC";
            filterRequest.FilterExpression = $"Id != null && Id == \"{validId}\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            
            Task<CdbFilterResponseGrpc> crimpingProcessTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);

            EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(crimpingProcessTypeGrpc, Is.Not.Null);
            Assert.That(crimpingProcessTypeGrpc.Result.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs.Count, equalConstraint);
            EqualConstraint equalToValidId = Is.EqualTo(validId);
            Assert.That(crimpingProcessTypeGrpc.Result.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs[0].Id, equalToValidId);
        }

        [Test]
        [Category("Unit")]
        public void GetCrimpingProcessTypeByInvalidIdGrpcTest_NoResults()
        {
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "CRIMPINGPROCESSTYPEGRPC";
            filterRequest.FilterExpression = "Id != null && Id == \"00000000-0000-0000-0000-000000000000\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            Task<CdbFilterResponseGrpc> crimpingProcessTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);
            EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(crimpingProcessTypeGrpc, Is.Not.Null);
            Assert.That(crimpingProcessTypeGrpc.Result.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs.Count, equalConstraint);
        }

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

using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Unit.Tests.NPR
{
    class NPRUnitTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _NPRAccessService = new NPRAccessService(serviceProvider, true);
            Mock<ILogger<NPRGrpcService>> logger = new Mock<ILogger<NPRGrpcService>>();
            _GrpcService = new NPRGrpcService(_NPRAccessService, logger.Object);
        }

        [TearDown]
        public void TearDown()
        {

            _NPRAccessService?.Dispose();
        
        }
        [Test]
        [Category("Unit")]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        #region H1NPRView

        [Test]
        [Category("Unit")]
        public void GetH1NPRViewGrpcTest_Success()
        {
            H1NPRViewRequest h1NPRViewRequest = new H1NPRViewRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllH1NPRViewGrpc));

            Task<ListH1NPRViewGrpc> geth1NPRViewGrpcReply = _GrpcService.GetAllH1NPRViewGrpc(h1NPRViewRequest, serverCallContext);
            Assert.That(geth1NPRViewGrpcReply.Result.H1NPRViewGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(geth1NPRViewGrpcReply.Result.H1NPRViewGrpc.Count, countConstraint);

        }
        #endregion

        #region RFQStatus
        [Category("Unit")]
        public void GetRFQStatusTest_Success()
        {
            RFQStatusRequest rfqStatusRequest = new RFQStatusRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllRFQStatusGrpc));

            Task<ListRFQStatusGrpc> getRFQStatusReply = _GrpcService.GetAllRFQStatusGrpc(rfqStatusRequest, serverCallContext);
            Assert.That(getRFQStatusReply.Result.RFQStatusGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRFQStatusReply.Result.RFQStatusGrpc.Count, countConstraint);

        }
        #endregion

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

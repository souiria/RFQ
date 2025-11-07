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

        [Test]
        [Category("Unit")]
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

        #region H1NPRView

        [Test]
        [Category("Unit")]
        public void GetCurrencyGrpcTest_Success()
        {
            H1NPRViewRequest h1NPRViewRequest = new H1NPRViewRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllH1NPRViewGrpc));

            Task<ListH1NPRViewGrpc> getCurrencyGrpcReply = _GrpcService.GetAllH1NPRViewGrpc(h1NPRViewRequest, serverCallContext);
            Assert.That(getCurrencyGrpcReply.Result.H1NPRViewGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCurrencyGrpcReply.Result.H1NPRViewGrpc.Count, countConstraint);

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

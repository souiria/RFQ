using Purchasing;
using Purchasing.Endpoints;
using Purchasing.Enums;
using Purchasing.Services;

namespace Unit.Tests.Purchasing
{
    class PurchasingUnitTests
    {
        PurchasingAccessService _PurchasingAccessService;
        PurchasingGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _PurchasingAccessService = new PurchasingAccessService(serviceProvider, true);
            Mock<ILogger<PurchasingGrpcService>> logger = new Mock<ILogger<PurchasingGrpcService>>();
            _GrpcService = new PurchasingGrpcService(_PurchasingAccessService, logger.Object);
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

        #region H1CPD

        [Test]
        [Category("Unit")]
        public void ReadH1CPDGrpccTest_Success()
        {
            H1CPDGrpcRequest h1CPDGrpcRequest = new H1CPDGrpcRequest();
            PurchasingGrpcRequestParameter purchasingGrpcRequestParameter = new PurchasingGrpcRequestParameter();
            h1CPDGrpcRequest.PurchasingGrpcRequestParameter = purchasingGrpcRequestParameter;
            h1CPDGrpcRequest.PurchasingGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadH1CPDGrpc));

            Task<ListH1CPDGrpc> getH1CPDGrpcReply = _GrpcService.ReadH1CPDGrpc(h1CPDGrpcRequest, serverCallContext);
            Assert.That(getH1CPDGrpcReply.Result.H1CPD, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getH1CPDGrpcReply.Result.H1CPD.Count, countConstraint);

        }

        [Test]
        public void FilterH1CPDGrpcByRowIdTest_Success()
        {
            PurchasingFilterRequest filterRequest = new PurchasingFilterRequest();
            filterRequest.DatabaseList = "H1CPDGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "SumitomoNumber != null && SumitomoNumber == \"TestSumitomoNumber\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterPurchasingGrpc));

            Task<PurchasingFilterResponse> reply = _GrpcService.FilterPurchasingGrpc(filterRequest, serverCallContext);

            Assert.That(reply.Result.ListH1CPDGrpc.H1CPD, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(reply.Result.ListH1CPDGrpc.H1CPD.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TestUniformSumitomoNumber");
            Assert.That(reply.Result.ListH1CPDGrpc.H1CPD.First().UniformSumitomoNumber, nameConstraint);
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

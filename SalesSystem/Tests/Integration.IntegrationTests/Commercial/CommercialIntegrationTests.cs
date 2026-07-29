using Commercial;
using Commercial.Endpoints.GrpcServices;
using Commercial.Services;

namespace Integration.Tests.Commercial
{
    class CommercialIntegrationTests
    {
        CommercialAccessService _CommercialAccessService;
        CommercialGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            Mock<ILogger<CommercialAccessService>> logger = new Mock<ILogger<CommercialAccessService>>();
            _CommercialAccessService = new CommercialAccessService(serviceProvider, logger.Object, true);
            Mock<ILogger<CommercialGrpcService>> logger2 = new Mock<ILogger<CommercialGrpcService>>();
            _GrpcService = new CommercialGrpcService(_CommercialAccessService, logger2.Object);
        }

        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Integration")]
        public void Filter_PurchaseOrder_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.CommercialFilterDataGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            CommercialFilterDataGrpcRequest successReq = new CommercialFilterDataGrpcRequest();
            successReq.DatabaseList = "PURCHASEORDERDATAGRPC";
            successReq.FilterExpression = "true";

            Task<CommercialFilterDataGrpcResponse> successTask = _GrpcService.CommercialFilterDataGrpc(successReq, ctx);
            CommercialFilterDataGrpcResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListPurchaseOrderDataGrpc successListContainer = successResp.FilteredPurchaseOrderData;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<PurchaseOrderDataGrpc> successItems = successListContainer.PurchaseOrderData;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            CommercialFilterDataGrpcRequest failReq = new CommercialFilterDataGrpcRequest();
            failReq.DatabaseList = "PURCHASEORDERDATAGRPC";
            failReq.FilterExpression = "false";

            Task<CommercialFilterDataGrpcResponse> failTask = _GrpcService.CommercialFilterDataGrpc(failReq, ctx);
            CommercialFilterDataGrpcResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListPurchaseOrderDataGrpc failListContainer = failResp.FilteredPurchaseOrderData;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<PurchaseOrderDataGrpc> failItems = failListContainer.PurchaseOrderData;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
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

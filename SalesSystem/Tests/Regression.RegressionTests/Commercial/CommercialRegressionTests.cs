using Commercial;
using Commercial.Endpoints.GrpcServices;
using Commercial.Services;

namespace Regression.Tests.Commercial
{
    class CommercialRegressionTests
    {
        CommercialAccessService _CommercialAccessService;
        CommercialGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();
            Mock<ILogger<CommercialAccessService>> logger = new Mock<ILogger<CommercialAccessService>>();

            _CommercialAccessService = new CommercialAccessService(provider, logger.Object, true);
            Mock<ILogger<CommercialGrpcService>> logger2 = new Mock<ILogger<CommercialGrpcService>>();
            _GrpcService = new CommercialGrpcService(_CommercialAccessService, logger2.Object);
        }

        [Test]
        public async Task RegressionTest_PurchaseOrder_AllEndpoints_FilterOnly_ShouldReturnExpectedResults()
        {
            CommonTypes.HelloRequest helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";
            ServerCallContext helloContext = CreateServerContext(nameof(_GrpcService.SayHello));

            CommonTypes.HelloReply helloResult = await _GrpcService.SayHello(helloRequest, helloContext);
            Assert.That(helloResult.Message == "Hello TestName", Is.True);

            // =========================================================
            // PurchaseOrder
            // =========================================================

            CommercialFilterDataGrpcRequest purchaseOrderFilter = new CommercialFilterDataGrpcRequest();
            purchaseOrderFilter.DatabaseList = "PURCHASEORDERDATAGRPC";
            purchaseOrderFilter.FilterExpression = "Id != null && Id == \"0\"";

            ServerCallContext purchaseOrderContext = CreateServerContext(nameof(_GrpcService.CommercialFilterDataGrpc));
            CommercialFilterDataGrpcResponse commercialResponse = await _GrpcService.CommercialFilterDataGrpc(purchaseOrderFilter, purchaseOrderContext);

            Assert.That(commercialResponse.FilteredPurchaseOrderData.PurchaseOrderData.Count == 1, Is.True);
            Assert.That(commercialResponse.FilteredPurchaseOrderData.PurchaseOrderData.First().MaterialNumber == "TestMaterialNumber", Is.True);

            // Fail case
            CommercialFilterDataGrpcRequest currencyFail = new CommercialFilterDataGrpcRequest();
            currencyFail.DatabaseList = "PURCHASEORDERDATAGRPC";
            currencyFail.FilterExpression = $"Id != null && Id == \"6\"";

            CommercialFilterDataGrpcResponse purchaseOrderFailResponse = await _GrpcService.CommercialFilterDataGrpc(currencyFail, purchaseOrderContext);
            Assert.That(purchaseOrderFailResponse.FilteredPurchaseOrderData.PurchaseOrderData.Count == 0, Is.True);
        }

        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline;
            deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata;
            metadata = new Metadata();
            ServerCallContext serverCallContext;
            serverCallContext = TestServerCallContext.Create(
                                    method: methodName,
                                    host: "localhost",
                                    deadline: deadline,
                                    requestHeaders: metadata,
                                    cancellationToken: CancellationToken.None,
                                    peer: "10.0.0.25:5001",
                                    authContext: null,
                                    contextPropagationToken: null,
                                    writeHeadersFunc: (headers) => Task.CompletedTask,
                                    writeOptionsGetter: () => new WriteOptions(),
                                    writeOptionsSetter: (writeOptions) => { }
                                );
            return serverCallContext;
        }
    }
}

using Purchasing;
using Purchasing.Endpoints;          
using Purchasing.Services;           

namespace Regression.Tests.Purchasing
{
    public class PurchasingRegressionTests
    {
        PurchasingAccessService _PurchasingAccessService;
        PurchasingGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services;
            services = new ServiceCollection();

            ServiceProvider provider;
            provider = services.BuildServiceProvider();

            _PurchasingAccessService = new PurchasingAccessService(provider, true);

            Mock<ILogger<PurchasingGrpcService>> logger;
            logger = new Mock<ILogger<PurchasingGrpcService>>();

            _GrpcService = new PurchasingGrpcService(_PurchasingAccessService, logger.Object);
        }

        [Test]
        public async Task RegressionTest_Purchasing_AllEndpoints_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello
            // ---------------------------------------------------------

            CommonTypes.HelloRequest helloRequest;
            helloRequest = new CommonTypes.HelloRequest();

            helloRequest.Name = "TestName";

            ServerCallContext helloContext;
            helloContext = CreateServerContext(nameof(_GrpcService.SayHello));

            CommonTypes.HelloReply helloReply;
            helloReply = await _GrpcService.SayHello(helloRequest, helloContext);

            // Expected value
            string expectedHello;
            expectedHello = "Hello TestName";

            // Actual value
            string actualHello;
            actualHello = helloReply.Message;

            // Constraint
            EqualConstraint helloConstraint;
            helloConstraint = Is.EqualTo(expectedHello);

            // Assertion
            Assert.That(actualHello, helloConstraint);

            // =========================================================
            // Purchasing: FilterPurchasingGrpc — H1CPD list
            // =========================================================

            // ----------------------- SUCCESS CASE -----------------------
            PurchasingFilterRequest h1SuccessReq;
            h1SuccessReq = new PurchasingFilterRequest();

            h1SuccessReq.DatabaseList = "H1CPDGrpc";
            h1SuccessReq.FilterExpression = "true";

            ServerCallContext h1Context;
            h1Context = CreateServerContext(nameof(_GrpcService.FilterPurchasingGrpc));

            Task<PurchasingFilterResponse> h1SuccessTask;
            h1SuccessTask = _GrpcService.FilterPurchasingGrpc(h1SuccessReq, h1Context);

            PurchasingFilterResponse h1SuccessResp;
            h1SuccessResp = await h1SuccessTask;

            ListH1CPDGrpc h1SuccessContainer;
            h1SuccessContainer = h1SuccessResp.ListH1CPDGrpc;

            Assert.That(h1SuccessContainer, Is.Not.Null);

            RepeatedField<H1CPDGrpc> h1SuccessList;
            h1SuccessList = h1SuccessContainer.H1CPD;

            Assert.That(h1SuccessList, Is.Not.Null);

           int h1SuccessActualCount;
            h1SuccessActualCount = h1SuccessList.Count;

            bool h1SuccessHasRows;
            h1SuccessHasRows = 1<= h1SuccessActualCount ;

            Assert.That(h1SuccessHasRows, Is.True);

            // ----------------------- FAILURE CASE -----------------------
            PurchasingFilterRequest h1FailReq;
            h1FailReq = new PurchasingFilterRequest();

            h1FailReq.DatabaseList = "H1CPDGrpc";
            h1FailReq.FilterExpression = "false";

            Task<PurchasingFilterResponse> h1FailTask;
            h1FailTask = _GrpcService.FilterPurchasingGrpc(h1FailReq, h1Context);

            PurchasingFilterResponse h1FailResp;
            h1FailResp = await h1FailTask;

            ListH1CPDGrpc h1FailContainer;
            h1FailContainer = h1FailResp.ListH1CPDGrpc;

            Assert.That(h1FailContainer, Is.Not.Null);

            RepeatedField<H1CPDGrpc> h1FailList;
            h1FailList = h1FailContainer.H1CPD;

            Assert.That(h1FailList, Is.Not.Null);

            int h1FailActualCount;
            h1FailActualCount = h1FailList.Count;

            bool h1FailIsZero;
            h1FailIsZero = h1FailActualCount == 0;

            Assert.That(h1FailIsZero, Is.True);
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
                                    writeHeadersFunc: (md) => Task.CompletedTask,
                                    writeOptionsGetter: () => new WriteOptions(),
                                    writeOptionsSetter: (writeOptions) => { }
                                );

            return serverCallContext;
        }
    }
}
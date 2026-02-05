using Purchasing;
using Purchasing.Endpoints;
using Purchasing.Services;

namespace Integration.Tests.Purchasing
{
    public class PurchasingIntegrationTests
    {
        PurchasingAccessService _PurchasingAccessService;
        PurchasingGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            // IMPORTANT: testing=true -> load in-memory sample data for lists (H1CPD, etc.)
            _PurchasingAccessService = new PurchasingAccessService(provider, testing: true);

            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<PurchasingGrpcService> logger = _LoggerFactory.CreateLogger<PurchasingGrpcService>();

            _GrpcService = new PurchasingGrpcService(_PurchasingAccessService, logger);
        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
        }

        // ---------------------------------------------------------------------
        // SayHello
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            // Arrange
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.SayHello));

            // Act
            Task<HelloReply> helloReply = _GrpcService.SayHello(request, context);

            // Assert
            Assert.That(helloReply, Is.Not.Null);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // Purchasing: H1CPD
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_H1CPD_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterPurchasingGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            PurchasingFilterRequest successReq = new PurchasingFilterRequest();
            successReq.DatabaseList = "H1CPDGrpc";
            successReq.FilterExpression = "true";

            Task<PurchasingFilterResponse> successTask = _GrpcService.FilterPurchasingGrpc(successReq, ctx);
            PurchasingFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListH1CPDGrpc successListContainer = successResp.ListH1CPDGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<H1CPDGrpc> successItems = successListContainer.H1CPD;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            PurchasingFilterRequest failReq = new PurchasingFilterRequest();
            failReq.DatabaseList = "H1CPDGrpc"; 
            failReq.FilterExpression = "false";

            Task<PurchasingFilterResponse> failTask = _GrpcService.FilterPurchasingGrpc(failReq, ctx);
            PurchasingFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListH1CPDGrpc failListContainer = failResp.ListH1CPDGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<H1CPDGrpc> failItems = failListContainer.H1CPD;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

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
                writeHeadersFunc: (md) => Task.CompletedTask,
                writeOptionsGetter: () => new WriteOptions(),
                writeOptionsSetter: (writeOptions) => { }
            );
            return serverCallContext;
        }
    }
}
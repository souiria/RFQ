using Microsoft.Extensions.DependencyInjection;
using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Integration.Tests.NPR
{
    public class NPRIntegrationTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            IConfiguration configuration = new ConfigurationBuilder().Build();

            _NPRAccessService = new NPRAccessService(serviceProvider, httpClientFactory, configuration, testing: true);
            
            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<NPRGrpcService> logger = _LoggerFactory.CreateLogger<NPRGrpcService>();

            _GrpcService = new NPRGrpcService(_NPRAccessService, logger);
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
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // NPR: H1NPRView 
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_H1NPRView_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterNPRGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            NPRFilterRequest successReq = new NPRFilterRequest();
            successReq.DatabaseList = "H1NPRVIEWGRPC";
            successReq.FilterExpression = "true";

            Task<NPRFilterResponse> successTask = _GrpcService.FilterNPRGrpc(successReq, ctx);
            NPRFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListH1NPRViewGrpc successListContainer = successResp.ListH1NPRViewGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> successItems = successListContainer.H1NPRViewGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            NPRFilterRequest failReq = new NPRFilterRequest();
            failReq.DatabaseList = "H1NPRVIEWGRPC";
            failReq.FilterExpression = "false";

            Task<NPRFilterResponse> failTask = _GrpcService.FilterNPRGrpc(failReq, ctx);
            NPRFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListH1NPRViewGrpc failListContainer = failResp.ListH1NPRViewGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> failItems = failListContainer.H1NPRViewGrpc;
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
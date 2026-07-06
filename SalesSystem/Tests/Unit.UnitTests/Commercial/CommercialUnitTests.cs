using Commercial;
using Commercial.Endpoints.GrpcServices;
using Commercial.Services;

namespace Unit.Tests.Commercial
{
    class CommercialUnitTests
    {
        CommercialAccessService _CommercialAccessService;
        CommercialGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _LoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger<CommercialAccessService> logger = _LoggerFactory.CreateLogger<CommercialAccessService>();
            ILogger<CommercialGrpcService> logger2 = _LoggerFactory.CreateLogger<CommercialGrpcService>();

            _CommercialAccessService = new CommercialAccessService(serviceProvider, logger, testing: true);
            _GrpcService = new CommercialGrpcService(_CommercialAccessService, logger2);
        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
        }

        [Test]
        [Category("Unit")]
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

        [Test]
        [Category("Unit")]
        public async Task GetPurchaseOrderGrpcTest()
        {
            // Arrange
            GetAllPurchaseOrderDataGrpcRequest request = new GetAllPurchaseOrderDataGrpcRequest();
            request.Position = 0;
            request.TakeAmount = 10;
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.GetAllPurchaseOrderDataGrpc));
            // Act
            ListPurchaseOrderDataGrpc result = await _GrpcService.GetAllPurchaseOrderDataGrpc(request, context);
            // Assert
            Assert.That(result, Is.Not.Null);
            GreaterThanConstraint equalConstraint = Is.GreaterThan(0);
            Assert.That(result.PurchaseOrderData.Count, equalConstraint);
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

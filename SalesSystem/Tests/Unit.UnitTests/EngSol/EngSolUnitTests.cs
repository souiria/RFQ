using EngSol;
using EngSol.Endpoints.GrpcServices;
using EngSol.Services;

namespace Unit.Tests.EngSol
{
    class EngSolUnitTests
    {
        EngSolAccessService _EngSolAccessService;
        EngSolGrpcService _GrpcService;
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
            ILogger<EngSolAccessService> logger = _LoggerFactory.CreateLogger<EngSolAccessService>();
            ILogger<EngSolGrpcService> logger2 = _LoggerFactory.CreateLogger<EngSolGrpcService>();

            _EngSolAccessService = new EngSolAccessService(serviceProvider, logger, testing: true);
            _GrpcService = new EngSolGrpcService(_EngSolAccessService, logger2);
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
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.SayHello));

            // Act
            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, context);

            // Assert
            Assert.That(helloReply, Is.Not.Null);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public async Task GetDerivativesGrpcTest()
        {
            // Arrange
            GetDerivativesGrpcRequest request = new GetDerivativesGrpcRequest();
            request.Position = 0;
            request.TakeAmount = 10;
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.GetDerivativesGrpc));
            // Act
            ListDerivatives result = await _GrpcService.GetDerivativesGrpc(request, context);
            // Assert
            Assert.That(result, Is.Not.Null);
            GreaterThanConstraint equalConstraint = Is.GreaterThan(0);
            Assert.That(result.DerivativeGrpc.Count, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public async Task GetDerivativeByDerivativeIdTest()
        {
            // Arrange
            GetDerivativeByIdGrpcRequest request = new GetDerivativeByIdGrpcRequest();
            request.DerivativeId = 1;
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.GetDerivativeByDerivativeId));
            // Act
            DerivativeGrpc result = await _GrpcService.GetDerivativeByDerivativeId(request, context);
            // Assert
            Assert.That(result, Is.Not.Null);
            EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(result.DerivativeID, equalConstraint);
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

using Rfq;                              
using Rfq.Endpoints.GrpcServices;        
using Rfq.Services;                 

namespace Integration.Tests.Rfq
{
    public class RfqIntegrationTests
    {
        RfqAccessService _RfqAccessService;
        RfqGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            // IMPORTANT: testing=true -> seeds in-memory lists via SampleRfqDataService
            _RfqAccessService = new RfqAccessService(provider, testing: true);

            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<RfqGrpcService> logger = _LoggerFactory.CreateLogger<RfqGrpcService>();

            _GrpcService = new RfqGrpcService(_RfqAccessService, logger);
        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
        }

        // ---------------------------------------------------------------------
        // Say Hello 
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

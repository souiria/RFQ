using System.Linq.Expressions;
using Google.Protobuf.WellKnownTypes;
using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;
namespace Regression.Tests.SFS
{
    public class SFSGrpcServiceRegressionTests
    {
         Mock<ISFSAccessService> _MockSfsAccessService;
         SFSGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            _MockSfsAccessService = new Mock<ISFSAccessService>();
            ILogger<SFSGrpcService> logger = new Mock<ILogger<SFSGrpcService>>().Object;
            _GrpcService = new SFSGrpcService(_MockSfsAccessService.Object, logger);
        }
        [Test]
        public async Task RegressionTest_AllEndpoints_ShouldReturnExpectedResults()
        {
            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            // --- SayHello ---
            HelloRequest helloRequest;
            helloRequest = new HelloRequest();
            helloRequest.Name = "TestName";

            Task<HelloReply> helloTask;
            helloTask = _GrpcService.SayHello(helloRequest, null!);

            HelloReply helloResult;
            helloResult = await helloTask;

            string actualHello;
            actualHello = helloResult.Message;

            string expectedHello;
            expectedHello = "Hello TestName";

            bool helloEqual;
            helloEqual = actualHello == expectedHello;
            Assert.That(helloEqual, Is.True);
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


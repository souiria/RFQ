using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;
using NUnit.Framework.Constraints;

namespace Regression.Tests.NPR
{
    public class NPRRegressionTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            _NPRAccessService = new NPRAccessService(provider, true);
            Mock<ILogger<NPRGrpcService>> logger = new Mock<ILogger<NPRGrpcService>>();
            _GrpcService = new NPRGrpcService(_NPRAccessService, logger.Object);
        }

        [Test]
        public async Task RegressionTest_NPR_AllEndpoints_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello
            // ---------------------------------------------------------

            HelloRequest helloRequest = new HelloRequest();
            helloRequest.Name = "TestName";

            ServerCallContext helloContext = CreateServerContext(nameof(_GrpcService.SayHello));

            HelloReply helloReply = await _GrpcService.SayHello(helloRequest, helloContext);

            // Expected value
            string expectedHello = "Hello TestName";

            // Actual value
            string actualHello = helloReply.Message;

            // Constraint
            EqualConstraint helloConstraint = Is.EqualTo(expectedHello);

            // Assertion
            Assert.That(actualHello, helloConstraint);

            // =========================================================
            // H1NPRView
            // =========================================================

            H1NPRViewRequest h1Request;
            h1Request = new H1NPRViewRequest();

            ServerCallContext h1Context;
            h1Context = CreateServerContext(nameof(_GrpcService.GetAllH1NPRViewGrpc));

            Task<ListH1NPRViewGrpc> h1Task;
            h1Task = _GrpcService.GetAllH1NPRViewGrpc(h1Request, h1Context);

            ListH1NPRViewGrpc h1Response;
            h1Response = await h1Task;

            Google.Protobuf.Collections.RepeatedField<H1NPRViewGrpc> h1List;
            h1List = h1Response.H1NPRViewGrpc;

            Assert.That(h1List, Is.Not.Null);

            // Count check
            int h1ActualCount;
            h1ActualCount = h1List.Count;

            int h1ExpectedCount;
            h1ExpectedCount = 6;

            bool h1CountMatches;
            h1CountMatches = h1ActualCount == h1ExpectedCount;

            Assert.That(h1CountMatches, Is.True);

            // First record
            H1NPRViewGrpc? h1First;
            h1First = h1List.FirstOrDefault();

            Assert.That(h1First, Is.Not.Null);

            // Validate a guaranteed non-null field
            string h1CustomerNo;
            h1CustomerNo = h1First!.CustomerNo;

            bool h1CustomerNoNotEmpty;
            h1CustomerNoNotEmpty = !string.IsNullOrWhiteSpace(h1CustomerNo);

            Assert.That(h1CustomerNoNotEmpty, Is.True);

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
                                                    writeHeadersFunc: (metadata) => Task.CompletedTask,
                                                    writeOptionsGetter: () => new WriteOptions(),
                                                    writeOptionsSetter: (writeOptions) => { }
                                                  );
            return serverCallContext;
        }
    }
}
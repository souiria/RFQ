using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Testing;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;
using SharedKernel;

namespace Regression.Tests
{
    public class SayHelloTests
    {
        Mock<ISFSAccessService> _MockSfsAccessService;
        SFSGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            _MockSfsAccessService = new Mock<ISFSAccessService>();
            ILogger<SFSGrpcService> logger = new Mock<ILogger<SFSGrpcService>>().Object;
            // Pass the mock object to the GrpcService
            _GrpcService = new SFSGrpcService(_MockSfsAccessService.Object, logger);
        }

        [Test]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
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
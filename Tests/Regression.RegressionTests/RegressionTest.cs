using System.Linq.Expressions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SFS;

namespace Regression.Tests
{
    public class SayHelloRegressionTests
    {
        SFSService.SFSServiceClient _Client;

        [SetUp]
        public void Setup()
        {
            GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:57822");
            _Client = new SFSService.SFSServiceClient(channel);
        }

        [Test]
        public async Task SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "RegressionTest";

            HelloReply helloReply = await _Client.SayHelloAsync(request);

            string actualMessage = helloReply.Message;
            string expectedMessage = "Hello RegressionTest";
            NUnit.Framework.Constraints.EqualConstraint constraint = Is.EqualTo(expectedMessage);

            Assert.That(actualMessage, constraint);
        }
    }
}

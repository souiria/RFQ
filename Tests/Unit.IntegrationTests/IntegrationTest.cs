using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NUnit.Framework;
using SFS;

namespace Integration.Tests
{
    public class SayHelloIntegrationTests
    {
        SFSService.SFSServiceClient _Client;

        [SetUp]
        public void Setup()
        {
            GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:57821");
            _Client = new SFSService.SFSServiceClient(channel);
        }

        [Test]
        public async Task SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "IntegrationTest";

            HelloReply helloReply = await _Client.SayHelloAsync(request);

            string replyString = "Hello IntegrationTest";
            Assert.That(helloReply, Is.Not.Null);
            string actualMessage = helloReply.Message;
            string expectedMessage = replyString;
            NUnit.Framework.Constraints.EqualConstraint constraint = Is.EqualTo(expectedMessage);

            Assert.That(actualMessage, constraint);

        }
    }
}

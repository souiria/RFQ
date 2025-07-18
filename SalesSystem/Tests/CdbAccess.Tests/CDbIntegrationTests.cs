using CDb;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Services;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace CdbAccess.Tests
{
    public class CDbIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _CDbAccessService = new CDbAccessService(serviceProvider, true);
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
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

        [Test]
        public void GetAllClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            RequestParameter requestParameter = new RequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadAll;
            request.RequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getCurrencyGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            RequestParameter requestParameter = new RequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByIsActive;
            requestParameter.BoolValue = true;
            request.RequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getCurrencyGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(4);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetNotActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            RequestParameter requestParameter = new RequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByIsActive;
            requestParameter.BoolValue = false; // Only not active clip types
            request.RequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getCurrencyGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCurrencyGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void CreateClipTypeTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            RequestParameter requestParameter = new RequestParameter();
            requestParameter.RequestType = (int)RequestType.Create;
            ClipTypeGrpc clip = new ClipTypeGrpc();
            clip.Code = "TESTCLIP";
            clip.Description = "Test Clip";
            clip.IsActive = true;
            request.ClipTypeGrpcsToAdd.Add(clip);
            request.RequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateClipTypeGrpc));

            Task<CDbCrudGrpcResponse> getCurrencyGrpcReply = _GrpcService.CreateClipTypeGrpc(request, serverCallContext);
            Assert.That(getCurrencyGrpcReply, Is.Not.Null);
            Assert.That(getCurrencyGrpcReply.Result.SaveSuccess, Is.True);

        }
        // Private helper method to create a mock ServerCallContext
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

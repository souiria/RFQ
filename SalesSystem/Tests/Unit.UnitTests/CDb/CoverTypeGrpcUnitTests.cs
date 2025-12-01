using CDb;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Services;

namespace Unit.Tests.CDb
{
    class CoverTypeGrpcUnitTests
    {
        CDbAccessService _CDbAccessService;
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
        [Category("Unit")]
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
        [Category("Unit")]
        public void GetCoverTypeGrpcTest_Success()
        {
            CoverTypeGrpcRequest request = new CoverTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = new GrpcRequestParameter();
            
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCoverTypeGrpc));
            Task<ListCoverTypeGrpc> coverTypeGrpc = _GrpcService.ReadCoverTypeGrpc(request, serverCallContext);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(5);
        }

        [Test]
        [Category("Unit")]
        public void GetCoverTypeByIdGrpcTest_Success()
        {
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "COVERTYPEGRPC";
            filterRequest.FilterExpression = "Id != null && Id == \"3a15c6ae-3b7f-4f55-b566-01cd29630901\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            Task<CdbFilterResponseGrpc> coverTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);

            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.Count, equalConstraint);
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("Unknown");
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.First().Code, codeConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCoverTypeByIdGrpcTest_NoResults()
        {
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "COVERTYPEGRPC";
            filterRequest.FilterExpression = "Id != null && Id == \"non-existing-id\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            Task<CdbFilterResponseGrpc> coverTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);

            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.Count, equalConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCoverTypeByCodeGrpcTest_Success()
        {
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "COVERTYPEGRPC";
            filterRequest.FilterExpression = "Code != null && Code == \"Type1\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            Task<CdbFilterResponseGrpc> coverTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);

            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.Count, equalConstraint);
            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("37c995eb-8556-4ff9-b2b9-a2bcd7de234b");
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.First().Id, codeConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCoverTypeByCodeGrpcTest_NoResults()
        {
            CdbFilterRequestGrpc filterRequest = new CdbFilterRequestGrpc();
            filterRequest.DatabaseList = "COVERTYPEGRPC";
            filterRequest.FilterExpression = "Code != null && Code == \"NonExistingCode\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            Task<CdbFilterResponseGrpc> coverTypeGrpc = _GrpcService.FilterCdbDataGrpc(filterRequest, serverCallContext);

            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(coverTypeGrpc.Result.ListCoverTypes.CoverTypeGrpcs.Count, equalConstraint);
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

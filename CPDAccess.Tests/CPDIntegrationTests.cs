using CPD;
using CPD.Endpoints.GrpcServices;
using CPD.Services;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace CPDAccess.Tests
{
    public class CPDIntegrationTests
    {
        CPDAccessService _CPDAccessService;
        CPDGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _CPDAccessService = new CPDAccessService(serviceProvider, true);
            Mock<ILogger<CPDGrpcService>> logger = new Mock<ILogger<CPDGrpcService>>();
            _GrpcService = new CPDGrpcService(_CPDAccessService, logger.Object);
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

        #region MattSuppMst
        [Test]
        public void GetMattSuppMstViewTest_Success()
        {
            MatSuppMstViewGrpcRequest request = new MatSuppMstViewGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllMatSuppMstView));

            Task<ListMatSuppMstGrpc> getMattSuppMstViewGrpcReply = _GrpcService.GetAllMatSuppMstView(request, serverCallContext);

            Assert.That(getMattSuppMstViewGrpcReply.Result.MatSuppMstViewGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMattSuppMstViewGrpcReply.Result.MatSuppMstViewGrpc.Count, countConstraint);
        }
        #endregion
        #region HarnessCostingCalculationData
        [Test]
        public void GetHarnessCostingCalculationDataViewTest_Success()
        {
            HarnessCostingCalculationDataViewGrpcRequest request = new HarnessCostingCalculationDataViewGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllHarnessCostingCalculationDataView));

            Task<ListHarnessCostingCalculationDataGrpc> getHarnessCostingCalculationDataViewGrpcReply = _GrpcService.GetAllHarnessCostingCalculationDataView(request, serverCallContext);

            Assert.That(getHarnessCostingCalculationDataViewGrpcReply.Result.HarnessCostingCalculationDataGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getHarnessCostingCalculationDataViewGrpcReply.Result.HarnessCostingCalculationDataGrpc.Count, countConstraint);
        }
        #endregion

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


using CPD;
using CPD.Endpoints.GrpcServices;
using CPD.Services;

namespace Regression.Tests.CPD
{
    public class CPDGrpcServiceRegressionTests
    {
        Mock<ICPDAccessService> _MockCpdAccessService;
        CPDGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            _MockCpdAccessService = new Mock<ICPDAccessService>();
            ILogger<CPDGrpcService> logger = new Mock<ILogger<CPDGrpcService>>().Object;
            _GrpcService = new CPDGrpcService(_MockCpdAccessService.Object, logger);
        }

        [Test]
        public async Task RegressionTest_AllEndpoints_ShouldReturnExpectedResults()
        {
            CancellationToken anyToken = It.IsAny<CancellationToken>();

            // --- SayHello ---
            CommonTypes.HelloRequest helloRequest;
            helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";
            Task<CommonTypes.HelloReply> helloTask;
            helloTask = _GrpcService.SayHello(helloRequest, null!);
            CommonTypes.HelloReply helloResult;
            helloResult = await helloTask;
            string actualHello;
            actualHello = helloResult.Message;
            string expectedHello;
            expectedHello = "Hello TestName";
            bool helloEqual;
            helloEqual = actualHello == expectedHello;
            Assert.That(helloEqual, Is.True);

            // --- GetAllMatSuppMstView ---
            MatSuppMstViewGrpc matSuppItem;
            matSuppItem = new MatSuppMstViewGrpc();
            matSuppItem.InitialVolQty = 1;
            matSuppItem.SuppMatNm = "ABC";

            ListMatSuppMstGrpc matSuppList;
            matSuppList = new ListMatSuppMstGrpc();
            matSuppList.MatSuppMstViewGrpc.Add(matSuppItem);

            _MockCpdAccessService.Setup(s => s.GetAllMatSuppMstView(anyToken,0,0)).ReturnsAsync(matSuppList);

            MatSuppMstViewGrpcRequest matSuppRequest;
            matSuppRequest = new MatSuppMstViewGrpcRequest();

            ServerCallContext matSuppContext;
            matSuppContext = CreateServerContext(nameof(_GrpcService.GetAllMatSuppMstView));

            Task<ListMatSuppMstGrpc> matSuppTask;
            matSuppTask = _GrpcService.GetAllMatSuppMstView(matSuppRequest, matSuppContext);

            ListMatSuppMstGrpc matSuppResult;
            matSuppResult = await matSuppTask;

            int actualMatSuppCount;
            actualMatSuppCount = matSuppResult.MatSuppMstViewGrpc.Count;

            int expectedMatSuppCount;
            expectedMatSuppCount = 1;

            bool matSuppCountEqual;
            matSuppCountEqual = actualMatSuppCount == expectedMatSuppCount;
            Assert.That(matSuppCountEqual, Is.True);

            string actualSupplierName;
            actualSupplierName = matSuppResult.MatSuppMstViewGrpc[0].SuppMatNm;

            string expectedSupplierName;
            expectedSupplierName = "ABC";

            bool supplierNameEqual;
            supplierNameEqual = actualSupplierName == expectedSupplierName;
            Assert.That(supplierNameEqual, Is.True);

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


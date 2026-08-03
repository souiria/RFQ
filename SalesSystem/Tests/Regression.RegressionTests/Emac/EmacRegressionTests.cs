using Emacs;
using Emacs.Endpoints.GrpcServices;
using Emacs.Services;

namespace Regression.Tests.Emac
{
    public class EmacRegressionTests
    {
        EMACSAccessService _EMACSAccessService;
        EMACSGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            Mock<ILogger<EMACSAccessService>> logger = new Mock<ILogger<EMACSAccessService>>();
            _EMACSAccessService = new EMACSAccessService(provider, logger.Object, true);
            Mock<ILogger<EMACSGrpcService>> logger2 = new Mock<ILogger<EMACSGrpcService>>();
            _GrpcService = new EMACSGrpcService(_EMACSAccessService, logger2.Object);
        }

        [Test]
        public async Task RegressionTest_AllEndpoints_FilterOnly_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello (health check)
            // ---------------------------------------------------------
            CommonTypes.HelloRequest helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";
            ServerCallContext helloContext = CreateServerContext(nameof(_GrpcService.SayHello));
            CommonTypes.HelloReply helloResult = await _GrpcService.SayHello(helloRequest, helloContext);
            Assert.That(helloResult.Message == "Hello TestName", Is.True);

            // ---------------------------------------------------------
            //   COMBINED PARTS
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc combinedFilterRequest;
            combinedFilterRequest = new EmacsFilterRequestGrpc();
            combinedFilterRequest.DatabaseList = "CombinedPartsGrpc";

            // Filter on a guaranteed non-null field
            combinedFilterRequest.FilterExpression = "SumitomoNumber != null";

            Assert.That(!string.IsNullOrWhiteSpace(combinedFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {combinedFilterRequest.DatabaseList}");

            ServerCallContext combinedFilterContext;
            combinedFilterContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> combinedFilterTask;
            combinedFilterTask = _GrpcService.FilterEmacsDataGrpc(combinedFilterRequest, combinedFilterContext);

            EmacsFilterResponseGrpc combinedFilterResponse;
            combinedFilterResponse = await combinedFilterTask;

            ListCombinedPartsGrpc combinedFilteredList;
            combinedFilteredList = combinedFilterResponse.ListCombinedPartsGrpc;

            int combinedActualFilteredCount;
            combinedActualFilteredCount = combinedFilteredList.CombinedPartsGrpc.Count;

            Assert.That(0 < combinedActualFilteredCount, Is.True);

            CombinedPartsGrpc? combinedFirst;
            combinedFirst = combinedFilteredList.CombinedPartsGrpc.FirstOrDefault();

            Assert.That(combinedFirst, Is.Not.Null);

            string combinedSumitomoNumber;
            combinedSumitomoNumber = combinedFirst!.SumitomoNumber;

            bool combinedSumitomoNotEmpty;
            combinedSumitomoNotEmpty = !string.IsNullOrWhiteSpace(combinedSumitomoNumber);

            Assert.That(combinedSumitomoNotEmpty, Is.True);

            // ---------------------------------------------------------
            //   FAIL CASE — filter returns 0 rows
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc combinedFailRequest;
            combinedFailRequest = new EmacsFilterRequestGrpc();
            combinedFailRequest.DatabaseList = "CombinedPartsGrpc";

            // Use a value that will never exist
            combinedFailRequest.FilterExpression = "SumitomoNumber == \"THIS_VALUE_DOES_NOT_EXIST_999999\"";

            Assert.That(!string.IsNullOrWhiteSpace(combinedFailRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {combinedFailRequest.DatabaseList}");

            ServerCallContext combinedFailContext;
            combinedFailContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> combinedFailTask;
            combinedFailTask = _GrpcService.FilterEmacsDataGrpc(combinedFailRequest, combinedFailContext);

            EmacsFilterResponseGrpc combinedFailResponse;
            combinedFailResponse = await combinedFailTask;

            int combinedFailCount;
            combinedFailCount = combinedFailResponse.ListCombinedPartsGrpc.CombinedPartsGrpc.Count;

            Assert.That(combinedFailCount == 0, Is.True);
            // ---------------------------------------------------------
            // PART CATEGORY DETAIL
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc partCatFilter = new EmacsFilterRequestGrpc();
            partCatFilter.DatabaseList = "PartCategoryDetailGrpc";
            partCatFilter.FilterExpression = "CategoryCode != null";

            Assert.That(!string.IsNullOrWhiteSpace(partCatFilter.FilterExpression), Is.True);

            ServerCallContext partCatContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));
            EmacsFilterResponseGrpc partCatResp = await _GrpcService.FilterEmacsDataGrpc(partCatFilter, partCatContext);

            int partCatCount = partCatResp.ListPartCategoryDetailGrpc.PartCategoryDetailGrpc.Count;
            Assert.That(0 < partCatCount, Is.True);

            EmacsFilterRequestGrpc partCatFail = new EmacsFilterRequestGrpc();
            partCatFail.DatabaseList = "PartCategoryDetailGrpc";
            partCatFail.FilterExpression = "CategoryCode == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            EmacsFilterResponseGrpc partCatFailResp = await _GrpcService.FilterEmacsDataGrpc(partCatFail, partCatContext);
            Assert.That(partCatFailResp.ListPartCategoryDetailGrpc.PartCategoryDetailGrpc.Count == 0, Is.True);

            // ---------------------------------------------------------
            // PART GROUPS
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc partGroupFilter = new EmacsFilterRequestGrpc();
            partGroupFilter.DatabaseList = "PartGroupsGrpc";
            partGroupFilter.FilterExpression = "PartGroup != null";

            Assert.That(!string.IsNullOrWhiteSpace(partGroupFilter.FilterExpression), Is.True);

            ServerCallContext partGroupContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));
            EmacsFilterResponseGrpc partGroupResp = await _GrpcService.FilterEmacsDataGrpc(partGroupFilter, partGroupContext);

            int partGroupCount = partGroupResp.ListPartGroupsGrpc.PartGroupsGrpc.Count;
            Assert.That(0 < partGroupCount, Is.True);

            EmacsFilterRequestGrpc partGroupFail = new EmacsFilterRequestGrpc();
            partGroupFail.DatabaseList = "PartGroupsGrpc";
            partGroupFail.FilterExpression = "PartGroup == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            EmacsFilterResponseGrpc partGroupFailResp = await _GrpcService.FilterEmacsDataGrpc(partGroupFail, partGroupContext);
            Assert.That(partGroupFailResp.ListPartGroupsGrpc.PartGroupsGrpc.Count == 0, Is.True);

            // ---------------------------------------------------------
            // MATERIAL GROUPS
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc materialGroupFilter = new EmacsFilterRequestGrpc();
            materialGroupFilter.DatabaseList = "MaterialGroupsGrpc";
            materialGroupFilter.FilterExpression = "MaterialGroup != null";

            Assert.That(!string.IsNullOrWhiteSpace(materialGroupFilter.FilterExpression), Is.True);

            ServerCallContext materialGroupContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));
            EmacsFilterResponseGrpc materialGroupResp = await _GrpcService.FilterEmacsDataGrpc(materialGroupFilter, materialGroupContext);

            int materialGroupCount = materialGroupResp.ListMaterialGroupsGrpc.MaterialGroupsGrpc.Count;
            Assert.That(0 < materialGroupCount, Is.True);

            EmacsFilterRequestGrpc materialGroupFail = new EmacsFilterRequestGrpc();
            materialGroupFail.DatabaseList = "MaterialGroupsGrpc";
            materialGroupFail.FilterExpression = "MaterialGroup == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            EmacsFilterResponseGrpc materialGroupFailResp = await _GrpcService.FilterEmacsDataGrpc(materialGroupFail, materialGroupContext);
            Assert.That(materialGroupFailResp.ListMaterialGroupsGrpc.MaterialGroupsGrpc.Count == 0, Is.True);

            // ---------------------------------------------------------
            // PARTMS
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc partMsFilter = new EmacsFilterRequestGrpc();
            partMsFilter.DatabaseList = "PARTMSGrpc";
            partMsFilter.FilterExpression = "SumitomoNumber != null";

            Assert.That(!string.IsNullOrWhiteSpace(partMsFilter.FilterExpression), Is.True);

            ServerCallContext partMsContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));
            EmacsFilterResponseGrpc partMsResp = await _GrpcService.FilterEmacsDataGrpc(partMsFilter, partMsContext);

            int partMsCount = partMsResp.ListPARTMSGrpc.PARTMSGrpc.Count;
            Assert.That(0 < partMsCount, Is.True);

            EmacsFilterRequestGrpc partMsFail = new EmacsFilterRequestGrpc();
            partMsFail.DatabaseList = "PARTMSGrpc";
            partMsFail.FilterExpression = "SumitomoNumber == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            EmacsFilterResponseGrpc partMsFailResp = await _GrpcService.FilterEmacsDataGrpc(partMsFail, partMsContext);
            Assert.That(partMsFailResp.ListPARTMSGrpc.PARTMSGrpc.Count == 0, Is.True);

            // ---------------------------------------------------------
            // SUPPLIERS
            // ---------------------------------------------------------
            EmacsFilterRequestGrpc supplierFilter = new EmacsFilterRequestGrpc();
            supplierFilter.DatabaseList = "SuppliersGrpc";
            supplierFilter.FilterExpression = "SupplierName != null";

            Assert.That(!string.IsNullOrWhiteSpace(supplierFilter.FilterExpression), Is.True);

            ServerCallContext supplierContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));
            EmacsFilterResponseGrpc supplierResp = await _GrpcService.FilterEmacsDataGrpc(supplierFilter, supplierContext);

            int supplierCount = supplierResp.ListSuppliersGrpc.SuppliersGrpc.Count;
            Assert.That(0 < supplierCount, Is.True);

            EmacsFilterRequestGrpc supplierFail = new EmacsFilterRequestGrpc();
            supplierFail.DatabaseList = "SuppliersGrpc";
            supplierFail.FilterExpression = "SupplierName == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            EmacsFilterResponseGrpc supplierFailResp = await _GrpcService.FilterEmacsDataGrpc(supplierFail, supplierContext);
            Assert.That(supplierFailResp.ListSuppliersGrpc.SuppliersGrpc.Count == 0, Is.True);

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

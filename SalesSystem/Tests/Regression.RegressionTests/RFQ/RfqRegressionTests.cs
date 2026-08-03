
using Rfq;
using Rfq.Endpoints.GrpcServices;
using Rfq.Services;

 namespace Regression.Tests.Rfq
{
    public class RfqRegressionTests
    {
        RfqAccessService _RfqAccessService;
        RfqGrpcService _GrpcService;
         [SetUp]
        public void Setup()
        {
            ServiceCollection services;
            services = new ServiceCollection();
             ServiceProvider provider;
            provider = services.BuildServiceProvider();
            Mock<ILogger<RfqAccessService>> logger;
            logger = new Mock<ILogger<RfqAccessService>>();
            _RfqAccessService = new RfqAccessService(provider, logger.Object, true);

            Mock<ILogger<RfqGrpcService>> logger2;
            logger2 = new Mock<ILogger<RfqGrpcService>>();
            _GrpcService = new RfqGrpcService(_RfqAccessService, logger2.Object);
        }
         [Test]
        public async Task RegressionTest_AllEndpoints_FilterOnly_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello (kept for health check)
            // ---------------------------------------------------------

            CommonTypes.HelloRequest helloRequest;
            helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";
             ServerCallContext helloContext;
            helloContext = CreateServerContext(nameof(_GrpcService.SayHello));
             Task<CommonTypes.HelloReply> helloTask;
            helloTask = _GrpcService.SayHello(helloRequest, helloContext);
             CommonTypes.HelloReply helloResult;
            helloResult = await helloTask;
             string actualHello;
            actualHello = helloResult.Message;
             string expectedHello;
            expectedHello = "Hello TestName";
             bool helloEqual;
            helloEqual = actualHello == expectedHello;
            Assert.That(helloEqual, Is.True);

             // ========================================================= $1

            // RFQ DRAWING PART NUMBERS ()
            // ========================================================= $1

            RfqFilterRequest rfqDrawingPnFilterRequest;
            rfqDrawingPnFilterRequest = new RfqFilterRequest();
            rfqDrawingPnFilterRequest.DatabaseList = "RFQDRAWINGPARTNUMBERGRPC";
            rfqDrawingPnFilterRequest.FilterExpression = "RfqId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(rfqDrawingPnFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {rfqDrawingPnFilterRequest.DatabaseList}");
             ServerCallContext rfqDrawingPnFilterContext;
            rfqDrawingPnFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> rfqDrawingPnFilterTask;
            rfqDrawingPnFilterTask = _GrpcService.FilterRfqGrpc(rfqDrawingPnFilterRequest, rfqDrawingPnFilterContext);
             RfqFilterResponse rfqDrawingPnFilterResponse;
            rfqDrawingPnFilterResponse = await rfqDrawingPnFilterTask;
             ListRfqDrawingPartNumberGrpc rfqDrawingPnFilteredList;
            rfqDrawingPnFilteredList = rfqDrawingPnFilterResponse.ListRfqDrawingPartNumbersGrpc;
             int rfqDrawingPnActualFilteredCount;
            rfqDrawingPnActualFilteredCount = rfqDrawingPnFilteredList.RfqDrawingPartNumbers.Count;
             int rfqDrawingPnExpectedFilteredCount;
            rfqDrawingPnExpectedFilteredCount = 1;
             Assert.That(rfqDrawingPnActualFilteredCount == rfqDrawingPnExpectedFilteredCount, Is.True);
             RfqDrawingPartNumberGrpc? rfqDrawingPnFirst;
            rfqDrawingPnFirst = rfqDrawingPnFilteredList.RfqDrawingPartNumbers.FirstOrDefault();
            Assert.That(rfqDrawingPnFirst, Is.Not.Null);
             string rfqDrawingPnOriginalPart;
            rfqDrawingPnOriginalPart = rfqDrawingPnFirst!.OriginalPartNumber;
             bool rfqDrawingPnOriginalNotEmpty;
            rfqDrawingPnOriginalNotEmpty = !string.IsNullOrEmpty(rfqDrawingPnOriginalPart);
            Assert.That(rfqDrawingPnOriginalNotEmpty, Is.True);
             // ========================================================= 

            // RFQ NOTES ()
            // ========================================================= 

            RfqFilterRequest notesFilterRequest;
            notesFilterRequest = new RfqFilterRequest();
            notesFilterRequest.DatabaseList = "RFQNOTESGRPC";
            notesFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(notesFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {notesFilterRequest.DatabaseList}");
             ServerCallContext notesFilterContext;
            notesFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> notesFilterTask;
            notesFilterTask = _GrpcService.FilterRfqGrpc(notesFilterRequest, notesFilterContext);
             RfqFilterResponse notesFilterResponse;
            notesFilterResponse = await notesFilterTask;
             ListRfqNotesGrpc notesFilteredList;
            notesFilteredList = notesFilterResponse.ListRfqNotesGrpc;
             int actualNotesFilteredCount;
            actualNotesFilteredCount = notesFilteredList.RfqNotes == null ? 0 : notesFilteredList.RfqNotes.Count;
             int expectedNotesFilteredCount;
            expectedNotesFilteredCount = 1;
            Assert.That(actualNotesFilteredCount == expectedNotesFilteredCount, Is.True);
             string actualNote;
            actualNote = notesFilteredList.RfqNotes!.First().Note;
            Assert.That(!string.IsNullOrWhiteSpace(actualNote), Is.True);
             //   Fail case
            RfqFilterRequest notesFailFilterRequest;
            notesFailFilterRequest = new RfqFilterRequest();
            notesFailFilterRequest.DatabaseList = "RFQNOTESGRPC";
            notesFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(notesFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {notesFailFilterRequest.DatabaseList}");
             ServerCallContext notesFailFilterContext;
            notesFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> notesFailFilterTask;
            notesFailFilterTask = _GrpcService.FilterRfqGrpc(notesFailFilterRequest, notesFailFilterContext);
             RfqFilterResponse notesFailFilterResponse;
            notesFailFilterResponse = await notesFailFilterTask;
             ListRfqNotesGrpc notesFailList;
            notesFailList = notesFailFilterResponse.ListRfqNotesGrpc;
             int actualNotesFailCount;
            actualNotesFailCount = notesFailList.RfqNotes == null ? 0 : notesFailList.RfqNotes.Count;
             int expectedNotesFailCount;
            expectedNotesFailCount = 0;
            Assert.That(actualNotesFailCount == expectedNotesFailCount, Is.True);
             // ========================================================= 

            // DSI BEND ()
            // ========================================================= 

            RfqFilterRequest dsiBendFilterRequest;
            dsiBendFilterRequest = new RfqFilterRequest();
            dsiBendFilterRequest.DatabaseList = "DSIBENDGRPC";
            dsiBendFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(dsiBendFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {dsiBendFilterRequest.DatabaseList}");
             ServerCallContext dsiBendFilterContext;
            dsiBendFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> dsiBendFilterTask;
            dsiBendFilterTask = _GrpcService.FilterRfqGrpc(dsiBendFilterRequest, dsiBendFilterContext);
             RfqFilterResponse dsiBendFilterResponse;
            dsiBendFilterResponse = await dsiBendFilterTask;
             ListDsiBendGrpc dsiBendFilteredList;
            dsiBendFilteredList = dsiBendFilterResponse.ListDsiBendGrpc;
             int actualDsiBendFilteredCount;
            actualDsiBendFilteredCount = dsiBendFilteredList.DsiBends == null ? 0 : dsiBendFilteredList.DsiBends.Count;
             int expectedDsiBendFilteredCount;
            expectedDsiBendFilteredCount = 1;
            Assert.That(actualDsiBendFilteredCount == expectedDsiBendFilteredCount, Is.True);
             string actualBend;
            actualBend = dsiBendFilteredList.DsiBends!.First().Bend;
             string expectedBend;
            expectedBend = "FixedBend";
            Assert.That(actualBend == expectedBend, Is.True);
             //   Fail case
            RfqFilterRequest dsiBendFailFilterRequest;
            dsiBendFailFilterRequest = new RfqFilterRequest();
            dsiBendFailFilterRequest.DatabaseList = "DSIBENDGRPC";
            dsiBendFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(dsiBendFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {dsiBendFailFilterRequest.DatabaseList}");
             ServerCallContext dsiBendFailFilterContext;
            dsiBendFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> dsiBendFailFilterTask;
            dsiBendFailFilterTask = _GrpcService.FilterRfqGrpc(dsiBendFailFilterRequest, dsiBendFailFilterContext);
             RfqFilterResponse dsiBendFailFilterResponse;
            dsiBendFailFilterResponse = await dsiBendFailFilterTask;
             ListDsiBendGrpc dsiBendFailList;
            dsiBendFailList = dsiBendFailFilterResponse.ListDsiBendGrpc;
             int actualDsiBendFailCount;
            actualDsiBendFailCount = dsiBendFailList.DsiBends == null ? 0 : dsiBendFailList.DsiBends.Count;
             int expectedDsiBendFailCount;
            expectedDsiBendFailCount = 0;
            Assert.That(actualDsiBendFailCount == expectedDsiBendFailCount, Is.True);
             // ========================================================= 

            // DSI BRANCH CONFIGURATION ()
            // ========================================================= 

            RfqFilterRequest branchFilterRequest;
            branchFilterRequest = new RfqFilterRequest();
            branchFilterRequest.DatabaseList = "DSIBRANCHCONFIGURATIONGRPC";
            branchFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(branchFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {branchFilterRequest.DatabaseList}");
             ServerCallContext branchFilterContext;
            branchFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> branchFilterTask;
            branchFilterTask = _GrpcService.FilterRfqGrpc(branchFilterRequest, branchFilterContext);
             RfqFilterResponse branchFilterResponse;
            branchFilterResponse = await branchFilterTask;
             ListDsiBranchConfigurationGrpc branchFilteredList;
            branchFilteredList = branchFilterResponse.ListDsiBranchConfigurationGrpc;
             int actualBranchFilteredCount;
            actualBranchFilteredCount = branchFilteredList.DsiBranchConfigurations == null ? 0 : branchFilteredList.DsiBranchConfigurations.Count;
             int expectedBranchFilteredCount;
            expectedBranchFilteredCount = 1;
            Assert.That(actualBranchFilteredCount == expectedBranchFilteredCount, Is.True);
             DsiBranchConfigurationGrpc? firstBranchConfig;
            firstBranchConfig = branchFilteredList.DsiBranchConfigurations?.FirstOrDefault();
            Assert.That(firstBranchConfig, Is.Not.Null);
             string actualUserModule;
            actualUserModule = firstBranchConfig!.UserModule;
             string expectedUserModule;
            expectedUserModule = "TestUserModule";
            Assert.That(actualUserModule == expectedUserModule, Is.True);
             //   Fail case
            RfqFilterRequest branchFailFilterRequest;
            branchFailFilterRequest = new RfqFilterRequest();
            branchFailFilterRequest.DatabaseList = "DSIBRANCHCONFIGURATIONGRPC";
            branchFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(branchFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {branchFailFilterRequest.DatabaseList}");
             ServerCallContext branchFailFilterContext;
            branchFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> branchFailFilterTask;
            branchFailFilterTask = _GrpcService.FilterRfqGrpc(branchFailFilterRequest, branchFailFilterContext);
             RfqFilterResponse branchFailFilterResponse;
            branchFailFilterResponse = await branchFailFilterTask;
             ListDsiBranchConfigurationGrpc branchFailList;
            branchFailList = branchFailFilterResponse.ListDsiBranchConfigurationGrpc;
             int actualBranchFailCount;
            actualBranchFailCount = branchFailList.DsiBranchConfigurations == null ? 0 : branchFailList.DsiBranchConfigurations.Count;
             int expectedBranchFailCount;
            expectedBranchFailCount = 0;
            Assert.That(actualBranchFailCount == expectedBranchFailCount, Is.True);
             // ========================================================= 

            // DSI BRANCH CONFIGURATION BEND ASSOCIATION ()
            // ========================================================= 

            RfqFilterRequest bendAssocFilterRequest;
            bendAssocFilterRequest = new RfqFilterRequest();
            bendAssocFilterRequest.DatabaseList = "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC";
            bendAssocFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(bendAssocFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {bendAssocFilterRequest.DatabaseList}");
             ServerCallContext bendAssocFilterContext;
            bendAssocFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> bendAssocFilterTask;
            bendAssocFilterTask = _GrpcService.FilterRfqGrpc(bendAssocFilterRequest, bendAssocFilterContext);
             RfqFilterResponse bendAssocFilterResponse;
            bendAssocFilterResponse = await bendAssocFilterTask;
             ListDsiBranchConfigurationBendAssociationGrpc bendAssocFilteredList;
            bendAssocFilteredList = bendAssocFilterResponse.ListDsiBranchConfigurationBendAssociationGrpc;
             int actualAssocFilteredCount;
            actualAssocFilteredCount = bendAssocFilteredList.DsiBranchConfigurationBendAssociations == null ? 0 : bendAssocFilteredList.DsiBranchConfigurationBendAssociations.Count;
             int expectedAssocFilteredCount;
            expectedAssocFilteredCount = 1;
            Assert.That(actualAssocFilteredCount == expectedAssocFilteredCount, Is.True);
             DsiBranchConfigurationBendAssociationGrpc? firstAssoc;
            firstAssoc = bendAssocFilteredList.DsiBranchConfigurationBendAssociations?.FirstOrDefault();
            Assert.That(firstAssoc, Is.Not.Null);
             string actualBendId;
            actualBendId = firstAssoc!.BendId;
             string expectedBendId;
            expectedBendId = "664c3151-c7fc-4e0e-971c-f1712a6342e1";
            Assert.That(actualBendId == expectedBendId, Is.True);
             //   Fail case
            RfqFilterRequest bendAssocFailFilterRequest;
            bendAssocFailFilterRequest = new RfqFilterRequest();
            bendAssocFailFilterRequest.DatabaseList = "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC";
            bendAssocFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(bendAssocFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {bendAssocFailFilterRequest.DatabaseList}");
             ServerCallContext bendAssocFailFilterContext;
            bendAssocFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> bendAssocFailFilterTask;
            bendAssocFailFilterTask = _GrpcService.FilterRfqGrpc(bendAssocFailFilterRequest, bendAssocFailFilterContext);
             RfqFilterResponse bendAssocFailFilterResponse;
            bendAssocFailFilterResponse = await bendAssocFailFilterTask;
             ListDsiBranchConfigurationBendAssociationGrpc bendAssocFailList;
            bendAssocFailList = bendAssocFailFilterResponse.ListDsiBranchConfigurationBendAssociationGrpc;
             int actualAssocFailCount;
            actualAssocFailCount = bendAssocFailList.DsiBranchConfigurationBendAssociations == null ? 0 : bendAssocFailList.DsiBranchConfigurationBendAssociations.Count;
             int expectedAssocFailCount;
            expectedAssocFailCount = 0;
            Assert.That(actualAssocFailCount == expectedAssocFailCount, Is.True);
             // ========================================================= 

            // DSI BRANCH INSULATION ()
            // ========================================================= 

            RfqFilterRequest insulationFilterRequest;
            insulationFilterRequest = new RfqFilterRequest();
            insulationFilterRequest.DatabaseList = "DSIBRANCHINSULATIONGRPC";
            insulationFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(insulationFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {insulationFilterRequest.DatabaseList}");
             ServerCallContext insulationFilterContext;
            insulationFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> insulationFilterTask;
            insulationFilterTask = _GrpcService.FilterRfqGrpc(insulationFilterRequest, insulationFilterContext);
             RfqFilterResponse insulationFilterResponse;
            insulationFilterResponse = await insulationFilterTask;
             ListDsiBranchInsulationGrpc insulationFilteredList;
            insulationFilteredList = insulationFilterResponse.ListDsiBranchInsulationGrpc;
             int actualInsulationFilteredCount;
            actualInsulationFilteredCount = insulationFilteredList.DsiBranchInsulations == null ? 0 : insulationFilteredList.DsiBranchInsulations.Count;
             int expectedInsulationFilteredCount;
            expectedInsulationFilteredCount = 1;
            Assert.That(actualInsulationFilteredCount == expectedInsulationFilteredCount, Is.True);
             DsiBranchInsulationGrpc? firstInsulation;
            firstInsulation = insulationFilteredList.DsiBranchInsulations?.FirstOrDefault();
            Assert.That(firstInsulation, Is.Not.Null);
             string actualColour;
            actualColour = firstInsulation!.Colour;
             string expectedColour;
            expectedColour = "FixedColour";
            Assert.That(actualColour == expectedColour, Is.True);
             //   Fail case
            RfqFilterRequest insulationFailFilterRequest;
            insulationFailFilterRequest = new RfqFilterRequest();
            insulationFailFilterRequest.DatabaseList = "DSIBRANCHINSULATIONGRPC";
            insulationFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(insulationFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {insulationFailFilterRequest.DatabaseList}");
             ServerCallContext insulationFailFilterContext;
            insulationFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> insulationFailFilterTask;
            insulationFailFilterTask = _GrpcService.FilterRfqGrpc(insulationFailFilterRequest, insulationFailFilterContext);
             RfqFilterResponse insulationFailFilterResponse;
            insulationFailFilterResponse = await insulationFailFilterTask;
             ListDsiBranchInsulationGrpc insulationFailList;
            insulationFailList = insulationFailFilterResponse.ListDsiBranchInsulationGrpc;
             int actualInsulationFailCount;
            actualInsulationFailCount = insulationFailList.DsiBranchInsulations == null ? 0 : insulationFailList.DsiBranchInsulations.Count;
             int expectedInsulationFailCount;
            expectedInsulationFailCount = 0;
            Assert.That(actualInsulationFailCount == expectedInsulationFailCount, Is.True);
             // ========================================================= 

            // DSI BRANCH INSULATION THROUGH NODE ()
            // ========================================================= 

            RfqFilterRequest insulationThroughNodeFilterRequest;
            insulationThroughNodeFilterRequest = new RfqFilterRequest();
            insulationThroughNodeFilterRequest.DatabaseList = "DSIBRANCHINSULATIONTHROUGHNODEGRPC";
            insulationThroughNodeFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(insulationThroughNodeFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {insulationThroughNodeFilterRequest.DatabaseList}");
             ServerCallContext insulationThroughNodeFilterContext;
            insulationThroughNodeFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> insulationThroughNodeFilterTask;
            insulationThroughNodeFilterTask = _GrpcService.FilterRfqGrpc(insulationThroughNodeFilterRequest, insulationThroughNodeFilterContext);
             RfqFilterResponse insulationThroughNodeFilterResponse;
            insulationThroughNodeFilterResponse = await insulationThroughNodeFilterTask;
             ListDsiBranchInsulationThroughNodeGrpc insulationThroughNodeFilteredList;
            insulationThroughNodeFilteredList = insulationThroughNodeFilterResponse.ListDsiBranchInsulationThroughNodeGrpc;
             int actualThroughNodeFilteredCount;
            actualThroughNodeFilteredCount = insulationThroughNodeFilteredList.DsiBranchInsulationThroughNodes == null ? 0 : insulationThroughNodeFilteredList.DsiBranchInsulationThroughNodes.Count;
             int expectedThroughNodeFilteredCount;
            expectedThroughNodeFilteredCount = 1;
            Assert.That(actualThroughNodeFilteredCount == expectedThroughNodeFilteredCount, Is.True);
             DsiBranchInsulationThroughNodeGrpc? firstThroughNode;
            firstThroughNode = insulationThroughNodeFilteredList.DsiBranchInsulationThroughNodes?.FirstOrDefault();
            Assert.That(firstThroughNode, Is.Not.Null);
             string actualThroughNode;
            actualThroughNode = firstThroughNode!.ThroughNode;
             string expectedThroughNode;
            expectedThroughNode = "FixedThroughNode";
            Assert.That(actualThroughNode == expectedThroughNode, Is.True);
             //   Fail case
            RfqFilterRequest insulationThroughNodeFailFilterRequest;
            insulationThroughNodeFailFilterRequest = new RfqFilterRequest();
            insulationThroughNodeFailFilterRequest.DatabaseList = "DSIBRANCHINSULATIONTHROUGHNODEGRPC";
            insulationThroughNodeFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(insulationThroughNodeFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {insulationThroughNodeFailFilterRequest.DatabaseList}");
             ServerCallContext insulationThroughNodeFailFilterContext;
            insulationThroughNodeFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> insulationThroughNodeFailFilterTask;
            insulationThroughNodeFailFilterTask = _GrpcService.FilterRfqGrpc(insulationThroughNodeFailFilterRequest, insulationThroughNodeFailFilterContext);
             RfqFilterResponse insulationThroughNodeFailFilterResponse;
            insulationThroughNodeFailFilterResponse = await insulationThroughNodeFailFilterTask;
             ListDsiBranchInsulationThroughNodeGrpc insulationThroughNodeFailList;
            insulationThroughNodeFailList = insulationThroughNodeFailFilterResponse.ListDsiBranchInsulationThroughNodeGrpc;
             int actualThroughNodeFailCount;
            actualThroughNodeFailCount = insulationThroughNodeFailList.DsiBranchInsulationThroughNodes == null ? 0 : insulationThroughNodeFailList.DsiBranchInsulationThroughNodes.Count;
             int expectedThroughNodeFailCount;
            expectedThroughNodeFailCount = 0;
            Assert.That(actualThroughNodeFailCount == expectedThroughNodeFailCount, Is.True);
             // ========================================================= 

            // DSI CAVITY MAPPING ()
            // ========================================================= 

            RfqFilterRequest cavityFilterRequest;
            cavityFilterRequest = new RfqFilterRequest();
            cavityFilterRequest.DatabaseList = "DSICAVITYMAPPINGGRPC";
            cavityFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(cavityFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {cavityFilterRequest.DatabaseList}");
             ServerCallContext cavityFilterContext;
            cavityFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> cavityFilterTask;
            cavityFilterTask = _GrpcService.FilterRfqGrpc(cavityFilterRequest, cavityFilterContext);
             RfqFilterResponse cavityFilterResponse;
            cavityFilterResponse = await cavityFilterTask;
             ListDsiCavityMappingGrpc cavityFilteredList;
            cavityFilteredList = cavityFilterResponse.ListDsiCavityMappingGrpc;
             int actualCavityFilteredCount;
            actualCavityFilteredCount = cavityFilteredList.DsiCavityMappingGrpcs == null ? 0 : cavityFilteredList.DsiCavityMappingGrpcs.Count;
             int expectedCavityFilteredCount;
            expectedCavityFilteredCount = 1;
            Assert.That(actualCavityFilteredCount == expectedCavityFilteredCount, Is.True);
             DsiCavityMappingGrpc? firstCavity;
            firstCavity = cavityFilteredList.DsiCavityMappingGrpcs?.FirstOrDefault();
            Assert.That(firstCavity, Is.Not.Null);
             string actualCavityMapping;
            actualCavityMapping = firstCavity!.CavityMapping;
             string expectedCavityMapping;
            expectedCavityMapping = "FixedCavityMapping";
            Assert.That(actualCavityMapping == expectedCavityMapping, Is.True);
             // ========================================================= 

            // DSI CIRCUIT OPTION ()
            // ========================================================= 

            RfqFilterRequest circuitOptionFilterRequest;
            circuitOptionFilterRequest = new RfqFilterRequest();
            circuitOptionFilterRequest.DatabaseList = "DSICIRCUITOPTIONGRPC";
            circuitOptionFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(circuitOptionFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {circuitOptionFilterRequest.DatabaseList}");
             ServerCallContext circuitOptionFilterContext;
            circuitOptionFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> circuitOptionFilterTask;
            circuitOptionFilterTask = _GrpcService.FilterRfqGrpc(circuitOptionFilterRequest, circuitOptionFilterContext);
             RfqFilterResponse circuitOptionFilterResponse;
            circuitOptionFilterResponse = await circuitOptionFilterTask;
             ListDsiCircuitOptionGrpc circuitOptionFilteredList;
            circuitOptionFilteredList = circuitOptionFilterResponse.ListDsiCircuitOptionGrpc;
             int actualCircuitOptionFilteredCount;
            actualCircuitOptionFilteredCount = circuitOptionFilteredList.DsiCircuitOptionGrpcs == null ? 0 : circuitOptionFilteredList.DsiCircuitOptionGrpcs.Count;
             int expectedCircuitOptionFilteredCount;
            expectedCircuitOptionFilteredCount = 1;
            Assert.That(actualCircuitOptionFilteredCount == expectedCircuitOptionFilteredCount, Is.True);
             DsiCircuitOptionGrpc? firstCircuitOption;
            firstCircuitOption = circuitOptionFilteredList.DsiCircuitOptionGrpcs?.FirstOrDefault();
            Assert.That(firstCircuitOption, Is.Not.Null);
             string actualOptionName;
            actualOptionName = firstCircuitOption!.OptionName;
             string expectedOptionName;
            expectedOptionName = "FixedCircuitOption";
            Assert.That(actualOptionName == expectedOptionName, Is.True);
             // ========================================================= 

            // DSI HARNESS ()
            // ========================================================= 

            RfqFilterRequest harnessFilterRequest;
            harnessFilterRequest = new RfqFilterRequest();
            harnessFilterRequest.DatabaseList = "DSIHARNESSGRPC";
            harnessFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(harnessFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {harnessFilterRequest.DatabaseList}");
             ServerCallContext harnessFilterContext;
            harnessFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> harnessFilterTask;
            harnessFilterTask = _GrpcService.FilterRfqGrpc(harnessFilterRequest, harnessFilterContext);
             RfqFilterResponse harnessFilterResponse;
            harnessFilterResponse = await harnessFilterTask;
             ListDsiHarnessGrpc harnessFilteredList;
            harnessFilteredList = harnessFilterResponse.ListDsiHarnessGrpc;
             int actualHarnessFilteredCount;
            actualHarnessFilteredCount = harnessFilteredList.DsiHarnessGrpcs == null ? 0 : harnessFilteredList.DsiHarnessGrpcs.Count;
             int expectedHarnessFilteredCount;
            expectedHarnessFilteredCount = 1;
            Assert.That(actualHarnessFilteredCount == expectedHarnessFilteredCount, Is.True);
             DsiHarnessGrpc? firstHarness;
            firstHarness = harnessFilteredList.DsiHarnessGrpcs?.FirstOrDefault();
            Assert.That(firstHarness, Is.Not.Null);
             string actualHarnessName;
            actualHarnessName = firstHarness!.HarnessName1;
             string expectedHarnessName;
            expectedHarnessName = "FixedHarnessA";
            Assert.That(actualHarnessName == expectedHarnessName, Is.True);
             //   Fail case
            RfqFilterRequest harnessFailFilterRequest;
            harnessFailFilterRequest = new RfqFilterRequest();
            harnessFailFilterRequest.DatabaseList = "DSIHARNESSGRPC";
            harnessFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(harnessFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {harnessFailFilterRequest.DatabaseList}");
             ServerCallContext harnessFailFilterContext;
            harnessFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> harnessFailFilterTask;
            harnessFailFilterTask = _GrpcService.FilterRfqGrpc(harnessFailFilterRequest, harnessFailFilterContext);
             RfqFilterResponse harnessFailFilterResponse;
            harnessFailFilterResponse = await harnessFailFilterTask;
             ListDsiHarnessGrpc harnessFailList;
            harnessFailList = harnessFailFilterResponse.ListDsiHarnessGrpc;
             int actualHarnessFailCount;
            actualHarnessFailCount = harnessFailList.DsiHarnessGrpcs == null ? 0 : harnessFailList.DsiHarnessGrpcs.Count;
             int expectedHarnessFailCount;
            expectedHarnessFailCount = 0;
            Assert.That(actualHarnessFailCount == expectedHarnessFailCount, Is.True);
             // ========================================================= 

            // DSI COMPOSITE DETAIL ()
            // ========================================================= 

            RfqFilterRequest compositeDetailFilterRequest;
            compositeDetailFilterRequest = new RfqFilterRequest();
            compositeDetailFilterRequest.DatabaseList = "DSICOMPOSITEDETAILGRPC";
            compositeDetailFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(compositeDetailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {compositeDetailFilterRequest.DatabaseList}");
             ServerCallContext compositeDetailFilterContext;
            compositeDetailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> compositeDetailFilterTask;
            compositeDetailFilterTask = _GrpcService.FilterRfqGrpc(compositeDetailFilterRequest, compositeDetailFilterContext);
             RfqFilterResponse compositeDetailFilterResponse;
            compositeDetailFilterResponse = await compositeDetailFilterTask;
             ListDsiCompositeDetailGrpc compositeDetailFilteredList;
            compositeDetailFilteredList = compositeDetailFilterResponse.ListDsiCompositeDetailGrpc;
             int actualCompositeDetailFilteredCount;
            actualCompositeDetailFilteredCount = compositeDetailFilteredList.DsiCompositeDetailGrpcs == null ? 0 : compositeDetailFilteredList.DsiCompositeDetailGrpcs.Count;
             int expectedCompositeDetailFilteredCount;
            expectedCompositeDetailFilteredCount = 1;
            Assert.That(actualCompositeDetailFilteredCount == expectedCompositeDetailFilteredCount, Is.True);
             DsiCompositeDetailGrpc? firstCompositeDetail;
            firstCompositeDetail = compositeDetailFilteredList.DsiCompositeDetailGrpcs?.FirstOrDefault();
            Assert.That(firstCompositeDetail, Is.Not.Null);
             actualHarnessName = firstCompositeDetail!.HarnessName1;
            Assert.That(actualHarnessName == expectedHarnessName, Is.True);
             // ========================================================= 

            // DSI COMPOSITE DETAIL CIRCUIT OPTION ASSOCIATION ()
            // ========================================================= 

            RfqFilterRequest compositeAssocFilterRequest;
            compositeAssocFilterRequest = new RfqFilterRequest();
            compositeAssocFilterRequest.DatabaseList = "DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC";
            compositeAssocFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(compositeAssocFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {compositeAssocFilterRequest.DatabaseList}");
             ServerCallContext compositeAssocFilterContext;
            compositeAssocFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> compositeAssocFilterTask;
            compositeAssocFilterTask = _GrpcService.FilterRfqGrpc(compositeAssocFilterRequest, compositeAssocFilterContext);
             RfqFilterResponse compositeAssocFilterResponse;
            compositeAssocFilterResponse = await compositeAssocFilterTask;
             ListDsiCompositeDetailCircuitOptionAssociationGrpc compositeAssocFilteredList;
            compositeAssocFilteredList = compositeAssocFilterResponse.ListDsiCompositeDetailCircuitOptionAssociationGrpc;
             int actualCompositeAssocFilteredCount;
            actualCompositeAssocFilteredCount = compositeAssocFilteredList.DsiCompositeDetailCircuitOptionAssociationGrpcs == null ? 0 : compositeAssocFilteredList.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count;
             int expectedCompositeAssocFilteredCount;
            expectedCompositeAssocFilteredCount = 1;
            Assert.That(actualCompositeAssocFilteredCount == expectedCompositeAssocFilteredCount, Is.True);
             // ========================================================= 

            // DSI MODULE CHILD DETAIL ()
            // ========================================================= 

            RfqFilterRequest moduleChildFilterRequest;
            moduleChildFilterRequest = new RfqFilterRequest();
            moduleChildFilterRequest.DatabaseList = "DSIMODULECHILDDETAILGRPC";
            moduleChildFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(moduleChildFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {moduleChildFilterRequest.DatabaseList}");
             ServerCallContext moduleChildFilterContext;
            moduleChildFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> moduleChildFilterTask;
            moduleChildFilterTask = _GrpcService.FilterRfqGrpc(moduleChildFilterRequest, moduleChildFilterContext);
             RfqFilterResponse moduleChildFilterResponse;
            moduleChildFilterResponse = await moduleChildFilterTask;
             ListDsiModuleChildDetailGrpc moduleChildFilteredList;
            moduleChildFilteredList = moduleChildFilterResponse.ListDsiModuleChildDetailGrpc;
             int actualModuleChildFilteredCount;
            actualModuleChildFilteredCount = moduleChildFilteredList.DsiModuleChildDetailGrpcs == null ? 0 : moduleChildFilteredList.DsiModuleChildDetailGrpcs.Count;
             int expectedModuleChildFilteredCount;
            expectedModuleChildFilteredCount = 1;
            Assert.That(actualModuleChildFilteredCount == expectedModuleChildFilteredCount, Is.True);
             DsiModuleChildDetailGrpc? firstModuleChild;
            firstModuleChild = moduleChildFilteredList.DsiModuleChildDetailGrpcs?.FirstOrDefault();
            Assert.That(firstModuleChild, Is.Not.Null);
             string actualModuleCode;
            actualModuleCode = firstModuleChild!.ModuleCode;
             string expectedModuleCode;
            expectedModuleCode = "FixedModule";
            Assert.That(actualModuleCode == expectedModuleCode, Is.True);
             //   Fail case
            RfqFilterRequest moduleChildFailFilterRequest;
            moduleChildFailFilterRequest = new RfqFilterRequest();
            moduleChildFailFilterRequest.DatabaseList = "DSIMODULECHILDDETAILGRPC";
            moduleChildFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(moduleChildFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {moduleChildFailFilterRequest.DatabaseList}");
             ServerCallContext moduleChildFailFilterContext;
            moduleChildFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> moduleChildFailFilterTask;
            moduleChildFailFilterTask = _GrpcService.FilterRfqGrpc(moduleChildFailFilterRequest, moduleChildFailFilterContext);
             RfqFilterResponse moduleChildFailFilterResponse;
            moduleChildFailFilterResponse = await moduleChildFailFilterTask;
             ListDsiModuleChildDetailGrpc moduleChildFailList;
            moduleChildFailList = moduleChildFailFilterResponse.ListDsiModuleChildDetailGrpc;
             int actualModuleChildFailCount;
            actualModuleChildFailCount = moduleChildFailList.DsiModuleChildDetailGrpcs == null ? 0 : moduleChildFailList.DsiModuleChildDetailGrpcs.Count;
             int expectedModuleChildFailCount;
            expectedModuleChildFailCount = 0;
            Assert.That(actualModuleChildFailCount == expectedModuleChildFailCount, Is.True);
             // ========================================================= 

            // DSI CENTRE STRIP ()
            // ========================================================= 

            RfqFilterRequest centreStripFilterRequest;
            centreStripFilterRequest = new RfqFilterRequest();
            centreStripFilterRequest.DatabaseList = "DSICENTRESTRIPGRPC";
            centreStripFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(centreStripFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {centreStripFilterRequest.DatabaseList}");
             ServerCallContext centreStripFilterContext;
            centreStripFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> centreStripFilterTask;
            centreStripFilterTask = _GrpcService.FilterRfqGrpc(centreStripFilterRequest, centreStripFilterContext);
             RfqFilterResponse centreStripFilterResponse;
            centreStripFilterResponse = await centreStripFilterTask;
             ListDsiCentreStripGrpc centreStripFilteredList;
            centreStripFilteredList = centreStripFilterResponse.ListDsiCentreStripGrpc;
             int actualCentreStripFilteredCount;
            actualCentreStripFilteredCount = centreStripFilteredList.DsiCentreStripGrpcs == null ? 0 : centreStripFilteredList.DsiCentreStripGrpcs.Count;
             int expectedCentreStripFilteredCount;
            expectedCentreStripFilteredCount = 1;
            Assert.That(actualCentreStripFilteredCount == expectedCentreStripFilteredCount, Is.True);
             DsiCentreStripGrpc? firstCentreStrip;
            firstCentreStrip = centreStripFilteredList.DsiCentreStripGrpcs?.FirstOrDefault();
            Assert.That(firstCentreStrip, Is.Not.Null);
             string actualWireName;
            actualWireName = firstCentreStrip!.WireName;
             string expectedWireName;
            expectedWireName = "FixedWire";
            Assert.That(actualWireName == expectedWireName, Is.True);
             // ========================================================= 

            // DSI COMPONENT ()
            // ========================================================= 

            RfqFilterRequest componentFilterRequest;
            componentFilterRequest = new RfqFilterRequest();
            componentFilterRequest.DatabaseList = "DSICOMPONENTGRPC";
            componentFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(componentFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {componentFilterRequest.DatabaseList}");
             ServerCallContext componentFilterContext;
            componentFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> componentFilterTask;
            componentFilterTask = _GrpcService.FilterRfqGrpc(componentFilterRequest, componentFilterContext);
             RfqFilterResponse componentFilterResponse;
            componentFilterResponse = await componentFilterTask;
             ListDsiComponentGrpc componentFilteredList;
            componentFilteredList = componentFilterResponse.ListDsiComponentGrpc;
             int actualComponentFilteredCount;
            actualComponentFilteredCount = componentFilteredList.DsiComponentGrpcs == null ? 0 : componentFilteredList.DsiComponentGrpcs.Count;
             int expectedComponentFilteredCount;
            expectedComponentFilteredCount = 1;
            Assert.That(actualComponentFilteredCount == expectedComponentFilteredCount, Is.True);
             DsiComponentGrpc? firstComponent;
            firstComponent = componentFilteredList.DsiComponentGrpcs?.FirstOrDefault();
            Assert.That(firstComponent, Is.Not.Null);
             actualWireName = firstComponent!.WireName;
            Assert.That(actualWireName == expectedWireName, Is.True);
             //   Fail case
            RfqFilterRequest componentFailFilterRequest;
            componentFailFilterRequest = new RfqFilterRequest();
            componentFailFilterRequest.DatabaseList = "DSICOMPONENTGRPC";
            componentFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(componentFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {componentFailFilterRequest.DatabaseList}");
             ServerCallContext componentFailFilterContext;
            componentFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> componentFailFilterTask;
            componentFailFilterTask = _GrpcService.FilterRfqGrpc(componentFailFilterRequest, componentFailFilterContext);
             RfqFilterResponse componentFailFilterResponse;
            componentFailFilterResponse = await componentFailFilterTask;
             ListDsiComponentGrpc componentFailList;
            componentFailList = componentFailFilterResponse.ListDsiComponentGrpc;
             int actualComponentFailCount;
            actualComponentFailCount = componentFailList.DsiComponentGrpcs == null ? 0 : componentFailList.DsiComponentGrpcs.Count;
             int expectedComponentFailCount;
            expectedComponentFailCount = 0;
            Assert.That(actualComponentFailCount == expectedComponentFailCount, Is.True);
             // ========================================================= 

            // DSI COMPOSITE OPTION ()
            // ========================================================= 

            RfqFilterRequest compositeOptionFilterRequest;
            compositeOptionFilterRequest = new RfqFilterRequest();
            compositeOptionFilterRequest.DatabaseList = "DSICOMPOSITEOPTIONGRPC";
            compositeOptionFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(compositeOptionFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {compositeOptionFilterRequest.DatabaseList}");
             ServerCallContext compositeOptionFilterContext;
            compositeOptionFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> compositeOptionFilterTask;
            compositeOptionFilterTask = _GrpcService.FilterRfqGrpc(compositeOptionFilterRequest, compositeOptionFilterContext);
             RfqFilterResponse compositeOptionFilterResponse;
            compositeOptionFilterResponse = await compositeOptionFilterTask;
             ListDsiCompositeOptionGrpc compositeOptionFilteredList;
            compositeOptionFilteredList = compositeOptionFilterResponse.ListDsiCompositeOptionGrpc;
             int actualCompositeOptionFilteredCount;
            actualCompositeOptionFilteredCount = compositeOptionFilteredList.DsiCompositeOptionGrpcs == null ? 0 : compositeOptionFilteredList.DsiCompositeOptionGrpcs.Count;
             int expectedCompositeOptionFilteredCount;
            expectedCompositeOptionFilteredCount = 1;
            Assert.That(actualCompositeOptionFilteredCount == expectedCompositeOptionFilteredCount, Is.True);
             DsiCompositeOptionGrpc? firstCompositeOption;
            firstCompositeOption = compositeOptionFilteredList.DsiCompositeOptionGrpcs?.FirstOrDefault();
            Assert.That(firstCompositeOption, Is.Not.Null);
             actualOptionName = firstCompositeOption!.OptionName;
            string expectedCompositeOptionName;
            expectedCompositeOptionName = "FixedCompositeOption";
            Assert.That(actualOptionName == expectedCompositeOptionName, Is.True);
             // ========================================================= 

            // DSI HARNESS SCOPE ()
            // ========================================================= 

            RfqFilterRequest harnessScopeFilterRequest;
            harnessScopeFilterRequest = new RfqFilterRequest();
            harnessScopeFilterRequest.DatabaseList = "DSIHARNESSSCOPEGRPC";
            harnessScopeFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(harnessScopeFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {harnessScopeFilterRequest.DatabaseList}");
             ServerCallContext harnessScopeFilterContext;
            harnessScopeFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> harnessScopeFilterTask;
            harnessScopeFilterTask = _GrpcService.FilterRfqGrpc(harnessScopeFilterRequest, harnessScopeFilterContext);
             RfqFilterResponse harnessScopeFilterResponse;
            harnessScopeFilterResponse = await harnessScopeFilterTask;
             ListDsiHarnessScopeGrpc harnessScopeFilteredList;
            harnessScopeFilteredList = harnessScopeFilterResponse.ListDsiHarnessScopeGrpc;
             int actualHarnessScopeFilteredCount;
            actualHarnessScopeFilteredCount = harnessScopeFilteredList.DsiHarnessScopeGrpcs == null ? 0 : harnessScopeFilteredList.DsiHarnessScopeGrpcs.Count;
             int expectedHarnessScopeFilteredCount;
            expectedHarnessScopeFilteredCount = 1;
            Assert.That(actualHarnessScopeFilteredCount == expectedHarnessScopeFilteredCount, Is.True);
             DsiHarnessScopeGrpc? firstHarnessScope;
            firstHarnessScope = harnessScopeFilteredList.DsiHarnessScopeGrpcs?.FirstOrDefault();
            Assert.That(firstHarnessScope, Is.Not.Null);
             actualHarnessName = firstHarnessScope!.HarnessName1;
            Assert.That(actualHarnessName == expectedHarnessName, Is.True);
             // ========================================================= 

            // DSI HARNESS SCOPE — SCOPE ASSOCIATION ()
            // ========================================================= 

            RfqFilterRequest harnessScopeAssocFilterRequest;
            harnessScopeAssocFilterRequest = new RfqFilterRequest();
            harnessScopeAssocFilterRequest.DatabaseList = "DSIHARNESSSCOPESCOPEASSOCIATIONGRPC";
            harnessScopeAssocFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(harnessScopeAssocFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {harnessScopeAssocFilterRequest.DatabaseList}");
             ServerCallContext harnessScopeAssocFilterContext;
            harnessScopeAssocFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> harnessScopeAssocFilterTask;
            harnessScopeAssocFilterTask = _GrpcService.FilterRfqGrpc(harnessScopeAssocFilterRequest, harnessScopeAssocFilterContext);
             RfqFilterResponse harnessScopeAssocFilterResponse;
            harnessScopeAssocFilterResponse = await harnessScopeAssocFilterTask;
             ListDsiHarnessScopeScopeAssociationGrpc harnessScopeAssocFilteredList;
            harnessScopeAssocFilteredList = harnessScopeAssocFilterResponse.ListDsiHarnessScopeScopeAssociationGrpc;
             int actualHarnessScopeAssocFilteredCount;
            actualHarnessScopeAssocFilteredCount = harnessScopeAssocFilteredList.DsiHarnessScopeScopeAssociationGrpcs == null ? 0 : harnessScopeAssocFilteredList.DsiHarnessScopeScopeAssociationGrpcs.Count;
             int expectedHarnessScopeAssocFilteredCount;
            expectedHarnessScopeAssocFilteredCount = 1;
            Assert.That(actualHarnessScopeAssocFilteredCount == expectedHarnessScopeAssocFilteredCount, Is.True);
             // =========================================================

            // DSI MANUAL BOM QUANTITY ()
            // ========================================================= 

            RfqFilterRequest manualBomFilterRequest;
            manualBomFilterRequest = new RfqFilterRequest();
            manualBomFilterRequest.DatabaseList = "DSIMANUALBOMQUANTITYGRPC";
            manualBomFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(manualBomFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {manualBomFilterRequest.DatabaseList}");
             ServerCallContext manualBomFilterContext;
            manualBomFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> manualBomFilterTask;
            manualBomFilterTask = _GrpcService.FilterRfqGrpc(manualBomFilterRequest, manualBomFilterContext);
             RfqFilterResponse manualBomFilterResponse;
            manualBomFilterResponse = await manualBomFilterTask;
             ListDsiManualBomQuantityGrpc manualBomFilteredList;
            manualBomFilteredList = manualBomFilterResponse.ListDsiManualBomQuantityGrpc;
             int actualManualBomFilteredCount;
            actualManualBomFilteredCount = manualBomFilteredList.DsiManualBomQuantityGrpcs == null ? 0 : manualBomFilteredList.DsiManualBomQuantityGrpcs.Count;
             int expectedManualBomFilteredCount;
            expectedManualBomFilteredCount = 1;
            Assert.That(actualManualBomFilteredCount == expectedManualBomFilteredCount, Is.True);
             DsiManualBomQuantityGrpc? firstManualBom;
            firstManualBom = manualBomFilteredList.DsiManualBomQuantityGrpcs?.FirstOrDefault();
            Assert.That(firstManualBom, Is.Not.Null);
         
            actualModuleCode = firstManualBom!.ModuleCode;
            expectedModuleCode = "FixedModule";
            Assert.That(actualModuleCode == expectedModuleCode, Is.True);
             //   Fail case
            RfqFilterRequest manualBomFailFilterRequest;
            manualBomFailFilterRequest = new RfqFilterRequest();
            manualBomFailFilterRequest.DatabaseList = "DSIMANUALBOMQUANTITYGRPC";
            manualBomFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(manualBomFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {manualBomFailFilterRequest.DatabaseList}");
             ServerCallContext manualBomFailFilterContext;
            manualBomFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> manualBomFailFilterTask;
            manualBomFailFilterTask = _GrpcService.FilterRfqGrpc(manualBomFailFilterRequest, manualBomFailFilterContext);
             RfqFilterResponse manualBomFailFilterResponse;
            manualBomFailFilterResponse = await manualBomFailFilterTask;
             ListDsiManualBomQuantityGrpc manualBomFailList;
            manualBomFailList = manualBomFailFilterResponse.ListDsiManualBomQuantityGrpc;
             int actualManualBomFailCount;
            actualManualBomFailCount = manualBomFailList.DsiManualBomQuantityGrpcs == null ? 0 : manualBomFailList.DsiManualBomQuantityGrpcs.Count;
             int expectedManualBomFailCount;
            expectedManualBomFailCount = 0;
            Assert.That(actualManualBomFailCount == expectedManualBomFailCount, Is.True);
             // ========================================================= 

            // DSI MID WIRE COMPONENT ()
            // ========================================================= 

            RfqFilterRequest midWireFilterRequest;
            midWireFilterRequest = new RfqFilterRequest();
            midWireFilterRequest.DatabaseList = "DSIMIDWIRECOMPONENTGRPC";
            midWireFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(midWireFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {midWireFilterRequest.DatabaseList}");
             ServerCallContext midWireFilterContext;
            midWireFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> midWireFilterTask;
            midWireFilterTask = _GrpcService.FilterRfqGrpc(midWireFilterRequest, midWireFilterContext);
             RfqFilterResponse midWireFilterResponse;
            midWireFilterResponse = await midWireFilterTask;
             ListDsiMidWireComponentGrpc midWireFilteredList;
            midWireFilteredList = midWireFilterResponse.ListDsiMidWireComponentGrpc;
             int actualMidWireFilteredCount;
            actualMidWireFilteredCount = midWireFilteredList.DsiMidWireComponentGrpcs == null ? 0 : midWireFilteredList.DsiMidWireComponentGrpcs.Count;
             int expectedMidWireFilteredCount;
            expectedMidWireFilteredCount = 1;
            Assert.That(actualMidWireFilteredCount == expectedMidWireFilteredCount, Is.True);
             DsiMidWireComponentGrpc? firstMidWire;
            firstMidWire = midWireFilteredList.DsiMidWireComponentGrpcs?.FirstOrDefault();
            Assert.That(firstMidWire, Is.Not.Null);
             actualWireName = firstMidWire!.WireName;
            Assert.That(actualWireName == expectedWireName, Is.True);
             //   Fail case
            RfqFilterRequest midWireFailFilterRequest;
            midWireFailFilterRequest = new RfqFilterRequest();
            midWireFailFilterRequest.DatabaseList = "DSIMIDWIRECOMPONENTGRPC";
            midWireFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(midWireFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {midWireFailFilterRequest.DatabaseList}");
             ServerCallContext midWireFailFilterContext;
            midWireFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> midWireFailFilterTask;
            midWireFailFilterTask = _GrpcService.FilterRfqGrpc(midWireFailFilterRequest, midWireFailFilterContext);
             RfqFilterResponse midWireFailFilterResponse;
            midWireFailFilterResponse = await midWireFailFilterTask;
             ListDsiMidWireComponentGrpc midWireFailList;
            midWireFailList = midWireFailFilterResponse.ListDsiMidWireComponentGrpc;
             int actualMidWireFailCount;
            actualMidWireFailCount = midWireFailList.DsiMidWireComponentGrpcs == null ? 0 : midWireFailList.DsiMidWireComponentGrpcs.Count;
             int expectedMidWireFailCount;
            expectedMidWireFailCount = 0;
            Assert.That(actualMidWireFailCount == expectedMidWireFailCount, Is.True);
             // ========================================================= 

            // DSI MODULE COMPATIBILITY ()
            // ========================================================= 

            RfqFilterRequest moduleCompatFilterRequest;
            moduleCompatFilterRequest = new RfqFilterRequest();
            moduleCompatFilterRequest.DatabaseList = "DSIMODULECOMPATIBILITYGRPC";
            moduleCompatFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(moduleCompatFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {moduleCompatFilterRequest.DatabaseList}");
             ServerCallContext moduleCompatFilterContext;
            moduleCompatFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> moduleCompatFilterTask;
            moduleCompatFilterTask = _GrpcService.FilterRfqGrpc(moduleCompatFilterRequest, moduleCompatFilterContext);
             RfqFilterResponse moduleCompatFilterResponse;
            moduleCompatFilterResponse = await moduleCompatFilterTask;
             ListDsiModuleCompatibilityGrpc moduleCompatFilteredList;
            moduleCompatFilteredList = moduleCompatFilterResponse.ListDsiModuleCompatibilityGrpc;
             int actualModuleCompatFilteredCount;
            actualModuleCompatFilteredCount = moduleCompatFilteredList.DsiModuleCompatibilityGrpcs == null ? 0 : moduleCompatFilteredList.DsiModuleCompatibilityGrpcs.Count;
             int expectedModuleCompatFilteredCount;
            expectedModuleCompatFilteredCount = 1;
            Assert.That(actualModuleCompatFilteredCount == expectedModuleCompatFilteredCount, Is.True);
             DsiModuleCompatibilityGrpc? firstModuleCompat;
            firstModuleCompat = moduleCompatFilteredList.DsiModuleCompatibilityGrpcs?.FirstOrDefault();
            Assert.That(firstModuleCompat, Is.Not.Null);
             string actualRelationship;
            actualRelationship = firstModuleCompat!.Relationship;
             string expectedRelationship;
            expectedRelationship = "FixedRelationship";
            Assert.That(actualRelationship == expectedRelationship, Is.True);
             // ========================================================= 

            // DSI MULTICORE SPECIFICATION ()
            // ========================================================= 

            RfqFilterRequest multicoreFilterRequest;
            multicoreFilterRequest = new RfqFilterRequest();
            multicoreFilterRequest.DatabaseList = "DSIMULTICORESPECIFICATIONGRPC";
            multicoreFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(multicoreFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {multicoreFilterRequest.DatabaseList}");
             ServerCallContext multicoreFilterContext;
            multicoreFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> multicoreFilterTask;
            multicoreFilterTask = _GrpcService.FilterRfqGrpc(multicoreFilterRequest, multicoreFilterContext);
             RfqFilterResponse multicoreFilterResponse;
            multicoreFilterResponse = await multicoreFilterTask;
             ListDsiMulticoreSpecificationGrpc multicoreFilteredList;
            multicoreFilteredList = multicoreFilterResponse.ListDsiMulticoreSpecificationGrpc;
             int actualMulticoreFilteredCount;
            actualMulticoreFilteredCount = multicoreFilteredList.DsiMulticoreSpecificationGrpcs == null ? 0 : multicoreFilteredList.DsiMulticoreSpecificationGrpcs.Count;
             int expectedMulticoreFilteredCount;
            expectedMulticoreFilteredCount = 1;
            Assert.That(actualMulticoreFilteredCount == expectedMulticoreFilteredCount, Is.True);
             DsiMulticoreSpecificationGrpc? firstMulticore;
            firstMulticore = multicoreFilteredList.DsiMulticoreSpecificationGrpcs?.FirstOrDefault();
            Assert.That(firstMulticore, Is.Not.Null);
             string actualMulticoreName;
            actualMulticoreName = firstMulticore!.MulticoreName;
             string expectedMulticoreName;
            expectedMulticoreName = "FixedMulticore";
            Assert.That(actualMulticoreName == expectedMulticoreName, Is.True);
             // ========================================================= 

            // DSI PIN MAPPING ()
            // ========================================================= 

            RfqFilterRequest pinMappingFilterRequest;
            pinMappingFilterRequest = new RfqFilterRequest();
            pinMappingFilterRequest.DatabaseList = "DSIPINMAPPINGGRPC";
            pinMappingFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(pinMappingFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {pinMappingFilterRequest.DatabaseList}");
             ServerCallContext pinMappingFilterContext;
            pinMappingFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> pinMappingFilterTask;
            pinMappingFilterTask = _GrpcService.FilterRfqGrpc(pinMappingFilterRequest, pinMappingFilterContext);
             RfqFilterResponse pinMappingFilterResponse;
            pinMappingFilterResponse = await pinMappingFilterTask;
             ListDsiPinMappingGrpc pinMappingFilteredList;
            pinMappingFilteredList = pinMappingFilterResponse.ListDsiPinMappingGrpc;
             int actualPinMappingFilteredCount;
            actualPinMappingFilteredCount = pinMappingFilteredList.DsiPinMappingGrpcs == null ? 0 : pinMappingFilteredList.DsiPinMappingGrpcs.Count;
             int expectedPinMappingFilteredCount;
            expectedPinMappingFilteredCount = 1;
            Assert.That(actualPinMappingFilteredCount == expectedPinMappingFilteredCount, Is.True);
             DsiPinMappingGrpc? firstPinMapping;
            firstPinMapping = pinMappingFilteredList.DsiPinMappingGrpcs?.FirstOrDefault();
            Assert.That(firstPinMapping, Is.Not.Null);
             string actualNode1;
            actualNode1 = firstPinMapping!.Node1;
             string expectedNode1;
            expectedNode1 = "FixedNodeA";
            Assert.That(actualNode1 == expectedNode1, Is.True);
             // ========================================================= 

            // DSI PIN MAPPING — CAVITY MAPPING ASSOCIATION ()
            // ========================================================= 

            RfqFilterRequest pinMapAssocFilterRequest;
            pinMapAssocFilterRequest = new RfqFilterRequest();
            pinMapAssocFilterRequest.DatabaseList = "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC";
            pinMapAssocFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(pinMapAssocFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {pinMapAssocFilterRequest.DatabaseList}");
             ServerCallContext pinMapAssocFilterContext;
            pinMapAssocFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> pinMapAssocFilterTask;
            pinMapAssocFilterTask = _GrpcService.FilterRfqGrpc(pinMapAssocFilterRequest, pinMapAssocFilterContext);
             RfqFilterResponse pinMapAssocFilterResponse;
            pinMapAssocFilterResponse = await pinMapAssocFilterTask;
             ListDsiPinMappingCavityMappingAssociationGrpc pinMapAssocFilteredList;
            pinMapAssocFilteredList = pinMapAssocFilterResponse.ListDsiPinMappingCavityMappingAssociationGrpc;
             int actualPinMapAssocFilteredCount;
            actualPinMapAssocFilteredCount = pinMapAssocFilteredList.DsiPinMappingCavityMappingAssociationGrpcs == null ? 0 : pinMapAssocFilteredList.DsiPinMappingCavityMappingAssociationGrpcs.Count;
             int expectedPinMapAssocFilteredCount;
            expectedPinMapAssocFilteredCount = 1;
            Assert.That(actualPinMapAssocFilteredCount == expectedPinMapAssocFilteredCount, Is.True);
             DsiPinMappingCavityMappingAssociationGrpc? firstPinMapAssoc;
            firstPinMapAssoc = pinMapAssocFilteredList.DsiPinMappingCavityMappingAssociationGrpcs?.FirstOrDefault();
            Assert.That(firstPinMapAssoc, Is.Not.Null);
             int actualMappingNumber;
            actualMappingNumber = firstPinMapAssoc!.MappingNumber;
             int expectedMappingNumber;
            expectedMappingNumber = 999;
            Assert.That(actualMappingNumber == expectedMappingNumber, Is.True);
             //   Fail case
            RfqFilterRequest pinMapAssocFailFilterRequest;
            pinMapAssocFailFilterRequest = new RfqFilterRequest();
            pinMapAssocFailFilterRequest.DatabaseList = "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC";
            pinMapAssocFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(pinMapAssocFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {pinMapAssocFailFilterRequest.DatabaseList}");
             ServerCallContext pinMapAssocFailFilterContext;
            pinMapAssocFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> pinMapAssocFailFilterTask;
            pinMapAssocFailFilterTask = _GrpcService.FilterRfqGrpc(pinMapAssocFailFilterRequest, pinMapAssocFailFilterContext);
             RfqFilterResponse pinMapAssocFailFilterResponse;
            pinMapAssocFailFilterResponse = await pinMapAssocFailFilterTask;
             ListDsiPinMappingCavityMappingAssociationGrpc pinMapAssocFailList;
            pinMapAssocFailList = pinMapAssocFailFilterResponse.ListDsiPinMappingCavityMappingAssociationGrpc;
             int actualPinMapAssocFailCount;
            actualPinMapAssocFailCount = pinMapAssocFailList.DsiPinMappingCavityMappingAssociationGrpcs == null ? 0 : pinMapAssocFailList.DsiPinMappingCavityMappingAssociationGrpcs.Count;
             int expectedPinMapAssocFailCount;
            expectedPinMapAssocFailCount = 0;
            Assert.That(actualPinMapAssocFailCount == expectedPinMapAssocFailCount, Is.True);
             // ========================================================= 

            // DSI SCOPE ()
            // ========================================================= 

            RfqFilterRequest scopeFilterRequest;
            scopeFilterRequest = new RfqFilterRequest();
            scopeFilterRequest.DatabaseList = "DSISCOPEGRPC";
            scopeFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(scopeFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {scopeFilterRequest.DatabaseList}");
             ServerCallContext scopeFilterContext;
            scopeFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> scopeFilterTask;
            scopeFilterTask = _GrpcService.FilterRfqGrpc(scopeFilterRequest, scopeFilterContext);
             RfqFilterResponse scopeFilterResponse;
            scopeFilterResponse = await scopeFilterTask;
             ListDsiScopeGrpc scopeFilteredList;
            scopeFilteredList = scopeFilterResponse.ListDsiScopeGrpc;
             int actualScopeFilteredCount;
            actualScopeFilteredCount = scopeFilteredList.DsiScopeGrpcs == null ? 0 : scopeFilteredList.DsiScopeGrpcs.Count;
             int expectedScopeFilteredCount;
            expectedScopeFilteredCount = 1;
            Assert.That(actualScopeFilteredCount == expectedScopeFilteredCount, Is.True);
             DsiScopeGrpc? firstScope;
            firstScope = scopeFilteredList.DsiScopeGrpcs?.FirstOrDefault();
            Assert.That(firstScope, Is.Not.Null);
             string actualScopeName;
            actualScopeName = firstScope!.Scope;
             string expectedScopeName;
            expectedScopeName = "FixedScope";
            Assert.That(actualScopeName == expectedScopeName, Is.True);
             //   Fail case
            RfqFilterRequest scopeFailFilterRequest;
            scopeFailFilterRequest = new RfqFilterRequest();
            scopeFailFilterRequest.DatabaseList = "DSISCOPEGRPC";
            scopeFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(scopeFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {scopeFailFilterRequest.DatabaseList}");
             ServerCallContext scopeFailFilterContext;
            scopeFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> scopeFailFilterTask;
            scopeFailFilterTask = _GrpcService.FilterRfqGrpc(scopeFailFilterRequest, scopeFailFilterContext);
             RfqFilterResponse scopeFailFilterResponse;
            scopeFailFilterResponse = await scopeFailFilterTask;
             ListDsiScopeGrpc scopeFailList;
            scopeFailList = scopeFailFilterResponse.ListDsiScopeGrpc;
             int actualScopeFailCount;
            actualScopeFailCount = scopeFailList.DsiScopeGrpcs == null ? 0 : scopeFailList.DsiScopeGrpcs.Count;
             int expectedScopeFailCount;
            expectedScopeFailCount = 0;
            Assert.That(actualScopeFailCount == expectedScopeFailCount, Is.True);
             // ========================================================= 

            // DSI SUPPLIER ()
            // ========================================================= 

            RfqFilterRequest supplierFilterRequest;
            supplierFilterRequest = new RfqFilterRequest();
            supplierFilterRequest.DatabaseList = "DSISUPPLIERGRPC";
            supplierFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(supplierFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {supplierFilterRequest.DatabaseList}");
             ServerCallContext supplierFilterContext;
            supplierFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> supplierFilterTask;
            supplierFilterTask = _GrpcService.FilterRfqGrpc(supplierFilterRequest, supplierFilterContext);
             RfqFilterResponse supplierFilterResponse;
            supplierFilterResponse = await supplierFilterTask;
             ListDsiSupplierGrpc supplierFilteredList;
            supplierFilteredList = supplierFilterResponse.ListDsiSupplierGrpc;
             int actualSupplierFilteredCount;
            actualSupplierFilteredCount = supplierFilteredList.DsiSupplierGrpcs == null ? 0 : supplierFilteredList.DsiSupplierGrpcs.Count;
             int expectedSupplierFilteredCount;
            expectedSupplierFilteredCount = 1;
            Assert.That(actualSupplierFilteredCount == expectedSupplierFilteredCount, Is.True);
             DsiSupplierGrpc? firstSupplier;
            firstSupplier = supplierFilteredList.DsiSupplierGrpcs?.FirstOrDefault();
            Assert.That(firstSupplier, Is.Not.Null);
             string actualSupplierName;
            actualSupplierName = firstSupplier!.Name;
             string expectedSupplierName;
            expectedSupplierName = "FixedSupplier";
            Assert.That(actualSupplierName == expectedSupplierName, Is.True);
             //   Fail case
            RfqFilterRequest supplierFailFilterRequest;
            supplierFailFilterRequest = new RfqFilterRequest();
            supplierFailFilterRequest.DatabaseList = "DSISUPPLIERGRPC";
            supplierFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(supplierFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {supplierFailFilterRequest.DatabaseList}");
             ServerCallContext supplierFailFilterContext;
            supplierFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> supplierFailFilterTask;
            supplierFailFilterTask = _GrpcService.FilterRfqGrpc(supplierFailFilterRequest, supplierFailFilterContext);
             RfqFilterResponse supplierFailFilterResponse;
            supplierFailFilterResponse = await supplierFailFilterTask;
             ListDsiSupplierGrpc supplierFailList;
            supplierFailList = supplierFailFilterResponse.ListDsiSupplierGrpc;
             int actualSupplierFailCount;
            actualSupplierFailCount = supplierFailList.DsiSupplierGrpcs == null ? 0 : supplierFailList.DsiSupplierGrpcs.Count;
             int expectedSupplierFailCount;
            expectedSupplierFailCount = 0;
            Assert.That(actualSupplierFailCount == expectedSupplierFailCount, Is.True);
             // ========================================================= 

            // DSI TRANSFORMED COMPOSITE DETAIL ()
            // ========================================================= 

            RfqFilterRequest transformedDetailFilterRequest;
            transformedDetailFilterRequest = new RfqFilterRequest();
            transformedDetailFilterRequest.DatabaseList = "DSITRANSFORMEDCOMPOSITEDETAILGRPC";
            transformedDetailFilterRequest.FilterExpression = "RowId == 2";
             Assert.That(!string.IsNullOrWhiteSpace(transformedDetailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {transformedDetailFilterRequest.DatabaseList}");
             ServerCallContext transformedDetailFilterContext;
            transformedDetailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> transformedDetailFilterTask;
            transformedDetailFilterTask = _GrpcService.FilterRfqGrpc(transformedDetailFilterRequest, transformedDetailFilterContext);
             RfqFilterResponse transformedDetailFilterResponse;
            transformedDetailFilterResponse = await transformedDetailFilterTask;
             ListDsiTransformedCompositeDetailGrpc transformedDetailFilteredList;
            transformedDetailFilteredList = transformedDetailFilterResponse.ListDsiTransformedCompositeDetailGrpc;
             int actualTransformedDetailFilteredCount;
            actualTransformedDetailFilteredCount = transformedDetailFilteredList.DsiTransformedCompositeDetailGrpcs == null ? 0 : transformedDetailFilteredList.DsiTransformedCompositeDetailGrpcs.Count;
             int expectedTransformedDetailFilteredCount;
            expectedTransformedDetailFilteredCount = 1;
            Assert.That(actualTransformedDetailFilteredCount == expectedTransformedDetailFilteredCount, Is.True);
             DsiTransformedCompositeDetailGrpc? firstTransformedDetail;
            firstTransformedDetail = transformedDetailFilteredList.DsiTransformedCompositeDetailGrpcs?.FirstOrDefault();
            Assert.That(firstTransformedDetail, Is.Not.Null);
             actualHarnessName = firstTransformedDetail!.HarnessName1;
            string expectedHarnessNameA2;
            expectedHarnessNameA2 = "HarnessA2";
            Assert.That(actualHarnessName == expectedHarnessNameA2, Is.True);
             // ========================================================= 

            // DSI TRANSFORMED HARNESS ()
            // ========================================================= 

            RfqFilterRequest transformedHarnessFilterRequest;
            transformedHarnessFilterRequest = new RfqFilterRequest();
            transformedHarnessFilterRequest.DatabaseList = "DSITRANSFORMEDHARNESSGRPC";
            transformedHarnessFilterRequest.FilterExpression = "RowId == 2";
             Assert.That(!string.IsNullOrWhiteSpace(transformedHarnessFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {transformedHarnessFilterRequest.DatabaseList}");
             ServerCallContext transformedHarnessFilterContext;
            transformedHarnessFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> transformedHarnessFilterTask;
            transformedHarnessFilterTask = _GrpcService.FilterRfqGrpc(transformedHarnessFilterRequest, transformedHarnessFilterContext);
             RfqFilterResponse transformedHarnessFilterResponse;
            transformedHarnessFilterResponse = await transformedHarnessFilterTask;
             ListDsiTransformedHarnessGrpc transformedHarnessFilteredList;
            transformedHarnessFilteredList = transformedHarnessFilterResponse.ListDsiTransformedHarnessGrpc;
             int actualTransformedHarnessFilteredCount;
            actualTransformedHarnessFilteredCount = transformedHarnessFilteredList.DsiTransformedHarnessGrpcs == null ? 0 : transformedHarnessFilteredList.DsiTransformedHarnessGrpcs.Count;
             int expectedTransformedHarnessFilteredCount;
            expectedTransformedHarnessFilteredCount = 1;
            Assert.That(actualTransformedHarnessFilteredCount == expectedTransformedHarnessFilteredCount, Is.True);
             DsiTransformedHarnessGrpc? firstTransformedHarness;
            firstTransformedHarness = transformedHarnessFilteredList.DsiTransformedHarnessGrpcs?.FirstOrDefault();
            Assert.That(firstTransformedHarness, Is.Not.Null);
             actualHarnessName = firstTransformedHarness!.HarnessName1;
            Assert.That(actualHarnessName == expectedHarnessNameA2, Is.True);
             // ========================================================= 

            // DSI TRANSFORMED MODULE CHILD DETAIL ()
            // ========================================================= 

            RfqFilterRequest transformedModuleChildFilterRequest;
            transformedModuleChildFilterRequest = new RfqFilterRequest();
            transformedModuleChildFilterRequest.DatabaseList = "DSITRANSFORMEDMODULECHILDDETAILGRPC";
            transformedModuleChildFilterRequest.FilterExpression = "RowId == 2";
             Assert.That(!string.IsNullOrWhiteSpace(transformedModuleChildFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {transformedModuleChildFilterRequest.DatabaseList}");
             ServerCallContext transformedModuleChildFilterContext;
            transformedModuleChildFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> transformedModuleChildFilterTask;
            transformedModuleChildFilterTask = _GrpcService.FilterRfqGrpc(transformedModuleChildFilterRequest, transformedModuleChildFilterContext);
             RfqFilterResponse transformedModuleChildFilterResponse;
            transformedModuleChildFilterResponse = await transformedModuleChildFilterTask;
             ListDsiTransformedModuleChildDetailGrpc transformedModuleChildFilteredList;
            transformedModuleChildFilteredList = transformedModuleChildFilterResponse.ListDsiTransformedModuleChildDetailGrpc;
             int actualTransformedModuleChildFilteredCount;
            actualTransformedModuleChildFilteredCount = transformedModuleChildFilteredList.DsiTransformedModuleChildDetailGrpcs == null ? 0 : transformedModuleChildFilteredList.DsiTransformedModuleChildDetailGrpcs.Count;
             int expectedTransformedModuleChildFilteredCount;
            expectedTransformedModuleChildFilteredCount = 1;
            Assert.That(actualTransformedModuleChildFilteredCount == expectedTransformedModuleChildFilteredCount, Is.True);
             DsiTransformedModuleChildDetailGrpc? firstTransformedModuleChild;
            firstTransformedModuleChild = transformedModuleChildFilteredList.DsiTransformedModuleChildDetailGrpcs?.FirstOrDefault();
            Assert.That(firstTransformedModuleChild, Is.Not.Null);
             actualModuleCode = firstTransformedModuleChild!.ModuleCode;
            string expectedModuleCode2;
            expectedModuleCode2 = "Module2";
            Assert.That(actualModuleCode == expectedModuleCode2, Is.True);
             // ========================================================= 

            // DSI UNIT OF MEASURE ()
            // ========================================================= 

            RfqFilterRequest unitFilterRequest;
            unitFilterRequest = new RfqFilterRequest();
            unitFilterRequest.DatabaseList = "DSIUNITOFMEASUREGRPC";
            unitFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(unitFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {unitFilterRequest.DatabaseList}");
             ServerCallContext unitFilterContext;
            unitFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> unitFilterTask;
            unitFilterTask = _GrpcService.FilterRfqGrpc(unitFilterRequest, unitFilterContext);
             RfqFilterResponse unitFilterResponse;
            unitFilterResponse = await unitFilterTask;
             ListDsiUnitOfMeasureGrpc unitFilteredList;
            unitFilteredList = unitFilterResponse.ListDsiUnitOfMeasureGrpc;
             int actualUnitFilteredCount;
            actualUnitFilteredCount = unitFilteredList.DsiUnitOfMeasureGrpcs == null ? 0 : unitFilteredList.DsiUnitOfMeasureGrpcs.Count;
             int expectedUnitFilteredCount;
            expectedUnitFilteredCount = 1;
            Assert.That(actualUnitFilteredCount == expectedUnitFilteredCount, Is.True);
             DsiUnitOfMeasureGrpc? firstUnit;
            firstUnit = unitFilteredList.DsiUnitOfMeasureGrpcs?.FirstOrDefault();
            Assert.That(firstUnit, Is.Not.Null);
             string actualAbbreviation;
            actualAbbreviation = firstUnit!.Abbreviation;
             string expectedAbbreviation;
            expectedAbbreviation = "FIX";
            Assert.That(actualAbbreviation == expectedAbbreviation, Is.True);
             //   Fail case
            RfqFilterRequest unitFailFilterRequest;
            unitFailFilterRequest = new RfqFilterRequest();
            unitFailFilterRequest.DatabaseList = "DSIUNITOFMEASUREGRPC";
            unitFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(unitFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {unitFailFilterRequest.DatabaseList}");
             ServerCallContext unitFailFilterContext;
            unitFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> unitFailFilterTask;
            unitFailFilterTask = _GrpcService.FilterRfqGrpc(unitFailFilterRequest, unitFailFilterContext);
             RfqFilterResponse unitFailFilterResponse;
            unitFailFilterResponse = await unitFailFilterTask;
             ListDsiUnitOfMeasureGrpc unitFailList;
            unitFailList = unitFailFilterResponse.ListDsiUnitOfMeasureGrpc;
             int actualUnitFailCount;
            actualUnitFailCount = unitFailList.DsiUnitOfMeasureGrpcs == null ? 0 : unitFailList.DsiUnitOfMeasureGrpcs.Count;
             int expectedUnitFailCount;
            expectedUnitFailCount = 0;
            Assert.That(actualUnitFailCount == expectedUnitFailCount, Is.True);
             // ========================================================= 

            // DSI WIRE MULTICORE MARKER ()
            // ========================================================= 

            RfqFilterRequest wireMarkerFilterRequest;
            wireMarkerFilterRequest = new RfqFilterRequest();
            wireMarkerFilterRequest.DatabaseList = "DSIWIREMULTICOREMARKERGRPC";
            wireMarkerFilterRequest.FilterExpression = "RowId == 6";
             Assert.That(!string.IsNullOrWhiteSpace(wireMarkerFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {wireMarkerFilterRequest.DatabaseList}");
             ServerCallContext wireMarkerFilterContext;
            wireMarkerFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> wireMarkerFilterTask;
            wireMarkerFilterTask = _GrpcService.FilterRfqGrpc(wireMarkerFilterRequest, wireMarkerFilterContext);
             RfqFilterResponse wireMarkerFilterResponse;
            wireMarkerFilterResponse = await wireMarkerFilterTask;
             ListDsiWireMulticoreMarkerGrpc wireMarkerFilteredList;
            wireMarkerFilteredList = wireMarkerFilterResponse.ListDsiWireMulticoreMarkerGrpc;
             int actualWireMarkerFilteredCount;
            actualWireMarkerFilteredCount = wireMarkerFilteredList.DsiWireMulticoreMarkerGrpcs == null ? 0 : wireMarkerFilteredList.DsiWireMulticoreMarkerGrpcs.Count;
             int expectedWireMarkerFilteredCount;
            expectedWireMarkerFilteredCount = 1;
            Assert.That(actualWireMarkerFilteredCount == expectedWireMarkerFilteredCount, Is.True);
             DsiWireMulticoreMarkerGrpc? firstWireMarker;
            firstWireMarker = wireMarkerFilteredList.DsiWireMulticoreMarkerGrpcs?.FirstOrDefault();
            Assert.That(firstWireMarker, Is.Not.Null);
             string actualItemName;
            actualItemName = firstWireMarker!.ItemName;
             string expectedItemName;
            expectedItemName = "FixedItem";
            Assert.That(actualItemName == expectedItemName, Is.True);
             //   Fail case
            RfqFilterRequest wireMarkerFailFilterRequest;
            wireMarkerFailFilterRequest = new RfqFilterRequest();
            wireMarkerFailFilterRequest.DatabaseList = "DSIWIREMULTICOREMARKERGRPC";
            wireMarkerFailFilterRequest.FilterExpression = $"RowId == {int.MaxValue}";
             Assert.That(!string.IsNullOrWhiteSpace(wireMarkerFailFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {wireMarkerFailFilterRequest.DatabaseList}");
             ServerCallContext wireMarkerFailFilterContext;
            wireMarkerFailFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> wireMarkerFailFilterTask;
            wireMarkerFailFilterTask = _GrpcService.FilterRfqGrpc(wireMarkerFailFilterRequest, wireMarkerFailFilterContext);
             RfqFilterResponse wireMarkerFailFilterResponse;
            wireMarkerFailFilterResponse = await wireMarkerFailFilterTask;
             ListDsiWireMulticoreMarkerGrpc wireMarkerFailList;
            wireMarkerFailList = wireMarkerFailFilterResponse.ListDsiWireMulticoreMarkerGrpc;
             int actualWireMarkerFailCount;
            actualWireMarkerFailCount = wireMarkerFailList.DsiWireMulticoreMarkerGrpcs == null ? 0 : wireMarkerFailList.DsiWireMulticoreMarkerGrpcs.Count;
             int expectedWireMarkerFailCount;
            expectedWireMarkerFailCount = 0;
            Assert.That(actualWireMarkerFailCount == expectedWireMarkerFailCount, Is.True);
             // ========================================================= 

            // DSI WIRE SPECIFICATION ()
            // ========================================================= 

            RfqFilterRequest wireSpecFilterRequest;
            wireSpecFilterRequest = new RfqFilterRequest();
            wireSpecFilterRequest.DatabaseList = "DSIWIRESPECIFICATIONGRPC";
            wireSpecFilterRequest.FilterExpression = "RowId == 2";
             Assert.That(!string.IsNullOrWhiteSpace(wireSpecFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {wireSpecFilterRequest.DatabaseList}");
             ServerCallContext wireSpecFilterContext;
            wireSpecFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> wireSpecFilterTask;
            wireSpecFilterTask = _GrpcService.FilterRfqGrpc(wireSpecFilterRequest, wireSpecFilterContext);
             RfqFilterResponse wireSpecFilterResponse;
            wireSpecFilterResponse = await wireSpecFilterTask;
             ListDsiWireSpecificationGrpc wireSpecFilteredList;
            wireSpecFilteredList = wireSpecFilterResponse.ListDsiWireSpecificationGrpc;
             int actualWireSpecFilteredCount;
            actualWireSpecFilteredCount = wireSpecFilteredList.DsiWireSpecificationGrpcs == null ? 0 : wireSpecFilteredList.DsiWireSpecificationGrpcs.Count;
             int expectedWireSpecFilteredCount;
            expectedWireSpecFilteredCount = 1;
            Assert.That(actualWireSpecFilteredCount == expectedWireSpecFilteredCount, Is.True);
             DsiWireSpecificationGrpc? firstWireSpec;
            firstWireSpec = wireSpecFilteredList.DsiWireSpecificationGrpcs?.FirstOrDefault();
            Assert.That(firstWireSpec, Is.Not.Null);
             actualWireName = firstWireSpec!.WireName;
            string expectedWireName2;
            expectedWireName2 = "Wire2";
            Assert.That(actualWireName == expectedWireName2, Is.True);
             // ========================================================= 

            // DSI WIRE THROUGH NODE ()
            // ========================================================= 

            RfqFilterRequest wireThroughNodeFilterRequest;
            wireThroughNodeFilterRequest = new RfqFilterRequest();
            wireThroughNodeFilterRequest.DatabaseList = "DSIWIRETHROUGHNODEGRPC";
            wireThroughNodeFilterRequest.FilterExpression = "RowId == 2";
             Assert.That(!string.IsNullOrWhiteSpace(wireThroughNodeFilterRequest.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {wireThroughNodeFilterRequest.DatabaseList}");
             ServerCallContext wireThroughNodeFilterContext;
            wireThroughNodeFilterContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));
             Task<RfqFilterResponse> wireThroughNodeFilterTask;
            wireThroughNodeFilterTask = _GrpcService.FilterRfqGrpc(wireThroughNodeFilterRequest, wireThroughNodeFilterContext);
             RfqFilterResponse wireThroughNodeFilterResponse;
            wireThroughNodeFilterResponse = await wireThroughNodeFilterTask;
             ListDsiWireThroughNodeGrpc wireThroughNodeFilteredList;
            wireThroughNodeFilteredList = wireThroughNodeFilterResponse.ListDsiWireThroughNodeGrpc;
             int actualWireThroughNodeFilteredCount;
            actualWireThroughNodeFilteredCount = wireThroughNodeFilteredList.DsiWireThroughNodeGrpcs == null ? 0 : wireThroughNodeFilteredList.DsiWireThroughNodeGrpcs.Count;
             int expectedWireThroughNodeFilteredCount;
            expectedWireThroughNodeFilteredCount = 1;
            Assert.That(actualWireThroughNodeFilteredCount == expectedWireThroughNodeFilteredCount, Is.True);
             DsiWireThroughNodeGrpc? firstWireThroughNode;
            firstWireThroughNode = wireThroughNodeFilteredList.DsiWireThroughNodeGrpcs?.FirstOrDefault();
            Assert.That(firstWireThroughNode, Is.Not.Null);
             actualWireName = firstWireThroughNode!.WireName;
            Assert.That(actualWireName == expectedWireName2, Is.True);
        }
         ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline;
            deadline = DateTime.Now.AddMinutes(30);
             Metadata metadata;
            metadata = new Metadata();
             ServerCallContext serverCallContext;
            serverCallContext = TestServerCallContext.Create(
                                    method: methodName,
                                    host: "localhost",
                                    deadline: deadline,
                                    requestHeaders: metadata,
                                    cancellationToken: CancellationToken.None,
                                    peer: "10.0.0.25:5001",
                                    authContext: null,
                                    contextPropagationToken: null,
                                    writeHeadersFunc: (headers) => Task.CompletedTask,
                                    writeOptionsGetter: () => new WriteOptions(),
                                    writeOptionsSetter: (writeOptions) => { }
                                );
             return serverCallContext;
        }
    }
}

using Rfq;                           
using Rfq.Endpoints.GrpcServices;        
using Rfq.Services;                   

namespace Integration.Tests.Rfq
{
    public class RfqIntegrationTests
    {
        RfqAccessService _RfqAccessService;
        RfqGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            _RfqAccessService = new RfqAccessService(provider, testing: true);

            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<RfqGrpcService> logger = _LoggerFactory.CreateLogger<RfqGrpcService>();

            _GrpcService = new RfqGrpcService(_RfqAccessService, logger);
        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
        }

        // ---------------------------------------------------------------------
        // Hello 
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            // Arrange
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.SayHello));

            // Act
            Task<HelloReply> helloReply = _GrpcService.SayHello(request, context);

            // Assert
            Assert.That(helloReply, Is.Not.Null);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // RFQ: Drawing Part Numbers
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_RfqDrawingPartNumbers_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "RfqDrawingPartNumbersGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListRfqDrawingPartNumbersGrpc successListContainer = successResp.ListRfqDrawingPartNumbersGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<RfqDrawingPartNumbersGrpc> successItems = successListContainer.RfqDrawingPartNumbers;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "RfqDrawingPartNumbersGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListRfqDrawingPartNumbersGrpc failListContainer = failResp.ListRfqDrawingPartNumbersGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<RfqDrawingPartNumbersGrpc> failItems = failListContainer.RfqDrawingPartNumbers;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // RFQ: Reasons
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_RfqReasons_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "RfqReasonGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListRfqReasonGrpc successListContainer = successResp.ListRfqReasonGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<RfqReasonGrpc> successItems = successListContainer.RfqReasons;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "RfqReasonGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListRfqReasonGrpc failListContainer = failResp.ListRfqReasonGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<RfqReasonGrpc> failItems = failListContainer.RfqReasons;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // RFQ: Notes
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_RfqNotes_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "RfqNotesGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListRfqNotesGrpc successListContainer = successResp.ListRfqNotesGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<RfqNotesGrpc> successItems = successListContainer.RfqNotes;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "RfqNotesGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListRfqNotesGrpc failListContainer = failResp.ListRfqNotesGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<RfqNotesGrpc> failItems = failListContainer.RfqNotes;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // RFQ: Projects
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_RfqProjects_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "RfqProjectGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListRfqProjectGrpc successListContainer = successResp.ListRfqProjectGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<RfqProjectGrpc> successItems = successListContainer.RfqProjects;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "RfqProjectGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListRfqProjectGrpc failListContainer = failResp.ListRfqProjectGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<RfqProjectGrpc> failItems = failListContainer.RfqProjects;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSI: Bend
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiBend_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DsiBendGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiBendGrpc successListContainer = successResp.ListDsiBendGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiBendGrpc> successItems = successListContainer.DsiBends;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DsiBendGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiBendGrpc failListContainer = failResp.ListDsiBendGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiBendGrpc> failItems = failListContainer.DsiBends;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSI: Supplier
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiSupplier_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DsiSupplierGrpc";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiSupplierGrpc successListContainer = successResp.ListDsiSupplierGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiSupplierGrpc> successItems = successListContainer.DsiSupplierGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DsiSupplierGrpc";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiSupplierGrpc failListContainer = failResp.ListDsiSupplierGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiSupplierGrpc> failItems = failListContainer.DsiSupplierGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSITRANSFORMEDCOMPOSITEDETAILGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiTransformedCompositeDetail_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSITRANSFORMEDCOMPOSITEDETAILGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiTransformedCompositeDetailGrpc successListContainer = successResp.ListDsiTransformedCompositeDetailGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedCompositeDetailGrpc> successItems = successListContainer.DsiTransformedCompositeDetailGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSITRANSFORMEDCOMPOSITEDETAILGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiTransformedCompositeDetailGrpc failListContainer = failResp.ListDsiTransformedCompositeDetailGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedCompositeDetailGrpc> failItems = failListContainer.DsiTransformedCompositeDetailGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSITRANSFORMEDHARNESSGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiTransformedHarness_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSITRANSFORMEDHARNESSGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiTransformedHarnessGrpc successListContainer = successResp.ListDsiTransformedHarnessGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedHarnessGrpc> successItems = successListContainer.DsiTransformedHarnessGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSITRANSFORMEDHARNESSGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiTransformedHarnessGrpc failListContainer = failResp.ListDsiTransformedHarnessGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedHarnessGrpc> failItems = failListContainer.DsiTransformedHarnessGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // DSITRANSFORMEDMODULECHILDDETAILGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiTransformedModuleChildDetail_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSITRANSFORMEDMODULECHILDDETAILGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiTransformedModuleChildDetailGrpc successListContainer = successResp.ListDsiTransformedModuleChildDetailGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedModuleChildDetailGrpc> successItems = successListContainer.DsiTransformedModuleChildDetailGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSITRANSFORMEDMODULECHILDDETAILGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiTransformedModuleChildDetailGrpc failListContainer = failResp.ListDsiTransformedModuleChildDetailGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiTransformedModuleChildDetailGrpc> failItems = failListContainer.DsiTransformedModuleChildDetailGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIUNITOFMEASUREGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiUnitOfMeasure_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIUNITOFMEASUREGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiUnitOfMeasureGrpc successListContainer = successResp.ListDsiUnitOfMeasureGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiUnitOfMeasureGrpc> successItems = successListContainer.DsiUnitOfMeasureGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIUNITOFMEASUREGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiUnitOfMeasureGrpc failListContainer = failResp.ListDsiUnitOfMeasureGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiUnitOfMeasureGrpc> failItems = failListContainer.DsiUnitOfMeasureGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSIWIREMULTICOREMARKERGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiWireMulticoreMarker_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIWIREMULTICOREMARKERGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiWireMulticoreMarkerGrpc successListContainer = successResp.ListDsiWireMulticoreMarkerGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiWireMulticoreMarkerGrpc> successItems = successListContainer.DsiWireMulticoreMarkerGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIWIREMULTICOREMARKERGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiWireMulticoreMarkerGrpc failListContainer = failResp.ListDsiWireMulticoreMarkerGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiWireMulticoreMarkerGrpc> failItems = failListContainer.DsiWireMulticoreMarkerGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIWIRESPECIFICATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiWireSpecification_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIWIRESPECIFICATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiWireSpecificationGrpc successListContainer = successResp.ListDsiWireSpecificationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiWireSpecificationGrpc> successItems = successListContainer.DsiWireSpecificationGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIWIRESPECIFICATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiWireSpecificationGrpc failListContainer = failResp.ListDsiWireSpecificationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiWireSpecificationGrpc> failItems = failListContainer.DsiWireSpecificationGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIWIRETHROUGHNODEGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiWireThroughNode_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIWIRETHROUGHNODEGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiWireThroughNodeGrpc successListContainer = successResp.ListDsiWireThroughNodeGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiWireThroughNodeGrpc> successItems = successListContainer.DsiWireThroughNodeGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIWIRETHROUGHNODEGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiWireThroughNodeGrpc failListContainer = failResp.ListDsiWireThroughNodeGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiWireThroughNodeGrpc> failItems = failListContainer.DsiWireThroughNodeGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSIBRANCHCONFIGURATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiBranchConfiguration_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIBRANCHCONFIGURATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiBranchConfigurationGrpc successListContainer = successResp.ListDsiBranchConfigurationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiBranchConfigurationGrpc> successItems = successListContainer.DsiBranchConfigurations;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIBRANCHCONFIGURATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiBranchConfigurationGrpc failListContainer = failResp.ListDsiBranchConfigurationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiBranchConfigurationGrpc> failItems = failListContainer.DsiBranchConfigurations;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiBranchConfigurationBendAssociation_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiBranchConfigurationBendAssociationGrpc successListContainer = successResp.ListDsiBranchConfigurationBendAssociationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiBranchConfigurationBendAssociationGrpc> successItems = successListContainer.DsiBranchConfigurationBendAssociations;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiBranchConfigurationBendAssociationGrpc failListContainer = failResp.ListDsiBranchConfigurationBendAssociationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiBranchConfigurationBendAssociationGrpc> failItems = failListContainer.DsiBranchConfigurationBendAssociations;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSIBRANCHINSULATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiBranchInsulation_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIBRANCHINSULATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiBranchInsulationGrpc successListContainer = successResp.ListDsiBranchInsulationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiBranchInsulationGrpc> successItems = successListContainer.DsiBranchInsulations;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIBRANCHINSULATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiBranchInsulationGrpc failListContainer = failResp.ListDsiBranchInsulationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiBranchInsulationGrpc> failItems = failListContainer.DsiBranchInsulations;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIBRANCHINSULATIONTHROUGHNODEGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiBranchInsulationThroughNode_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIBRANCHINSULATIONTHROUGHNODEGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiBranchInsulationThroughNodeGrpc successListContainer = successResp.ListDsiBranchInsulationThroughNodeGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiBranchInsulationThroughNodeGrpc> successItems = successListContainer.DsiBranchInsulationThroughNodes;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIBRANCHINSULATIONTHROUGHNODEGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiBranchInsulationThroughNodeGrpc failListContainer = failResp.ListDsiBranchInsulationThroughNodeGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiBranchInsulationThroughNodeGrpc> failItems = failListContainer.DsiBranchInsulationThroughNodes;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSICENTRESTRIPGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCentreStrip_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICENTRESTRIPGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCentreStripGrpc successListContainer = successResp.ListDsiCentreStripGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCentreStripGrpc> successItems = successListContainer.DsiCentreStripGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICENTRESTRIPGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCentreStripGrpc failListContainer = failResp.ListDsiCentreStripGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCentreStripGrpc> failItems = failListContainer.DsiCentreStripGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSICIRCUITOPTIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCircuitOption_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICIRCUITOPTIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCircuitOptionGrpc successListContainer = successResp.ListDsiCircuitOptionGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCircuitOptionGrpc> successItems = successListContainer.DsiCircuitOptionGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICIRCUITOPTIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCircuitOptionGrpc failListContainer = failResp.ListDsiCircuitOptionGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCircuitOptionGrpc> failItems = failListContainer.DsiCircuitOptionGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSICOMPONENTGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiComponent_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICOMPONENTGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiComponentGrpc successListContainer = successResp.ListDsiComponentGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiComponentGrpc> successItems = successListContainer.DsiComponentGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICOMPONENTGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiComponentGrpc failListContainer = failResp.ListDsiComponentGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiComponentGrpc> failItems = failListContainer.DsiComponentGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSICOMPOSITEDETAILGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCompositeDetail_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICOMPOSITEDETAILGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCompositeDetailGrpc successListContainer = successResp.ListDsiCompositeDetailGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeDetailGrpc> successItems = successListContainer.DsiCompositeDetailGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICOMPOSITEDETAILGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCompositeDetailGrpc failListContainer = failResp.ListDsiCompositeDetailGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeDetailGrpc> failItems = failListContainer.DsiCompositeDetailGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCompositeDetailCircuitOptionAssociation_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCompositeDetailCircuitOptionAssociationGrpc successListContainer = successResp.ListDsiCompositeDetailCircuitOptionAssociationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeDetailCircuitOptionAssociationGrpc> successItems =
                successListContainer.DsiCompositeDetailCircuitOptionAssociationGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCompositeDetailCircuitOptionAssociationGrpc failListContainer = failResp.ListDsiCompositeDetailCircuitOptionAssociationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeDetailCircuitOptionAssociationGrpc> failItems =
                failListContainer.DsiCompositeDetailCircuitOptionAssociationGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSICOMPOSITEOPTIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCompositeOption_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICOMPOSITEOPTIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCompositeOptionGrpc successListContainer = successResp.ListDsiCompositeOptionGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeOptionGrpc> successItems = successListContainer.DsiCompositeOptionGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICOMPOSITEOPTIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCompositeOptionGrpc failListContainer = failResp.ListDsiCompositeOptionGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCompositeOptionGrpc> failItems = failListContainer.DsiCompositeOptionGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIHARNESSGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiHarness_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIHARNESSGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiHarnessGrpc successListContainer = successResp.ListDsiHarnessGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessGrpc> successItems = successListContainer.DsiHarnessGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIHARNESSGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiHarnessGrpc failListContainer = failResp.ListDsiHarnessGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessGrpc> failItems = failListContainer.DsiHarnessGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIHARNESSSCOPEGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiHarnessScope_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIHARNESSSCOPEGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiHarnessScopeGrpc successListContainer = successResp.ListDsiHarnessScopeGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessScopeGrpc> successItems = successListContainer.DsiHarnessScopeGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIHARNESSSCOPEGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiHarnessScopeGrpc failListContainer = failResp.ListDsiHarnessScopeGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessScopeGrpc> failItems = failListContainer.DsiHarnessScopeGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIHARNESSSCOPESCOPEASSOCIATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiHarnessScopeScopeAssociation_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIHARNESSSCOPESCOPEASSOCIATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiHarnessScopeScopeAssociationGrpc successListContainer = successResp.ListDsiHarnessScopeScopeAssociationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessScopeScopeAssociationGrpc> successItems = successListContainer.DsiHarnessScopeScopeAssociationGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIHARNESSSCOPESCOPEASSOCIATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiHarnessScopeScopeAssociationGrpc failListContainer = failResp.ListDsiHarnessScopeScopeAssociationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiHarnessScopeScopeAssociationGrpc> failItems = failListContainer.DsiHarnessScopeScopeAssociationGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIMANUALBOMQUANTITYGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiManualBomQuantity_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIMANUALBOMQUANTITYGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiManualBomQuantityGrpc successListContainer = successResp.ListDsiManualBomQuantityGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiManualBomQuantityGrpc> successItems = successListContainer.DsiManualBomQuantityGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIMANUALBOMQUANTITYGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiManualBomQuantityGrpc failListContainer = failResp.ListDsiManualBomQuantityGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiManualBomQuantityGrpc> failItems = failListContainer.DsiManualBomQuantityGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIMIDWIRECOMPONENTGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiMidWireComponent_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIMIDWIRECOMPONENTGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiMidWireComponentGrpc successListContainer = successResp.ListDsiMidWireComponentGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiMidWireComponentGrpc> successItems = successListContainer.DsiMidWireComponentGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIMIDWIRECOMPONENTGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiMidWireComponentGrpc failListContainer = failResp.ListDsiMidWireComponentGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiMidWireComponentGrpc> failItems = failListContainer.DsiMidWireComponentGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIMODULECHILDDETAILGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiModuleChildDetail_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIMODULECHILDDETAILGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiModuleChildDetailGrpc successListContainer = successResp.ListDsiModuleChildDetailGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiModuleChildDetailGrpc> successItems = successListContainer.DsiModuleChildDetailGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIMODULECHILDDETAILGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiModuleChildDetailGrpc failListContainer = failResp.ListDsiModuleChildDetailGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiModuleChildDetailGrpc> failItems = failListContainer.DsiModuleChildDetailGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIMODULECOMPATIBILITYGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiModuleCompatibility_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIMODULECOMPATIBILITYGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiModuleCompatibilityGrpc successListContainer = successResp.ListDsiModuleCompatibilityGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiModuleCompatibilityGrpc> successItems = successListContainer.DsiModuleCompatibilityGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIMODULECOMPATIBILITYGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiModuleCompatibilityGrpc failListContainer = failResp.ListDsiModuleCompatibilityGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiModuleCompatibilityGrpc> failItems = failListContainer.DsiModuleCompatibilityGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIMULTICORESPECIFICATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiMulticoreSpecification_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIMULTICORESPECIFICATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiMulticoreSpecificationGrpc successListContainer = successResp.ListDsiMulticoreSpecificationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiMulticoreSpecificationGrpc> successItems = successListContainer.DsiMulticoreSpecificationGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIMULTICORESPECIFICATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiMulticoreSpecificationGrpc failListContainer = failResp.ListDsiMulticoreSpecificationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiMulticoreSpecificationGrpc> failItems = failListContainer.DsiMulticoreSpecificationGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIPINMAPPINGGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiPinMapping_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIPINMAPPINGGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiPinMappingGrpc successListContainer = successResp.ListDsiPinMappingGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiPinMappingGrpc> successItems = successListContainer.DsiPinMappingGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIPINMAPPINGGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiPinMappingGrpc failListContainer = failResp.ListDsiPinMappingGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiPinMappingGrpc> failItems = failListContainer.DsiPinMappingGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiPinMappingCavityMappingAssociation_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiPinMappingCavityMappingAssociationGrpc successListContainer = successResp.ListDsiPinMappingCavityMappingAssociationGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiPinMappingCavityMappingAssociationGrpc> successItems =
                successListContainer.DsiPinMappingCavityMappingAssociationGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiPinMappingCavityMappingAssociationGrpc failListContainer =
                failResp.ListDsiPinMappingCavityMappingAssociationGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiPinMappingCavityMappingAssociationGrpc> failItems =
                failListContainer.DsiPinMappingCavityMappingAssociationGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // DSISCOPEGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiScope_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSISCOPEGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiScopeGrpc successListContainer = successResp.ListDsiScopeGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiScopeGrpc> successItems = successListContainer.DsiScopeGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSISCOPEGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiScopeGrpc failListContainer = failResp.ListDsiScopeGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiScopeGrpc> failItems = failListContainer.DsiScopeGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // DSICAVITYMAPPINGGRPC
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_DsiCavityMapping_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            RfqFilterRequest successReq = new RfqFilterRequest();
            successReq.DatabaseList = "DSICAVITYMAPPINGGRPC";
            successReq.FilterExpression = "true";

            Task<RfqFilterResponse> successTask = _GrpcService.FilterRfqGrpc(successReq, ctx);
            RfqFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListDsiCavityMappingGrpc successListContainer = successResp.ListDsiCavityMappingGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<DsiCavityMappingGrpc> successItems = successListContainer.DsiCavityMappingGrpcs;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            RfqFilterRequest failReq = new RfqFilterRequest();
            failReq.DatabaseList = "DSICAVITYMAPPINGGRPC";
            failReq.FilterExpression = "false";

            Task<RfqFilterResponse> failTask = _GrpcService.FilterRfqGrpc(failReq, ctx);
            RfqFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListDsiCavityMappingGrpc failListContainer = failResp.ListDsiCavityMappingGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<DsiCavityMappingGrpc> failItems = failListContainer.DsiCavityMappingGrpcs;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
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

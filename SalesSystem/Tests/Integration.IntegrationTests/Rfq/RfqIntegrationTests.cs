using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

// Adjust these namespaces to your RFQ project layout
using Rfq;                               // proto-generated messages (e.g., HelloRequest, HelloReply)
using Rfq.Endpoints.GrpcServices;        // RfqGrpcService (service implementation)
using Rfq.Services;                      // RfqAccessService (access layer)

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

            // IMPORTANT: testing=true -> seeds in-memory lists via SampleRfqDataService
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
        // Hello (health check) — same pattern you used in other modules
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

        // =====================================================================
        // The following RFQ filter tests use the SAME structure you validated:
        //   SUCCESS: FilterExpression = "true"   -> expect items
        //   FAILURE: FilterExpression = "false"  -> expect zero items
        // =====================================================================

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

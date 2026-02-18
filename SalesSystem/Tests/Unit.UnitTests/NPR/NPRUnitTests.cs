using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Unit.Tests.NPR
{
    public class NPRUnitTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;
        Mock<ILogger<NPRGrpcService>> _LoggerMock;
        string _TempNprRequestSetsPath;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services;
            services = new ServiceCollection();

            ServiceProvider provider;
            provider = services.BuildServiceProvider();

            _NPRAccessService = new NPRAccessService(provider, testing: true);

            string tempPath;
            tempPath = Path.GetTempPath();

            string fileName;
            fileName = $"npr_request_sets_unit_{Guid.NewGuid():N}.json";

            string combinedPath;
            combinedPath = Path.Combine(tempPath, fileName);

            _TempNprRequestSetsPath = combinedPath;

            OverrideNprRequestSetsPath(_NPRAccessService, _TempNprRequestSetsPath);

            _LoggerMock = new Mock<ILogger<NPRGrpcService>>();
            _GrpcService = new NPRGrpcService(_NPRAccessService, _LoggerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_TempNprRequestSetsPath) && File.Exists(_TempNprRequestSetsPath))
                {
                    File.Delete(_TempNprRequestSetsPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Test environment may restrict deletion — safe to ignore
            }

            _NPRAccessService?.Dispose();
        }
        // ---------------------------------------------------------------------
        // SayHello
        // ---------------------------------------------------------------------
        [Test]
        [Category("Unit")]
        public void SayHelloTest()
        {
            HelloRequest request;
            request = new HelloRequest();
            request.Name = "TestName";

            ServerCallContext serverCallContext;
            serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply;
            helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString;
            replyString = "Hello TestName";

            EqualConstraint equalConstraint;
            equalConstraint = Is.EqualTo(replyString);

            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // NPR: H1NPRView 
        // ---------------------------------------------------------------------
        [Test]
        [Category("Unit")]
        public void Filter_H1NPRView_Success_And_Fail()
        {
            ServerCallContext ctx;
            ctx = CreateServerContext(nameof(_GrpcService.FilterNPRGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            NPRFilterRequest successReq;
            successReq = new NPRFilterRequest();
            successReq.DatabaseList = "H1NPRVIEWGRPC";
            successReq.FilterExpression = "true";

            Task<NPRFilterResponse> successTask;
            successTask = _GrpcService.FilterNPRGrpc(successReq, ctx);

            NPRFilterResponse successResp;
            successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListH1NPRViewGrpc successListContainer;
            successListContainer = successResp.ListH1NPRViewGrpc;

            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> successItems;
            successItems = successListContainer.H1NPRViewGrpc;

            int successCount;
            successCount = successItems.Count;

            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            NPRFilterRequest failReq;
            failReq = new NPRFilterRequest();
            failReq.DatabaseList = "H1NPRVIEWGRPC";
            failReq.FilterExpression = "false";

            Task<NPRFilterResponse> failTask;
            failTask = _GrpcService.FilterNPRGrpc(failReq, ctx);

            NPRFilterResponse failResp;
            failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListH1NPRViewGrpc failListContainer;
            failListContainer = failResp.ListH1NPRViewGrpc;

            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> failItems;
            failItems = failListContainer.H1NPRViewGrpc;

            int failCount;
            failCount = failItems.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(failCount, zeroConstraint);
        }

        // ---------------------------------------------------------------------
        // NPR Request Sets (Unit with same structure as your integration)
        // ---------------------------------------------------------------------

        [Test]
        [Category("Unit")]
        public async Task GetAllNprRequestSets_FileMissing_ReturnsEmpty()
        {
            // Ensure file is missing
            if (File.Exists(_TempNprRequestSetsPath))
            {
                File.Delete(_TempNprRequestSetsPath);
            }

            Empty emptyRequest;
            emptyRequest = new Empty();

            ServerCallContext ctx;
            ctx = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));

            ListRfqNprRequestSetGrpc resp;
            resp = await _GrpcService.GetAllNprRequestSets(emptyRequest, ctx);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Items, Is.Not.Null);

            int itemCount;
            itemCount = resp.Items.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(itemCount, zeroConstraint);
        }

        [Test]
        [Category("Unit")]
        public async Task SaveAllNprRequestSets_EmptyList_CreatesFile_ThenGetReturnsEmpty()
        {
            // Start clean
            if (File.Exists(_TempNprRequestSetsPath))
            {
                File.Delete(_TempNprRequestSetsPath);
            }

            // Save with empty list
            ListRfqNprRequestSetGrpc toSave;
            toSave = new ListRfqNprRequestSetGrpc();

            ServerCallContext saveCtx;
            saveCtx = CreateServerContext(nameof(_GrpcService.SaveAllNprRequestSets));

            await _GrpcService.SaveAllNprRequestSets(toSave, saveCtx);

            // Verify file exists
            bool fileExists;
            fileExists = File.Exists(_TempNprRequestSetsPath);

            IResolveConstraint trueConstraint;
            trueConstraint = Is.True;

            Assert.That(fileExists, trueConstraint);

            // Now read back
            Empty emptyRequest;
            emptyRequest = new Empty();

            ServerCallContext getCtx;
            getCtx = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));

            ListRfqNprRequestSetGrpc readBack;
            readBack = await _GrpcService.GetAllNprRequestSets(emptyRequest, getCtx);

            Assert.That(readBack, Is.Not.Null);
            Assert.That(readBack.Items, Is.Not.Null);

            int itemCount;
            itemCount = readBack.Items.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(itemCount, zeroConstraint);
        }

        // ---------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------
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
                writeHeadersFunc: (md) => Task.CompletedTask,
                writeOptionsGetter: () => new WriteOptions(),
                writeOptionsSetter: (writeOptions) => { }
            );

            return serverCallContext;
        }

        static void OverrideNprRequestSetsPath(NPRAccessService service, string newPath)
        {
            FieldInfo? fieldInfo;
            fieldInfo = typeof(NPRAccessService).GetField("_NprRequestSetsFilePath", BindingFlags.Instance | BindingFlags.NonPublic);

            bool fieldMissing;
            fieldMissing = fieldInfo is null;

            if (fieldMissing)
            {
                throw new MissingFieldException("Could not find _NprRequestSetsFilePath on NPRAccessService.");
            }

            FieldInfo nonNullFieldInfo;
            nonNullFieldInfo = fieldInfo!;

            nonNullFieldInfo.SetValue(service, newPath);
        }
    }
}
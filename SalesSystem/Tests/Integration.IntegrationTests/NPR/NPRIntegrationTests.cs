using Google.Protobuf.Collections;
using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Integration.Tests.NPR
{
    public class NPRIntegrationTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;
        string _TempNprRequestSetsPath;
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            _NPRAccessService = new NPRAccessService(provider, testing: true);
            string tempPath;
            tempPath = Path.GetTempPath();

            string fileName;
            fileName = $"npr_request_sets_{Guid.NewGuid():N}.json";

            string combinedPath;
            combinedPath = Path.Combine(tempPath, fileName);

            _TempNprRequestSetsPath = combinedPath;

            OverrideNprRequestSetsPath(_NPRAccessService, _TempNprRequestSetsPath);
            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<NPRGrpcService> logger = _LoggerFactory.CreateLogger<NPRGrpcService>();

            _GrpcService = new NPRGrpcService(_NPRAccessService, logger);
        }

        [TearDown]
        public void TearDown()
        {
              
            _NPRAccessService?.Dispose();    
            _LoggerFactory?.Dispose();
        }

        // ---------------------------------------------------------------------
        // SayHello
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // NPR: H1NPRView 
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_H1NPRView_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterNPRGrpc));

            // ----------------------- SUCCESS CASE -----------------------
            NPRFilterRequest successReq = new NPRFilterRequest();
            successReq.DatabaseList = "H1NPRVIEWGRPC";
            successReq.FilterExpression = "true";

            Task<NPRFilterResponse> successTask = _GrpcService.FilterNPRGrpc(successReq, ctx);
            NPRFilterResponse successResp = successTask.Result;

            Assert.That(successResp, Is.Not.Null);

            ListH1NPRViewGrpc successListContainer = successResp.ListH1NPRViewGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> successItems = successListContainer.H1NPRViewGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // ----------------------- FAILURE CASE -----------------------
            NPRFilterRequest failReq = new NPRFilterRequest();
            failReq.DatabaseList = "H1NPRVIEWGRPC";
            failReq.FilterExpression = "false";

            Task<NPRFilterResponse> failTask = _GrpcService.FilterNPRGrpc(failReq, ctx);
            NPRFilterResponse failResp = failTask.Result;

            Assert.That(failResp, Is.Not.Null);

            ListH1NPRViewGrpc failListContainer = failResp.ListH1NPRViewGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<H1NPRViewGrpc> failItems = failListContainer.H1NPRViewGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        [Test]
        [Category("Integration")]
        public async Task GetAllNprRequestSets_FileMissing_ReturnsEmpty()
        {
            // Ensure file is missing
            if (File.Exists(_TempNprRequestSetsPath))
            {
                File.Delete(_TempNprRequestSetsPath);
            }

            Empty emptyRequest;
            emptyRequest = new Empty();
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));
            ListRfqNprRequestSetGrpc resp = await _GrpcService.GetAllNprRequestSets(emptyRequest, ctx);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Items, Is.Not.Null);
            int itemCount;
            itemCount = resp.Items.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(itemCount, zeroConstraint);

        }

        [Test]
        [Category("Integration")]
        public async Task SaveAllNprRequestSets_EmptyList_CreatesFile_ThenGetReturnsEmpty()
        {
            // Start clean
            if (File.Exists(_TempNprRequestSetsPath))
            {
                File.Delete(_TempNprRequestSetsPath);
            }

            // Save with empty list
            ListRfqNprRequestSetGrpc toSave = new ListRfqNprRequestSetGrpc();
            ServerCallContext saveCtx = CreateServerContext(nameof(_GrpcService.SaveAllNprRequestSets));
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
            ServerCallContext getCtx = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));
            ListRfqNprRequestSetGrpc readBack = await _GrpcService.GetAllNprRequestSets(emptyRequest, getCtx);

            Assert.That(readBack, Is.Not.Null);
            Assert.That(readBack.Items, Is.Not.Null);
            int itemCount;
            itemCount = readBack.Items.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(itemCount, zeroConstraint);

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
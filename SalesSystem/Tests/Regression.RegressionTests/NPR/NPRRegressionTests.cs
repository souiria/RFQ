using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Regression.Tests.NPR
{
    public class NPRRegressionTests
    {
        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;
        string _TempNprRequestSetsPath;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services;
            services = new ServiceCollection();

            ServiceProvider provider;
            provider = services.BuildServiceProvider();

            // Use testing=true to populate in-memory sample data
            _NPRAccessService = new NPRAccessService(provider, true);

            // Create temp file path for NPR Request Sets
            string tempPath;
            tempPath = Path.GetTempPath();

            string fileName;
            fileName = $"npr_request_sets_reg_{Guid.NewGuid():N}.json";

            string combinedPath;
            combinedPath = Path.Combine(tempPath, fileName);

            _TempNprRequestSetsPath = combinedPath;

            // Override the internal file path so we don't pollute real locations
            OverrideNprRequestSetsPath(_NPRAccessService, _TempNprRequestSetsPath);

            // Mock logger
            Mock<ILogger<NPRGrpcService>> logger;
            logger = new Mock<ILogger<NPRGrpcService>>();

            _GrpcService = new NPRGrpcService(_NPRAccessService, logger.Object);
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
            catch (IOException)
            {
                // File may be locked or already deleted — safe to ignore in teardown
            }
            catch (UnauthorizedAccessException)
            {
                // Test environment may restrict deletion — safe to ignore
            }

            _NPRAccessService?.Dispose();
        }

        [Test]
        [Category("Regression")]
        public async Task RegressionTest_NPR_AllEndpoints_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello
            // ---------------------------------------------------------

            HelloRequest helloRequest;
            helloRequest = new HelloRequest();
            helloRequest.Name = "TestName";

            ServerCallContext helloContext;
            helloContext = CreateServerContext(nameof(_GrpcService.SayHello));

            HelloReply helloReply;
            helloReply = await _GrpcService.SayHello(helloRequest, helloContext);

            string expectedHello;
            expectedHello = "Hello TestName";

            string actualHello;
            actualHello = helloReply.Message;

            EqualConstraint helloConstraint;
            helloConstraint = Is.EqualTo(expectedHello);

            Assert.That(actualHello, helloConstraint);

            // =========================================================
            // H1NPRView - GetAll + Basic Field Validation
            // =========================================================

            H1NPRViewRequest h1Request;
            h1Request = new H1NPRViewRequest();

            ServerCallContext h1Context;
            h1Context = CreateServerContext(nameof(_GrpcService.GetAllH1NPRViewGrpc));

            Task<ListH1NPRViewGrpc> h1Task;
            h1Task = _GrpcService.GetAllH1NPRViewGrpc(h1Request, h1Context);

            ListH1NPRViewGrpc h1Response;
            h1Response = await h1Task;

            RepeatedField<H1NPRViewGrpc> h1List;
            h1List = h1Response.H1NPRViewGrpc;

            Assert.That(h1List, Is.Not.Null);

            int h1ActualCount;
            h1ActualCount = h1List.Count;

            int h1ExpectedCount;
            h1ExpectedCount = 6; // from SampleNPRDataService in testing mode

            bool h1CountMatches;
            h1CountMatches = h1ActualCount == h1ExpectedCount;

            Assert.That(h1CountMatches, Is.True);

            H1NPRViewGrpc? h1First;
            h1First = h1List.FirstOrDefault();

            Assert.That(h1First, Is.Not.Null);

            // Validate a guaranteed non-null/meaningful field (based on your sample data)
            string h1CustomerNo;
            h1CustomerNo = h1First!.CustomerNo;

            bool h1CustomerNoNotEmpty;
            h1CustomerNoNotEmpty = !string.IsNullOrWhiteSpace(h1CustomerNo);

            Assert.That(h1CustomerNoNotEmpty, Is.True);

            // =========================================================
            // RFQStatus - GetAll
            // =========================================================

            RFQStatusRequest rfqRequest;
            rfqRequest = new RFQStatusRequest();

            ServerCallContext rfqContext;
            rfqContext = CreateServerContext(nameof(_GrpcService.GetAllRFQStatusGrpc));

            Task<ListRFQStatusGrpc> rfqTask;
            rfqTask = _GrpcService.GetAllRFQStatusGrpc(rfqRequest, rfqContext);

            ListRFQStatusGrpc rfqResponse;
            rfqResponse = await rfqTask;

            RepeatedField<RFQStatusGrpc> rfqList;
            rfqList = rfqResponse.RFQStatusGrpc;

            Assert.That(rfqList, Is.Not.Null);

            int rfqActualCount;
            rfqActualCount = rfqList.Count;

            int rfqExpectedCount;
            rfqExpectedCount = 6; // from SampleNPRDataService in testing mode

            bool rfqCountMatches;
            rfqCountMatches = rfqActualCount == rfqExpectedCount;

            Assert.That(rfqCountMatches, Is.True);

            // =========================================================
            // FilterNPRGrpc - H1NPRView (Success & Fail)
            // =========================================================

            ServerCallContext filterContext;
            filterContext = CreateServerContext(nameof(_GrpcService.FilterNPRGrpc));

            // Success: "true" should return items
            NPRFilterRequest filterSuccessReq;
            filterSuccessReq = new NPRFilterRequest();
            filterSuccessReq.DatabaseList = "H1NPRVIEWGRPC";
            filterSuccessReq.FilterExpression = "true";

            NPRFilterResponse filterSuccessResp;
            filterSuccessResp = await _GrpcService.FilterNPRGrpc(filterSuccessReq, filterContext);

            Assert.That(filterSuccessResp, Is.Not.Null);
            Assert.That(filterSuccessResp.ListH1NPRViewGrpc, Is.Not.Null);

            int filterSuccessCount;
            filterSuccessCount = filterSuccessResp.ListH1NPRViewGrpc.H1NPRViewGrpc.Count;

            Assert.That(filterSuccessCount, Is.Positive);

            // Fail: "false" should return 0 items
            NPRFilterRequest filterFailReq;
            filterFailReq = new NPRFilterRequest();
            filterFailReq.DatabaseList = "H1NPRVIEWGRPC";
            filterFailReq.FilterExpression = "false";

            NPRFilterResponse filterFailResp;
            filterFailResp = await _GrpcService.FilterNPRGrpc(filterFailReq, filterContext);

            Assert.That(filterFailResp, Is.Not.Null);
            Assert.That(filterFailResp.ListH1NPRViewGrpc, Is.Not.Null);

            int filterFailCount;
            filterFailCount = filterFailResp.ListH1NPRViewGrpc.H1NPRViewGrpc.Count;

            IResolveConstraint zeroConstraint;
            zeroConstraint = Is.EqualTo(0);

            Assert.That(filterFailCount, zeroConstraint);

            // =========================================================
            // NPR Request Sets
            //   1) Missing file -> Get returns empty
            //   2) Save empty list -> file created -> Get returns empty
            // =========================================================

            // 1) Ensure file is missing
            if (File.Exists(_TempNprRequestSetsPath))
            {
                File.Delete(_TempNprRequestSetsPath);
            }

            Empty emptyRequest;
            emptyRequest = new Empty();

            ServerCallContext getSetsContext1;
            getSetsContext1 = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));

            ListRfqNprRequestSetGrpc setsResp1;
            setsResp1 = await _GrpcService.GetAllNprRequestSets(emptyRequest, getSetsContext1);

            Assert.That(setsResp1, Is.Not.Null);
            Assert.That(setsResp1.Items, Is.Not.Null);

            int setsCount1;
            setsCount1 = setsResp1.Items.Count;

            Assert.That(setsCount1, zeroConstraint);

            // 2) Save empty list -> file should be created
            ListRfqNprRequestSetGrpc toSave;
            toSave = new ListRfqNprRequestSetGrpc();

            ServerCallContext saveSetsContext;
            saveSetsContext = CreateServerContext(nameof(_GrpcService.SaveAllNprRequestSets));

            Empty saveResult;
            saveResult = await _GrpcService.SaveAllNprRequestSets(toSave, saveSetsContext);

            bool fileExists;
            fileExists = File.Exists(_TempNprRequestSetsPath);

            IResolveConstraint trueConstraint;
            trueConstraint = Is.True;

            Assert.That(fileExists, trueConstraint);

            // Read back -> still empty
            ServerCallContext getSetsContext2;
            getSetsContext2 = CreateServerContext(nameof(_GrpcService.GetAllNprRequestSets));

            ListRfqNprRequestSetGrpc setsResp2;
            setsResp2 = await _GrpcService.GetAllNprRequestSets(emptyRequest, getSetsContext2);

            Assert.That(setsResp2, Is.Not.Null);
            Assert.That(setsResp2.Items, Is.Not.Null);

            int setsCount2;
            setsCount2 = setsResp2.Items.Count;

            Assert.That(setsCount2, zeroConstraint);
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
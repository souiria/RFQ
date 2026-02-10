using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using CDb;
using CDb.Endpoints.GrpcServices;
using CDb.Services;

using Grpc.Core;
using Grpc.Core.Testing;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Moq;
using NUnit.Framework;

namespace Regression.Tests.CDb
{
    public class CDbRegressionTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            // testing=true -> PopulateSampleData() pre-fills ClipType, CoverType, CrimpingProcessType, FileType, WireType, CompositeComponent
            _CDbAccessService = new CDbAccessService(provider, true);

            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
        }

        [Test]
        public async Task RegressionTest_AllEndpoints_FilterOnly_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello (health check)
            // ---------------------------------------------------------
            HelloRequest helloRequest = new HelloRequest();
            helloRequest.Name = "TestName";
            ServerCallContext helloContext = CreateServerContext(nameof(_GrpcService.SayHello));
            HelloReply helloResult = await _GrpcService.SayHello(helloRequest, helloContext);
            Assert.That(helloResult.Message == "Hello TestName", Is.True);

            // ---------------------------------------------------------
            //   CLIP TYPE
            // ---------------------------------------------------------
            CdbFilterRequestGrpc clipTypeFilter;
            clipTypeFilter = new CdbFilterRequestGrpc();
            clipTypeFilter.DatabaseList = "CLIPTYPEGRPC";
            clipTypeFilter.FilterExpression = "Id != null";

            Assert.That(!string.IsNullOrWhiteSpace(clipTypeFilter.FilterExpression),
                $"FilterExpression is empty for DatabaseList = {clipTypeFilter.DatabaseList}");

            ServerCallContext clipTypeContext;
            clipTypeContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));

            Task<CdbFilterResponseGrpc> clipTypeTask;
            clipTypeTask = _GrpcService.FilterCdbDataGrpc(clipTypeFilter, clipTypeContext);

            CdbFilterResponseGrpc clipTypeResponse;
            clipTypeResponse = await clipTypeTask;

            int clipTypeCount;
            clipTypeCount = clipTypeResponse.ListClipTypes.ClipTypeGrpcs.Count;

            Assert.That(0 < clipTypeCount, Is.True);

            string? clipTypeFirstId = clipTypeResponse.ListClipTypes.ClipTypeGrpcs.FirstOrDefault()?.Id;
            Assert.That(!string.IsNullOrWhiteSpace(clipTypeFirstId), Is.True);

            // Fail case
            CdbFilterRequestGrpc clipTypeFail = new CdbFilterRequestGrpc();
            clipTypeFail.DatabaseList = "CLIPTYPEGRPC";
            clipTypeFail.FilterExpression = "Id == \"THIS_VALUE_DOES_NOT_EXIST_999999\"";

            CdbFilterResponseGrpc clipTypeFailResp = await _GrpcService.FilterCdbDataGrpc(clipTypeFail, clipTypeContext);
            Assert.That(clipTypeFailResp.ListClipTypes.ClipTypeGrpcs.Count == 0, Is.True);

            // ---------------------------------------------------------
            //   COVER TYPE
            // ---------------------------------------------------------
            CdbFilterRequestGrpc coverTypeFilter = new CdbFilterRequestGrpc();
            coverTypeFilter.DatabaseList = "COVERTYPEGRPC";
            coverTypeFilter.FilterExpression = "Id != null";

            Assert.That(!string.IsNullOrWhiteSpace(coverTypeFilter.FilterExpression), Is.True);

            ServerCallContext coverTypeContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            CdbFilterResponseGrpc coverTypeResp = await _GrpcService.FilterCdbDataGrpc(coverTypeFilter, coverTypeContext);

            int coverTypeCount = coverTypeResp.ListCoverTypes.CoverTypeGrpcs.Count;
            Assert.That(0 < coverTypeCount, Is.True);

            string? coverTypeFirstId = coverTypeResp.ListCoverTypes.CoverTypeGrpcs.FirstOrDefault()?.Id;
            Assert.That(!string.IsNullOrWhiteSpace(coverTypeFirstId), Is.True);

            // Fail case
            CdbFilterRequestGrpc coverTypeFail = new CdbFilterRequestGrpc();
            coverTypeFail.DatabaseList = "COVERTYPEGRPC";
            coverTypeFail.FilterExpression = "Id == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            CdbFilterResponseGrpc coverTypeFailResp = await _GrpcService.FilterCdbDataGrpc(coverTypeFail, coverTypeContext);
            Assert.That(coverTypeFailResp.ListCoverTypes.CoverTypeGrpcs.Count == 0, Is.True);

            // ---------------------------------------------------------
            //   CRIMPING PROCESS TYPE
            // ---------------------------------------------------------
            CdbFilterRequestGrpc crimpProcFilter = new CdbFilterRequestGrpc();
            crimpProcFilter.DatabaseList = "CRIMPINGPROCESSTYPEGRPC";
            crimpProcFilter.FilterExpression = "Id != null";

            Assert.That(!string.IsNullOrWhiteSpace(crimpProcFilter.FilterExpression), Is.True);

            ServerCallContext crimpProcContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            CdbFilterResponseGrpc crimpProcResp = await _GrpcService.FilterCdbDataGrpc(crimpProcFilter, crimpProcContext);

            int crimpProcCount = crimpProcResp.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs.Count;
            Assert.That(0 < crimpProcCount, Is.True);

            string? crimpProcFirstId = crimpProcResp.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs.FirstOrDefault()?.Id;
            Assert.That(!string.IsNullOrWhiteSpace(crimpProcFirstId), Is.True);

            // Fail case
            CdbFilterRequestGrpc crimpProcFail = new CdbFilterRequestGrpc();
            crimpProcFail.DatabaseList = "CRIMPINGPROCESSTYPEGRPC";
            crimpProcFail.FilterExpression = "Id == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            CdbFilterResponseGrpc crimpProcFailResp = await _GrpcService.FilterCdbDataGrpc(crimpProcFail, crimpProcContext);
            Assert.That(crimpProcFailResp.ListCrimpingProcessTypes.CrimpingProcessTypeGrpcs.Count == 0, Is.True);

            // ---------------------------------------------------------
            //   FILE TYPE
            // ---------------------------------------------------------
            CdbFilterRequestGrpc fileTypeFilter = new CdbFilterRequestGrpc();
            fileTypeFilter.DatabaseList = "FILETYPEGRPC";
            fileTypeFilter.FilterExpression = "Id != null";

            Assert.That(!string.IsNullOrWhiteSpace(fileTypeFilter.FilterExpression), Is.True);

            ServerCallContext fileTypeContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            CdbFilterResponseGrpc fileTypeResp = await _GrpcService.FilterCdbDataGrpc(fileTypeFilter, fileTypeContext);

            int fileTypeCount = fileTypeResp.ListFileTypes.FileTypeGrpcs.Count;
            Assert.That(0 < fileTypeCount, Is.True);

            string? fileTypeFirstId = fileTypeResp.ListFileTypes.FileTypeGrpcs.FirstOrDefault()?.Id;
            Assert.That(!string.IsNullOrWhiteSpace(fileTypeFirstId), Is.True);

            // Fail case
            CdbFilterRequestGrpc fileTypeFail = new CdbFilterRequestGrpc();
            fileTypeFail.DatabaseList = "FILETYPEGRPC";
            fileTypeFail.FilterExpression = "Id == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            CdbFilterResponseGrpc fileTypeFailResp = await _GrpcService.FilterCdbDataGrpc(fileTypeFail, fileTypeContext);
            Assert.That(fileTypeFailResp.ListFileTypes.FileTypeGrpcs.Count == 0, Is.True);

            // ---------------------------------------------------------
            //   WIRE TYPE
            // ---------------------------------------------------------
            CdbFilterRequestGrpc wireTypeFilter = new CdbFilterRequestGrpc();
            wireTypeFilter.DatabaseList = "WIRETYPEGRPC";
            wireTypeFilter.FilterExpression = "Id != null";

            Assert.That(!string.IsNullOrWhiteSpace(wireTypeFilter.FilterExpression), Is.True);

            ServerCallContext wireTypeContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            CdbFilterResponseGrpc wireTypeResp = await _GrpcService.FilterCdbDataGrpc(wireTypeFilter, wireTypeContext);

            int wireTypeCount = wireTypeResp.ListWireTypes.WireTypeGrpcs.Count;
            Assert.That(0 < wireTypeCount, Is.True);

            string? wireTypeFirstId = wireTypeResp.ListWireTypes.WireTypeGrpcs.FirstOrDefault()?.Id;
            Assert.That(!string.IsNullOrWhiteSpace(wireTypeFirstId), Is.True);

            // Fail case
            CdbFilterRequestGrpc wireTypeFail = new CdbFilterRequestGrpc();
            wireTypeFail.DatabaseList = "WIRETYPEGRPC";
            wireTypeFail.FilterExpression = "Id == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            CdbFilterResponseGrpc wireTypeFailResp = await _GrpcService.FilterCdbDataGrpc(wireTypeFail, wireTypeContext);
            Assert.That(wireTypeFailResp.ListWireTypes.WireTypeGrpcs.Count == 0, Is.True);
            // ---------------------------------------------------------
            //   COMPOSITE COMPONENTS
            // ---------------------------------------------------------
            CdbFilterRequestGrpc compFilter = new CdbFilterRequestGrpc();
            compFilter.DatabaseList = "COMPOSITECOMPONENTGRPC";
            // Use a generic always-true filter based on existence (adjust if you know an actual field)
            compFilter.FilterExpression = "true";

            Assert.That(!string.IsNullOrWhiteSpace(compFilter.FilterExpression), Is.True);

            ServerCallContext compContext = CreateServerContext(nameof(_GrpcService.FilterCdbDataGrpc));
            CdbFilterResponseGrpc compResp = await _GrpcService.FilterCdbDataGrpc(compFilter, compContext);

            int compCount = compResp.ListCompositeComponents.CompositeComponentGrpcs.Count;
            Assert.That(0 < compCount, Is.True);

            // Just ensure at least one element exists (no property access)
            CompositeComponentGrpc? compositeFirst = compResp.ListCompositeComponents.CompositeComponentGrpcs.FirstOrDefault();
            Assert.That(compositeFirst, Is.Not.Null);

            // Fail case
            CdbFilterRequestGrpc compFail = new CdbFilterRequestGrpc();
            compFail.DatabaseList = "COMPOSITECOMPONENTGRPC";
            // Use a filter that is guaranteed to return 0; pick a **real** field name if you know one.
            compFail.FilterExpression = "1 == 2";

            CdbFilterResponseGrpc compFailResp = await _GrpcService.FilterCdbDataGrpc(compFail, compContext);
            Assert.That(compFailResp.ListCompositeComponents.CompositeComponentGrpcs.Count == 0, Is.True);

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
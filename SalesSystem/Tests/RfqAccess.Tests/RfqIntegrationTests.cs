using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Rfq;
using Rfq.Endpoints.GrpcServices;
using Rfq.Enums;
using Rfq.Services;

namespace RfqAccess.Tests
{
    public class RfqIntegrationTests
    {
        RfqAccessService _RfqAccessService;
        RfqGrpcService _GrpcService;
        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _RfqAccessService = new RfqAccessService(serviceProvider, true);
            Mock<ILogger<RfqGrpcService>> logger = new Mock<ILogger<RfqGrpcService>>();
            _GrpcService = new RfqGrpcService(_RfqAccessService, logger.Object);
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

        #region RfqDrawingPartNumber
        [Test]
        public void GetRfqDrawingPartNumbersGrpcTest_Success()
        {
            RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
            drawingPartNumbersGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

            Task<ListRfqDrawingPartNumbersGrpc> getRfqDrawingPartNumbersGrpcReply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers.Count, countConstraint);

        }

        [Test]
        public void GetRfqDrawingPartNumbersGrpcByRowIdTest_Success()
        {
            RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.IntValue = 6;
            drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
            drawingPartNumbersGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.ReadByRowId);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

            Task<ListRfqDrawingPartNumbersGrpc> getRfqDrawingPartNumbersByRowIdReply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);

            Assert.That(getRfqDrawingPartNumbersByRowIdReply.Result.RfqDrawingPartNumbers, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getRfqDrawingPartNumbersByRowIdReply.Result.RfqDrawingPartNumbers.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestOriginalPartNumber");
            Assert.That(getRfqDrawingPartNumbersByRowIdReply.Result.RfqDrawingPartNumbers.First().OriginalPartNumber, nameConstraint);
        }

        [Test]
        public void GetRfqDrawingPartNumbersGrpcByRowIdTest_Fails()
        {
            RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.IntValue = int.MaxValue;
            drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
            drawingPartNumbersGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.ReadByRowId);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

            Task<ListRfqDrawingPartNumbersGrpc> getRfqDrawingPartNumbersByRowIdReply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getRfqDrawingPartNumbersByRowIdReply.Result.RfqDrawingPartNumbers.Count, countConstraint);
        }

        //[Test]
        //public async Task CreateRfqDrawingPartNumbersGrpcTest_Success()
        //{
        //    Mock<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>> mockRfqProjectCommandHandler = new Mock<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>>();
        //    RfqDrawingPartNumberCommand command = It.IsAny<RfqDrawingPartNumberCommand>();
        //    CancellationToken cancelationToken = It.IsAny<CancellationToken>();
        //    ListRfqDrawingPartNumbersGrpc drawingPartNumberList = SampleRfqDataService.PopulateRfqDrawingPartNumbersGrpc();
        //    List<DbRfqDrawingPartNumber> dbRfqDrawingPartNumbers = drawingPartNumberList.RfqDrawingPartNumbers.Select(r => r.ToEntity()).ToList();
        //    Result<List<DbRfqDrawingPartNumber>> results = new Result<List<DbRfqDrawingPartNumber>>(dbRfqDrawingPartNumbers, true, Error.None);
        //    mockRfqProjectCommandHandler.Setup(m => m.Handle(command, cancelationToken))
        //        .ReturnsAsync(results);

        //    RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
        //    RfqDrawingPartNumbersGrpc drawingPartNumbersGrpc = new RfqDrawingPartNumbersGrpc();
        //    drawingPartNumbersGrpc.OriginalPartNumber = "TestOriginalPartNumber";
        //    drawingPartNumbersGrpc.OriginalPartNumberPrice = 30;
        //    drawingPartNumbersGrpcRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(drawingPartNumbersGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateRfqDrawingPartNumbersGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(6);

        //    RfqCrudGrpcResponse createRfqDrawingPartNumbersByRowIdReply = await _GrpcService.CreateRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(7);
        //    Assert.That(createRfqDrawingPartNumbersByRowIdReply.SaveSuccess, countConstraint);
        //}
        #endregion

        #region RfqProject
        [Test]
        public void GetRfqProjectGrpcTest_Success()
        {
            RfqProjectGrpcRequest drawingPartNumbersGrpcRequest = new RfqProjectGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

            Task<ListRfqProjectGrpc> getRfqProjectGrpcReply = _GrpcService.ReadRfqProjectGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
            Assert.That(getRfqProjectGrpcReply.Result.RfqProjects, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqProjectGrpcReply.Result.RfqProjects.Count, countConstraint);

        }

        [Test]
        public void GetRfqProjectGrpcByRowIdTest_Success()
        {
            RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.IntValue = 6;
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            projectGrpcRequest.GrpcRequestParameter = requestParameter;

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

            Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

            Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProjectGuid");
            Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.First().ProjectGuid, nameConstraint);
        }

        [Test]
        public void GetRfqProjectGrpcByRowIdTest_Fails()
        {
            RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            projectGrpcRequest.GrpcRequestParameter = requestParameter;
            projectGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.ReadByRowId);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

            Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
        }

        //[Test]
        //public void CreateRfqProjectGrpcTest_Success()
        //{
        //    RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    projectGrpcRequest.GrpcRequestParameter = requestParameter;
        //    RfqProjectGrpc projectGrpc = new RfqProjectGrpc();
        //    projectGrpc.ProjectGuid = "d7b17788-a28f-4877-8b48-e43bf0e85efe";
        //    projectGrpc.CarModelGuid = "471babb7-a0c5-468a-b963-c146c47a3a13";
        //    projectGrpcRequest.RfqProjectGrpcsToCreate.Add(projectGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateRfqProjectGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
        //}
        #endregion

        #region RfqNotes
        [Test]
        public void GetRfqNotesGrpcTest_Success()
        {
            RfqNotesGrpcRequest notesGrpcRequest = new RfqNotesGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            notesGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqNotesGrpc));

            Task<ListRfqNotesGrpc> getRfqNotesGrpcReply = _GrpcService.ReadRfqNotesGrpc(notesGrpcRequest, serverCallContext);
            Assert.That(getRfqNotesGrpcReply.Result.RfqNotes, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqNotesGrpcReply.Result.RfqNotes.Count, countConstraint);

        }

        [Test]
        public void GetRfqNotesGrpcByRowIdTest_Success()
        {
            RfqNotesGrpcRequest notesGrpcRequest = new RfqNotesGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            notesGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqNotesGrpc));

            Task<ListRfqNotesGrpc> getRfqNotesByRowIdReply = _GrpcService.ReadRfqNotesGrpc(notesGrpcRequest, serverCallContext);

            Assert.That(getRfqNotesByRowIdReply.Result.RfqNotes, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getRfqNotesByRowIdReply.Result.RfqNotes.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint noteConstraint = Is.EqualTo("TestNote");
            Assert.That(getRfqNotesByRowIdReply.Result.RfqNotes.First().Note, noteConstraint);
        }

        [Test]
        public void GetRfqNotesGrpcByRowIdTest_Fails()
        {
            RfqNotesGrpcRequest noteGrpcRequest = new RfqNotesGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            noteGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqNotesGrpc));

            Task<ListRfqNotesGrpc> getRfqNotesByRowIdReply = _GrpcService.ReadRfqNotesGrpc(noteGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getRfqNotesByRowIdReply.Result.RfqNotes.Count, countConstraint);
        }

        //[Test]
        //public void CreateRfqNotesGrpcTest_Success()
        //{
        //    RfqNotesGrpcRequest noteGrpcRequest = new RfqNotesGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    noteGrpcRequest.GrpcRequestParameter = requestParameter;
        //    RfqNotesGrpc noteGrpc = new RfqNotesGrpc();
        //    noteGrpc.Note = "TestNote";
        //    noteGrpcRequest.RfqNotesGrpcsToCreate.Add(noteGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateRfqNotesGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListRfqNotesGrpc> getRfqNotesByRowIdReply = _GrpcService.ReadRfqNotesGrpc(noteGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getRfqNotesByRowIdReply.Result.RfqNotes.Count, countConstraint);
        //}
        #endregion

        #region RfqReason
        [Test]
        public void GetRfqReasonGrpcTest_Success()
        {
            RfqReasonGrpcRequest reasonGrpcRequest = new RfqReasonGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqReasonGrpc));

            Task<ListRfqReasonGrpc> getRfqReasonGrpcReply = _GrpcService.ReadRfqReasonGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getRfqReasonGrpcReply.Result.RfqReasons, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqReasonGrpcReply.Result.RfqReasons.Count, countConstraint);

        }

        [Test]
        public void GetRfqReasonGrpcByRowIdTest_Success()
        {
            RfqReasonGrpcRequest reasonGrpcRequest = new RfqReasonGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqReasonGrpc));

            Task<ListRfqReasonGrpc> getRfqReasonByRowIdReply = _GrpcService.ReadRfqReasonGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getRfqReasonByRowIdReply.Result.RfqReasons, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getRfqReasonByRowIdReply.Result.RfqReasons.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("TestReasonTitle");
            Assert.That(getRfqReasonByRowIdReply.Result.RfqReasons.First().ReasonTitle, reasonConstraint);
        }

        [Test]
        public void GetRfqReasonGrpcByRowIdTest_Fails()
        {
            RfqReasonGrpcRequest reasonGrpcRequest = new RfqReasonGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqReasonGrpc));

            Task<ListRfqReasonGrpc> getRfqReasonByRowIdReply = _GrpcService.ReadRfqReasonGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getRfqReasonByRowIdReply.Result.RfqReasons.Count, countConstraint);
        }

        //[Test]
        //public void CreateRfqReasonGrpcTest_Success()
        //{
        //    RfqReasonGrpcRequest reasonGrpcRequest = new RfqReasonGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    RfqReasonGrpc noteGrpc = new RfqReasonGrpc();
        //    noteGrpc.ReasonTitle = "TestReason";
        //    reasonGrpcRequest.RfqReasonGrpcsToCreate.Add(noteGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateRfqReasonGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListRfqReasonGrpc> getRfqReasonByRowIdReply = _GrpcService.ReadRfqReasonGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getRfqReasonByRowIdReply.Result.RfqReasons.Count, countConstraint);
        //}
        #endregion

        #region DsiBend
        [Test]
        public void GetDsiBendGrpcTest_Success()
        {
            DsiBendGrpcRequest reasonGrpcRequest = new DsiBendGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBendGrpc));

            Task<ListDsiBendGrpc> getDsiBendGrpcReply = _GrpcService.ReadDsiBendGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBendGrpcReply.Result.DsiBends, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBendGrpcReply.Result.DsiBends.Count, countConstraint);

        }

        [Test]
        public void GetDsiBendGrpcByRowIdTest_Success()
        {
            DsiBendGrpcRequest reasonGrpcRequest = new DsiBendGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBendGrpc));

            Task<ListDsiBendGrpc> getDsiBendByRowIdReply = _GrpcService.ReadDsiBendGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiBendByRowIdReply.Result.DsiBends, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiBendByRowIdReply.Result.DsiBends.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedBend");
            Assert.That(getDsiBendByRowIdReply.Result.DsiBends.First().Bend, reasonConstraint);
        }

        [Test]
        public void GetDsiBendGrpcByRowIdTest_Fails()
        {
            DsiBendGrpcRequest reasonGrpcRequest = new DsiBendGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBendGrpc));

            Task<ListDsiBendGrpc> getDsiBendByRowIdReply = _GrpcService.ReadDsiBendGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBendByRowIdReply.Result.DsiBends.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBendGrpcTest_Success()
        //{
        //    DsiBendGrpcRequest reasonGrpcRequest = new DsiBendGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiBendGrpc bendGrpc = new DsiBendGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBendGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBendGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBendGrpc> getDsiBendByRowIdReply = _GrpcService.ReadDsiBendGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBendByRowIdReply.Result.DsiBends.Count, countConstraint);
        //}
        #endregion

        #region DsiBranchConfiguration
        [Test]
        public void GetDsiBranchConfigurationGrpcTest_Success()
        {
            DsiBranchConfigurationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationGrpc));

            Task<ListDsiBranchConfigurationGrpc> getDsiBranchConfigurationGrpcReply = _GrpcService.ReadDsiBranchConfigurationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchConfigurationGrpcReply.Result.DsiBranchConfigurations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchConfigurationGrpcReply.Result.DsiBranchConfigurations.Count, countConstraint);

        }

        [Test]
        public void GetDsiBranchConfigurationGrpcByRowIdTest_Success()
        {
            DsiBranchConfigurationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationGrpc));

            Task<ListDsiBranchConfigurationGrpc> getDsiBranchConfigurationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiBranchConfigurationByRowIdReply.Result.DsiBranchConfigurations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiBranchConfigurationByRowIdReply.Result.DsiBranchConfigurations.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("TestUserModule");
            Assert.That(getDsiBranchConfigurationByRowIdReply.Result.DsiBranchConfigurations.First().UserModule, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchConfigurationGrpcByRowIdTest_Fails()
        {
            DsiBranchConfigurationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationGrpc));

            Task<ListDsiBranchConfigurationGrpc> getDsiBranchConfigurationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBranchConfigurationByRowIdReply.Result.DsiBranchConfigurations.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchConfigurationGrpcTest_Success()
        //{
        //    DsiBranchConfigurationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiBranchConfigurationGrpc bendGrpc = new DsiBranchConfigurationGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBranchConfigurationGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchConfigurationGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchConfigurationGrpc> getDsiBranchConfigurationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchConfigurationByRowIdReply.Result.DsiBranchConfigurations.Count, countConstraint);
        //}
        #endregion

        #region DsiBranchConfigurationBendAssociation
        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcTest_Success()
        {
            DsiBranchConfigurationBendAssociationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc));

            Task<ListDsiBranchConfigurationBendAssociationGrpc> getDsiBranchConfigurationBendAssociationGrpcReply = _GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchConfigurationBendAssociationGrpcReply.Result.DsiBranchConfigurationBendAssociations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchConfigurationBendAssociationGrpcReply.Result.DsiBranchConfigurationBendAssociations.Count, countConstraint);

        }

        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcByRowIdTest_Success()
        {
            DsiBranchConfigurationBendAssociationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc));

            Task<ListDsiBranchConfigurationBendAssociationGrpc> getDsiBranchConfigurationBendAssociationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiBranchConfigurationBendAssociationByRowIdReply.Result.DsiBranchConfigurationBendAssociations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiBranchConfigurationBendAssociationByRowIdReply.Result.DsiBranchConfigurationBendAssociations.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("664c3151-c7fc-4e0e-971c-f1712a6342e1");
            Assert.That(getDsiBranchConfigurationBendAssociationByRowIdReply.Result.DsiBranchConfigurationBendAssociations.First().BendId, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcByRowIdTest_Fails()
        {
            DsiBranchConfigurationBendAssociationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc));

            Task<ListDsiBranchConfigurationBendAssociationGrpc> getDsiBranchConfigurationBendAssociationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBranchConfigurationBendAssociationByRowIdReply.Result.DsiBranchConfigurationBendAssociations.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchConfigurationBendAssociationGrpcTest_Success()
        //{
        //    DsiBranchConfigurationBendAssociationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiBranchConfigurationBendAssociationGrpc bendGrpc = new DsiBranchConfigurationBendAssociationGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBranchConfigurationBendAssociationGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchConfigurationBendAssociationGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchConfigurationBendAssociationGrpc> getDsiBranchConfigurationBendAssociationByRowIdReply = _GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchConfigurationBendAssociationByRowIdReply.Result.DsiBranchConfigurationBendAssociations.Count, countConstraint);
        //}
        #endregion

        #region DsiBranchInsulation
        [Test]
        public void GetDsiBranchInsulationGrpcTest_Success()
        {
            DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationGrpc));

            Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationGrpcReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchInsulationGrpcReply.Result.DsiBranchInsulations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchInsulationGrpcReply.Result.DsiBranchInsulations.Count, countConstraint);

        }

        [Test]
        public void GetDsiBranchInsulationGrpcByRowIdTest_Success()
        {
            DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationGrpc));

            Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationByRowIdReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedColour");
            Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations.First().Colour, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchInsulationGrpcByRowIdTest_Fails()
        {
            DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationGrpc));

            Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationByRowIdReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchInsulationGrpcTest_Success()
        //{
        //    DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiBranchInsulationGrpc bendGrpc = new DsiBranchInsulationGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBranchInsulationGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchInsulationGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationByRowIdReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations.Count, countConstraint);
        //}
        #endregion

        #region DsiBranchInsulationThroughNode
        [Test]
        public void GetDsiBranchInsulationThroughNodeGrpcTest_Success()
        {
            DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = ((int)RequestType.Read);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationThroughNodeGrpc));

            Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeGrpcReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchInsulationThroughNodeGrpcReply.Result.DsiBranchInsulationThroughNodes, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchInsulationThroughNodeGrpcReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);

        }

        [Test]
        public void GetDsiBranchInsulationThroughNodeGrpcByRowIdTest_Success()
        {
            DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationThroughNodeGrpc));

            Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedThroughNode");
            Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes.First().ThroughNode, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchInsulationThroughNodeGrpcByRowIdTest_Fails()
        {
            DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.ReadByRowId);
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationThroughNodeGrpc));

            Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchInsulationThroughNodeGrpcTest_Success()
        //{
        //    DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiBranchInsulationThroughNodeGrpc bendGrpc = new DsiBranchInsulationThroughNodeGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBranchInsulationThroughNodeGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchInsulationThroughNodeGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);
        //}
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

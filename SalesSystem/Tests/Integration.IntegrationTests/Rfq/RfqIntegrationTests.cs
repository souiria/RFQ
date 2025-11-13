using Rfq;
using Rfq.Endpoints.GrpcServices;
using Rfq.Enums;
using Rfq.Services;

namespace Integration.Tests.Rfq
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
            drawingPartNumbersGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

            Task<ListRfqDrawingPartNumbersGrpc> getRfqDrawingPartNumbersGrpcReply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers.Count, countConstraint);

        }
        //temporary excluded
        //[Test]
        //public void GetRfqDrawingPartNumbersGrpcByRowIdTest_Success()
        //{
        //    RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();

        //    // This value is used as RfqId in your service
        //    requestParameter.RfqId = 6;
        //    requestParameter.RequestType = (int)RequestType.ReadByRowId;

        //    drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;

        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

        //    Task<ListRfqDrawingPartNumbersGrpc> reply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);

        //    Assert.That(reply.Result.RfqDrawingPartNumbers, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(reply.Result.RfqDrawingPartNumbers.Count, countConstraint);
        //    NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestOriginalPartNumber");
        //    Assert.That(reply.Result.RfqDrawingPartNumbers.First().RfqId, nameConstraint);
        //}
        //[Test]
        //public void GetRfqDrawingPartNumbersGrpcByRowIdTest_Fails()
        //{
        //    RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();

        //    // This value is used as RfqId in your service
        //    requestParameter.RfqId = int.MaxValue;
        //    requestParameter.RequestType = (int)RequestType.ReadByRowId;

        //    drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;

        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

        //    Task<ListRfqDrawingPartNumbersGrpc> reply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        //    Assert.That(reply.Result.RfqDrawingPartNumbers.Count, countConstraint);
        //}
        #endregion

        //#region RfqProject
        //[Test]
        //public void GetRfqProjectGrpcTest_Success()
        //{
        //    RfqProjectGrpcRequest drawingPartNumbersGrpcRequest = new RfqProjectGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Read);
        //    drawingPartNumbersGrpcRequest.GrpcRequestParameter = requestParameter;
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

        //    Task<ListRfqProjectGrpc> getRfqProjectGrpcReply = _GrpcService.ReadRfqProjectGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
        //    Assert.That(getRfqProjectGrpcReply.Result.RfqProjects, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
        //    Assert.That(getRfqProjectGrpcReply.Result.RfqProjects.Count, countConstraint);

        //}

        //[Test]
        //public void GetRfqProjectGrpcByRowIdTest_Success()
        //{
        //    RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.ReadByRowId);
        //    projectGrpcRequest.GrpcRequestParameter = requestParameter;
        //    projectGrpcRequest.RowId = 6; 

        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

        //    Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

        //    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects, Is.Not.Null);
        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
        //    NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProjectGuid");
        //    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.First().ProjectGuid, nameConstraint);
        //}

        //[Test]
        //public void GetRfqProjectGrpcByRowIdTest_Fails()
        //{
        //    RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.ReadByRowId);
        //    projectGrpcRequest.GrpcRequestParameter = requestParameter;
        //    projectGrpcRequest.RowId = 9999; 

        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

        //    Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        //    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
        //}

        ////[Test]
        ////public void CreateRfqProjectGrpcTest_Success()
        ////{
        ////    RfqProjectGrpcRequest projectGrpcRequest = new RfqProjectGrpcRequest();
        ////    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        ////    requestParameter.RequestType = ((int)RequestType.Create);
        ////    projectGrpcRequest.GrpcRequestParameter = requestParameter;
        ////    RfqProjectGrpc projectGrpc = new RfqProjectGrpc();
        ////    projectGrpc.ProjectGuid = "d7b17788-a28f-4877-8b48-e43bf0e85efe";
        ////    projectGrpc.CarModelGuid = "471babb7-a0c5-468a-b963-c146c47a3a13";
        ////    projectGrpcRequest.RfqProjectGrpcsToCreate.Add(projectGrpc);
        ////    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateRfqProjectGrpc));
        ////    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        ////    Task<ListRfqProjectGrpc> getRfqProjectByRowIdReply = _GrpcService.ReadRfqProjectGrpc(projectGrpcRequest, serverCallContext);

        ////    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        ////    Assert.That(getRfqProjectByRowIdReply.Result.RfqProjects.Count, countConstraint);
        ////}
        //#endregion

        #region RfqNotes
        [Test]
        public void GetRfqNotesGrpcTest_Success()
        {
            RfqNotesGrpcRequest notesGrpcRequest = new RfqNotesGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
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

        #region DsiCavityMapping
        [Test]
        public void GetDsiCavityMappingGrpcTest_Success()
        {
            DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCavityMappingGrpc));

            Task<ListDsiCavityMappingGrpc> getDsiCavityMappingGrpcReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCavityMappingGrpcReply.Result.DsiCavityMappingGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCavityMappingGrpcReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);

        }

        [Test]
        public void GetDsiCavityMappingGrpcByRowIdTest_Success()
        {
            DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCavityMappingGrpc));

            Task<ListDsiCavityMappingGrpc> getDsiCavityMappingByRowIdReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedCavityMapping");
            Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs.First().CavityMapping, reasonConstraint);
        }

        [Test]
        public void GetDsiCavityMappingGrpcByRowIdTest_Fails()
        {
            DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCavityMappingGrpc));

            Task<ListDsiCavityMappingGrpc> getDsiCavityMappingByRowIdReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiCavityMappingGrpcTest_Success()
        //{
        //    DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
        //    GrpcRequestParameter requestParameter = new GrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.GrpcRequestParameter = requestParameter;
        //    DsiCavityMappingGrpc bendGrpc = new DsiCavityMappingGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiCavityMappingGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiCavityMappingGrpc));
        //    NUnit.Framework.Constraints.EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiCavityMappingGrpc> getDsiCavityMappingByRowIdReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);

        //    NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);
        //}
        #endregion

        #region DsiCircuitOption
        [Test]
        public void GetDsiCircuitOptionGrpcTest_Success()
        {
            DsiCircuitOptionGrpcRequest reasonGrpcRequest = new DsiCircuitOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCircuitOptionGrpc));
            Task<ListDsiCircuitOptionGrpc> getDsiCircuitOptionGrpcReply = _GrpcService.ReadDsiCircuitOptionGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCircuitOptionGrpcReply.Result.DsiCircuitOptionGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCircuitOptionGrpcReply.Result.DsiCircuitOptionGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCircuitOptionGrpcByRowIdTest_Success()
        {
            DsiCircuitOptionGrpcRequest reasonGrpcRequest = new DsiCircuitOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCircuitOptionGrpc));
            Task<ListDsiCircuitOptionGrpc> getDsiCircuitOptionByRowIdReply = _GrpcService.ReadDsiCircuitOptionGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCircuitOptionByRowIdReply.Result.DsiCircuitOptionGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiCircuitOptionByRowIdReply.Result.DsiCircuitOptionGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedCircuitOption");
            Assert.That(getDsiCircuitOptionByRowIdReply.Result.DsiCircuitOptionGrpcs.First().OptionName, reasonConstraint);
        }

        [Test]
        public void GetDsiCircuitOptionGrpcByRowIdTest_Fails()
        {
            DsiCircuitOptionGrpcRequest reasonGrpcRequest = new DsiCircuitOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCircuitOptionGrpc));
            Task<ListDsiCircuitOptionGrpc> getDsiCircuitOptionByRowIdReply = _GrpcService.ReadDsiCircuitOptionGrpc(reasonGrpcRequest, serverCallContext);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCircuitOptionByRowIdReply.Result.DsiCircuitOptionGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarness
        [Test]
        public void GetDsiHarnessGrpcTest_Success()
        {
            DsiHarnessGrpcRequest reasonGrpcRequest = new DsiHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessGrpc));

            Task<ListDsiHarnessGrpc> getDsiHarnessGrpcReply = _GrpcService.ReadDsiHarnessGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiHarnessGrpcReply.Result.DsiHarnessGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiHarnessGrpcReply.Result.DsiHarnessGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiHarnessGrpcByRowIdTest_Success()
        {
            DsiHarnessGrpcRequest reasonGrpcRequest = new DsiHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessGrpc));

            Task<ListDsiHarnessGrpc> getDsiHarnessByRowIdReply = _GrpcService.ReadDsiHarnessGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiHarnessByRowIdReply.Result.DsiHarnessGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiHarnessByRowIdReply.Result.DsiHarnessGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(getDsiHarnessByRowIdReply.Result.DsiHarnessGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiHarnessGrpcByRowIdTest_Fails()
        {
            DsiHarnessGrpcRequest reasonGrpcRequest = new DsiHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessGrpc));

            Task<ListDsiHarnessGrpc> getDsiHarnessByRowIdReply = _GrpcService.ReadDsiHarnessGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiHarnessByRowIdReply.Result.DsiHarnessGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeDetail
        [Test]
        public void GetDsiCompositeDetailGrpcTest_Success()
        {
            DsiCompositeDetailGrpcRequest reasonGrpcRequest = new DsiCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailGrpc));

            Task<ListDsiCompositeDetailGrpc> getDsiCompositeDetailGrpcReply = _GrpcService.ReadDsiCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCompositeDetailGrpcReply.Result.DsiCompositeDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCompositeDetailGrpcReply.Result.DsiCompositeDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailGrpcByRowIdTest_Success()
        {
            DsiCompositeDetailGrpcRequest reasonGrpcRequest = new DsiCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailGrpc));

            Task<ListDsiCompositeDetailGrpc> getDsiCompositeDetailByRowIdReply = _GrpcService.ReadDsiCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiCompositeDetailByRowIdReply.Result.DsiCompositeDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiCompositeDetailByRowIdReply.Result.DsiCompositeDetailGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(getDsiCompositeDetailByRowIdReply.Result.DsiCompositeDetailGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailGrpcByRowIdTest_Fails()
        {
            DsiCompositeDetailGrpcRequest reasonGrpcRequest = new DsiCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailGrpc));

            Task<ListDsiCompositeDetailGrpc> getDsiCompositeDetailByRowIdReply = _GrpcService.ReadDsiCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCompositeDetailByRowIdReply.Result.DsiCompositeDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcTest_Success()
        {
            DsiCompositeDetailCircuitOptionAssociationGrpcRequest reasonGrpcRequest = new DsiCompositeDetailCircuitOptionAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc));

            Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> getReply = _GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcByRowIdTest_Success()
        {
            DsiCompositeDetailCircuitOptionAssociationGrpcRequest reasonGrpcRequest = new DsiCompositeDetailCircuitOptionAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc));

            Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcByRowIdTest_Fails()
        {
            DsiCompositeDetailCircuitOptionAssociationGrpcRequest reasonGrpcRequest = new DsiCompositeDetailCircuitOptionAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc));

            Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiModuleChildDetail
        [Test]
        public void GetDsiModuleChildDetailGrpcTest_Success()
        {
            DsiModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleChildDetailGrpc));

            Task<ListDsiModuleChildDetailGrpc> getReply = _GrpcService.ReadDsiModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiModuleChildDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiModuleChildDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiModuleChildDetailGrpcByRowIdTest_Success()
        {
            DsiModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleChildDetailGrpc));

            Task<ListDsiModuleChildDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiModuleChildDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiModuleChildDetailGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedModule");
            Assert.That(getByRowIdReply.Result.DsiModuleChildDetailGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void GetDsiModuleChildDetailGrpcByRowIdTest_Fails()
        {
            DsiModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleChildDetailGrpc));

            Task<ListDsiModuleChildDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiModuleChildDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCentreStrip
        [Test]
        public void GetDsiCentreStripGrpcTest_Success()
        {
            DsiCentreStripGrpcRequest reasonGrpcRequest = new DsiCentreStripGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCentreStripGrpc));

            Task<ListDsiCentreStripGrpc> getDsiCentreStripGrpcReply = _GrpcService.ReadDsiCentreStripGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCentreStripGrpcReply.Result.DsiCentreStripGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCentreStripGrpcReply.Result.DsiCentreStripGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCentreStripGrpcByRowIdTest_Success()
        {
            DsiCentreStripGrpcRequest reasonGrpcRequest = new DsiCentreStripGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCentreStripGrpc));

            Task<ListDsiCentreStripGrpc> getDsiCentreStripByRowIdReply = _GrpcService.ReadDsiCentreStripGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiCentreStripByRowIdReply.Result.DsiCentreStripGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiCentreStripByRowIdReply.Result.DsiCentreStripGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(getDsiCentreStripByRowIdReply.Result.DsiCentreStripGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiCentreStripGrpcByRowIdTest_Fails()
        {
            DsiCentreStripGrpcRequest reasonGrpcRequest = new DsiCentreStripGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCentreStripGrpc));

            Task<ListDsiCentreStripGrpc> getDsiCentreStripByRowIdReply = _GrpcService.ReadDsiCentreStripGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCentreStripByRowIdReply.Result.DsiCentreStripGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiComponent
        [Test]
        public void GetDsiComponentGrpcTest_Success()
        {
            DsiComponentGrpcRequest reasonGrpcRequest = new DsiComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiComponentGrpc));

            Task<ListDsiComponentGrpc> getDsiComponentGrpcReply = _GrpcService.ReadDsiComponentGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiComponentGrpcReply.Result.DsiComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiComponentGrpcReply.Result.DsiComponentGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiComponentGrpcByRowIdTest_Success()
        {
            DsiComponentGrpcRequest reasonGrpcRequest = new DsiComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiComponentGrpc));

            Task<ListDsiComponentGrpc> getDsiComponentByRowIdReply = _GrpcService.ReadDsiComponentGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiComponentByRowIdReply.Result.DsiComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiComponentByRowIdReply.Result.DsiComponentGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(getDsiComponentByRowIdReply.Result.DsiComponentGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiComponentGrpcByRowIdTest_Fails()
        {
            DsiComponentGrpcRequest reasonGrpcRequest = new DsiComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiComponentGrpc));

            Task<ListDsiComponentGrpc> getDsiComponentByRowIdReply = _GrpcService.ReadDsiComponentGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiComponentByRowIdReply.Result.DsiComponentGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeOption
        [Test]
        public void GetDsiCompositeOptionGrpcTest_Success()
        {
            DsiCompositeOptionGrpcRequest reasonGrpcRequest = new DsiCompositeOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeOptionGrpc));

            Task<ListDsiCompositeOptionGrpc> getDsiCompositeOptionGrpcReply = _GrpcService.ReadDsiCompositeOptionGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCompositeOptionGrpcReply.Result.DsiCompositeOptionGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCompositeOptionGrpcReply.Result.DsiCompositeOptionGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeOptionGrpcByRowIdTest_Success()
        {
            DsiCompositeOptionGrpcRequest reasonGrpcRequest = new DsiCompositeOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeOptionGrpc));

            Task<ListDsiCompositeOptionGrpc> getDsiCompositeOptionByRowIdReply = _GrpcService.ReadDsiCompositeOptionGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiCompositeOptionByRowIdReply.Result.DsiCompositeOptionGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiCompositeOptionByRowIdReply.Result.DsiCompositeOptionGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedCompositeOption");
            Assert.That(getDsiCompositeOptionByRowIdReply.Result.DsiCompositeOptionGrpcs.First().OptionName, reasonConstraint);
        }

        [Test]
        public void GetDsiCompositeOptionGrpcByRowIdTest_Fails()
        {
            DsiCompositeOptionGrpcRequest reasonGrpcRequest = new DsiCompositeOptionGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeOptionGrpc));

            Task<ListDsiCompositeOptionGrpc> getDsiCompositeOptionByRowIdReply = _GrpcService.ReadDsiCompositeOptionGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCompositeOptionByRowIdReply.Result.DsiCompositeOptionGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarnessScope
        [Test]
        public void GetDsiHarnessScopeGrpcTest_Success()
        {
            DsiHarnessScopeGrpcRequest reasonGrpcRequest = new DsiHarnessScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeGrpc));

            Task<ListDsiHarnessScopeGrpc> getDsiHarnessScopeGrpcReply = _GrpcService.ReadDsiHarnessScopeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiHarnessScopeGrpcReply.Result.DsiHarnessScopeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiHarnessScopeGrpcReply.Result.DsiHarnessScopeGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiHarnessScopeGrpcByRowIdTest_Success()
        {
            DsiHarnessScopeGrpcRequest reasonGrpcRequest = new DsiHarnessScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeGrpc));

            Task<ListDsiHarnessScopeGrpc> getDsiHarnessScopeByRowIdReply = _GrpcService.ReadDsiHarnessScopeGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiHarnessScopeByRowIdReply.Result.DsiHarnessScopeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiHarnessScopeByRowIdReply.Result.DsiHarnessScopeGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(getDsiHarnessScopeByRowIdReply.Result.DsiHarnessScopeGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiHarnessScopeGrpcByRowIdTest_Fails()
        {
            DsiHarnessScopeGrpcRequest reasonGrpcRequest = new DsiHarnessScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeGrpc));

            Task<ListDsiHarnessScopeGrpc> getDsiHarnessScopeByRowIdReply = _GrpcService.ReadDsiHarnessScopeGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiHarnessScopeByRowIdReply.Result.DsiHarnessScopeGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarnessScopeScopeAssociation
        [Test]
        public void GetDsiHarnessScopeScopeAssociationGrpcTest_Success()
        {
            DsiHarnessScopeScopeAssociationGrpcRequest reasonGrpcRequest = new DsiHarnessScopeScopeAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc));

            Task<ListDsiHarnessScopeScopeAssociationGrpc> getReply = _GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiHarnessScopeScopeAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiHarnessScopeScopeAssociationGrpcByRowIdTest_Success()
        {
            DsiHarnessScopeScopeAssociationGrpcRequest reasonGrpcRequest = new DsiHarnessScopeScopeAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc));

            Task<ListDsiHarnessScopeScopeAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiHarnessScopeScopeAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiHarnessScopeScopeAssociationGrpcByRowIdTest_Fails()
        {
            DsiHarnessScopeScopeAssociationGrpcRequest reasonGrpcRequest = new DsiHarnessScopeScopeAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc));

            Task<ListDsiHarnessScopeScopeAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiManualBomQuantity
        [Test]
        public void GetDsiManualBomQuantityGrpcTest_Success()
        {
            DsiManualBomQuantityGrpcRequest reasonGrpcRequest = new DsiManualBomQuantityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiManualBomQuantityGrpc));

            Task<ListDsiManualBomQuantityGrpc> getDsiManualBomQuantityGrpcReply = _GrpcService.ReadDsiManualBomQuantityGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiManualBomQuantityGrpcReply.Result.DsiManualBomQuantityGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiManualBomQuantityGrpcReply.Result.DsiManualBomQuantityGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiManualBomQuantityGrpcByRowIdTest_Success()
        {
            DsiManualBomQuantityGrpcRequest reasonGrpcRequest = new DsiManualBomQuantityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiManualBomQuantityGrpc));

            Task<ListDsiManualBomQuantityGrpc> getDsiManualBomQuantityByRowIdReply = _GrpcService.ReadDsiManualBomQuantityGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiManualBomQuantityByRowIdReply.Result.DsiManualBomQuantityGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiManualBomQuantityByRowIdReply.Result.DsiManualBomQuantityGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedModule");
            Assert.That(getDsiManualBomQuantityByRowIdReply.Result.DsiManualBomQuantityGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void GetDsiManualBomQuantityGrpcByRowIdTest_Fails()
        {
            DsiManualBomQuantityGrpcRequest reasonGrpcRequest = new DsiManualBomQuantityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiManualBomQuantityGrpc));

            Task<ListDsiManualBomQuantityGrpc> getDsiManualBomQuantityByRowIdReply = _GrpcService.ReadDsiManualBomQuantityGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiManualBomQuantityByRowIdReply.Result.DsiManualBomQuantityGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiMidWireComponent
        [Test]
        public void GetDsiMidWireComponentGrpcTest_Success()
        {
            DsiMidWireComponentGrpcRequest reasonGrpcRequest = new DsiMidWireComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMidWireComponentGrpc));

            Task<ListDsiMidWireComponentGrpc> getDsiMidWireComponentGrpcReply = _GrpcService.ReadDsiMidWireComponentGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiMidWireComponentGrpcReply.Result.DsiMidWireComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiMidWireComponentGrpcReply.Result.DsiMidWireComponentGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiMidWireComponentGrpcByRowIdTest_Success()
        {
            DsiMidWireComponentGrpcRequest reasonGrpcRequest = new DsiMidWireComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMidWireComponentGrpc));

            Task<ListDsiMidWireComponentGrpc> getDsiMidWireComponentByRowIdReply = _GrpcService.ReadDsiMidWireComponentGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiMidWireComponentByRowIdReply.Result.DsiMidWireComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiMidWireComponentByRowIdReply.Result.DsiMidWireComponentGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(getDsiMidWireComponentByRowIdReply.Result.DsiMidWireComponentGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiMidWireComponentGrpcByRowIdTest_Fails()
        {
            DsiMidWireComponentGrpcRequest reasonGrpcRequest = new DsiMidWireComponentGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMidWireComponentGrpc));

            Task<ListDsiMidWireComponentGrpc> getDsiMidWireComponentByRowIdReply = _GrpcService.ReadDsiMidWireComponentGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiMidWireComponentByRowIdReply.Result.DsiMidWireComponentGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiModuleCompatibility
        [Test]
        public void GetDsiModuleCompatibilityGrpcTest_Success()
        {
            DsiModuleCompatibilityGrpcRequest reasonGrpcRequest = new DsiModuleCompatibilityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleCompatibilityGrpc));

            Task<ListDsiModuleCompatibilityGrpc> getDsiModuleCompatibilityGrpcReply = _GrpcService.ReadDsiModuleCompatibilityGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiModuleCompatibilityGrpcReply.Result.DsiModuleCompatibilityGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiModuleCompatibilityGrpcReply.Result.DsiModuleCompatibilityGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiModuleCompatibilityGrpcByRowIdTest_Success()
        {
            DsiModuleCompatibilityGrpcRequest reasonGrpcRequest = new DsiModuleCompatibilityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleCompatibilityGrpc));

            Task<ListDsiModuleCompatibilityGrpc> getDsiModuleCompatibilityByRowIdReply = _GrpcService.ReadDsiModuleCompatibilityGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiModuleCompatibilityByRowIdReply.Result.DsiModuleCompatibilityGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiModuleCompatibilityByRowIdReply.Result.DsiModuleCompatibilityGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedRelationship");
            Assert.That(getDsiModuleCompatibilityByRowIdReply.Result.DsiModuleCompatibilityGrpcs.First().Relationship, reasonConstraint);
        }

        [Test]
        public void GetDsiModuleCompatibilityGrpcByRowIdTest_Fails()
        {
            DsiModuleCompatibilityGrpcRequest reasonGrpcRequest = new DsiModuleCompatibilityGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleCompatibilityGrpc));

            Task<ListDsiModuleCompatibilityGrpc> getDsiModuleCompatibilityByRowIdReply = _GrpcService.ReadDsiModuleCompatibilityGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiModuleCompatibilityByRowIdReply.Result.DsiModuleCompatibilityGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiMulticoreSpecification
        [Test]
        public void GetDsiMulticoreSpecificationGrpcTest_Success()
        {
            DsiMulticoreSpecificationGrpcRequest reasonGrpcRequest = new DsiMulticoreSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMulticoreSpecificationGrpc));

            Task<ListDsiMulticoreSpecificationGrpc> getReply = _GrpcService.ReadDsiMulticoreSpecificationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiMulticoreSpecificationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiMulticoreSpecificationGrpcByRowIdTest_Success()
        {
            DsiMulticoreSpecificationGrpcRequest reasonGrpcRequest = new DsiMulticoreSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMulticoreSpecificationGrpc));

            Task<ListDsiMulticoreSpecificationGrpc> getByRowIdReply = _GrpcService.ReadDsiMulticoreSpecificationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiMulticoreSpecificationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedMulticore");
            Assert.That(getByRowIdReply.Result.DsiMulticoreSpecificationGrpcs.First().MulticoreName, reasonConstraint);
        }

        [Test]
        public void GetDsiMulticoreSpecificationGrpcByRowIdTest_Fails()
        {
            DsiMulticoreSpecificationGrpcRequest reasonGrpcRequest = new DsiMulticoreSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMulticoreSpecificationGrpc));

            Task<ListDsiMulticoreSpecificationGrpc> getByRowIdReply = _GrpcService.ReadDsiMulticoreSpecificationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiPinMapping
        [Test]
        public void GetDsiPinMappingGrpcTest_Success()
        {
            DsiPinMappingGrpcRequest reasonGrpcRequest = new DsiPinMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingGrpc));

            Task<ListDsiPinMappingGrpc> getDsiPinMappingGrpcReply = _GrpcService.ReadDsiPinMappingGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiPinMappingGrpcReply.Result.DsiPinMappingGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiPinMappingGrpcReply.Result.DsiPinMappingGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiPinMappingGrpcByRowIdTest_Success()
        {
            DsiPinMappingGrpcRequest reasonGrpcRequest = new DsiPinMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingGrpc));

            Task<ListDsiPinMappingGrpc> getDsiPinMappingByRowIdReply = _GrpcService.ReadDsiPinMappingGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiPinMappingByRowIdReply.Result.DsiPinMappingGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiPinMappingByRowIdReply.Result.DsiPinMappingGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedNodeA");
            Assert.That(getDsiPinMappingByRowIdReply.Result.DsiPinMappingGrpcs.First().Node1, reasonConstraint);
        }

        [Test]
        public void GetDsiPinMappingGrpcByRowIdTest_Fails()
        {
            DsiPinMappingGrpcRequest reasonGrpcRequest = new DsiPinMappingGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingGrpc));

            Task<ListDsiPinMappingGrpc> getDsiPinMappingByRowIdReply = _GrpcService.ReadDsiPinMappingGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiPinMappingByRowIdReply.Result.DsiPinMappingGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        [Test]
        public void GetDsiPinMappingCavityMappingAssociationGrpcTest_Success()
        {
            DsiPinMappingCavityMappingAssociationGrpcRequest reasonGrpcRequest = new DsiPinMappingCavityMappingAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc));

            Task<ListDsiPinMappingCavityMappingAssociationGrpc> getReply = _GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiPinMappingCavityMappingAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiPinMappingCavityMappingAssociationGrpcByRowIdTest_Success()
        {
            DsiPinMappingCavityMappingAssociationGrpcRequest reasonGrpcRequest = new DsiPinMappingCavityMappingAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc));

            Task<ListDsiPinMappingCavityMappingAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiPinMappingCavityMappingAssociationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo(999);
            Assert.That(getByRowIdReply.Result.DsiPinMappingCavityMappingAssociationGrpcs.First().MappingNumber, reasonConstraint);
        }

        [Test]
        public void GetDsiPinMappingCavityMappingAssociationGrpcByRowIdTest_Fails()
        {
            DsiPinMappingCavityMappingAssociationGrpcRequest reasonGrpcRequest = new DsiPinMappingCavityMappingAssociationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc));

            Task<ListDsiPinMappingCavityMappingAssociationGrpc> getByRowIdReply = _GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiScope
        [Test]
        public void GetDsiScopeGrpcTest_Success()
        {
            DsiScopeGrpcRequest reasonGrpcRequest = new DsiScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiScopeGrpc));

            Task<ListDsiScopeGrpc> getDsiScopeGrpcReply = _GrpcService.ReadDsiScopeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiScopeGrpcReply.Result.DsiScopeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiScopeGrpcReply.Result.DsiScopeGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiScopeGrpcByRowIdTest_Success()
        {
            DsiScopeGrpcRequest reasonGrpcRequest = new DsiScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiScopeGrpc));

            Task<ListDsiScopeGrpc> getDsiScopeByRowIdReply = _GrpcService.ReadDsiScopeGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiScopeByRowIdReply.Result.DsiScopeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiScopeByRowIdReply.Result.DsiScopeGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedScope");
            Assert.That(getDsiScopeByRowIdReply.Result.DsiScopeGrpcs.First().Scope, reasonConstraint);
        }

        [Test]
        public void GetDsiScopeGrpcByRowIdTest_Fails()
        {
            DsiScopeGrpcRequest reasonGrpcRequest = new DsiScopeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiScopeGrpc));

            Task<ListDsiScopeGrpc> getDsiScopeByRowIdReply = _GrpcService.ReadDsiScopeGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiScopeByRowIdReply.Result.DsiScopeGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiSupplier
        [Test]
        public void GetDsiSupplierGrpcTest_Success()
        {
            DsiSupplierGrpcRequest reasonGrpcRequest = new DsiSupplierGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiSupplierGrpc));

            Task<ListDsiSupplierGrpc> getDsiSupplierGrpcReply = _GrpcService.ReadDsiSupplierGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiSupplierGrpcReply.Result.DsiSupplierGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiSupplierGrpcReply.Result.DsiSupplierGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiSupplierGrpcByRowIdTest_Success()
        {
            DsiSupplierGrpcRequest reasonGrpcRequest = new DsiSupplierGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiSupplierGrpc));

            Task<ListDsiSupplierGrpc> getDsiSupplierByRowIdReply = _GrpcService.ReadDsiSupplierGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getDsiSupplierByRowIdReply.Result.DsiSupplierGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getDsiSupplierByRowIdReply.Result.DsiSupplierGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedSupplier");
            Assert.That(getDsiSupplierByRowIdReply.Result.DsiSupplierGrpcs.First().Name, reasonConstraint);
        }

        [Test]
        public void GetDsiSupplierGrpcByRowIdTest_Fails()
        {
            DsiSupplierGrpcRequest reasonGrpcRequest = new DsiSupplierGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiSupplierGrpc));

            Task<ListDsiSupplierGrpc> getDsiSupplierByRowIdReply = _GrpcService.ReadDsiSupplierGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiSupplierByRowIdReply.Result.DsiSupplierGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedCompositeDetail
        [Test]
        public void GetDsiTransformedCompositeDetailGrpcTest_Success()
        {
            DsiTransformedCompositeDetailGrpcRequest reasonGrpcRequest = new DsiTransformedCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedCompositeDetailGrpc));

            Task<ListDsiTransformedCompositeDetailGrpc> getReply = _GrpcService.ReadDsiTransformedCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedCompositeDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiTransformedCompositeDetailGrpcByRowIdTest_Success()
        {
            DsiTransformedCompositeDetailGrpcRequest reasonGrpcRequest = new DsiTransformedCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 2;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedCompositeDetailGrpc));

            Task<ListDsiTransformedCompositeDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiTransformedCompositeDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("HarnessA2");
            Assert.That(getByRowIdReply.Result.DsiTransformedCompositeDetailGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiTransformedCompositeDetailGrpcByRowIdTest_Fails()
        {
            DsiTransformedCompositeDetailGrpcRequest reasonGrpcRequest = new DsiTransformedCompositeDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedCompositeDetailGrpc));

            Task<ListDsiTransformedCompositeDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedHarness
        [Test]
        public void GetDsiTransformedHarnessGrpcTest_Success()
        {
            DsiTransformedHarnessGrpcRequest reasonGrpcRequest = new DsiTransformedHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedHarnessGrpc));

            Task<ListDsiTransformedHarnessGrpc> getReply = _GrpcService.ReadDsiTransformedHarnessGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedHarnessGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedHarnessGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiTransformedHarnessGrpcByRowIdTest_Success()
        {
            DsiTransformedHarnessGrpcRequest reasonGrpcRequest = new DsiTransformedHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 2;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedHarnessGrpc));

            Task<ListDsiTransformedHarnessGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedHarnessGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiTransformedHarnessGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiTransformedHarnessGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("HarnessA2");
            Assert.That(getByRowIdReply.Result.DsiTransformedHarnessGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiTransformedHarnessGrpcByRowIdTest_Fails()
        {
            DsiTransformedHarnessGrpcRequest reasonGrpcRequest = new DsiTransformedHarnessGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedHarnessGrpc));

            Task<ListDsiTransformedHarnessGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedHarnessGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiTransformedHarnessGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedModuleChildDetail
        [Test]
        public void GetDsiTransformedModuleChildDetailGrpcTest_Success()
        {
            DsiTransformedModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiTransformedModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedModuleChildDetailGrpc));

            Task<ListDsiTransformedModuleChildDetailGrpc> getReply = _GrpcService.ReadDsiTransformedModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedModuleChildDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiTransformedModuleChildDetailGrpcByRowIdTest_Success()
        {
            DsiTransformedModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiTransformedModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 2;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedModuleChildDetailGrpc));

            Task<ListDsiTransformedModuleChildDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiTransformedModuleChildDetailGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("Module2");
            Assert.That(getByRowIdReply.Result.DsiTransformedModuleChildDetailGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void GetDsiTransformedModuleChildDetailGrpcByRowIdTest_Fails()
        {
            DsiTransformedModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiTransformedModuleChildDetailGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedModuleChildDetailGrpc));

            Task<ListDsiTransformedModuleChildDetailGrpc> getByRowIdReply = _GrpcService.ReadDsiTransformedModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiUnitOfMeasure
        [Test]
        public void GetDsiUnitOfMeasureGrpcTest_Success()
        {
            DsiUnitOfMeasureGrpcRequest reasonGrpcRequest = new DsiUnitOfMeasureGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiUnitOfMeasureGrpc));

            Task<ListDsiUnitOfMeasureGrpc> getReply = _GrpcService.ReadDsiUnitOfMeasureGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiUnitOfMeasureGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiUnitOfMeasureGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiUnitOfMeasureGrpcByRowIdTest_Success()
        {
            DsiUnitOfMeasureGrpcRequest reasonGrpcRequest = new DsiUnitOfMeasureGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiUnitOfMeasureGrpc));

            Task<ListDsiUnitOfMeasureGrpc> getByRowIdReply = _GrpcService.ReadDsiUnitOfMeasureGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiUnitOfMeasureGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiUnitOfMeasureGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FIX");
            Assert.That(getByRowIdReply.Result.DsiUnitOfMeasureGrpcs.First().Abbreviation, reasonConstraint);
        }

        [Test]
        public void GetDsiUnitOfMeasureGrpcByRowIdTest_Fails()
        {
            DsiUnitOfMeasureGrpcRequest reasonGrpcRequest = new DsiUnitOfMeasureGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiUnitOfMeasureGrpc));

            Task<ListDsiUnitOfMeasureGrpc> getByRowIdReply = _GrpcService.ReadDsiUnitOfMeasureGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiUnitOfMeasureGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireMulticoreMarker
        [Test]
        public void GetDsiWireMulticoreMarkerGrpcTest_Success()
        {
            DsiWireMulticoreMarkerGrpcRequest reasonGrpcRequest = new DsiWireMulticoreMarkerGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireMulticoreMarkerGrpc));

            Task<ListDsiWireMulticoreMarkerGrpc> getReply = _GrpcService.ReadDsiWireMulticoreMarkerGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireMulticoreMarkerGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiWireMulticoreMarkerGrpcByRowIdTest_Success()
        {
            DsiWireMulticoreMarkerGrpcRequest reasonGrpcRequest = new DsiWireMulticoreMarkerGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 6;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireMulticoreMarkerGrpc));

            Task<ListDsiWireMulticoreMarkerGrpc> getByRowIdReply = _GrpcService.ReadDsiWireMulticoreMarkerGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiWireMulticoreMarkerGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("FixedItem");
            Assert.That(getByRowIdReply.Result.DsiWireMulticoreMarkerGrpcs.First().ItemName, reasonConstraint);
        }

        [Test]
        public void GetDsiWireMulticoreMarkerGrpcByRowIdTest_Fails()
        {
            DsiWireMulticoreMarkerGrpcRequest reasonGrpcRequest = new DsiWireMulticoreMarkerGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireMulticoreMarkerGrpc));

            Task<ListDsiWireMulticoreMarkerGrpc> getByRowIdReply = _GrpcService.ReadDsiWireMulticoreMarkerGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireSpecification
        [Test]
        public void GetDsiWireSpecificationGrpcTest_Success()
        {
            DsiWireSpecificationGrpcRequest reasonGrpcRequest = new DsiWireSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireSpecificationGrpc));

            Task<ListDsiWireSpecificationGrpc> getReply = _GrpcService.ReadDsiWireSpecificationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireSpecificationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiWireSpecificationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiWireSpecificationGrpcByRowIdTest_Success()
        {
            DsiWireSpecificationGrpcRequest reasonGrpcRequest = new DsiWireSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 2;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireSpecificationGrpc));

            Task<ListDsiWireSpecificationGrpc> getByRowIdReply = _GrpcService.ReadDsiWireSpecificationGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiWireSpecificationGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiWireSpecificationGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("Wire2");
            Assert.That(getByRowIdReply.Result.DsiWireSpecificationGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiWireSpecificationGrpcByRowIdTest_Fails()
        {
            DsiWireSpecificationGrpcRequest reasonGrpcRequest = new DsiWireSpecificationGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireSpecificationGrpc));

            Task<ListDsiWireSpecificationGrpc> getByRowIdReply = _GrpcService.ReadDsiWireSpecificationGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiWireSpecificationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireThroughNode
        [Test]
        public void GetDsiWireThroughNodeGrpcTest_Success()
        {
            DsiWireThroughNodeGrpcRequest reasonGrpcRequest = new DsiWireThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            reasonGrpcRequest.GrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireThroughNodeGrpc));

            Task<ListDsiWireThroughNodeGrpc> getReply = _GrpcService.ReadDsiWireThroughNodeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireThroughNodeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiWireThroughNodeGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiWireThroughNodeGrpcByRowIdTest_Success()
        {
            DsiWireThroughNodeGrpcRequest reasonGrpcRequest = new DsiWireThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = 2;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireThroughNodeGrpc));

            Task<ListDsiWireThroughNodeGrpc> getByRowIdReply = _GrpcService.ReadDsiWireThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getByRowIdReply.Result.DsiWireThroughNodeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getByRowIdReply.Result.DsiWireThroughNodeGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint reasonConstraint = Is.EqualTo("Wire2");
            Assert.That(getByRowIdReply.Result.DsiWireThroughNodeGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiWireThroughNodeGrpcByRowIdTest_Fails()
        {
            DsiWireThroughNodeGrpcRequest reasonGrpcRequest = new DsiWireThroughNodeGrpcRequest();
            GrpcRequestParameter requestParameter = new GrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.ReadByRowId;
            requestParameter.IntValue = int.MaxValue;
            reasonGrpcRequest.GrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireThroughNodeGrpc));

            Task<ListDsiWireThroughNodeGrpc> getByRowIdReply = _GrpcService.ReadDsiWireThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getByRowIdReply.Result.DsiWireThroughNodeGrpcs.Count, countConstraint);
        }
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

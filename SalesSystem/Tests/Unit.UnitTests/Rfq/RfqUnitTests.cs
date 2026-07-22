using Rfq;
using Rfq.Endpoints.GrpcServices;
using Rfq.Enums;
using Rfq.Services;

namespace Unit.Tests.Rfq
{
    class RfqUnitTests
    {
        RfqAccessService _RfqAccessService;
        RfqGrpcService _GrpcService;
        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            Mock<ILogger<RfqAccessService>> logger = new Mock<ILogger<RfqAccessService>>();
            _RfqAccessService = new RfqAccessService(serviceProvider, logger.Object, true);
            Mock<ILogger<RfqGrpcService>> logger2 = new Mock<ILogger<RfqGrpcService>>();
            _GrpcService = new RfqGrpcService(_RfqAccessService, logger2.Object);
        }

        [Test]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        #region RfqDrawingPartNumber
        [Test]
        public void GetRfqDrawingPartNumbersGrpcTest_Success()
        {
            RfqDrawingPartNumbersGrpcRequest drawingPartNumbersGrpcRequest = new RfqDrawingPartNumbersGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            drawingPartNumbersGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            drawingPartNumbersGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqDrawingPartNumbersGrpc));

            Task<ListRfqDrawingPartNumbersGrpc> getRfqDrawingPartNumbersGrpcReply = _GrpcService.ReadRfqDrawingPartNumbersGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqDrawingPartNumbersGrpcReply.Result.RfqDrawingPartNumbers.Count, countConstraint);

        }

        [Test]
        public void FilterRfqDrawingPartNumbersGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqDrawingPartNumbersGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> reply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(reply.Result.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(reply.Result.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TestOriginalPartNumber");
            Assert.That(reply.Result.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.First().OriginalPartNumber, nameConstraint);
        }
        [Test]
        public void FilterRfqDrawingPartNumbersGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqDrawingPartNumbersGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> reply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);
            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(reply.Result.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Count, countConstraint);
        }
        #endregion

        #region RfqProject
        [Test]
        public void GetRfqProjectGrpcTest_Success()
        {
            RfqProjectGrpcRequest drawingPartNumbersGrpcRequest = new RfqProjectGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = ((int)RequestType.Read);
            drawingPartNumbersGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqProjectGrpc));

            Task<ListRfqProjectGrpc> getRfqProjectGrpcReply = _GrpcService.ReadRfqProjectGrpc(drawingPartNumbersGrpcRequest, serverCallContext);
            Assert.That(getRfqProjectGrpcReply.Result.RfqProjects, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqProjectGrpcReply.Result.RfqProjects.Count, countConstraint);

        }

        [Test]
        public void FilterRfqProjectGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqProjectGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqProjectByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterRfqProjectByRowIdReply.Result.ListRfqProjectGrpc.RfqProjects, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterRfqProjectByRowIdReply.Result.ListRfqProjectGrpc.RfqProjects.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TestProjectGuid");
            Assert.That(filterRfqProjectByRowIdReply.Result.ListRfqProjectGrpc.RfqProjects.First().ProjectGuid, nameConstraint);
        }

        [Test]
        public void GetRfqProjectGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqProjectGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqProjectByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterRfqProjectByRowIdReply.Result.ListRfqProjectGrpc.RfqProjects.Count, countConstraint);
        }
        #endregion

        #region RfqNotes
        [Test]
        public void GetRfqNotesGrpcTest_Success()
        {
            RfqNotesGrpcRequest notesGrpcRequest = new RfqNotesGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            notesGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqNotesGrpc));

            Task<ListRfqNotesGrpc> getRfqNotesGrpcReply = _GrpcService.ReadRfqNotesGrpc(notesGrpcRequest, serverCallContext);
            Assert.That(getRfqNotesGrpcReply.Result.RfqNotes, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqNotesGrpcReply.Result.RfqNotes.Count, countConstraint);

        }

        [Test]
        public void GetRfqNotesGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqNotesGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqNotesByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterRfqNotesByRowIdReply.Result.ListRfqNotesGrpc.RfqNotes, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterRfqNotesByRowIdReply.Result.ListRfqNotesGrpc.RfqNotes.Count, countConstraint);
            EqualConstraint noteConstraint = Is.EqualTo("TestNote");
            Assert.That(filterRfqNotesByRowIdReply.Result.ListRfqNotesGrpc.RfqNotes.First().Note, noteConstraint);
        }

        [Test]
        public void GetRfqNotesGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqNotesGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqNotesByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterRfqNotesByRowIdReply.Result.ListRfqNotesGrpc.RfqNotes.Count, countConstraint);
        }
        #endregion

        #region RfqReason
        [Test]
        public void GetRfqReasonGrpcTest_Success()
        {
            RfqReasonGrpcRequest reasonGrpcRequest = new RfqReasonGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqReasonGrpc));

            Task<ListRfqReasonGrpc> getRfqReasonGrpcReply = _GrpcService.ReadRfqReasonGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getRfqReasonGrpcReply.Result.RfqReasons, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getRfqReasonGrpcReply.Result.RfqReasons.Count, countConstraint);

        }

        [Test]
        public void GetRfqReasonGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqReasonGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqReasonByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterRfqReasonByRowIdReply.Result.ListRfqReasonGrpc.RfqReasons, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterRfqReasonByRowIdReply.Result.ListRfqReasonGrpc.RfqReasons.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("TestReasonTitle");
            Assert.That(filterRfqReasonByRowIdReply.Result.ListRfqReasonGrpc.RfqReasons.First().ReasonTitle, reasonConstraint);
        }

        [Test]
        public void GetRfqReasonGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqReasonGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterRfqReasonByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterRfqReasonByRowIdReply.Result.ListRfqReasonGrpc.RfqReasons.Count, countConstraint);
        }

        #endregion

        #region DsiBend
        [Test]
        public void GetDsiBendGrpcTest_Success()
        {
            DsiBendGrpcRequest reasonGrpcRequest = new DsiBendGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBendGrpc));

            Task<ListDsiBendGrpc> getDsiBendGrpcReply = _GrpcService.ReadDsiBendGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBendGrpcReply.Result.DsiBends, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBendGrpcReply.Result.DsiBends.Count, countConstraint);

        }

        [Test]
        public void FilterDsiBendGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBendGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBendByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiBendByRowIdReply.Result.ListDsiBendGrpc.DsiBends, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiBendByRowIdReply.Result.ListDsiBendGrpc.DsiBends.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedBend");
            Assert.That(filterDsiBendByRowIdReply.Result.ListDsiBendGrpc.DsiBends.First().Bend, reasonConstraint);
        }

        [Test]
        public void GetDsiBendGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBendGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> getDsiBendByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiBendByRowIdReply.Result.ListDsiBendGrpc.DsiBends.Count, countConstraint);
        }
        #endregion

        #region DsiBranchConfiguration
        [Test]
        public void FilterDsiBranchConfigurationGrpcTest_Success()
        {
            DsiBranchConfigurationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationGrpc));

            Task<ListDsiBranchConfigurationGrpc> filterDsiBranchConfigurationGrpcReply = _GrpcService.ReadDsiBranchConfigurationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(filterDsiBranchConfigurationGrpcReply.Result.DsiBranchConfigurations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(filterDsiBranchConfigurationGrpcReply.Result.DsiBranchConfigurations.Count, countConstraint);

        }

        [Test]
        public void FilterDsiBranchConfigurationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchConfigurationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchConfigurationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiBranchConfigurationByRowIdReply.Result.ListDsiBranchConfigurationGrpc.DsiBranchConfigurations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiBranchConfigurationByRowIdReply.Result.ListDsiBranchConfigurationGrpc.DsiBranchConfigurations.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("TestUserModule");
            Assert.That(filterDsiBranchConfigurationByRowIdReply.Result.ListDsiBranchConfigurationGrpc.DsiBranchConfigurations.First().UserModule, reasonConstraint);
        }

        [Test]
        public void FilterDsiBranchConfigurationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchConfigurationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchConfigurationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiBranchConfigurationByRowIdReply.Result.ListDsiBranchConfigurationGrpc.DsiBranchConfigurations.Count, countConstraint);
        }
        #endregion

        #region DsiBranchConfigurationBendAssociation
        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcTest_Success()
        {
            DsiBranchConfigurationBendAssociationGrpcRequest reasonGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc));

            Task<ListDsiBranchConfigurationBendAssociationGrpc> getDsiBranchConfigurationBendAssociationGrpcReply = _GrpcService.ReadDsiBranchConfigurationBendAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchConfigurationBendAssociationGrpcReply.Result.DsiBranchConfigurationBendAssociations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchConfigurationBendAssociationGrpcReply.Result.DsiBranchConfigurationBendAssociations.Count, countConstraint);

        }

        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchConfigurationBendAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchConfigurationBendAssociationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiBranchConfigurationBendAssociationByRowIdReply.Result.ListDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiBranchConfigurationBendAssociationByRowIdReply.Result.ListDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("664c3151-c7fc-4e0e-971c-f1712a6342e1");
            Assert.That(filterDsiBranchConfigurationBendAssociationByRowIdReply.Result.ListDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations.First().BendId, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchConfigurationBendAssociationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchConfigurationBendAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchConfigurationBendAssociationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiBranchConfigurationBendAssociationByRowIdReply.Result.ListDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations.Count, countConstraint);
        }
        #endregion

        #region DsiBranchInsulation
        [Test]
        public void GetDsiBranchInsulationGrpcTest_Success()
        {
            DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationGrpc));

            Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationGrpcReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchInsulationGrpcReply.Result.DsiBranchInsulations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchInsulationGrpcReply.Result.DsiBranchInsulations.Count, countConstraint);

        }

        [Test]
        public void FilterDsiBranchInsulationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchInsulationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchInsulationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiBranchInsulationByRowIdReply.Result.ListDsiBranchInsulationGrpc.DsiBranchInsulations, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiBranchInsulationByRowIdReply.Result.ListDsiBranchInsulationGrpc.DsiBranchInsulations.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedColour");
            Assert.That(filterDsiBranchInsulationByRowIdReply.Result.ListDsiBranchInsulationGrpc.DsiBranchInsulations.First().Colour, reasonConstraint);
        }

        [Test]
        public void GetDsiBranchInsulationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchInsulationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchInsulationByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiBranchInsulationByRowIdReply.Result.ListDsiBranchInsulationGrpc.DsiBranchInsulations.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchInsulationGrpcTest_Success()
        //{
        //    DsiBranchInsulationGrpcRequest reasonGrpcRequest = new DsiBranchInsulationGrpcRequest();
        //    RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
        //    DsiBranchInsulationGrpc bendGrpc = new DsiBranchInsulationGrpc();
        //    reasonGrpcRequest.DsiBranchInsulationGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchInsulationGrpc));
        //    EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchInsulationGrpc> getDsiBranchInsulationByRowIdReply = _GrpcService.ReadDsiBranchInsulationGrpc(reasonGrpcRequest, serverCallContext);

        //    EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchInsulationByRowIdReply.Result.DsiBranchInsulations.Count, countConstraint);
        //}
        #endregion

        #region DsiBranchInsulationThroughNode
        [Test]
        public void GetDsiBranchInsulationThroughNodeGrpcTest_Success()
        {
            DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiBranchInsulationThroughNodeGrpc));

            Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeGrpcReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiBranchInsulationThroughNodeGrpcReply.Result.DsiBranchInsulationThroughNodes, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiBranchInsulationThroughNodeGrpcReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);

        }

        [Test]
        public void FilterDsiBranchInsulationThroughNodeGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchInsulationThroughNodeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiBranchInsulationThroughNodeByRowIdReply.Result.ListDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiBranchInsulationThroughNodeByRowIdReply.Result.ListDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedThroughNode");
            Assert.That(filterDsiBranchInsulationThroughNodeByRowIdReply.Result.ListDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes.First().ThroughNode, reasonConstraint);
        }

        [Test]
        public void FilterDsiBranchInsulationThroughNodeGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiBranchInsulationThroughNodeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiBranchInsulationThroughNodeByRowIdReply.Result.ListDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiBranchInsulationThroughNodeGrpcTest_Success()
        //{
        //    DsiBranchInsulationThroughNodeGrpcRequest reasonGrpcRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
        //    RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
        //    DsiBranchInsulationThroughNodeGrpc bendGrpc = new DsiBranchInsulationThroughNodeGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiBranchInsulationThroughNodeGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiBranchInsulationThroughNodeGrpc));
        //    EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiBranchInsulationThroughNodeGrpc> getDsiBranchInsulationThroughNodeByRowIdReply = _GrpcService.ReadDsiBranchInsulationThroughNodeGrpc(reasonGrpcRequest, serverCallContext);

        //    EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiBranchInsulationThroughNodeByRowIdReply.Result.DsiBranchInsulationThroughNodes.Count, countConstraint);
        //}
        #endregion

        #region DsiCavityMapping
        [Test]
        public void GetDsiCavityMappingGrpcTest_Success()
        {
            DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCavityMappingGrpc));

            Task<ListDsiCavityMappingGrpc> getDsiCavityMappingGrpcReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCavityMappingGrpcReply.Result.DsiCavityMappingGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCavityMappingGrpcReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);

        }

        [Test]
        public void FilterDsiCavityMappingGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCavityMappingGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCavityMappingByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiCavityMappingByRowIdReply.Result.ListDsiCavityMappingGrpc.DsiCavityMappingGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiCavityMappingByRowIdReply.Result.ListDsiCavityMappingGrpc.DsiCavityMappingGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedCavityMapping");
            Assert.That(filterDsiCavityMappingByRowIdReply.Result.ListDsiCavityMappingGrpc.DsiCavityMappingGrpcs.First().CavityMapping, reasonConstraint);
        }

        [Test]
        public void GetDsiCavityMappingGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCavityMappingGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCavityMappingByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiCavityMappingByRowIdReply.Result.ListDsiCavityMappingGrpc.DsiCavityMappingGrpcs.Count, countConstraint);
        }

        //[Test]
        //public void CreateDsiCavityMappingGrpcTest_Success()
        //{
        //    DsiCavityMappingGrpcRequest reasonGrpcRequest = new DsiCavityMappingGrpcRequest();
        //    RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
        //    requestParameter.RequestType = ((int)RequestType.Create);
        //    reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
        //    DsiCavityMappingGrpc bendGrpc = new DsiCavityMappingGrpc();
        //    bendGrpc.Bend = "TestBend";
        //    reasonGrpcRequest.DsiCavityMappingGrpcsToCreate.Add(bendGrpc);
        //    ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateDsiCavityMappingGrpc));
        //    EqualConstraint originalCountConstraint = Is.EqualTo(0);

        //    Task<ListDsiCavityMappingGrpc> getDsiCavityMappingByRowIdReply = _GrpcService.ReadDsiCavityMappingGrpc(reasonGrpcRequest, serverCallContext);

        //    EqualConstraint countConstraint = Is.EqualTo(1);
        //    Assert.That(getDsiCavityMappingByRowIdReply.Result.DsiCavityMappingGrpcs.Count, countConstraint);
        //}
        #endregion

        #region DsiCircuitOption
        [Test]
        public void GetDsiCircuitOptionGrpcTest_Success()
        {
            DsiCircuitOptionGrpcRequest reasonGrpcRequest = new DsiCircuitOptionGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCircuitOptionGrpc));
            Task<ListDsiCircuitOptionGrpc> getDsiCircuitOptionGrpcReply = _GrpcService.ReadDsiCircuitOptionGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCircuitOptionGrpcReply.Result.DsiCircuitOptionGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCircuitOptionGrpcReply.Result.DsiCircuitOptionGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiCircuitOptionGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCircuitOptionGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCircuitOptionByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiCircuitOptionByRowIdReply.Result.ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiCircuitOptionByRowIdReply.Result.ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedCircuitOption");
            Assert.That(filterDsiCircuitOptionByRowIdReply.Result.ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.First().OptionName, reasonConstraint);
        }

        [Test]
        public void FilterDsiCircuitOptionGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCircuitOptionGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCircuitOptionByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiCircuitOptionByRowIdReply.Result.ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarness
        [Test]
        public void GetDsiHarnessGrpcTest_Success()
        {
            DsiHarnessGrpcRequest reasonGrpcRequest = new DsiHarnessGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessGrpc));

            Task<ListDsiHarnessGrpc> getDsiHarnessGrpcReply = _GrpcService.ReadDsiHarnessGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiHarnessGrpcReply.Result.DsiHarnessGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiHarnessGrpcReply.Result.DsiHarnessGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiHarnessGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiHarnessByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiHarnessByRowIdReply.Result.ListDsiHarnessGrpc.DsiHarnessGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiHarnessByRowIdReply.Result.ListDsiHarnessGrpc.DsiHarnessGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(filterDsiHarnessByRowIdReply.Result.ListDsiHarnessGrpc.DsiHarnessGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void FilterDsiHarnessGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiHarnessByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiHarnessByRowIdReply.Result.ListDsiHarnessGrpc.DsiHarnessGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeDetail
        [Test]
        public void GetDsiCompositeDetailGrpcTest_Success()
        {
            DsiCompositeDetailGrpcRequest reasonGrpcRequest = new DsiCompositeDetailGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailGrpc));

            Task<ListDsiCompositeDetailGrpc> getDsiCompositeDetailGrpcReply = _GrpcService.ReadDsiCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCompositeDetailGrpcReply.Result.DsiCompositeDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCompositeDetailGrpcReply.Result.DsiCompositeDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCompositeDetailByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiCompositeDetailByRowIdReply.Result.ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiCompositeDetailByRowIdReply.Result.ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(filterDsiCompositeDetailByRowIdReply.Result.ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCompositeDetailByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiCompositeDetailByRowIdReply.Result.ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcTest_Success()
        {
            DsiCompositeDetailCircuitOptionAssociationGrpcRequest reasonGrpcRequest = new DsiCompositeDetailCircuitOptionAssociationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc));

            Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> getReply = _GrpcService.ReadDsiCompositeDetailCircuitOptionAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeDetailCircuitOptionAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeDetailCircuitOptionAssociationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeDetailCircuitOptionAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiModuleChildDetail
        [Test]
        public void GetDsiModuleChildDetailGrpcTest_Success()
        {
            DsiModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiModuleChildDetailGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleChildDetailGrpc));

            Task<ListDsiModuleChildDetailGrpc> getReply = _GrpcService.ReadDsiModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiModuleChildDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiModuleChildDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiModuleChildDetailGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiModuleChildDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedModule");
            Assert.That(filterByRowIdReply.Result.ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void GetDsiModuleChildDetailGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiModuleChildDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCentreStrip
        [Test]
        public void GetDsiCentreStripGrpcTest_Success()
        {
            DsiCentreStripGrpcRequest reasonGrpcRequest = new DsiCentreStripGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCentreStripGrpc));

            Task<ListDsiCentreStripGrpc> getDsiCentreStripGrpcReply = _GrpcService.ReadDsiCentreStripGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCentreStripGrpcReply.Result.DsiCentreStripGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCentreStripGrpcReply.Result.DsiCentreStripGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCentreStripGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCentreStripGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCentreStripByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiCentreStripByRowIdReply.Result.ListDsiCentreStripGrpc.DsiCentreStripGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiCentreStripByRowIdReply.Result.ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(filterDsiCentreStripByRowIdReply.Result.ListDsiCentreStripGrpc.DsiCentreStripGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void FilterDsiCentreStripGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCentreStripGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCentreStripByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiCentreStripByRowIdReply.Result.ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiComponent
        [Test]
        public void GetDsiComponentGrpcTest_Success()
        {
            DsiComponentGrpcRequest reasonGrpcRequest = new DsiComponentGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiComponentGrpc));

            Task<ListDsiComponentGrpc> getDsiComponentGrpcReply = _GrpcService.ReadDsiComponentGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiComponentGrpcReply.Result.DsiComponentGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiComponentGrpcReply.Result.DsiComponentGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiComponentGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiComponentGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiComponentByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiComponentByRowIdReply.Result.ListDsiComponentGrpc.DsiComponentGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiComponentByRowIdReply.Result.ListDsiComponentGrpc.DsiComponentGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(filterDsiComponentByRowIdReply.Result.ListDsiComponentGrpc.DsiComponentGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiComponentGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiComponentGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiComponentByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiComponentByRowIdReply.Result.ListDsiComponentGrpc.DsiComponentGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiCompositeOption
        [Test]
        public void GetDsiCompositeOptionGrpcTest_Success()
        {
            DsiCompositeOptionGrpcRequest reasonGrpcRequest = new DsiCompositeOptionGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiCompositeOptionGrpc));

            Task<ListDsiCompositeOptionGrpc> getDsiCompositeOptionGrpcReply = _GrpcService.ReadDsiCompositeOptionGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiCompositeOptionGrpcReply.Result.DsiCompositeOptionGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiCompositeOptionGrpcReply.Result.DsiCompositeOptionGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiCompositeOptionGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeOptionGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiCompositeOptionByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiCompositeOptionByRowIdReply.Result.ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiCompositeOptionByRowIdReply.Result.ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedCompositeOption");
            Assert.That(filterDsiCompositeOptionByRowIdReply.Result.ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.First().OptionName, reasonConstraint);
        }

        [Test]
        public void GetDsiCompositeOptionGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiCompositeOptionGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> getDsiCompositeOptionByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiCompositeOptionByRowIdReply.Result.ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarnessScope
        [Test]
        public void GetDsiHarnessScopeGrpcTest_Success()
        {
            DsiHarnessScopeGrpcRequest reasonGrpcRequest = new DsiHarnessScopeGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeGrpc));

            Task<ListDsiHarnessScopeGrpc> getDsiHarnessScopeGrpcReply = _GrpcService.ReadDsiHarnessScopeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiHarnessScopeGrpcReply.Result.DsiHarnessScopeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiHarnessScopeGrpcReply.Result.DsiHarnessScopeGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiHarnessScopeGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessScopeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiHarnessScopeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiHarnessScopeByRowIdReply.Result.ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiHarnessScopeByRowIdReply.Result.ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedHarnessA");
            Assert.That(filterDsiHarnessScopeByRowIdReply.Result.ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void FilterDsiHarnessScopeGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessScopeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiHarnessScopeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiHarnessScopeByRowIdReply.Result.ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiHarnessScopeScopeAssociation
        [Test]
        public void GetDsiHarnessScopeScopeAssociationGrpcTest_Success()
        {
            DsiHarnessScopeScopeAssociationGrpcRequest reasonGrpcRequest = new DsiHarnessScopeScopeAssociationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc));

            Task<ListDsiHarnessScopeScopeAssociationGrpc> getReply = _GrpcService.ReadDsiHarnessScopeScopeAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiHarnessScopeScopeAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiHarnessScopeScopeAssociationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessScopeScopeAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiHarnessScopeScopeAssociationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiHarnessScopeScopeAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiManualBomQuantity
        [Test]
        public void GetDsiManualBomQuantityGrpcTest_Success()
        {
            DsiManualBomQuantityGrpcRequest reasonGrpcRequest = new DsiManualBomQuantityGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiManualBomQuantityGrpc));

            Task<ListDsiManualBomQuantityGrpc> getDsiManualBomQuantityGrpcReply = _GrpcService.ReadDsiManualBomQuantityGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiManualBomQuantityGrpcReply.Result.DsiManualBomQuantityGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiManualBomQuantityGrpcReply.Result.DsiManualBomQuantityGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiManualBomQuantityGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiManualBomQuantityGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiManualBomQuantityByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiManualBomQuantityByRowIdReply.Result.ListDsiManualBomQuantityGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiManualBomQuantityByRowIdReply.Result.ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedModule");
            Assert.That(filterDsiManualBomQuantityByRowIdReply.Result.ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void FilterDsiManualBomQuantityGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiManualBomQuantityGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiManualBomQuantityByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiManualBomQuantityByRowIdReply.Result.ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiMidWireComponent
        [Test]
        public void GetDsiMidWireComponentGrpcTest_Success()
        {
            DsiMidWireComponentGrpcRequest reasonGrpcRequest = new DsiMidWireComponentGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMidWireComponentGrpc));

            Task<ListDsiMidWireComponentGrpc> getDsiMidWireComponentGrpcReply = _GrpcService.ReadDsiMidWireComponentGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiMidWireComponentGrpcReply.Result.DsiMidWireComponentGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiMidWireComponentGrpcReply.Result.DsiMidWireComponentGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiMidWireComponentGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiMidWireComponentGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiMidWireComponentByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiMidWireComponentByRowIdReply.Result.ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiMidWireComponentByRowIdReply.Result.ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedWire");
            Assert.That(filterDsiMidWireComponentByRowIdReply.Result.ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void FilterDsiMidWireComponentGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiMidWireComponentGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiMidWireComponentByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiMidWireComponentByRowIdReply.Result.ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiModuleCompatibility
        [Test]
        public void GetDsiModuleCompatibilityGrpcTest_Success()
        {
            DsiModuleCompatibilityGrpcRequest reasonGrpcRequest = new DsiModuleCompatibilityGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiModuleCompatibilityGrpc));

            Task<ListDsiModuleCompatibilityGrpc> getDsiModuleCompatibilityGrpcReply = _GrpcService.ReadDsiModuleCompatibilityGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiModuleCompatibilityGrpcReply.Result.DsiModuleCompatibilityGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiModuleCompatibilityGrpcReply.Result.DsiModuleCompatibilityGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiModuleCompatibilityGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiModuleCompatibilityGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiModuleCompatibilityByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiModuleCompatibilityByRowIdReply.Result.ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiModuleCompatibilityByRowIdReply.Result.ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedRelationship");
            Assert.That(filterDsiModuleCompatibilityByRowIdReply.Result.ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.First().Relationship, reasonConstraint);
        }

        [Test]
        public void FilterDsiModuleCompatibilityGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiModuleCompatibilityGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiModuleCompatibilityByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiModuleCompatibilityByRowIdReply.Result.ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiMulticoreSpecification
        [Test]
        public void GetDsiMulticoreSpecificationGrpcTest_Success()
        {
            DsiMulticoreSpecificationGrpcRequest reasonGrpcRequest = new DsiMulticoreSpecificationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiMulticoreSpecificationGrpc));

            Task<ListDsiMulticoreSpecificationGrpc> getReply = _GrpcService.ReadDsiMulticoreSpecificationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiMulticoreSpecificationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiMulticoreSpecificationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiMulticoreSpecificationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedMulticore");
            Assert.That(filterByRowIdReply.Result.ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.First().MulticoreName, reasonConstraint);
        }

        [Test]
        public void GetDsiMulticoreSpecificationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiMulticoreSpecificationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiPinMapping
        [Test]
        public void GetDsiPinMappingGrpcTest_Success()
        {
            DsiPinMappingGrpcRequest reasonGrpcRequest = new DsiPinMappingGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingGrpc));

            Task<ListDsiPinMappingGrpc> getDsiPinMappingGrpcReply = _GrpcService.ReadDsiPinMappingGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiPinMappingGrpcReply.Result.DsiPinMappingGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiPinMappingGrpcReply.Result.DsiPinMappingGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiPinMappingGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiPinMappingGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiPinMappingByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiPinMappingByRowIdReply.Result.ListDsiPinMappingGrpc.DsiPinMappingGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiPinMappingByRowIdReply.Result.ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedNodeA");
            Assert.That(filterDsiPinMappingByRowIdReply.Result.ListDsiPinMappingGrpc.DsiPinMappingGrpcs.First().Node1, reasonConstraint);
        }

        [Test]
        public void GetDsiPinMappingGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiPinMappingGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> getDsiPinMappingByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getDsiPinMappingByRowIdReply.Result.ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        [Test]
        public void GetDsiPinMappingCavityMappingAssociationGrpcTest_Success()
        {
            DsiPinMappingCavityMappingAssociationGrpcRequest reasonGrpcRequest = new DsiPinMappingCavityMappingAssociationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc));

            Task<ListDsiPinMappingCavityMappingAssociationGrpc> getReply = _GrpcService.ReadDsiPinMappingCavityMappingAssociationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiPinMappingCavityMappingAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiPinMappingCavityMappingAssociationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiPinMappingCavityMappingAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo(999);
            Assert.That(filterByRowIdReply.Result.ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.First().MappingNumber, reasonConstraint);
        }

        [Test]
        public void GetDsiPinMappingCavityMappingAssociationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiPinMappingCavityMappingAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiScope
        [Test]
        public void GetDsiScopeGrpcTest_Success()
        {
            DsiScopeGrpcRequest reasonGrpcRequest = new DsiScopeGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiScopeGrpc));

            Task<ListDsiScopeGrpc> getDsiScopeGrpcReply = _GrpcService.ReadDsiScopeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiScopeGrpcReply.Result.DsiScopeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiScopeGrpcReply.Result.DsiScopeGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiScopeGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiScopeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiScopeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiScopeByRowIdReply.Result.ListDsiScopeGrpc.DsiScopeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiScopeByRowIdReply.Result.ListDsiScopeGrpc.DsiScopeGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedScope");
            Assert.That(filterDsiScopeByRowIdReply.Result.ListDsiScopeGrpc.DsiScopeGrpcs.First().Scope, reasonConstraint);
        }

        [Test]
        public void GetDsiScopeGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiScopeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiScopeByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiScopeByRowIdReply.Result.ListDsiScopeGrpc.DsiScopeGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiSupplier
        [Test]
        public void GetDsiSupplierGrpcTest_Success()
        {
            DsiSupplierGrpcRequest reasonGrpcRequest = new DsiSupplierGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiSupplierGrpc));

            Task<ListDsiSupplierGrpc> getDsiSupplierGrpcReply = _GrpcService.ReadDsiSupplierGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getDsiSupplierGrpcReply.Result.DsiSupplierGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getDsiSupplierGrpcReply.Result.DsiSupplierGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiSupplierGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiSupplierGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiSupplierByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterDsiSupplierByRowIdReply.Result.ListDsiSupplierGrpc.DsiSupplierGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterDsiSupplierByRowIdReply.Result.ListDsiSupplierGrpc.DsiSupplierGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedSupplier");
            Assert.That(filterDsiSupplierByRowIdReply.Result.ListDsiSupplierGrpc.DsiSupplierGrpcs.First().Name, reasonConstraint);
        }

        [Test]
        public void FilterDsiSupplierGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiSupplierGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterDsiSupplierByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterDsiSupplierByRowIdReply.Result.ListDsiSupplierGrpc.DsiSupplierGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedCompositeDetail
        [Test]
        public void GetDsiTransformedCompositeDetailGrpcTest_Success()
        {
            DsiTransformedCompositeDetailGrpcRequest reasonGrpcRequest = new DsiTransformedCompositeDetailGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedCompositeDetailGrpc));

            Task<ListDsiTransformedCompositeDetailGrpc> getReply = _GrpcService.ReadDsiTransformedCompositeDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedCompositeDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiTransformedCompositeDetailGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedCompositeDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("HarnessA2");
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void FilterDsiTransformedCompositeDetailGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedCompositeDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedHarness
        [Test]
        public void GetDsiTransformedHarnessGrpcTest_Success()
        {
            DsiTransformedHarnessGrpcRequest reasonGrpcRequest = new DsiTransformedHarnessGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedHarnessGrpc));

            Task<ListDsiTransformedHarnessGrpc> getReply = _GrpcService.ReadDsiTransformedHarnessGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedHarnessGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedHarnessGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiTransformedHarnessGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedHarnessGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("HarnessA2");
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.First().HarnessName1, reasonConstraint);
        }

        [Test]
        public void GetDsiTransformedHarnessGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedHarnessGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiTransformedModuleChildDetail
        [Test]
        public void GetDsiTransformedModuleChildDetailGrpcTest_Success()
        {
            DsiTransformedModuleChildDetailGrpcRequest reasonGrpcRequest = new DsiTransformedModuleChildDetailGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiTransformedModuleChildDetailGrpc));

            Task<ListDsiTransformedModuleChildDetailGrpc> getReply = _GrpcService.ReadDsiTransformedModuleChildDetailGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiTransformedModuleChildDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiTransformedModuleChildDetailGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedModuleChildDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("Module2");
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.First().ModuleCode, reasonConstraint);
        }

        [Test]
        public void GetDsiTransformedModuleChildDetailGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiTransformedModuleChildDetailGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiUnitOfMeasure
        [Test]
        public void GetDsiUnitOfMeasureGrpcTest_Success()
        {
            DsiUnitOfMeasureGrpcRequest reasonGrpcRequest = new DsiUnitOfMeasureGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiUnitOfMeasureGrpc));

            Task<ListDsiUnitOfMeasureGrpc> getReply = _GrpcService.ReadDsiUnitOfMeasureGrpc(reasonGrpcRequest, serverCallContext);

            Assert.That(getReply.Result.DsiUnitOfMeasureGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiUnitOfMeasureGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiUnitOfMeasureGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiUnitOfMeasureGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FIX");
            Assert.That(filterByRowIdReply.Result.ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.First().Abbreviation, reasonConstraint);
        }

        [Test]
        public void GetDsiUnitOfMeasureGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiUnitOfMeasureGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireMulticoreMarker
        [Test]
        public void GetDsiWireMulticoreMarkerGrpcTest_Success()
        {
            DsiWireMulticoreMarkerGrpcRequest reasonGrpcRequest = new DsiWireMulticoreMarkerGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireMulticoreMarkerGrpc));

            Task<ListDsiWireMulticoreMarkerGrpc> getReply = _GrpcService.ReadDsiWireMulticoreMarkerGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireMulticoreMarkerGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getReply.Result.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiWireMulticoreMarkerGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireMulticoreMarkerGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"6\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("FixedItem");
            Assert.That(filterByRowIdReply.Result.ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.First().ItemName, reasonConstraint);
        }

        [Test]
        public void FilterDsiWireMulticoreMarkerGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireMulticoreMarkerGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireSpecification
        [Test]
        public void GetDsiWireSpecificationGrpcTest_Success()
        {
            DsiWireSpecificationGrpcRequest reasonGrpcRequest = new DsiWireSpecificationGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireSpecificationGrpc));

            Task<ListDsiWireSpecificationGrpc> getReply = _GrpcService.ReadDsiWireSpecificationGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireSpecificationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiWireSpecificationGrpcs.Count, countConstraint);
        }

        [Test]
        public void GetDsiWireSpecificationGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireSpecificationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("Wire2");
            Assert.That(filterByRowIdReply.Result.ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiWireSpecificationGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireSpecificationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Count, countConstraint);
        }
        #endregion

        #region DsiWireThroughNode
        [Test]
        public void GetDsiWireThroughNodeGrpcTest_Success()
        {
            DsiWireThroughNodeGrpcRequest reasonGrpcRequest = new DsiWireThroughNodeGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadDsiWireThroughNodeGrpc));

            Task<ListDsiWireThroughNodeGrpc> getReply = _GrpcService.ReadDsiWireThroughNodeGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.DsiWireThroughNodeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.DsiWireThroughNodeGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterDsiWireThroughNodeGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireThroughNodeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("Wire2");
            Assert.That(filterByRowIdReply.Result.ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.First().WireName, reasonConstraint);
        }

        [Test]
        public void GetDsiWireThroughNodeGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "DsiWireThroughNodeGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "RowId != null && RowId == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Count, countConstraint);
        }
        #endregion

        #region RfqNprRequest
        [Test]
        public void GetRfqNprRequestGrpcTest_Success()
        {
            RfqNprRequestGrpcRequest reasonGrpcRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter requestParameter = new RfqGrpcRequestParameter();
            requestParameter.RequestType = (int)RequestType.Read;
            reasonGrpcRequest.RfqGrpcRequestParameter = requestParameter;
            reasonGrpcRequest.RfqGrpcRequestParameter.RequestType = (int)RequestType.Read;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadRfqNprRequestGrpc));

            Task<ListRfqNprRequestGrpc> getReply = _GrpcService.ReadRfqNprRequestGrpc(reasonGrpcRequest, serverCallContext);
            Assert.That(getReply.Result.RfqNprRequestGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getReply.Result.RfqNprRequestGrpcs.Count, countConstraint);
        }

        [Test]
        public void FilterRfqNprRequestGrpcByRowIdTest_Success()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqNprRequestGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"b559bdd7-e4fa-434c-8e8d-c26b3ae40ba2\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            Assert.That(filterByRowIdReply.Result.ListRfqNprRequestGrpc.RfqNprRequestGrpcs, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterByRowIdReply.Result.ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Count, countConstraint);
            EqualConstraint reasonConstraint = Is.EqualTo("CustomerCode2");
            Assert.That(filterByRowIdReply.Result.ListRfqNprRequestGrpc.RfqNprRequestGrpcs.First().CustomerCode, reasonConstraint);
        }

        [Test]
        public void GetRfqNprRequestGrpcByRowIdTest_Fails()
        {
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            filterRequest.DatabaseList = "RfqNprRequestGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"10\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterRfqGrpc));

            Task<RfqFilterResponse> filterByRowIdReply = _GrpcService.FilterRfqGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterByRowIdReply.Result.ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Count, countConstraint);
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

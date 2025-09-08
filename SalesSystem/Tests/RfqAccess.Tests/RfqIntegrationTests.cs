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

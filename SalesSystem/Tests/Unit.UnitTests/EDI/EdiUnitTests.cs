using EDI;
using EDI.Data.Enum;
using EDI.Endpoints.GrpcServices;
using EDI.Services;

namespace Unit.Tests.EDI
{
    class EdiUnitTests
    {
        EdiAccessService _EdiAccessService;
        EdiGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            bool testing = true;
            _EdiAccessService = new EdiAccessService(provider, testing);

            Mock<ILogger<EdiGrpcService>> loggerMock = new Mock<ILogger<EdiGrpcService>>();
            ILogger<EdiGrpcService> logger = loggerMock.Object;

            _GrpcService = new EdiGrpcService(_EdiAccessService, logger);
        }

        [Test]
        [Category("Unit")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";

            string methodName = nameof(_GrpcService.SayHello);
            ServerCallContext serverCallContext = CreateServerContext(methodName);

            Task<CommonTypes.HelloReply> task = _GrpcService.SayHello(request, serverCallContext);
            CommonTypes.HelloReply reply = task.Result;

            string expected = "Hello TestName, I am the EdiGrpcService";
            string actual = reply.Message;

            EqualConstraint equalConstraint = Is.EqualTo(expected);
            Assert.That(actual, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // GetEdiDataGrpc: EdiCustomerParameters (seeded in testing mode)
        // ---------------------------------------------------------------------
        [Test]
        [Category("Unit")]
        public void GetEdiDataGrpc_EdiCustomerParameters_Success()
        {
            EdiRequest req = new EdiRequest();
            int requestType = (int)EdiRequestType.GetEdiCustomerParameters;
            req.RequestType = requestType;

            string methodName = nameof(_GrpcService.GetEdiDataGrpc);
            ServerCallContext ctx = CreateServerContext(methodName);

            Task<EdiResponse> task = _GrpcService.GetEdiDataGrpc(req, ctx);
            EdiResponse resp = task.Result;

            bool success = resp.Success;
            EqualConstraint trueEq = Is.EqualTo(true);
            Assert.That(success, trueEq);

            ListEdiCustomerParameterGrpc listContainer = resp.ListEdiCustomerParameterGrpc;
            Assert.That(listContainer, Is.Not.Null);

            RepeatedField<EdiCustomerParameterGrpc> items = listContainer.EdiCustomerParameterGrpc;
            Assert.That(items, Is.Not.Null);

            int count = items.Count;
            bool zeroOrLess = count <= 0;
            EqualConstraint falseEq = Is.EqualTo(false);
            Assert.That(zeroOrLess, falseEq);

            EdiCustomerParameterGrpc first = items[0];
            Assert.That(first, Is.Not.Null);

            string customer = first.Customer;
            bool hasCustomer = !string.IsNullOrWhiteSpace(customer);
            Assert.That(hasCustomer, trueEq);
        }

        // ---------------------------------------------------------------------
        // FilterEdiDataGrpc: SUCCESS ("true") for EdiCustomerParameterGrpc
        // ---------------------------------------------------------------------
        [Test]
        [Category("Unit")]
        public void FilterEdiDataGrpc_True_ReturnsItems()
        {
            EdiFilterRequest filterReq = new EdiFilterRequest();
            string dbList = "EdiCustomerParameterGrpc";
            string filterExpression = "true";
            filterReq.DatabaseList = dbList;
            filterReq.FilterExpression = filterExpression;

            string methodName = nameof(_GrpcService.FilterEdiDataGrpc);
            ServerCallContext ctx = CreateServerContext(methodName);

            Task<EdiResponse> task = _GrpcService.FilterEdiDataGrpc(filterReq, ctx);
            EdiResponse resp = task.Result;

            int expectedResponseType = (int)EdiResponseType.EdiFilter;
            int actualResponseType = resp.ResponseType;
            EqualConstraint respTypeEq = Is.EqualTo(expectedResponseType);
            Assert.That(actualResponseType, respTypeEq);

            bool success = resp.Success;
            EqualConstraint trueEq = Is.EqualTo(true);
            Assert.That(success, trueEq);

            ListEdiCustomerParameterGrpc listContainer = resp.ListEdiCustomerParameterGrpc;
            Assert.That(listContainer, Is.Not.Null);

            RepeatedField<EdiCustomerParameterGrpc> items = listContainer.EdiCustomerParameterGrpc;
            Assert.That(items, Is.Not.Null);

            int count = items.Count;
            bool zeroOrLess = count <= 0;
            EqualConstraint falseEq = Is.EqualTo(false);
            Assert.That(zeroOrLess, falseEq);
        }

        // ---------------------------------------------------------------------
        // FilterEdiDataGrpc: FAILURE ("false") -> list should be null or empty
        // ---------------------------------------------------------------------
        [Test]
        [Category("Unit")]
        public void FilterEdiDataGrpc_False_ReturnsEmptyOrNull()
        {
            EdiFilterRequest filterReq = new EdiFilterRequest();
            string dbList = "EdiCustomerParameterGrpc";
            string filterExpression = "false";
            filterReq.DatabaseList = dbList;
            filterReq.FilterExpression = filterExpression;

            string methodName = nameof(_GrpcService.FilterEdiDataGrpc);
            ServerCallContext ctx = CreateServerContext(methodName);

            Task<EdiResponse> task = _GrpcService.FilterEdiDataGrpc(filterReq, ctx);
            EdiResponse resp = task.Result;

            ListEdiCustomerParameterGrpc? container = resp.ListEdiCustomerParameterGrpc;

            bool finalEmptyOrNull;
            if (container == null)
            {
                finalEmptyOrNull = true;
            }
            else
            {
                RepeatedField<EdiCustomerParameterGrpc>? items = container.EdiCustomerParameterGrpc;
                if (items == null)
                {
                    finalEmptyOrNull = true;
                }
                else
                {
                    int count = items.Count;
                    bool zeroOrLess = count <= 0;
                    finalEmptyOrNull = zeroOrLess;
                }
            }

            EqualConstraint trueEq = Is.EqualTo(true);
            Assert.That(finalEmptyOrNull, trueEq);
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
using EDI;
using EDI.Data.Enum;
using EDI.Endpoints.GrpcServices;
using EDI.Services;

namespace Regression.Tests.EDI
{
    public class EdiRegressionTests
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
        public async Task RegressionTest_EDI_AllEndpoints_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello
            // ---------------------------------------------------------
            HelloRequest helloRequest = new HelloRequest();
            helloRequest.Name = "TestName";

            string helloMethodName = nameof(_GrpcService.SayHello);
            ServerCallContext helloContext = CreateServerContext(helloMethodName);

            HelloReply helloReply = await _GrpcService.SayHello(helloRequest, helloContext);

            string expectedHello = "Hello TestName, I am the EdiGrpcService";
            string actualHello = helloReply.Message;
            EqualConstraint helloConstraint = Is.EqualTo(expectedHello);
            Assert.That(actualHello, helloConstraint);

            // =========================================================
            // GetEdiDataGrpc - EdiCustomerParameters (POPULATED IN TESTING MODE)
            // =========================================================
            EdiRequest dataRequest = new EdiRequest();
            int requestTypeCustomerParams = (int)EdiRequestType.GetEdiCustomerParameters;
            dataRequest.RequestType = requestTypeCustomerParams;

            string getDataMethodName = nameof(_GrpcService.GetEdiDataGrpc);
            ServerCallContext getDataContext = CreateServerContext(getDataMethodName);

            EdiResponse dataResponse = await _GrpcService.GetEdiDataGrpc(dataRequest, getDataContext);

            bool successFlag = dataResponse.Success;
            Assert.That(successFlag, Is.True);

            ListEdiCustomerParameterGrpc listContainer = dataResponse.ListEdiCustomerParameterGrpc;
            Assert.That(listContainer, Is.Not.Null);

            RepeatedField<EdiCustomerParameterGrpc> items = listContainer.EdiCustomerParameterGrpc;
            Assert.That(items, Is.Not.Null);

            int itemCount = items.Count;
            bool itemCountIsZeroOrLess = itemCount <= 0;
            Assert.That(itemCountIsZeroOrLess, Is.False);

            EdiCustomerParameterGrpc? firstItem = items.FirstOrDefault();
            Assert.That(firstItem, Is.Not.Null);

            string firstCustomer = firstItem!.Customer;
            bool firstCustomerHasValue = !string.IsNullOrWhiteSpace(firstCustomer);
            Assert.That(firstCustomerHasValue, Is.True);

            // =========================================================
            // FilterEdiDataGrpc - SUCCESS ("true") for EdiCustomerParameterGrpc
            // =========================================================
            EdiFilterRequest filterSuccessRequest = new EdiFilterRequest();
            string databaseListCustomerParams = "EdiCustomerParameterGrpc";
            string filterExpressionTrue = "true";
            filterSuccessRequest.DatabaseList = databaseListCustomerParams;
            filterSuccessRequest.FilterExpression = filterExpressionTrue;

            string filterMethodName = nameof(_GrpcService.FilterEdiDataGrpc);
            ServerCallContext filterSuccessContext = CreateServerContext(filterMethodName);

            EdiResponse filterSuccessResponse = await _GrpcService.FilterEdiDataGrpc(filterSuccessRequest, filterSuccessContext);

            int responseTypeFilter = (int)EdiResponseType.EdiFilter;
            int actualResponseType = filterSuccessResponse.ResponseType;
            EqualConstraint responseTypeConstraint = Is.EqualTo(responseTypeFilter);
            Assert.That(actualResponseType, responseTypeConstraint);

            bool filterSuccessFlag = filterSuccessResponse.Success;
            Assert.That(filterSuccessFlag, Is.True);

            ListEdiCustomerParameterGrpc filterSuccessListContainer = filterSuccessResponse.ListEdiCustomerParameterGrpc;
            Assert.That(filterSuccessListContainer, Is.Not.Null);

            RepeatedField<EdiCustomerParameterGrpc> filterSuccessItems = filterSuccessListContainer.EdiCustomerParameterGrpc;
            Assert.That(filterSuccessItems, Is.Not.Null);

            int filterSuccessCount = filterSuccessItems.Count;
            bool filterSuccessCountIsZeroOrLess = filterSuccessCount <= 0;
            Assert.That(filterSuccessCountIsZeroOrLess, Is.False);

            // =========================================================
            // FilterEdiDataGrpc - FAILURE ("false") -> empty result (or null set)
            // =========================================================
            EdiFilterRequest filterFailRequest = new EdiFilterRequest();
            string filterExpressionFalse = "false";
            filterFailRequest.DatabaseList = databaseListCustomerParams;
            filterFailRequest.FilterExpression = filterExpressionFalse;

            ServerCallContext filterFailContext = CreateServerContext(filterMethodName);

            EdiResponse filterFailResponse = await _GrpcService.FilterEdiDataGrpc(filterFailRequest, filterFailContext);

            // Safely evaluate the list without dereferencing null
            ListEdiCustomerParameterGrpc? filterFailListContainer = filterFailResponse.ListEdiCustomerParameterGrpc;

            bool finalEmptyOrNull;
            if (filterFailListContainer == null)
            {
                finalEmptyOrNull = true;
            }
            else
            {
                // Only access the repeated field if the container is not null
              RepeatedField<EdiCustomerParameterGrpc>? filterFailItems;
                filterFailItems = filterFailListContainer.EdiCustomerParameterGrpc;

                if (filterFailItems == null)
                {
                    finalEmptyOrNull = true;
                }
                else
                {
                    int failCount = filterFailItems.Count;
                    bool failCountIsZeroOrLess = failCount <= 0;
                    finalEmptyOrNull = failCountIsZeroOrLess;
                }
            }

            EqualConstraint trueConstraint = Is.EqualTo(true);
            Assert.That(finalEmptyOrNull, trueConstraint);

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


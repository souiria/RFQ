using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using Moq.Language.Flow;
using Moq.Protected;
using NPR;
using NPR.Endpoints.GrpcServices;
using NPR.Services;

namespace Unit.Tests.NPR
{
    [TestFixture]
    class NPRUnitTests
    {
        #region Fields

        NPRAccessService _NPRAccessService;
        NPRGrpcService _GrpcService;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            string sendAsyncMethodName = "SendAsync";
#pragma warning disable CA2000
            HttpResponseMessage defaultHttpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            defaultHttpResponse.StatusCode = HttpStatusCode.OK;
            defaultHttpResponse.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            Expression requestMessageExpression = ItExpr.IsAny<HttpRequestMessage>();
            Expression cancellationTokenExpression = ItExpr.IsAny<CancellationToken>();
            IReturnsThrows<HttpMessageHandler, Task<HttpResponseMessage>> handlerSetup = handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    sendAsyncMethodName,
                    requestMessageExpression,
                    cancellationTokenExpression);

            handlerSetup.ReturnsAsync(defaultHttpResponse);

            HttpMessageHandler handler = handlerMock.Object;
            Uri baseAddress = new Uri("http://localhost/");

            serviceCollection.AddHttpClient("MyClient", client =>
            {
                client.BaseAddress = baseAddress;
            }).ConfigurePrimaryHttpMessageHandler(() => handler);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            Mock<ILogger<NPRGrpcService>> logger = new Mock<ILogger<NPRGrpcService>>();
            IConfiguration configuration = new ConfigurationBuilder().Build();
            _NPRAccessService = new NPRAccessService(serviceProvider, httpClientFactory, configuration, true);
            _GrpcService = new NPRGrpcService(_NPRAccessService, logger.Object);
        }

        #endregion

        #region SayHello

        [Test]
        [Category("Unit")]
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

        #endregion

        #region H1NPRView

        [Test]
        [Category("Unit")]
        public void GetCurrencyGrpcTest_Success()
        {
            H1NPRViewRequest h1NPRViewRequest = new H1NPRViewRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllH1NPRViewGrpc));

            Task<ListH1NPRViewGrpc> getCurrencyGrpcReply = _GrpcService.GetAllH1NPRViewGrpc(h1NPRViewRequest, serverCallContext);

            Assert.That(getCurrencyGrpcReply.Result.H1NPRViewGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCurrencyGrpcReply.Result.H1NPRViewGrpc.Count, countConstraint);
        }

        #endregion

        #region RFQStatus

        [Test]
        [Category("Unit")]
        public void GetAllRFQStatusGrpcTest_Success()
        {
            RFQStatusRequest request = new RFQStatusRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllRFQStatusGrpc));

            Task<ListRFQStatusGrpc> reply = _GrpcService.GetAllRFQStatusGrpc(request, serverCallContext);

            GreaterThanConstraint greaterThanConstraint = Is.GreaterThan(0);
            Assert.That(reply.Result.RFQStatusGrpc, Is.Not.Null);
            Assert.That(reply.Result.RFQStatusGrpc.Count, greaterThanConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetAllRFQStatusGrpcTest_WithPositionAndTakeAmount_ReturnsPaginatedResults()
        {
            RFQStatusRequest request = new RFQStatusRequest();
            request.Position = 1;
            request.Takeamount = 2;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAllRFQStatusGrpc));

            Task<ListRFQStatusGrpc> reply = _GrpcService.GetAllRFQStatusGrpc(request, serverCallContext);

            Assert.That(reply.Result.RFQStatusGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(2);
            Assert.That(reply.Result.RFQStatusGrpc.Count, countConstraint);
        }

        #endregion

        #region CreateNprApiGrpc

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_EmptyNprApiData_ReturnsEmptyResponse()
        {
            // Arrange — protobuf RepeatedField is never null, an empty collection is the correct guard case
            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = _GrpcService.CreateNprApiGrpc(request, serverCallContext);

            // Assert — guard returns early before HttpClient is called
            Assert.That(reply.Result, Is.Not.Null);
            Assert.That(reply.Result.NprApiData, Is.Empty);
            Assert.That(reply.Result.HttpStatusCode, Is.Null);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_ValidRequest_Returns200()
        {
            // Arrange — default handler returns 200 OK with empty array body
            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            //entry.SumitomoNumber = "SN-001";
            entry.RfqNprRequestId = "RFQ-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = _GrpcService.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.OK.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_Returns422_SetsValidationErrorMessage()
        {
            // Arrange
            string validationError = "The field CustomerRfqNo is required.";
            StringContent content = new StringContent(validationError, Encoding.UTF8, "application/json");
#pragma warning disable CA2000
            HttpResponseMessage httpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            httpResponse.StatusCode = HttpStatusCode.UnprocessableContent;
            httpResponse.Content = content;

            NPRGrpcService service = CreateGrpcServiceWithResponse(httpResponse);

            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            entry.CustomerRfqNo = "Rfq-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = service.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.UnprocessableContent.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
            ContainsConstraint containsConstraint = Does.Contain("Validation error");
            Assert.That(reply.Result.Message, containsConstraint);
            ContainsConstraint validationConstraint = Does.Contain(validationError);
            Assert.That(reply.Result.Message, validationConstraint);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_Returns401_SetsUnauthorizedMessage()
        {
            // Arrange
#pragma warning disable CA2000
            HttpResponseMessage httpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            httpResponse.StatusCode = HttpStatusCode.Unauthorized;
            httpResponse.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            NPRGrpcService service = CreateGrpcServiceWithResponse(httpResponse);

            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            entry.CustomerRfqNo = "Rfq-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = service.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.Unauthorized.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
            ContainsConstraint containsConstraint = Does.Contain("Unauthorized");
            Assert.That(reply.Result.Message, containsConstraint);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_Returns403_SetsForbiddenMessage()
        {
            // Arrange
#pragma warning disable CA2000
            HttpResponseMessage httpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            httpResponse.StatusCode = HttpStatusCode.Forbidden;
            httpResponse.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            NPRGrpcService service = CreateGrpcServiceWithResponse(httpResponse);

            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            entry.CustomerRfqNo = "Rfq-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = service.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.Forbidden.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
            ContainsConstraint contains = Does.Contain("Forbidden");
            Assert.That(reply.Result.Message, contains);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_Returns500_SetsServerErrorMessage()
        {
            // Arrange
            string serverError = "An unhandled exception occurred.";
            StringContent content = new StringContent(serverError, Encoding.UTF8, "application/json");
#pragma warning disable CA2000
            HttpResponseMessage httpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            httpResponse.StatusCode = HttpStatusCode.InternalServerError;
            httpResponse.Content = content;

            NPRGrpcService service = CreateGrpcServiceWithResponse(httpResponse);

            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            entry.CustomerRfqNo = "Rfq-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = service.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.InternalServerError.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
            ContainsConstraint containsConstraint = Does.Contain("Server error (500)");
            Assert.That(reply.Result.Message, containsConstraint);
            ContainsConstraint containsError = Does.Contain(serverError);
            Assert.That(reply.Result.Message, containsError);
        }

        [Test]
        [Category("Unit")]
        public void CreateNprApiGrpcTest_Returns503_SetsUnexpectedStatusMessage()
        {
            // Arrange
            string unavailableBody = "Service temporarily unavailable.";
            StringContent content = new StringContent(unavailableBody, Encoding.UTF8, "application/json");
#pragma warning disable CA2000
            HttpResponseMessage httpResponse = new HttpResponseMessage();
#pragma warning restore CA2000
            httpResponse.StatusCode = HttpStatusCode.ServiceUnavailable;
            httpResponse.Content = content;

            NPRGrpcService service = CreateGrpcServiceWithResponse(httpResponse);

            CreateNprApiGrpcRequest request = new CreateNprApiGrpcRequest();
            NprApiDataGrpc entry = new NprApiDataGrpc();
            //entry.SumitomoNumber = "SN-001";
            request.NprApiData.Add(entry);
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateNprApiGrpc));

            // Act
            Task<CreateNprApiGrpcResponse> reply = service.CreateNprApiGrpc(request, serverCallContext);

            // Assert
            Assert.That(reply.Result, Is.Not.Null);
            string status = HttpStatusCode.ServiceUnavailable.ToString();
            EqualConstraint statusConstraint = Is.EqualTo(status);
            Assert.That(reply.Result.HttpStatusCode, statusConstraint);
            ContainsConstraint containsConstraint = Does.Contain("Unexpected status");
            Assert.That(reply.Result.Message, containsConstraint);
        }

        #endregion

        #region Helpers

        NPRGrpcService CreateGrpcServiceWithResponse(HttpResponseMessage httpResponse)
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            string sendAsyncMethodName = "SendAsync";
            Expression messageException = ItExpr.IsAny<HttpRequestMessage>();
            Expression cancellationToken = ItExpr.IsAny<CancellationToken>();

            ISetup<HttpMessageHandler, Task<HttpResponseMessage>> handlerSetup = handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    sendAsyncMethodName,
                    messageException,
                    cancellationToken);

            handlerSetup.ReturnsAsync(httpResponse);

            HttpMessageHandler handler = handlerMock.Object;
            Uri baseAddress = new Uri("http://localhost/");

            serviceCollection.AddHttpClient("MyClient", client =>
            {
                client.BaseAddress = baseAddress;
            }).ConfigurePrimaryHttpMessageHandler(() => handler);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            Mock<ILogger<NPRGrpcService>> logger = new Mock<ILogger<NPRGrpcService>>();
            IConfiguration configuration = new ConfigurationBuilder().Build();

            NPRAccessService accessService = new NPRAccessService(serviceProvider, httpClientFactory, configuration, true);
            NPRGrpcService grpcService = new NPRGrpcService(accessService, logger.Object);

            return grpcService;
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

        #endregion
    }
}
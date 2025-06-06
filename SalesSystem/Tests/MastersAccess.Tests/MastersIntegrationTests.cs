using Grpc.Core;
using Grpc.Core.Testing;
using Master;
using Master.Endpoints.GrpcServices;
using Master.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace MastersAccess.Tests
{
    public class MastersIntegrationTests
    {
        MasterAccessService _MasterAccessService;
        MasterGrpcService _GrpcService;
        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _MasterAccessService = new MasterAccessService(serviceProvider, true);
            Mock<ILogger<MasterGrpcService>> logger = new Mock<ILogger<MasterGrpcService>>();
            _GrpcService = new MasterGrpcService(_MasterAccessService, logger.Object);
        }

        [Test]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.SayHello)
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
            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }
        #region Currency

        [Test]
        public void GetCurrencyDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CurrencyGrpcRequest currencyGrpcRequest = new CurrencyGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCurrencyData)
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
            Task<ListCurrencyData> getCurrencyDataReply = _GrpcService.GetCurrencyData(currencyGrpcRequest, serverCallContext);
            Assert.That(getCurrencyDataReply.Result.CurrencyData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCurrencyDataReply.Result.CurrencyData.Count, countConstraint);

        }

        [Test]
        public void GetCurrencyDataByIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CurrencyByIdGrpcRequest currencyGrpcRequest = new CurrencyByIdGrpcRequest();
            currencyGrpcRequest.Id = "ec44e5cd-5832-48dd-b5a3-440b5cb49450";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCurrencyDataById)
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
            Task<ListCurrencyData> getCurrencyDataByIdReply = _GrpcService.GetCurrencyDataById(currencyGrpcRequest, serverCallContext);

            Assert.That(getCurrencyDataByIdReply.Result.CurrencyData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCurrencyDataByIdReply.Result.CurrencyData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestName");
            Assert.That(getCurrencyDataByIdReply.Result.CurrencyData.First().CurrencyName, nameConstraint);
        }

        [Test]
        public void GetCurrencyDataByIdTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            CurrencyByIdGrpcRequest currencyGrpcRequest = new CurrencyByIdGrpcRequest();
            currencyGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCurrencyDataById)
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
            Task<ListCurrencyData> getCurrencyDataByIdReply = _GrpcService.GetCurrencyDataById(currencyGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCurrencyDataByIdReply.Result.CurrencyData.Count, countConstraint);
        }

        #endregion
        #region Customer

        [Test]
        public void GetCustomerDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerGrpcRequest customerGrpcRequest = new CustomerGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerData)
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
            Task<ListCustomerData> getCustomerData = _GrpcService.GetCustomerData(customerGrpcRequest, serverCallContext);
            
            Assert.That(getCustomerData.Result.CustomerData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerData.Result.CustomerData.Count, countConstraint);
        }

        public void GetCustomerDataByIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerByIdGrpcRequest customerByIdGrpcRequest = new CustomerByIdGrpcRequest();
            customerByIdGrpcRequest.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerDataById)
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
            Task<ListCustomerData> getCustomerDataByIdReply = _GrpcService.GetCustomerDataById(customerByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerDataByIdReply.Result.CustomerData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerDataByIdReply.Result.CustomerData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestGroupName");
            Assert.That(getCustomerDataByIdReply.Result.CustomerData.First().CustomerBusinessGroupName, nameConstraint);
        }
        [Test]
        public void GetCustomerDataByIdTest_Fail()
        {
            CancellationToken token = CancellationToken.None;
            CustomerByIdGrpcRequest customerByIdGrpcRequest = new CustomerByIdGrpcRequest();
            customerByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerDataById)
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
            Task<ListCustomerData> getCustomerDataByIdReply = _GrpcService.GetCustomerDataById(customerByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerDataByIdReply.Result.CustomerData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerLocationTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerLocationGrpcRequest customerGrpcRequest = new CustomerLocationGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerLocationData)
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
            Task<ListCustomerLocationData> getCustomerLocationData = _GrpcService.GetCustomerLocationData(customerGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationData.Result.CustomerLocationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerLocationData.Result.CustomerLocationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerLocationDataByIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerLocationByIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerLocationByIdGrpcRequest();
            customerLocationByIdGrpcRequest.Id = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerLocationDataById)
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
            Task<ListCustomerLocationData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerLocationDataById(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerLocationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerLocationData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestCustomerName");
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerLocationData.First().CustomerName, nameConstraint);
        }

        [Test]
        public void GetCustomerLocationDataByIdTest_Fail()
        {
            CancellationToken token = CancellationToken.None;
            CustomerLocationByIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerLocationByIdGrpcRequest();
            customerLocationByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerLocationDataById)
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
            Task<ListCustomerLocationData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerLocationDataById(customerLocationByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerLocationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerLocationDataByUserIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerLocationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerLocationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerLocationDataByUserId)
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
            Task<ListCustomerLocationData> getCustomerLocationDataByUserIdReply = _GrpcService.GetCustomerLocationDataByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationDataByUserIdReply.Result.CustomerLocationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationDataByUserIdReply.Result.CustomerLocationData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestCustomerName");
            Assert.That(getCustomerLocationDataByUserIdReply.Result.CustomerLocationData.First().CustomerName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("3759c3b6-aceb-475e-9ba3-74f13e441e2d");
            Assert.That(getCustomerLocationDataByUserIdReply.Result.CustomerLocationData.First().Id, idConstraint);
        }
        [Test]
        public void GetCustomerLocationDataByUserIdTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            CustomerLocationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerLocationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerLocationDataByUserId)
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
            Task<ListCustomerLocationData> getCustomerLocationDataByUserIdReply = _GrpcService.GetCustomerLocationDataByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationDataByUserIdReply.Result.CustomerLocationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerSalesEntityDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerSalesEntityGrpcRequest customerSalesEntityGrpcRequest = new CustomerSalesEntityGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerSalesEntityData)
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
            Task<ListCustomerSalesEntityData> getCustomerSalesEntityData = _GrpcService.GetCustomerSalesEntityData(customerSalesEntityGrpcRequest, serverCallContext);

            Assert.That(getCustomerSalesEntityData.Result.CustomerSalesEntityData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerSalesEntityData.Result.CustomerSalesEntityData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerSalesEmntityDataByUserIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerSalesEntityByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerSalesEntityByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerSalesEntityDataByUserId)
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
            Task<ListCustomerSalesEntityData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerSalesEntityDataByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerSalesEntityData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerSalesEntityData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestfixedCustomerSalesEntityName");
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerSalesEntityData.First().CustomerSalesEntityName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("84e51c97-4da5-460e-b918-3d70edd87d88");
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerSalesEntityData.First().Id, idConstraint);
        }

        [Test]
        public void GetCustomerSalesEmntityDataByUserIdTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            CustomerSalesEntityByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerSalesEntityByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerSalesEntityDataByUserId)
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
            Task<ListCustomerSalesEntityData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerSalesEntityDataByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerSalesEntityData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerProjectAssociationDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerProjectAssociationGrpcRequest customerProjectAssociationGrpcRequest = new CustomerProjectAssociationGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerProjectAssociationData)
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
            Task<ListCustomerProjectAssociationData> getcustomerProjectAssociationData = _GrpcService.GetCustomerProjectAssociationData(customerProjectAssociationGrpcRequest, serverCallContext);

            Assert.That(getcustomerProjectAssociationData.Result.CustomerProjectAssociationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getcustomerProjectAssociationData.Result.CustomerProjectAssociationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerProjectAssociationDataByUserIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerProjectAssociationByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerProjectAssociationByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerProjectAssociationDataByUserId)
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
            Task<ListCustomerProjectAssociationData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerProjectAssociationDataByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerProjectAssociationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerProjectAssociationData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("fd994af4-57a3-4d95-b75d-b8d502e6a023");
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerProjectAssociationData.First().Id, idConstraint);
        }

        [Test]
        public void GetCustomerProjectAssociationDataByUserIdTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            CustomerProjectAssociationByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerProjectAssociationByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerProjectAssociationDataByUserId)
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
            Task<ListCustomerProjectAssociationData> getCustomerLocationDataByIdReply = _GrpcService.GetCustomerProjectAssociationDataByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationDataByIdReply.Result.CustomerProjectAssociationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerBusinessUserAssociationDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerBusinessUserAssociationGrpcRequest customerBuisnessUserAssociationGrpcRequest = new CustomerBusinessUserAssociationGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerBusinessUserAssociationData)
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
            Task<ListCustomerBusinessUserAssociationData> getcustomerBuisnessUserAssociationData = _GrpcService.GetCustomerBusinessUserAssociationData(customerBuisnessUserAssociationGrpcRequest, serverCallContext);

            Assert.That(getcustomerBuisnessUserAssociationData.Result.CustomerBusinessUserAssociationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getcustomerBuisnessUserAssociationData.Result.CustomerBusinessUserAssociationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerBusinessUserAssociationDataByUserIdTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CustomerBusinessUserAssociationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerBusinessUserAssociationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerBusinessUserAssociationDataByUserId)
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
            Task<ListCustomerBusinessUserAssociationData> getcustomerBuisnessUserAssociationByUserIdData = _GrpcService.GetCustomerBusinessUserAssociationDataByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            Assert.That(getcustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getcustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationData.Count, countConstraint);
        }

        [Test]
        public void GetCustomerBusinessUserAssociationDataByUserIdTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            CustomerBusinessUserAssociationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerBusinessUserAssociationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerBusinessUserAssociationDataByUserId)
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
            Task<ListCustomerBusinessUserAssociationData> getcustomerBuisnessUserAssociationByUserIdData = _GrpcService.GetCustomerBusinessUserAssociationDataByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            Assert.That(getcustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getcustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationData.Count, countConstraint);
        }
        #endregion
        #region Project

        [Test]
        public void GetMilestoneDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            MilestoneGrpcRequest milestoneGrpcRequest = new MilestoneGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCustomerBusinessUserAssociationData)
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
            Task<ListMilestoneData> getMilestoneData = _GrpcService.GetMilestoneData(milestoneGrpcRequest, serverCallContext);

            Assert.That(getMilestoneData.Result.MilestoneData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneData.Result.MilestoneData.Count, countConstraint);
        }

        [Test]
        public void GetMilestoneByIdDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            MilestoneByIdGrpcRequest milestoneByIdGrpcRequest = new MilestoneByIdGrpcRequest();
            milestoneByIdGrpcRequest.Id = "50365c14-734c-406a-b18e-9a3eff9e2d17";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMilestoneDataById)
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
            Task<ListMilestoneData> getMilestoneByIdReply = _GrpcService.GetMilestoneDataById(milestoneByIdGrpcRequest, serverCallContext);

            Assert.That(getMilestoneByIdReply.Result.MilestoneData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getMilestoneByIdReply.Result.MilestoneData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestMilestoneEventName");
            Assert.That(getMilestoneByIdReply.Result.MilestoneData.First().MilestoneEventName, nameConstraint);
        }

        [Test]
        public void GetMilestoneByIdDataTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            MilestoneByIdGrpcRequest milestoneByIdGrpcRequest = new MilestoneByIdGrpcRequest();
            milestoneByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMilestoneDataById)
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
            Task<ListMilestoneData> getMilestoneByIdReply = _GrpcService.GetMilestoneDataById(milestoneByIdGrpcRequest, serverCallContext);

            Assert.That(getMilestoneByIdReply.Result.MilestoneData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        }

        [Test]
        public void GetPlatformDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            PlatformGrpcRequest platformGrpcRequest = new PlatformGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPlatformData)
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
            Task<ListPlatformData> getMilestoneData = _GrpcService.GetPlatformData(platformGrpcRequest, serverCallContext);

            Assert.That(getMilestoneData.Result.PlatformData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneData.Result.PlatformData.Count, countConstraint);
        }

        [Test]
        public void GetPlatformByIdDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            PlatformByIdGrpcRequest platformByIdGrpcRequest = new PlatformByIdGrpcRequest();
            platformByIdGrpcRequest.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPlatformDataById)
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
            Task<ListPlatformData> getPlatformByIdReply = _GrpcService.GetPlatformDataById(platformByIdGrpcRequest, serverCallContext);

            Assert.That(getPlatformByIdReply.Result.PlatformData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPlatformByIdReply.Result.PlatformData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestPlatformName");
            Assert.That(getPlatformByIdReply.Result.PlatformData.First().PlatformName, nameConstraint);
        }

        [Test]
        public void GetPlatformByIdDataTest_False()
        {
            CancellationToken token = CancellationToken.None;
            PlatformByIdGrpcRequest platformByIdGrpcRequest = new PlatformByIdGrpcRequest();
            platformByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPlatformDataById)
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
            Task<ListPlatformData> getPlatformByIdReply = _GrpcService.GetPlatformDataById(platformByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getPlatformByIdReply.Result.PlatformData.Count, countConstraint);
        }

        [Test]
        public void GetProgramDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            ProgramGrpcRequest programGrpcRequest = new ProgramGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProgramData)
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
            Task<ListProgramData> getProgramData = _GrpcService.GetProgramData(programGrpcRequest, serverCallContext);

            Assert.That(getProgramData.Result.ProgramData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProgramData.Result.ProgramData.Count, countConstraint);
        }

        [Test]
        public void GetProgramByIdDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            ProgramByIdGrpcRequest programByIdGrpcRequest = new ProgramByIdGrpcRequest();
            programByIdGrpcRequest.Id = "aea9e204-0353-4297-a9ff-bbe75f9b4a93";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProgramDataById)
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
            Task<ListProgramData> getProgramByIdReply = _GrpcService.GetProgramDataById(programByIdGrpcRequest, serverCallContext);

            Assert.That(getProgramByIdReply.Result.ProgramData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getProgramByIdReply.Result.ProgramData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProgramName");
            Assert.That(getProgramByIdReply.Result.ProgramData.First().ProgramName, nameConstraint);
        }

        [Test]
        public void GetProgramByIdDataTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            ProgramByIdGrpcRequest programByIdGrpcRequest = new ProgramByIdGrpcRequest();
            programByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProgramDataById)
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
            Task<ListProgramData> getProgramByIdReply = _GrpcService.GetProgramDataById(programByIdGrpcRequest, serverCallContext);

            Assert.That(getProgramByIdReply.Result.ProgramData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getProgramByIdReply.Result.ProgramData.Count, countConstraint);
        }

        [Test]
        public void GetProjectDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            ProjectGrpcRequest projectGrpcRequest = new ProjectGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProjectData)
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
            Task<ListProjectData> getProjectData = _GrpcService.GetProjectData(projectGrpcRequest, serverCallContext);

            Assert.That(getProjectData.Result.ProjectData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProjectData.Result.ProjectData.Count, countConstraint);
        }

        [Test]
        public void GetProjectByIdDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            ProjectByIdGrpcRequest projectByIdGrpcRequest = new ProjectByIdGrpcRequest();
            projectByIdGrpcRequest.Id = "461616e5-fd7b-491c-9592-8453182e7e72";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProjectDataById)
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
            Task<ListProjectData> getProjectByIdReply = _GrpcService.GetProjectDataById(projectByIdGrpcRequest, serverCallContext);

            Assert.That(getProjectByIdReply.Result.ProjectData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getProjectByIdReply.Result.ProjectData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProjectName");
            Assert.That(getProjectByIdReply.Result.ProjectData.First().ProjectName, nameConstraint);
        }

        [Test]
        public void GetProjectByIdDataTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            ProjectByIdGrpcRequest projectByIdGrpcRequest = new ProjectByIdGrpcRequest();
            projectByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetProjectDataById)
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
            Task<ListProjectData> getProjectByIdReply = _GrpcService.GetProjectDataById(projectByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getProjectByIdReply.Result.ProjectData.Count, countConstraint);
        }

        #endregion
        #region Vehicle

        [Test]
        public void GetVehicleDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            VehicleGrpcRequest vehicleGrpcRequest = new VehicleGrpcRequest();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetVehicleData)
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
            Task<ListVehicleData> getVehicleData = _GrpcService.GetVehicleData(vehicleGrpcRequest, serverCallContext);

            Assert.That(getVehicleData.Result.VehicleData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getVehicleData.Result.VehicleData.Count, countConstraint);
        }

        [Test]
        public void GetVehicleByIdDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            VehicleByIdGrpcRequest vehicleByIdGrpcRequest = new VehicleByIdGrpcRequest();
            vehicleByIdGrpcRequest.Id = "766612a1-5c65-4d17-950d-2841e1888f0b";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetVehicleDataById)
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
            Task<ListVehicleData> getVehicleByIdData = _GrpcService.GetVehicleDataById(vehicleByIdGrpcRequest, serverCallContext);

            Assert.That(getVehicleByIdData.Result.VehicleData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getVehicleByIdData.Result.VehicleData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestVehicleName");
            Assert.That(getVehicleByIdData.Result.VehicleData.First().VehicleName, nameConstraint);
        }

        [Test]
        public void GetVehicleByIdDataTest_False()
        {
            CancellationToken token = CancellationToken.None;
            VehicleByIdGrpcRequest vehicleByIdGrpcRequest = new VehicleByIdGrpcRequest();
            vehicleByIdGrpcRequest.Id = Guid.NewGuid().ToString();

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetVehicleDataById)
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
            Task<ListVehicleData> getVehicleByIdData = _GrpcService.GetVehicleDataById(vehicleByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getVehicleByIdData.Result.VehicleData.Count, countConstraint);
        }

        [Test]
        public void GetVehicleByDisplayDataTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            VehicleByDisplayGrpcRequest vehicleByIdGrpcRequest = new VehicleByDisplayGrpcRequest();
            vehicleByIdGrpcRequest.VehicleDisplay = "TestVehicleDisplay";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetVehicleDataByDisplay)
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
            Task<ListVehicleData> getVehicleByIdData = _GrpcService.GetVehicleDataByDisplay(vehicleByIdGrpcRequest, serverCallContext);

            Assert.That(getVehicleByIdData.Result.VehicleData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getVehicleByIdData.Result.VehicleData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestVehicleName");
            Assert.That(getVehicleByIdData.Result.VehicleData.First().VehicleName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("766612a1-5c65-4d17-950d-2841e1888f0b");
            Assert.That(getVehicleByIdData.Result.VehicleData.First().Id, idConstraint);
        }

        [Test]
        public void GetVehicleByDisplayDataTest_Fails()
        {
            CancellationToken token = CancellationToken.None;
            VehicleByDisplayGrpcRequest vehicleByIdGrpcRequest = new VehicleByDisplayGrpcRequest();
            vehicleByIdGrpcRequest.VehicleDisplay = "";

            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetVehicleDataByDisplay)
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
            Task<ListVehicleData> getVehicleByIdData = _GrpcService.GetVehicleDataByDisplay(vehicleByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getVehicleByIdData.Result.VehicleData.Count, countConstraint);
        }
        #endregion
    }
}

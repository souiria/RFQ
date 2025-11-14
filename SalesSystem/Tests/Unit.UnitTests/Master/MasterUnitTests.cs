using Master;
using Master.Endpoints.GrpcServices;
using Master.Services;

namespace Unit.Tests.Master
{
    class MasterUnitTests
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
        [Category("Unit")]
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
        #region Currency

        [Test]
        [Category("Unit")]
        public void GetCurrencyGrpcTest_Success()
        {
            CurrencyGrpcRequest currencyGrpcRequest = new CurrencyGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCurrencyGrpc));

            Task<ListCurrencyGrpc> getCurrencyGrpcReply = _GrpcService.GetCurrencyGrpc(currencyGrpcRequest, serverCallContext);
            Assert.That(getCurrencyGrpcReply.Result.CurrencyGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCurrencyGrpcReply.Result.CurrencyGrpc.Count, countConstraint);

        }

        [Test]
        [Category("Unit")]
        public void FilterCurrencyGrpcByIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CurrencyGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"ec44e5cd-5832-48dd-b5a3-440b5cb49450\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCurrencyGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestName");
            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc.First().CurrencyName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCurrencyGrpcByIdTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CurrencyGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{ Guid.NewGuid() }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCurrencyGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc.Count, countConstraint);
        }

        #endregion

        #region Customer

        [Test]
        [Category("Unit")]
        public void GetCustomerGrpcTest_Success()
        {
            CustomerGrpcRequest customerGrpcRequest = new CustomerGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerGrpc));

            Task<ListCustomerGrpc> getCustomerGrpc = _GrpcService.GetCustomerGrpc(customerGrpcRequest, serverCallContext);

            Assert.That(getCustomerGrpc.Result.CustomerGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerGrpc.Result.CustomerGrpc.Count, countConstraint);
        }
        [Test]
        [Category("Unit")]
        public void FilterCustomerGrpcByIdTest_Success()
        {
            CustomerByUserIdGrpcRequest customerByIdGrpcRequest = new CustomerByUserIdGrpcRequest();
            customerByIdGrpcRequest.Id = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerGrpcByUserId));

            Task<ListCustomerGrpc> getCustomerGrpcByIdReply = _GrpcService.GetCustomerGrpcByUserId(customerByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("04707931-2cff-4b2c-8fbd-bef614c6a99a");
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpc.First().Id, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerGrpcByIdTest_Fail()
        {
            CustomerByUserIdGrpcRequest customerByIdGrpcRequest = new CustomerByUserIdGrpcRequest();
            customerByIdGrpcRequest.Id = Guid.NewGuid().ToString();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerGrpcByUserId));

            Task<ListCustomerGrpc> getCustomerGrpcByIdReply = _GrpcService.GetCustomerGrpcByUserId(customerByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerLocationTest_Success()
        {
            CustomerLocationGrpcRequest customerGrpcRequest = new CustomerLocationGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerLocationGrpc));

            Task<ListCustomerLocationGrpc> getCustomerLocationGrpc = _GrpcService.GetCustomerLocationGrpc(customerGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpc.Result.CustomerLocationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerLocationGrpc.Result.CustomerLocationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerLocationGrpcByIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerLocationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"3759c3b6-aceb-475e-9ba3-74f13e441e2d\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCustomerLocationGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestCustomerName");
            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc.First().CustomerName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerLocationGrpcByIdTest_Fail()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerLocationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{ Guid.NewGuid }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCustomerLocationGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerLocationGrpcByUserIdTest_Success()
        {
            CustomerLocationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerLocationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerLocationGrpcByUserId));

            Task<ListCustomerLocationGrpc> getCustomerLocationGrpcByUserIdReply = _GrpcService.GetCustomerLocationGrpcByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpcByUserIdReply.Result.CustomerLocationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationGrpcByUserIdReply.Result.CustomerLocationGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestCustomerName");
            Assert.That(getCustomerLocationGrpcByUserIdReply.Result.CustomerLocationGrpc.First().CustomerName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("3759c3b6-aceb-475e-9ba3-74f13e441e2d");
            Assert.That(getCustomerLocationGrpcByUserIdReply.Result.CustomerLocationGrpc.First().Id, idConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerLocationGrpcByUserIdTest_Fails()
        {
            CustomerLocationByUserIdGrpcRequest customerLocationByUserIdGrpcRequest = new CustomerLocationByUserIdGrpcRequest();
            customerLocationByUserIdGrpcRequest.UserId = Guid.NewGuid().ToString();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerLocationGrpcByUserId));

            Task<ListCustomerLocationGrpc> getCustomerLocationGrpcByUserIdReply = _GrpcService.GetCustomerLocationGrpcByUserId(customerLocationByUserIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationGrpcByUserIdReply.Result.CustomerLocationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerSalesEntityGrpcTest_Success()
        {
            CustomerSalesEntityGrpcRequest customerSalesEntityGrpcRequest = new CustomerSalesEntityGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpc));

            Task<ListCustomerSalesEntityGrpc> getCustomerSalesEntityGrpc = _GrpcService.GetCustomerSalesEntityGrpc(customerSalesEntityGrpcRequest, serverCallContext);

            Assert.That(getCustomerSalesEntityGrpc.Result.CustomerSalesEntityGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerSalesEntityGrpc.Result.CustomerSalesEntityGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerSalesEntityDataByUserIdTest_Success()
        {
            CustomerSalesEntityByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerSalesEntityByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpcByUserId));

            Task<ListCustomerSalesEntityGrpc> getCustomerLocationGrpcByIdReply = _GrpcService.GetCustomerSalesEntityGrpcByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerSalesEntityGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerSalesEntityGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestfixedCustomerSalesEntityName");
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerSalesEntityGrpc.First().CustomerSalesEntityName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("84e51c97-4da5-460e-b918-3d70edd87d88");
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerSalesEntityGrpc.First().Id, idConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerSalesEntityDataByUserIdTest_Fails()
        {
            CustomerSalesEntityByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerSalesEntityByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = Guid.NewGuid().ToString();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpcByUserId));

            Task<ListCustomerSalesEntityGrpc> getCustomerLocationGrpcByIdReply = _GrpcService.GetCustomerSalesEntityGrpcByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerSalesEntityGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerProjectAssociationGrpcTest_Success()
        {
            CustomerProjectAssociationGrpcRequest customerProjectAssociationGrpcRequest = new CustomerProjectAssociationGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpcByUserId));

            Task<ListCustomerProjectAssociationGrpc> getCustomerProjectAssociationGrpc = _GrpcService.GetCustomerProjectAssociationGrpc(customerProjectAssociationGrpcRequest, serverCallContext);

            Assert.That(getCustomerProjectAssociationGrpc.Result.CustomerProjectAssociationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerProjectAssociationGrpc.Result.CustomerProjectAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerProjectAssociationGrpcByUserIdTest_Success()
        {
            CustomerProjectAssociationByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerProjectAssociationByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerProjectAssociationGrpcByUserId));

            Task<ListCustomerProjectAssociationGrpc> getCustomerLocationGrpcByIdReply = _GrpcService.GetCustomerProjectAssociationGrpcByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc.Count, countConstraint);
            string expectedId = "fd994af4-57a3-4d95-b75d-b8d502e6a023".ToUpperInvariant();
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(expectedId);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc.First().Id, idConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerProjectAssociationGrpcByUserIdTest_Fails()
        {
            CustomerProjectAssociationByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerProjectAssociationByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = Guid.NewGuid().ToString();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerProjectAssociationGrpcByUserId));

            Task<ListCustomerProjectAssociationGrpc> getCustomerLocationGrpcByIdReply = _GrpcService.GetCustomerProjectAssociationGrpcByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerBusinessUserAssociationGrpcTest_Success()
        {
            CustomerBusinessUserAssociationGrpcRequest customerBuisnessUserAssociationGrpcRequest = new CustomerBusinessUserAssociationGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerBusinessUserAssociationGrpc));

            Task<ListCustomerBusinessUserAssociationGrpc> getcustomerBuisnessUserAssociationData = _GrpcService.GetCustomerBusinessUserAssociationGrpc(customerBuisnessUserAssociationGrpcRequest, serverCallContext);

            Assert.That(getcustomerBuisnessUserAssociationData.Result.CustomerBusinessUserAssociationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getcustomerBuisnessUserAssociationData.Result.CustomerBusinessUserAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerBusinessUserAssociationGrpcByUserIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerBusinessUserAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"UserGuid != null && UserGuid == \"83853662-6d20-41b0-b6ac-fd3271406b6b\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCustomerBuisnessUserAssociationByUserIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationGrpcList.CustomerBusinessUserAssociationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationGrpcList.CustomerBusinessUserAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerBusinessUserAssociationGrpcByUserIdTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerBusinessUserAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"UserGuid != null && UserGuid == \"{ Guid.NewGuid() }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filtercustomerBuisnessUserAssociationByUserIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filtercustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationGrpcList.CustomerBusinessUserAssociationGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filtercustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationGrpcList.CustomerBusinessUserAssociationGrpc.Count, countConstraint);
        }
        #endregion

        #region Project

        [Test]
        [Category("Unit")]
        public void GetMilestoneGrpcTest_Success()
        {
            MilestoneGrpcRequest milestoneGrpcRequest = new MilestoneGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMilestoneGrpc));

            Task<ListMilestoneGrpc> getMilestoneGrpc = _GrpcService.GetMilestoneGrpc(milestoneGrpcRequest, serverCallContext);

            Assert.That(getMilestoneGrpc.Result.MilestoneGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneGrpc.Result.MilestoneGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterMilestoneByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "MilestoneGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"50365c14-734c-406a-b18e-9a3eff9e2d17\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterMilestoneByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestMilestoneEventName");
            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc.First().MilestoneEventName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetMilestoneByIdDataTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "MilestoneGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{ Guid.NewGuid() }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterMilestoneByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
        }

        [Test]
        [Category("Unit")]
        public void GetPlatformGrpcTest_Success()
        {
            PlatformGrpcRequest platformGrpcRequest = new PlatformGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPlatformGrpc));

            Task<ListPlatformGrpc> getMilestoneGrpc = _GrpcService.GetPlatformGrpc(platformGrpcRequest, serverCallContext);

            Assert.That(getMilestoneGrpc.Result.PlatformGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneGrpc.Result.PlatformGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPlatformByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "PlatformGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"46711693-0ea4-4f9a-86c1-4973308bf795\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterPlatformByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestPlatformName");
            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc.First().PlatformName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetPlatformByIdDataTest_False()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "PlatformGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \" {Guid.NewGuid()} \"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterPlatformByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetProgramGrpcTest_Success()
        {
            ProgramGrpcRequest programGrpcRequest = new ProgramGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetProgramGrpc));

            Task<ListProgramGrpc> getProgramGrpc = _GrpcService.GetProgramGrpc(programGrpcRequest, serverCallContext);

            Assert.That(getProgramGrpc.Result.ProgramGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProgramGrpc.Result.ProgramGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetProgramByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProgramGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"aea9e204-0353-4297-a9ff-bbe75f9b4a93\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProgramByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProgramName");
            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc.First().ProgramName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetProgramByIdDataTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProgramGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{ Guid.NewGuid() }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProgramByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetProjectGrpcTest_Success()
        {
            ProjectGrpcRequest projectGrpcRequest = new ProjectGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetProjectGrpc));

            Task<ListProjectGrpc> getProjectGrpc = _GrpcService.GetProjectGrpc(projectGrpcRequest, serverCallContext);

            Assert.That(getProjectGrpc.Result.ProjectGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProjectGrpc.Result.ProjectGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterProjectByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProjectGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"461616e5-fd7b-491c-9592-8453182e7e72\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProjectByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestProjectName");
            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc.First().ProjectName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterProjectByIdDataTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProjectGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{ Guid.NewGuid() }\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProjectByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc.Count, countConstraint);
        }

        #endregion

        #region Vehicle

        [Test]
        [Category("Unit")]
        public void GetVehicleGrpcTest_Success()
        {
            VehicleGrpcRequest vehicleGrpcRequest = new VehicleGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetVehicleGrpc));

            Task<ListVehicleGrpc> getVehicleGrpc = _GrpcService.GetVehicleGrpc(vehicleGrpcRequest, serverCallContext);

            Assert.That(getVehicleGrpc.Result.VehicleGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getVehicleGrpc.Result.VehicleGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterVehicleByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"766612a1-5c65-4d17-950d-2841e1888f0b\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestVehicleName");
            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc.First().VehicleName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetVehicleByIdDataTest_False()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetVehicleByDisplayDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"VehicleDisplay != null && VehicleDisplay == \"TestVehicleDisplay\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByDisplayData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("TestVehicleName");
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.First().VehicleName, nameConstraint);
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo("766612a1-5c65-4d17-950d-2841e1888f0b");
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.First().Id, idConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetVehicleByDisplayDataTest_Fails()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"VehicleDisplay != null && VehicleDisplay == \"\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByDisplayData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
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

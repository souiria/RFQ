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
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCurrencyGrpcReply.Result.CurrencyGrpc.Count, countConstraint);

        }

        [Test]
        [Category("Unit")]
        public void FilterCurrencyGrpcByIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CurrencyGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"EC44E5CD-5832-48DD-B5A3-440B5CB49450\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCurrencyGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCurrencyGrpcByIdReply.Result.CurrencyGrpcList.CurrencyGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTNAME");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerGrpc.Result.CustomerGrpc.Count, countConstraint);
        }
        [Test]
        [Category("Unit")]
        public void FilterCustomerGrpcByIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"04707931-2CFF-4B2C-8FBD-BEF614C6A99A\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> getCustomerGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpcList.CustomerGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpcList.CustomerGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("04707931-2CFF-4B2C-8FBD-BEF614C6A99A");
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpcList.CustomerGrpc.First().Id, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerGrpcByIdTest_Fail()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> getCustomerGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(getCustomerGrpcByIdReply.Result.CustomerGrpcList.CustomerGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerLocationTest_Success()
        {
            CustomerLocationGrpcRequest customerGrpcRequest = new CustomerLocationGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerLocationGrpc));

            Task<ListCustomerLocationGrpc> getCustomerLocationGrpc = _GrpcService.GetCustomerLocationGrpc(customerGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpc.Result.CustomerLocationGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerLocationGrpc.Result.CustomerLocationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerLocationGrpcByIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerLocationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = "Id != null && Id == \"3759C3B6-ACEB-475E-9BA3-74F13E441E2D\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCustomerLocationGrpcByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTCUSTOMERNAME");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterCustomerLocationGrpcByIdReply.Result.CustomerLocationGrpcList.CustomerLocationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerSalesEntityGrpcTest_Success()
        {
            CustomerSalesEntityGrpcRequest customerSalesEntityGrpcRequest = new CustomerSalesEntityGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpc));

            Task<ListCustomerSalesEntityGrpc> getCustomerSalesEntityGrpc = _GrpcService.GetCustomerSalesEntityGrpc(customerSalesEntityGrpcRequest, serverCallContext);

            Assert.That(getCustomerSalesEntityGrpc.Result.CustomerSalesEntityGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerSalesEntityGrpc.Result.CustomerSalesEntityGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerProjectAssociationGrpcTest_Success()
        {
            CustomerProjectAssociationGrpcRequest customerProjectAssociationGrpcRequest = new CustomerProjectAssociationGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerSalesEntityGrpcByUserId));

            Task<ListCustomerProjectAssociationGrpc> getCustomerProjectAssociationGrpc = _GrpcService.GetCustomerProjectAssociationGrpc(customerProjectAssociationGrpcRequest, serverCallContext);

            Assert.That(getCustomerProjectAssociationGrpc.Result.CustomerProjectAssociationGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCustomerProjectAssociationGrpc.Result.CustomerProjectAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCustomerProjectAssociationGrpcByUserIdTest_Success()
        {
            CustomerProjectAssociationByUserIdGrpcRequest customerLocationByIdGrpcRequest = new CustomerProjectAssociationByUserIdGrpcRequest();
            customerLocationByIdGrpcRequest.UserId = "83853662-6D20-41B0-B6AC-FD3271406B6B";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerProjectAssociationGrpcByUserId));

            Task<ListCustomerProjectAssociationGrpc> getCustomerLocationGrpcByIdReply = _GrpcService.GetCustomerProjectAssociationGrpcByUserId(customerLocationByIdGrpcRequest, serverCallContext);

            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCustomerLocationGrpcByIdReply.Result.CustomerProjectAssociationGrpc.Count, countConstraint);
            string expectedId = "fd994af4-57a3-4d95-b75d-b8d502e6a023".ToUpperInvariant();
            EqualConstraint idConstraint = Is.EqualTo(expectedId);
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

            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getcustomerBuisnessUserAssociationData.Result.CustomerBusinessUserAssociationGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterCustomerBusinessUserAssociationGrpcByUserIdTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "CustomerBusinessUserAssociationGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"UserGuid != null && UserGuid == \"83853662-6D20-41B0-B6AC-FD3271406B6B\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterCustomerBuisnessUserAssociationByUserIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterCustomerBuisnessUserAssociationByUserIdData.Result.CustomerBusinessUserAssociationGrpcList.CustomerBusinessUserAssociationGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
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
            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneGrpc.Result.MilestoneGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterMilestoneByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "MilestoneGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"50365C14-734C-406A-B18E-9A3EFF9E2D17\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterMilestoneByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterMilestoneByIdReply.Result.MilestoneGrpcList.MilestoneGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTMILESTONEEVENTNAME");
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
            EqualConstraint countConstraint = Is.EqualTo(0);
        }

        [Test]
        [Category("Unit")]
        public void GetPlatformGrpcTest_Success()
        {
            PlatformGrpcRequest platformGrpcRequest = new PlatformGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPlatformGrpc));

            Task<ListPlatformGrpc> getMilestoneGrpc = _GrpcService.GetPlatformGrpc(platformGrpcRequest, serverCallContext);

            Assert.That(getMilestoneGrpc.Result.PlatformGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMilestoneGrpc.Result.PlatformGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPlatformByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "PlatformGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"46711693-0EA4-4F9A-86C1-4973308BF795\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterPlatformByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPlatformByIdReply.Result.PlatformGrpcList.PlatformGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTPLATFORMNAME");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProgramGrpc.Result.ProgramGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetProgramByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProgramGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"AEA9E204-0353-4297-A9FF-BBE75F9B4A93\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProgramByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterProgramByIdReply.Result.ProgramGrpcList.ProgramGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTPROGRAMNAME");
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
            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getProjectGrpc.Result.ProjectGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterProjectByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "ProjectGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"461616E5-FD7B-491C-9592-8453182E7E72\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterProjectByIdReply = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterProjectByIdReply.Result.ProjectGrpcList.ProjectGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTPROJECTNAME");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
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
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getVehicleGrpc.Result.VehicleGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterVehicleByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"766612A1-5C65-4D17-950D-2841E1888F0B\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTVEHICLENAME");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterVehicleByIdData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetVehicleByDisplayDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "VehicleGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"VehicleDisplay != null && VehicleDisplay == \"TESTVEHICLEDISPLAY\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterVehicleByDisplayData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTVEHICLENAME");
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.First().VehicleName, nameConstraint);
            EqualConstraint idConstraint = Is.EqualTo("766612A1-5C65-4D17-950D-2841E1888F0B");
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

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterVehicleByDisplayData.Result.VehicleGrpcList.VehicleGrpc.Count, countConstraint);
        }
        #endregion
        #region SupplierGroup

        [Test]
        [Category("Unit")]
        public void GetSupplierGroupGrpcTest_Success()
        {
            SupplierGroupGrpcRequest supplierGroupGrpcRequest = new SupplierGroupGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetSupplierGroupGrpc));

            Task<ListSupplierGroupGrpc> getSupplierGroupGrpc = _GrpcService.GetSupplierGroupGrpc(supplierGroupGrpcRequest, serverCallContext);

            Assert.That(getSupplierGroupGrpc.Result.SupplierGroupGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getSupplierGroupGrpc.Result.SupplierGroupGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterSupplierGroupByIdDataTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "SupplierGroupGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"766612A1-5C65-4D17-950D-2841E1888F0B\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterSupplierGroupByIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterSupplierGroupByIdData.Result.SupplierGroupGrpcList.SupplierGroupGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterSupplierGroupByIdData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTFIXEDSUPPLIERGROUPNAME");
            Assert.That(filterSupplierGroupByIdData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.First().SupplierGroupName, nameConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetSupplierGroupByIdDataTest_False()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "SupplierGroupGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"Id != null && Id == \"\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterSupplierGroupByIdData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(0);
            Assert.That(filterSupplierGroupByIdData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetSupplierGroupBySupplierGroupNameTest_Success()
        {
            MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
            filterRequest.DatabaseList = "SupplierGroupGrpc".ToUpperInvariant();
            filterRequest.FilterExpression = $"SupplierGroupName != null && SupplierGroupName == \"TESTFIXEDSUPPLIERGROUPNAME\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));

            Task<MastersFilterResponseGrpc> filterSupplierGroupByDisplayData = _GrpcService.FilterMasterDataGrpc(filterRequest, serverCallContext);

            Assert.That(filterSupplierGroupByDisplayData.Result.SupplierGroupGrpcList.SupplierGroupGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterSupplierGroupByDisplayData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.Count, countConstraint);
            EqualConstraint nameConstraint = Is.EqualTo("TESTFIXEDSUPPLIERGROUPNAME");
            Assert.That(filterSupplierGroupByDisplayData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.First().SupplierGroupName, nameConstraint);
            EqualConstraint idConstraint = Is.EqualTo("766612A1-5C65-4D17-950D-2841E1888F0B");
            Assert.That(filterSupplierGroupByDisplayData.Result.SupplierGroupGrpcList.SupplierGroupGrpc.First().Id, idConstraint);
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

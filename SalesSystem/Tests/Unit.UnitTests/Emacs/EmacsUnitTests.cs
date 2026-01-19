using Emacs;
using Emacs.Endpoints.GrpcServices;
using Emacs.Services;

namespace Unit.Tests.Emacs
{
    class EmacsUnitTests
    {
        EMACSAccessService _EMACSAccessService;
        EMACSGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _EMACSAccessService = new EMACSAccessService(serviceProvider, true);
            Mock<ILogger<EMACSGrpcService>> logger = new Mock<ILogger<EMACSGrpcService>>();
            _GrpcService = new EMACSGrpcService(_EMACSAccessService, logger.Object);
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

        #region CombinedParts
        [Test]
        [Category("Unit")]
        public void GetCombinedPartsTest_Success()
        {
            CombinedPartsGrpcRequest request = new CombinedPartsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCombinedPartsGrpc));

            Task<ListCombinedPartsGrpc> getCombinedPartsGrpcReply = _GrpcService.GetCombinedPartsGrpc(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.CombinedPartsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.CombinedPartsGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void GetCombinedPartsGrpcCountTest_Success()
        {
            CombinedPartsCountGrpcRequest request = new CombinedPartsCountGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCombinedPartsGrpcCount));

            Task<CombinedPartsCountGrpc> getCombinedPartsGrpcReply = _GrpcService.GetCombinedPartsGrpcCount(request, serverCallContext);

            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.Count, countConstraint);
        }
        #endregion

        #region PartCategoryDetail
        [Test]
        [Category("Unit")]
        public void GetAllPartCatogoryDetail_Success()
        {
            PartCategoryDetailGrpcRequest request = new PartCategoryDetailGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<ListPartCategoryDetailGrpc> getCombinedPartsGrpcReply = _GrpcService.GetPartCategoryDetailGrpc(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPartCategoryDetailByCategoryCode_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PartCategoryDetailGrpc";
            request.FilterExpression = "CategoryCode != null && CategoryCode == \"TestCategoryCode\"";

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterCombinedPartsGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartCategoryDetailGrpc.PartCategoryDetailGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartCategoryDetailGrpc.PartCategoryDetailGrpc.Count, countConstraint);
            EqualConstraint categoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartCategoryDetailGrpc.PartCategoryDetailGrpc.First().CategoryCode, categoryCodeConstraint);
        }
        #endregion

        #region PartClassDetail
        [Test]
        [Category("Unit")]
        public void GetAllPartClassDetail_Success()
        {
            PartClassDetailGrpcRequest request = new PartClassDetailGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartClassDetailGrpc));

            Task<ListPartClassDetailGrpc> getPartClassDetailGrpcReply = _GrpcService.GetPartClassDetailGrpc(request, serverCallContext);

            Assert.That(getPartClassDetailGrpcReply.Result.PartClassDetailGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartClassDetailGrpcReply.Result.PartClassDetailGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPartClassDetailByClasses_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PartClassDetailGrpc";
            request.FilterExpression = "Class1 != null && Class2 != null && Class1 == \"TestClass1\" && Class2 == \"0\"";

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterCombinedPartsGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartClassDetailGrpc.PartClassDetailGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartClassDetailGrpc.PartClassDetailGrpc.Count, countConstraint);
            EqualConstraint class1Constraint = Is.EqualTo("TestClass1");
            EqualConstraint class2Constraint = Is.EqualTo(0);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartClassDetailGrpc.PartClassDetailGrpc.First().Class1, class1Constraint);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartClassDetailGrpc.PartClassDetailGrpc.First().Class2, class2Constraint);
        }

        #endregion

        #region PartGroups
        [Test]
        [Category("Unit")]
        public void GetAllPartGroups_Success()
        {
            PartGroupsGrpcRequest request = new PartGroupsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsGrpc));

            Task<ListPartGroupsGrpc> getPartGroupsGrpcReply = _GrpcService.GetPartGroupsGrpc(request, serverCallContext);

            Assert.That(getPartGroupsGrpcReply.Result.PartGroupsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsGrpcReply.Result.PartGroupsGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPartGroupsGrpcByPartGroup_Success()
        {
            CancellationToken token = CancellationToken.None;

            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PartGroupsGrpc";
            request.FilterExpression = "PartGroup != null && PartGroup == \"TestPartGroup\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterCombinedPartsGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsGrpc.PartGroupsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsGrpc.PartGroupsGrpc.Count, countConstraint);
            EqualConstraint partGroupsConstraint = Is.EqualTo("TestPartGroup");
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsGrpc.PartGroupsGrpc.First().PartGroup, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        [Category("Unit")]
        public void GetAllPartGroupsConst_Success()
        {
            PartGroupsConstGrpcRequest request = new PartGroupsConstGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsConstGrpc));

            Task<ListPartGroupsConstGrpc> getPartGroupsConstGrpcReply = _GrpcService.GetPartGroupsConstGrpc(request, serverCallContext);

            Assert.That(getPartGroupsConstGrpcReply.Result.PartGroupsConstGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsConstGrpcReply.Result.PartGroupsConstGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPartGroupsConstByGroup3_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PartGroupsConstGrpc";
            request.FilterExpression = "Code != null && Code == \"TestCode\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterCombinedPartsGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsConstGrpc.PartGroupsConstGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsConstGrpc.PartGroupsConstGrpc.Count, countConstraint);
            EqualConstraint partGroupsConstraint = Is.EqualTo("TestCode");
            Assert.That(filterCombinedPartsGrpcReply.Result.ListPartGroupsConstGrpc.PartGroupsConstGrpc.First().Code, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        [Category("Unit")]
        public void GetAllCustomerData_Success()
        {
            GetCustomerDataGrpcRequest request = new GetCustomerDataGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerDataGrpc));

            Task<ListCustomerDataGrpc> getAllCustomerDataReply = _GrpcService.GetCustomerDataGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc.Count, countConstraint);
        }
        #endregion

        #region ColourCode
        [Test]
        [Category("Unit")]
        public void GetAllColourCode_Success()
        {
            GetColourCodeGrpcRequest request = new GetColourCodeGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetColourCodeGrpc));

            Task<ListColourCodeGrpc> getAllCustomerDataReply = _GrpcService.GetColourCodeGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.ColourCodeGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.ColourCodeGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterColourCodeGrpcByColorCode_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "ColourCodeGrpc";
            request.FilterExpression = "ClMk != null && ClMk == \"TestClMk\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterColourCodeGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterColourCodeGrpcReply.Result.ListColourCodeGrpc.ColourCodeGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterColourCodeGrpcReply.Result.ListColourCodeGrpc.ColourCodeGrpc.Count, countConstraint);
            EqualConstraint colorCodeConstraint = Is.EqualTo("TestClMk");
            Assert.That(filterColourCodeGrpcReply.Result.ListColourCodeGrpc.ColourCodeGrpc.First().ClMk, colorCodeConstraint);
        }
        #endregion

        #region MaterialGroups
        [Test]
        [Category("Unit")]
        public void GetAllMaterialGroups_Success()
        {
            GetMaterialGroupsGrpcRequest request = new GetMaterialGroupsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialGroupsGrpc));

            Task<ListMaterialGroupsGrpc> getAllCustomerDataReply = _GrpcService.GetMaterialGroupsGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterMaterialGroupsByMaterialGroupId_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "MaterialGroupsGrpc";
            request.FilterExpression = "MaterialGroup != null && MaterialGroup == \"TestMaterialGroup\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterMaterialGroupDataReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterMaterialGroupDataReply.Result.ListMaterialGroupsGrpc.MaterialGroupsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterMaterialGroupDataReply.Result.ListMaterialGroupsGrpc.MaterialGroupsGrpc.Count, countConstraint);
            EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(filterMaterialGroupDataReply.Result.ListMaterialGroupsGrpc.MaterialGroupsGrpc.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region MaterialTypes
        [Test]
        [Category("Unit")]
        public void GetAllMaterialTypes_Success()
        {
            GetMaterialTypesGrpcRequest request = new GetMaterialTypesGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialTypesGrpc));

            Task<ListMaterialTypesGrpc> getMaterialTypesReply = _GrpcService.GetMaterialTypesGrpc(request, serverCallContext);

            Assert.That(getMaterialTypesReply.Result.MaterialTypesGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMaterialTypesReply.Result.MaterialTypesGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterMaterialTypesByMaterials_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "MaterialTypesGrpc";
            request.FilterExpression = "MaterialType != null && MaterialGroup != null && MaterialType == \"TestMaterialType\" && MaterialGroup == \"TestMaterialGroup\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterMaterialTypeDataReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterMaterialTypeDataReply.Result.ListMaterialTypesGrpc.MaterialTypesGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterMaterialTypeDataReply.Result.ListMaterialTypesGrpc.MaterialTypesGrpc.Count, countConstraint);
            EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialType");
            EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(filterMaterialTypeDataReply.Result.ListMaterialTypesGrpc.MaterialTypesGrpc.First().MaterialType, materialTypeConstraint);
            Assert.That(filterMaterialTypeDataReply.Result.ListMaterialTypesGrpc.MaterialTypesGrpc.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region NPACustomer
        [Test]
        [Category("Unit")]
        public void GetAllNPACustomer_Success()
        {
            GetNPACustomerGrpcRequest request = new GetNPACustomerGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetNPACustomerGrpc));

            Task<ListNPACustomerGrpc> getNPACustomerReply = _GrpcService.GetNPACustomerGrpc(request, serverCallContext);

            Assert.That(getNPACustomerReply.Result.NPACustomerGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPACustomerReply.Result.NPACustomerGrpc.Count, countConstraint);
        }
        #endregion

        #region NPASupplier
        [Test]
        [Category("Unit")]
        public void GetAllNPASupplier_Success()
        {
            GetNPASupplierGrpcRequest request = new GetNPASupplierGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetNPASupplierGrpc));

            Task<ListNPASupplierGrpc> getNPASupplierReply = _GrpcService.GetNPASupplierGrpc(request, serverCallContext);

            Assert.That(getNPASupplierReply.Result.NPASupplierGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPASupplierReply.Result.NPASupplierGrpc.Count, countConstraint);
        }
        #endregion

        #region Supplier
        [Test]
        [Category("Unit")]
        public void GetAllSupplier_Success()
        {
            GetSuppliersGrpcRequest request = new GetSuppliersGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetSuppliersGrpc));

            Task<ListSuppliersGrpc> getSupplierReply = _GrpcService.GetSuppliersGrpc(request, serverCallContext);

            Assert.That(getSupplierReply.Result.SuppliersGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getSupplierReply.Result.SuppliersGrpc.Count, countConstraint);
        }
        #endregion

        #region PARTMS
        [Test]
        [Category("Unit")]
        public void GetAllPARTMSGrpc_Success()
        {
            GetPARTMSGrpcRequest request = new GetPARTMSGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpc));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpc(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByClass_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "ClassDetailGroupCode != null && ClassDetailId != null && ClassDetailGroupCode == \"TestClassDetailGroupCode\" && ClassDetailId == \"0\"";

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint class1Constraint = Is.EqualTo("TestClassDetailGroupCode");
            EqualConstraint class2Constraint = Is.EqualTo("0");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().ClassDetailGroupCode, class1Constraint);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().ClassDetailId, class2Constraint);
        }

        [Test]
        [Category("Unit")]
        public void GetPARTMSGrpcByColorCode_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "ColorCode != null && ColorCode == \"TestColorCode\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint colorConstraint = Is.EqualTo("TestColorCode");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().ColorCode, colorConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByMaterial_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "MaterialGroupId != null && MaterialTypeId != null && MaterialGroupId == \"TestMaterialGroupId\" && MaterialTypeId == \"TestMaterialTypeId\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialTypeId");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().MaterialGroupId, materialGroupConstraint);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().MaterialTypeId, materialTypeConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByMaterialGroup_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "MaterialGroupId != null && MaterialGroupId == \"TestMaterialGroupId\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().MaterialGroupId, materialGroupConstraint);
        }
        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByPartGroup_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "ClassDetailGroupCode != null && ClassDetailGroupCode == \"TestClassDetailGroupCode\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint partGroupConstraint = Is.EqualTo("TestClassDetailGroupCode");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().ClassDetailGroupCode, partGroupConstraint);
        }
        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByCategoryCode_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "CategoryCode != null && CategoryCode == \"TestCategoryCode\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().CategoryCode, catogoryCodeConstraint);
        }
        [Test]
        [Category("Unit")]
        public void FilterPARTMSGrpcByPartGroupsConstCode_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "PARTMSGrpc";
            request.FilterExpression = "Group3 != null && Group3 == \"TestGroup3\"";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterPARTMSGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.Count, countConstraint);
            EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestGroup3");
            Assert.That(filterPARTMSGrpcReply.Result.ListPARTMSGrpc.PARTMSGrpc.First().Group3, catogoryCodeConstraint);
        }
        #endregion

        #region AlternativeParts
        [Test]
        [Category("Unit")]
        public void GetAllAlternativePartsGrpc_Success()
        {
            GetAlternativePartsGrpcRequest request = new GetAlternativePartsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetAlternativePartsGrpc));

            Task<ListAlternativePartsGrpc> getAlternativePartsGrpcReply = _GrpcService.GetAlternativePartsGrpc(request, serverCallContext);

            Assert.That(getAlternativePartsGrpcReply.Result.AlternativePartsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAlternativePartsGrpcReply.Result.AlternativePartsGrpc.Count, countConstraint);
        }

        [Test]
        [Category("Unit")]
        public void FilterAlternativePartsGrpcBySumitomoNumber_Success()
        {
            EmacsFilterRequestGrpc request = new EmacsFilterRequestGrpc();
            request.DatabaseList = "AlternativePartsGrpc";
            request.FilterExpression = "SumitomoNumber != null && SumitomoNumber == \"TestSumitomoNumber\"";

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            Task<EmacsFilterResponseGrpc> filterAlternativePartsGrpcReply = _GrpcService.FilterEmacsDataGrpc(request, serverCallContext);

            Assert.That(filterAlternativePartsGrpcReply.Result.ListAlternativePartsGrpc.AlternativePartsGrpc, Is.Not.Null);
            EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(filterAlternativePartsGrpcReply.Result.ListAlternativePartsGrpc.AlternativePartsGrpc.Count, countConstraint);
            EqualConstraint class1Constraint = Is.EqualTo("TestSumitomoDescription");
            Assert.That(filterAlternativePartsGrpcReply.Result.ListAlternativePartsGrpc.AlternativePartsGrpc.First().SumitomoDescription, class1Constraint);        }
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
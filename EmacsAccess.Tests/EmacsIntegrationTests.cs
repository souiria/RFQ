using Emacs;
using Emacs.Endpoints.GrpcServices;
using Emacs.Services;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmacsAccess.Tests
{
    public class EmacsIntegrationTests
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

        #region CombinedParts
        [Test]
        public void GetCombinedPartsTest_Success()
        {
            CombinedPartsGrpcRequest request = new CombinedPartsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCombinedPartsGrpc));

            Task<ListCombinedPartsGrpc> getCombinedPartsGrpcReply = _GrpcService.GetCombinedPartsGrpc(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.CombinedPartsGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.CombinedPartsGrpc.Count, countConstraint);
        }

        [Test]
        public void GetCombinedPartsGrpcCountTest_Success()
        {
            CombinedPartsCountGrpcRequest request = new CombinedPartsCountGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCombinedPartsGrpcCount));

            Task<CombinedPartsCountGrpc> getCombinedPartsGrpcReply = _GrpcService.GetCombinedPartsGrpcCount(request, serverCallContext);

            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.Count, countConstraint);
        }
        #endregion

        #region PartCategoryDetail
        [Test]
        public void GetAllPartCatogoryDetail_Success()
        {
            PartCategoryDetailGrpcRequest request = new PartCategoryDetailGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<ListPartCategoryDetailGrpc> getCombinedPartsGrpcReply = _GrpcService.GetPartCategoryDetailGrpc(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc.Count, countConstraint);
        }

        [Test]
        public void GetPartCategoryDetailByCategoryCode_Success()
        {
            PartCategoryDetailByCategoryCodeGrpcRequest request = new PartCategoryDetailByCategoryCodeGrpcRequest();
            request.CategoryCode = "TestCategoryCode";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartCategoryDetailGrpcByCategoryCode));

            Task<ListPartCategoryDetailGrpc> getCombinedPartsGrpcReply = _GrpcService.GetPartCategoryDetailGrpcByCategoryCode(request, serverCallContext);
           
            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint categoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(getCombinedPartsGrpcReply.Result.PartCategoryDetailGrpc.First().CategoryCode, categoryCodeConstraint);
        }
        #endregion

        #region PartClassDetail
        [Test]
        public void GetAllPartClassDetail_Success()
        {
            PartClassDetailGrpcRequest request = new PartClassDetailGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartClassDetailGrpc));

            Task<ListPartClassDetailData> getPartClassDetailGrpcReply = _GrpcService.GetPartClassDetailGrpc(request, serverCallContext);

            Assert.That(getPartClassDetailGrpcReply.Result.PartClassDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartClassDetailGrpcReply.Result.PartClassDetailData.Count, countConstraint);
        }

        [Test]
        public void GetPartClassDetailByClasses_Success()
        {
            PartClassDetailByClassesGrpcRequest request = new PartClassDetailByClassesGrpcRequest();
            request.Class1 = "TestClass1";
            request.Class2 = 0;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartClassDetailGrpcByClasses));

            Task<ListPartClassDetailData> getCombinedPartsGrpcReply = _GrpcService.GetPartClassDetailGrpcByClasses(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.PartClassDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsGrpcReply.Result.PartClassDetailData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint class1Constraint = Is.EqualTo("TestClass1");
            NUnit.Framework.Constraints.EqualConstraint class2Constraint = Is.EqualTo(0);
            Assert.That(getCombinedPartsGrpcReply.Result.PartClassDetailData.First().Class1, class1Constraint);
            Assert.That(getCombinedPartsGrpcReply.Result.PartClassDetailData.First().Class2, class2Constraint);
        }

        #endregion

        #region PartGroups
        [Test]
        public void GetAllPartGroups_Success()
        {
            PartGroupsGrpcRequest request = new PartGroupsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsGrpc));

            Task<ListPartGroupsGrpc> getPartGroupsGrpcReply = _GrpcService.GetPartGroupsGrpc(request, serverCallContext);

            Assert.That(getPartGroupsGrpcReply.Result.PartGroupsGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsGrpcReply.Result.PartGroupsGrpc.Count, countConstraint);
        }

        [Test]
        public void GetPartGroupsGrpcByPartGroup_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartGroupsByPartGroupGrpcRequest request = new PartGroupsByPartGroupGrpcRequest();
            request.PartGroup = "TestPartGroup";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsGrpcByPartGroup));

            Task<ListPartGroupsGrpc> getCombinedPartsGrpcReply = _GrpcService.GetPartGroupsGrpcByPartGroup(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupsConstraint = Is.EqualTo("TestPartGroup");
            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsGrpc.First().PartGroup, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        public void GetAllPartGroupsConst_Success()
        {
            PartGroupsConstGrpcRequest request = new PartGroupsConstGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsConstGrpc));

            Task<ListPartGroupsConstGrpc> getPartGroupsConstGrpcReply = _GrpcService.GetPartGroupsConstGrpc(request, serverCallContext);

            Assert.That(getPartGroupsConstGrpcReply.Result.PartGroupsConstGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsConstGrpcReply.Result.PartGroupsConstGrpc.Count, countConstraint);
        }

        [Test]
        public void GetPartGroupsConstByGroup3_Success()
        {
            PartGroupsConstByGroup3GrpcRequest request = new PartGroupsConstByGroup3GrpcRequest();
            request.Group3 = "TestCode";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPartGroupsConstGrpcByGroup3));

            Task<ListPartGroupsConstGrpc> getCombinedPartsGrpcReply = _GrpcService.GetPartGroupsConstGrpcByGroup3(request, serverCallContext);

            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsConstGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsConstGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupsConstraint = Is.EqualTo("TestCode");
            Assert.That(getCombinedPartsGrpcReply.Result.PartGroupsConstGrpc.First().Code, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        public void GetAllCustomerData_Success()
        {
            GetCustomerDataGrpcRequest request = new GetCustomerDataGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetCustomerDataGrpc));

            Task<ListCustomerDataGrpc> getAllCustomerDataReply = _GrpcService.GetCustomerDataGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc.Count, countConstraint);
        }
        #endregion

        #region ColourCode
        [Test]
        public void GetAllColourCode_Success()
        {
            GetColourCodeGrpcRequest request = new GetColourCodeGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetColourCodeGrpc));

            Task<ListColourCodeGrpc> getAllCustomerDataReply = _GrpcService.GetColourCodeGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.ColourCodeGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.ColourCodeGrpc.Count, countConstraint);
        }

        [Test]
        public void GetColourCodeGrpcByColorCode_Success()
        {
            GetColourCodeByColorCodeGrpcRequest request = new GetColourCodeByColorCodeGrpcRequest();
            request.ColorCode = "TestClMk";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetColourCodeGrpcByColorCode));

            Task<ListColourCodeGrpc> getColourCodeGrpcReply = _GrpcService.GetColourCodeGrpcByColorCode(request, serverCallContext);

            Assert.That(getColourCodeGrpcReply.Result.ColourCodeGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getColourCodeGrpcReply.Result.ColourCodeGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorCodeConstraint = Is.EqualTo("TestClMk");
            Assert.That(getColourCodeGrpcReply.Result.ColourCodeGrpc.First().ClMk, colorCodeConstraint);
        }
        #endregion

        #region MaterialGroups
        [Test]
        public void GetAllMaterialGroups_Success()
        {
            GetMaterialGroupsGrpcRequest request = new GetMaterialGroupsGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialGroupsGrpc));

            Task<ListMaterialGroupsGrpc> getAllCustomerDataReply = _GrpcService.GetMaterialGroupsGrpc(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsGrpc.Count, countConstraint);
        }

        [Test]
        public void GetMaterialGroupsByMaterialGroupId_Success()
        {
            GetMaterialGroupsByMaterialGroupIdGrpcRequest request = new GetMaterialGroupsByMaterialGroupIdGrpcRequest();
            request.MaterialGroup = "TestMaterialGroup";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialGroupsGrpcByMaterialGroupId));

            Task<ListMaterialGroupsGrpc> getMaterialGroupDataReply = _GrpcService.GetMaterialGroupsGrpcByMaterialGroupId(request, serverCallContext);

            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsGrpc.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region MaterialTypes
        [Test]
        public void GetAllMaterialTypes_Success()
        {
            GetMaterialTypesGrpcRequest request = new GetMaterialTypesGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialTypesGrpc));

            Task<ListMaterialTypesGrpc> getMaterialTypesReply = _GrpcService.GetMaterialTypesGrpc(request, serverCallContext);

            Assert.That(getMaterialTypesReply.Result.MaterialTypesGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMaterialTypesReply.Result.MaterialTypesGrpc.Count, countConstraint);
        }

        [Test]
        public void GetMaterialTypesByMaterials_Success()
        {
            GetMaterialTypesByMaterialsGrpcRequest request = new GetMaterialTypesByMaterialsGrpcRequest();
            request.MaterialType = "TestMaterialType";
            request.MaterialGroup = "TestMaterialGroup";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetMaterialTypesGrpcByMaterials));

            Task<ListMaterialTypesGrpc> getMaterialTypeDataReply = _GrpcService.GetMaterialTypesGrpcByMaterials(request, serverCallContext);

            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialType");
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesGrpc.First().MaterialType, materialTypeConstraint);
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesGrpc.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region NPACustomer
        [Test]
        public void GetAllNPACustomer_Success()
        {
            GetNPACustomerGrpcRequest request = new GetNPACustomerGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetNPACustomerGrpc));

            Task<ListNPACustomerGrpc> getNPACustomerReply = _GrpcService.GetNPACustomerGrpc(request, serverCallContext);

            Assert.That(getNPACustomerReply.Result.NPACustomerGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPACustomerReply.Result.NPACustomerGrpc.Count, countConstraint);
        }
        #endregion

        #region NPASupplier
        [Test]
        public void GetAllNPASupplier_Success()
        {
            GetNPASupplierGrpcRequest request = new GetNPASupplierGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetNPASupplierGrpc));

            Task<ListNPASupplierGrpc> getNPASupplierReply = _GrpcService.GetNPASupplierGrpc(request, serverCallContext);

            Assert.That(getNPASupplierReply.Result.NPASupplierGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPASupplierReply.Result.NPASupplierGrpc.Count, countConstraint);
        }
        #endregion

        #region Supplier
        [Test]
        public void GetAllSupplier_Success()
        {
            GetSuppliersGrpcRequest request = new GetSuppliersGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetSuppliersGrpc));

            Task<ListSuppliersGrpc> getSupplierReply = _GrpcService.GetSuppliersGrpc(request, serverCallContext);

            Assert.That(getSupplierReply.Result.SuppliersGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getSupplierReply.Result.SuppliersGrpc.Count, countConstraint);
        }
        #endregion

        #region PARTMS
        [Test]
        public void GetAllPARTMSGrpc_Success()
        {
            GetPARTMSGrpcRequest request = new GetPARTMSGrpcRequest();
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpc));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpc(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
        }

        [Test]
        public void GetPARTMSGrpcByClass_Success()
        {
            GetPARTMSGrpcByClassGrpcRequest request = new GetPARTMSGrpcByClassGrpcRequest();
            request.Class1 = "TestClassDetailGroupCode";
            request.Class2 = 0;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByClass));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByClass(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint class1Constraint = Is.EqualTo("TestClassDetailGroupCode");
            NUnit.Framework.Constraints.EqualConstraint class2Constraint = Is.EqualTo("0");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().ClassDetailGroupCode, class1Constraint);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().ClassDetailId, class2Constraint);
        }

        [Test]
        public void GetPARTMSGrpcByColorCode_Success()
        {
            GetPARTMSGrpcByColorCodeGrpcRequest request = new GetPARTMSGrpcByColorCodeGrpcRequest();
            request.ColorCode = "TestColorCode";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByColorCode));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByColorCode(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo("TestColorCode");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().ColorCode, colorConstraint);
        }

        [Test]
        public void GetPARTMSGrpcByMaterial_Success()
        {
            GetPARTMSGrpcByMaterialGrpcRequest request = new GetPARTMSGrpcByMaterialGrpcRequest();
            request.MaterialGroup = "TestMaterialGroupId";
            request.MaterialType = "TestMaterialTypeId";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByMaterial));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByMaterial(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            NUnit.Framework.Constraints.EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialTypeId");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().MaterialGroupId, materialGroupConstraint);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().MaterialTypeId, materialTypeConstraint);
        }

        [Test]
        public void GetPARTMSGrpcByMaterialGroup_Success()
        {
            GetPARTMSGrpcByMaterialGroupGrpcRequest request = new GetPARTMSGrpcByMaterialGroupGrpcRequest();
            request.MaterialGroup = "TestMaterialGroupId";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByMaterialGroup));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByMaterialGroup(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().MaterialGroupId, materialGroupConstraint);
        }
        [Test]
        public void GetPARTMSGrpcByPartGroup_Success()
        {
            GetPARTMSGrpcByPartGroupGrpcRequest request = new GetPARTMSGrpcByPartGroupGrpcRequest();
            request.PartGroup = "TestClassDetailGroupCode";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByPartGroup));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByPartGroup(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupConstraint = Is.EqualTo("TestClassDetailGroupCode");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().ClassDetailGroupCode, partGroupConstraint);
        }
        [Test]
        public void GetPARTMSGrpcByCatogoryCode_Success()
        {
            GetPARTMSGrpcByCategoryCodeGrpcRequest request = new GetPARTMSGrpcByCategoryCodeGrpcRequest();
            request.CatogoryCode = "TestCategoryCode";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByCategoryCode));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByCategoryCode(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().CategoryCode, catogoryCodeConstraint);
        }
        [Test]
        public void GetPARTMSGrpcByPartGroupsConstCode_Success()
        {
            GetPARTMSGrpcByPartGroupsConstCodeGrpcRequest request = new GetPARTMSGrpcByPartGroupsConstCodeGrpcRequest();
            request.PartGroupsConstCode = "TestGroup3";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.GetPARTMSGrpcByPartGroupsConstCode));

            Task<ListPARTMSGrpc> getPARTMSGrpcReply = _GrpcService.GetPARTMSGrpcByPartGroupsConstCode(request, serverCallContext);

            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestGroup3");
            Assert.That(getPARTMSGrpcReply.Result.PARTMSGrpc.First().Group3, catogoryCodeConstraint);
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

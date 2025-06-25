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

        #region CombinedParts
        [Test]
        public void GetCombinedPartsTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CombinedPartsGrpcRequest request = new CombinedPartsGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCombinedPartsData)
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
            Task<ListCombinedPartsData> getCombinedPartsDataReply = _GrpcService.GetCombinedPartsData(request, serverCallContext);

            Assert.That(getCombinedPartsDataReply.Result.CombinedPartsData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsDataReply.Result.CombinedPartsData.Count, countConstraint);
        }

        [Test]
        public void GetCombinedPartsDataCountTest_Success()
        {
            CancellationToken token = CancellationToken.None;
            CombinedPartsCountGrpcRequest request = new CombinedPartsCountGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetCombinedPartsDataCount)
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
            Task<CombinedPartsCountData> getCombinedPartsDataReply = _GrpcService.GetCombinedPartsDataCount(request, serverCallContext);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsDataReply.Result.Count, countConstraint);
        }
        #endregion

        #region PartCategoryDetail
        [Test]
        public void GetAllPartCatogoryDetail_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartCategoryDetailGrpcRequest request = new PartCategoryDetailGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartCategoryDetailData)
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
            Task<ListPartCategoryDetailData> getCombinedPartsDataReply = _GrpcService.GetPartCategoryDetailData(request, serverCallContext);

            Assert.That(getCombinedPartsDataReply.Result.PartCategoryDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getCombinedPartsDataReply.Result.PartCategoryDetailData.Count, countConstraint);
        }

        [Test]
        public void GetPartCategoryDetailByCategoryCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartCategoryDetailByCategoryCodeGrpcRequest request = new PartCategoryDetailByCategoryCodeGrpcRequest();
            request.CategoryCode = "TestCategoryCode";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartCategoryDetailDataByCategoryCode)
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
            Task<ListPartCategoryDetailData> getCombinedPartsDataReply = _GrpcService.GetPartCategoryDetailDataByCategoryCode(request, serverCallContext);
           
            Assert.That(getCombinedPartsDataReply.Result.PartCategoryDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsDataReply.Result.PartCategoryDetailData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint categoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(getCombinedPartsDataReply.Result.PartCategoryDetailData.First().CategoryCode, categoryCodeConstraint);
        }
        #endregion

        #region PartClassDetail
        [Test]
        public void GetAllPartClassDetail_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartClassDetailGrpcRequest request = new PartClassDetailGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartClassDetailData)
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
            Task<ListPartClassDetailData> getPartClassDetailDataReply = _GrpcService.GetPartClassDetailData(request, serverCallContext);

            Assert.That(getPartClassDetailDataReply.Result.PartClassDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartClassDetailDataReply.Result.PartClassDetailData.Count, countConstraint);
        }

        [Test]
        public void GetPartClassDetailByClasses_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartClassDetailByClassesGrpcRequest request = new PartClassDetailByClassesGrpcRequest();
            request.Class1 = "TestClass1";
            request.Class2 = 0;
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartClassDetailDataByClasses)
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
            Task<ListPartClassDetailData> getCombinedPartsDataReply = _GrpcService.GetPartClassDetailDataByClasses(request, serverCallContext);

            Assert.That(getCombinedPartsDataReply.Result.PartClassDetailData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsDataReply.Result.PartClassDetailData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint class1Constraint = Is.EqualTo("TestClass1");
            NUnit.Framework.Constraints.EqualConstraint class2Constraint = Is.EqualTo(0);
            Assert.That(getCombinedPartsDataReply.Result.PartClassDetailData.First().Class1, class1Constraint);
            Assert.That(getCombinedPartsDataReply.Result.PartClassDetailData.First().Class2, class2Constraint);
        }

        #endregion

        #region PartGroups
        [Test]
        public void GetAllPartGroups_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartGroupsGrpcRequest request = new PartGroupsGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartGroupsData)
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
            Task<ListPartGroupsData> getPartGroupsDataReply = _GrpcService.GetPartGroupsData(request, serverCallContext);

            Assert.That(getPartGroupsDataReply.Result.PartGroupsData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsDataReply.Result.PartGroupsData.Count, countConstraint);
        }

        [Test]
        public void GetPartGroupsDataByPartGroup_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartGroupsByPartGroupGrpcRequest request = new PartGroupsByPartGroupGrpcRequest();
            request.PartGroup = "TestPartGroup";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartGroupsDataByPartGroup)
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
            Task<ListPartGroupsData> getCombinedPartsDataReply = _GrpcService.GetPartGroupsDataByPartGroup(request, serverCallContext);

            Assert.That(getCombinedPartsDataReply.Result.PartGroupsData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsDataReply.Result.PartGroupsData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupsConstraint = Is.EqualTo("TestPartGroup");
            Assert.That(getCombinedPartsDataReply.Result.PartGroupsData.First().PartGroup, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        public void GetAllPartGroupsConst_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartGroupsConstGrpcRequest request = new PartGroupsConstGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartGroupsConstData)
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
            Task<ListPartGroupsConstData> getPartGroupsConstDataReply = _GrpcService.GetPartGroupsConstData(request, serverCallContext);

            Assert.That(getPartGroupsConstDataReply.Result.PartGroupsConstData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPartGroupsConstDataReply.Result.PartGroupsConstData.Count, countConstraint);
        }

        [Test]
        public void GetPartGroupsConstByGroup3_Success()
        {
            CancellationToken token = CancellationToken.None;
            PartGroupsConstByGroup3GrpcRequest request = new PartGroupsConstByGroup3GrpcRequest();
            request.Group3 = "TestCode";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPartGroupsConstDataByGroup3)
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
            Task<ListPartGroupsConstData> getCombinedPartsDataReply = _GrpcService.GetPartGroupsConstDataByGroup3(request, serverCallContext);

            Assert.That(getCombinedPartsDataReply.Result.PartGroupsConstData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCombinedPartsDataReply.Result.PartGroupsConstData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupsConstraint = Is.EqualTo("TestCode");
            Assert.That(getCombinedPartsDataReply.Result.PartGroupsConstData.First().Code, partGroupsConstraint);
        }
        #endregion

        #region PartGroupsConst
        [Test]
        public void GetAllCustomerData_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetCustomerDataGrpcRequest request = new GetCustomerDataGrpcRequest();
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
            Task<ListCustomerDataGrpc> getAllCustomerDataReply = _GrpcService.GetCustomerData(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.CustomerDataGrpc.Count, countConstraint);
        }
        #endregion

        #region ColourCode
        [Test]
        public void GetAllColourCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetColourCodeGrpcRequest request = new GetColourCodeGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetColourCodeData)
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
            Task<ListColourCodeData> getAllCustomerDataReply = _GrpcService.GetColourCodeData(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.ColourCodeData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.ColourCodeData.Count, countConstraint);
        }

        [Test]
        public void GetColourCodeDataByColorCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetColourCodeByColorCodeGrpcRequest request = new GetColourCodeByColorCodeGrpcRequest();
            request.ColorCode = "TestClMk";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetColourCodeDataByColorCode)
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
            Task<ListColourCodeData> getColourCodeDataReply = _GrpcService.GetColourCodeDataByColorCode(request, serverCallContext);

            Assert.That(getColourCodeDataReply.Result.ColourCodeData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getColourCodeDataReply.Result.ColourCodeData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorCodeConstraint = Is.EqualTo("TestClMk");
            Assert.That(getColourCodeDataReply.Result.ColourCodeData.First().ClMk, colorCodeConstraint);
        }
        #endregion

        #region MaterialGroups
        [Test]
        public void GetAllMaterialGroups_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetMaterialGroupsGrpcRequest request = new GetMaterialGroupsGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMaterialGroupsData)
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
            Task<ListMaterialGroupsData> getAllCustomerDataReply = _GrpcService.GetMaterialGroupsData(request, serverCallContext);

            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getAllCustomerDataReply.Result.MaterialGroupsData.Count, countConstraint);
        }

        [Test]
        public void GetMaterialGroupsByMaterialGroupId_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetMaterialGroupsByMaterialGroupIdGrpcRequest request = new GetMaterialGroupsByMaterialGroupIdGrpcRequest();
            request.MaterialGroup = "TestMaterialGroup";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMaterialGroupsDataByMaterialGroupId)
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
            Task<ListMaterialGroupsData> getMaterialGroupDataReply = _GrpcService.GetMaterialGroupsDataByMaterialGroupId(request, serverCallContext);

            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(getMaterialGroupDataReply.Result.MaterialGroupsData.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region MaterialTypes
        [Test]
        public void GetAllMaterialTypes_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetMaterialTypesGrpcRequest request = new GetMaterialTypesGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMaterialTypesData)
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
            Task<ListMaterialTypesData> getMaterialTypesReply = _GrpcService.GetMaterialTypesData(request, serverCallContext);

            Assert.That(getMaterialTypesReply.Result.MaterialTypesData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getMaterialTypesReply.Result.MaterialTypesData.Count, countConstraint);
        }

        [Test]
        public void GetMaterialTypesByMaterials_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetMaterialTypesByMaterialsGrpcRequest request = new GetMaterialTypesByMaterialsGrpcRequest();
            request.MaterialType = "TestMaterialType";
            request.MaterialGroup = "TestMaterialGroup";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetMaterialTypesDataByMaterials)
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
            Task<ListMaterialTypesData> getMaterialTypeDataReply = _GrpcService.GetMaterialTypesDataByMaterials(request, serverCallContext);

            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialType");
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroup");
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesData.First().MaterialType, materialTypeConstraint);
            Assert.That(getMaterialTypeDataReply.Result.MaterialTypesData.First().MaterialGroup, materialGroupConstraint);
        }
        #endregion

        #region NPACustomer
        [Test]
        public void GetAllNPACustomer_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetNPACustomerGrpcRequest request = new GetNPACustomerGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetNPACustomerData)
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
            Task<ListNPACustomerData> getNPACustomerReply = _GrpcService.GetNPACustomerData(request, serverCallContext);

            Assert.That(getNPACustomerReply.Result.NPACustomerData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPACustomerReply.Result.NPACustomerData.Count, countConstraint);
        }
        #endregion

        #region NPASupplier
        [Test]
        public void GetAllNPASupplier_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetNPASupplierGrpcRequest request = new GetNPASupplierGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetNPASupplierData)
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
            Task<ListNPASupplierData> getNPASupplierReply = _GrpcService.GetNPASupplierData(request, serverCallContext);

            Assert.That(getNPASupplierReply.Result.NPASupplierData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getNPASupplierReply.Result.NPASupplierData.Count, countConstraint);
        }
        #endregion

        #region Supplier
        [Test]
        public void GetAllSupplier_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetSuppliersGrpcRequest request = new GetSuppliersGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetSuppliersData)
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
            Task<ListSuppliersData> getSupplierReply = _GrpcService.GetSuppliersData(request, serverCallContext);

            Assert.That(getSupplierReply.Result.SuppliersData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getSupplierReply.Result.SuppliersData.Count, countConstraint);
        }
        #endregion

        #region PARTMS
        [Test]
        public void GetAllPARTMSData_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataGrpcRequest request = new GetPARTMSDataGrpcRequest();
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSData)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSData(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(6);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
        }

        [Test]
        public void GetPARTMSDataByClass_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByClassGrpcRequest request = new GetPARTMSDataByClassGrpcRequest();
            request.Class1 = "TestClassDetailGroupCode";
            request.Class2 = 0;
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByClass)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByClass(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint class1Constraint = Is.EqualTo("TestClassDetailGroupCode");
            NUnit.Framework.Constraints.EqualConstraint class2Constraint = Is.EqualTo("0");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().ClassDetailGroupCode, class1Constraint);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().ClassDetailId, class2Constraint);
        }

        [Test]
        public void GetPARTMSDataByColorCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByColorCodeGrpcRequest request = new GetPARTMSDataByColorCodeGrpcRequest();
            request.ColorCode = "TestColorCode";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByColorCode)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByColorCode(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo("TestColorCode");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().ColorCode, colorConstraint);
        }

        [Test]
        public void GetPARTMSDataByMaterial_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByMaterialGrpcRequest request = new GetPARTMSDataByMaterialGrpcRequest();
            request.MaterialGroup = "TestMaterialGroupId";
            request.MaterialType = "TestMaterialTypeId";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByMaterial)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByMaterial(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            NUnit.Framework.Constraints.EqualConstraint materialTypeConstraint = Is.EqualTo("TestMaterialTypeId");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().MaterialGroupId, materialGroupConstraint);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().MaterialTypeId, materialTypeConstraint);
        }

        [Test]
        public void GetPARTMSDataByMaterialGroup_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByMaterialGroupGrpcRequest request = new GetPARTMSDataByMaterialGroupGrpcRequest();
            request.MaterialGroup = "TestMaterialGroupId";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByMaterialGroup)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByMaterialGroup(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint materialGroupConstraint = Is.EqualTo("TestMaterialGroupId");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().MaterialGroupId, materialGroupConstraint);
        }
        [Test]
        public void GetPARTMSDataByPartGroup_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByPartGroupGrpcRequest request = new GetPARTMSDataByPartGroupGrpcRequest();
            request.PartGroup = "TestClassDetailGroupCode";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByPartGroup)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByPartGroup(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint partGroupConstraint = Is.EqualTo("TestClassDetailGroupCode");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().ClassDetailGroupCode, partGroupConstraint);
        }
        [Test]
        public void GetPARTMSDataByCatogoryCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByCategoryCodeGrpcRequest request = new GetPARTMSDataByCategoryCodeGrpcRequest();
            request.CatogoryCode = "TestCategoryCode";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByCategoryCode)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByCategoryCode(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestCategoryCode");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().CategoryCode, catogoryCodeConstraint);
        }
        [Test]
        public void GetPARTMSDataByPartGroupsConstCode_Success()
        {
            CancellationToken token = CancellationToken.None;
            GetPARTMSDataByPartGroupsConstCodeGrpcRequest request = new GetPARTMSDataByPartGroupsConstCodeGrpcRequest();
            request.PartGroupsConstCode = "TestGroup3";
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: nameof(_GrpcService.GetPARTMSDataByPartGroupsConstCode)
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
            Task<ListPARTMSData> getPARTMSDataReply = _GrpcService.GetPARTMSDataByPartGroupsConstCode(request, serverCallContext);

            Assert.That(getPARTMSDataReply.Result.PARTMSData, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getPARTMSDataReply.Result.PARTMSData.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint catogoryCodeConstraint = Is.EqualTo("TestGroup3");
            Assert.That(getPARTMSDataReply.Result.PARTMSData.First().Group3, catogoryCodeConstraint);
        }
        #endregion
    }
}

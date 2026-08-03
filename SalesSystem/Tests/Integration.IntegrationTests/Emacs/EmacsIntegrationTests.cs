using Emacs;
using Emacs.Endpoints.GrpcServices;
using Emacs.Services;

namespace Integration.Tests.Emacs
{
    public class EmacsIntegrationTests
    {
         EMACSAccessService _EMACSAccessService;
         EMACSGrpcService _GrpcService;
         ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _LoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger<EMACSAccessService> logger = _LoggerFactory.CreateLogger<EMACSAccessService>();
            ILogger<EMACSGrpcService> logger2 = _LoggerFactory.CreateLogger<EMACSGrpcService>();

            _EMACSAccessService = new EMACSAccessService(serviceProvider, logger, testing: true);
            _GrpcService = new EMACSGrpcService(_EMACSAccessService, logger2);
        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
        }

        // ---------------------------------------------------------------------
        // SayHello
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            // Arrange
             CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName" ;
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.SayHello));

            // Act
            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, context);

            // Assert
            Assert.That(helloReply, Is.Not.Null);
            string replyString = "Hello TestName";
           EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }
        [Test]
[Category("Integration")]
public void Filter_CombinedParts_Success_And_Fail()
{
    // Establish context
    string methodName = nameof(_GrpcService.FilterEmacsDataGrpc);
    ServerCallContext ctx = CreateServerContext(methodName);

    // ---------------------------------------------------------------------
    // SUCCESS CASE
    // ---------------------------------------------------------------------
    
    EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
    successReq.DatabaseList = "CombinedPartsGrpc";
    successReq.FilterExpression = "SumitomoNumber != null";

    // Execute Service Call
    Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
    EmacsFilterResponseGrpc successResp = successTask.Result;

    // Assert Response Structure
    Assert.That(successResp, Is.Not.Null);

      ListCombinedPartsGrpc successListContainer = successResp.ListCombinedPartsGrpc;
    Assert.That(successListContainer, Is.Not.Null);

     RepeatedField<CombinedPartsGrpc> successItems = successListContainer.CombinedPartsGrpc;
    int successCount = successItems.Count;
    Assert.That(successCount, Is.Positive);

    // Assert Data Integrity
    CombinedPartsGrpc firstItem = successItems.First();
    string sumitomoNum = firstItem.SumitomoNumber;
    bool isSumitomoEmpty = string.IsNullOrWhiteSpace(sumitomoNum);
    Assert.That(isSumitomoEmpty, Is.False);

    // ---------------------------------------------------------------------
    // FAILURE CASE
    // ---------------------------------------------------------------------

    EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
    failReq.DatabaseList = "CombinedPartsGrpc";
    failReq.FilterExpression = "SumitomoNumber == \"THIS_VALUE_DOES_NOT_EXIST_999999\"";

    // Execute Service Call
    Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
    EmacsFilterResponseGrpc failResp = failTask.Result;

    // Assert Response Structure
    Assert.That(failResp, Is.Not.Null);

            ListCombinedPartsGrpc failListContainer = failResp.ListCombinedPartsGrpc;
    Assert.That(failListContainer, Is.Not.Null);

      RepeatedField<CombinedPartsGrpc> failItems = failListContainer.CombinedPartsGrpc;
    int failCount = failItems.Count;
    Assert.That(failCount, Is.Zero);
}

        // ---------------------------------------------------------------------
        // PartCategoryDetail
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_PartCategoryDetail_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            // ---------------------------------------------------------------------
            // SUCCESS CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
            successReq.DatabaseList = "PartCategoryDetailGrpc";
            successReq.FilterExpression = "CategoryCode != null";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
            EmacsFilterResponseGrpc successResp = successTask.Result;

            // Assert Response Structure
            Assert.That(successResp, Is.Not.Null);

            ListPartCategoryDetailGrpc successListContainer = successResp.ListPartCategoryDetailGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<PartCategoryDetailGrpc> successItems = successListContainer.PartCategoryDetailGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // Assert Data Integrity (optional but consistent with your CombinedParts test)
            PartCategoryDetailGrpc firstItem = successItems.First();
            string categoryCode = firstItem.CategoryCode;
            bool isCategoryCodeEmpty = string.IsNullOrWhiteSpace(categoryCode);
            Assert.That(isCategoryCodeEmpty, Is.False);

            // ---------------------------------------------------------------------
            // FAILURE CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
            failReq.DatabaseList = "PartCategoryDetailGrpc";
            failReq.FilterExpression = "CategoryCode == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
            EmacsFilterResponseGrpc failResp = failTask.Result;

            // Assert Response Structure
            Assert.That(failResp, Is.Not.Null);

            ListPartCategoryDetailGrpc failListContainer = failResp.ListPartCategoryDetailGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<PartCategoryDetailGrpc> failItems = failListContainer.PartCategoryDetailGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // PartGroups
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_PartGroups_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            // ---------------------------------------------------------------------
            // SUCCESS CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
            successReq.DatabaseList = "PartGroupsGrpc";
            successReq.FilterExpression = "PartGroup != null";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
            EmacsFilterResponseGrpc successResp = successTask.Result;

            // Assert Response Structure
            Assert.That(successResp, Is.Not.Null);

            ListPartGroupsGrpc successListContainer = successResp.ListPartGroupsGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<PartGroupsGrpc> successItems = successListContainer.PartGroupsGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // Assert Data Integrity
            PartGroupsGrpc firstItem = successItems.First();
            string partGroupValue = firstItem.PartGroup;
            bool isPartGroupEmpty = string.IsNullOrWhiteSpace(partGroupValue);
            Assert.That(isPartGroupEmpty, Is.False);

            // ---------------------------------------------------------------------
            // FAILURE CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
            failReq.DatabaseList = "PartGroupsGrpc";
            failReq.FilterExpression = "PartGroup == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
            EmacsFilterResponseGrpc failResp = failTask.Result;

            // Assert Response Structure
            Assert.That(failResp, Is.Not.Null);

            ListPartGroupsGrpc failListContainer = failResp.ListPartGroupsGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<PartGroupsGrpc> failItems = failListContainer.PartGroupsGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // MaterialGroups
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_MaterialGroups_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            // ---------------------------------------------------------------------
            // SUCCESS CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
            successReq.DatabaseList = "MaterialGroupsGrpc";
            successReq.FilterExpression = "MaterialGroup != null";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
            EmacsFilterResponseGrpc successResp = successTask.Result;

            // Assert Response Structure
            Assert.That(successResp, Is.Not.Null);

            ListMaterialGroupsGrpc successListContainer = successResp.ListMaterialGroupsGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<MaterialGroupsGrpc> successItems = successListContainer.MaterialGroupsGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // Assert Data Integrity
            MaterialGroupsGrpc firstItem = successItems.First();
            string materialGroupValue = firstItem.MaterialGroup;
            bool isMaterialGroupEmpty = string.IsNullOrWhiteSpace(materialGroupValue);
            Assert.That(isMaterialGroupEmpty, Is.False);

            // ---------------------------------------------------------------------
            // FAILURE CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
            failReq.DatabaseList = "MaterialGroupsGrpc";
            failReq.FilterExpression = "MaterialGroup == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
            EmacsFilterResponseGrpc failResp = failTask.Result;

            // Assert Response Structure
            Assert.That(failResp, Is.Not.Null);

            ListMaterialGroupsGrpc failListContainer = failResp.ListMaterialGroupsGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<MaterialGroupsGrpc> failItems = failListContainer.MaterialGroupsGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }
        // ---------------------------------------------------------------------
        // PARTMS
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_PARTMS_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            // ---------------------------------------------------------------------
            // SUCCESS CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
            successReq.DatabaseList = "PARTMSGrpc";
            successReq.FilterExpression = "SumitomoNumber != null";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
            EmacsFilterResponseGrpc successResp = successTask.Result;

            // Assert Response Structure
            Assert.That(successResp, Is.Not.Null);

            ListPARTMSGrpc successListContainer = successResp.ListPARTMSGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<PARTMSGrpc> successItems = successListContainer.PARTMSGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // Assert Data Integrity
            PARTMSGrpc firstItem = successItems.First();
            string sumitomoValue = firstItem.SumitomoNumber;
            bool isSumitomoEmpty = string.IsNullOrWhiteSpace(sumitomoValue);
            Assert.That(isSumitomoEmpty, Is.False);

            // ---------------------------------------------------------------------
            // FAILURE CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
            failReq.DatabaseList = "PARTMSGrpc";
            failReq.FilterExpression = "SumitomoNumber == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
            EmacsFilterResponseGrpc failResp = failTask.Result;

            // Assert Response Structure
            Assert.That(failResp, Is.Not.Null);

            ListPARTMSGrpc failListContainer = failResp.ListPARTMSGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<PARTMSGrpc> failItems = failListContainer.PARTMSGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // Suppliers
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void Filter_Suppliers_Success_And_Fail()
        {
            ServerCallContext ctx = CreateServerContext(nameof(_GrpcService.FilterEmacsDataGrpc));

            // ---------------------------------------------------------------------
            // SUCCESS CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc successReq = new EmacsFilterRequestGrpc();
            successReq.DatabaseList = "SuppliersGrpc";
            successReq.FilterExpression = "SupplierName != null";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> successTask = _GrpcService.FilterEmacsDataGrpc(successReq, ctx);
            EmacsFilterResponseGrpc successResp = successTask.Result;

            // Assert Response Structure
            Assert.That(successResp, Is.Not.Null);

            ListSuppliersGrpc successListContainer = successResp.ListSuppliersGrpc;
            Assert.That(successListContainer, Is.Not.Null);

            RepeatedField<SuppliersGrpc> successItems = successListContainer.SuppliersGrpc;
            int successCount = successItems.Count;
            Assert.That(successCount, Is.Positive);

            // Assert Data Integrity
            SuppliersGrpc firstItem = successItems.First();
            string supplierName = firstItem.SupplierName;
            bool isSupplierNameEmpty = string.IsNullOrWhiteSpace(supplierName);
            Assert.That(isSupplierNameEmpty, Is.False);

            // ---------------------------------------------------------------------
            // FAILURE CASE
            // ---------------------------------------------------------------------

            EmacsFilterRequestGrpc failReq = new EmacsFilterRequestGrpc();
            failReq.DatabaseList = "SuppliersGrpc";
            failReq.FilterExpression = "SupplierName == \"THIS_VALUE_DOES_NOT_EXIST_999\"";

            // Execute Service Call
            Task<EmacsFilterResponseGrpc> failTask = _GrpcService.FilterEmacsDataGrpc(failReq, ctx);
            EmacsFilterResponseGrpc failResp = failTask.Result;

            // Assert Response Structure
            Assert.That(failResp, Is.Not.Null);

            ListSuppliersGrpc failListContainer = failResp.ListSuppliersGrpc;
            Assert.That(failListContainer, Is.Not.Null);

            RepeatedField<SuppliersGrpc> failItems = failListContainer.SuppliersGrpc;
            int failCount = failItems.Count;
            Assert.That(failCount, Is.Zero);
        }

        // ---------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------

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

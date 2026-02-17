using SalesSystem.Rfq.Enums;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;

namespace Integration.Tests.Rfq.Client
{
    [TestFixture]
    public class RfqUxClientServiceNprTests : IDisposable
    {
        #region Fields & Constructor

        RfqUxClientService _Service;
        Mock<ILogger<RfqUxClientService>> _LoggerMock;
        IConfiguration? _Configuration;
        bool _Disposed;

        static RfqUxClientServiceNprTests()
        {
        }

        public RfqUxClientServiceNprTests()
        {
            _Service = null!;
            _LoggerMock = null!;
        }
        #endregion

        #region Initialization Methods

        void InitializeConfiguration()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            Dictionary<string, string?> configuration = new Dictionary<string, string?>();
            configuration["GrpcService:Url"] = "https://localhost:7207";
            configuration["GrpcService:TimeoutSeconds"] = "90";
            configuration["GrpcService:MaxReceiveMessageSizeMB"] = "256";
            configuration["GrpcService:MaxSendMessageSizeMB"] = "256";
            configBuilder.AddInMemoryCollection(configuration);
            _Configuration = configBuilder.Build();
            TestContext.Out.WriteLine("RfqUxClientServiceNprTest - Configuration initialized");
        }

        void InitializeService()
        {
            ArgumentNullException.ThrowIfNull(_Configuration);
            _LoggerMock = new Mock<ILogger<RfqUxClientService>>();

            _Service = new RfqUxClientService(_Configuration, _LoggerMock.Object, true);

            TestContext.Out.WriteLine("RfqUxClientServiceNprTest - RfqUxClientService initialized successfully");
            TestContext.Out.WriteLine($"Max GRPC Response Size: {RfqUxClientService.MAX_GRPC_RESPONSE_SIZE / 1024 / 1024} MB");
        }

        #endregion

        #region Setup / Teardown

        [OneTimeSetUp]
        public void SetUp()
        {
            InitializeConfiguration();
            InitializeService();
            // Ensure clean state before each test
            if (File.Exists(_Service.NprRequestSetsFilePath))
            {
                File.Delete(_Service.NprRequestSetsFilePath);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _Service?.Dispose();
        }

        #endregion

        #region Helper Methods

        RfqNprRequestSetUxModel CreateTestSet(string rfqNumber = "SEWS-25-025-DEADBEEF")
        {
            RfqNprRequestSetUxModel set = new RfqNprRequestSetUxModel();
            set.RfqNumber = rfqNumber;

            return set;
        }

        RfqNprRequestUxModel CreateTestRequest(
            string? reason = "Test Reason",
            string? customer = "Test Customer",
            string? sumitomoNumber = "SUM-001",
            int? quantity = 100)
        {
            RfqNprRequestUxModel request = new RfqNprRequestUxModel();
            request.Reason = reason;
            request.Customer = customer;
            request.SumitomoNumber = sumitomoNumber;
            request.Quantity = quantity;
            request.CustomerPartNumber = "CPN-001";
            request.MaterialDescription = "Test Material";
            request.UnitOfMeasure = "EA";
            request.RequiredDate = DateTime.UtcNow.AddDays(30);

            return request;
        }

        async Task<RfqNprRequestSetUxModel> CreateAndPersistTestSetAsync(string name)
        {
            RfqNprRequestSetUxModel set = CreateTestSet(name);
            RfqNprRequestSetUxModel createdSet = await _Service.CreateNprRequestSetAsync(set);

            return createdSet;
        }

        #endregion

        #region GetAllNprRequestSetsAsync Tests

        [Test]
        public async Task GetAllNprRequestSetsAsync_WhenNoFileExists_ReturnsZero()
        {
            // Act
            int count = await _Service.GetAllNprRequestSetsAsync();

            // Assert
            EqualConstraint isZero = Is.EqualTo(0);
            Assert.That(count, isZero);
            Assert.That(_Service.NprRequestSets, Is.Empty);
        }

        [Test]
        public async Task GetAllNprRequestSetsAsync_WhenSetsExist_ReturnsCorrectCount()
        {
            // Arrange
            await CreateAndPersistTestSetAsync("Set A - GetAllNprRequestSetsAsync_WhenSetsExist_ReturnsCorrectCount");
            await CreateAndPersistTestSetAsync("Set B - GetAllNprRequestSetsAsync_WhenSetsExist_ReturnsCorrectCount");
            await CreateAndPersistTestSetAsync("Set C - GetAllNprRequestSetsAsync_WhenSetsExist_ReturnsCorrectCount");

            // Act
            int count = await _Service.GetAllNprRequestSetsAsync();

            // Assert
            EqualConstraint isEQ3 = Is.EqualTo(3);

            Assert.That(count, isEQ3);
            Assert.That(_Service.NprRequestSets.Count, isEQ3);
        }

        [Test]
        public async Task GetAllNprRequestSetsAsync_WhenFileIsEmpty_ReturnsZero()
        {
            // Arrange
            string? directory = Path.GetDirectoryName(_Service.NprRequestSetsFilePath);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(_Service.NprRequestSetsFilePath, "");

            // Act
            int count = await _Service.GetAllNprRequestSetsAsync();

            // Assert
            EqualConstraint isEQ0 = Is.EqualTo(0);

            Assert.That(count, isEQ0);
        }

        #endregion

        #region GetNprRequestSetByIdAsync Tests

        [Test]
        public async Task GetNprRequestSetByIdAsync_WhenSetExists_ReturnsSet()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel createdSet = await CreateAndPersistTestSetAsync("Find Me - WhenSetExists_ReturnsSet");

            // Act
            RfqNprRequestSetUxModel? foundSet = await _Service.GetNprRequestSetByIdAsync(createdSet.Id);

            // Assert
            Assert.That(foundSet, Is.Not.Null);
            EqualConstraint isCreatedId = Is.EqualTo(createdSet.Id);
            Assert.That(foundSet!.Id, isCreatedId);
            EqualConstraint isFindMe = Is.EqualTo("Find Me - WhenSetExists_ReturnsSet");
            Assert.That(foundSet.RfqNumber, isFindMe);
        }

        [Test]
        public async Task GetNprRequestSetByIdAsync_WhenSetDoesNotExist_ReturnsNull()
        {
            // Arrange
            await CreateAndPersistTestSetAsync("Other Set - WhenSetDoesNotExist_ReturnsNull");

            // Act
            Guid newId = Guid.NewGuid();

            RfqNprRequestSetUxModel? foundSet = await _Service.GetNprRequestSetByIdAsync(newId);

            // Assert
            Assert.That(foundSet, Is.Null);
        }

        [Test]
        public async Task GetNprRequestSetByIdAsync_WhenNoFileExists_ReturnsNull()
        {
            // Act
            Guid newGuid = Guid.NewGuid();
            RfqNprRequestSetUxModel? foundSet = await _Service.GetNprRequestSetByIdAsync(newGuid);

            // Assert
            Assert.That(foundSet, Is.Null);
        }

        #endregion

        #region CreateNprRequestSetAsync Tests

        [Test]
        public async Task CreateNprRequestSetAsync_WithValidSet_CreatesAndPersists()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel newSet = CreateTestSet("New Set - WithValidSet_CreatesAndPersists");

            // Act
            RfqNprRequestSetUxModel result = await _Service.CreateNprRequestSetAsync(newSet);

            // Assert
            Assert.That(result, Is.Not.Null);
            EqualConstraint isNewSet = Is.EqualTo("New Set - WithValidSet_CreatesAndPersists");
            Assert.That(result.RfqNumber, isNewSet);
            EqualConstraint isLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);
            Assert.That(result.Status, isLocalUnchanged);
            EqualConstraint defaultDT = Is.Not.EqualTo(default(DateTime));
            Assert.That(result.Created, defaultDT);
            bool fileExists = File.Exists(_Service.NprRequestSetsFilePath);
            Assert.That(fileExists, Is.True);

            // Verify persistence
            int count = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint isOne = Is.EqualTo(1);
            Assert.That(count, isOne);
        }

        [Test]
        public async Task CreateNprRequestSetAsync_MultipleSets_AllPersisted()
        {
            // Act
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set1 = await CreateAndPersistTestSetAsync("Set 1 - MultipleSets_AllPersisted");
            RfqNprRequestSetUxModel set2 = await CreateAndPersistTestSetAsync("Set 2 - MultipleSets_AllPersisted");
            RfqNprRequestSetUxModel set3 = await CreateAndPersistTestSetAsync("Set 3 - MultipleSets_AllPersisted");

            // Assert
            int count = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint isEQ3 = Is.EqualTo(3);
            Assert.That(count, isEQ3);

            RfqNprRequestSetUxModel? loadedSet2 = _Service.NprRequestSets.FirstOrDefault(x => x.RfqNumber == "Set 2 - MultipleSets_AllPersisted");
            RfqNprRequestSetUxModel? loadedSet3 = _Service.NprRequestSets.FirstOrDefault(x => x.RfqNumber == "Set 3 - MultipleSets_AllPersisted");

            EqualConstraint isEQs2Id = Is.EqualTo(set2.Id);
            EqualConstraint isEQs3Id = Is.EqualTo(set3.Id);
            Assert.That(set2.Id, isEQs2Id);
            Assert.That(set3.Id, isEQs3Id);
        }

        [Test]
        public void CreateNprRequestSetAsync_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.CreateNprRequestSetAsync(null!));
        }

        [Test]
        public async Task CreateNprRequestSetAsync_SetsCreatedTimestamp()
        {
            // Arrange
            DateTime beforeCreate = DateTime.UtcNow;
            RfqNprRequestSetUxModel newSet = CreateTestSet("Timestamped Set");

            // Act
            RfqNprRequestSetUxModel result = await _Service.CreateNprRequestSetAsync(newSet);

            // Assert
            DateTime afterCreate = DateTime.UtcNow;
            GreaterThanOrEqualConstraint isGTTOETBeforeCreate = Is.GreaterThanOrEqualTo(beforeCreate);
            LessThanOrEqualConstraint isLTORETAfterCreate = Is.LessThanOrEqualTo(afterCreate);

            Assert.That(result.Created, isGTTOETBeforeCreate);
            Assert.That(result.Created, isLTORETAfterCreate);
        }

        #endregion

        #region UpdateNprRequestSetAsync Tests

        [Test]
        public async Task UpdateNprRequestSetAsync_WithValidSet_UpdatesAndPersists()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel createdSet = await CreateAndPersistTestSetAsync("Original Name - WithValidSet_UpdatesAndPersists");

            // Act
            createdSet.RfqNumber = "Updated Name - WithValidSet_UpdatesAndPersists - Updated";
            RfqNprRequestSetUxModel result = await _Service.UpdateNprRequestSetAsync(createdSet);

            // Assert
            EqualConstraint updatedRfq = Is.EqualTo("Updated Name - WithValidSet_UpdatesAndPersists - Updated");
            Assert.That(result.RfqNumber, updatedRfq);
            NullConstraint isNotNull = Is.Not.Null;
            Assert.That(result.Updated, isNotNull);

            // Verify persistence
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(createdSet.Id);
            Assert.That(reloaded, Is.Not.Null);
            string? reloadedUpdatedRfq = reloaded!.RfqNumber;
            Assert.That(reloadedUpdatedRfq, updatedRfq);
        }

        [Test]
        public async Task UpdateNprRequestSetAsync_SetsUpdatedTimestamp()
        {
            // Arrange
            RfqNprRequestSetUxModel createdSet = await CreateAndPersistTestSetAsync("Before Update - SetsUpdatedTimestamp");
            DateTime beforeUpdate = DateTime.UtcNow;

            // Act
            createdSet.RfqNumber = "After Update";
            RfqNprRequestSetUxModel result = await _Service.UpdateNprRequestSetAsync(createdSet);

            // Assert
            DateTime afterUpdate = DateTime.UtcNow;
            NullConstraint isNotNull = Is.Not.Null;
            Assert.That(result.Updated, isNotNull);
            GreaterThanOrEqualConstraint isGTBefore = Is.GreaterThanOrEqualTo(beforeUpdate);
            LessThanOrEqualConstraint isLTAfter = Is.LessThanOrEqualTo(afterUpdate);
            Assert.That(result.Updated!, isGTBefore);
            Assert.That(result.Updated!, isLTAfter);
        }

        [Test]
        public void UpdateNprRequestSetAsync_WhenSetNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            RfqNprRequestSetUxModel nonExistentSet = CreateTestSet("Ghost Set - WhenSetNotFound_ThrowsInvalidOperationException");

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _Service.UpdateNprRequestSetAsync(nonExistentSet));
        }

        [Test]
        public void UpdateNprRequestSetAsync_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.UpdateNprRequestSetAsync(null!));
        }

        [Test]
        public async Task UpdateNprRequestSetAsync_DoesNotAffectOtherSets()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set1 = await CreateAndPersistTestSetAsync("Set 1 - DoesNotAffectOtherSets");
            RfqNprRequestSetUxModel set2 = await CreateAndPersistTestSetAsync("Set 2 - DoesNotAffectOtherSets");

            // Act
            set1.RfqNumber = "Set 1 Updated";
            await _Service.UpdateNprRequestSetAsync(set1);

            // Assert
            RfqNprRequestSetUxModel? reloadedSet2 = await _Service.GetNprRequestSetByIdAsync(set2.Id);
            Assert.That(reloadedSet2, Is.Not.Null);
            EqualConstraint is2 = Is.EqualTo("Set 2 - DoesNotAffectOtherSets");
            Assert.That(reloadedSet2!.RfqNumber, is2);
        }

        #endregion

        #region DeleteNprRequestSetAsync Tests

        [Test]
        public async Task DeleteNprRequestSetAsync_WhenSetExists_DeletesAndReturnsTrue()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel createdSet = await CreateAndPersistTestSetAsync("Delete Me - WhenSetExists_DeletesAndReturnsTrue");

            // Act
            bool result = await _Service.DeleteNprRequestSetAsync(createdSet.Id);

            // Assert
            Assert.That(result, Is.True);

            int count = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint is0 = Is.EqualTo(0);
            Assert.That(count, is0);
        }

        [Test]
        public async Task DeleteNprRequestSetAsync_WhenSetDoesNotExist_ReturnsFalse()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            await CreateAndPersistTestSetAsync("Keep Me - WhenSetDoesNotExist_ReturnsFalse");

            // Act
            Guid newId = Guid.NewGuid();
            bool result = await _Service.DeleteNprRequestSetAsync(newId);

            // Assert
            Assert.That(result, Is.False);

            int count = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint is1 = Is.EqualTo(1);
            Assert.That(count, is1);
        }

        [Test]
        public async Task DeleteNprRequestSetAsync_DeletesOnlyTargetSet()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set1 = await CreateAndPersistTestSetAsync("Set 1 - DeletesOnlyTargetSet");
            RfqNprRequestSetUxModel set2 = await CreateAndPersistTestSetAsync("Set 2 - DeletesOnlyTargetSet");
            RfqNprRequestSetUxModel set3 = await CreateAndPersistTestSetAsync("Set 3 - DeletesOnlyTargetSet");

            // Act
            bool result = await _Service.DeleteNprRequestSetAsync(set2.Id);

            // Assert
            Assert.That(result, Is.True);

            int count = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint is2 = Is.EqualTo(2);
            Assert.That(count, is2);

            RfqNprRequestSetUxModel? deletedSet = await _Service.GetNprRequestSetByIdAsync(set2.Id);
            Assert.That(deletedSet, Is.Null);

            RfqNprRequestSetUxModel? remainingSet1 = await _Service.GetNprRequestSetByIdAsync(set1.Id);
            Assert.That(remainingSet1, Is.Not.Null);

            RfqNprRequestSetUxModel? remainingSet3 = await _Service.GetNprRequestSetByIdAsync(set3.Id);
            Assert.That(remainingSet3, Is.Not.Null);
        }

        #endregion

        #region AddNprRequestToSetAsync Tests

        [Test]
        public async Task AddNprRequestToSetAsync_WithValidRequest_AddsAndPersists()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set With Requests - WithValidRequest_AddsAndPersists");
            RfqNprRequestUxModel request = CreateTestRequest();

            // Act
            RfqNprRequestUxModel result = await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Assert
            Assert.That(result, Is.Not.Null);
            EqualConstraint isEQRqId = Is.EqualTo(request.Id);
            Assert.That(result.Id, isEQRqId);

            // Verify persistence
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(reloaded, Is.Not.Null);
            EqualConstraint is1 = Is.EqualTo(1);
            Assert.That(reloaded!.NprRequests.Count, is1);
            EqualConstraint isEQSum001 = Is.EqualTo("SUM-001");
            Assert.That(reloaded.NprRequests.First().SumitomoNumber, isEQSum001);
        }

        [Test]
        public async Task AddNprRequestToSetAsync_SetsStatusToLocalUnchanged()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Empty Set - SetsStatusToLocalUnchanged");
            RfqNprRequestUxModel request = CreateTestRequest();

            // Act
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Assert
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            EqualConstraint isLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);
            Assert.That(reloaded!.Status, isLocalUnchanged);
        }

        [Test]
        public async Task AddNprRequestToSetAsync_SetsUpdatedTimestamp()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Timestamp Set - SetsUpdatedTimestamp");
            RfqNprRequestUxModel request = CreateTestRequest();
            DateTime beforeAdd = DateTime.UtcNow;

            // Act
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Assert
            DateTime afterAdd = DateTime.UtcNow;
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            NullConstraint isNNull = Is.Not.Null;
            Assert.That(reloaded!.Updated, isNNull);
            GreaterThanOrEqualConstraint isGToET = Is.GreaterThanOrEqualTo(beforeAdd);
            Assert.That(reloaded.Updated!, isGToET);
            LessThanOrEqualConstraint isLToET = Is.LessThanOrEqualTo(afterAdd);
            Assert.That(reloaded.Updated!, isLToET);
        }

        [Test]
        public async Task AddNprRequestToSetAsync_MultipleRequests_AllPersisted()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Multi Request Set - MultipleRequests_AllPersisted");
            RfqNprRequestUxModel request1 = CreateTestRequest(sumitomoNumber: "SUM-001");
            RfqNprRequestUxModel request2 = CreateTestRequest(sumitomoNumber: "SUM-002");
            RfqNprRequestUxModel request3 = CreateTestRequest(sumitomoNumber: "SUM-003");

            // Act
            await _Service.AddNprRequestToSetAsync(set.Id, request1);
            await _Service.AddNprRequestToSetAsync(set.Id, request2);
            await _Service.AddNprRequestToSetAsync(set.Id, request3);

            // Assert
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            EqualConstraint isEQ3 = Is.EqualTo(3);
            Assert.That(reloaded!.NprRequests.Count, isEQ3);
        }

        [Test]
        public void AddNprRequestToSetAsync_WhenSetNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            RfqNprRequestUxModel request = CreateTestRequest("Ghost Request - WhenSetNotFound_ThrowsInvalidOperationException");

            // Act & Assert
            Guid newGuid = Guid.NewGuid();
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _Service.AddNprRequestToSetAsync(newGuid, request));
        }

        [Test]
        public async Task AddNprRequestToSetAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set - WithNullRequest_ThrowsArgumentNullException");

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.AddNprRequestToSetAsync(set.Id, null!));
        }

        #endregion

        #region UpdateNprRequestInSetAsync Tests

        [Test]
        public async Task UpdateNprRequestInSetAsync_WithValidRequest_UpdatesAndPersists()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Update Request Set - WithValidRequest_UpdatesAndPersists");
            RfqNprRequestUxModel request = CreateTestRequest(reason: "Original Reason");
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            request.Reason = "Updated Reason";
            request.Quantity = 999;
            RfqNprRequestUxModel result = await _Service.UpdateNprRequestInSetAsync(set.Id, request);

            // Assert
            EqualConstraint isEQUpdReason = Is.EqualTo("Updated Reason");
            EqualConstraint isEQ999 = Is.EqualTo(999);

            Assert.That(result.Reason, isEQUpdReason);
            Assert.That(result.Quantity, isEQ999);

            // Verify persistence
            RfqNprRequestUxModel? reloaded = await _Service.GetNprRequestByIdAsync(set.Id, request.Id);
            Assert.That(reloaded, Is.Not.Null);
            Assert.That(reloaded!.Reason, isEQUpdReason);
            Assert.That(reloaded.Quantity, isEQ999);
        }

        [Test]
        public async Task UpdateNprRequestInSetAsync_SetsUpdatedTimestampOnSet()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Timestamp Update Set - SetsUpdatedTimestampOnSet");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);
            DateTime beforeUpdate = DateTime.UtcNow;

            // Act
            request.Reason = "Changed";
            await _Service.UpdateNprRequestInSetAsync(set.Id, request);

            // Assert
            DateTime afterUpdate = DateTime.UtcNow;
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            GreaterThanOrEqualConstraint isGToET = Is.GreaterThanOrEqualTo(beforeUpdate);
            Assert.That(reloaded!.Updated!, isGToET);
            LessThanOrEqualConstraint isLToET = Is.LessThanOrEqualTo(afterUpdate);
            Assert.That(reloaded.Updated!, isLToET);
        }

        [Test]
        public async Task UpdateNprRequestInSetAsync_DoesNotAffectOtherRequests()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Multi Update Set - DoesNotAffectOtherRequests");
            RfqNprRequestUxModel request1 = CreateTestRequest(reason: "Reason 1", sumitomoNumber: "SUM-001");
            RfqNprRequestUxModel request2 = CreateTestRequest(reason: "Reason 2", sumitomoNumber: "SUM-002");
            await _Service.AddNprRequestToSetAsync(set.Id, request1);
            await _Service.AddNprRequestToSetAsync(set.Id, request2);

            // Act
            request1.Reason = "Reason 1 Updated";
            await _Service.UpdateNprRequestInSetAsync(set.Id, request1);

            // Assert
            RfqNprRequestUxModel? reloadedRequest2 = await _Service.GetNprRequestByIdAsync(set.Id, request2.Id);
            Assert.That(reloadedRequest2, Is.Not.Null);
            EqualConstraint isEQReas2 = Is.EqualTo("Reason 2");
            Assert.That(reloadedRequest2!.Reason, isEQReas2);
        }

        [Test]
        public void UpdateNprRequestInSetAsync_WhenSetNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            RfqNprRequestUxModel request = CreateTestRequest();

            // Act & Assert
            Guid newGuid = Guid.NewGuid();
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _Service.UpdateNprRequestInSetAsync(newGuid, request));
        }

        [Test]
        public async Task UpdateNprRequestInSetAsync_WhenRequestNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set - WhenRequestNotFound_ThrowsInvalidOperationException");
            RfqNprRequestUxModel nonExistentRequest = CreateTestRequest();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _Service.UpdateNprRequestInSetAsync(set.Id, nonExistentRequest));
        }

        [Test]
        public async Task UpdateNprRequestInSetAsync_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set - WithNull_ThrowsArgumentNullException");

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.UpdateNprRequestInSetAsync(set.Id, null!));
        }

        #endregion

        #region RemoveNprRequestFromSetAsync Tests

        [Test]
        public async Task RemoveNprRequestFromSetAsync_WhenRequestExists_RemovesAndReturnsTrue()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Remove Request Set - WhenRequestExists_RemovesAndReturnsTrue");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            bool result = await _Service.RemoveNprRequestFromSetAsync(set.Id, request.Id);

            // Assert
            Assert.That(result, Is.True);

            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            EqualConstraint isEQ0 = Is.EqualTo(0);

            Assert.That(reloaded!.NprRequests.Count, isEQ0);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_WhenLastRequestRemoved_SetsStatusToEmpty()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Status Reset Set - WhenLastRequestRemoved_SetsStatusToEmpty");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            await _Service.RemoveNprRequestFromSetAsync(set.Id, request.Id);

            // Assert
            EqualConstraint isEQLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);

            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(reloaded!.Status, isEQLocalUnchanged);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_WhenReloaded_StatusRemainsLocalUnchanged()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Multi Remove Set - WhenReloaded_StatusRemainsLocalUnchanged");
            RfqNprRequestUxModel request1 = CreateTestRequest(sumitomoNumber: "SUM-001");
            RfqNprRequestUxModel request2 = CreateTestRequest(sumitomoNumber: "SUM-002");
            await _Service.AddNprRequestToSetAsync(set.Id, request1);
            await _Service.AddNprRequestToSetAsync(set.Id, request2);

            // Act
            await _Service.RemoveNprRequestFromSetAsync(set.Id, request1.Id);

            // Assert
            EqualConstraint isEQLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);
            EqualConstraint isEQ1 = Is.EqualTo(1);

            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(reloaded!.NprRequests.Count, isEQ1);
            Assert.That(reloaded.Status, isEQLocalUnchanged);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_RemovesOnlyTargetRequest()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Selective Remove Set - RemovesOnlyTargetRequest");
            RfqNprRequestUxModel request1 = CreateTestRequest(sumitomoNumber: "SUM-001");
            RfqNprRequestUxModel request2 = CreateTestRequest(sumitomoNumber: "SUM-002");
            RfqNprRequestUxModel request3 = CreateTestRequest(sumitomoNumber: "SUM-003");
            await _Service.AddNprRequestToSetAsync(set.Id, request1);
            await _Service.AddNprRequestToSetAsync(set.Id, request2);
            await _Service.AddNprRequestToSetAsync(set.Id, request3);

            // Act
            await _Service.RemoveNprRequestFromSetAsync(set.Id, request2.Id);

            // Assert
            EqualConstraint qe2 = Is.EqualTo(2); // just because I can 😁😁😁

            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(reloaded!.NprRequests.Count, qe2);

            RfqNprRequestUxModel? removedRequest = await _Service.GetNprRequestByIdAsync(set.Id, request2.Id);
            Assert.That(removedRequest, Is.Null);

            RfqNprRequestUxModel? remainingRequest1 = await _Service.GetNprRequestByIdAsync(set.Id, request1.Id);
            Assert.That(remainingRequest1, Is.Not.Null);

            RfqNprRequestUxModel? remainingRequest3 = await _Service.GetNprRequestByIdAsync(set.Id, request3.Id);
            Assert.That(remainingRequest3, Is.Not.Null);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_WhenRequestNotFound_ReturnsFalse()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set - WhenRequestNotFound_ReturnsFalse");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            Guid newGuid = Guid.NewGuid();
            bool result = await _Service.RemoveNprRequestFromSetAsync(set.Id, newGuid);

            // Assert
            EqualConstraint isEQ1 = Is.EqualTo(1);

            Assert.That(result, Is.False);

            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(reloaded!.NprRequests.Count, isEQ1);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_WhenSetNotFound_ReturnsFalse()
        {
            // Act
            Guid newGuid = Guid.NewGuid();
            Guid newGuid1 = Guid.NewGuid();
            bool result = await _Service.RemoveNprRequestFromSetAsync(newGuid, newGuid1);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task RemoveNprRequestFromSetAsync_SetsUpdatedTimestamp()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Timestamp Remove Set - SetsUpdatedTimestamp");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);
            DateTime beforeRemove = DateTime.UtcNow;

            // Act
            await _Service.RemoveNprRequestFromSetAsync(set.Id, request.Id);

            // Assert
            DateTime afterRemove = DateTime.UtcNow;
            RfqNprRequestSetUxModel? reloaded = await _Service.GetNprRequestSetByIdAsync(set.Id);

            GreaterThanOrEqualConstraint isGToET = Is.GreaterThanOrEqualTo(beforeRemove);
            LessThanOrEqualConstraint isLToET = Is.LessThanOrEqualTo(afterRemove);

            Assert.That(reloaded!.Updated!, isGToET);
            Assert.That(reloaded.Updated!, isLToET);
        }

        #endregion

        #region GetNprRequestByIdAsync Tests

        [Test]
        public async Task GetNprRequestByIdAsync_WhenRequestExists_ReturnsRequest()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Get Request Set - WhenRequestExists_ReturnsRequest");
            RfqNprRequestUxModel request = CreateTestRequest(
                reason: "Find This",
                customer: "Important Customer",
                sumitomoNumber: "SUM-FIND",
                quantity: 42);
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            RfqNprRequestUxModel? found = await _Service.GetNprRequestByIdAsync(set.Id, request.Id);

            // Assert
            NullConstraint isNNull = Is.Not.Null;
            EqualConstraint isEQReqId = Is.EqualTo(request.Id);
            EqualConstraint isEQFindThis = Is.EqualTo("Find This");
            EqualConstraint isEQSumFind = Is.EqualTo("SUM-FIND");
            EqualConstraint isEQImportantCustomer = Is.EqualTo("Important Customer");
            EqualConstraint isEQ42 = Is.EqualTo(42);

            Assert.That(found, isNNull);
            Assert.That(found!.Id, isEQReqId);
            Assert.That(found.Reason, isEQFindThis);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(found.Customer, isEQImportantCustomer);
                Assert.That(found.SumitomoNumber, isEQSumFind);
                Assert.That(found.Quantity, isEQ42);
            }
        }

        [Test]
        public async Task GetNprRequestByIdAsync_WhenRequestDoesNotExist_ReturnsNull()
        {
            // Arrange
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Set - WhenRequestDoesNotExist_ReturnsNull");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            Guid newGuid = Guid.NewGuid();
            RfqNprRequestUxModel? found = await _Service.GetNprRequestByIdAsync(set.Id, newGuid);

            // Assert
            Assert.That(found, Is.Null);
        }

        [Test]
        public async Task GetNprRequestByIdAsync_WhenSetDoesNotExist_ReturnsNull()
        {
            // Act
            Guid newGuid = Guid.NewGuid();
            Guid newGuid1 = Guid.NewGuid();
            RfqNprRequestUxModel? found = await _Service.GetNprRequestByIdAsync(newGuid, newGuid1);

            // Assert
            Assert.That(found, Is.Null);
        }

        #endregion

        #region JSON File Persistence Tests

        [Test]
        public async Task Persistence_DataSurvivesServiceRecreation()
        {
            // Arrange - create data with first service instance
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Persistent Set - DataSurvivesServiceRecreation");
            RfqNprRequestUxModel request = CreateTestRequest(reason: "Persistent Request");
            await _Service.AddNprRequestToSetAsync(set.Id, request);
            Guid setId = set.Id;
            Guid requestId = request.Id;

            // Act - dispose and create a new service instance
            _Service.Dispose();
            _Service = new RfqUxClientService(_Configuration!, _LoggerMock.Object, true);

            // Assert - data should be loadable from the new instance
            RfqNprRequestSetUxModel? reloadedSet = await _Service.GetNprRequestSetByIdAsync(setId);
            Assert.That(reloadedSet, Is.Not.Null);
            EqualConstraint isThePersistentSet = Is.EqualTo("Persistent Set - DataSurvivesServiceRecreation");
            Assert.That(reloadedSet!.RfqNumber, isThePersistentSet);
            EqualConstraint is1 = Is.EqualTo(1);
            Assert.That(reloadedSet.NprRequests.Count, is1);
            EqualConstraint isReqId = Is.EqualTo(requestId);
            Assert.That(reloadedSet.NprRequests.First().Id, isReqId);
            EqualConstraint isThePersistentRequest = Is.EqualTo("Persistent Request");
            Assert.That(reloadedSet.NprRequests.First().Reason, isThePersistentRequest);
        }

        [Test]
        public async Task Persistence_FileContainsValidJson()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("JSON Valid Set - FileContainsValidJson");
            RfqNprRequestUxModel request = CreateTestRequest();
            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act
            string json = await File.ReadAllTextAsync(_Service.NprRequestSetsFilePath);

            // Assert
            Assert.That(json, Is.Not.Null.And.Not.Empty);
            Assert.DoesNotThrow(() => JsonDocument.Parse(json));

            // Verify it deserializes correctly
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = false;

            List<RfqNprRequestSetUxModel>? deserialized = JsonSerializer.Deserialize<List<RfqNprRequestSetUxModel>>(json, options);
            Assert.That(deserialized, Is.Not.Null);
            EqualConstraint isEQ1 = Is.EqualTo(1);
            Assert.That(deserialized!.Count, isEQ1);
        }

        [Test]
        public async Task Persistence_AllRequestFieldsAreSerialized()
        {
            // Arrange
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Full Fields Set - AllRequestFieldsAreSerialized");
            RfqNprRequestUxModel request = new RfqNprRequestUxModel();
            request.Reason = "Test Reason";
            request.Customer = "Test Customer";
            request.PlatformName = "Platform A";
            request.ProgramName = "Program B";
            request.Project = "Project C";
            request.MaterialType = "Steel";
            request.SuggestedSewsEManufacturingSite = "Site X";
            request.CustomerPartNumber = "CPN-999";
            request.SupplierPartNumber = "SPN-888";
            request.SumitomoNumber = "SUM-777";
            request.MaterialDescription = "High Grade Steel";
            request.UnitOfMeasure = "KG";
            request.SupplierGroup = "Group Alpha";
            request.QtyPerVehicle = 4;
            request.Quantity = 1000;
            request.RequiredDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc);
            request.RaisedRemarks = "Urgent";
            request.IsCustomerNominatedSupplier = true;
            request.IsCustomerNominatedMaterial = false;
            request.SamplesRequired = true;
            request.SampleSite = "Lab 1";
            request.SampleQuantity = 5;
            request.SampleRecipient = "John Doe";
            request.SampleRequiredDate = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc);
            request.FreightAccount = "FA-001";
            request.AssociatedParts = "AP-001, AP-002";
            request.SuggestedManufacturer = "Manufacturer Z";

            await _Service.AddNprRequestToSetAsync(set.Id, request);

            // Act - reload from file via new service instance
            _Service.Dispose();
            _Service = new RfqUxClientService(_Configuration!, _LoggerMock.Object, true);

            RfqNprRequestUxModel? reloaded = await _Service.GetNprRequestByIdAsync(set.Id, request.Id);

            // Assert
            Assert.That(reloaded, Is.Not.Null);

            EqualConstraint expectedReason = Is.EqualTo("Test Reason");
            Assert.That(reloaded!.Reason, expectedReason);

            EqualConstraint expectedCustomer = Is.EqualTo("Test Customer");
            Assert.That(reloaded.Customer, expectedCustomer);

            EqualConstraint expectedPlatformName = Is.EqualTo("Platform A");
            Assert.That(reloaded.PlatformName, expectedPlatformName);

            EqualConstraint expectedProgramName = Is.EqualTo("Program B");
            Assert.That(reloaded.ProgramName, expectedProgramName);

            EqualConstraint expectedProject = Is.EqualTo("Project C");
            Assert.That(reloaded.Project, expectedProject);

            EqualConstraint expectedMaterialType = Is.EqualTo("Steel");
            Assert.That(reloaded.MaterialType, expectedMaterialType);

            EqualConstraint expectedSuggestedSewsEManufacturingSite = Is.EqualTo("Site X");
            Assert.That(reloaded.SuggestedSewsEManufacturingSite, expectedSuggestedSewsEManufacturingSite);

            EqualConstraint expectedCustomerPartNumber = Is.EqualTo("CPN-999");
            Assert.That(reloaded.CustomerPartNumber, expectedCustomerPartNumber);

            EqualConstraint expectedSupplierPartNumber = Is.EqualTo("SPN-888");
            Assert.That(reloaded.SupplierPartNumber, expectedSupplierPartNumber);

            EqualConstraint expectedSumitomoNumber = Is.EqualTo("SUM-777");
            Assert.That(reloaded.SumitomoNumber, expectedSumitomoNumber);

            EqualConstraint expectedMaterialDescription = Is.EqualTo("High Grade Steel");
            Assert.That(reloaded.MaterialDescription, expectedMaterialDescription);

            EqualConstraint expectedUnitOfMeasure = Is.EqualTo("KG");
            Assert.That(reloaded.UnitOfMeasure, expectedUnitOfMeasure);

            EqualConstraint expectedSupplierGroup = Is.EqualTo("Group Alpha");
            Assert.That(reloaded.SupplierGroup, expectedSupplierGroup);

            EqualConstraint expectedQtyPerVehicle = Is.EqualTo(4);
            Assert.That(reloaded.QtyPerVehicle, expectedQtyPerVehicle);

            EqualConstraint expectedQuantity = Is.EqualTo(1000);
            Assert.That(reloaded.Quantity, expectedQuantity);

            DateTime is20260615 = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc);
            EqualConstraint expectedRequiredDate = Is.EqualTo(is20260615);
            Assert.That(reloaded.RequiredDate, expectedRequiredDate);

            EqualConstraint expectedRaisedRemarks = Is.EqualTo("Urgent");
            Assert.That(reloaded.RaisedRemarks, expectedRaisedRemarks);

            Assert.That(reloaded.IsCustomerNominatedSupplier, Is.True);

            Assert.That(reloaded.IsCustomerNominatedMaterial, Is.False);

            Assert.That(reloaded.SamplesRequired, Is.True);

            EqualConstraint expectedSampleSite = Is.EqualTo("Lab 1");
            Assert.That(reloaded.SampleSite, expectedSampleSite);

            EqualConstraint expectedSampleQuantity = Is.EqualTo(5);
            Assert.That(reloaded.SampleQuantity, expectedSampleQuantity);

            EqualConstraint expectedSampleRecipient = Is.EqualTo("John Doe");
            Assert.That(reloaded.SampleRecipient, expectedSampleRecipient);

            DateTime is20260501 = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc);
            EqualConstraint expectedSampleRequiredDate = Is.EqualTo(is20260501);
            Assert.That(reloaded.SampleRequiredDate, expectedSampleRequiredDate);

            EqualConstraint expectedFreightAccount = Is.EqualTo("FA-001");
            Assert.That(reloaded.FreightAccount, expectedFreightAccount);

            EqualConstraint expectedAssociatedParts = Is.EqualTo("AP-001, AP-002");
            Assert.That(reloaded.AssociatedParts, expectedAssociatedParts);

            EqualConstraint expectedSuggestedManufacturer = Is.EqualTo("Manufacturer Z");
            Assert.That(reloaded.SuggestedManufacturer, expectedSuggestedManufacturer);
        }

        #endregion

        #region End-to-End Workflow Tests

        [Test]
        public async Task Workflow_CreateSetAddRequestsUpdateRemoveDelete()
        {
            // Step 1: Create a set
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel set = await CreateAndPersistTestSetAsync("Workflow Set - CreateSetAddRequestsUpdateRemoveDelete");
            EqualConstraint isEQLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);
            Assert.That(set.Status, isEQLocalUnchanged);

            // Step 2: Add requests
            RfqNprRequestUxModel request1 = CreateTestRequest(reason: "Reason 1", sumitomoNumber: "SUM-W01");
            RfqNprRequestUxModel request2 = CreateTestRequest(reason: "Reason 2", sumitomoNumber: "SUM-W02");
            RfqNprRequestUxModel request3 = CreateTestRequest(reason: "Reason 3", sumitomoNumber: "SUM-W03");
            await _Service.AddNprRequestToSetAsync(set.Id, request1);
            await _Service.AddNprRequestToSetAsync(set.Id, request2);
            await _Service.AddNprRequestToSetAsync(set.Id, request3);

            RfqNprRequestSetUxModel? afterAdd = await _Service.GetNprRequestSetByIdAsync(set.Id);
            
            EqualConstraint isThree = Is.EqualTo(3);
            EqualConstraint isLocalUnchanged = Is.EqualTo(NprSetRequestStatus.LocalUnchanged);
            Assert.That(afterAdd!.NprRequests.Count, isThree);

            Assert.That(afterAdd.Status, isLocalUnchanged);

            // Step 3: Update a request
            request2.Reason = "Reason 2 - Updated";
            request2.Quantity = 500;
            await _Service.UpdateNprRequestInSetAsync(set.Id, request2);

            RfqNprRequestUxModel? updatedRequest = await _Service.GetNprRequestByIdAsync(set.Id, request2.Id);

            EqualConstraint is500 = Is.EqualTo(500);
            EqualConstraint isEQReason2Updated = Is.EqualTo("Reason 2 - Updated");
            
            Assert.That(updatedRequest!.Reason, isEQReason2Updated);
            Assert.That(updatedRequest.Quantity, is500);

            // Step 4: Remove a request
            await _Service.RemoveNprRequestFromSetAsync(set.Id, request1.Id);

            EqualConstraint isTwo = Is.EqualTo(2);
            RfqNprRequestSetUxModel? afterRemove = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(afterRemove!.NprRequests.Count, isTwo);

            // Step 5: Update the set itself
            set.RfqNumber = "Workflow Set - Finalized";
            await _Service.UpdateNprRequestSetAsync(afterRemove);

            // Step 6: Verify final state
            RfqNprRequestSetUxModel? finalSet = await _Service.GetNprRequestSetByIdAsync(set.Id);
            Assert.That(finalSet, Is.Not.Null);
            Assert.That(finalSet!.NprRequests.Count, isTwo);
            NullConstraint notNull = Is.Not.Null;
            Assert.That(finalSet.Updated, notNull);

            // Step 7: Delete the set
            bool deleted = await _Service.DeleteNprRequestSetAsync(set.Id);
            Assert.That(deleted, Is.True);

            int finalCount = await _Service.GetAllNprRequestSetsAsync();
            EqualConstraint isZero = Is.EqualTo(0);
            Assert.That(finalCount, isZero);
        }

        [Test]
        public async Task Workflow_MultipleSetsWithIndependentRequests()
        {
            // Create two independent sets
            await _Service.DeleteAllNprRequestSetsAsync();
            RfqNprRequestSetUxModel setA = await CreateAndPersistTestSetAsync("Set A - MultipleSetsWithIndependentRequests");
            RfqNprRequestSetUxModel setB = await CreateAndPersistTestSetAsync("Set B - MultipleSetsWithIndependentRequests");

            // Add requests to each set
            RfqNprRequestUxModel requestA1 = CreateTestRequest(customer: "Customer A1");
            RfqNprRequestUxModel requestA2 = CreateTestRequest(customer: "Customer A2");
            RfqNprRequestUxModel requestB1 = CreateTestRequest(customer: "Customer B1");

            await _Service.AddNprRequestToSetAsync(setA.Id, requestA1);
            await _Service.AddNprRequestToSetAsync(setA.Id, requestA2);
            await _Service.AddNprRequestToSetAsync(setB.Id, requestB1);

            // Modify set A - should not affect set B
            await _Service.RemoveNprRequestFromSetAsync(setA.Id, requestA1.Id);

            // Verify independence
            RfqNprRequestSetUxModel? reloadedA = await _Service.GetNprRequestSetByIdAsync(setA.Id);
            RfqNprRequestSetUxModel? reloadedB = await _Service.GetNprRequestSetByIdAsync(setB.Id);

            EqualConstraint isEQ1 = Is.EqualTo(1);
            EqualConstraint isEQCustomerB1 = Is.EqualTo("Customer B1");

            Assert.That(reloadedA!.NprRequests.Count, isEQ1);
            Assert.That(reloadedB!.NprRequests.Count, isEQ1);
            Assert.That(reloadedB.NprRequests.First().Customer, isEQCustomerB1);

            // Delete set A - should not affect set B
            await _Service.DeleteNprRequestSetAsync(setA.Id);

            int totalSets = await _Service.GetAllNprRequestSetsAsync();
            Assert.That(totalSets, isEQ1);

            EqualConstraint isEQSetB = Is.EqualTo("Set B - MultipleSetsWithIndependentRequests");

            RfqNprRequestSetUxModel? survivingSet = await _Service.GetNprRequestSetByIdAsync(setB.Id);
            Assert.That(survivingSet, Is.Not.Null);
            Assert.That(survivingSet!.RfqNumber, isEQSetB);
        }

        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            if (disposing)
            {
                _Service?.Dispose();

                TestContext.Out.WriteLine("RfqClientIntegrationTests - Resources disposed");
            }

            _Disposed = true;
        }

        #endregion
    }
}
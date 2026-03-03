using SalesSystem.Rfq.Enums;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;

namespace Integration.Tests.Rfq.Client
{
    [TestFixture]
    sealed class RfqUxClientServiceNprTests : IDisposable
    {
#pragma warning disable IDESIGN103 // Avoid compound statements.

        #region Fields & Constructor

        RfqUxClientService _Service;
        Mock<ILogger<RfqUxClientService>> _LoggerMock;
        IConfiguration? _Configuration;
        bool _Disposed;

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
            // Ensure clean state
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

        #region IDisposable

        public void Dispose()
        {
            if (!_Disposed)
            {
                _Service?.Dispose();
                _Disposed = true;
            }
        }

        #endregion

        #region Helper Methods

        RfqNprRequestUxModel CreateTestRequest(
            string rfqNumber = "SEWS-25-025-DEADBEEF",
            string? reason = "Test Reason",
            string? customer = "Test Customer",
            string? sumitomoNumber = "SUM-001",
            int? quantity = 100)
        {
            RfqNprRequestUxModel request = new RfqNprRequestUxModel();
            request.RfqNumber = rfqNumber;
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

        List<RfqNprRequestUxModel> CreateTestRequestsAsync(string rfqNumber, int count = 1)
        {
            List<RfqNprRequestUxModel> requests = new List<RfqNprRequestUxModel>();
            for (int i = 0; i < count; i++)
            {
                RfqNprRequestUxModel request = CreateTestRequest(rfqNumber, sumitomoNumber: $"SUM-{i + 1:D3}");
                requests.Add(request);
            }

            return requests;
        }
        async Task<List<RfqNprRequestUxModel>> CreateAndPersistTestRequestsAsync(string rfqNumber, int count = 1)
        {
            List<RfqNprRequestUxModel> requests = new List<RfqNprRequestUxModel>();
            for (int i = 0; i < count; i++)
            {
                RfqNprRequestUxModel request = CreateTestRequest(rfqNumber, sumitomoNumber: $"SUM-{i + 1:D3}");
                requests.Add(request);
            }

            List<RfqNprRequestUxModel> created = await _Service.CreateNprRequestsAsync(requests);
            return created;
        }

        #endregion

        #region GetAllNprRequestsAsync Tests

        [Test]
        public async Task GetAllNprRequestsAsync_WhenNoFileExists_ReturnsZero()
        {
            // Act
            int count = await _Service.GetAllNprRequestsAsync();

            // Assert
            Assert.That(count, Is.EqualTo(0));
            Assert.That(_Service.NprRequestSets, Is.Empty);
        }

        [Test]
        public async Task GetAllNprRequestsAsync_WhenRequestsExist_ReturnsCorrectCount()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("RFQ-A", 2);
            await CreateAndPersistTestRequestsAsync("RFQ-B", 1);

            // Act
            int count = await _Service.GetAllNprRequestsAsync();

            // Assert
            Assert.That(count, Is.EqualTo(3));
            Assert.That(_Service.NprRequestSets.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllNprRequestsAsync_WhenFileIsEmpty_ReturnsZero()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            string? directory = Path.GetDirectoryName(_Service.NprRequestSetsFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(_Service.NprRequestSetsFilePath, "");

            // Act
            int count = await _Service.GetAllNprRequestsAsync();

            // Assert
            Assert.That(count, Is.EqualTo(0));
        }

        #endregion

        #region GetNprRequestsByRfqNumberAsync Tests

        [Test]
        public async Task GetNprRequestsByRfqNumberAsync_WhenRequestsExist_ReturnsList()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("FIND-ME-RFQ", 3);

            // Act
            List<RfqNprRequestUxModel>? found = await _Service.GetNprRequestsByRfqNumberAsync("FIND-ME-RFQ");

            // Assert
            Assert.That(found, Is.Not.Null);
            Assert.That(found!.Count, Is.EqualTo(3));
            Assert.That(found.All(r => r.RfqNumber == "FIND-ME-RFQ"), Is.True);
        }

        [Test]
        public async Task GetNprRequestsByRfqNumberAsync_WhenNotFound_ReturnsNull()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("OTHER-RFQ", 1);

            // Act
            List<RfqNprRequestUxModel>? found = await _Service.GetNprRequestsByRfqNumberAsync("NONEXISTENT-RFQ");

            // Assert
            Assert.That(found, Is.Null);
        }

        [Test]
        public async Task GetNprRequestsByRfqNumberAsync_WhenNoFileExists_ReturnsNull()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();

            // Act
            List<RfqNprRequestUxModel>? found = await _Service.GetNprRequestsByRfqNumberAsync("ANY-RFQ");

            // Assert
            Assert.That(found, Is.Null);
        }

        #endregion

        #region GetNprRequestByIdAsync Tests

        [Test]
        public async Task GetNprRequestByIdAsync_WhenExists_ReturnsRequest()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("ID-TEST-RFQ", 1);
            Guid targetId = created[0].Id;

            // Act
            List<RfqNprRequestUxModel>? found = await _Service.GetNprRequestsByRfqProjectIdAsync(targetId);

            // Assert
            Assert.That(found, Is.Not.Null);
            Assert.That(found!.Count, Is.GreaterThan(0));
            Assert.That(found!.First().RfqNumber, Is.EqualTo("ID-TEST-RFQ"));
        }

        [Test]
        public async Task GetNprRequestByIdAsync_WhenNotFound_ReturnsNull()
        {
            // Act
            List<RfqNprRequestUxModel>? found = await _Service.GetNprRequestsByRfqProjectIdAsync(Guid.NewGuid());

            // Assert
            Assert.That(found, Is.Null);
        }

        #endregion

        #region CreateNprRequestsAsync Tests

        [Test]
        public async Task CreateNprRequestsAsync_WithValidRequests_CreatesAndPersists()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            RfqNprRequestUxModel request = CreateTestRequest("NEW-RFQ");
            List<RfqNprRequestUxModel> requests = new List<RfqNprRequestUxModel> { request };

            // Act
            List<RfqNprRequestUxModel> result = await _Service.CreateNprRequestsAsync(requests);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].RfqNumber, Is.EqualTo("NEW-RFQ"));
            Assert.That(result[0].Created, Is.Not.EqualTo(default(DateTime)));
            Assert.That(File.Exists(_Service.NprRequestSetsFilePath), Is.True);

            // Verify persistence
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public async Task CreateNprRequestsAsync_MultipleRequests_AllPersisted()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();

            // Act
            await CreateAndPersistTestRequestsAsync("RFQ-1", 2);
            await CreateAndPersistTestRequestsAsync("RFQ-2", 3);

            // Assert
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(5));

            List<RfqNprRequestUxModel>? rfq1 = await _Service.GetNprRequestsByRfqNumberAsync("RFQ-1");
            Assert.That(rfq1, Is.Not.Null);
            Assert.That(rfq1!.Count, Is.EqualTo(2));

            List<RfqNprRequestUxModel>? rfq2 = await _Service.GetNprRequestsByRfqNumberAsync("RFQ-2");
            Assert.That(rfq2, Is.Not.Null);
            Assert.That(rfq2!.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateNprRequestsAsync_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.CreateNprRequestsAsync(null!));
        }

        [Test]
        public async Task CreateNprRequestsAsync_SetsCreatedTimestamp()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            DateTime beforeCreate = DateTime.UtcNow;
            RfqNprRequestUxModel request = CreateTestRequest("TIMESTAMP-RFQ");

            // Act
            List<RfqNprRequestUxModel> result = await _Service.CreateNprRequestsAsync(new List<RfqNprRequestUxModel> { request });

            // Assert
            DateTime afterCreate = DateTime.UtcNow;
            Assert.That(result[0].Created, Is.GreaterThanOrEqualTo(beforeCreate));
            Assert.That(result[0].Created, Is.LessThanOrEqualTo(afterCreate));
        }

        #endregion

        #region UpdateNprRequestAsync Tests

        [Test]
        public async Task UpdateNprRequestAsync_WithValidRequest_UpdatesAndPersists()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("UPDATE-RFQ", 1);
            RfqNprRequestUxModel toUpdate = created[0];

            // Act
            toUpdate.SumitomoNumber = "SUM-UPDATED";
            created[0] = toUpdate;
            List<RfqNprRequestUxModel> updated = await _Service.UpdateNprRequestsAsync(created);

            // Assert
            Assert.That(updated[0].SumitomoNumber, Is.EqualTo("SUM-UPDATED"));
            Assert.That(updated[0].Updated, Is.Not.EqualTo(default(DateTime)));

            // Verify persistence
            List<RfqNprRequestUxModel>? reloaded = await _Service.GetNprRequestsByRfqProjectIdAsync(toUpdate.Id);
            Assert.That(reloaded, Is.Not.Null);
            Assert.That(reloaded![0].SumitomoNumber, Is.EqualTo("SUM-UPDATED"));
        }

        [Test]
        public async Task UpdateNprRequestAsync_SetsUpdatedTimestamp()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("TIMESTAMP-UPDATE-RFQ", 1);
            DateTime beforeUpdate = created[0].Created;

            // Act
            created[0].Reason = "Updated Reason";
            List<RfqNprRequestUxModel>? updated = await _Service.UpdateNprRequestsAsync(created);

            // Assert
            DateTime afterUpdate = DateTime.UtcNow;
            Assert.That(updated, Is.Not.Null);
            Assert.That(updated![0].Updated, Is.GreaterThanOrEqualTo(beforeUpdate));
            Assert.That(updated![0].Updated, Is.LessThanOrEqualTo(afterUpdate));
        }

        [Test]
        public async Task UpdateNprRequestAsync_WhenNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> ghostSet = CreateTestRequestsAsync("GHOST-RFQ-PROJECT", 1);
            ghostSet[0] = CreateTestRequest("GHOST-RFQ");

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _Service.UpdateNprRequestsAsync(ghostSet));
        }

        [Test]
        public void UpdateNprRequestAsync_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _Service.UpdateNprRequestsAsync(null!));
        }

        [Test]
        public async Task UpdateNprRequestAsync_DoesNotAffectOtherRequests()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("MULTI-UPDATE-RFQ", 2);

            // Act
            created[0].SumitomoNumber = "SUM-CHANGED";
            await _Service.UpdateNprRequestsAsync(created);

            // Assert
            RfqNprRequestUxModel? other = await _Service.GetNprRequestByIdAsync(created[1].Id);
            Assert.That(other, Is.Not.Null);
            Assert.That(other!.SumitomoNumber, Is.EqualTo("SUM-002"));
        }

        #endregion

        #region DeleteNprRequestAsync Tests

        [Test]
        public async Task DeleteNprRequestAsync_WhenExists_DeletesAndReturnsTrue()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("DELETE-RFQ", 1);

            // Act
            bool result = await _Service.DeleteNprRequestAsync(created[0].Id);

            // Assert
            Assert.That(result, Is.True);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteNprRequestAsync_WhenNotFound_ReturnsFalse()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("KEEP-RFQ", 1);

            // Act
            bool result = await _Service.DeleteNprRequestAsync(Guid.NewGuid());

            // Assert
            Assert.That(result, Is.False);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteNprRequestAsync_DeletesOnlyTarget()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            List<RfqNprRequestUxModel> created = await CreateAndPersistTestRequestsAsync("TARGET-RFQ", 3);
            Guid targetId = created[1].Id;

            // Act
            bool result = await _Service.DeleteNprRequestAsync(targetId);

            // Assert
            Assert.That(result, Is.True);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(2));

            RfqNprRequestUxModel? deleted = await _Service.GetNprRequestByIdAsync(targetId);
            Assert.That(deleted, Is.Null);

            RfqNprRequestUxModel? remaining1 = await _Service.GetNprRequestByIdAsync(created[0].Id);
            Assert.That(remaining1, Is.Not.Null);

            RfqNprRequestUxModel? remaining3 = await _Service.GetNprRequestByIdAsync(created[2].Id);
            Assert.That(remaining3, Is.Not.Null);
        }

        #endregion

        #region DeleteAllNprRequestsAsync Tests

        [Test]
        public async Task DeleteAllNprRequestsAsync_WhenRequestsExist_DeletesAll()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("ALL-DEL-RFQ", 5);

            // Act
            bool result = await _Service.DeleteAllNprRequestsAsync();

            // Assert
            Assert.That(result, Is.True);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteAllNprRequestsAsync_WhenEmpty_ReturnsFalse()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();

            // Act
            bool result = await _Service.DeleteAllNprRequestsAsync();

            // Assert
            Assert.That(result, Is.False);
        }

        #endregion

        #region DeleteNprRequestsByRfqNumberAsync Tests

        [Test]
        public async Task DeleteNprRequestsByRfqNumberAsync_WhenExists_DeletesOnlyMatchingRfq()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("RFQ-KEEP", 2);
            await CreateAndPersistTestRequestsAsync("RFQ-DELETE", 3);

            // Act
            bool result = await _Service.DeleteNprRequestsByRfqNumberAsync("RFQ-DELETE");

            // Assert
            Assert.That(result, Is.True);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(2));

            List<RfqNprRequestUxModel>? remaining = await _Service.GetNprRequestsByRfqNumberAsync("RFQ-KEEP");
            Assert.That(remaining, Is.Not.Null);
            Assert.That(remaining!.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteNprRequestsByRfqNumberAsync_WhenNotFound_ReturnsFalse()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();
            await CreateAndPersistTestRequestsAsync("RFQ-EXISTS", 1);

            // Act
            bool result = await _Service.DeleteNprRequestsByRfqNumberAsync("RFQ-NONEXISTENT");

            // Assert
            Assert.That(result, Is.False);
            int count = await _Service.GetAllNprRequestsAsync();
            Assert.That(count, Is.EqualTo(1));
        }

        #endregion

        #region Persistence / Serialization Tests

        [Test]
        public async Task Persistence_AllRequestFieldsAreSerialized()
        {
            // Arrange
            await _Service.DeleteAllNprRequestsAsync();

            RfqNprRequestUxModel request = new RfqNprRequestUxModel();
            request.RfqNumber = "SERIAL-RFQ";
            request.Reason = "Serialization Test";
            request.Customer = "Acme Corp";
            request.PlatformName = "Platform X";
            request.ProgramName = "Program Y";
            request.Project = "Project Z";
            request.MaterialType = "Steel";
            request.SuggestedSewsEManufacturingSite = "Site A";
            request.CustomerPartNumber = "CPN-999";
            request.SupplierPartNumber = "SPN-888";
            request.SumitomoNumber = "SUM-777";
            request.MaterialDescription = "High-grade steel connector";
            request.UnitOfMeasure = "EA";
            request.SupplierGroup = "Group Alpha";
            request.QtyPerVehicle = 4;
            request.Quantity = 500;
            request.RequiredDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc);
            request.RaisedRemarks = "Urgent requirement";
            request.IsCustomerNominatedSupplier = true;
            request.IsCustomerNominatedMaterial = false;
            request.SamplesRequired = true;
            request.SampleSite = "Lab B";
            request.SampleQuantity = 10;
            request.SampleRecipient = "John Doe";
            request.SampleRequiredDate = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc);
            request.FreightAccount = "FA-12345";
            request.AssociatedParts = "AP-001, AP-002";
            request.SuggestedManufacturer = "MegaCorp";

            // Act
            List<RfqNprRequestUxModel> created = await _Service.CreateNprRequestsAsync(new List<RfqNprRequestUxModel> { request });

            // Reload from file
            RfqNprRequestUxModel? loaded = await _Service.GetNprRequestByIdAsync(created[0].Id);

            // Assert
            Assert.That(loaded, Is.Not.Null);
            Assert.That(loaded!.RfqNumber, Is.EqualTo("SERIAL-RFQ"));
            Assert.That(loaded.Reason, Is.EqualTo("Serialization Test"));
            Assert.That(loaded.Customer, Is.EqualTo("Acme Corp"));
            Assert.That(loaded.PlatformName, Is.EqualTo("Platform X"));
            Assert.That(loaded.ProgramName, Is.EqualTo("Program Y"));
            Assert.That(loaded.Project, Is.EqualTo("Project Z"));
            Assert.That(loaded.MaterialType, Is.EqualTo("Steel"));
            Assert.That(loaded.SuggestedSewsEManufacturingSite, Is.EqualTo("Site A"));
            Assert.That(loaded.CustomerPartNumber, Is.EqualTo("CPN-999"));
            Assert.That(loaded.SupplierPartNumber, Is.EqualTo("SPN-888"));
            Assert.That(loaded.SumitomoNumber, Is.EqualTo("SUM-777"));
            Assert.That(loaded.MaterialDescription, Is.EqualTo("High-grade steel connector"));
            Assert.That(loaded.UnitOfMeasure, Is.EqualTo("EA"));
            Assert.That(loaded.SupplierGroup, Is.EqualTo("Group Alpha"));
            Assert.That(loaded.QtyPerVehicle, Is.EqualTo(4));
            Assert.That(loaded.Quantity, Is.EqualTo(500));
            Assert.That(loaded.RequiredDate, Is.EqualTo(new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc)));
            Assert.That(loaded.RaisedRemarks, Is.EqualTo("Urgent requirement"));
            Assert.That(loaded.IsCustomerNominatedSupplier, Is.True);
            Assert.That(loaded.IsCustomerNominatedMaterial, Is.False);
            Assert.That(loaded.SamplesRequired, Is.True);
            Assert.That(loaded.SampleSite, Is.EqualTo("Lab B"));
            Assert.That(loaded.SampleQuantity, Is.EqualTo(10));
            Assert.That(loaded.SampleRecipient, Is.EqualTo("John Doe"));
            Assert.That(loaded.SampleRequiredDate, Is.EqualTo(new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc)));
            Assert.That(loaded.FreightAccount, Is.EqualTo("FA-12345"));
            Assert.That(loaded.AssociatedParts, Is.EqualTo("AP-001, AP-002"));
            Assert.That(loaded.SuggestedManufacturer, Is.EqualTo("MegaCorp"));
        }

        #endregion
    }
}
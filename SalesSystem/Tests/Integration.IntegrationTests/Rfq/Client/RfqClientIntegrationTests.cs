using SalesSystem.Rfq.Extensions;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;
using RfqModule;

namespace Integration.Tests.Rfq.Client
{
    [TestFixture]
    public sealed class RfqClientIntegrationTests : IDisposable
    {
        #region Fields

        RfqUxClientService? _RfqUxClientService;
        IConfiguration? _Configuration;
        bool _Disposed;

        #endregion

        #region Setup and Teardown

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitializeConfiguration();
            InitializeService();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Dispose();
        }

        #endregion

        #region Initialization Methods

        void InitializeConfiguration()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            Dictionary<string, string?> configuration = new Dictionary<string, string?>();
            configuration["GrpcService:Url"] = "https://localhost:7207";
            configuration["GrpcService:TimeoutSeconds"] = "90";
            configuration["GrpcService:MaxReceiveMessageSizeMB"] = "256"; // 16 MB
            configuration["GrpcService:MaxSendMessageSizeMB"] = "256";    // 16 MB
            configBuilder.AddInMemoryCollection(configuration);
            _Configuration = configBuilder.Build();
            TestContext.Out.WriteLine("RfqClientIntegrationTests - Configuration initialized");
        }

        void InitializeService()
        {
            ArgumentNullException.ThrowIfNull(_Configuration);
            Mock<ILogger<RfqUxClientService>> logger = new Mock<ILogger<RfqUxClientService>>();

            _RfqUxClientService = new RfqUxClientService(_Configuration, logger.Object);

            TestContext.Out.WriteLine("RfqClientIntegrationTests - RfqUxClientService initialized successfully");
            TestContext.Out.WriteLine($"Max GRPC Response Size: {RfqUxClientService.MAX_GRPC_RESPONSE_SIZE / 1024 / 1024} MB");

        }

        #endregion

        #region Test Methods
        [Test]
        [Category("Integration")]
        [Description("Verify that GetCustomersByUserIdAsync returns a project list")]
        public async Task GetCustomersByUserIdAsyncTest()
        {
            EnsureServiceInitialized();
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            // Arrange
            Guid testUserId = Guid.Parse("86380EFD-5651-4552-8145-E59E785F099A");
            TestContext.Out.WriteLine($"Testing GetCustomersByUserIdAsync with RowId: {testUserId}");

            // Act
            int rfqProjectList = await _RfqUxClientService.GetCustomersByUserIdAsync(testUserId);

            // Assert this is bigger than 0
            GreaterThanConstraint greaterThanZero = Is.GreaterThan(0);
            Assert.That(rfqProjectList, greaterThanZero, "RfqProject list count should be greater than 0");

            foreach (RfqProjectUx project in _RfqUxClientService.RfqProjectUxs)
            {
                TestContext.Out.WriteLine($"Retrieved RFQ Project: RowId={project.RowId}, RfqNumber={project.RfqNumber}");
            }
        }
        [Test]
        [Category("Integration")]
        [Description("Verify that GetRfqProjectByIdAsync returns a project")]
        public async Task GetRfqProjectByIdAsyncTest()
        {
            // Arrange
            const long testProjectRowId = 130;
            EnsureServiceInitialized();

            TestContext.Out.WriteLine($"Testing GetRfqProjectByIdAsync with RowId: {testProjectRowId}");

            // Act
            RfqProject? rfqProject = await GetRfqProjectAsync(testProjectRowId);

            // Assert
            AssertProjectRetrieved(rfqProject, testProjectRowId);

            Assert.That(rfqProject, Is.Not.Null, "RfqProject should not be null");
            long rowId = rfqProject.RowId;
            await AssertDrawingPartNumbersRetrieved(rowId);
        }

        [Test]
        [Category("Integration")]
        [Description("Verify that service can retrieve all RFQ projects and their drawing numbers")]
        public async Task GetAllRfqProjectsAsyncTest()
        {
            // Arrange
            const int position = 0;
            const int take = 10;
            //const int maxProjectsToTest = 3;

            EnsureServiceInitialized();
            TestContext.Out.WriteLine("Testing GetAllRfqProjectAsync");

            // Act
            int projectCount = await GetAllRfqProjectsAsync(position, take);

            // Assert
            AssertProjectsRetrieved(projectCount);
            // await AssertDrawingNumbersForMultipleProjects(maxProjectsToTest);
        }

        [Test]
        [Category("Integration")]
        [Description("Manual test to explore a specific RFQ project and its drawing numbers")]
        public async Task GetRfqProjectAsyncTest()
        {
            // Arrange
            const long specificRowId = 130;
            EnsureServiceInitialized();

            // Act
            RfqProject? project = await GetRfqProjectAsync(specificRowId);

            // Assert
            if (project is null)
            {
                LogProjectNotFound(specificRowId);
                Assert.Fail($"No project found with RowId: {specificRowId}");
                return;
            }

            LogProjectDetails(project);

            long rowId = project.RowId;
            await LogDrawingPartNumbers(rowId);

            Assert.Pass("Manual exploration test completed - check console output");
        }

        [Test]
        [Category("Integration")]
        [Description("Verify that GetRfqProjectByIdAsync returns a project with drawing/part numbers")]
        public async Task UpdateRfqProjectAsyncTest()
        {
            // Arrange - get a project first
            const long testProjectRowId = 127;
            EnsureServiceInitialized();

            TestContext.Out.WriteLine($"Testing UpdateRfqProjectAsync with RowId: {testProjectRowId}");
            
            RfqProject? rfqProject = await GetRfqProjectAsync(testProjectRowId);

            // Assert
            AssertProjectRetrieved(rfqProject, testProjectRowId);
            Assert.That(rfqProject, Is.Not.Null, "RfqProject should not be null");

            RfqProjectUx? project = rfqProject.ToUx();

            // save the name for later comparison
            string originalRfqNumber = project!.RfqNumber;

            Assert.That(project, Is.Not.Null, "RfqProjectUx should not be null");

            // Act - update the project
            project.RfqNumber += " - Updated";

            rfqProject = project.ToDto();

            UpdateRfqProjectGrpcResponse result = await _RfqUxClientService!.UpdateRfqProjectAsync(project);

            TestContext.Out.WriteLine($"Update Result: Success={result.Success}, Message={result.Message}");

            // Get the project again to verify update
            rfqProject = await GetRfqProjectAsync(testProjectRowId);
            project = rfqProject.ToUx();

            Assert.That(project, Is.Not.Null, "RfqProjectUx should not be null");

            TestContext.Out.WriteLine($"Updated Project RfqNumber: {project.RfqNumber}");

            EndsWithConstraint doesEndsWith = Does.EndWith(" - Updated");
            Assert.That(project.RfqNumber, doesEndsWith, "RfqNumber should reflect the update");

            project.RfqNumber = project.RfqNumber.Replace(" - Updated", "", StringComparison.Ordinal);

            // save changes to revert
            rfqProject = project.ToDto();
            result = await _RfqUxClientService!.UpdateRfqProjectAsync(project);
            TestContext.Out.WriteLine($"Revert Update Result: Success={result.Success}, Message={result.Message}");

            // reread to confirm revert
            rfqProject = await GetRfqProjectAsync(testProjectRowId);
            project = rfqProject.ToUx();
            Assert.That(project, Is.Not.Null, "RfqProjectUx should not be null after revert");

            TestContext.Out.WriteLine($"Reverted Project RfqNumber: {project.RfqNumber}");
            EqualConstraint isEqualToOriginal = Is.EqualTo(originalRfqNumber);
            Assert.That(project.RfqNumber, isEqualToOriginal, "RfqNumber should be reverted to original");

        }

        [Test]
        [Category("Integration")]
        [Description("Manual test to update a specific RFQ project drawing numbers")]
        public async Task UpdateRfqDrawingNumbersAsyncTest()
        {
            // Arrange
            const long specificRowId = 127;
            EnsureServiceInitialized();

            // Act
            RfqProject? project = await GetRfqProjectAsync(specificRowId);

            // Assert
            if (project is null)
            {
                LogProjectNotFound(specificRowId);
                Assert.Fail($"No project found with RowId: {specificRowId}");
                return;
            }

            LogProjectDetails(project);

            long rowId = project.RowId;
            List<RfqDrawingPartNumberUx?> parts = await LogDrawingPartNumbers(rowId);
            if (parts.Count == 0)
            {
                TestContext.Out.WriteLine("No drawing part numbers found to update.");
                Assert.Inconclusive("No drawing part numbers found to update.");
                return;
            }

            // update all IsCompleted to false
            foreach (RfqDrawingPartNumberUx? part in parts)
            {
                if (part is not null)
                {
                    part.IsExactMatch = false;
                    part.IsSwapped = false;
                }
            }

            UpdateRfqDrawingPartNumbersGrpcResponse result = await _RfqUxClientService!.UpdateRfqDrawingPartNumbersAsync(parts);

            TestContext.Out.WriteLine($"Update Result: Success={result.Success}, Message={result.Message}");
            // reread to confirm update
            await LogDrawingPartNumbers(rowId);

            Assert.Pass("Manual exploration test completed - check console output");
        }

        [Test]
        [Category("Integration")]
        [Description("Verify that service can retrieve all alternative parts with SumtomoNumber and Price from Emacs")]
        public async Task GetAllAlternativePartsAsyncTest()
        {
            // Arrange
            EnsureServiceInitialized();
            TestContext.Out.WriteLine("Testing GetAlternativePartsAsyncTest");

            // Act 100
            int alternativePartsCount = await GetAllAlternativePartsAsync(0, 100);
            TestContext.Out.WriteLine($"Retrieved {_RfqUxClientService!.AlternativeParts.Count} alternative parts");
            // Assert
            AssertAllAlternativePartsRetrieved(alternativePartsCount);

            // Act 1000
            alternativePartsCount = await GetAllAlternativePartsAsync(0, 1000);
            TestContext.Out.WriteLine($"Retrieved {_RfqUxClientService!.AlternativeParts.Count} alternative parts");
            // Assert
            AssertAllAlternativePartsRetrieved(alternativePartsCount);

            // Act 10000
            alternativePartsCount = await GetAllAlternativePartsAsync(0, 5000);
            TestContext.Out.WriteLine($"Retrieved {_RfqUxClientService!.AlternativeParts.Count} alternative parts");
            // Assert
            AssertAllAlternativePartsRetrieved(alternativePartsCount);


            // Act 10000
            alternativePartsCount = await GetAllAlternativePartsAsync(0, -1);
            TestContext.Out.WriteLine($"Retrieved ALL {_RfqUxClientService!.AlternativeParts.Count} alternative parts");
            // Assert
            AssertAllAlternativePartsRetrieved(alternativePartsCount);
        }
        #endregion

        #region Helper Methods - Service Operations

        async Task<RfqProject?> GetRfqProjectAsync(long rowId)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            try
            {
                RfqProject? project = await _RfqUxClientService.GetRfqProjectByIdAsync(rowId);
                return project;
            }
            catch (Exception ex)
            {
                TestContext.Out.WriteLine($"Error retrieving RFQ project with RowId: {rowId}: {ex.Message}");
                throw;
            }
        }

        async Task<int> GetAllRfqProjectsAsync(int position, int take)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            try
            {
                return await _RfqUxClientService.GetAllRfqProjectAsync(position, take);
            }
            catch (Exception ex)
            {
                TestContext.Out.WriteLine($"Error retrieving all RFQ projects: {ex.Message}: {ex.Message}");
                throw;
            }
        }

        async Task<int> GetAllAlternativePartsAsync()
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            try
            {
                return await _RfqUxClientService.GetAllAlternativePartsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving all alternative parts: {ex.Message}: {ex.Message}");
                throw;
            }
        }

        async Task<int> GetDrawingPartNumbersAsync(long rfqId)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            try
            {
                TestContext.Out.WriteLine($"Retrieving drawing part numbers for RfqId: {rfqId}");
                return await _RfqUxClientService.GetRfqDrawingPartNumbersByRfqIdAsync(rfqId);
            }
            catch (Exception ex)
            {
                TestContext.Out.WriteLine($"Error retrieving drawing part numbers for RfqId: {rfqId}: {ex.Message}");
                throw;
            }
        }

        async Task<int> GetAllAlternativePartsAsync(int position, int take)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            try
            {
                return await _RfqUxClientService.GetAllAlternativePartsAsync(position, take);
            }
            catch (Exception ex)
            {
                TestContext.Out.WriteLine($"Error retrieving all alternative parts: {ex.Message}: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Helper Methods - Assertions

        void EnsureServiceInitialized()
        {
            Assert.That(_RfqUxClientService, Is.Not.Null, "RfqUxClientService should be initialized");
        }

        void AssertProjectRetrieved(RfqProject? project, long expectedRowId)
        {
            Assert.Multiple(() =>
            {
                Assert.That(project, Is.Not.Null, "RfqProject should not be null");
                EqualConstraint condition = Is.EqualTo(expectedRowId);
                Assert.That(project!.RowId, condition, "RowId should match the requested ID");
            });

            TestContext.Out.WriteLine($"Retrieved RFQ Project: RowId={project!.RowId}, RfqNumber={project.RfqNumber}");
        }

        async Task AssertDrawingPartNumbersRetrieved(long rowId)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            int partNumberCount = await GetDrawingPartNumbersAsync(rowId);

            GreaterThanOrEqualConstraint condition = Is.GreaterThanOrEqualTo(0);
            Assert.That(partNumberCount, condition, "Part number count should be >= 0");
            TestContext.Out.WriteLine($"Retrieved {partNumberCount} drawing part numbers");

            IReadOnlyCollection<RfqDrawingPartNumberUx?> cachedPartNumbers = _RfqUxClientService.RfqDrawingPartNumbers;
            Assert.Multiple(() =>
            {
                Assert.That(cachedPartNumbers, Is.Not.Null, "Cached part numbers collection should not be null");
                EqualConstraint conditionCount = Is.EqualTo(partNumberCount);
                Assert.That(cachedPartNumbers.Count, conditionCount, "Cached part numbers count should match");
            });

            LogPartNumberDetails(cachedPartNumbers);
        }

        void AssertProjectsRetrieved(int projectCount)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);
            GreaterThanOrEqualConstraint condition = Is.GreaterThanOrEqualTo(0);
            Assert.That(projectCount, condition, "Project count should be >= 0");
            TestContext.Out.WriteLine($"Retrieved {projectCount} RFQ projects");

            IReadOnlyCollection<RfqProject> projects = _RfqUxClientService.RfqProjects;
            EqualConstraint conditionIsEqualTo = Is.EqualTo(projectCount);
            Assert.That(projects.Count, conditionIsEqualTo, "Cached projects count should match");
        }

        void AssertAlternativePartsRetrieved(int alternativePartsCount)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);
            GreaterThanOrEqualConstraint condition = Is.GreaterThanOrEqualTo(0);
            Assert.That(alternativePartsCount, condition, "AlternativeParts count should be >= 0");
            Debug.WriteLine($"Retrieved {alternativePartsCount} alternative parts");

            IReadOnlyCollection<AlternativePartUxModel> parts = _RfqUxClientService.AlternativeParts;
            EqualConstraint conditionIsEqualTo = Is.EqualTo(alternativePartsCount);
            Assert.That(parts.Count, conditionIsEqualTo, "Cached alternative parts count should match");
        }

        async Task AssertDrawingNumbersForMultipleProjects(int maxProjectsToTest)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            IEnumerable<RfqProject> projects = _RfqUxClientService.RfqProjects.Take(maxProjectsToTest);
            
            foreach (RfqProject project in projects)
            {
                long rfqId = project.RowId;
                TestContext.Out.WriteLine($"Getting part numbers for Project: RowId={project.RowId}, RfqNumber={project.RfqNumber}");

                int partCount = await GetDrawingPartNumbersAsync(rfqId);
                TestContext.Out.WriteLine($"  Found {partCount} part numbers for this project");
                GreaterThanOrEqualConstraint isGreaterThanOrEqualToZero = Is.GreaterThanOrEqualTo(0);
                Assert.That(partCount, isGreaterThanOrEqualToZero, 
                    $"Part count for RfqId {rfqId} should be >= 0");
            }
        }
        void AssertAllAlternativePartsRetrieved(int alternativePartsCount)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);
            GreaterThanOrEqualConstraint condition = Is.GreaterThanOrEqualTo(0);
            Assert.That(alternativePartsCount, condition, "AlternativeParts count should be >= 0");
            IReadOnlyCollection<AlternativePartUxModel> parts = _RfqUxClientService.AlternativeParts;
            EqualConstraint conditionIsEqualTo = Is.EqualTo(alternativePartsCount);
            Assert.That(parts.Count, conditionIsEqualTo, "Cached alternative parts count should match");
        }

        #endregion

        #region Helper Methods - Logging

        void LogPartNumberDetails(IReadOnlyCollection<RfqDrawingPartNumberUx?> partNumbers)
        {
            List<RfqDrawingPartNumberUx?> partNumberList = partNumbers.Where(p => p is not null).ToList();
            foreach (RfqDrawingPartNumberUx? partNumber in partNumberList)
            {
                TestContext.Out.WriteLine(
                    $"Part Number: RowId={partNumber!.RowId}, Customer P/N={partNumber.CustomerPartNumber}, Drawing P/N={partNumber.DrawingPartNumber}, " +
                    $"Drawing Price={partNumber.DrawingPartNumberPrice}, Swapped P/N={partNumber.SwappedPartNumber}, Swapped Price={partNumber.SwappedPartNumberPrice}, " +
                    $"PriceSource={partNumber.PriceSource}, IsExactMatch={partNumber.IsExactMatch}, IsCompleted={partNumber.IsCompleted}");
            }
        }

        void LogProjectDetails(RfqProject project)
        {
            ArgumentNullException.ThrowIfNull(project);

            TestContext.Out.WriteLine("Project Found:");
            TestContext.Out.WriteLine($"  RowId: {project.RowId}");
            TestContext.Out.WriteLine($"  RfqNumber: {project.RfqNumber}");
            TestContext.Out.WriteLine($"  CustomerBusinessGroupCode: {project.CustomerBusinessGroupCode}");
            TestContext.Out.WriteLine($"  ProjectName: {project.ProjectName}");
            TestContext.Out.WriteLine($"  CarModelName: {project.CarModelName}");
        }

        async Task<List<RfqDrawingPartNumberUx?>> LogDrawingPartNumbers(long rfqId)
        {
            ArgumentNullException.ThrowIfNull(_RfqUxClientService);

            int partCount = await GetDrawingPartNumbersAsync(rfqId);
            
            Console.WriteLine($"\nDrawing Part Numbers ({partCount} found) for RfqId {rfqId}:");

            List<RfqDrawingPartNumberUx?> partList = _RfqUxClientService.RfqDrawingPartNumbers.Where(p => p is not null).ToList();
            foreach (RfqDrawingPartNumberUx? part in partList)
            {
                string msg = $"  - {part!.CustomerPartNumber} / {part.DrawingPartNumber} (${part.DrawingPartNumberPrice}) ";
                msg += (part.IsCompleted == true ? "completed" : "in progress");
                Console.WriteLine(msg);
            }

            return partList;
        }

        static void LogProjectNotFound(long rowId)
        {
            Console.WriteLine($"No project found with RowId: {rowId}");
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            if (disposing)
            {
                _RfqUxClientService?.Dispose();
                
                TestContext.Out.WriteLine("RfqClientIntegrationTests - Resources disposed");
            }

            _Disposed = true;
        }

        #endregion
    }
}

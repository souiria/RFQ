using SalesSystem.Rfq.Extensions;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;
using SalesSystem.Rfq.Tests.Resources;
using System.Diagnostics;
using System.Globalization;
using NUnit.Framework.Constraints;

namespace SalesSystem.Rfq.Tests
{
    [TestFixture]
    public class RfqUxServiceLiveTests
    {
        static IEnumerable<string>? _LineArray;
        static string? _Line;

        RfqUxService _RfqUxService;
        RfqModule.RfqModule.RfqModuleClient _GrpcClient;
        readonly Guid _TestUserId;
        readonly int _FastThreshold;
        readonly int _AcceptableThreshold;
        readonly int _SlowThreshold;

        public RfqUxServiceLiveTests()
        {
            _LineArray = Enumerable.Repeat("-", 240);
            _Line = string.Concat(_LineArray);

            _TestUserId = Guid.Parse(TimingTestMessages.DarranGuid);

            _FastThreshold = int.Parse(TimingTestMessages.FastThreshold, CultureInfo.InvariantCulture);
            _AcceptableThreshold = int.Parse(TimingTestMessages.AcceptableThreshold, CultureInfo.InvariantCulture);
            _SlowThreshold = int.Parse(TimingTestMessages.SlowThreshold, CultureInfo.InvariantCulture);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                // Create gRPC client pointing to the live service
                Grpc.Net.Client.GrpcChannel channel = Grpc.Net.Client.GrpcChannel.ForAddress(TimingTestMessages.GrpcServiceUrl);
                _GrpcClient = new RfqModule.RfqModule.RfqModuleClient(channel);
                _RfqUxService = new RfqUxService(_GrpcClient);

                Debug.WriteLine($"[SETUP] Connected to live gRPC service at {TimingTestMessages.GrpcServiceUrl}");
                Debug.WriteLine($"[SETUP] Test User ID: {_TestUserId}");
            }
            catch (Exception ex)
            {
                Assert.Inconclusive($"Failed to setup live gRPC connection: {ex.Message}");
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        [Test]
        [Category("Live")]
        [Category("Benchmark")]
        public async Task GetCustomersAsync_LiveService_BenchmarkWithSpecificUserId()
        {
            // Arrange
            string methodName = nameof(_RfqUxService.GetCustomersAsync);
            DateTime startTime = DateTime.UtcNow;

            string message = string.Format(CultureInfo.InvariantCulture,
                TimingTestMessages.TestStartMessage, methodName, startTime);
            Debug.WriteLine(message);
            Debug.WriteLine($"[LIVE-TEST] Using User ID: {_TestUserId}");

#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                // Act - Following the exact pattern from CreateRfq.razor OnInitializedAsync method
                Func<Guid, Task<List<RfqModule.CustomerGrpc>>> guidAsyncService = _RfqUxService.GetCustomersAsync;
                (long timing, int count, List<RfqModule.CustomerGrpc> customers) = await guidAsyncService.TimeAsyncGuidService(_TestUserId);

                // Output results - mimicking the Blazor component behavior
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.TestCompleteMessage, methodName, timing, count);
                Debug.WriteLine(message);
                Debug.WriteLine($"[LIVE-TEST] Customer load time: {timing}ms at {DateTime.UtcNow}");
                
                // Assess performance like the Blazor component would
                AssessPerformanceWithSnackbarLikeOutput(timing, count);
                
                // Detailed performance analysis
                AssessPerformance(methodName, timing);
                
                // Log first few customers (like the Blazor component displays them)
                LogCustomerDetails(customers);

                // Assertions
                Assert.That(customers, Is.Not.Null, "Customer list should not be null");
                EqualConstraint itIsEqual = Is.EqualTo(count);
                Assert.That(customers.Count, itIsEqual, "Customer count should match returned count");
                GreaterThanConstraint itIsGreaterThan = Is.GreaterThan(0);
                Assert.That(customers.Count, itIsGreaterThan, "Should return at least one customer for the test user");

                // Performance assertion - warn if too slow but don't fail the test
                if (_SlowThreshold <= timing)
                {
                    Assert.Warn($"Performance warning: Customer retrieval took {timing}ms, which exceeds the slow threshold of {_SlowThreshold}ms. " +
                              "This may indicate network latency or service performance issues.");
                }
                
                // Validate customer data structure
                foreach (RfqModule.CustomerGrpc? customer in customers)
                {
                    Assert.That(customer.Id, Is.Not.Null.And.Not.Empty, "Customer ID should not be null or empty");
                    Assert.That(customer.CustomerBusinessGroupName, Is.Not.Null, "Customer business group name should not be null");
                }
            }
            catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.Unavailable)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.ServiceUnavailableMessage, ex.Message);
                Assert.Inconclusive(message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception during live service test: {ex.Message}");
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        [Test]
        [Category("Live")]
        [Category("Performance")]
        [Repeat(3)]
        public async Task GetCustomersAsync_LiveService_ConsistencyCheck()
        {
            // Arrange
            string methodName = $"{nameof(_RfqUxService.GetCustomersAsync)}_ConsistencyRun_{TestContext.CurrentContext.CurrentRepeatCount + 1}";
            
            try
            {
                // Act
                Func<Guid, Task<List<RfqModule.CustomerGrpc>>> guidAsyncService = _RfqUxService.GetCustomersAsync;
                (long timing, int count, List<RfqModule.CustomerGrpc> customers) = await guidAsyncService.TimeAsyncGuidService(_TestUserId);

                // Output results for each run
                Debug.WriteLine($"[CONSISTENCY-RUN-{TestContext.CurrentContext.CurrentRepeatCount + 1}] " +
                                $"Retrieved {count} customers in {timing}ms");

                // Assertions for consistency
                Assert.That(customers, Is.Not.Null);
                EqualConstraint itIsEqual = Is.EqualTo(count);
                Assert.That(customers.Count, itIsEqual);
                GreaterThanConstraint itIsGreaterThan = Is.GreaterThan(0);
                Assert.That(customers.Count, itIsGreaterThan);

                // Track performance consistency across runs

                if (_SlowThreshold * 2 <= timing) // Allow for network variance
                {
                    Assert.Warn($"Performance variance detected in run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {timing}ms");
                }
            }
            catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.Unavailable)
            {
                Assert.Inconclusive($"Service unavailable in consistency run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Integration")]
        public async Task GetCustomersAsync_LiveService_DataValidation()
        {
            // Arrange & Act
            Func<Guid, Task<List<RfqModule.CustomerGrpc>>> guidAsyncService = _RfqUxService.GetCustomersAsync;
            (long timing, int count, List<RfqModule.CustomerGrpc> customers) = await guidAsyncService.TimeAsyncGuidService(_TestUserId);

            Debug.WriteLine($"[DATA-VALIDATION] Retrieved {count} customers for validation");

            // Detailed data validation
            Assert.That(customers, Is.Not.Null);
            GreaterThanConstraint itIsGreaterThan = Is.GreaterThan(0);
            Assert.That(customers.Count, itIsGreaterThan, "User should have at least one associated customer");

            // Validate each customer has required fields
            foreach (RfqModule.CustomerGrpc customer in customers)
            {
                Assert.That(customer.Id, Is.Not.Null.And.Not.Empty, 
                    $"Customer ID should not be null or empty for customer: {customer.CustomerBusinessGroupName}");
                
                // These can be null according to protobuf, but log if they are
                if (string.IsNullOrEmpty(customer.CustomerBusinessGroupName))
                {
                    Debug.WriteLine($"[DATA-WARNING] Customer {customer.Id} has null/empty CustomerBusinessGroupName");
                }
                
                if (string.IsNullOrEmpty(customer.CustomerBusinessGroupCode))
                {
                    Debug.WriteLine($"[DATA-WARNING] Customer {customer.Id} has null/empty CustomerBusinessGroupCode");
                }
            }

            // Check for duplicate customer IDs
            List<string> duplicateIds = customers.GroupBy(c => c.Id).Where(g => !(g.Count() <= 1)).Select(g => g.Key).ToList();

            // List<string> duplicateIds = customers.GroupBy(c => c.Id).Where(g => (g.Any())).Select(g => g.Key).ToList();

            Assert.That(duplicateIds, Is.Empty, $"Found duplicate customer IDs: {string.Join(", ", duplicateIds)}");

            Debug.WriteLine($"[DATA-VALIDATION] ✓ All {count} customers passed validation");
        }

        [Test]
        [Category("Live")]
        [Category("Integration")]
        [Category("Composition")]
        public async Task CompositionTest()
        {
            long timing = 0;
            int count = 0;
            Stopwatch sw = Stopwatch.StartNew();

            //GetCustomersAsync
            List<RfqModule.CustomerGrpc> customers = await _RfqUxService.GetCustomersAsync(_TestUserId);
            sw.Stop();
            timing = sw.ElapsedMilliseconds;
            count = customers.Count;

            Debug.WriteLine($"[COMPOSITION] GetCustomersAsync retrieved {count} customers in {timing}ms");
            WriteDividerLine();
            foreach (RfqModule.CustomerGrpc customer in customers)
            {
                Debug.WriteLine($"\t{customer.CustomerBusinessGroupName} ({customer.Id})");
            }

            // GetLocationsByCustomer
            customers = customers.Where(c => c.CustomerBusinessGroupName == "FORD").ToList();  // This is where the customerId would come from the UI
            foreach (RfqModule.CustomerGrpc customer in customers)
            {   
                // get locations
                sw.Restart();
                List<RfqModule.CustomerLocationGrpc> locations = await _RfqUxService.GetLocationsByCustomer(customer.Id);
                sw.Stop();
                timing = sw.ElapsedMilliseconds;
                count = locations.Count;

                Debug.WriteLine($"[COMPOSITION] GetLocationsByCustomer retrieved {count} locations for customer {customer.CustomerBusinessGroupName} in {timing}ms");
                //WriteDividerLine();
                //foreach (RfqModule.CustomerLocationGrpc location in locations)
                //{
                //    Debug.WriteLine($"\t- customerId {location.CustomerBusinessHierarchyGuid} customerLocationId {location.Id} {location.CustomerCode} ({location.CustomerName}) ");
                //}

                // GetCustomerProjectAssociations
                sw.Restart();
                List<CustomerProjectUx> customerProjectAssociations = await _RfqUxService.GetCustomerProjectAssociations();
                sw.Stop();
                timing = sw.ElapsedMilliseconds;
                count = customerProjectAssociations.Count;

                Debug.WriteLine($"[COMPOSITION] GetCustomerProjectAssociations retrieved {count} customer project associations in {timing}ms");
                //WriteDividerLine();
                //foreach (CustomerProjectUx association in customerProjectAssociations)
                //{
                //    Debug.WriteLine($"\t- customerLocationId {association.CustomerId} projectId {association.ProjectId}");
                //}

                // GetProjectsbyCustomerProjectAssociation
                sw.Restart();
                List<RfqModule.ProjectGrpc> projectsbyCustomerProjectAssociation = await _RfqUxService.GetProjectsbyCustomerProjectAssociation(customerProjectAssociations);
                sw.Stop();
                timing = sw.ElapsedMilliseconds;
                count = projectsbyCustomerProjectAssociation.Count;

                Debug.WriteLine($"[COMPOSITION] GetProjectsbyCustomerProjectAssociation retrieved {count} projects by customer-projects association in {timing}ms");
                //WriteDividerLine();
                //foreach (RfqModule.ProjectGrpc project in projectsbyCustomerProjectAssociation)
                //{
                //    Debug.WriteLine($"\t- projectId {project.Id} projectCode {project.ProjectCode} projectName {project.ProjectName}");
                //}

                // GetCustomerProjectUx
                sw.Restart();
                List<CustomerProjectUx> projects = await _RfqUxService.GetCustomerProjectUx(projects: projectsbyCustomerProjectAssociation,
                                                                                            customerLocations: locations,
                                                                                            customerProjects: customerProjectAssociations);
                sw.Stop();
                timing = sw.ElapsedMilliseconds;
                count = projects.Count;

                Debug.WriteLine($"[COMPOSITION] GetCustomerProjectUx retrieved {projects.Count} projects for select list for customer {customer.CustomerBusinessGroupName} in {timing}ms");
                WriteDividerLine();
                int pos = 1;
                foreach (CustomerProjectUx project in projects)
                {
                    Debug.WriteLine($"\t{pos,3}\t customerLocationId {project.CustomerId} customerName {project.CustomerName,32} - projectId {project.ProjectId} projectName {project.ProjectName,32}");
                    pos++;
                }
            }
        }

        #region Utils
        static void WriteDividerLine()
        {
            Debug.WriteLine($"+{_Line}+");
        }
        void AssessPerformanceWithSnackbarLikeOutput(long timing, int count)
        {
            // Mimic the Blazor component's snackbar logic
            if (timing < 500 )
            {
                Debug.WriteLine($"[SNACKBAR-SIMULATION] SUCCESS: Customer load time is ok ({timing}ms), loaded {count} customers"); 
            }
            else if (timing < 1000)
            {
                Debug.WriteLine($"[SNACKBAR-SIMULATION] WARNING: Customer load time is a bit slow ({timing}ms), loaded {count} customers");
            }
            else
            {
                Debug.WriteLine($"[SNACKBAR-SIMULATION] ERROR: Customer load time is high ({timing}ms), loaded {count} customers");
            }
        }

        void AssessPerformance(string methodName, long elapsedMs)
        {
            string message = "";
            if (elapsedMs < _FastThreshold)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentFast, methodName, elapsedMs, _FastThreshold);
                Debug.WriteLine(message);
            }
            else if (elapsedMs < _AcceptableThreshold)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentAcceptable, methodName, elapsedMs, _FastThreshold, _AcceptableThreshold);
                Debug.WriteLine(message);
            }
            else
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentSlow, methodName, elapsedMs, _AcceptableThreshold);
                Debug.WriteLine(message);
                
                if (_SlowThreshold <= elapsedMs)
                {
                    Debug.WriteLine($"[PERFORMANCE-WARNING] {methodName} took {elapsedMs}ms, exceeding threshold of {_SlowThreshold}ms");
                }
            }
        }

        static void LogCustomerDetails(List<RfqModule.CustomerGrpc> customers)
        {
            Debug.WriteLine($"[CUSTOMER-DETAILS] Retrieved {customers.Count} customers:");
            
            foreach (RfqModule.CustomerGrpc? customer in customers) // Show first 10 customers like the UI might
            {
                Debug.WriteLine($"  - ID: {customer.Id}");
                Debug.WriteLine($"    Name: {customer.CustomerBusinessGroupName ?? "N/A"}");
                Debug.WriteLine($"    Code: {customer.CustomerBusinessGroupCode ?? "N/A"}");
                Debug.WriteLine($"    Team: {customer.SEWSEBusinessTeam ?? "N/A"}");
                Debug.WriteLine($"    Active: {customer.IsActive ?? false}");
            }
        }
        #endregion
    }
}
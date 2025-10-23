using SalesSystem.Rfq.Extensions;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;
using SalesSystem.Rfq.Tests.Resources;
using System.Diagnostics;
using System.Globalization;
using Grpc.Core;
using Grpc.Net.Client;
using Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Constraints;
using static RfqModule.RfqModule;

namespace SalesSystem.Rfq.Tests
{
    [TestFixture]
    public class RfqUxServiceLiveTests
    {
        static IEnumerable<string>? _LineArray;
        static string? _Line;

        RfqUxClientService _RfqUxClientService;
        RfqModuleClient _GrpcClient;
        readonly Guid _TestUserId;
        readonly int _FastThreshold;
        readonly int _AcceptableThreshold;
        readonly int _SlowThreshold;

        ILogger<RfqUxClientService> _Logger;
        IHost _Host;
        IConfiguration _Configuration;

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
            try
            {
                // Set up configuration from appsettings.json
                string currentDirectory = Directory.GetCurrentDirectory();
                _Configuration = new ConfigurationBuilder()
                    .SetBasePath(currentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Create host with logging configuration from appsettings.json
                IConfigurationSection loggingSection = _Configuration.GetSection("Logging");
                _Host = Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration(config =>
                    {
                        config.AddConfiguration(_Configuration);
                    })
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddConfiguration(loggingSection);
                        logging.AddConsole();
                        logging.AddDebug();

                        // Add Seq logging if configured
                        IConfigurationSection seqSection = _Configuration.GetSection("Logging:Seq");
                        if (seqSection.Exists())
                        {
                            string? serverUrl = seqSection["ServerUrl"];
                            if (!string.IsNullOrEmpty(serverUrl))
                            {
                                _Logger?.GenericLogInformation($"Seq logging configured for: {serverUrl}");
                            }
                        }
                    })
                    .ConfigureServices(services =>
                    {
                        // Register additional services if needed
                        services.AddSingleton(_Configuration);
                    })
                    .Build();

                // Get logger from DI container
                _Logger = _Host.Services.GetRequiredService<ILogger<RfqUxClientService>>();

                // Log application information from configuration
                IConfigurationSection appSection = _Configuration.GetSection("Application");
                if (appSection.Exists())
                {
                    string appName = appSection["Name"] ?? "Unknown";
                    string appVersion = appSection["Version"] ?? "Unknown";
                    _Logger.GenericLogInformation($"Starting {appName} v{appVersion} tests");
                }

                // Create gRPC client pointing to the live service
                GrpcChannel channel = GrpcChannel.ForAddress(TimingTestMessages.GrpcServiceUrl);
                _GrpcClient = new RfqModuleClient(channel);

                if(_Logger == null)
                {
                    throw new InvalidOperationException("Failed to obtain logger for RfqUxClientService");
                }

                _RfqUxClientService = new RfqUxClientService(_GrpcClient, _Logger);

                _Logger.GenericLogInformation($"Connected to live gRPC service at {TimingTestMessages.GrpcServiceUrl}");
                _Logger.GenericLogInformation($"Test User ID: {_TestUserId}");

                Debug.WriteLine($"[SETUP] Connected to live gRPC service at {TimingTestMessages.GrpcServiceUrl}");
                Debug.WriteLine($"[SETUP] Test User ID: {_TestUserId}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                string message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.ServiceUnavailableMessage, ex.Message);
                _Logger?.GenericLogError("gRPC service unavailable during setup", ex);
                Assert.Inconclusive(message);
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error during test setup", ex);
                throw;
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                _Logger?.GenericLogInformation("Cleaning up test resources");
                _Host?.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                _Logger?.GenericLogError("Error during test cleanup", ex);
            }
        }

        [Test]
        [Category("Live")]
        [Category("Performance")]
        [Repeat(3)]
        public async Task GetCustomersAsync_LiveService_ConsistencyCheck()
        {
            // Arrange
            string methodName = $"{nameof(_RfqUxClientService.GetCustomersByUserIdAsync)}_ConsistencyRun_{TestContext.CurrentContext.CurrentRepeatCount + 1}";
            
            _Logger.GenericLogInformation($"Starting consistency check run {TestContext.CurrentContext.CurrentRepeatCount + 1}");
            
            try
            {
                // Act
                Func<Guid, Task<int>> guidAsyncService = _RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService(_TestUserId);

                // Output results for each run
                string logMessage = $"Consistency run {TestContext.CurrentContext.CurrentRepeatCount + 1}: Retrieved {count} customers in {timing}ms";
                _Logger.GenericLogInformation(logMessage);
                Debug.WriteLine($"[CONSISTENCY-RUN-{TestContext.CurrentContext.CurrentRepeatCount + 1}] " +
                                $"Retrieved {count} customers in {timing}ms");

                // Assertions for consistency
                Assert.That(_RfqUxClientService.Customers, Is.Not.Null);
                EqualConstraint itIsEqual = Is.EqualTo(count);
                Assert.That(_RfqUxClientService.Customers.Count, itIsEqual);
                GreaterThanConstraint itIsGreaterThan = Is.GreaterThan(0);
                Assert.That(_RfqUxClientService.Customers.Count, itIsGreaterThan);

                // Track performance consistency across runs
                if (_SlowThreshold * 2 <= timing) // Allow for network variance
                {
                    string warningMessage = $"Performance variance detected in run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {timing}ms";
                    _Logger.GenericLogInformation(warningMessage);
                    Assert.Warn(warningMessage);
                }

                _Logger.GenericLogInformation($"Consistency check run {TestContext.CurrentContext.CurrentRepeatCount + 1} completed successfully");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                string message = $"Service unavailable in consistency run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {ex.Message}";
                _Logger.GenericLogError(message, ex);
                Assert.Inconclusive(message);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error in consistency run {TestContext.CurrentContext.CurrentRepeatCount + 1}", ex);
                throw;
            }
        }

        [Test]
        [Category("Live")]
        [Category("Integration")]
        public async Task GetCustomersAsync_LiveService_DataValidation()
        {
            _Logger.GenericLogInformation("Starting data validation test");
            
            try
            {
                // Arrange & Act
                Func<Guid, Task<int>> guidAsyncService = _RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService(_TestUserId);

                _Logger.GenericLogInformation($"Data validation: Retrieved {count} customers in {timing}ms");
                Debug.WriteLine($"[DATA-VALIDATION] Retrieved {count} customers for validation");

                // Detailed data validation
                Assert.That(_RfqUxClientService.Customers, Is.Not.Null);
                GreaterThanConstraint itIsGreaterThan = Is.GreaterThan(0);
                Assert.That(_RfqUxClientService.Customers.Count, itIsGreaterThan, "User should have at least one associated customer");

                // Validate each customer has required fields
                foreach (RfqModule.CustomerGrpc customer in _RfqUxClientService.Customers)
                {
                    Assert.That(customer.Id, Is.Not.Null.And.Not.Empty, 
                        $"Customer ID should not be null or empty for customer: {customer.CustomerBusinessGroupName}");
                    
                    // These can be null according to protobuf, but log if they are
                    if (string.IsNullOrEmpty(customer.CustomerBusinessGroupName))
                    {
                        string warningMessage = $"Customer {customer.Id} has null/empty CustomerBusinessGroupName";
                        _Logger.GenericLogInformation(warningMessage);
                        Debug.WriteLine($"[DATA-WARNING] {warningMessage}");
                    }
                    
                    if (string.IsNullOrEmpty(customer.CustomerBusinessGroupCode))
                    {
                        string warningMessage = $"Customer {customer.Id} has null/empty CustomerBusinessGroupCode";
                        _Logger.GenericLogInformation(warningMessage);
                        Debug.WriteLine($"[DATA-WARNING] {warningMessage}");
                    }
                }

                // Check for duplicate customer IDs
                List<string> duplicateIds = _RfqUxClientService.Customers.GroupBy(c => c.Id).Where(g => !(g.Count() <= 1)).Select(g => g.Key).ToList();

                Assert.That(duplicateIds, Is.Empty, $"Found duplicate customer IDs: {string.Join(", ", duplicateIds)}");

                _Logger.GenericLogInformation($"Data validation completed successfully: All {count} customers passed validation");
                Debug.WriteLine($"[DATA-VALIDATION] ✓ All {count} customers passed validation");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during data validation test", ex);
                throw;
            }
        }

        [Test]
        [Category("Live")]
        [Category("Integration")]
        [Category("Composition")]
        public async Task CompositionTest()
        {
            _Logger.GenericLogInformation("Starting composition test");
            
            try
            {
                long timing = 0;
                Stopwatch sw = Stopwatch.StartNew();

                //GetCustomersAsync
                int count = await _RfqUxClientService.GetCustomersByUserIdAsync(_TestUserId);
                sw.Stop();
                timing = sw.ElapsedMilliseconds;
                count = _RfqUxClientService.Customers.Count;

                _Logger.GenericLogInformation($"Composition test - GetCustomersAsync: {count} customers in {timing}ms");
                Debug.WriteLine($"[COMPOSITION] GetCustomersAsync retrieved {count} customers in {timing}ms");
                WriteDividerLine();
                foreach (RfqModule.CustomerGrpc customer in _RfqUxClientService.Customers)
                {
                    Debug.WriteLine($"\t{customer.CustomerBusinessGroupName} ({customer.Id})");
                }

                // GetLocationsByCustomer
                List<RfqModule.CustomerGrpc> customers = _RfqUxClientService.Customers.Where(c => c.CustomerBusinessGroupName == "FORD").ToList();  // This is where the customerId would come from the UI
                foreach (RfqModule.CustomerGrpc customer in customers)
                {   
                    // GetCustomerProjectUx
                    sw.Restart();
                    int projectAssociationCount = await _RfqUxClientService.GetProjectAssociationsByCustomerIdAsync(customer.Id);
                    sw.Stop();
                    timing = sw.ElapsedMilliseconds;

                    _Logger.GenericLogInformation($"Composition test - GetProjectAssociationsByCustomerId: {projectAssociationCount} projects for {customer.CustomerBusinessGroupName} in {timing}ms");
                    Debug.WriteLine($"[COMPOSITION] GetProjectAssociationsByCustomerId retrieved {projectAssociationCount} projects for select list for customer {customer.CustomerBusinessGroupName} in {timing}ms");
                    WriteDividerLine();
                    int pos = 1;
                    foreach (CustomerProjectUx project in _RfqUxClientService.CustomerProjectAssociations)
                    {
                        Debug.WriteLine($"\t{pos,3}\t customerLocationId {project.CustomerId} customerName {project.CustomerName,32} - projectId {project.ProjectId} projectName {project.ProjectName,32}");
                        pos++;
                    }
                }

                _Logger.GenericLogInformation("Composition test completed successfully");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during composition test", ex);
                throw;
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
            string message;
            if (timing < 500 )
            {
                message = $"Customer load time is ok ({timing}ms), loaded {count} customers";
                _Logger.GenericLogInformation($"PERFORMANCE-OK: {message}");
                Debug.WriteLine($"[SNACKBAR-SIMULATION] SUCCESS: {message}"); 
            }
            else if (timing < 1000)
            {
                message = $"Customer load time is a bit slow ({timing}ms), loaded {count} customers";
                _Logger.GenericLogInformation($"PERFORMANCE-WARNING: {message}");
                Debug.WriteLine($"[SNACKBAR-SIMULATION] WARNING: {message}");
            }
            else
            {
                message = $"Customer load time is high ({timing}ms), loaded {count} customers";
                _Logger.GenericLogInformation($"PERFORMANCE-ERROR: {message}");
                Debug.WriteLine($"[SNACKBAR-SIMULATION] ERROR: {message}");
            }
        }

        void AssessPerformance(string methodName, long elapsedMs)
        {
            string message = "";
            if (elapsedMs < _FastThreshold)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentFast, methodName, elapsedMs, _FastThreshold);
                _Logger.GenericLogInformation($"FAST-PERFORMANCE: {message}");
                Debug.WriteLine(message);
            }
            else if (elapsedMs < _AcceptableThreshold)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentAcceptable, methodName, elapsedMs, _FastThreshold, _AcceptableThreshold);
                _Logger.GenericLogInformation($"ACCEPTABLE-PERFORMANCE: {message}");
                Debug.WriteLine(message);
            }
            else
            {
                message = string.Format(CultureInfo.InvariantCulture,
                    TimingTestMessages.PerformanceAssessmentSlow, methodName, elapsedMs, _AcceptableThreshold);
                _Logger.GenericLogInformation($"SLOW-PERFORMANCE: {message}");
                Debug.WriteLine(message);
                
                if (_SlowThreshold <= elapsedMs)
                {
                    string warningMessage = $"{methodName} took {elapsedMs}ms, exceeding threshold of {_SlowThreshold}ms";
                    _Logger.GenericLogInformation($"PERFORMANCE-THRESHOLD-EXCEEDED: {warningMessage}");
                    Debug.WriteLine($"[PERFORMANCE-WARNING] {warningMessage}");
                }
            }
        }

        void LogCustomerDetails(IReadOnlyCollection<RfqModule.CustomerGrpc> customers)
        {
            _Logger.GenericLogInformation($"Customer details: Retrieved {customers.Count} customers");
            Debug.WriteLine($"[CUSTOMER-DETAILS] Retrieved {customers.Count} customers:");
            
            foreach (RfqModule.CustomerGrpc? customer in customers) // Show first 10 customers like the UI might
            {
                string customerInfo = $"Customer - ID: {customer.Id}, Name: {customer.CustomerBusinessGroupName ?? "N/A"}, Code: {customer.CustomerBusinessGroupCode ?? "N/A"}, Team: {customer.SEWSEBusinessTeam ?? "N/A"}, Active: {customer.IsActive ?? false}";
                _Logger.GenericLogInformation(customerInfo);
                
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
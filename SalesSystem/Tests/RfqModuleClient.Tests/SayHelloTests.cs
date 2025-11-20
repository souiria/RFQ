using Grpc.Core;
using Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RfqModule;
using RfqModuleClient.Tests.Services;

namespace RfqModuleClient.Tests
{
    [TestFixture]
    public class SayHelloTests
    {
        RfqModuleClientService _RfqModuleClientService;
        ILogger<SayHelloTests> _Logger;
        IHost _Host;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _Host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddSeq();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();

            IConfiguration configuration = _Host.Services.GetRequiredService<IConfiguration>();
            _Logger = _Host.Services.GetRequiredService<ILogger<SayHelloTests>>();
            ILogger<RfqModuleClientService> rfqGrpcClientServiceLogger = _Host.Services.GetRequiredService<ILogger<RfqModuleClientService>>();
            _RfqModuleClientService = new RfqModuleClientService(configuration, rfqGrpcClientServiceLogger);

            _Logger.GenericLogInformation("SayHelloTests setup completed");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _RfqModuleClientService?.Dispose();
            _Host?.Dispose();
            _Logger?.GenericLogInformation("SayHelloTests cleanup completed");
        }

        [Test]
        [Category("SayHello")]
        [Category("Basic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_WithValidName_ReturnsExpectedMessage()
        {
            // Arrange
            string testName = "TestUser";
            string expectedMessage = $"Hello {testName}";

            try
            {
                _Logger.GenericLogInformation($"Starting SayHello test with name: {testName}");

                // Act
                HelloReply response = await _RfqModuleClientService.SayHelloAsync(testName);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Message, Is.EqualTo(expectedMessage));

                _Logger.GenericLogInformation($"✓ SayHello test passed: {response.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during SayHello test", ex);
                Assert.Inconclusive($"gRPC service unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error during SayHello test with name: {testName}", ex);
                throw;
            }
        }

        [Test]
        [Category("SayHello")]
        [Category("Basic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_WithEmptyName_ReturnsExpectedMessage()
        {
            // Arrange
            string testName = "";
            string expectedMessage = "Hello ";

            try
            {
                _Logger.GenericLogInformation("Starting SayHello test with empty name");

                // Act
                HelloReply response = await _RfqModuleClientService.SayHelloAsync(testName);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Message, Is.EqualTo(expectedMessage));

                _Logger.GenericLogInformation($"✓ SayHello with empty name test passed: {response.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during SayHello empty name test", ex);
                Assert.Inconclusive($"gRPC service unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during SayHello test with empty name", ex);
                throw;
            }
        }

        [Test]
        [Category("SayHello")]
        [Category("Performance")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_PerformanceTest_RespondsQuickly()
        {
            // Arrange
            string testName = "PerformanceTest";
            var maxAllowedTime = TimeSpan.FromSeconds(5);

            try
            {
                _Logger.GenericLogInformation($"Starting SayHello performance test with max allowed time: {maxAllowedTime.TotalSeconds}s");

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                // Act
                HelloReply response = await _RfqModuleClientService.SayHelloAsync(testName);
                stopwatch.Stop();

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(stopwatch.Elapsed, Is.LessThan(maxAllowedTime),
                    $"SayHello should respond within {maxAllowedTime.TotalSeconds} seconds");

                _Logger.GenericLogInformation($"✓ SayHello performance test passed: {stopwatch.ElapsedMilliseconds}ms");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during SayHello performance test", ex);
                Assert.Inconclusive($"gRPC service unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during SayHello performance test", ex);
                throw;
            }
        }

        [Test]
        [Category("SayHello")]
        [Category("Stress")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_MultipleRequests_HandlesLoad()
        {
            // Arrange
            const int requestCount = 10;
            List<Task<HelloReply>> tasks = new List<Task<HelloReply>>();

            try
            {
                _Logger.GenericLogInformation($"Starting SayHello stress test with {requestCount} concurrent requests");

                // Act
                for (int i = 0; i < requestCount; i++)
                {
                    string testName = $"User{i}";
                    tasks.Add(_RfqModuleClientService.SayHelloAsync(testName));
                }

                HelloReply[] responses = await Task.WhenAll(tasks);

                // Assert
                Assert.That(responses.Length, Is.EqualTo(requestCount));

                for (int i = 0; i < requestCount; i++)
                {
                    string expectedMessage = $"Hello User{i}";
                    Assert.That(responses[i].Message, Is.EqualTo(expectedMessage));
                }

                _Logger.GenericLogInformation($"✓ SayHello stress test passed: {requestCount} concurrent requests completed successfully");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during SayHello stress test", ex);
                Assert.Inconclusive($"gRPC service unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error during SayHello stress test with {requestCount} requests", ex);
                throw;
            }
        }

        [Test]
        [Category("SayHello")]
        [Category("Validation")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_WithSpecialCharacters_HandlesCorrectly()
        {
            // Arrange
            string testName = "Test@User#123!";
            string expectedMessage = $"Hello {testName}";

            try
            {
                _Logger.GenericLogInformation($"Starting SayHello test with special characters: {testName}");

                // Act
                HelloReply response = await _RfqModuleClientService.SayHelloAsync(testName);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Message, Is.EqualTo(expectedMessage));

                _Logger.GenericLogInformation($"✓ SayHello with special characters test passed: {response.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during SayHello special characters test", ex);
                Assert.Inconclusive($"gRPC service unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error during SayHello test with special characters: {testName}", ex);
                throw;
            }
        }
    }
}
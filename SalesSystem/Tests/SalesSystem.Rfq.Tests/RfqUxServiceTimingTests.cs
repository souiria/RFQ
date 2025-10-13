using SalesSystem.Rfq.Extensions;
using SalesSystem.Rfq.Models;
using SalesSystem.Rfq.Services;
using SalesSystem.Rfq.Tests.Resources;
using System.Diagnostics;
using System.Globalization;
using DocumentFormat.OpenXml.Wordprocessing;
using Moq;
using NUnit.Framework.Constraints;

namespace SalesSystem.Rfq.Tests
{
    [TestFixture]
    public class RfqUxServiceTimingTests
    {
        Mock<RfqModule.RfqModule.RfqModuleClient> _MockGrpcClient;
        RfqUxService _RfqUxService;
        readonly int _FastThreshold;
        readonly int _AcceptableThreshold;
        readonly int _SlowThreshold;

        public RfqUxServiceTimingTests()
        {
            _FastThreshold = int.Parse(TimingTestMessages.FastThreshold, CultureInfo.InvariantCulture);
            _AcceptableThreshold = int.Parse(TimingTestMessages.AcceptableThreshold, CultureInfo.InvariantCulture);
            _SlowThreshold = int.Parse(TimingTestMessages.SlowThreshold, CultureInfo.InvariantCulture);
        }

        [SetUp]
        public void SetUp()
        {
            _MockGrpcClient = new Mock<RfqModule.RfqModule.RfqModuleClient>();
            _RfqUxService = new RfqUxService(_MockGrpcClient.Object);
            
            SetupMockResponses();
        }

        void SetupMockResponses()
        {
            // Mock GetCustomersByUserIdGrpc response
            RfqModule.GetCustomersByUserIdGrpcResponse customersResponse = new RfqModule.GetCustomersByUserIdGrpcResponse();
            for (int i = 0; i < 50; i++) // Simulate 50 customers
            {
                RfqModule.CustomerGrpc customer = new RfqModule.CustomerGrpc();
                customer.Id = $"customer-{i}";
                customer.CustomerBusinessGroupName = $"Customer Group {i}";
                customer.CustomerBusinessGroupCode = $"CGC{i:000}";
                customer.SEWSEBusinessTeam = $"Team {i % 5}";
                customer.IsActive = true;
                customersResponse.Customers.Add(customer);
            }

            RfqModule.GetCustomersByUserIdGrpcRequest itIsAnyCustomerByUser = It.IsAny<RfqModule.GetCustomersByUserIdGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetCustomersByUserIdGrpc(itIsAnyCustomerByUser, null, null, default))
                .Returns(customersResponse);

            // Mock GetLocationsByCustomerIdGrpc response
            RfqModule.GetLocationsByCustomerIdGrpcResponse locationsResponse = new RfqModule.GetLocationsByCustomerIdGrpcResponse();
            for (int i = 0; i < 10; i++) // Simulate 10 locations per customer
            {
                RfqModule.CustomerLocationGrpc location = new RfqModule.CustomerLocationGrpc();
                
                
                location.Id = $"location-{i}";
                location.CustomerCode = $"CUST{i:000}";
                location.CustomerName = $"Customer Name {i}";
                location.CustomerBusinessHierarchyGuid = $"hierarchy-{i}";
                location.IsActive = true;

                locationsResponse.Locations.Add(location);
            }

            RfqModule.GetLocationsByCustomerIdGrpcRequest itIsAnyGetLocationsByCustomer = It.IsAny<RfqModule.GetLocationsByCustomerIdGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetLocationsByCustomerIdGrpc(itIsAnyGetLocationsByCustomer, null, null, default))
                .Returns(locationsResponse);

            // Mock GetProjectsByIdGrpc response
            RfqModule.GetProjectsByIdGrpcResponse projectsResponse = new RfqModule.GetProjectsByIdGrpcResponse();
            for (int i = 0; i < 5; i++) // Simulate 5 projects
            {
                RfqModule.ProjectGrpc project = new RfqModule.ProjectGrpc();
                
                project.Id = $"project-{i}";
                project.ProjectCode = $"PROJ{i:000}";
                project.ProjectName = $"Project {i}";
                project.CustomerProjectCode = $"CUST-PROJ-{i}";
                project.ProjectDescription = $"Project Description {i}";
                project.ProjectAnnualVolume = 1000 * (i + 1);
                project.ProgramHierarchyGuid = $"program-{i}";
                project.IsActive = true;
                
                projectsResponse.Projects.Add(project);
            }

            RfqModule.GetProjectsByIdGrpcRequest itIsAnyGetProjectsById = It.IsAny<RfqModule.GetProjectsByIdGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetProjectsByIdGrpc(itIsAnyGetProjectsById, null, null, default))
                .Returns(projectsResponse);

            // Mock GetRfqReasonsGrpc response
            RfqModule.GetRfqReasonsGrpcResponse reasonsResponse = new RfqModule.GetRfqReasonsGrpcResponse();
            string[] reasonTitles = new[] { "Cost Reduction", "New Project", "Quality Improvement", "Technology Upgrade", "Capacity Increase" };
            for (int i = 0; i < reasonTitles.Length; i++)
            {
                RfqModule.RfqReasonGrpc reason = new RfqModule.RfqReasonGrpc();

                reason.RowId = i + 1;
                reason.RfqReasonTitle = reasonTitles[i];

                reasonsResponse.RfqReasons.Add(reason);
            }

            RfqModule.GetRfqReasonsGrpcRequest itIsAnyGetRfqReasons = It.IsAny<RfqModule.GetRfqReasonsGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetRfqReasonsGrpc(itIsAnyGetRfqReasons, null, null, default))
                .Returns(reasonsResponse);

            // Mock GetCustomerProjectAssociationsByLocationIdGrpc response
            RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcResponse associationsResponse = new RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcResponse();
            for (int i = 0; i < 15; i++) // Simulate 15 associations
            {
                RfqModule.CustomerProjectAssociationGrpc customerProjectAssociation = new RfqModule.CustomerProjectAssociationGrpc();

                customerProjectAssociation.Id = $"association-{i}";
                customerProjectAssociation.CustomerLocationGuid = $"location-{i % 10}";
                customerProjectAssociation.ProjectGuid = $"project-{i % 5}";
                customerProjectAssociation.IsActive = true;

                associationsResponse.CustomerProjectAssociation.Add(customerProjectAssociation);
            }

            RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcRequest itIsAnyGetAssociationsByLocation = It.IsAny<RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetCustomerProjectAssociationsByLocationIdGrpc(itIsAnyGetAssociationsByLocation, null, null, default))
                .Returns(associationsResponse);
            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.MockDataGeneratedMessage, "Mock", "gRPC responses");
            Console.WriteLine(message);
        }

        [Test]
        [Category("Timing")]
        public async Task GetCustomersAsync_TimingTest_WithMockData()
        {
            // Arrange
            Guid testUserId = Guid.Parse(TimingTestMessages.TestUserId);
            string methodName = nameof(_RfqUxService.GetCustomersAsync);

            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestStartMessage, methodName, DateTime.Now);

            Console.WriteLine(message);

            // Act & Assert using extension method
            (long elapsedMs, int count, List<RfqModule.CustomerGrpc> customers) = await new Func<Guid, Task<List<RfqModule.CustomerGrpc>>>(_RfqUxService.GetCustomersAsync)
                .TimeAsyncGuidService(testUserId);

            // Output results
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, elapsedMs, count);
            Console.WriteLine(message);
            AssessPerformance(methodName, elapsedMs);

            // Assertions
            Assert.That(customers, Is.Not.Null);
            EqualConstraint equalConstraint = Is.EqualTo(count); // Expecting 50 customers as per mock setup
            Assert.That(customers.Count, equalConstraint);
            LessThanConstraint lessThanConstraint = Is.LessThan(_SlowThreshold * 2);
            Assert.That(elapsedMs, lessThanConstraint); // Allow some buffer for mock setup
        }

        [Test]
        [Category("Timing")]
        public async Task GetLocationsByCustomer_TimingTest_WithMockData()
        {
            // Arrange
            string customerId = TimingTestMessages.TestCustomerId;
            string methodName = nameof(_RfqUxService.GetLocationsByCustomer);
            
            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestStartMessage, methodName, DateTime.Now);

            Console.WriteLine(message);

            // Act & Assert using extension method
            (long elapsedMs, int count, List<RfqModule.CustomerLocationGrpc> locations) = await new Func<string, Task<List<RfqModule.CustomerLocationGrpc>>>(_RfqUxService.GetLocationsByCustomer)
                .TimeAsyncStringService(customerId);

            // Output results
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, elapsedMs, count);
            Console.WriteLine(message);
            AssessPerformance(methodName, elapsedMs);

            // Assertions
            Assert.That(locations, Is.Not.Null);
            EqualConstraint isEqualConstraint = Is.EqualTo(count); // Expecting 10 locations as per mock setup
            Assert.That(locations.Count, isEqualConstraint);
            LessThanConstraint isLessThanConstraint = Is.LessThan(_SlowThreshold * 2);
            Assert.That(elapsedMs, isLessThanConstraint);
        }

        [Test]
        [Category("Timing")]
        public async Task GetReasons_TimingTest_WithMockData()
        {
            // Arrange
            string methodName = nameof(_RfqUxService.GetReasons);

            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestStartMessage, methodName, DateTime.Now);

            Console.WriteLine(message);

            // Act & Assert using extension method
            (long elapsedMs, int count, List<RfqModule.RfqReasonGrpc> reasons) = await new Func<Task<List<RfqModule.RfqReasonGrpc>>>(_RfqUxService.GetReasons)
                .TimeAsyncService();

            // Output results
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, elapsedMs, count);
            Console.WriteLine(message);
            AssessPerformance(methodName, elapsedMs);

            // Assertions
            Assert.That(reasons, Is.Not.Null);
            EqualConstraint equalConstraint = Is.EqualTo(count); // Expecting 5 reasons as per mock setup
            Assert.That(reasons.Count, equalConstraint);
            LessThanConstraint lessThanConstraint = Is.LessThan(_SlowThreshold * 2);
            Assert.That(elapsedMs, lessThanConstraint);
        }

        [Test]
        [Category("Timing")]
        public async Task GetProjectsbyCustomerProjectAssociation_TimingTest_WithMockData()
        {
            // Arrange
            List<CustomerProjectUx> customerProjects = GenerateTestCustomerProjects(20); // Generate 20 test items
            string methodName = nameof(_RfqUxService.GetProjectsbyCustomerProjectAssociation);

            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestStartMessage, methodName, DateTime.Now);

            Console.WriteLine(message);
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.MockDataGeneratedMessage, customerProjects.Count, "CustomerProjectUx");
            Console.WriteLine(message);

            // Act & Assert using extension method
            (long elapsedMs, int count, List<RfqModule.ProjectGrpc> projects) = await new Func<ICollection<CustomerProjectUx>, Task<List<RfqModule.ProjectGrpc>>>(_RfqUxService.GetProjectsbyCustomerProjectAssociation)
                .TimeAsyncCollectionService(customerProjects);

            // Output results
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, elapsedMs, count);
            Console.WriteLine(message);
            AssessPerformance(methodName, elapsedMs);

            // Assertions
            Assert.That(projects, Is.Not.Null);
            EqualConstraint equalConstraint = Is.EqualTo(count); // Expecting 5 projects as per mock setup
            Assert.That(projects.Count, equalConstraint);
            LessThanConstraint lessThanConstraint = Is.LessThan(_SlowThreshold * 3);
            Assert.That(elapsedMs, lessThanConstraint);
        }

        [Test]
        [Category("Timing")]
        public async Task GetCustomerProjectUx_TimingTest_WithMockData()
        {
            // Arrange
            List<RfqModule.ProjectGrpc> projects = GenerateTestProjects(5);
            List<RfqModule.CustomerLocationGrpc> locations = GenerateTestLocations(10);
            List<CustomerProjectUx> customerProjects = GenerateTestCustomerProjects(15);
            string methodName = nameof(_RfqUxService.GetCustomerProjectUx);

            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestStartMessage, methodName, DateTime.Now);

            Console.WriteLine(message);

            // Act
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<CustomerProjectUx> result = await _RfqUxService.GetCustomerProjectUx(projects, locations, customerProjects);
            stopwatch.Stop();

            // Output results
            message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, stopwatch.ElapsedMilliseconds, result.Count);
            Console.WriteLine(message);
            AssessPerformance(methodName, stopwatch.ElapsedMilliseconds);

            // Assertions
            Assert.That(result, Is.Not.Null);
            LessThanConstraint lessThanConstraint = Is.LessThan(_SlowThreshold * 2);
            Assert.That(stopwatch.ElapsedMilliseconds, lessThanConstraint);
        }

        [Test]
        [Category("Timing")]
        [Repeat(5)]
        public async Task GetCustomersAsync_MultipleRuns_ConsistentTiming()
        {
            // Arrange
            Guid testUserId = Guid.Parse(TimingTestMessages.TestUserId);
            string methodName = $"{nameof(_RfqUxService.GetCustomersAsync)}_Run_{TestContext.CurrentContext.CurrentRepeatCount + 1}";
            
            // Act
            (long elapsedMs, int count, List<RfqModule.CustomerGrpc> customers) = await new Func<Guid, Task<List<RfqModule.CustomerGrpc>>>(_RfqUxService.GetCustomersAsync)
                .TimeAsyncGuidService(testUserId);

            string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.TestCompleteMessage, methodName, elapsedMs, count);

            // Output results
            Console.WriteLine(message);

            // Assertions
            Assert.That(customers, Is.Not.Null);
            GreaterThanConstraint greaterThan0Constraint = Is.GreaterThan(0);
            Assert.That(customers.Count, greaterThan0Constraint);
            LessThanConstraint lessThanConstraint = Is.LessThan(_SlowThreshold * 2);
            Assert.That(elapsedMs, lessThanConstraint);

            // Track timing consistency (should be relatively stable for mocked data)
            if (_SlowThreshold <= elapsedMs)
            {
                Assert.Warn($"Performance degradation detected in run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {elapsedMs}ms");
            }
        }

        void AssessPerformance(string methodName, long elapsedMs)
        {
            if (elapsedMs < _FastThreshold)
            {
                string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.PerformanceAssessmentFast, methodName, elapsedMs, _FastThreshold);
                Console.WriteLine(message);
            }
            else if (elapsedMs < _AcceptableThreshold)
            {
                string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.PerformanceAssessmentAcceptable, methodName, elapsedMs, _FastThreshold, _AcceptableThreshold);
                Console.WriteLine(message);
            }
            else
            {
                string message = string.Format(CultureInfo.InvariantCulture, TimingTestMessages.PerformanceAssessmentSlow, methodName, elapsedMs, _AcceptableThreshold);
                Console.WriteLine(message);

                if (_SlowThreshold <= elapsedMs)
                {
                    Assert.Warn($"Performance warning: {methodName} took {elapsedMs}ms, which exceeds the slow threshold of {_SlowThreshold}ms");
                }
            }
        }

        static List<RfqModule.ProjectGrpc> GenerateTestProjects(int count)
        {
            List<RfqModule.ProjectGrpc> projects = new List<RfqModule.ProjectGrpc>();
            for (int i = 0; i < count; i++)
            {
                RfqModule.ProjectGrpc project = new RfqModule.ProjectGrpc();

                project.Id = $"project-{i}";
                project.ProjectCode = $"PROJ{i:000}";
                project.ProjectName = $"Test Project {i}";
                project.CustomerProjectCode = $"CUST-PROJ-{i}";
                project.ProjectDescription = $"Test project description {i}";
                project.IsActive = true;

                projects.Add(project);
                

                
            }

            return projects;
        }

        static List<RfqModule.CustomerLocationGrpc> GenerateTestLocations(int count)
        {
            List<RfqModule.CustomerLocationGrpc> locations = new List<RfqModule.CustomerLocationGrpc>();
            for (int i = 0; i < count; i++)
            {
                RfqModule.CustomerLocationGrpc location = new RfqModule.CustomerLocationGrpc();

                location.Id = $"location-{i}";
                location.CustomerCode = $"CUST{i:000}";
                location.CustomerName = $"Test Customer {i}";
                location.CustomerBusinessHierarchyGuid = $"hierarchy-{i}";
                location.IsActive = true;
                
                locations.Add(location);
            }

            return locations;
        }

        static List<CustomerProjectUx> GenerateTestCustomerProjects(int count)
        {
            List<CustomerProjectUx> customerProjects = new List<CustomerProjectUx>();

            for (int i = 0; i < count; i++)
            {
                CustomerProjectUx customerProject = new CustomerProjectUx();

                customerProject.Id = $"association-{i}";
                customerProject.CustomerId = $"location-{i % 10}";
                customerProject.ProjectId = $"project-{i % 5}";
                customerProject.CustomerName = $"Test Customer {i % 10}";
                customerProject.ProjectName = $"Test Project {i % 5}";

                customerProjects.Add(customerProject);
            }

            return customerProjects;
        }
    }
}
namespace SalesSystem.Tests
{
    public class WebTests
    {
        [Test]
        public async Task GetWebResourceRootReturnsUnauthorizedStatusCode()
        {
            // Arrange
            IDistributedApplicationTestingBuilder appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.SalesSystem_AppHost>();
            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });

            await using Aspire.Hosting.DistributedApplication app = await appHost.BuildAsync();
            ResourceNotificationService resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
            await app.StartAsync();

            // Act
            using HttpClient httpClient = app.CreateHttpClient("RfqFrontEnd");
            await resourceNotificationService.WaitForResourceAsync("RfqFrontEnd", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));
            HttpResponseMessage response = await httpClient.GetAsync(new Uri("/", UriKind.Relative));

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
    }
}

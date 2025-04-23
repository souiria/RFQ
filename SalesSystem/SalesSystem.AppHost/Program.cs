class Program
{
    static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<ProjectResource> apiService = builder.AddProject<Projects.SalesSystem_ApiService>("apiservice");

        IResourceBuilder<ProjectResource> rfqManager = builder.AddProject<Projects.RfqManager>("RfqManager");

        builder.AddProject<Projects.SalesSystem_Rfq>("RfqFrontEnd")
            .WithExternalHttpEndpoints()
            .WithReference(apiService)
            .WaitFor(apiService);

        builder.Build().Run();
    }
}
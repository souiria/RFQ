class Program
{
    static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<ProjectResource> mastersAccessService = builder.AddProject<Projects.Master>("master-access-service");

        IResourceBuilder<ProjectResource> emacsAccessService = builder.AddProject<Projects.Emacs>("emacs-access-service");

        IResourceBuilder<ProjectResource> nPRAccessService = builder.AddProject<Projects.NPR>("npr-access-service");

        IResourceBuilder<ProjectResource> cPDAccessService = builder.AddProject<Projects.CPD>("cpd-access-service");

        IResourceBuilder<ProjectResource> ediAccessService = builder.AddProject<Projects.EDI>("edi-access-service");

        IResourceBuilder<ProjectResource> apiService = builder.AddProject<Projects.SalesSystem_ApiService>("api-service");

        IResourceBuilder<ProjectResource> rfqManager = builder.AddProject<Projects.RfqModule>("rfq-module-service");

        IResourceBuilder<ProjectResource> cdbManager = builder.AddProject<Projects.CDb>("cdb-module-service");

        IResourceBuilder<ProjectResource> sfsManager = builder.AddProject<Projects.SFS>("sfs-module-service");
        builder.AddProject<Projects.SalesSystem_Rfq>("RfqFrontEnd");
            //.WithExternalHttpEndpoints()
            //.WithReference(apiService)
            //.WaitFor(apiService);

        builder.Build().Run();
    }
}
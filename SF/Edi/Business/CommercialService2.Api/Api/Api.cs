namespace CommercialService2.Api;

/// <summary>
/// The FabricRuntime creates an instance of this class for each service type instance.
/// </summary>
internal sealed class Api : StatelessService
{
    public Api(StatelessServiceContext context) : base(context)
    { }
    
    /// <summary>
    /// Optional override to create listeners (like tcp, http) for this service instance.
    /// </summary>
    /// <returns>The collection of listeners.</returns>
    protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
    {
        return new ServiceInstanceListener[]
        {
            new ServiceInstanceListener(serviceContext =>
                new KestrelCommunicationListener(serviceContext, "SecureServiceEndpoint", (url, listener) =>
                {
                    var builder = WebApplication.CreateBuilder();
                    builder.Services.AddSingleton<StatelessServiceContext>(serviceContext);
                    builder.WebHost
                        .UseKestrel(opt =>
                        {
                            int port = serviceContext.CodePackageActivationContext.GetEndpoint("SecureServiceEndpoint")
                                .Port;
                            opt.Listen(IPAddress.IPv6Any, port, listenOptions =>
                            {
                                listenOptions.UseHttps(FindMatchingCertificateBySubject("*.sews-e.com"));
                            });
                        })
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                        .UseUrls(url);

                    var aiOptions = new ApplicationInsightsServiceOptions
                    {
                        EnableAdaptiveSampling = false,
                        EnableQuickPulseMetricStream = false,
                        ConnectionString = Environment.GetEnvironmentVariable("APPINSIGHTS_CONNECTION")
                    };

                    builder.Services.AddSingleton<ITelemetryInitializer>((serviceProvider) =>
                        FabricTelemetryInitializerExtension.CreateFabricTelemetryInitializer(
                            serviceProvider.GetService<ServiceContext>()));
                    builder.Services.AddSingleton<ITelemetryInitializer>(
                        new CloudRoleNameTelemetryInitializer("CommercialService2.Api"));
                    builder.Services.AddApplicationInsightsTelemetry(aiOptions);

                    // fetch other builder class
                    
                    return CommercialService2HostBuilder.CreateApp(builder, serviceContext, url);
                }), name: "SecureListener")
        };
    }

    /// <summary>
    /// Finds the ASP .NET Core HTTPS development certificate in development environment. Update this method to use the appropriate certificate for production environment.
    /// </summary>
    /// <returns>Returns the ASP .NET Core HTTPS development certificate</returns>
    private static X509Certificate2 GetCertificateFromStore()
    {
        var aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (string.Equals(aspNetCoreEnvironment, "Development", StringComparison.OrdinalIgnoreCase))
        {
            const string aspNetHttpsOid = "1.3.6.1.4.1.311.84.1.1";
            const string CNName = "CN=localhost";
            using X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates;
            var currentCerts = certCollection.Find(X509FindType.FindByExtension, aspNetHttpsOid, true);
            currentCerts = currentCerts.Find(X509FindType.FindByIssuerDistinguishedName, CNName, true);
            return currentCerts.Count == 0 ? null : currentCerts[0];
        }
        else
        {
            throw new NotImplementedException(
                "GetCertificateFromStore should be updated to retrieve the certificate for non Development environment");
        }
    }

    private X509Certificate2 FindMatchingCertificateBySubject(string subjectCommonName)
    {
        using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
        var certCollection = store.Certificates;
        var matchingCerts = new X509Certificate2Collection();

        foreach (var enumeratedCert in certCollection.Where(enumeratedCert => StringComparer.OrdinalIgnoreCase.Equals(subjectCommonName, enumeratedCert.GetNameInfo(X509NameType.SimpleName, forIssuer: false))
                                                                              && DateTime.Now < enumeratedCert.NotAfter
                                                                              && DateTime.Now >= enumeratedCert.NotBefore))
        {
            matchingCerts.Add(enumeratedCert);
        }

        if (matchingCerts.Count == 0)
        {
            throw new Exception($"Could not find a match for a certificate with subject 'CN={subjectCommonName}'.");
        }

        return matchingCerts[0];
    }
}

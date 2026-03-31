using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SF.Access.Rfqs
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    sealed class Rfqs : StatelessService
    {
        public Rfqs(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0300:Simplify collection initialization", Justification = "Service Fabric Boilerplate")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "Service Fabric Boilerplate")]
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource._Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        WebApplicationBuilder builder = WebApplication.CreateBuilder();

                        builder.Services.AddSingleton(serviceContext);
                      builder.WebHost
                                .UseKestrel(opt =>
                                {
                                    int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;

                                    opt.Listen(IPAddress.Any, port, listenOptions =>
                                    {
                                        string certPath = Path.Combine(
                                            serviceContext.CodePackageActivationContext
                                                .GetDataPackageObject("Certificates").Path,
                                            "grpc-test.pfx");

                                        X509Certificate2 cert = X509CertificateLoader.LoadPkcs12FromFile(
                                            certPath,
                                            "123456",
                                            X509KeyStorageFlags.MachineKeySet |
                                            X509KeyStorageFlags.PersistKeySet |
                                            X509KeyStorageFlags.Exportable);

                                        listenOptions.UseHttps(cert);
                                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                    });
                                })
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                               .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.UseUniqueServiceUrl);

                            string pathBase = "/"; // default root

                            int schemeSep = url.IndexOf("://", StringComparison.Ordinal);

if (schemeSep < 0)
{
    return Rfq.HostBuilder.CreateApp(builder, pathBase);
}

// Find the next slash AFTER scheme (after host:port)
int nextSlash = url.IndexOf('/', schemeSep + 3);

// If no slash, skip parsing
if (nextSlash < 0)
{
    return Rfq.HostBuilder.CreateApp(builder, pathBase);
}

// Extract pathBase
pathBase = url.Substring(nextSlash);

// Pass to Access HostBuilder
return Rfq.HostBuilder.CreateApp(builder, pathBase);

                    }))
                   };
        }

        /// <summary>
        /// Finds the ASP .NET Core HTTPS development certificate in development environment. Update this method to use the appropriate certificate for production environment.
        /// </summary>
        /// <returns>Returns the ASP .NET Core HTTPS development certificate</returns>
        static X509Certificate2 GetCertificateFromStore()
        {
            string aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            if (string.Equals(aspNetCoreEnvironment, "Development", StringComparison.OrdinalIgnoreCase))
            {
                const string aspNetHttpsOid = "1.3.6.1.4.1.311.84.1.1";
                const string cNName = "CN=localhost";
                using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
                {
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certCollection = store.Certificates;
                    X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByExtension, aspNetHttpsOid, true);
                    currentCerts = currentCerts.Find(X509FindType.FindByIssuerDistinguishedName, cNName, true);
#pragma warning disable CS8603 // Possible null reference return.
                    return currentCerts.Count != 0 ? currentCerts[0] : null;
#pragma warning restore CS8603 // Possible null reference return.
                }
            }
            else
            {
                throw new NotImplementedException("GetCertificateFromStore should be updated to retrieve the certificate for non Development environment");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0300:Simplify collection initialization", Justification = "Service Fabric Boilerplate")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "Service Fabric Boilerplate")]
        X509Certificate2 FindMatchingCertificateBySubject(string subjectCommonName)
        {
            using X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = store.Certificates;
            X509Certificate2Collection matchingCerts = new X509Certificate2Collection();

            foreach (X509Certificate2 enumeratedCert in certCollection.Where(enumeratedCert => StringComparer.OrdinalIgnoreCase.Equals(subjectCommonName, enumeratedCert.GetNameInfo(X509NameType.SimpleName, forIssuer: false))
                                                                                  && DateTime.Now < enumeratedCert.NotAfter
                                                                                  && enumeratedCert.NotBefore <= DateTime.Now))
            {
                matchingCerts.Add(enumeratedCert);
            }

            if (matchingCerts.Count == 0)
            {
                foreach (X509Certificate2? enumeratedCert in certCollection.Where(enumeratedCert => StringComparer.OrdinalIgnoreCase.Equals("*.sews-e.com", enumeratedCert.GetNameInfo(X509NameType.SimpleName, forIssuer: false))
                                                                                  && DateTime.Now < enumeratedCert.NotAfter
                                                                                  && enumeratedCert.NotBefore <= DateTime.Now))
                {
                    matchingCerts.Add(enumeratedCert);
                }

                if (matchingCerts.Count == 0)
                {
                    throw new ArgumentNullException($"Could not find a match for a certificate with subject 'CN={subjectCommonName}'.");
                }
            }

            return matchingCerts[0];
        }
    }
}

using Microsoft.Extensions.Hosting;

namespace SF.Access.Masters
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    sealed class Masters : StatelessService
    {
        public Masters(StatelessServiceContext context)
            : base(context)
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
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        WebApplicationBuilder builder = WebApplication.CreateBuilder();

                        builder.Services.AddSingleton(serviceContext);
                        builder.WebHost
                                    .UseKestrel(opt =>
                                    {
                                        int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;
                                        opt.Listen(IPAddress.IPv6Any, port, listenOptions =>
                                        {
                                            listenOptions.UseHttps(FindMatchingCertificateBySubject("*.SEWS-E.COM"));
                                            listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                        });
                                    })
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url);

                        
                        return Masters.HostBuilder.CreateApp(builder, serviceContext, url);

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

        X509Certificate2 FindMatchingCertificateBySubject(string subjectCommonName)
        {
            using X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = store.Certificates;
            X509Certificate2Collection matchingCerts = new X509Certificate2Collection();

            foreach (X509Certificate2 enumeratedCert in certCollection.Where(enumeratedCert => StringComparer.OrdinalIgnoreCase.Equals(subjectCommonName, enumeratedCert.GetNameInfo(X509NameType.SimpleName, forIssuer: false))
                                                                                  && DateTime.Now < enumeratedCert.NotAfter
                                                                                  && DateTime.Now >= enumeratedCert.NotBefore))
            {
                matchingCerts.Add(enumeratedCert);
            }

            if (matchingCerts.Count == 0)
            {
                foreach (X509Certificate2? enumeratedCert in certCollection.Where(enumeratedCert => StringComparer.OrdinalIgnoreCase.Equals("*.sews-e.com", enumeratedCert.GetNameInfo(X509NameType.SimpleName, forIssuer: false))
                                                                                  && DateTime.Now < enumeratedCert.NotAfter
                                                                                  && DateTime.Now >= enumeratedCert.NotBefore))
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

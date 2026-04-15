using static Master.Master;

namespace SF.Manager.Rfqs
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
                                        opt.Listen(IPAddress.IPv6Any, port, listenOptions =>
                                        {
#if DEBUG
                                          listenOptions.Protocols = HttpProtocols.Http1AndHttp2;  //listenOptions.UseHttps(GetCertificateFromStore());
#else
                                            //listenOptions.UseHttps(FindMatchingCertificateBySubject("*.sews-e.com"));
#endif
                                            listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                        });
                                    })
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url);

                        return Rfq.HostBuilder.CreateApp(builder, url);

                    }))
            };
        }
    }
}

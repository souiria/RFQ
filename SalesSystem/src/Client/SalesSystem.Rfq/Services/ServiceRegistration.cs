namespace SalesSystem.Rfq.Services
{
    public static class ServiceRegistration
    {
        /// <summary>
        ///     Set up UX Services for Blazor
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRfqUxServices(this IServiceCollection services)
        {
            services.AddScoped<RfqUxClientService>();
            services.AddScoped<DsiUxClientService>();
            services.AddScoped<CsvExportService>();
            return services;
        }
    }
}

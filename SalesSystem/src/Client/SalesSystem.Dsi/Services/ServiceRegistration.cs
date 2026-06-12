namespace SalesSystem.Dsi.Services
{
    public static class ServiceRegistration
    {
        /// <summary>
        ///     Set up UX Services for Blazor
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDsiUxServices(this IServiceCollection services)
        {
            services.AddScoped<DsiUxClientService>();
            services.AddScoped<CsvExportService>();
            return services;
        }
    }
}

using HostBuilder = SalesSystem.Rfq.HostBuilder;

static class Program
{
    static void Main(string[] args)
    {
        using (WebApplication app = HostBuilder.CreateApp(null, args))
        {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("Starting the Sales Edi Ux Service");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            app.Run();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        using (WebApplication app = SalesSystem.Rfq.HostBuilder.CreateApp(null, args))
        {
            app.Run();
        }
    }
}
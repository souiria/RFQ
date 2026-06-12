class Program
{
    static void Main(string[] args)
    {
        using (WebApplication app = SalesSystem.Dsi.HostBuilder.CreateApp(null, args))
        {
            app.Run();
        }
    }
}
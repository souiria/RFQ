namespace Rfq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using WebApplication app = HostBuilder.CreateApp(
                 builder: null,
                pathBase: "/",   // Aspire has no pathBase
                args: args       // Pass CLI args here
            );

#pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("Starting the RFQ Service");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                app.Run();
          }
    }
}
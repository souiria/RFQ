namespace EngSol
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            using (WebApplication app = HostBuilder.CreateApp(null, args))
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                Console.WriteLine("Starting the EngSol Service");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                app.Run();
            }
        }
    }
}
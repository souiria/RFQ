using Master.Endpoints.GrpcServices;

namespace Master
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region ToDo

            // create in-memory dictionaries
            // create dto's
            // create crud ops

            #endregion

            using (WebApplication app = HostBuilder.CreateApp(null, args))
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                Console.WriteLine("Starting the Masters Service");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                app.Run();
            }
        }
    }
}
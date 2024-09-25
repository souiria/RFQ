namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public static class EndpointHelper
    {
#if DEBUG
        // Local
        public static string EndpointAddress = "localhost";

        //MIND Server IP
        //public static string EndpointAddress = "172.29.38.15";

        // TDD
        //public static string EndpointAddress = "192.168.53.51";

        // UAT
        //public static string EndpointAddress = "UKHQH1UAT";

        //Live
        //public static string EndpointAddress = "UKHQHOS001";
#elif UAT
         // UAT
        public static string EndpointAddress = "UKHQH1UAT";
#else
        //Live
        public static string EndpointAddress = "UKHQHOS001";
#endif

    }
}
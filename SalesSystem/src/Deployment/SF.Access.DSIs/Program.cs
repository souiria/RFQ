namespace SF.Access.DSIs
{
    static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                ServiceRuntime.RegisterServiceAsync("SF.Access.DSIsType",
                    context => new DSIs(context)).GetAwaiter().GetResult();

                ServiceEventSource._Current.ServiceTypeRegistered(Environment.ProcessId, typeof(DSIs).Name);

                // Prevents this host process from terminating so services keeps running. 
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                string exceptionString = e.ToString();
                ServiceEventSource._Current.ServiceHostInitializationFailed(exceptionString);
                throw;
            }
        }
    }
}

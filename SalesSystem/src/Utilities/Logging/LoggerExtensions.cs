namespace Logging
{
    public static class LoggerExtensions
    {
        static Action<ILogger, string, Exception> _GenericLogInformation;
        static Action<ILogger, string, Exception> _GenericLogError;
        static LoggerExtensions()
        {        
            _GenericLogInformation = LoggerMessage.Define<string>(
            logLevel: LogLevel.Information,
            eventId: 1,
            formatString: "{String}");

            _GenericLogError = LoggerMessage.Define<string>(
            logLevel: LogLevel.Error,
            eventId: 2,
            formatString: "{String}");
        }

        public static void GenericLogInformation(
            this ILogger logger, string information)
        {
            _GenericLogInformation(logger, information, null!);
        }
        public static void GenericLogError(
            this ILogger logger, string errorMessage, Exception e)
        {
            _GenericLogError(logger, errorMessage, e);
        }
    }
}

namespace Master
{
    static class LoggerExtensions
    {
        static Action<ILogger, String, Exception> _GenericLogInformation;
        static Action<ILogger, String, Exception> _GenericLogError;
        static LoggerExtensions()
        {        
            _GenericLogError = LoggerMessage.Define<String>(
            logLevel: LogLevel.Error,
            eventId: 1,
            formatString: "Logged Error: {String}");

            _GenericLogInformation = LoggerMessage.Define<String>(
            logLevel: LogLevel.Information,
            eventId: 1,
            formatString: "{String}");
        }

        public static void GenericLogInformation(
            this ILogger logger, string information)
        {
            _GenericLogInformation(logger, information, null!); //<--appending ! is null forgiving operator
        }
        public static void GenericLogError(
            this ILogger logger, string errorMessage)
        {
            _GenericLogError(logger, errorMessage, null!);
        }
    }
}

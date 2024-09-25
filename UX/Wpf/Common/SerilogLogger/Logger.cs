using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using System.Diagnostics;

namespace SerilogLogger
{
    public class Logger : ILoggerFacade
    {
        public Logger()
        {
        }


        public Serilog.Core.Logger logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
            .WithDefaultDestructurers())
            .WriteTo.File(@"E:\log.txt",
            outputTemplate: "{Timestamp:yyyy-mm-dd HH:mm:ss.fff} [{Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(new CompactJsonFormatter(), @"E:\log_json.txt")
            .WriteTo.RollingFile(
        new JsonFormatter(renderMessage: true),
        @"E:\log-{Date}.txt")
            .CreateLogger();

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    logger.Debug(message);
                    break;
                case Category.Info:
                    logger.Information(message);
                    break;
                case Category.Warn:
                    logger.Warning(message);
                    break;
                case Category.Exception:
                    logger.Error(message);
                    break;
                default:
                    logger.Fatal(message);
                    break;
            }
        }

        public void LogExceptionInformation(Exception ex, StackFrame stackFrame, string className, string screenshot)
        {
            string innerException = ex.InnerException?.ToString();

            logger.Error("An error was encountered. Please refer to the error logs given below to see " +
                "the detailed exceptions.");

            logger.Error(ex, "{className}, {methodName}, {physicalFileName}, {stackTrace}, " +
                "{@innerException}, {snapshotData}", className, stackFrame.GetMethod().Name,
                stackFrame.GetFileName(), ex.StackTrace, innerException, screenshot);
            
        }

        public void LogServiceInformation(string serviceName, string methodName,
                                          string viewModelName, string duration)
        {
            logger.Information("The service {serviceName} was called by the method {methodName} in the viewModel {viewModelName} and it took " +
                "{duration} to execute successfully.", serviceName, methodName, viewModelName, duration);
        }

        

        public void LogMethodInformation(string methodName, string className)
        {
            logger.Information("The method {methodName} was successfully called in the class {className}", methodName, className);
        }

        public void LogViewLoadInformation(string viewName, string duration)
        {
            logger.Information("The view {viewName} took {duration} to load.", viewName, duration);
        }

        public void LogViewRefreshInformation(string viewName, string duration)
        {
            logger.Information("The view {viewName} took {duration} to refresh.", viewName, duration);
        }

        public void LogGridLoadInformation(string viewName, string duration)
        {
            logger.Information("The xamDataGrid in the view {viewName} took {duration} to load.", viewName, duration);
        }

        public void LogCreateInformation(string viewName, string duration)
        {
            logger.Information("It took {duration} to create a new record in the view {viewName}.", duration, viewName);
        }

        public void LogSaveInformation(string viewName, string duration)
        {
            logger.Information("It took {duration} to save records in the view {viewName}.", duration, viewName);
        }

        public void LogControlLoadInformation(string controlType, string controlName, string viewName,
                                                string duration)
        {
            logger.Information("The {controlType} {controlName} took {duration} to load in the {viewName}.", controlType,
                                controlName, duration, viewName);
        }

    }
}

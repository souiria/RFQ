using Ardalis.GuardClauses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace SharedKernel
{
    /// <summary>
    /// Adds logging for all requests in MediatR pipeline.
    /// Configure by adding the service with a scoped lifetime
    /// 
    /// Example for Autofac:
    /// builder
    ///   .RegisterType&lt;Mediator&gt;()
    ///   .As&lt;IMediator&gt;()
    ///   .InstancePerLifetimeScope();
    ///
    /// builder
    ///   .RegisterGeneric(typeof(LoggingBehavior&lt;,&gt;))
    ///      .As(typeof(IPipelineBehavior&lt;,&gt;))
    ///   .InstancePerLifetimeScope();
    ///
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : IRequest<TResponse>
    {
        readonly ILogger<Mediator> _Logger;

        public LoggingBehavior(ILogger<Mediator> logger)
        {
            _Logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
            Guard.Against.Null(request);
            if (_Logger.IsEnabled(LogLevel.Information))
            {
                _Logger.LogInformation("Handling {RequestName}", typeof(TRequest).Name);
                // Reflection! Could be a performance concern
                Type myType = request.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                foreach (PropertyInfo prop in props)
                {
                    object? propValue = prop?.GetValue(request, null);
                    _Logger.LogInformation("Property {Property} : {@Value}", prop?.Name, propValue);
                }
            }

            Stopwatch sw = Stopwatch.StartNew();

            TResponse? response = await next(cancellationToken);

#pragma warning disable CA1727 // Use PascalCase for named placeholders
            _Logger.LogInformation("Handled {RequestName} with {Response} in {ms} ms", typeof(TRequest).Name, response, sw.ElapsedMilliseconds);
#pragma warning restore CA1727 // Use PascalCase for named placeholders
            sw.Stop();
#pragma warning restore CA1848 // Use the LoggerMessage delegates
            return response;
        }
    }
}

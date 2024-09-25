namespace Edi.Common.AutofacModules;
public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.Register(x =>
        {
            var seqConnection = Environment.GetEnvironmentVariable("SEQ_CONNECTION");
            var serviceContext = x.ResolveOptional<ServiceContext>();

            if (string.IsNullOrEmpty(seqConnection))
            {
                seqConnection = "http://localhost:5341";
                //seqConnection = "http://tddiisweb001.sews-tdd.com:5341";
                //seqConnection ??= "http://ukhquatiis001:5341";
                //seqConnection ??= "http://ukhqcomiis001:5341";
            }

            return LoggerFactory.Create(config =>
            {
                var loggerConfig = new LoggerConfiguration();
                if (serviceContext != null)
                {
                    loggerConfig
                        .MinimumLevel.Information()
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ServiceTypeName", serviceContext.ServiceTypeName)
                        .Enrich.WithProperty("ServiceName", serviceContext.ServiceName)
                        .Enrich.WithProperty("PartitionId", serviceContext.PartitionId)
                        .Enrich.WithProperty("InstanceId", serviceContext.ReplicaOrInstanceId)
                        .Enrich.WithProperty("NodeName", serviceContext.NodeContext.NodeName);
                }
                else
                {
                    loggerConfig
                        .MinimumLevel.Information()
                        .Enrich.FromLogContext();
                }

                loggerConfig.Enrich.WithProperty("Application", "Sales Edi");
                loggerConfig.WriteTo.Debug();
                loggerConfig.WriteTo.Console();
                loggerConfig.WriteTo.Trace();

                if (!string.IsNullOrEmpty(seqConnection))
                {
                    loggerConfig.WriteTo.Seq(seqConnection);
                }

                config.AddSerilog(loggerConfig.CreateLogger());
            });
        }).InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(Logger<>))
            .As(typeof(ILogger<>))
            .SingleInstance();
    }
}

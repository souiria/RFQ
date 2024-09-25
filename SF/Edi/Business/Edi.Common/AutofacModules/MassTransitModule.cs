namespace Edi.Common.AutofacModules;
public class MassTransitModule : Module
{
    private readonly IEnumerable<Assembly> _assembliesToScan;
    public MassTransitModule(IEnumerable<Assembly> assembliesToScan)
    {
        this._assembliesToScan = assembliesToScan;
    }

    public MassTransitModule(params Assembly[] assembliesToScan) : this((IEnumerable<Assembly>)assembliesToScan) { }

    protected override void Load(ContainerBuilder builder)
    {
        var assembliesToScan = this._assembliesToScan as Assembly[] ?? this._assembliesToScan.ToArray();
        var allTypes = assembliesToScan
            .Where(a => !a.IsDynamic && a.GetName().Name.Contains("Consumer"))
            .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
            .SelectMany(a => a.DefinedTypes)
            .ToArray();
        var openTypes = new[] {
            typeof(IConsumer)};

        var clusterName = Environment.GetEnvironmentVariable("RABBIT_CLUSTERNAME") ?? "";
        var nodeNames = Environment.GetEnvironmentVariable("RABBITMQ_CONNECTION") ?? "";
        var services = new ServiceCollection();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(clusterName), "/", h =>
                {
                    h.Username("user");
                    h.Password("password");
                    h.UseCluster(c =>
                    {
                        string[] hostnames = nodeNames.Split(";");
                        foreach (string hostname in hostnames)
                        {
                            c.Node(hostname);
                        }
                    });
                });

                config.SetQuorumQueue();
                config.ConfigureEndpoints(context);
            });
            if (assembliesToScan.Any())
            {
                x.AddConsumers(assembliesToScan[0]);
            }

        });

        // push the ServiceCollection into the ContainerBuilder 
        builder.Populate(services);

    }
}

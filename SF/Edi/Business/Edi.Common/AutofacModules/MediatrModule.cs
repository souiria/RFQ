namespace Edi.Common.AutofacModules;
public class MediatrModule : Module
{
    private readonly IEnumerable<Assembly> _assembliesToScan;
    public MediatrModule(IEnumerable<Assembly> assembliesToScan)
    {
        this._assembliesToScan = assembliesToScan;
    }

    public MediatrModule(params Assembly[] assembliesToScan) : this((IEnumerable<Assembly>)assembliesToScan) { }

    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        var assembliesToScan = this._assembliesToScan as Assembly[] ?? this._assembliesToScan.ToArray();
        var configuration = MediatRConfigurationBuilder
            .Create(assembliesToScan)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();
        builder.RegisterMediatR(configuration);
    }
}

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc(opt =>
        {
            opt.EnableDetailedErrors = true;
            opt.MaxReceiveMessageSize = int.MaxValue;
            opt.MaxSendMessageSize = int.MaxValue;
        });

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<EdiModuleService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}
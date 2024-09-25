namespace CommercialService2.Api.ApplicationInsights;

public class CloudRoleNameTelemetryInitializer(string cloudRoleName) : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        telemetry.Context.Cloud.RoleName = cloudRoleName;
    }
}

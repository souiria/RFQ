namespace Edi.Common.ApplicationInsights;

public class CloudRoleNameTelemetryInitializer(string cloudRoleName) : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        telemetry.Context.Cloud.RoleName = cloudRoleName;
    }
}

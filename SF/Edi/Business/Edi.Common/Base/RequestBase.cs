namespace Edi.Common.Base;

public class RequestBase
{
    public Guid? UserId { get; set; }
    public bool IsCompressed { get; set; } = true;
    public bool HasHeartBeat { get; set; }
    public Guid? ModuleId { get; set; }
}

namespace Common.Core.Contracts.Interfaces.Administration.Security
{
    public interface ISecurityModel
    {
        string DisplayName { get; set; }
        string LabelKey { get; set; }
        string DisplayLabel { get; set; }
    }
}

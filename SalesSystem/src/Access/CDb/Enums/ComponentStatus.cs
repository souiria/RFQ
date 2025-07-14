namespace CDb.Enums
{
    public enum ComponentStatus
    {
        [Description("N/A")]
        NotAvailable,
        [Description("Unknown")]
        Unknown,
        [Description("Current")]
        Current,
        [Description("New")]
        New,
        [Description("Obsolete")]
        Obsolete,
        [Description("Current-Valid")]
        CurrentValid,
        [Description("New-Valid")]
        NewValid
    }
}

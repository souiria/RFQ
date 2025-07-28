namespace CDb.Data.Model.Masters
{
    [Index(nameof(Name), IsUnique = true)]
    public class DbTerminalSize
    {
        public Guid Id
        { get; set; }
        public string Name
        { get; set; }
        public string Description
        { get; set; }
        public Guid TerminalFamilyId
        { get; set; }
        public DbTerminalFamily TerminalFamily
        { get; set; }
        public ICollection<DbTerminal> Terminals
        { get; init; }
        public ICollection<DbConnector> Connectors
        { get; init; }
        public bool IsActive
        { get; set; }

        public DbTerminalSize()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            IsActive = false;
            TerminalFamily = null!;
            Terminals = new HashSet<DbTerminal>();
            Connectors = new HashSet<DbConnector>();
        }
    }
}

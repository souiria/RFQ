namespace CDb.Data.Model.Masters
{
    [Index(nameof(Name), IsUnique = true)]
    public class DbTerminalFamily : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public string Name
        { get; set; }
        public string Description
        { get; set; }
        public ICollection<DbTerminal> Terminals
        { get; init; }
        public ICollection<DbConnector> Connectors
        { get; init; }
        public bool IsActive
        { get; set; }

        public DbTerminalFamily()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            Terminals = new HashSet<DbTerminal>();
            Connectors = new HashSet<DbConnector>();
            IsActive = false;
        }
    }
}

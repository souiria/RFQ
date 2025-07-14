namespace CDb.Data.Model.Masters
{
    [Index(nameof(Name), IsUnique = true)]
    public class DbTerminalFamily
    {
        public Guid Id
        { get; set; }
        public string Name
        { get; set; }
        public string Description
        { get; set; }
        public ICollection<DbTerminalSize> Sizes
        { get; init; }
        public ICollection<DbTerminal> Terminals
        { get; init; }
        public ICollection<DbConnector> Connectors
        { get; init; }
        public bool IsDeleted
        { get; set; }

        public DbTerminalFamily()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            Sizes = new HashSet<DbTerminalSize>();
            Terminals = new HashSet<DbTerminal>();
            Connectors = new HashSet<DbConnector>();
            IsDeleted = false;
        }
    }
}

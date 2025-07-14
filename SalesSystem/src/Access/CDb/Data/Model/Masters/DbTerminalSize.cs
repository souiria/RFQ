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
        public ICollection<DbTerminalFamily> Families
        { get; init; }
        public ICollection<DbTerminal> Terminals
        { get; init; }
        public ICollection<DbConnector> Connectors
        { get; init; }
        public bool IsDeleted
        { get; set; }

        public DbTerminalSize()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            IsDeleted = false;
            Families = new HashSet<DbTerminalFamily>();
            Terminals = new HashSet<DbTerminal>();
            Connectors = new HashSet<DbConnector>();
        }
    }
}

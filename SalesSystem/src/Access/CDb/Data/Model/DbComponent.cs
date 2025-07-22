namespace CDb.Data.Model
{
    public abstract class DbComponent : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public ComponentType ComponentType
        { get; set; }
        public int SheetNumber
        { get; set; }
        public string Name
        { get; set; }
        public string? Issue
        { get; set; }
        public ComponentStatus ComponentStatus
        { get; set; }

        public decimal Weight
        { get; set; }
        public string? Comment
        { get; set; }
        public string? TypeCode
        { get; set; }
        public string? UserField4
        { get; set; }
        public string? UserField5
        { get; set; }
        public bool? GraphicSymbol
        { get; set; }
        public string? InDb
        { get; set; }
        public string? PfReferencePsa
        { get; set; }
        public bool? VerifiedToLatestDrawing
        { get; set; }
        public bool? UpdateInCaphDb
        { get; set; }
        public string? StatusPv
        { get; set; }
        public DateTime? DatePv
        { get; set; }
        public string? StatusBrut
        { get; set; }
        public string? Pilot
        { get; set; }
        public DateTime? DbUpdatedPv
        { get; set; }

        // audit properties
        public DateTime Created
        { get; set; }
        public Guid CreatedById
        { get; set; }
        public DateTime? Updated
        { get; set; }
        public Guid? UpdatedById
        { get; set; }
        public DateTime? Validated
        { get; set; }
        public Guid ValidatedById
        { get; set; }
        public string? GroupName
        { get; set; }

        // relationship properties 
        // related fields
        public bool IsReplacement
        { get; set; }
        public Guid? ReplacedComponentId
        { get; set; }
        public DbComponent? ReplacedComponent
        { get; set; }
        // if no TemperatureRangeId then TemperatureLow and TemperatureHigh are used
        public int TemperatureLow
        { get; set; }
        public int TemperatureHigh
        { get; set; }
        public Guid? TemperatureRangeId
        { get; set; }
        public DbTemperatureRange? TemperatureRange
        { get; set; }
        // files associated with the component
        public ICollection<DbFileName> FileNames
        { get; init; }
        // many-to-many relationship with DbPerson - buyer, responsible and customer/supplier contacts
        public ICollection<DbPerson> Contacts
        { get; init; }
        // many-to-many relationship with DbPartner - suppliers, customers, manufacturers, etc.
        public ICollection<DbPartner> Partners
        { get; init; }
        // many-to-many relationship with DbPartNumber - all part numbers associated with the component
        public ICollection<DbPartNumber> PartNumbers
        { get; init; }
        // many-to-many relationship with DbTag - tags associated with the component (GC5 Project field goes here as a Project type tag
        public ICollection<DbTag> Tags
        { get; init; }

        public Guid? UnitOfMeasureId
        { get; set; }
        //self aggregation
        public ICollection<DbComponent> Children
        { get; init; }
        public ICollection<DbComponent> Parents
        { get; init; }

        protected DbComponent()
        {
            Id = Guid.NewGuid();
            ComponentType = ComponentType.Unknown;
            SheetNumber = 0;
            Name = string.Empty;
            Issue = null;
            ComponentStatus = ComponentStatus.Unknown;
            Weight = 0.0m;
            Comment = null;
            TypeCode = null;
            UserField4 = null;
            UserField5 = null;
            GraphicSymbol = null;
            InDb = null;
            PfReferencePsa = null;
            VerifiedToLatestDrawing = null;
            UpdateInCaphDb = null;
            StatusPv = null;
            DatePv = null;
            StatusBrut = null;
            Pilot = null;
            DbUpdatedPv = null;
            IsReplacement = false;
            ReplacedComponentId = null;
            ReplacedComponent = null;
            TemperatureLow = 0;
            TemperatureHigh = 0;
            TemperatureRangeId = null;
            TemperatureRange = null;
            UnitOfMeasureId = null;
            ComponentStatus = ComponentStatus.Unknown;

            CreatedById = Guid.Empty;
            Created = DateTime.UtcNow;
            //UpdatedById = null;
            Updated = Created;
            //ValidatedById = Guid.Empty;
            //Validated = DateTime.UtcNow;

            FileNames = new List<DbFileName>();
            Contacts = new List<DbPerson>();
            Partners = new List<DbPartner>();
            PartNumbers = new List<DbPartNumber>();
            Tags = new List<DbTag>();
            Children = new List<DbComponent>();
            Parents = new List<DbComponent>();
        }
    }
}

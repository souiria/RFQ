namespace Core.Data.Models
{
    public class DbUserList : IAggregateRoot
    {
        public string Username
        { get; set; } = string.Empty;
        public string FirstName
        { get; set; } = string.Empty;
        public string Surname
        { get; set; } = string.Empty;
        public string Site
        { get; set; } = string.Empty;
        public string Logon
        { get; set; } = string.Empty;
        public DateTime LastLogin
        { get; set; }
        public DateTime FirstLogin
        { get; set; }
        public string Accesss
        { get; set; } = string.Empty;
        public bool IsActive
        { get; set; }
        public string Groups
        { get; set; } = string.Empty;
        public Guid Id
        { get; set; }
        public DateTime CreatedDate
        { get; set; }
        public DateTime ModifiedDate
        { get; set; }
        public Guid CreatedBy
        { get; set; }
        public Guid ModifiedBy
        { get; set; }
        public string EmailAddress
        { get; set; } = string.Empty;
        public DateTime ActiveDirectoryDeactivationDate
        { get; set; }
        public bool IsUserActive
        { get; set; }
        public bool IsAccountLocked
        { get; set; }
        public string UserRoles
        { get; set; } = string.Empty;
        public string CreationHelpDeskNumber
        { get; set; } = string.Empty;
        public string CreationHelpDeskDescription
        { get; set; } = string.Empty;
        public DateTime CreationHelpDeskDate
        { get; set; }
        public string LastHelpDeskNumber
        { get; set; } = string.Empty;
        public string LastHelpDeskDescription
        { get; set; } = string.Empty;
        public DateTime LastHelpDeskDate
        { get; set; }
        public bool IsH1User
        { get; set; }
    }
}

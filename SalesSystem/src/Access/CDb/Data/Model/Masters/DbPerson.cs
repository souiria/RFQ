using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CDb.Enums;

namespace CDb.Data.Model.Masters
{
    public class DbPerson
    {
        public Guid Id 
        { get; set; }
        public PersonType PersonType 
        { get; set; }

        public string Name 
        { get; set; }
        public string? Description 
        { get; set; }
        public string Phone 
        { get; set; }
        public string Email 
        { get; set; }
        public string? Address 
        { get; set; }
        public bool IsDeleted 
        { get; set; }
        public ICollection<DbComponent> Components 
        { get; init; }

        public DbPerson()
        {
            Id = Guid.NewGuid();
            PersonType = PersonType.Contact;
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Components = new List<DbComponent>();
            IsDeleted = false;
        }
    }
}

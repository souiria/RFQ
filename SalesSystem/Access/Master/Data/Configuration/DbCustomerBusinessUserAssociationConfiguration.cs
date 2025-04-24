using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerBusinessUserAssociationConfiguration : IEntityTypeConfiguration<DbCustomerBusinessUserAssociation>
    {
        public void Configure(EntityTypeBuilder<DbCustomerBusinessUserAssociation> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

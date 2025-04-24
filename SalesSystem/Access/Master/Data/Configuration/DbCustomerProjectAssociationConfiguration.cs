using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerProjectAssociationConfiguration : IEntityTypeConfiguration<DbCustomerProjectAssociation>
    {
        public void Configure(EntityTypeBuilder<DbCustomerProjectAssociation> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

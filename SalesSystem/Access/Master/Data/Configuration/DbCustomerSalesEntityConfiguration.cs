using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerSalesEntityConfiguration : IEntityTypeConfiguration<DbCustomerSalesEntity>
    {
        public void Configure(EntityTypeBuilder<DbCustomerSalesEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

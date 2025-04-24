using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCurrencyConfiguration : IEntityTypeConfiguration<DbCurrency>
    {
        public void Configure(EntityTypeBuilder<DbCurrency> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

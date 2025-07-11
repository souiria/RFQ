using ComponentDB.Infrastructure.DataMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Masters
{
    public class DbTypeCodeConfiguration : IEntityTypeConfiguration<DbTypeCode>
    {
        public void Configure(EntityTypeBuilder<DbTypeCode> builder)
        {
            builder.ToTable("TypeCodes");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Code)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(w => w.Code)
                .IsUnique();
            builder.Property(w => w.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }
        void AddSeedData(EntityTypeBuilder<DbTypeCode> builder)
        {
            DbTypeCode notAvailable = new DbTypeCode("N/A");
            DbTypeCode adht = new DbTypeCode("ADHT");
            DbTypeCode bcli = new DbTypeCode("BCLI");
            DbTypeCode box = new DbTypeCode("BOX");
            DbTypeCode ccli = new DbTypeCode("CCLI");
            DbTypeCode ceye = new DbTypeCode("CEYE");
            DbTypeCode cover = new DbTypeCode("COVER");
            DbTypeCode csep = new DbTypeCode("CSEP");
            DbTypeCode csla = new DbTypeCode("CSLA");
            DbTypeCode csun = new DbTypeCode("CSUN");
            DbTypeCode etiq = new DbTypeCode("ETIQ");
            DbTypeCode felt = new DbTypeCode("FELT");
            DbTypeCode fire = new DbTypeCode("FIRE");
            DbTypeCode flag = new DbTypeCode("FLAG");
            DbTypeCode fram = new DbTypeCode("FRAM");
            DbTypeCode fusn = new DbTypeCode("FUSN");
            DbTypeCode fuss = new DbTypeCode("FUSS");
            DbTypeCode gaf = new DbTypeCode("GAF");
            DbTypeCode gbwa = new DbTypeCode("GBWA");
            DbTypeCode gsna = new DbTypeCode("GSNA");
            DbTypeCode gswa = new DbTypeCode("GSWA");
            DbTypeCode hlsl = new DbTypeCode("HLSL");
            DbTypeCode hood = new DbTypeCode("HOOD");
            DbTypeCode hssl = new DbTypeCode("HSSL");
            DbTypeCode jun1 = new DbTypeCode("JUN1");
            DbTypeCode lock_  = new DbTypeCode("LOCK");
            DbTypeCode mnwp = new DbTypeCode("MNWP");
            DbTypeCode nowp = new DbTypeCode("NOWP");
            DbTypeCode nsls = new DbTypeCode("NSLS");
            DbTypeCode nwp = new DbTypeCode("NWP");
            DbTypeCode other = new DbTypeCode("OTHER");
            DbTypeCode plug = new DbTypeCode("PLUG");
            DbTypeCode poe2 = new DbTypeCode("POE2");
            DbTypeCode prot = new DbTypeCode("PROT");
            DbTypeCode ptcs = new DbTypeCode("PTCS");
            DbTypeCode rela = new DbTypeCode("RELA");
            DbTypeCode sac = new DbTypeCode("SAC");
            DbTypeCode sea1 = new DbTypeCode("SEA1");
            DbTypeCode sea2 = new DbTypeCode("SEA2");
            DbTypeCode sea3 = new DbTypeCode("SEA3");
            DbTypeCode slaby = new DbTypeCode("slaby");
            DbTypeCode tae6 = new DbTypeCode("TAE6");
            DbTypeCode tape = new DbTypeCode("TAPE");
            DbTypeCode tea5 = new DbTypeCode("TEA5");
            DbTypeCode tea6 = new DbTypeCode("TEA6");
            DbTypeCode tea7 = new DbTypeCode("TEA7");
            DbTypeCode ties = new DbTypeCode("TIES");
            DbTypeCode twst = new DbTypeCode("TWST");
            DbTypeCode wp = new DbTypeCode("WP");
            DbTypeCode foam = new DbTypeCode("FOAM");

            builder.HasData(
                notAvailable,
                adht,
                bcli,
                box,
                ccli,
                ceye,
                cover,
                csep,
                csla,
                csun,
                etiq,
                felt,
                fire,
                flag,
                fram,
                fusn,
                fuss,
                gaf,
                gbwa,
                gsna,
                gswa,
                hlsl,
                hood,
                hssl,
                jun1,
                lock_,
                mnwp,
                nowp,
                nsls,
                nwp,
                other,
                plug,
                poe2,
                prot,
                ptcs,
                rela,
                sac,
                sea1,
                sea2,
                sea3,
                slaby,
                tae6,
                tape,
                tea5,
                tea6,
                tea7,
                ties,
                twst,
                wp,
                foam
            );
        }
    }
}

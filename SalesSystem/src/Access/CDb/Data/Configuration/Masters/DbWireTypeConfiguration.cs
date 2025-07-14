using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbWireTypeConfiguration : IEntityTypeConfiguration<DbWireType>
    {
        public void Configure(EntityTypeBuilder<DbWireType> builder)
        {
            builder.ToTable("WireTypes");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Code)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(w => w.Code)
                .IsUnique();
            builder.Property(w => w.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(w => w.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbWireType> builder)
        {
            DbWireType typeUnknown = new DbWireType("Unknown", "Unknown", true);
            DbWireType type_0219 = new DbWireType("_0219", "_0219", true);
            DbWireType typeA3Z = new DbWireType("A3Z", "A3Z", true);
            DbWireType typeA3ZH = new DbWireType("A3ZH", "A3ZH", true);
            DbWireType typeA3ZP = new DbWireType("A3ZP", "A3ZP", true);
            DbWireType typeA3ZPA = new DbWireType("A3ZPA", "A3ZPA", true);
            DbWireType typeA3ZZ = new DbWireType("A3ZZ", "A3ZZ", true);
            DbWireType typeA4Z = new DbWireType("A4Z", "A4Z", true);
            DbWireType typeA4ZH = new DbWireType("A4ZH", "A4ZH", true);
            DbWireType typeA4ZP = new DbWireType("A4ZP", "A4ZP", true);
            DbWireType typeA4Z_S = new DbWireType("A4Z_S", "A4Z_S", true);
            DbWireType typeA4ZZ = new DbWireType("A4ZZ", "A4ZZ", true);
            DbWireType typeALDUS = new DbWireType("ALDUS", "ALDUS", true);
            DbWireType typeB2A = new DbWireType("B2A", "B2A", true);
            DbWireType typeB2C = new DbWireType("B2C", "B2C", true);
            DbWireType typeB9Y01 = new DbWireType("B9Y01", "B9Y01", true);
            DbWireType typeBV3C = new DbWireType("BV3C", "BV3C", true);
            DbWireType typeC3A = new DbWireType("C3A", "C3A", true);
            DbWireType typeC3PZH = new DbWireType("C3PZH", "C3PZH", true);
            DbWireType typeC3ZH = new DbWireType("C3ZH", "C3ZH", true);
            DbWireType typeC4A = new DbWireType("C4A", "C4A", true);
            DbWireType typeC4ZH = new DbWireType("C4ZH", "C4ZH", true);
            DbWireType typeC5A = new DbWireType("C5A", "C5A", true);
            DbWireType typeC5ZH = new DbWireType("C5ZH", "C5ZH", true);
            DbWireType typeC6A = new DbWireType("C6A", "C6A", true);
            DbWireType typeC6ZH = new DbWireType("C6ZH", "C6ZH", true);
            DbWireType typeCE3B = new DbWireType("CE3B", "CE3B", true);
            DbWireType typeCE3C = new DbWireType("CE3C", "CE3C", true);
            DbWireType typeC_F3Z = new DbWireType("C_F3Z", "C_F3Z", true);
            DbWireType typeCFLRA = new DbWireType("CFLRA", "CFLRA", true);
            DbWireType typeCFLRB = new DbWireType("CFLRB", "CFLRB", true);
            DbWireType typeCFLT2 = new DbWireType("CFLT2", "CFLT2", true);
            DbWireType typeD6 = new DbWireType("D6", "D6", true);
            DbWireType typeD6CPC = new DbWireType("D6CPC", "D6CPC", true);
            DbWireType typeDC631 = new DbWireType("DC631", "DC631", true);
            DbWireType typeDR_IN = new DbWireType("DR_IN", "DR_IN", true);
            DbWireType typeF3Z = new DbWireType("F3Z", "F3Z", true);
            DbWireType typeF3ZPA = new DbWireType("F3ZPA", "F3ZPA", true);
            DbWireType typeFLR13 = new DbWireType("FLR13", "FLR13", true);
            DbWireType typeFLRYA = new DbWireType("FLRYA", "FLRYA", true);
            DbWireType typeFLRYB = new DbWireType("FLRYB", "FLRYB", true);
            DbWireType typeFLYT2 = new DbWireType("FLYT2", "FLYT2", true);
            DbWireType typeG3C = new DbWireType("G3C", "G3C", true);
            DbWireType typeG3ZH = new DbWireType("G3ZH", "G3ZH", true);
            DbWireType typeG4A = new DbWireType("G4A", "G4A", true);
            DbWireType typeG4C = new DbWireType("G4C", "G4C", true);
            DbWireType typeH4ZH = new DbWireType("H4ZH", "H4ZH", true);
            DbWireType typeHV3 = new DbWireType("HV3", "HV3", true);
            DbWireType typeHV4 = new DbWireType("HV4", "HV4", true);
            DbWireType typeHV4C = new DbWireType("HV4C", "HV4C", true);
            DbWireType typeNF3Z = new DbWireType("NF3Z", "NF3Z", true);
            DbWireType typeNF3ZA = new DbWireType("NF3ZA", "NF3ZA", true);
            DbWireType typeNF3ZZ = new DbWireType("NF3ZZ", "NF3ZZ", true);
            DbWireType typeP3S = new DbWireType("P3S", "P3S", true);
            DbWireType typeP3SNC = new DbWireType("P3SNC", "P3SNC", true);
            DbWireType typePVC1 = new DbWireType("PVC1", "PVC1", true);
            DbWireType typeSI_LD = new DbWireType("SI_LD", "SI_LD", true);
            DbWireType typeSQUIB = new DbWireType("SQUIB", "SQUIB", true);
            DbWireType typeSRE = new DbWireType("SRE", "SRE", true);
            DbWireType typeT4601 = new DbWireType("T4601", "T4601", true);
            DbWireType typeT7128 = new DbWireType("T7128", "T7128", true);
            DbWireType typeT7129 = new DbWireType("T7129", "T7129", true);
            DbWireType typeT7988 = new DbWireType("T7988", "T7988", true);
            DbWireType typeR3Z = new DbWireType("R3Z", "R3Z", true);
            DbWireType typeR4S = new DbWireType("R4S", "R4S", true);
            DbWireType typeF4Z = new DbWireType("F4Z", "F4Z", true);

            builder.HasData(
                typeUnknown,
                type_0219,
                typeA3Z,
                typeA3ZH,
                typeA3ZP,
                typeA3ZPA,
                typeA3ZZ,
                typeA4Z,
                typeA4ZH,
                typeA4ZP,
                typeA4Z_S,
                typeA4ZZ,
                typeALDUS,
                typeB2A,
                typeB2C,
                typeB9Y01,
                typeBV3C,
                typeC3A,
                typeC3PZH,
                typeC3ZH,
                typeC4A,
                typeC4ZH,
                typeC5A,
                typeC5ZH,
                typeC6A,
                typeC6ZH,
                typeCE3B,
                typeCE3C,
                typeC_F3Z,
                typeCFLRA,
                typeCFLRB,
                typeCFLT2,
                typeD6,
                typeD6CPC,
                typeDC631,
                typeDR_IN,
                typeF3Z,
                typeF3ZPA,
                typeFLR13,
                typeFLRYA,
                typeFLRYB,
                typeFLYT2,
                typeG3C,
                typeG3ZH,
                typeG4A,
                typeG4C,
                typeH4ZH,
                typeHV3,
                typeHV4,
                typeHV4C,
                typeNF3Z,
                typeNF3ZA,
                typeNF3ZZ,
                typeP3S,
                typeP3SNC,
                typePVC1,
                typeSI_LD,
                typeSQUIB,
                typeSRE,
                typeT4601,
                typeT7128,
                typeT7129,
                typeT7988,
                typeR3Z,
                typeR4S,
                typeF4Z
            );
        }
    }
}
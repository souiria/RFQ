using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbWireProtectionTypeConfiguration : IEntityTypeConfiguration<DbWireProtectionType>
    {
        public void Configure(EntityTypeBuilder<DbWireProtectionType> builder)
        {
            builder.ToTable("WireProtectionTypes");
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

        static void AddSeedData(EntityTypeBuilder<DbWireProtectionType> builder)
        {
            DbWireProtectionType typeNotApplicable = new DbWireProtectionType("NotApplicable", "Not applicable", true);
            DbWireProtectionType typeNone = new DbWireProtectionType("None", "", true);
            DbWireProtectionType typeCorrugateTube = new DbWireProtectionType("CorrugateTube", "CORRUGATE TUBE", true);
            DbWireProtectionType typeCottonTape = new DbWireProtectionType("CottonTape", "COTTON TAPE", true);
            DbWireProtectionType typeCurlWrap = new DbWireProtectionType("CurlWrap", "CURLWRAP", true);
            DbWireProtectionType typeDuctSealed = new DbWireProtectionType("DuctSealed", "DUCT SEALED", true);
            DbWireProtectionType typeEmiHv = new DbWireProtectionType("EmiHv", "EMI HV", true);
            DbWireProtectionType typeEpdmTube = new DbWireProtectionType("EpdmTube", "EPDM TUBE", true);
            DbWireProtectionType typeFelt = new DbWireProtectionType("Felt", "FELT", true);
            DbWireProtectionType typeFlexGuard = new DbWireProtectionType("FlexGuard", "FLEX GUARD", true);
            DbWireProtectionType typeFlexWrap = new DbWireProtectionType("FlexWrap", "FLEXWRAP", true);
            DbWireProtectionType typeFoam = new DbWireProtectionType("Foam", "FOAM", true);
            DbWireProtectionType typeGab = new DbWireProtectionType("Gab", "GAB", true);
            DbWireProtectionType typeGaineScroll = new DbWireProtectionType("GaineScroll", "GAINE SCROLL", true);
            DbWireProtectionType typeGlassFiber = new DbWireProtectionType("GlassFiber", "GLASS FIBER", true);
            DbWireProtectionType typeHarnaSleeve = new DbWireProtectionType("HarnaSleeve", "HARNASLEEVE", true);
            DbWireProtectionType typePaperTape = new DbWireProtectionType("PaperTape", "PAPER TAPE", true);
            DbWireProtectionType typePlasticCloth = new DbWireProtectionType("PlasticCloth", "PLASTIC CLOTH", true);
            DbWireProtectionType typePolyesterSleeve = new DbWireProtectionType("PolyesterSleeve", "POLYESTER SLEEVE", true);
            DbWireProtectionType typePolyesterTape = new DbWireProtectionType("PolyesterTape", "POLYESTER TAPE", true);
            DbWireProtectionType typePpTape = new DbWireProtectionType("PpTape", "PP TAPE", true);
            DbWireProtectionType typePvcSheet = new DbWireProtectionType("PvcSheet", "PVC SHEET", true);
            DbWireProtectionType typePvcTape = new DbWireProtectionType("PvcTape", "PVC TAPE", true);
            DbWireProtectionType typePvcTube = new DbWireProtectionType("PvcTube", "PVC TUBE", true);
            DbWireProtectionType typeScrollPvc = new DbWireProtectionType("ScrollPvc", "SCROLL PVC", true);
            DbWireProtectionType typeSmoothTube = new DbWireProtectionType("SmoothTube", "SMOOTH TUBE", true);
            DbWireProtectionType typeTaefa = new DbWireProtectionType("Taefa", "TAEFA", true);
            DbWireProtectionType typeTwistedTube = new DbWireProtectionType("TwistedTube", "TWISTED TUBE", true);
            DbWireProtectionType typeWeavedSleeve = new DbWireProtectionType("WeavedSleeve", "WEAVED SLEEVE", true);
            DbWireProtectionType typeWovenSleeve = new DbWireProtectionType("WovenSleeve", "WOVEN SLEEVE", true);

            builder.HasData(
                typeNotApplicable,
                typeNone,
                typeCorrugateTube,
                typeCottonTape,
                typeCurlWrap,
                typeDuctSealed,
                typeEmiHv,
                typeEpdmTube,
                typeFelt,
                typeFlexGuard,
                typeFlexWrap,
                typeFoam,
                typeGab,
                typeGaineScroll,
                typeGlassFiber,
                typeHarnaSleeve,
                typePaperTape,
                typePlasticCloth,
                typePolyesterSleeve,
                typePolyesterTape,
                typePpTape,
                typePvcSheet,
                typePvcTape,
                typePvcTube,
                typeScrollPvc,
                typeSmoothTube,
                typeTaefa,
                typeTwistedTube,
                typeWeavedSleeve,
                typeWovenSleeve
            );
        }
    }
}
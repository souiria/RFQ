namespace CDb.Data.Configuration.Masters
{
    public class DbMiscellaneousComponentTypeConfiguration : IEntityTypeConfiguration<DbMiscellaneousComponentType>
    {
        public void Configure(EntityTypeBuilder<DbMiscellaneousComponentType> builder)
        {
            builder.ToTable("MiscellaneousComponentTypes");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(m => m.Code)
                .IsUnique();
            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(m => m.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbMiscellaneousComponentType> builder)
        {
            DbMiscellaneousComponentType miscUnknown = new DbMiscellaneousComponentType("Unknown", "Unknown", true);
            DbMiscellaneousComponentType miscBatteryHolder = new DbMiscellaneousComponentType("BatteryHolder", "BAT FIXATION", true);
            DbMiscellaneousComponentType miscAccessoryBox = new DbMiscellaneousComponentType("AccessoryBox", "ACC BOX", true);
            DbMiscellaneousComponentType miscBECB = new DbMiscellaneousComponentType("BECB", "BECB", true);
            DbMiscellaneousComponentType miscBEND = new DbMiscellaneousComponentType("BEND", "BEND", true);
            DbMiscellaneousComponentType miscBFAV = new DbMiscellaneousComponentType("BFAV", "BFAV", true);
            DbMiscellaneousComponentType miscBONN = new DbMiscellaneousComponentType("BONN", "BONN", true);
            DbMiscellaneousComponentType miscBracket = new DbMiscellaneousComponentType("Bracket", "BRACKET", true);
            DbMiscellaneousComponentType miscBubbleBag = new DbMiscellaneousComponentType("BubbleBag", "BUBBLE BAG", true);
            DbMiscellaneousComponentType miscCPA = new DbMiscellaneousComponentType("CPA", "CPA", true);
            DbMiscellaneousComponentType miscDoubleFaceTape = new DbMiscellaneousComponentType("DoubleFaceTape", "DOUBLE FACE TAPE", true);
            DbMiscellaneousComponentType miscERFBBoxAssembly = new DbMiscellaneousComponentType("ERFBBoxAssembly", "ERFB BOX ASSY", true);
            DbMiscellaneousComponentType miscFakraSubConnector = new DbMiscellaneousComponentType("FakraSubConnector", "FAKRA SUB CONNECTOR", true);
            DbMiscellaneousComponentType miscFerrite = new DbMiscellaneousComponentType("Ferrite", "FERRITE", true);
            DbMiscellaneousComponentType miscFerrule = new DbMiscellaneousComponentType("Ferrule", "FERRULE", true);
            DbMiscellaneousComponentType miscFoamBox = new DbMiscellaneousComponentType("FoamBox", "FOAM BLOCK", true);
            DbMiscellaneousComponentType miscFuseRelayBox = new DbMiscellaneousComponentType("FuseRelayBox", "FUSE/RELAY BOX", true);
            DbMiscellaneousComponentType miscGrid = new DbMiscellaneousComponentType("Grid", "GRID", true);
            DbMiscellaneousComponentType miscIdentificationLabel = new DbMiscellaneousComponentType("IdentificationLabel", "IDENT. LABEL", true);
            DbMiscellaneousComponentType miscLabel = new DbMiscellaneousComponentType("Label", "LABEL", true);
            DbMiscellaneousComponentType miscLever = new DbMiscellaneousComponentType("Lever", "LEVER", true);
            DbMiscellaneousComponentType miscLock = new DbMiscellaneousComponentType("Lock", "LOCK", true);
            DbMiscellaneousComponentType miscNut = new DbMiscellaneousComponentType("Nut", "NUT", true);
            DbMiscellaneousComponentType miscOptionTape = new DbMiscellaneousComponentType("OptionTape", "OPTION TAPE", true);
            DbMiscellaneousComponentType miscPaperBubble = new DbMiscellaneousComponentType("PaperBubble", "PAPER BUBBLE", true);
            DbMiscellaneousComponentType miscPaperSheet = new DbMiscellaneousComponentType("PaperSheet", "PAPER SHEET", true);
            DbMiscellaneousComponentType miscPEB = new DbMiscellaneousComponentType("PEB", "PEB", true);
            DbMiscellaneousComponentType miscPlasticBag = new DbMiscellaneousComponentType("PlasticBag", "PLASTIC BAG", true);
            DbMiscellaneousComponentType miscPlasticClamp = new DbMiscellaneousComponentType("PlasticClamp", "PLASTIC CLAMP", true);
            DbMiscellaneousComponentType miscAssyClip = new DbMiscellaneousComponentType("AssyClip", "POSTICHE", true);
            DbMiscellaneousComponentType miscProtectionLabel = new DbMiscellaneousComponentType("ProtectionLabel", "PROTECT. LABEL", true);
            DbMiscellaneousComponentType miscRearHolder = new DbMiscellaneousComponentType("RearHolder", "REAR HOLDER", true);
            DbMiscellaneousComponentType miscRelayBox = new DbMiscellaneousComponentType("RelayBox", "RELAY BOX", true);
            DbMiscellaneousComponentType miscScrew = new DbMiscellaneousComponentType("Screw", "SCREW", true);
            DbMiscellaneousComponentType miscShell = new DbMiscellaneousComponentType("Shell", "SHELL", true);
            DbMiscellaneousComponentType miscSpotTape = new DbMiscellaneousComponentType("SpotTape", "SPOT TAPE", true);
            DbMiscellaneousComponentType miscSTRAP = new DbMiscellaneousComponentType("STRAP", "STRAP", true);
            DbMiscellaneousComponentType miscTE = new DbMiscellaneousComponentType("TE", "TE", true);
            DbMiscellaneousComponentType miscTestLabel = new DbMiscellaneousComponentType("TestLabel", "TEST LABEL", true);
            DbMiscellaneousComponentType miscTieWrap = new DbMiscellaneousComponentType("TieWrap", "TIE WRAP", true);
            DbMiscellaneousComponentType miscTPA = new DbMiscellaneousComponentType("TPA", "TPA", true);
            DbMiscellaneousComponentType miscUltrasonicWeld = new DbMiscellaneousComponentType("UltrasonicWeld", "ULTRASONIC WELD", true);
            DbMiscellaneousComponentType miscWarningLabel = new DbMiscellaneousComponentType("WarningLabel", "WARNING LABEL", true);
            DbMiscellaneousComponentType miscWireClamp = new DbMiscellaneousComponentType("WireClamp", "WIRE CLAMP", true);

            builder.HasData(
                miscUnknown,
                miscBatteryHolder,
                miscAccessoryBox,
                miscBECB,
                miscBEND,
                miscBFAV,
                miscBONN,
                miscBracket,
                miscBubbleBag,
                miscCPA,
                miscDoubleFaceTape,
                miscERFBBoxAssembly,
                miscFakraSubConnector,
                miscFerrite,
                miscFerrule,
                miscFoamBox,
                miscFuseRelayBox,
                miscGrid,
                miscIdentificationLabel,
                miscLabel,
                miscLever,
                miscLock,
                miscNut,
                miscOptionTape,
                miscPaperBubble,
                miscPaperSheet,
                miscPEB,
                miscPlasticBag,
                miscPlasticClamp,
                miscAssyClip,
                miscProtectionLabel,
                miscRearHolder,
                miscRelayBox,
                miscScrew,
                miscShell,
                miscSpotTape,
                miscSTRAP,
                miscTE,
                miscTestLabel,
                miscTieWrap,
                miscTPA,
                miscUltrasonicWeld,
                miscWarningLabel,
                miscWireClamp
            );
        }
    }
}
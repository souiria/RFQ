namespace CDb.Data.Configuration.Masters
{
    public class DbMiscComponentTypeConfiguration : IEntityTypeConfiguration<DbMiscComponentType>
    {
        public void Configure(EntityTypeBuilder<DbMiscComponentType> builder)
        {
            builder.ToTable("MiscComponentTypes");
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

        static void AddSeedData(EntityTypeBuilder<DbMiscComponentType> builder)
        {
            DbMiscComponentType miscUnknown = new DbMiscComponentType("Unknown", "Unknown", true);
            DbMiscComponentType miscBatteryHolder = new DbMiscComponentType("BatteryHolder", "BAT FIXATION", true);
            DbMiscComponentType miscAccessoryBox = new DbMiscComponentType("AccessoryBox", "ACC BOX", true);
            DbMiscComponentType miscBECB = new DbMiscComponentType("BECB", "BECB", true);
            DbMiscComponentType miscBEND = new DbMiscComponentType("BEND", "BEND", true);
            DbMiscComponentType miscBFAV = new DbMiscComponentType("BFAV", "BFAV", true);
            DbMiscComponentType miscBONN = new DbMiscComponentType("BONN", "BONN", true);
            DbMiscComponentType miscBracket = new DbMiscComponentType("Bracket", "BRACKET", true);
            DbMiscComponentType miscBubbleBag = new DbMiscComponentType("BubbleBag", "BUBBLE BAG", true);
            DbMiscComponentType miscCPA = new DbMiscComponentType("CPA", "CPA", true);
            DbMiscComponentType miscDoubleFaceTape = new DbMiscComponentType("DoubleFaceTape", "DOUBLE FACE TAPE", true);
            DbMiscComponentType miscERFBBoxAssembly = new DbMiscComponentType("ERFBBoxAssembly", "ERFB BOX ASSY", true);
            DbMiscComponentType miscFakraSubConnector = new DbMiscComponentType("FakraSubConnector", "FAKRA SUB CONNECTOR", true);
            DbMiscComponentType miscFerrite = new DbMiscComponentType("Ferrite", "FERRITE", true);
            DbMiscComponentType miscFerrule = new DbMiscComponentType("Ferrule", "FERRULE", true);
            DbMiscComponentType miscFoamBox = new DbMiscComponentType("FoamBox", "FOAM BLOCK", true);
            DbMiscComponentType miscFuseRelayBox = new DbMiscComponentType("FuseRelayBox", "FUSE/RELAY BOX", true);
            DbMiscComponentType miscGrid = new DbMiscComponentType("Grid", "GRID", true);
            DbMiscComponentType miscIdentificationLabel = new DbMiscComponentType("IdentificationLabel", "IDENT. LABEL", true);
            DbMiscComponentType miscLabel = new DbMiscComponentType("Label", "LABEL", true);
            DbMiscComponentType miscLever = new DbMiscComponentType("Lever", "LEVER", true);
            DbMiscComponentType miscLock = new DbMiscComponentType("Lock", "LOCK", true);
            DbMiscComponentType miscNut = new DbMiscComponentType("Nut", "NUT", true);
            DbMiscComponentType miscOptionTape = new DbMiscComponentType("OptionTape", "OPTION TAPE", true);
            DbMiscComponentType miscPaperBubble = new DbMiscComponentType("PaperBubble", "PAPER BUBBLE", true);
            DbMiscComponentType miscPaperSheet = new DbMiscComponentType("PaperSheet", "PAPER SHEET", true);
            DbMiscComponentType miscPEB = new DbMiscComponentType("PEB", "PEB", true);
            DbMiscComponentType miscPlasticBag = new DbMiscComponentType("PlasticBag", "PLASTIC BAG", true);
            DbMiscComponentType miscPlasticClamp = new DbMiscComponentType("PlasticClamp", "PLASTIC CLAMP", true);
            DbMiscComponentType miscAssyClip = new DbMiscComponentType("AssyClip", "POSTICHE", true);
            DbMiscComponentType miscProtectionLabel = new DbMiscComponentType("ProtectionLabel", "PROTECT. LABEL", true);
            DbMiscComponentType miscRearHolder = new DbMiscComponentType("RearHolder", "REAR HOLDER", true);
            DbMiscComponentType miscRelayBox = new DbMiscComponentType("RelayBox", "RELAY BOX", true);
            DbMiscComponentType miscScrew = new DbMiscComponentType("Screw", "SCREW", true);
            DbMiscComponentType miscShell = new DbMiscComponentType("Shell", "SHELL", true);
            DbMiscComponentType miscSpotTape = new DbMiscComponentType("SpotTape", "SPOT TAPE", true);
            DbMiscComponentType miscSTRAP = new DbMiscComponentType("STRAP", "STRAP", true);
            DbMiscComponentType miscTE = new DbMiscComponentType("TE", "TE", true);
            DbMiscComponentType miscTestLabel = new DbMiscComponentType("TestLabel", "TEST LABEL", true);
            DbMiscComponentType miscTieWrap = new DbMiscComponentType("TieWrap", "TIE WRAP", true);
            DbMiscComponentType miscTPA = new DbMiscComponentType("TPA", "TPA", true);
            DbMiscComponentType miscUltrasonicWeld = new DbMiscComponentType("UltrasonicWeld", "ULTRASONIC WELD", true);
            DbMiscComponentType miscWarningLabel = new DbMiscComponentType("WarningLabel", "WARNING LABEL", true);
            DbMiscComponentType miscWireClamp = new DbMiscComponentType("WireClamp", "WIRE CLAMP", true);

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
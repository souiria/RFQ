namespace CDb.Extensions.GrpcMapping
{
    public static class CompositeComponentExtensions
    {
        public static CompositeComponentGrpc FromEntity(this DbComponent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ComponentGrpc componentGrpc = ComponentExtensions.FromEntity(entity);

            CompositeComponentGrpc grpc = new CompositeComponentGrpc();
            grpc.ComponentGrpc = componentGrpc;
            ComponentType componentType = (ComponentType)entity.ComponentType;
            switch (componentType)
            {
                case ComponentType.Cable:
                    grpc.CableGrpc = CableExtensions.FromEntity((DbCable)entity);
                    break;
                case ComponentType.Clip:
                    grpc.ClipGrpc = ClipExtensions.FromEntity((DbClip)entity);
                    break;
                case ComponentType.Connector:
                    grpc.ConnectorGrpc = ConnectorExtensions.FromEntity((DbConnector)entity);
                    break;
                case ComponentType.Cover:
                    grpc.CoverGrpc = CoverExtensions.FromEntity((DbCover)entity);
                    break;
                case ComponentType.Diode:
                    grpc.DiodeGrpc = DiodeExtensions.FromEntity((DbDiode)entity);
                    break;
                case ComponentType.Eyelet:
                    grpc.EyeletGrpc = EyeletExtensions.FromEntity((DbEyelet)entity);
                    break;
                case ComponentType.Fuse:
                    grpc.FuseGrpc = FuseExtensions.FromEntity((DbFuse)entity);
                    break;
                case ComponentType.Grommet:
                    grpc.GrommetGrpc = GrommetExtensions.FromEntity((DbGrommet)entity);
                    break;
                case ComponentType.Housing:
                    grpc.HousingGrpc = HousingExtensions.FromEntity((DbHousing)entity);
                    break;
                case ComponentType.MiscellaneousComponent:
                    grpc.MiscellaneousComponentGrpc = MiscellaneousComponentExtensions.FromEntity((DbMiscellaneousComponent)entity);
                    break;
                case ComponentType.Plug:
                    grpc.PlugGrpc = PlugExtensions.FromEntity((DbPlug)entity);
                    break;
                case ComponentType.Relay:
                    grpc.RelayGrpc = RelayExtensions.FromEntity((DbRelay)entity);
                    break;
                case ComponentType.Seal:
                    grpc.SealGrpc = SealExtensions.FromEntity((DbSeal)entity);
                    break;
                case ComponentType.Shield:
                    grpc.ShieldGrpc = ShieldExtensions.FromEntity((DbShield)entity);
                    break;
                case ComponentType.Sleeve:
                    grpc.SleeveGrpc = SleeveExtensions.FromEntity((DbSleeve)entity);
                    break;
                case ComponentType.SubAssembly:
                    grpc.SubAssemblyGrpc = SubAssemblyExtensions.FromEntity((DbSubAssembly)entity);
                    break;
                case ComponentType.Support:
                    grpc.SupportGrpc = SupportExtensions.FromEntity((DbSupport)entity);
                    break;
                case ComponentType.Terminal:
                    grpc.TerminalGrpc = TerminalExtensions.FromEntity((DbTerminal)entity);
                    break;
                case ComponentType.Wire:
                    grpc.WireGrpc = WireExtensions.FromEntity((DbWire)entity);
                    break;
                case ComponentType.WireProtection:
                    grpc.WireProtectionGrpc = WireProtectionExtensions.FromEntity((DbWireProtection)entity);
                    break;
                // Add more cases for other component types as needed
                default:
                    throw new ArgumentException($"Unsupported Component Type: {componentType}");
            }

            return grpc;
        }
        public static void ToEntity(this ComponentGrpc grpc, DbComponent entity)
        {

            if (string.IsNullOrEmpty(grpc.Id) || Guid.Parse(grpc.Id) == Guid.Empty)
            {
                throw new ArgumentException("Invalid ComponentGrpc Id.");
            }

            if (grpc.ComponentType == null || grpc.ComponentType == 0)
            {
                throw new ArgumentException("Invalid ComponentGrpc Type.");
            }

            entity.Id = Guid.Parse(grpc.Id);
            entity.ComponentType = (ComponentType)grpc.ComponentType;
            entity.SheetNumber = grpc.SheetNumber ?? 0;
            entity.Name = grpc.Name ?? string.Empty;
            entity.Issue = grpc.Issue;
            entity.ComponentStatus = grpc.ComponentStatus is null || grpc.ComponentStatus == 0 ? ComponentStatus.Unknown : (ComponentStatus)grpc.ComponentStatus;
            entity.Weight = grpc.Weight is null || grpc.Weight == 0 ? 0.0m : (decimal)grpc.Weight;
            entity.Comment = grpc.Comment;
            entity.TypeCode = grpc.TypeCode;
            entity.UserField4 = grpc.UserField4;
            entity.UserField5 = grpc.UserField5;
            entity.GraphicSymbol = grpc.GraphicSymbol;
            entity.InDb = grpc.InDb;
            entity.PfReferencePsa = grpc.PfReferencePsa;
            entity.VerifiedToLatestDrawing = grpc.VerifiedToLatestDrawing;
            entity.UpdateInCaphDb = grpc.UpdateInCaphDb;
            entity.StatusPv = grpc.StatusPv;
            entity.DatePv = grpc.DatePv is null ? null : grpc.DatePv.ToDateTime();
            entity.StatusBrut = grpc.StatusBrut;
            entity.Pilot = grpc.Pilot;
            entity.DbUpdatedPv = grpc.DbUpdatedPv is null ? null : grpc.DbUpdatedPv.ToDateTime();
            entity.IsReplacement = grpc.IsReplacement ?? false;
            entity.TemperatureLow = grpc.TemperatureLow ?? 0;
            entity.TemperatureHigh = grpc.TemperatureHigh ?? 0;
            entity.TemperatureRangeId = grpc.TemperatureRangeId is null ? Guid.Parse("DD8FDC91-72A3-4AAF-AB22-D27877BB0B0E") : Guid.Parse(grpc.TemperatureRangeId); // this is the T1, by default
            entity.UnitOfMeasureId = grpc.UnitOfMeasureId is null ? Guid.Empty : Guid.Parse(grpc.UnitOfMeasureId);
            entity.ComponentStatus = ComponentStatus.Unknown;

            entity.CreatedById = grpc.CreatedById is null ? Guid.Empty : Guid.Parse(grpc.CreatedById);
            entity.Created = grpc.Created is null ? DateTime.UtcNow : grpc.Created.ToDateTime();
            entity.UpdatedById = grpc.UpdatedById is null ? Guid.Empty : Guid.Parse(grpc.UpdatedById);
            entity.Updated = grpc.Updated is null ? null : grpc.Updated.ToDateTime();
            //ValidatedById = Guid.Empty;
            //Validated = grpc.Validated.ToDateTime();

            //entity.ReplacedComponents = new List<DbComponent>();
            //entity.FileNames = new List<DbFileName>();
            //entity.Contacts = new List<DbPerson>();
            //entity.Partners = new List<DbPartner>();
            //entity.PartNumbers = new List<DbPartNumber>();
            //entity.Tags = new List<DbTag>();
            //entity.Children = new List<DbComponent>();
            //entity.Parents = new List<DbComponent>();
        }
        // the not that easy part
        public static DbComponent ToEntity(this CompositeComponentGrpc grpc)
        {
            if (grpc == null || grpc.ComponentGrpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "grpc/ComponentGrpc object cannot be null.");
            }

            if (grpc.ComponentGrpc.ComponentType == null || grpc.ComponentGrpc.ComponentType == 0)
            {
                throw new ArgumentException("Invalid ComponentGrpc Type.");
            }

            // Create a new DbComponent instance
            DbComponent entity = (ComponentType)grpc.ComponentGrpc.ComponentType switch
            {
                ComponentType.Cable => new DbCable(),
                ComponentType.Clip => new DbClip(),
                ComponentType.Connector => new DbConnector(),
                ComponentType.Cover => new DbCover(),
                ComponentType.Diode => new DbDiode(),
                ComponentType.Eyelet => new DbEyelet(),
                ComponentType.Fuse => new DbFuse(),
                ComponentType.Grommet => new DbGrommet(),
                ComponentType.Housing => new DbHousing(),
                ComponentType.MiscellaneousComponent => new DbMiscellaneousComponent(),
                ComponentType.Plug => new DbPlug(),
                ComponentType.Relay => new DbRelay(),
                ComponentType.Seal => new DbSeal(),
                ComponentType.Shield => new DbShield(),
                ComponentType.Sleeve => new DbSleeve(),
                ComponentType.SubAssembly => new DbSubAssembly(),
                ComponentType.Support => new DbSupport(),
                ComponentType.Terminal => new DbTerminal(),
                ComponentType.Wire => new DbWire(),
                ComponentType.WireProtection => new DbWireProtection(),
                _ => throw new ArgumentException("Unsupported Component Type for CompositeComponentGrpc.")
            };
            // transfer properties from DbComponent
            grpc.ComponentGrpc.ToEntity(entity);

            // map specific component types
            switch ((ComponentType)grpc.ComponentGrpc.ComponentType)
            {
                case ComponentType.Cable:
                    grpc.CableGrpc.ToEntity((DbCable)entity);
                break;
                case ComponentType.Clip:
                    grpc.ClipGrpc.ToEntity((DbClip)entity);
                break;
                case ComponentType.Connector:
                    grpc.ConnectorGrpc.ToEntity((DbConnector)entity);
                break;
                case ComponentType.Cover:
                    grpc.CoverGrpc.ToEntity((DbCover)entity);
                break;
                case ComponentType.Diode:
                    grpc.DiodeGrpc.ToEntity((DbDiode)entity);
                break;
                case ComponentType.Eyelet:
                    grpc.EyeletGrpc.ToEntity((DbEyelet)entity);
                break;
                case ComponentType.Fuse:
                    grpc.FuseGrpc.ToEntity((DbFuse)entity);
                break;
                case ComponentType.Grommet:
                    grpc.GrommetGrpc.ToEntity((DbGrommet)entity);
                break;
                case ComponentType.Housing:
                    grpc.HousingGrpc.ToEntity((DbHousing)entity);
                break;
                case ComponentType.MiscellaneousComponent:
                    grpc.MiscellaneousComponentGrpc.ToEntity((DbMiscellaneousComponent)entity);
                break;
                case ComponentType.Plug:
                    grpc.PlugGrpc.ToEntity((DbPlug)entity);
                break;
                case ComponentType.Relay:
                    grpc.RelayGrpc.ToEntity((DbRelay)entity);
                break;
                case ComponentType.Seal:
                    grpc.SealGrpc.ToEntity((DbSeal)entity);
                break;
                case ComponentType.Shield:
                    grpc.ShieldGrpc.ToEntity((DbShield)entity);
                break;
                case ComponentType.Sleeve:
                    grpc.SleeveGrpc.ToEntity((DbSleeve)entity);
                break;
                case ComponentType.SubAssembly:
                    grpc.SubAssemblyGrpc.ToEntity((DbSubAssembly)entity);
                break;
                case ComponentType.Support:
                    grpc.SupportGrpc.ToEntity((DbSupport)entity);
                break;
                case ComponentType.Terminal:
                    grpc.TerminalGrpc.ToEntity((DbTerminal)entity);
                break;
                case ComponentType.Wire:
                    grpc.WireGrpc.ToEntity((DbWire)entity);
                break;
                case ComponentType.WireProtection:
                    grpc.WireProtectionGrpc.ToEntity((DbWireProtection)entity);
                break;
                default:
                    throw new NotSupportedException($"Component type {grpc.ComponentGrpc.ComponentType} is not supported for CompositeComponentGrpc.");
            }

            return entity;
        }
    }
}

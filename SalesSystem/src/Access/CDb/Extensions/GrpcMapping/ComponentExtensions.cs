namespace CDb.Extensions.GrpcMapping
{
    public static class ComponentExtensions
    {
        public static ComponentGrpc FromDb(this DbComponent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ComponentGrpc grpc = new ComponentGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.ComponentType = (int)entity.ComponentType;
            grpc.SheetNumber = entity.SheetNumber;
            grpc.Name = entity.Name;
            grpc.Issue = entity.Issue;
            grpc.ComponentStatus = (int)entity.ComponentStatus;
            grpc.Weight = (double)entity.Weight;
            grpc.Comment = entity.Comment;
            grpc.TypeCode = entity.TypeCode;
            grpc.UserField4 = entity.UserField4;
            grpc.UserField5 = entity.UserField5;
            grpc.GraphicSymbol = entity.GraphicSymbol ?? false;
            grpc.InDb = entity.InDb;
            grpc.PfReferencePsa = entity.PfReferencePsa;
            grpc.VerifiedToLatestDrawing = entity.VerifiedToLatestDrawing ?? false;
            grpc.UpdateInCaphDb = entity.UpdateInCaphDb ?? false;
            grpc.StatusPv = entity.StatusPv;
            grpc.DatePv = entity.DatePv is null ? null : Timestamp.FromDateTime((DateTime)entity.DatePv);
            grpc.StatusBrut = entity.StatusBrut;
            grpc.Pilot = entity.Pilot;
            grpc.DbUpdatedPv = entity.DbUpdatedPv is null ? null : Timestamp.FromDateTime((DateTime)entity.DbUpdatedPv);

            grpc.Created = Timestamp.FromDateTime(entity.Created);
            grpc.CreatedById = entity.CreatedById.ToString();
            grpc.Updated = entity.Updated is null ? null : Timestamp.FromDateTime((DateTime)entity.Updated);
            grpc.UpdatedById = entity.UpdatedById?.ToString();
            grpc.Validated = entity.Validated is null ? null : Timestamp.FromDateTime((DateTime)entity.Validated);
            grpc.ValidatedById = entity.ValidatedById.ToString();

            grpc.GroupName = entity.GroupName;
            grpc.IsReplacement = entity.IsReplacement;
            grpc.ReplacedComponentId = entity.ReplacedComponentId?.ToString();

            grpc.TemperatureLow = entity.TemperatureLow;
            grpc.TemperatureHigh = entity.TemperatureHigh;
            grpc.TemperatureRangeId = entity.TemperatureRangeId?.ToString();

            //grpc.FileNames = entity.FileNames?.Select(fn => fn.FromDb()).ToList() ?? new List<FileNameGrpc>();
            //grpc.Contacts = entity.Contacts?.Select(c => c.FromDb()).ToList() ?? new List<PersonGrpc>();
            //grpc.Partners = entity.Partners?.Select(p => p.FromDb()).ToList() ?? new List<PartnerGrpc>();
            //grpc.PartNumbers = entity.PartNumbers?.Select(pn => pn.FromDb()).ToList() ?? new List<PartNumberGrpc>();
            //grpc.Tags = entity.Tags?.Select(t => t.FromDb()).ToList() ?? new List<TagGrpc>();

            grpc.UnitOfMeasureId = entity.UnitOfMeasureId?.ToString();

            return grpc;
        }
    }
}
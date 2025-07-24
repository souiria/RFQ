namespace CDb.Extensions.GrpcMapping.Components
{
    public static class CoverExtensions
    {
        public static CoverGrpc FromDb(this DbCover entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            CoverGrpc grpc = new CoverGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.CoverTypeId = entity.CoverTypeId.ToString();
            grpc.Diameter = (double)entity.Diameter;
            grpc.Length = (double)entity.Length;
            grpc.Width = (double)entity.Width;
            grpc.HasNoiseDampening = entity.HasNoiseDampening;
            grpc.IsTearable = entity.IsTearable;
            grpc.IsPrecut = entity.IsPreCut;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbCover ToDb(this CoverGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbCover entity = new DbCover();
            entity.Id = Guid.Parse(grpc.Id);
            entity.CoverTypeId = string.IsNullOrEmpty(grpc.CoverTypeId) ? null : Guid.Parse(grpc.CoverTypeId);
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Length = grpc.Length.ToDecimal();
            entity.Width = grpc.Width.ToDecimal();
            entity.HasNoiseDampening = grpc.HasNoiseDampening ?? false;
            entity.IsTearable = grpc.IsTearable ?? false;
            entity.IsPreCut = grpc.IsPrecut ?? false;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}

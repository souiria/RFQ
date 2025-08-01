namespace CDb.Extensions.GrpcMapping.Components
{
    public static class EyeletExtensions
    {
        public static EyeletGrpc FromEntity(this DbEyelet entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            EyeletGrpc grpc = new EyeletGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.StudSize = (double?)entity.StudSize;
            grpc.Thickness = (double?)entity.Thickness;
            grpc.Angle = entity.Angle;
            grpc.IsWaterproof = entity.IsWaterproof;
            grpc.IsCr6Free = entity.IsCr6Free;
            grpc.Family = entity.Family;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.PlatingType = (int)entity.PlatingType;

            return grpc;
        }
        public static void ToEntity(this EyeletGrpc grpc, DbEyelet entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.StudSize = grpc.StudSize.ToDecimal();
            entity.Thickness = grpc.Thickness.ToDecimal();
            entity.Angle = grpc.Angle ?? 0;
            entity.IsWaterproof = grpc.IsWaterproof ?? false;
            entity.IsCr6Free = grpc.IsCr6Free ?? false;
            entity.Family = grpc.Family;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.PlatingType = (PlatingType)(grpc.PlatingType ?? 0);
        }
    }
}

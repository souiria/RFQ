namespace CDb.Extensions.GrpcMapping.Components
{
    public static class ClipExtensions
    {
        public static ClipGrpc FromEntity(this DbClip entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ClipGrpc grpc = new ClipGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.ClipTypeId = entity.ClipTypeId.ToString();
            grpc.TieType = (int)entity.TieType;
            grpc.DimensionCode = entity.DimensionCode;
            grpc.ThicknessCode = entity.ThicknessCode;
            grpc.Length = (double)entity.Length;
            grpc.IsDoubleHarness = entity.IsDoubleHarness;
            grpc.ClipOrientationStart = entity.ClipOrientationStart;
            grpc.ClipOrientationEnd = entity.ClipOrientationEnd;
            grpc.AdditionalInformation = entity.AdditionalInformation;

            return grpc;
        }
        public static void ToEntity(this ClipGrpc grpc, DbClip entity)
        {
            entity.ClipTypeId = Guid.Parse(grpc.ClipTypeId);
            entity.TieType = grpc.TieType is null ? TieType.Unknown : (TieType)grpc.TieType;
            entity.DimensionCode = grpc.DimensionCode;
            entity.ThicknessCode = grpc.ThicknessCode;
            entity.Length = grpc.Length is null ? 0.0m : (decimal)grpc.Length;
            entity.IsDoubleHarness = grpc.IsDoubleHarness ?? false;
            entity.ClipOrientationStart = grpc.ClipOrientationStart ?? 0;
            entity.ClipOrientationEnd = grpc.ClipOrientationEnd ?? 0;
            entity.AdditionalInformation = grpc.AdditionalInformation;

        }
    }
}

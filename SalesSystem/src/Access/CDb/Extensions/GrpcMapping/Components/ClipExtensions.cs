namespace CDb.Extensions.GrpcMapping.Components
{
    public static class ClipExtensions
    {
        public static ClipGrpc FromDb(this DbClip entity)
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
    }
}

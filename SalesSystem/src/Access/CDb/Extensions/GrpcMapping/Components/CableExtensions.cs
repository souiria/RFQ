namespace CDb.Extensions.GrpcMapping.Components
{
    public static class CableExtensions
    {
        public static CableGrpc FromEntity(this DbCable entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            CableGrpc grpc = new CableGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Color = (int)entity.Color;
            grpc.WireCount = entity.WireCount;
            grpc.WireCountCode = entity.WireCountCode;
            grpc.Length = (double)entity.Length;
            grpc.IsShielded = entity.IsShielded;

            return grpc;
        }
        public static void ToEntity(this CableGrpc grpc, DbCable entity)
        {
            entity.Color = grpc.Color is null ? ColorType.X : (ColorType)grpc.Color;
            entity.WireCount = grpc.WireCount ?? 0;
            entity.WireCountCode = grpc.WireCountCode ?? "";
            entity.Length = grpc.Length is null ? 0.0m : (decimal)grpc.Length;
            entity.IsShielded = grpc.IsShielded ?? false;
        }
    }
}

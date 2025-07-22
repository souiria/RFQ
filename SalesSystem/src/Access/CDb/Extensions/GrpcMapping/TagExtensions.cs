namespace CDb.Extensions.GrpcMapping
{
    public static class TagExtensions
    {
        public static TagGrpc FromEntity(this DbTag entity)
        {

            TagGrpc grpc = new TagGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.TagType = (int)entity.TagType;
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbTag ToEntity(this TagGrpc grpc)
        {
            DbTag entity = new DbTag();
            entity.Id = Guid.Parse(grpc.Id);
            entity.TagType = (grpc.TagType == 0 || grpc.TagType is null) ? TagType.None : (TagType)grpc.TagType;
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}

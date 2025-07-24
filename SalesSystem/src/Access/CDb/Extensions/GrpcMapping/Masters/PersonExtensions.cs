namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class PersonExtensions
    {
        public static PersonGrpc FromEntity(this DbPerson entity)
        {

            PersonGrpc grpc = new PersonGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.PersonType = (int)entity.PersonType;
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.Phone = entity.Phone;
            grpc.Email = entity.Email;
            grpc.Address = entity.Address;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbPerson ToEntity(this PersonGrpc grpc)
        {
            DbPerson entity = new DbPerson();
            entity.Id = Guid.Parse(grpc.Id);
            entity.PersonType = grpc.PersonType is null ? PersonType.Unknown : (PersonType)grpc.PersonType;
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.Phone = grpc.Phone;
            entity.Email = grpc.Email;
            entity.Address = grpc.Address;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}

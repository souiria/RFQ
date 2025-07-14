namespace SFS.CQRS.Query.CarModel
{
    public class GetAllCarModelQuery : IQuery<List<CarModelViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}


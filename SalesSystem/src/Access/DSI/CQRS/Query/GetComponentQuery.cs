namespace DSI.CQRS.Query
{
    public class GetComponentQuery : IQuery<List<ComponentGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}

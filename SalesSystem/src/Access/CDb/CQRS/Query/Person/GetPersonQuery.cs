namespace CDb.CQRS.Query.Person
{
    public class GetPersonsQuery : IQuery<List<PersonGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

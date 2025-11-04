namespace Unit4.CQRS.Query
{
    class GetUnit4InputProductsCountQuery : IQuery<int>
    {
        public string? PartNumber
        { get; set; }
        public string? Client
        { get; set; }
    }
}

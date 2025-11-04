namespace Unit4.CQRS.Specification
{
    sealed class GetUnit4InputProductsCountReadOnlySpec : Specification<DbAlgProductInput>
    {
        public GetUnit4InputProductsCountReadOnlySpec(string? partNumber, string? client)
        {
            Query
                .Where(x => x.Client == client && x.Article == partNumber)
                .AsNoTracking();
        }
    }
}

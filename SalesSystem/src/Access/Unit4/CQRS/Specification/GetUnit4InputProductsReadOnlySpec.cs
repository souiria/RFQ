namespace Unit4.CQRS.Specification
{
    sealed class GetUnit4InputProductsReadOnlySpec : Specification<DbAlgProductInput>
    {
        public GetUnit4InputProductsReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}

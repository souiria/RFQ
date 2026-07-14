namespace EDI.CQRS.Specification
{
    sealed class GetCustomerParameterReadOnlySpec : Specification<DbEdiCustomerParameter>
    {
        public GetCustomerParameterReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}

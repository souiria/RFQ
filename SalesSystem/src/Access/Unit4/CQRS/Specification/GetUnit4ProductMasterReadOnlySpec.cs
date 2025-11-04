namespace Unit4.CQRS.Specification
{
    sealed class GetUnit4ProductMasterReadOnlySpec : Specification<DbMinAlgArticle>
    {
        public GetUnit4ProductMasterReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}

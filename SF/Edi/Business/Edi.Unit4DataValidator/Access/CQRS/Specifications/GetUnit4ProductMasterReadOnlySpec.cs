using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetUnit4ProductMasterReadOnlySpec : Specification<DbMinAlgArticle>
{
    public GetUnit4ProductMasterReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}

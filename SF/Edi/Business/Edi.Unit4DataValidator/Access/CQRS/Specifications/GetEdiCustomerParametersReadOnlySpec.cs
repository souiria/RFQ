using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetEdiCustomerParametersReadOnlySpec : Specification<DbEdiCustomerParameter>
{
    public GetEdiCustomerParametersReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}
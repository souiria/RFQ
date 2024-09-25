namespace Edi.Unit4DataValidator.Common.MappingProfiles;
internal class EdiProfile : Profile
{
    public EdiProfile()
    {
        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();

        CreateMap<DbEdiInvoiceUnit4, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceUnit4>();

        CreateMap<DbUnit4SalesOrdersView, Unit4SalesOrdersViewDto>();
        CreateMap<Unit4SalesOrdersViewDto, DbUnit4SalesOrdersView>();
    }
}

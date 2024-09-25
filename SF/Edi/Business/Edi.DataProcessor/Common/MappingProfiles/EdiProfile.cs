namespace Edi.DataProcessor.Common.MappingProfiles;
internal class EdiProfile : Profile
{
    public EdiProfile()
    {
        CreateMap<DbExternalSalesPriceInformationView, ExternalSalesPriceInformationViewDto>();
        CreateMap<ExternalSalesPriceInformationViewDto, DbExternalSalesPriceInformationView>();

        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();

        CreateMap<DbEdiInvoiceInformation, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceInformation>();

        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();
    }
}

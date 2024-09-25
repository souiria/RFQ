namespace Edi.Unit4DataProcessor.Common.MappingProfiles;
internal class EdiProfile : Profile
{
    public EdiProfile()
    {
        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();

        CreateMap<DbEdiInvoiceInformation, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceInformation>();

        CreateMap<DbMinAlgArticle, Unit4ProductDto>();
        CreateMap<Unit4ProductDto, DbMinAlgArticle>();

        CreateMap<DbEdiInvoiceUnit4, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceUnit4>();
    }
}

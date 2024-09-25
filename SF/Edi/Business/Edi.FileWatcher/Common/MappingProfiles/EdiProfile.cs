namespace Edi.FileWatcher.Common.MappingProfiles;
internal class EdiProfile : Profile
{
    public EdiProfile()
    {
        CreateMap<DbEdiFileDataUpload, EdiFileDataUploadDto>();
        CreateMap<DbEdiFileDataUploadDuplicate, EdiFileDataUploadDto>();

        CreateMap<EdiFileDataUploadDto, DbEdiFileDataUpload>();
        CreateMap<EdiFileDataUploadDto, DbEdiFileDataUploadDuplicate>();

        CreateMap<DbEdiInvoiceInformation, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceInformation>();

        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();
    }
}

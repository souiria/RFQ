using Google.Protobuf.WellKnownTypes;

namespace Edi.Api.Common.MappingProfiles;

internal class EdiProfile : Profile
{
    public EdiProfile()
    {
        CreateMap<EdiInvoiceInformationDto, InvoiceInformationData>()
            .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.DispatchDate,
                act => act.MapFrom(src => src.DispatchDate.ToUniversalTime().ToTimestamp()))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CustomerLocationId, act => act.MapFrom(src => src.CustomerLocationId.ToString()));

        CreateMap<InvoiceInformationData, EdiInvoiceInformationDto>()
            .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.DispatchDate,
                act => act.MapFrom(src => src.DispatchDate.ToDateTime()))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => new Guid(src.Id)))
            .ForMember(dest => dest.CustomerLocationId, act => act.MapFrom(src => new Guid(src.CustomerLocationId)));



        CreateMap<DbEdiFileDataUploadDuplicate, EdiFileDataUploadDto>();

        CreateMap<EdiFileDataUploadDto, DbEdiFileDataUploadDuplicate>();

        CreateMap<DbEdiInvoiceInformation, EdiInvoiceInformationDto>();
        CreateMap<EdiInvoiceInformationDto, DbEdiInvoiceInformation>();

        CreateMap<DbEdiCustomerParameter, EdiCustomerParameterDto>();
        CreateMap<EdiCustomerParameterDto, DbEdiCustomerParameter>();

        //CreateMap<EdiInvoiceInformationDto, InvoiceInformationData>(MemberList.Source)
        //    .ForMember(dest => dest.Id, opt => opt.Ignore())
        //    .ForMember(dest => dest.CustomerLocationId,
        //        opt => opt.ConvertUsing(ValConverter.Instance, r => r.CustomerLocationId));


    }
}
public class ValConverter : IValueConverter<Guid, string>
{
    public static ValConverter Instance { get; } = new();
    public string Convert(Guid sourceMember, ResolutionContext context) => sourceMember.ToString("B");
}

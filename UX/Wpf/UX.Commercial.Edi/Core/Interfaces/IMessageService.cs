using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcServices;
using UX.Commercial.Edi.Core.Dto;

namespace UX.Commercial.Edi.Core.Interfaces
{
    public interface IMessageService
    {
        Task<ReprocessResponse> ReprocessDispatchData(string apiPath, ReprocessRequest request);
        Task<ReprocessResponse> ProcessDuplicatesRequest(string apiPath, ProcessDuplicatesRequest request);
        string GetMessage();
        IAsyncEnumerable<EdiInvoiceInformationDto> GetAllInvoiceInformation<T>(string apiPath, T request);
        IAsyncEnumerable<EdiInvoiceInformationDto> GetAllInvoiceInformationStream<T>(string apiPath, T request);

        IAsyncEnumerable<EdiFileDataUploadDto> GetDuplicateInvoiceInformation<T>(string apiPath, T request);
        IAsyncEnumerable<EdiFileDataUploadDto> GetDuplicateInvoiceInformationStream<T>(string apiPath, T request);


        IAsyncEnumerable<EdiCustomerParameterDto> GetAllCustomerParameter<T>(string apiPath, T request);
        IAsyncEnumerable<EdiCustomerParameterDto> GetAllCustomerParameterStream<T>(string apiPath, T request);
        Task<bool> SaveAllCustomerParameter<T>(string url, T request);
    }
}

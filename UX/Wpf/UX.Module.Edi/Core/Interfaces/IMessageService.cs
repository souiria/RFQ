using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcServices;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.Core.Messages.Responses;

namespace UX.Module.Edi.Core.Interfaces
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Security.DataFilter
{
    public interface IDataFilter : IService
    {
        Task<byte[]> GetAllDataFilters();
        Task<byte[]> GetDataFilter(Guid id);
        Task<byte[]> GetDataFiltersByFilter(byte[] objData);
        Task ProcessDataFilters(byte[] objData);
        Task<byte[]> GetDataFiltersByRequest(IEnumerable<Guid> guid, string serviceUri);
    }
}

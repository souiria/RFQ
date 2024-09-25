using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1FieldMaster : IService
    {
        Task<byte[]> GetAllFields();
        Task<byte[]> GetField(Guid id);
        Task<byte[]> GetFieldsByFilter(byte[] objData);
        Task ProcessFields(byte[] objData);
    }
}

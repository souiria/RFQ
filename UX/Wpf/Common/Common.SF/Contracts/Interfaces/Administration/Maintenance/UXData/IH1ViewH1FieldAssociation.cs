using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1ViewH1FieldAssociation : IService
    {
        Task<byte[]> GetViewFieldAssociation(Guid id);
        Task<byte[]> GetAllViewFieldAssociations();
        Task<byte[]> GetViewFieldAssociationsByFilter(byte[] filter);
        Task ProcessViewFieldAssociations(byte[] objData);
        Task<byte[]> GetFieldsByView(Guid id);
        Task<byte[]> GetViewsByField(Guid id);
    }
}

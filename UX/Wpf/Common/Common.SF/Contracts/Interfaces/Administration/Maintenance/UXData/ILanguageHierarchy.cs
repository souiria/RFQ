using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
   public interface ILanguageHierarchy : IService
    {
        Task<byte[]> GetLanguageHierarchy(Guid id);
        Task<byte[]> GetAllLanguageHierarchy();
        Task<byte[]> GetLanguageHierarchyByFilter(byte[] filter);
        Task ProcessLanguageHierarchy(byte[] objData);
        //Task<byte[]> GetLabelsByLanguage(Guid id);
    }
}

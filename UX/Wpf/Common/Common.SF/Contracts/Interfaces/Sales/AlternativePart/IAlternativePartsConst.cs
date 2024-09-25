using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.AlternativePart
{
    public interface IAlternativePartsConst: IService
    {
        Task<byte[]> GetMaterialGroups();
        Task<byte[]> GetMaterialTypes();
        Task<byte[]> GetColourList();
        Task<byte[]> GetPartCategoryList();
        Task<byte[]> GetGroupCodesList();
        Task<byte[]> GetPartClassList();
    }
}

using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance
{
    public interface IPerformance : IBase
    {
        Task<MaterialModel> GetUncompressed(Guid id);
        Task<byte[]> GetByMaterialNumberRange(string materialNumberFrom, string materialNumberTo);
        Task<byte[]> GetBaseMaterials(string materialNumberFrom, string materialNumberTo);
    }
}

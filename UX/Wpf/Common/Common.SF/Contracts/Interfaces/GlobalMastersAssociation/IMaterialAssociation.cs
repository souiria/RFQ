using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface IMaterialAssociation : IBase
    {
        Task<MaterialAssociationModel> GetUncompressed(Guid id);
        Task<string> Get(Guid id);
        Task<string> GetAll();
        //Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        //Task<string> ProcessOperation(string objData);
        //Task DatabaseRecovery(bool mergeData);
        //Task<string> GetGridDataByFilter(MaterialAssociationSearchModel materialAssociationSearchModel);
        //Task<string> GetMaterialData();
        //Task<string> GetGridDataByFilterWithBaseMaterial(MaterialAssociationSearchModel materialAssociationSearchModel);
        //Task<string> GetMaterialDataWithBaseMaterial();
    }
}

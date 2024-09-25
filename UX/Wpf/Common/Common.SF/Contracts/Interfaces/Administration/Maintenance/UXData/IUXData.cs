using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    /// <summary>
    /// Encapsulates all the interface of the UXData service
    /// </summary>
    public interface IUXData : IService, IHierarchy, IH1FunctionMaster, IH1FunctionH1ModuleAssociation, IH1ModuleMaster,
        IH1ModuleH1ViewAssociation, IH1ViewMaster, IH1ViewH1FieldAssociation, IH1FieldMaster, ILanguages, ILabels
    {

    }
}

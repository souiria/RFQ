using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    /// <summary>
    /// An interface that provide all the public method implementations for the Dsi service.
    /// </summary>
    public interface IDsi : IService, IBend, IBranchConfiguration, IBranchInsulation, IBranchInsulationThroughNode, ICavityMapping,
        ICentreStrip, ICircuitOption, IComponent, ICompositeDetail, ICompositeOption, IDataSynchronisation, IHarness, IHarnessScope,
        IManualBomQuantity, IMidWireComponent, IModuleChildDetail, IModuleCompatibility, IMulticoreSpecification, IPinMapping, IScope,
        IWireMulticoreMarker, IWireSpecification

    {
        //Does not implement any method itself.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.DsiAssociation
{
    public interface IDsiAssociation : IService, IBranchConfigurationBend, ICompositeDetailCircuitOption, IHarnessScopeScope, IPinMappingCavityMapping
    {
        //Does not implement any method itself.
    }
}

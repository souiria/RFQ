using Common.UX.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Contracts.Interfaces.Purchasing
{
    public interface IPurchasingSupplierMaterialViewModel: IUXLogger
    {
        Action LoadCompleted { get; set; }
    }
}
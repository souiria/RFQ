using Common.UX.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.UX.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface ISupplierMaterialAssociationViewModel 
    {
        Action LoadCompleted { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces.Administration.Maintenance
{
    public interface IHierarchyModel
    {
        bool? IsSelected { get; set; }
        bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces
{
    public interface IBaseHierarchy<T>
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        T Id { get; set; }
        bool IsActive { get; set; }
        bool? IsRowChecked { get; set; }
        Guid ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string Error { get; set; }
    }
}

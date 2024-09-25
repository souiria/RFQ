using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
    public interface ISupportDataContext
    {
        object DataContext { get; set; }        
    }
}

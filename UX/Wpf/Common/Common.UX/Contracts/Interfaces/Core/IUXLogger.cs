using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Contracts.Interfaces.Core
{
    public interface IUXLogger
    {
        void UXLoggingForDebug(string message);
        string Filepath { get; set; }
    }
}

using Common.UX.Wpf.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IStatusBarMessageHelper
    {
        void DisplayMessage(string message, string operationName, UXNotificationType messageType);
    }
}

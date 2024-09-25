using Common.UX.Wpf.Contracts.Models.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface ICustomDialogHelper
    {
        Task ErrorMessage(string title, string content);
        Task<bool?> GetConfirmation(string title, string content, UXDialogTypes type);
        bool? GetCloseConfirmation(string title, string content);
    }
}

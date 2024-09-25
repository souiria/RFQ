using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.Models
{
    public class UXH1FunctionMasterModel : H1FunctionMasterModel
    {
        private ObservableCollection<ModuleSecurityModel> _permissions;
        public ObservableCollection<ModuleSecurityModel> Permissions
        {
            get => _permissions;
            set => SetProperty(ref _permissions, value);
        }
    }
}

using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Security;

namespace SEWSE.H1.UX.Module.Core.OutlookBar
{
    public class DesignOutlookBarViewModel
    {
        public ObservableCollection<FunctionSecurityModel> OutlookBarGroups =>
            new ObservableCollection<FunctionSecurityModel>
            {
                //Global Master
                new FunctionSecurityModel
                {
                    DisplayId = 1,
                    DisplayName = "Global Masters",
                    ImageSource =
                        "pack://application:,,,/Common.UX;component/Resources/Images/GlobalMasters/Masters64.png",
                    Modules = new ObservableCollection<ModuleSecurityModel>
                    {
                        new ModuleSecurityModel
                        {
                            DisplayId = 1,
                            ImageSource =
                                "pack://application:,,,/Common.UX;component/Resources/Images/GlobalMasters/Masters64.png",
                            DisplayName = "Core Masters",
                            Views = new ObservableCollection<ViewSecurityModel>
                            {
                                new ViewSecurityModel
                                {
                                    DisplayId = 1,
                                    DisplayName = "Country",
                                    ViewName = "Country",
                                    ActiveDirectoryGroup = "",
                                    ImageSource =
                                        "pack://application:,,,/Common.UX;component/Resources/Images/WorldFlags/EU.png"
                                }
                            }
                        }
                    }


                }

            };
    }
}
        
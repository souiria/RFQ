using System.Collections.Generic;
using System.Windows;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Helpers;
using Prism.Regions;
using UX.Core.ShellDialog.Views;

namespace UX.Core.ShellDialog
{
    public class DialogService : IDialogService
    {
        IRegionManager _regionManager;
        FrameworkElement _dialogInstance;

        public DialogService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void ShowRibbonDialog(string navigationUri, NavigationParameters parameters = null, bool isModal = true, int Width = 0, int Height = 0)
        {
            RibbonDialog dialog = new RibbonDialog();
            _dialogInstance = dialog;

            if (Height != 0 && Width != 0)
            {
                dialog.Width = Width;
                dialog.Height = Height;
            }
            var newRegionManager = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(dialog, newRegionManager);

            if (parameters != null)
                newRegionManager.RequestNavigate(RegionNames.ContentRegion, navigationUri, parameters);
            else
                newRegionManager.RequestNavigate(RegionNames.ContentRegion, navigationUri);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            dialog.ShowInTaskbar = true;
            dialog.ShowActivated = true;
            dialog.Show(isModal);
        }
        public void ShowRibbonDialogForBaseViewModel(string navigationUri, NavigationParameters parameters = null, bool isModal = true, int Width = 0, int Height = 0)
        {
            RibbonDialog dialog = new RibbonDialog();
            _dialogInstance = dialog;
            if (Height != 0 && Width != 0)
            {
                dialog.Width = Width;
                dialog.Height = Height;
            }

            var newRegionManager = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(dialog, newRegionManager);

            if (parameters != null)
                newRegionManager.RequestNavigate(RegionNames.ContentRegion, navigationUri, parameters);
            else
                newRegionManager.RequestNavigate(RegionNames.ContentRegion, navigationUri);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            dialog.ShowInTaskbar = true;
            dialog.ShowActivated = true;
            dialog.ShowForBaseViewModel(isModal);
        }

        public FrameworkElement GetDialogInstance()
        {
            return _dialogInstance;
        }
    }
}

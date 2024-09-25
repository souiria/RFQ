using System;
using System.Threading.Tasks;
using Prism.Events;
using Squirrel;
using System.Windows;
using SEWSE.H1.UX.Infrastructure.Core.Events;
using System.IO;
using System.Collections.Generic;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{

    public class ApplicationUpdater
    {
        private readonly IEventAggregator _eventAggregator;
        private static string LocalUpdatePath = @"C:\H1Releases";
        private static string UATUpdatePath = @"\\ukhqsfuat001\HarnessOneRepo";
        private static string ReleaseUpdatePath = @"\\sews-e\replica\Apps\HarnessOne";

        public ApplicationUpdater(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        async void UpdateStarted(string message)
        {
            await CheckForUpdate();
        }

        void Timer_Tick(object sender, EventArgs e)
        {

        }
        private static string GetCurrentPath()
        {
#if DEBUG
            return LocalUpdatePath;
#elif UAT
            return UATUpdatePath;
#else
            return ReleaseUpdatePath;
#endif
        }
        public async Task<UpdateInfo> CheckForUpdate()
        {
            var CurrentPath = GetCurrentPath();
            using (var updateManager = new UpdateManager(CurrentPath))
            {
                return await updateManager.CheckForUpdate();
                //if (updateCheck.CurrentlyInstalledVersion != updateCheck.FutureReleaseEntry)
                //    return true;
                //return false;
            }
        }

        async public Task Update(Action<int> progress = null)
        {
            try
            {
                var CurrentPath = GetCurrentPath();
                using (var updateManager = new UpdateManager(CurrentPath))
                {
                    await updateManager.UpdateApp(progress);
                }
            }
            catch (Exception ex)
            {
                #region ErrorHandling
#if DEBUG

                if (ex.Message == "Update.exe not found, not a Squirrel-installed app?")
                {
                    MessageBox.Show("Please confirm update.exe is located in the bin folder.\n" +
                        "If not, rebuild the solution and try again. A copy of update.exe is also kept in the SEWS.H1.UX.WpfClient\\Helpers folder\n\n" +
                        "Please be aware, the update functionality will not work in debug without this file.",
                        "Update.exe not found, not a Squirrel-installed app?", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (ex.Message.Contains("something is probably broken with your application"))
                {
                    var last = ex.Message.Split(',')[0].Trim();
                    _eventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Publish(string.Format("{0}, or you do not have access to this location.", last));

                }
                else if (ex.Message.Contains("Remote release File is empty or corrupted"))
                {
                    MessageBox.Show("Check the distribution location, the RELEASE file should contain all the release information of each version.\n" +
                        "Try releasing a new update to rebuild the RELEASE file.", "Remote release File is empty or corrupted",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                }

#else

                var userErrorBoxTitle = "Harness One Error";
                if (ex.Message.Contains("something is probably broken with your application"))
                {
                    MessageBox.Show(ex.Message, userErrorBoxTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    //MessageBox.Show("Your client cannot connect to the update server\nPlease raise a helpdesk call",
                    //userErrorBoxTitle, MessageBoxButton.OK, MessageBoxImage.Warning); //todo: Error logging 
                }
                else
                {
                    MessageBox.Show("There was an unknown error, please raise a helpdesk call.", userErrorBoxTitle,
                    MessageBoxButton.OK, MessageBoxImage.Warning); //todo: Error logging 
                }

#endif
                #endregion
            }
        }

        public static IEnumerable<ReleaseEntry> ReadVersions()
        {
            var CurrentPath = GetCurrentPath();

            var text = File.ReadAllText(CurrentPath + "\\RELEASES");
            return ReleaseEntry.ParseReleaseFile(text);
        }

        public static async Task<string> GetCurrentVersion()
        {
            //var CurrentPath = GetCurrentPath();

            //using (var updateManager = new UpdateManager(CurrentPath))
            //{
            //    var updateCheck = await updateManager.CheckForUpdate();
            //    return updateCheck.CurrentlyInstalledVersion.Version.Version.ToString();
            //}
            return "";
        }

        public static async Task InstallVersion(IEnumerable<ReleaseEntry> versions)
        {
            using (var updateManager = new UpdateManager(GetCurrentPath()))
            {
                //var updateInfo = UpdateInfo.Create(version, availableReleases, GetCurrentPath());
                //updateManager.CreateShortcutsForExecutable(, ShortcutLocation.AppRoot, true);

            }
        }
    }
}

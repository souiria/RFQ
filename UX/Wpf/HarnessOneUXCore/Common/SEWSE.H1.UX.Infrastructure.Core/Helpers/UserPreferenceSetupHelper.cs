using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Services;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public static class UserPreferenceSetupHelper
    {
        /// <summary>
        /// A model represeting the current user
        /// </summary>
        public static UserPreferenceModel CurrentUser;
        public static List<ActiveDirectoryGroupModel> Groups;
        public static LaunchStatus LaunchStatus;

        public static Guid UserPrincipalGuid = UserPrincipal.Current.Guid.Value;
        public static string UserPrincipalUsername = UserPrincipal.Current.DisplayName;


        /// <summary>
        /// <para>A helper class made to help retrieve the current user of the application as well as the preffered settings.</para>
        /// Upon creating a new UserPreferenceSetupHelper, this class makes a call to the User service to retrieve their preferences.
        /// </summary>
        public static void InitializeUser()
        {
            try
            {
                CurrentUser = ServiceHelper.Get<UserPreferenceModel>(ServiceEndPointRoutes.UserSettingsPreference, UserPrincipalGuid.ToString(), false);
                if (CurrentUser == null)
                {
                    CurrentUser = new UserPreferenceModel
                    {
                        Username = UserPrincipal.Current.DisplayName,
                        UserGuid = UserPrincipal.Current.Guid.Value,
                        GivenName = UserPrincipal.Current.GivenName,
                        Surname = UserPrincipal.Current.Surname,
                        EmailAddress = UserPrincipal.Current.EmailAddress,
                        LoginTime = DateTime.UtcNow,
                        TimeZoneOffset = new DateTimeOffset().Offset,
                        PreferredLanguage = "English",
                    };
                    ServiceHelper.Update(ServiceEndPointRoutes.UserSettingsPreference, CurrentUser, CurrentUser.UserGuid.ToString(), false);
                }
            }
            catch (Exception e)
            {
                //Removed due to testing throwing a (404) error

                //if (e.Message == "The remote server returned an error: (500) Internal Server Error." || e.Message == "Unable to connect to the remote server")
                //{
                CurrentUser = new UserPreferenceModel
                {
                    Username = UserPrincipal.Current.DisplayName,
                    UserGuid = UserPrincipal.Current.Guid.Value,
                    GivenName = UserPrincipal.Current.GivenName,
                    Surname = UserPrincipal.Current.Surname,
                    EmailAddress = UserPrincipal.Current.EmailAddress,
                    LoginTime = DateTime.UtcNow,
                    TimeZoneOffset = new DateTimeOffset().Offset,
                    PreferredLanguage = "English",
                };
                //}
                //else
                //{
                //    
                //    //throw;
                //}
            }
            //TODO: Uncomment line below when testing is complete            
            //CurrentUser = ClusterApiHelper.GetServiceApi(ServiceEndPointRoutes.H1SecurityUserListPreference, UserPrincipalGuid).GetSingle<UserPreferenceModel>();            
        }

        public static void GetGroups()
        {
#if !DEBUG
            Groups = ServiceHelper.Get<List<ActiveDirectoryGroupModel>>(ServiceEndPointRoutes.ActiveDirectory, UserPrincipalGuid.ToString(), false);
#endif
        }

        public static LaunchStatus GetUserLaunchStatus()
        {
#if !DEBUG
            LaunchStatus = ServiceHelper.Get<LaunchStatus>(ServiceEndPointRoutes.H1SecurityUserListLaunchStatus, UserPrincipalGuid.ToString(), false);
            return LaunchStatus;
#else
            LaunchStatus = LaunchStatus.Completed;
            //LaunchStatus = ServiceHelper.Get<LaunchStatus>(ServiceEndPointRoutes.H1SecurityUserListLaunchStatus, UserPrincipalGuid.ToString(), false);
            return LaunchStatus;
#endif
        }
    }
}

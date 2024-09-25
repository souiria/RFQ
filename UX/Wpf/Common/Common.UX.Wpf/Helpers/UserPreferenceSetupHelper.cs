/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UserPreferenceSetupHelper.cs
Function           :   
Created By         :  
Created on         :   
Revision History   :   [21-Jan-2021] : Dharmendra
                   :   Added new property Logon
                   :   [08-Feb-2024] : Piyush Anand
                   :   [HD-00393919] : Added Two new property HostName and ApplicationGuid for Single User Access
****************************************************************************************************/
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Core.Security;
using Common.Core.Contracts.Models.User;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace Common.UX.Wpf.Helpers
{
    //TODO: Discuss discontinuing class and moving methods to StartupHelper.cs
    //TODO: Check if class is consuming the correct ServiceHelper based on which team owns the class

    public static class UserPreferenceSetupHelper
    {
        /// <summary>
        /// A model representing the current user
        /// </summary>
        public static UserPreferenceModel CurrentUser { get; set; }
        public static List<Group> Groups { get; set; }
        public static LaunchStatus LaunchStatus { get; set; }
        public static Guid UserPrincipalGuid { get; set; } = UserPrincipal.Current.Guid.Value;
        public static string UserPrincipalUsername { get; set; } = UserPrincipal.Current.DisplayName;

        public static string UserCommand { get; set; }
        public static string HomeMessage { get; set; } = "Welcome to Harness One";

        /// <summary>
        /// <para>A helper class made to help retrieve the current user of the application as well as the preferred settings.</para>
        /// Upon creating a new UserPreferenceSetupHelper, this class makes a call to the User service to retrieve their preferences.
        /// </summary>
        public static async Task InitializeUser()
        {
            //Removed because the User service does not do anything meaningful with this data and does not need to be retrieved or updated.

            //try
            //{
            //    CurrentUser = await ServiceHelper.Get<UserPreferenceModel>(ServiceEndpointRoutes.UserPreferences, UserPrincipalGuid.ToString());
            //    if (CurrentUser == null)
            //    {
            //        CurrentUser = new UserPreferenceModel
            //        {
            //            Username = UserPrincipal.Current.DisplayName,
            //            UserGuid = new Guid("2B4A7B7E-1559-4008-A997-3469E6C3D9F2"),//UserPrincipal.Current.Guid.Value,
            //            GivenName = UserPrincipal.Current.GivenName,
            //            Surname = UserPrincipal.Current.Surname,
            //            EmailAddress = UserPrincipal.Current.EmailAddress,
            //            LoginTime = DateTime.UtcNow,
            //            TimeZoneOffset = new DateTimeOffset().Offset,
            //            PreferredLanguage = "English",
            //        };
            //        await ServiceHelper.Update(ServiceEndpointRoutes.UserPreferences, CurrentUser, CurrentUser.UserGuid.ToString());
            //    }
            //}
            //catch (Exception e)
            //{

            //CurrentUser = new UserPreferenceModel
            //{
            //    Username = UserPrincipal.Current.DisplayName, //"Woods, Anthony (HQ)", //UserPrincipal.Current.DisplayName,
            //    UserGuid = UserPrincipal.Current.Guid.Value,//new Guid("BD4087DB-7922-4E9E-B7E1-C778F60A990E"),//UserPrincipal.Current.Guid.Value,
            //    GivenName = UserPrincipal.Current.GivenName,
            //    Surname = UserPrincipal.Current.Surname,
            //    EmailAddress = UserPrincipal.Current.EmailAddress,
            //    LoginTime = DateTime.UtcNow,
            //    TimeZoneOffset = new DateTimeOffset().Offset,
            //    PreferredLanguage = "English",
            //    Logon = UserPrincipal.Current.SamAccountName,
            //};

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
                Logon = UserPrincipal.Current.SamAccountName,
                HostName = System.Net.Dns.GetHostName(),    //added by piyush on 08-Feb-2024
                ApplicationGuid = Guid.NewGuid()    //added by piyush on 08-Feb-2024
            };
        }

        public static async Task GetGroups()
        {
            Groups = await ServiceHelper.Get<List<Group>>(ServiceEndpointRoutes.RecursiveSecurityGroupsByUser, UserPrincipalGuid.ToString()) ?? new List<Group>();
        }

        public static async Task<LaunchStatus> GetUserLaunchStatus()
        {
            return await ServiceHelper.Get<LaunchStatus>(ServiceEndpointRoutes.UserListLaunchStatus, UserPrincipalGuid.ToString());
        }
    }
}

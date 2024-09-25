/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UserPreferenceModel.cs
Function           :   
Created By         :  
Created on         :   
Revision History   :   [21-Jan-2021] : Dharmendra
                   :   Added new property Logon
                   :   [08-Feb-2024] : Piyush Anand
                   :   [HD-00393919] : Added Two new property HostName and ApplicationGuid for Single User Access
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.User
{
    [DataContract, Serializable]
    [NotMapped]
    public class UserPreferenceModel : BaseModel<Guid>
    {
        private Guid _userGuid;

        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private string _username;

        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private DateTime _loginTime;

        [DataMember]
        public DateTime LoginTime
        {
            get => _loginTime;
            set => SetProperty(ref _loginTime, value);
        }

        private TimeSpan _timeZoneOffset;

        [DataMember]
        public TimeSpan TimeZoneOffset
        {
            get => _timeZoneOffset;
            set => SetProperty(ref _timeZoneOffset, value);
        }

        private string _preferredLanguage;

        [DataMember]
        public string PreferredLanguage
        {
            get => _preferredLanguage;
            set => SetProperty(ref _preferredLanguage, value);
        }

        private string _preferredTheme;

        [DataMember]
        public string PreferredTheme
        {
            get => _preferredTheme;
            set => SetProperty(ref _preferredTheme, value);
        }

        private List<string> _rFQColors;
        [DataMember]
        public List<string> RFQColors
        {
            get => _rFQColors;
            set => SetProperty(ref _rFQColors, value);
        }

        private string _givenName;

        [DataMember]
        public string GivenName
        {
            get => _givenName;
            set => SetProperty(ref _givenName, value);
        }

        private string _surname;

        [DataMember]
        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        private string _emailAddress;

        [DataMember]
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }

        private string _logon;

        [DataMember]
        public string Logon
        {
            get => _logon;
            set => SetProperty(ref _logon, value);
        }
        
        private Guid _applicationGuid;

        [DataMember]
        public Guid ApplicationGuid
        {
            get => _applicationGuid;
            set => SetProperty(ref _applicationGuid, value);
        }

        private string _hostName;

        [DataMember]
        public string HostName
        {
            get => _hostName;
            set => SetProperty(ref _hostName, value);
        }

    }
}

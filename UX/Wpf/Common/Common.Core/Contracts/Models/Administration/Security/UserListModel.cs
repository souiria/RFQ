using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Security;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class UserListModel : BaseModel<Guid>, IEquatable<UserListModel>
    {
        private string _username;
        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _firstName;
        [DataMember]
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
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

        private string _site;
        [DataMember]
        public string Site
        {
            get => _site;
            set => SetProperty(ref _site, value);
        }

        private string _logon;
        [DataMember]
        public string Logon
        {
            get => _logon;
            set => SetProperty(ref _logon, value);
        }

        /// <summary>
        /// Last Login to Harness One, not Active Directory
        /// </summary>
        private DateTime? _lastLogin;
        [DataMember]
        public DateTime? LastLogin
        {
            get => _lastLogin;
            set => SetProperty(ref _lastLogin, value);
        }

        /// <summary>
        /// First Login to Harness One, not Active Directory
        /// </summary>
        private DateTime? _firstLogin;
        [DataMember]
        public DateTime? FirstLogin
        {
            get => _firstLogin;
            set => SetProperty(ref _firstLogin, value);
        }

        private bool _isH1User;
        [DataMember]
        public bool IsH1User
        {
            get => _isH1User;
            set => SetProperty(ref _isH1User, value);
        }

        private List<ActiveDirectoryGroupModel> _groups;
        [DataMember]
        public List<ActiveDirectoryGroupModel> Groups
        {
            get => _groups;
            set => SetProperty(ref _groups, value);
        }

        private List<UserListAccessModel> _access;
        [DataMember]
        public List<UserListAccessModel> Access
        {
            get => _access;
            set => SetProperty(ref _access, value);
        }

        public bool Equals(UserListModel other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is UserListModel user)
                return Equals(user);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

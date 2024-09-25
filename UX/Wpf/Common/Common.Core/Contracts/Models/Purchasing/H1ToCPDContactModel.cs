using System.Runtime.Serialization;
using System;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDContactModel
    {
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }

        private string _code;
        [DataMember]
        public string Code
        {
            get => _code;
            set => _code = value;
        }
        private string _contactType;
        [DataMember]
        public string ContactType
        {
            get => _contactType;
            set => _contactType = value;
        }
        private Guid _contactTypeGuid;
        [DataMember]
        public Guid ContactTypeGuid
        {
            get => _contactTypeGuid;
            set => _contactTypeGuid = value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDContactDataSyncModel 
    {
        private string _sDECode;
        [DataMember]
        public string SDE_Code
        {
            get => _sDECode;
            set => _sDECode = value;
        }

        private string _sDEName;
        [DataMember]
        public string SDE_Name
        {
            get => _sDEName;
            set => _sDEName = value;
        }

        private string _sDE_Contact_No;
        [DataMember]
        public string SDE_Contact_No
        {
            get => _sDE_Contact_No;
            set => _sDE_Contact_No = value;
        }
        private string _sDE_Email;
        [DataMember]
        public string SDE_Email
        {
            get => _sDE_Email;
            set => _sDE_Email = value;
        }

        private string _sDE_UserId;
        [DataMember]
        public string SDE_UserId
        {
            get => _sDE_UserId;
            set => _sDE_UserId = value;
        }

        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
}

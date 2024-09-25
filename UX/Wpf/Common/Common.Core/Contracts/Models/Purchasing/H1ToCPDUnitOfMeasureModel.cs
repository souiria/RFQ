using System.Runtime.Serialization;
using System;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDUnitOfMeasureModel
    {
        
        private Guid _iSOUnitOfMeasureGuid;
        [DataMember]
        public Guid ISOUnitOfMeasureGuid
        {
            get => _iSOUnitOfMeasureGuid;
            set => _iSOUnitOfMeasureGuid = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
        private string _sourceUnitOfMeasureCode;
        [DataMember]

        public string SourceUnitOfMeasureCode
        {
            get => _sourceUnitOfMeasureCode;
            set => _sourceUnitOfMeasureCode = value;
        }
    }
        [DataContract, Serializable]
        public class H1ToCPDUnitOfMeasureDataSyncModel
        {
        private Guid _id = Guid.Empty;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _code;
            [DataMember]
            public string Code
            {
                get => _code;
                set => _code = value;
            }

            private string _unitOfMeasurementDescription;
            [DataMember]
            public string UnitOfMeasureDescription
            {
                get => _unitOfMeasurementDescription;
                set => _unitOfMeasurementDescription = value;
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

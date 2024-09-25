using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLConsolidatedMRPErrorListGridModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode= value; }
        }       

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set {  _materialNumber= value; }
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get { return _materialName; }
            set {  _materialName= value; }
        }
     
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set =>  _businessUnitCode= value;
        }
        private string _iSOUnitOfMeasurement;
        [DataMember]
        public string ISOUnitOfMeasurement
        {
            get => _iSOUnitOfMeasurement;
            set => _iSOUnitOfMeasurement=value;
        }
        private int _requiredQuantity;
        [DataMember]
        public int RequiredQuantity
        {
            get => _requiredQuantity;
            set =>  _requiredQuantity= value;
        }

        private string _message;
        [DataMember]
        public string Message
        {
            get => _message;
            set =>  _message= value;
        }

        private DateTime _fromDate;
        [DataMember]
        public DateTime FromDate
        {
            get => _fromDate;
            set => _fromDate = value;
        }
        private DateTime _toDate;
        [DataMember]
        public DateTime ToDate
        {
            get => _toDate;
            set => _toDate = value;
        }
        private string _upd;
        [DataMember]
        public string Upd
        {
            get => _upd;
            set =>  _upd=value;
        }
    }

    [DataContract, Serializable]
    public class ConsolidatedMRPErrorParamModel
    {
        private Guid _businessUnit;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }
        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => _option = value;
        }
    }

}

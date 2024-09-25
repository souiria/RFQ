using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class EMACSSupplierNoXrefModel : ExternalDataSourceModel<long>
    {
        private string _swsPartNo;
        [DataMember, Key]
        public string SWSPartNo
        {
            get => _swsPartNo;
            set => SetProperty(ref _swsPartNo, value);
        }

        private string _supplierPartNo;
        [DataMember]
        public string SupplierPartNo
        {
            get => _supplierPartNo;
            set => SetProperty(ref _supplierPartNo, value);
        }
    }
}

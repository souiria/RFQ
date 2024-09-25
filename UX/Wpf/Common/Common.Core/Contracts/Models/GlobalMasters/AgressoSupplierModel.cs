using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class AgressoSupplierModel : BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private string _agressoSupplierCode;
        [DataMember]
        [Required]
        [StringLength(20)]
        public string AgressoSupplierCode
        {
            get => _agressoSupplierCode;
            set => SetProperty(ref _agressoSupplierCode, value);
        }

        private string _agressoSupplierName;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string AgressoSupplierName
        {
            get => _agressoSupplierName;
            set => SetProperty(ref _agressoSupplierName, value);
        }

        private string _agressoAccount;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string AgressoAccount
        {
            get => _agressoAccount;
            set => SetProperty(ref _agressoAccount, value);
        }

        private string _agressoTaxCode;
        [DataMember]
        [Required]
        [StringLength(5)]
        public string AgressoTaxCode
        {
            get => _agressoTaxCode;
            set => SetProperty(ref _agressoTaxCode, value);
        }

        private int _agressoDueDays;
        [DataMember]
        [Required]        
        public int AgressoDueDays
        {
            get => _agressoDueDays;
            set => SetProperty(ref _agressoDueDays, value);
        }


        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}

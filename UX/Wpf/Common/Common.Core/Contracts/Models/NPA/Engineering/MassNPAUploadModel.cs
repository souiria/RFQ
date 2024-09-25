using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class MassNPAUploadModel : BaseModel<Guid>
    {
        private Guid _materialTypeGuid;
        [DataMember]
        [Required]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => SetProperty(ref _materialTypeGuid, value);
        }


        private Guid _supplierGuid;
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private Guid _suggestedSupplierGuid;
        [DataMember]
        [Required]
        public Guid SuggestedSupplierGuid
        {
            get => _suggestedSupplierGuid;
            set => SetProperty(ref _suggestedSupplierGuid, value);
        }

        private Guid _projectGuid;
        [DataMember]
        [Required]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid _customerGuid;
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private Guid _uomGuid;
        [DataMember]
        [Required]
        public Guid UOMGuid
        {
            get => _uomGuid;
            set => SetProperty(ref _uomGuid, value);
        }


        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _reasonGuid;
        [DataMember]
        [Required]
        public Guid ReasonGuid
        {
            get => _reasonGuid;
            set => SetProperty(ref _reasonGuid, value);
        }

        private string _referenceNumber;
        [DataMember]
        [Required]
        [StringLength(20)]
        public string ReferenceNumber
        {
            get => _referenceNumber;
            set => SetProperty(ref _referenceNumber, value);
        }

        private Guid _npaTypeGuid;
        [DataMember]
        public Guid NPATypeGuid
        {
            get => _npaTypeGuid;
            set => SetProperty(ref _npaTypeGuid, value);
        }
    }
}

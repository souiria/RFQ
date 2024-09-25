using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <summary>
    /// Supplier Approval Status Model
    /// </summary>
    [DataContract, Serializable]
    public class SupplierApprovalStatusModel : BaseModel<Guid>
    {

        private string _supplierApprovalStatusCode;
        /// <summary>
        /// Supplier Approval Status Code   
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(10)]
        public string SupplierApprovalStatusCode
        {
            get => _supplierApprovalStatusCode;
            set => SetProperty(ref _supplierApprovalStatusCode, value);
        }

        private string _supplierApprovalStatusDescription;
        /// <summary>
        /// Supplier Approval Status Description
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string SupplierApprovalStatusDescription
        {
            get => _supplierApprovalStatusDescription;
            set => SetProperty(ref _supplierApprovalStatusDescription, value);
        }
    }
}

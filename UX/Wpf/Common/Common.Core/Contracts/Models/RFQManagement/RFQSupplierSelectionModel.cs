using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.RFQManagement
{
    [DataContract, Serializable]
    public class RFQSupplierSelectionModel : BaseModel<Guid>
    {
        private List<RFQModel> _rfqModelList;

        [DataMember]
        public List<RFQModel> RFQModelList
        {
            get => _rfqModelList;
            set => SetProperty(ref _rfqModelList, value);
        }

        private string _businessUnit;

        [DataMember]
        [StringLength(4)]
        [Required]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => SetProperty(ref _businessUnit, value);
        }

        private string _remarks;

        [DataMember]
        [StringLength(250)]
        [Required]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        private bool _approvalStatus;

        [DataMember]
        public bool ApprovalStatus
        {
            get => _approvalStatus;
            set => SetProperty(ref _approvalStatus, value);
        }
    }
}

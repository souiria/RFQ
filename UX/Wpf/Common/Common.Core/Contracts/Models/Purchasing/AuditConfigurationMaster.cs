/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditConfigurationMaster.cs
Function           :  Audit Configuration Model
Created By         :   Vishwadeep
Created on         :   12-Oct-2022
Revision History   : [28-Nov-2022]:Virendra 
                   : Added LastAuditDate and AuditStatusName property    
                   : [21-Dec-2022]:Virendra 
                   : Added SubmittedDate property    
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class AuditConfigurationModel : BaseModel<Guid>
    {
        private Guid _supplierGroupGuid;
        [DataMember]
        [Required]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }

        private string _SupplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get => _SupplierGroupName;
            set => SetProperty(ref _SupplierGroupName, value);
        }

        private DateTime? _startDate;
        [DataMember]
        [Required]
        public DateTime? StartDate
        {
            get => _startDate ?? DateTime.UtcNow;
            set => SetProperty(ref _startDate, value);
        }
        private DateTime? _lastAuditDate;
        [DataMember]
        public DateTime? LastAuditDate
        {
            get { return _lastAuditDate; }
            set { _lastAuditDate = value; }
        }
        private string _auditStatusName;
        [DataMember]
        public string AuditStatusName
        {
            get => _auditStatusName;
            set => SetProperty(ref _auditStatusName, value);
        }
        private DateTime? _nextAuditDate;
        [DataMember]
        [Required]
        public DateTime? NextAuditDate
        {
            get => _nextAuditDate ?? DateTime.UtcNow;
            set => SetProperty(ref _nextAuditDate, value);
        }
        private int _interval;
        [DataMember]
        [Required]
        public int Interval
        {
            get => _interval;
            set => SetProperty(ref _interval, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        private DateTime? _submittedDate;
        [DataMember]
        public DateTime? SubmittedDate
        {
            get { return _submittedDate; }
            set { _submittedDate = value; }
        }
    }

    //[DataContract, Serializable]
    //public class ShowAuditConfiguration : AuditConfigurationModel
    //{
    //    private string _supplierGroup;

    //    /// get or set for projectname

    //    [DataMember]
    //    public string SupplierGroup
    //    {
    //        get => _supplierGroup;
    //        set => _supplierGroup = value;
    //    }
    //}
}

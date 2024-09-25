/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   OrderStatusModel.cs
Function           :   Order Status
Created By         :   shivam Dhingra
Created on         :   13-Jul-2021
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Class File for OrderStatusModel
    /// </summary>
    [DataContract,Serializable]
    public class OrderStatusModel : BaseModel<Guid>
    {
        private string _wmsSourceType;
        /// <summary>
        /// WMSSourceType
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceType
        {
            get => _wmsSourceType;
            set => SetProperty(ref _wmsSourceType, value);
        }

        private string _wmsSourceLocation;
        /// <summary>
        /// WMSSourceLocation
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceLocation
        {
            get => _wmsSourceLocation;
            set => SetProperty(ref _wmsSourceLocation, value);
        }

        private string _asn_No;
        /// <summary>
        /// Asn_No
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(12)]
        public string Asn_No
        {
            get => _asn_No;
            set => SetProperty(ref _asn_No, value);
        }


        private string _sews_Part_No;
        /// <summary>
        /// Sews_Part_No
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(18)]
        public string Sews_Part_No
        {
            get => _sews_Part_No;
            set => SetProperty(ref _sews_Part_No, value);
        }

        private string _wh_Code;
        /// <summary>
        /// Wh_Code
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string Wh_Code
        {
            get => _wh_Code;
            set => SetProperty(ref _wh_Code, value);
        }

        private int? _total_Delivery_Qty;
        /// <summary>
        /// Total_Delivery_Qty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? Total_Delivery_Qty
        {
            get => _total_Delivery_Qty;
            set => SetProperty(ref _total_Delivery_Qty, value);
        }

        private int? _delivered_Qty;
        /// <summary>
        /// Delivered_Qty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? Delivered_Qty
        {
            get => _delivered_Qty;
            set => SetProperty(ref _delivered_Qty, value);
        }

        private int? _in_Transit_Qty;
        /// <summary>
        /// In_Transit_Qty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? In_Transit_Qty
        {
            get => _in_Transit_Qty;
            set => SetProperty(ref _in_Transit_Qty, value);
        }

        private DateTime? _expected_Arrival_Date;
        /// <summary>
        /// Expected_Arrival_Date
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? Expected_Arrival_Date
        {
            get => _expected_Arrival_Date;
            set => SetProperty(ref _expected_Arrival_Date, value);
        }

        private DateTime? _last_Upd_Stamp;
        /// <summary>
        /// Last_Upd_Stamp
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? Last_Upd_Stamp
        {
            get => _last_Upd_Stamp;
            set => SetProperty(ref _last_Upd_Stamp, value);
        }

        private DateTime? _snapshot_Stamp;
        /// <summary>
        /// Snapshot_Stamp
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? Snapshot_Stamp
        {
            get => _snapshot_Stamp;
            set => SetProperty(ref _snapshot_Stamp, value);
        }

        private Guid _supplyPlanningDataSyncCalendarGuid;
        /// <summary>
        /// SupplyPlanningDataSyncCalendarGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid SupplyPlanningDataSyncCalendarGuid
        {
            get => _supplyPlanningDataSyncCalendarGuid;
            set => SetProperty(ref _supplyPlanningDataSyncCalendarGuid, value);
        }


        private int? _back_log_Qty;
        /// <summary>
        /// Back_log_Qty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? Back_log_Qty
        {
            get => _back_log_Qty;
            set => SetProperty(ref _back_log_Qty, value);
        }
        
    }

    /// <summary>
    /// Class File For OrderStatusParameterModel
    /// </summary>
    [DataContract,Serializable]
    public class OrderStatusParameterModel
    {
        private string _whCode;
        /// <summary>
        /// Get or Set for {WHCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WHCode
        {
            get => _whCode;
            set => _whCode = value;
        }

        private string _asnNo;
        /// <summary>
        /// Get or Set for {ASNNo}.
        /// </summary>
        [DataMember]
        [StringLength(12)]
        public string ASNNo
        {
            get => _asnNo;
            set => _asnNo = value;
        }
    }
}

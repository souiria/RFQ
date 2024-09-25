/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSInventorySnapShotModel.cs
Function           :   WMS Inventory Snap Shot Model
Created By         :   Dharmendra 
Created on         :   10-Sep-2020
Revision History   :   [18-May-2021] : Shivam Kalia
                   :   []: Added new Class WMSInventorySnapShotMasterByProcedureParameterModel
                   :   [24-July-2023] : Prakhar
                   :   []: Added new Property WH_Code in Class WMSInventorySnapShotMasterByProcedureParameterModel
                   :   [31-July-2023] : Prakhar
                   :   []: Added new Property parameter in Class WMSInventorySnapShotMasterByProcedureParameterModel

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
    [DataContract, Serializable]
    public class WMSInventorySnapShotModel : BaseModel<Guid>
    {
        private string _wMSSourceType;
        /// <summary>
        /// Get or Set for {WMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string WMSSourceType
        {
            get => _wMSSourceType;
            set => SetProperty(ref _wMSSourceType, value);
        }
        private string _wMSSourceLocation;
        /// <summary>
        /// Get or Set for {WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string WMSSourceLocation
        {
            get => _wMSSourceLocation;
            set => SetProperty(ref _wMSSourceLocation, value);
        }


        private string _sEWS_PART_NO;
        /// <summary>
        /// Get or Set for {SEWS_PART_NO}.
        /// </summary>
        [DataMember]
        [StringLength(18)]
        public string SEWS_PART_NO
        {
            get => _sEWS_PART_NO;
            set => SetProperty(ref _sEWS_PART_NO, value);
        }

        private string _lOC_ID;
        /// <summary>
        /// Get or Set for {LOC_ID}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string LOC_ID
        {
            get => _lOC_ID;
            set => SetProperty(ref _lOC_ID, value);
        }


        private string _wH_CODE;
        /// <summary>
        /// Get or Set for {WH_CODE}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WH_CODE
        {
            get => _wH_CODE;
            set => SetProperty(ref _wH_CODE, value);
        }


        private string _zONE_CD;
        /// <summary>
        /// Get or Set for {ZONE_CD}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        [Required]
        public string ZONE_CD
        {
            get => _zONE_CD;
            set => SetProperty(ref _zONE_CD, value);
        }



        private short _sTS_CD;
        /// <summary>
        /// Get or Set for {STS_CD}.
        /// </summary>
        [DataMember]
        [Required]
        public short STS_CD
        {
            get => _sTS_CD;
            set => SetProperty(ref _sTS_CD, value);
        }

        private int _sERIAL_QTY;
        /// <summary>
        /// Get or Set for {SERIAL_QTY}.
        /// </summary>
        [DataMember]
        public int SERIAL_QTY
        {
            get => _sERIAL_QTY;
            set => SetProperty(ref _sERIAL_QTY, value);
        }


        private Guid _supplyPlanningDataSyncCalendarGuid;
        /// <summary>
        /// Get or Set for {SupplyPlanningDataSyncCalendarGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplyPlanningDataSyncCalendarGuid
        {
            get => _supplyPlanningDataSyncCalendarGuid;
            set => SetProperty(ref _supplyPlanningDataSyncCalendarGuid, value);
        }
    }

    [DataContract, Serializable]
    public class WMSInventorySnapShotMasterByProcedureParameterModel
    {
        private string _p_option;
        /// <summary>
        /// Get or Set for {P_option}.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        public string P_option
        {
            get => _p_option;
            set => _p_option = value;
        }

        private string _wH_Code;
        /// <summary>
        /// Get or Set for {P_option}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WH_Code
        {
            get => _wH_Code;
            set => _wH_Code = value;
        }

        private string _sewsPartNo;
        /// <summary>
        /// Get or Set for {_sewsPartNo}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SewsPartNo
        {
            get => _sewsPartNo;
            set => _sewsPartNo = value;
        }

        private string _wMSSourceType;
        /// <summary>
        /// Get or Set for {_wMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceType
        {
            get => _wMSSourceType;
            set => _wMSSourceType = value;
        }

        private string _wMSSourceLocation;
        /// <summary>
        /// Get or Set for {_wMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceLocation
        {
            get => _wMSSourceLocation;
            set => _wMSSourceLocation = value;
        }

        private string _loc;
        /// <summary>
        /// Get or Set for {P_option}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Loc
        {
            get => _loc;
            set => _loc = value;
        }

        private DateTime _date_Of_Inventory;
        /// <summary>
        /// Get or Set for {_date_Of_Inventory}.
        /// </summary>
        [DataMember]

        public DateTime Date_Of_Inventory
        {
            get => _date_Of_Inventory;
            set => _date_Of_Inventory = value;
        }

    }
}

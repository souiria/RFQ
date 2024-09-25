/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSOpeningStockModel.cs
Function           :  
Created By         :   Shivam Kalia
Created on         :   24-May-2021
Revision History   :   
*                  :   [01-June-2021]: Shivam Kalia
*                  :   Changed the datatype of 'P_Date_Of_Inventory' from string to DateTime and also renamed some fields according to the 'Proc_H1Show_WMSOpeningStock' procedure.
*                  :   [12-Oct-2022]: Virendra 
*                  :   Added new field LOC_Type_CD into WMSOpeningStockModel Model
                
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
    /// Data Contract use for WMSDataSynchronizationETL Service
    /// </summary>
    [DataContract, Serializable]
    public class WMSOpeningStockModel : BaseModel<Guid>
    {
        private string _part_Number;
        /// <summary>
        /// Get or Set for {Part_Number}.
        /// </summary>
        [DataMember]
        public string Part_Number
        {
            get => _part_Number;
            set => _part_Number = value;
        }

        private string _wh_Code;
        /// <summary>
        /// Get or Set for {Wh_Code}.
        /// </summary>
        [DataMember]
        public string Wh_Code
        {
            get => _wh_Code;
            set => _wh_Code = value;
        }

        private string _mfg_Site;
        /// <summary>
        /// Get or Set for {Mfg_Site}.
        /// </summary>
        [DataMember]
        public string Mfg_Site
        {
            get => _mfg_Site;
            set => _mfg_Site = value;
        }

        private string _country;
        /// <summary>
        /// Get or Set for {Country}.
        /// </summary>
        [DataMember]
        public string Country
        {
            get => _country;
            set => _country = value;
        }

        private string _inv_Location;
        /// <summary>
        /// Get or Set for {Inv_Location}.
        /// </summary>
        [DataMember]
        public string Inv_Location
        {
            get => _inv_Location;
            set => _inv_Location = value;
        }

        private int _serial_Qty;
        /// <summary>
        /// Get or Set for {Serial_Qty}.
        /// </summary>
        [DataMember]
        public int Serial_Qty
        {
            get => _serial_Qty;
            set => _serial_Qty = value;
        }

        private DateTime _date_of_Inv_Snapshot;
        /// <summary>
        /// Get or Set for {Date_of_Inv_Snapshot}.
        /// </summary>
        [DataMember]
        public DateTime Date_of_Inv_Snapshot
        {
            get => _date_of_Inv_Snapshot;
            set => _date_of_Inv_Snapshot = value;
        }
        private string _lOC_Type_CD;
        /// <summary>
        /// Get or Set for {LOC_Type_CD}.
        /// </summary>
        [DataMember]
        public string LOC_Type_CD
        {
            get => _lOC_Type_CD;
            set => _lOC_Type_CD = value;
        }
    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in WMSOpeningStock endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class WMSOpeningStockModelByProcedureParameterModel
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

        private string _P_Sews_Part_No;
        /// <summary>
        /// Get or Set for {P_Sews_Part_No}.
        /// </summary>
        [DataMember]
        [StringLength(18)]
        public string P_Sews_Part_No
        {
            get => _P_Sews_Part_No;
            set => _P_Sews_Part_No = value;
        }

        private string _P_WH_Code;
        /// <summary>
        /// Get or Set for {P_WH_Code}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string P_WH_Code
        {
            get => _P_WH_Code;
            set => _P_WH_Code = value;
        }

        private string _P_WMSSourceType;
        /// <summary>
        /// Get or Set for {P_WMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string P_WMSSourceType
        {
            get => _P_WMSSourceType;
            set => _P_WMSSourceType = value;
        }

        private string _P_WMSSourceLocation;
        /// <summary>
        /// Get or Set for {P_WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string P_WMSSourceLocation
        {
            get => _P_WMSSourceLocation;
            set => _P_WMSSourceLocation = value;
        }

        private string _P_Loc;
        /// <summary>
        /// Get or Set for {P_Loc}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string P_Loc
        {
            get => _P_Loc;
            set => _P_Loc = value;
        }

        private DateTime _P_Date_Of_Inventory;
        /// <summary>
        /// Get or Set for {P_Date_Of_Inventory}.
        /// </summary>
        [DataMember]
        public DateTime P_Date_Of_Inventory
        {
            get => _P_Date_Of_Inventory;
            set => _P_Date_Of_Inventory = value;
        }

    }
}

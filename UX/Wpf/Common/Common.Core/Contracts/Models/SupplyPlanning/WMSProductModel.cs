/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSProductrModel.cs
Function           :   WMS Product Model
Created By         :   Shivam Dhingra
Created on         :   09-Apr-2020
Revision History   :   [04-May-2020] : Shivam Dhingra
*                  :   Removed property SEWS_PART_NO  
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
    public class WMSProductModel : BaseModel<Guid>
    {
        private int _iTEM_NO;
        /// <summary>
        /// Get or Set for {ITEM_NO}.
        /// </summary>
        [DataMember]
        [Required]
        public int ITEM_NO
        {
            get => _iTEM_NO;
            set => SetProperty(ref _iTEM_NO, value);
        }

      
        private string _sEWS_DESIGN_LEVEL;
        /// <summary>
        /// Get or Set for {SEWS_DESIGN_LEVEL}.
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string SEWS_DESIGN_LEVEL
        {
            get => _sEWS_DESIGN_LEVEL;
            set => SetProperty(ref _sEWS_DESIGN_LEVEL, value);
        }

        private string _mFG_PLANT;
        /// <summary>
        /// Get or Set for {MFG_PLANT}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        [Required]
        public string MFG_PLANT
        {
            get => _mFG_PLANT;
            set => SetProperty(ref _mFG_PLANT, value);
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

        private DateTime _eNT_STAMP;
        /// <summary>
        /// Get or Set for {ENT_STAMP}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ENT_STAMP
        {
            get => _eNT_STAMP;
            set => SetProperty(ref _eNT_STAMP, value);
        }


        private string _eNT_BY;
        /// <summary>
        /// Get or Set for {ENT_BY}.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        [Required]
        public string ENT_BY
        {
            get => _eNT_BY;
            set => SetProperty(ref _eNT_BY, value);
        }


        private DateTime _lAST_UPD_STAMP;
        /// <summary>
        /// Get or Set for {LAST_UPD_STAMP}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime LAST_UPD_STAMP
        {
            get => _lAST_UPD_STAMP;
            set => SetProperty(ref _lAST_UPD_STAMP, value);
        }




        private string _lAST_UPD_BY;
        /// <summary>
        /// Get or Set for {LAST_UPD_BY}.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        [Required]
        public string LAST_UPD_BY
        {
            get => _lAST_UPD_BY;
            set => SetProperty(ref _lAST_UPD_BY, value);
        }


    }
}


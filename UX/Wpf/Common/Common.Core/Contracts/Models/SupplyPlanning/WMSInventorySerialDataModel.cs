/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSInventorySerialDataModel.cs
Function           :   WMS Inventory Serial Data Model
Created By         :   Shivam Dhingra
Created on         :   09-Apr-2020
Revision History   :   [04-May-2020] : Shivam Dhingra
*                  :   Added new property SEWS_PART_NO 
                   :   [08-May-2020] : Pawan
*                  :   Added new property WMSSourceType,WMSSourceLocation
                   :   
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

	public class WMSInventorySerialDataModel : BaseModel<Guid>
    {


		private string _sERIAL_NO;
		/// <summary>
		/// Get or Set for {SERIAL_NO}.
		/// </summary>
		[DataMember]
		[StringLength(10)]
		[Required]
		public string SERIAL_NO
		{
			get => _sERIAL_NO;
			set => SetProperty(ref _sERIAL_NO, value);
		}


		private string _bOX_PHY_ID;
		/// <summary>
		/// Get or Set for {BOX_PHY_ID}.
		/// </summary>
		[DataMember]
		[StringLength(10)]
		public string BOX_PHY_ID
		{
			get => _bOX_PHY_ID;
			set => SetProperty(ref _bOX_PHY_ID, value);
		}


		private string _pARENT_SRL_NO;
		/// <summary>
		/// Get or Set for {PARENT_SRL_NO}.
		/// </summary>
		[DataMember]
		[StringLength(10)]
		public string PARENT_SRL_NO
		{
			get => _pARENT_SRL_NO;
			set => SetProperty(ref _pARENT_SRL_NO, value);
		}

		private string _gB_SERIAL_NO;
		/// <summary>
		/// Get or Set for {GB_SERIAL_NO}.
		/// </summary>
		[DataMember]
		[StringLength(10)]
		public string GB_SERIAL_NO
		{
			get => _gB_SERIAL_NO;
			set => SetProperty(ref _gB_SERIAL_NO, value);
		}


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


		private string _sEWS_PART_NO;
		/// <summary>
		/// Get or Set for {SEWS_PART_NO}.
		/// </summary>
		[DataMember]
		[StringLength(18)]
		[Required]
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
		[Required]
		public string LOC_ID
		{
			get => _lOC_ID;
			set => SetProperty(ref _lOC_ID, value);
		}

		private string _pALLET_NO;
		/// <summary>
		/// Get or Set for {PALLET_NO}.
		/// </summary>
		[DataMember]
		[StringLength(22)]
		public string PALLET_NO
		{
			get => _pALLET_NO;
			set => SetProperty(ref _pALLET_NO, value);
		}


		private string _pALLET_PHY_ID;
		/// <summary>
		/// Get or Set for {PALLET_PHY_ID}.
		/// </summary>
		[DataMember]
		[StringLength(10)]
		public string PALLET_PHY_ID
		{
			get => _pALLET_PHY_ID;
			set => SetProperty(ref _pALLET_PHY_ID, value);
		}

		private string _wH_CODE;
		/// <summary>
		/// Get or Set for {WH_CODE}.
		/// </summary>
		[DataMember]
		[StringLength(4)]
		[Required]
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



		private int _sERIAL_QTY;
		/// <summary>
		/// Get or Set for {SERIAL_QTY}.
		/// </summary>
		[DataMember]
		[Required]
		public int SERIAL_QTY
		{
			get => _sERIAL_QTY;
			set => SetProperty(ref _sERIAL_QTY, value);
		}


		private int _sEQ_NO;
		/// <summary>
		/// Get or Set for {SEQ_NO}.
		/// </summary>
		[DataMember]
		[Required]
		public int SEQ_NO
		{
			get => _sEQ_NO;
			set => SetProperty(ref _sEQ_NO, value);
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

        private string _wmsSourceType;
        /// <summary>
        /// Get or Set for {WMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string WMSSourceType
        {
            get => _wmsSourceType;
            set => SetProperty(ref _wmsSourceType, value);
        }

        private string _wmsSourceLocation;
        /// <summary>
        /// Get or Set for {WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string WMSSourceLocation
        {
            get => _wmsSourceLocation;
            set => SetProperty(ref _wmsSourceLocation, value);
        }




    }
}
 
  
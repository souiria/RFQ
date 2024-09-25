/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageSearchModel.cs
Function           :   Model to get data from EDIMessageHeader on the basis of search field
Created By         :   Shivam Dhingra
Created on         :   13-Apr-2020
Revision History   :   [29-Apr-2020] : Shivam Dhingra
                   :   Added new field EDIMessageFileName
                   :   [26-Jun-2020] : Shivam Dhingra
                   :   Added new class to call Procedure for Reporcessing with Parameters
                   :   [07-Jun-2021] : Shivam Kalia
                   :   Changed the data length from 12 characters to 35 characters for UNBSenderId   
				   :   [01-Sept-2021] : Shivam Kalia
                   :   Added new fields UNBSenderId,AccountNumber,BuyerCode,ConsigneeCode,ConsignorCode,UnloadingPoint,MessageType in EDIMessageSearchModel
				   :   [10-June-2022] : Shivam Kalia
                   :   Added new field UserGuid
*				   :   [14-Sept-2022] : Sejal Srivastava
*                  :   [] : Added new fields- CustomerBusinessGroupGuid, CustomerGuid, EdiMessageFileName
*                  :   [18-Oct-2022] : Sejal Srivastava
*                  :   [] : Changes in EDIMessageHeaderProcedureParametersFilterModel
*                  :   [01-Nov-2022] : Sejal Srivastava
*                  :   [] : Made CustomerBusinessGroupGuid, CustomerName nullable
*                  :   [12-Dec-2022] : Prakhar
*                  :   [] : Added new property UniqueGuid
*                  :   [02-Feb-2024] : Prakhar
*                  :   [HD-00394058] : Added new property ViewName in EDIMessageHeaderProcedureParametersFilterModel
*                  
*                  
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
    public class EDIMessageSearchModel : BaseModel<Guid>
    {

		private DateTime _dateTo;
		/// <summary>
		/// Get or Set for {DateTo}.
		/// </summary>
		[DataMember]
		[Required]
		public DateTime DateTo
		{
			get => _dateTo;
			set => SetProperty(ref _dateTo, value);
		}

		private DateTime _dateFrom;
		/// <summary>
		/// Get or Set for {DateFrom}.
		/// </summary>
		[DataMember]
		[Required]
		public DateTime DateFrom
		{
			get => _dateFrom;
			set => SetProperty(ref _dateFrom, value);
		}

		private string _ediMessageFileName;
		/// <summary>
		/// Get or Set for {EDIMessageFileName}.
		/// </summary>
		[DataMember]
		[Required]
		[StringLength(150)]
		public string EDIMessageFileName
		{
			get => _ediMessageFileName;
			set => SetProperty(ref _ediMessageFileName, value);
		}

		private string _unbSenderId;
		/// <summary>
		/// Get or Set for {UNBSenderId}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string UNBSenderId
		{
			get => _unbSenderId;
			set => SetProperty(ref _unbSenderId, value);
		}

		private string _accountNumber;
		/// <summary>
		/// Get or Set for {AccountNumber}.
		/// </summary>
		[DataMember]
		[StringLength(70)]
		public string AccountNumber
		{
			get => _accountNumber;
			set => SetProperty(ref _accountNumber, value);
		}

		private string _buyerCode;
		/// <summary>
		/// Get or Set for {BuyerCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string BuyerCode
		{
			get => _buyerCode;
			set => SetProperty(ref _buyerCode, value);
		}

		private string _consigneeCode;
		/// <summary>
		/// Get or Set for {ConsigneeCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string ConsigneeCode
		{
			get => _consigneeCode;
			set => SetProperty(ref _consigneeCode, value);
		}

		private string _consignorCode;
		/// <summary>
		/// Get or Set for {ConsignorCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string ConsignorCode
		{
			get => _consignorCode;
			set => SetProperty(ref _consignorCode, value);
		}

		private string _unloadingPoint;
		/// <summary>
		/// Get or Set for {UnloadingPoint}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string UnloadingPoint
		{
			get => _unloadingPoint;
			set => SetProperty(ref _unloadingPoint, value);
		}

		private string _messageType;
		/// <summary>
		/// Get or Set for {MessageType}.
		/// </summary>
		[DataMember]
		[StringLength(6)]
		public string MessageType
		{
			get => _messageType;
			set => SetProperty(ref _messageType, value);
		}

		private Guid _userGuid;
		/// <summary>
		/// Get or Set for {UserGuid}.
		/// </summary>
		[DataMember]
		public Guid UserGuid
		{
			get => _userGuid;
			set => SetProperty(ref _userGuid, value);
		}

		/// <summary>
		/// Local variable _customerBusinessGroupGuid     
		/// </summary>
		private Guid? _customerBusinessGroupGuid;
		/// <summary>
		/// Get or Set for {CustomerBusinessGroupGuid}.
		/// </summary>
		[DataMember]
		public Guid? CustomerBusinessGroupGuid
		{
			get => _customerBusinessGroupGuid;
			set => _customerBusinessGroupGuid = value;
		}
		/// <summary>
		/// Local variable _customerGuid     
		/// </summary>
		private Guid? _customerGuid;
		/// <summary>
		/// Get or Set for {CustomerGuid}.
		/// </summary>
		[DataMember]
		public Guid? CustomerGuid
		{
			get => _customerGuid;
			set => _customerGuid = value;
		}

		private Guid? _uniqueGuid;
		/// <summary>
		/// Get or Set for {UniqueGuid}.
		/// </summary>
		[DataMember]	
		public Guid? UniqueGuid
		{
			get => _uniqueGuid;
			set => SetProperty(ref _uniqueGuid, value);
		}

	}
	/// <summary>
	/// Data Contract for EDIMessageHeaderProcedureParametersFilterModel
	/// </summary>
	[DataContract, Serializable]
	public class EDIMessageHeaderProcedureParametersFilterModel : BaseModel<Guid>
	{
        private DateTime _startDate;
        /// <summary>
        /// Get or Set for {StartDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;
        /// <summary>
        /// Get or Set for {DateFrom}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private string _unbSenderId;
		/// <summary>
		/// Get or Set for {UNBSenderId}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string UNBSenderId
		{
			get => _unbSenderId;
			set => SetProperty(ref _unbSenderId, value);
		}

		private string _buyerCode;
		/// <summary>
		/// Get or Set for {BuyerCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string BuyerCode
		{
			get => _buyerCode;
			set => SetProperty(ref _buyerCode, value);
		}

		private string _consigneeCode;
		/// <summary>
		/// Get or Set for {ConsigneeCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string ConsigneeCode
		{
			get => _consigneeCode;
			set => SetProperty(ref _consigneeCode, value);
		}

		private string _consignorCode;
		/// <summary>
		/// Get or Set for {ConsignorCode}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string ConsignorCode
		{
			get => _consignorCode;
			set => SetProperty(ref _consignorCode, value);
		}


		private string _accountNumber;
		/// <summary>
		/// Get or Set for {AccountNumber}.
		/// </summary>
		[DataMember]
		[StringLength(70)]
		public string AccountNumber
		{
			get => _accountNumber;
			set => SetProperty(ref _accountNumber, value);
		}


		private string _unloadingPointCode;
		/// <summary>
		/// Get or Set for {UnloadingPoint}.
		/// </summary>
		[DataMember]
		[StringLength(35)]
		public string UnloadingPointCode
		{
			get => _unloadingPointCode;
			set => SetProperty(ref _unloadingPointCode, value);
		}

		private string _ediMessageTypeCode;
		/// <summary>
		/// Get or Set for {MessageType}.
		/// </summary>
		[DataMember]
		[StringLength(8)]
		public string EDIMessageTypeCode
		{
			get => _ediMessageTypeCode;
			set => SetProperty(ref _ediMessageTypeCode, value);
		}

		private string _ediMessageFileName;
		/// <summary>
		/// Get or Set for {EdiMessageFileName}.
		/// </summary>
		[DataMember]
		[StringLength(150)]
		public string EdiMessageFileName
		{
			get => _ediMessageFileName;
			set => SetProperty(ref _ediMessageFileName, value);
		}

		private string _viewName;
		[DataMember]
		public string ViewName
		{
			get { return _viewName; }
			set { SetProperty(ref _viewName, value); }
		}


	}

}

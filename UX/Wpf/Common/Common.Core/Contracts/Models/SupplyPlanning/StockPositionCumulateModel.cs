/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   StockPositionCumulateModel.cs
Function           :   Data contract for StockPositionCumulate
Created By         :   Srashti Gupta
Created on         :   05-Nov-2020
Revision History   :   [06-Nov-2020] : Srashti Gupta
*                  :   Added new Property
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    ///  Data Contract for StockPositionCumulateModel
    /// </summary>
    [DataContract, Serializable]
    public class StockPositionCumulateModel
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        private int _openingStock;
        /// <summary>
        /// Get or Set for {OpeningStock}.
        /// </summary>
        [DataMember]
        public int OpeningStock
        {
            get => _openingStock;
            set => _openingStock = value;
        }

        private string _wareHouseCode;
        /// <summary>
        /// Get or Set for {WareHouseCode}.
        /// </summary>
        [DataMember]
        public string WareHouseCode
        {
            get => _wareHouseCode;
            set => _wareHouseCode = value;
        }

        private string _locationId;
        /// <summary>
        /// Get or Set for {LocationId}.
        /// </summary>
        [DataMember]
        public string LocationId
        {
            get => _locationId;
            set => _locationId = value;
        }
    }
}

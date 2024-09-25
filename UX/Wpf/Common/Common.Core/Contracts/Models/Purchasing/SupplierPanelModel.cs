/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierPanelModel.cs
Function           :   Supplier Panel Sets: To issue same RFQ/NPR to multiple supplier group within the  panel
Created By         :   Ajay Kumar
Created on         :   25-Aug-2019
Revision History   :   

****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of SupplierPanel
    /// </summary>
    [DataContract, Serializable]
    public class SupplierPanelModel : BaseModel<Guid>
    {

        private string _supplierPanelCode;

        /// <summary>
        /// Gets or sets a string value for the Supplier Panel Code.
        /// Maximum length is 20 characters
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string SupplierPanelCode
        {
            get => _supplierPanelCode;
            set => SetProperty(ref _supplierPanelCode, value);
        }

        private string _supplierPanelDescription;

        /// <summary>
        /// Gets or sets a string value for the Supplier Panel description
        /// Maximum length is 100 characters
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]
        public string SupplierPanelDescription
        {
            get => _supplierPanelDescription;
            set => SetProperty(ref _supplierPanelDescription, value);
        }

    }
}
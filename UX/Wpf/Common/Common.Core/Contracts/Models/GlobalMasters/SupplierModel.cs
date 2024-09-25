/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierModel.cs
Function           :  
Created By         :   
Created on         :   
Revision History   :   [16-May-2022] : Sejal Srivastava
*                  :   [] : Added new column DistributionCountryOfOriginGuid
*                      [30-Sep-2022] : Prakhar
*                  :   [] : Added new column IsEOLRequired
*                  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class SupplierModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "VARCHAR")]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _supplierName;
        [DataMember]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string SupplierName
        {
            get => _supplierName;
            set => SetProperty(ref _supplierName, value);
        }
        private string _address1 ;
        [DataMember]
        [Required]
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
 
        public string Address1
        {
            get => _address1;
            set => SetProperty(ref _address1, value);
        }
        private string _address2;
        [DataMember]
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Address2
        {
            get => _address2;
            set => SetProperty(ref _address2, value);
        }
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
        private string _address3;
        [DataMember]
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Address3
        {
            get => _address3;
            set => SetProperty(ref _address3, value);
        }

        private string _city;
        [DataMember]
        [Required]
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        private string _region;
        [DataMember]
        [StringLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }
        private string _zipCode;
        [DataMember]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }
        private Guid _countryGuid;
        [DataMember]
        [Required]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private Guid _supplierTypeGuid;
        [DataMember]
        [Required]
        public Guid SupplierTypeGuid
        {
            get => _supplierTypeGuid;
            set => SetProperty(ref _supplierTypeGuid, value);
        }

        private Guid _supplierGroupGuid;
        [DataMember]
        [Required]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }
        
        private Guid _supplierIncoTermsGuid;
        [DataMember]
        [Required]
        public Guid SupplierIncoTermsGuid
        {
            get => _supplierIncoTermsGuid;
            set => SetProperty(ref _supplierIncoTermsGuid, value);
        }

        private Guid _supplierCurrencyGuid;
        [DataMember]
        [Required]
        public Guid SupplierCurrencyGuid
        {
            get => _supplierCurrencyGuid;
            set => SetProperty(ref _supplierCurrencyGuid, value);
        }

        private Guid _supplierBuyerGuid;
        [DataMember]
        [Required]
        public Guid SupplierBuyerGuid
        {
            get => _supplierBuyerGuid;
            set => SetProperty(ref _supplierBuyerGuid, value);
        }

        private Guid _supplierDevelopmentTeamGuid;
        [DataMember]
        [Required]
        public Guid SupplierDevelopmentTeamGuid
        {
            get => _supplierDevelopmentTeamGuid;
            set => SetProperty(ref _supplierDevelopmentTeamGuid, value);
        }

        private string _paymentTerms;
        [DataMember]
        [Required]
        [MaxLength(20)]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => SetProperty(ref _paymentTerms, value);
        }

        private Guid _epoCommodityGroupGuid;
        [DataMember]
        [Required]
        public Guid EPOCommodityGroupGuid
        {
            get => _epoCommodityGroupGuid;
            set => SetProperty(ref _epoCommodityGroupGuid, value);
        }

        private Guid _poPriceEffectiveDateTypeGuid;
        [DataMember]
        public Guid POPriceEffectiveDateTypeGuid
        {
            get => _poPriceEffectiveDateTypeGuid;
            set => SetProperty(ref _poPriceEffectiveDateTypeGuid, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private Guid _supplierApprovalStatusGuid;
        [DataMember]
        [Required]
        public Guid SupplierApprovalStatusGuid
        {
            get => _supplierApprovalStatusGuid;
            set => SetProperty(ref _supplierApprovalStatusGuid, value);
        }
        private Guid _distributionCountryOfOriginGuid;
        [DataMember]
        [Required]
        public Guid DistributionCountryOfOriginGuid
        {
            get => _distributionCountryOfOriginGuid;
            set => SetProperty(ref _distributionCountryOfOriginGuid, value);
        }
        private bool _isEOLRequired = false;
        /// <summary>
        /// SWS Part Number Required
        /// </summary>
        [DataMember]
        public bool IsEOLRequired
        {
            get => _isEOLRequired;
            set => SetProperty(ref _isEOLRequired, value);
        }

        /// <summary>
        /// Validation on properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public override string this[string propertyName]
        {
            get
            {
                Error = string.Empty;
                try
                {
                    switch (propertyName)
                    {
                        // Sample Implementation
                        //case nameof(CountryName): Error = _countryName.Length < 5 ? "Name must be greater than 4 characters" : null; break;
                        //case nameof(SuppName): Error = XamDataGridValidation.CheckForBlank(_suppName); break;
                        //case nameof(SuppAddress1): Error = XamDataGridValidation.CheckForBlank(_suppAddress1); break;
                        //case nameof(SupplierGroup): Error = XamDataGridValidation.CheckForBlank(_supplierGroup); break;
                        //case nameof(PUCode): Error = XamDataGridValidation.CheckForBlank(_pUCode); break;
                        //case nameof(SDECode): Error = XamDataGridValidation.CheckForBlank(_sDECode); break;
                        //case nameof(SuppTariffContactId):
                        //    if (TariffNotifyFlg == true)
                        //        Error = XamDataGridValidation.CheckValidEmail(_suppTariffContactId);
                        //    else
                        //        Error = "";
                        //    break;
                        default: break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;

            }
        }
    }
}
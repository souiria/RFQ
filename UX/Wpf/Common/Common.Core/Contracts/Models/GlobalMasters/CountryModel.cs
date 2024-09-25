using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    [KnownType(typeof(CountryModel))]
    public class CountryModel : BaseModel<Guid>
    {
        private string _countryName;
        [DataMember]
        [StringLength(50)]
        public string CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }

        private string _alpha2Code;
        [DataMember]
        [StringLength(2)]
        public string Alpha2Code
        {
            get => _alpha2Code;
            set => SetProperty(ref _alpha2Code, value);
        }

        private string _alpha3Code;
        [DataMember]
        [StringLength(3)]
        public string Alpha3Code
        {
            get => _alpha3Code;
            set => SetProperty(ref _alpha3Code, value);
        }

        private string _unCode;
        [DataMember]
        [StringLength(3)]
        public string UNCode
        {
            get => _unCode;
            set => SetProperty(ref _unCode, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
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
                        case nameof(CountryName):
                            if (_countryName != null)
                                Error = _countryName.Length > 50 ? "Country Name cannot be greater than 50 characters" : null;
                            else
                                Error = "Country Name cannot be left empty";
                            break;
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
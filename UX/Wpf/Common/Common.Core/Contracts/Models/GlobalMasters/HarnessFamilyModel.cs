using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class HarnessFamilyModel : BaseModel<Guid>
    {

        private string _harnessFamilyCode;
        [DataMember]
        [Required]
        [StringLength(40)]
        public string HarnessFamilyCode
        {
            get => _harnessFamilyCode;
            set => SetProperty(ref _harnessFamilyCode, value);
        }
        private string _harnessFamilyName;
        [DataMember]
        [StringLength(50)]
        public string HarnessFamilyName
        {
            get => _harnessFamilyName;
            set => SetProperty(ref _harnessFamilyName, value);
        }

        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(HarnessFamilyName)
        };
        /// <summary>
        /// Method to validate properties
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
                        case nameof(HarnessFamilyName) when string.IsNullOrWhiteSpace(HarnessFamilyName):
                            Error = "HarnessFamilyName must not be empty."; break;


                        default:
                            Error = null; break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;
            }
        }

        #endregion

    }
}

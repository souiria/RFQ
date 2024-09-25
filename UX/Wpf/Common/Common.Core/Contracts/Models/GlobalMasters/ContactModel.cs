using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ContactModel : BaseModel<Guid>
    {
        private Guid _contactTypeGuid;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid ContactTypeGuid
        {
            get => _contactTypeGuid;
            set => SetProperty(ref _contactTypeGuid, value);
        }
        //private string _contactType;
        //[DataMember]
        //[Required]
        //[StringLength(20)]
        //public string ContactType
        //{
        //    get => _contactType;
        //    set => SetProperty(ref _contactType, value);
        //}

        private string _code;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }


        private string _contactFirstName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ContactFirstName
        {
            get => _contactFirstName;
            set => SetProperty(ref _contactFirstName, value);
        }


        private string _contactLastName;
        [DataMember] 
        [StringLength(50)]
        public string ContactLastName
        {
            get => _contactLastName;
            set => SetProperty(ref _contactLastName, value);
        }


        private string _contactNo;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ContactNo
        {
            get => _contactNo;
            set => SetProperty(ref _contactNo, value);
        }
        private string _otherContactNo;
        [DataMember]
        [StringLength(100)]
        public string OtherContactNo
        {
            get => _otherContactNo;
            set => SetProperty(ref _otherContactNo, value);
        }

        private string _faxNo;
        [DataMember]
        [StringLength(100)]
        public string FaxNo
        {
            get => _faxNo;
            set => SetProperty(ref _faxNo, value);
        }

        private string _emailId;
        [DataMember]
        [StringLength(120)]
        public string EmailId
        {
            get => _emailId;
            set => SetProperty(ref _emailId, value);
        }  

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}

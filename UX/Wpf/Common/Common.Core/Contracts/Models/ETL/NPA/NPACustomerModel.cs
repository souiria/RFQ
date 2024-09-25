using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, Serializable]
    public class NPACustomerModel : BindableBaseEntity, IEntity<long>
    {
        private long _id;
        [DataMember, Key]
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        object IEntity.Id
        {
            get => Id;
            set => Id = (long)Convert.ChangeType(value, typeof(long));
        }

        private string _code;
        [DataMember, Column("code")]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _name;
        [DataMember, Column("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private long? _subsidiaryID;
        [DataMember, Column("subsidiary_id")]
        public long? SubsidiaryID
        {
            get => _subsidiaryID;
            set => SetProperty(ref _subsidiaryID, value);
        }

        private long? _buyerID;
        [DataMember, Column("buyer_id")]
        public long? BuyerID
        {
            get => _buyerID;
            set => SetProperty(ref _buyerID, value);
        }

        private string _address;
        [DataMember, Column("address")]
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _phone;
        [DataMember, Column("phone")]
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        private string _email;
        [DataMember, Column("email")]
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _contact;
        [DataMember, Column("contact")]
        public string Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private string _alternateContact;
        [DataMember, Column("alternate_contact")]
        public string AlternateContact
        {
            get => _alternateContact;
            set => SetProperty(ref _alternateContact, value);
        }

        private bool? _active;
        [DataMember, Column("active")]
        public bool? Active
        {
            get => _active;
            set => SetProperty(ref _active, value);
        }

        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public Guid CreatedBy { get; set; }
        [NotMapped]
        public Guid ModifiedBy { get; set; }
        [NotMapped]
        public byte[] Version { get; set; }
    }
}

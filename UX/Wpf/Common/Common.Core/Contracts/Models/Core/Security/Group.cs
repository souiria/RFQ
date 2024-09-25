using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Security
{
    [DataContract, Serializable, NotMapped]
    public class Group : BindableBaseEntity, IEquatable<Group>
    {
        public Group() { }

        public Group(Guid id, string name)
        {
            Id = id;
            ActiveDirectoryName = name;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string ActiveDirectoryName { get; set; }

        [DataMember, NotMapped]
        public List<string> MemberOf { get; set; }

        private bool _isSelected;
        [DataMember]
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        #region IEquatable<Group>

        public bool Equals(Group other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Group group)
                return Equals(group);
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}

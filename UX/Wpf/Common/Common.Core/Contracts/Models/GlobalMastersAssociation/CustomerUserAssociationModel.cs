using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class CustomerUserAssociationModel : BaseModel<Guid>
    {
        private Guid _userGuid;
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private List<Guid> _customerHierarchyList;
        [DataMember]
        [Required]
        public List<Guid> CustomerHierarchyList
        {
            get => _customerHierarchyList;
            set => SetProperty(ref _customerHierarchyList, value);
        }

    }
}

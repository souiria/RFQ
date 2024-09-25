/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ContactTypeModel.cs
Function           :   Contact Type
Created By         :   Pawan Kumar
Created on         :   31-May-2018
Revision History   :   [] : Pawan
                    :  [17-Jun-2019]: Data contract field [IsInternal] added as per mail
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ContactTypeModel : BaseModel<Guid>
    {
        private string _contactTypeName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ContactTypeName
        {
            get => _contactTypeName;
            set => SetProperty(ref _contactTypeName, value);
        }

        private bool _isInternal = false;
        [DataMember]
        public bool IsInternal
        {
            get => _isInternal;
            set => SetProperty(ref _isInternal, value);
        }
    }
}

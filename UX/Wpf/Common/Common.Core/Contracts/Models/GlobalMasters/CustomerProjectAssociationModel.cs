/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProjectAssociationModel.cs
Function           :   CustomerProjectAssociation
Created By         :   Prakhar Singh  
Created on         :   [15-Jul-2022]
Revision History   :  [04-Aug-2023]: Dhamendra Kumar
                   :   [] Add New Property IsActive
                   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters
{

    /// Represents a CustomerProjectAssociation
    [DataContract, Serializable]
    public class CustomerProjectAssociationModel : BaseModel<Guid>
    {

        private Guid _projectGuid;

        /// get or set for projectguid

        [DataMember]
        [Required]
        public Guid ProjectGuid
        
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid _customerGuid;

        /// get or set for customerguid
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }


        private Guid _id;

        /// get or set for id
        [DataMember]
        public Guid ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private bool _isActive = true;
        [DataMember]
        public  bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }


    }

    /// Represents a ShowCustomerProjectAssociation
    [DataContract, Serializable]
    public class ShowCustomerProjectAssociation: CustomerProjectAssociationModel
    {
        private string _projectName;

        /// get or set for projectname

        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        private string _customerName;

        /// get or set for customername
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }
    }


}

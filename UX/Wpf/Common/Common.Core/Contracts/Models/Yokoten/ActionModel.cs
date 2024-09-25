/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ActionModel.cs
Function           :   Data contract for Action Model
Created By         :   Shivam Dhingra
Created on         :   24-March-2020
Revision History   :   [04-May-2020] : Pawan
                   :   [] : Added field for Action
                   :   [09-Jun-2020] : Pawan
                   :   [] : Added field for Action Document List
                   :   [24-Jul-2020] : Pawan
                   :   [] : Added field for IsNotify and UserGuid
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ActionModel : BaseModel<Guid>
    {
        private string _action;
        /// <summary>
        /// This field will set Action
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }
        private string _completedBy;
        /// <summary>
        /// This field will set CompletedBy
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string CompletedBy
        {
            get => _completedBy;
            set => SetProperty(ref _completedBy, value);
        }

        private bool _isNotify;
        /// <summary>
        /// This field will set IsNotify
        /// </summary>
        [DataMember]
        public bool IsNotify
        {
            get => _isNotify;
            set => SetProperty(ref _isNotify, value);
        }

        private Guid _completedByUserGuid;
        /// <summary>
        /// This field will set CompletedByUserGuid
        /// </summary>
        [DataMember]
        public Guid CompletedByUserGuid
        {
            get => _completedByUserGuid;
            set => SetProperty(ref _completedByUserGuid, value);
        }

        private DateTime _completedDate;
        /// <summary>
        /// This field will set CompletedDate
        /// </summary>
        [DataMember]
        public DateTime CompletedDate
        {
            get => _completedDate;
            set => SetProperty(ref _completedDate, value);
        }

        private string _progressPercentage;
        /// <summary>
        /// This field will set ProgressPercentage
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProgressPercentage
        {
            get => _progressPercentage;
            set => SetProperty(ref _progressPercentage, value);
        }

        private string _evidence;
        /// <summary>
        /// This field will set Evidence
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Evidence
        {
            get => _evidence;
            set => SetProperty(ref _evidence, value);
        }

        private List<FileUploadModel> _actionDocumentList;
        /// <summary>
        /// This field will set ActionDocumentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> ActionDocumentList
        {
            get => _actionDocumentList;
            set => SetProperty(ref _actionDocumentList, value);
        }

    }
}

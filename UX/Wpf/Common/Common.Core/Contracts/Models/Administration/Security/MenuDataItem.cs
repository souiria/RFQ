using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class MenuDataItem 
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _displayName;
        [DataMember]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
}

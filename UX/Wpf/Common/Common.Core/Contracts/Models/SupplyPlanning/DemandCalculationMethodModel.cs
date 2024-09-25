using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
    public class DemandCalculationMethodModel : BaseModel<Guid>
    {

        /// <summary>
        /// Local variable _methodName     
        /// </summary>
        private string _methodName;
        /// <summary>
        /// Get or Set for {MethodName}.
        /// </summary>

        [DataMember]
        [StringLength(50)]
        public string MethodName
        {
            get => _methodName;
            set => SetProperty(ref _methodName, value);
        }

        /// <summary>
        /// Local variable _remarks     
        /// </summary>
        private string _remarks;
        /// <summary>
        /// Get or Set for {Remarks}.
        /// </summary>

        [DataMember]
        [StringLength(150)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }


    }
}

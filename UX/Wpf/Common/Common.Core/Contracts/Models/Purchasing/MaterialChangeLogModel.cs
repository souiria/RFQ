using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialChangeLogModel : BaseModel<Guid>
    {
    }
}

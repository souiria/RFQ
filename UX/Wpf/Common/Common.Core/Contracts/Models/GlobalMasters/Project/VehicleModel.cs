/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   VehicleModel.cs
Function           :   Vehicle Model
Created By         :   Aditya Rastogi
Created on         :   18-Oct-2019
Revision History   :   [18-Oct-2019] : Aditya
                   :   [ ] : Added VehicleVolumePerAnnum 
                   
****************************************************************************************************/
using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Project
{
    [DataContract]
    public class VehicleModel : BaseModel<Guid>, IValidatable
    {
        private string _code;

        [DataMember]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private int _vehicleVolumePerAnnum;

        [DataMember]
        public int VehicleVolumePerAnnum
        {
            get => _vehicleVolumePerAnnum;
            set => SetProperty(ref _vehicleVolumePerAnnum, value);
        }

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(Code)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Name) when string.IsNullOrWhiteSpace(Name):
                        return "Name can not be empty.";

                    case nameof(Code) when string.IsNullOrWhiteSpace(_code):
                        return "Code can not be empty.";

                    default:
                        return null;
                }
            }
        }
    }
}

/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  VehicleModel.cs
Function           :  Vehicle Model
Created By         :  Dharmendra Kumar
Created on         :    20-Jan-2023
Revision History   : [20-Jan-2023]:Dharmendar Kumar 
                   : Modified Existing Vehicle as per HD call:00371199  
                   : [31-Jan-2023]:Prakhar 
                   : [HD Call - 00371661] Added new Model Class GetAllVehicleModel for Getall Vehicle.  
                   : [21-Mar-2023]:Prakhar 
                   : [HD Call - 00370582] Added Model Class VehicleUXModel for new master Screen Vehicle.  
                   : [21-Apr-2023]:Prakhar 
                   : Added new property IsActive in VehicleModel  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class VehicleModel 
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _vehicleName;
        [DataMember]
        public string VehicleName
        {
            get => _vehicleName;
            set => _vehicleName = value;
        }
        private string _projectReference;
        [DataMember]
        public string ProjectReference
        {
            get => _projectReference;
            set => _projectReference = value;
        }
        private string _vehicleDisplay;
        [DataMember]
        public string VehicleDisplay
        {
            get => _vehicleDisplay;
            set => _vehicleDisplay = value;
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

    }

    //For new Screen Vehicle
    [DataContract, Serializable]
    public class VehicleUXModel : BaseModel<Guid>
    {
       
        private string _vehicleName;
        [DataMember]
        public string VehicleName
        {
            get => _vehicleName;
            set => SetProperty(ref _vehicleName, value);
        }
        private string _projectReference;
        [DataMember]
        public string ProjectReference
        {
            get => _projectReference;
            set => SetProperty (ref _projectReference, value);
        }
        private string _vehicleDisplay;
        [DataMember]
        public string VehicleDisplay
        {
            get => _vehicleDisplay;
            set => SetProperty(ref _vehicleDisplay, value);
        }

       
    }



    //Prakhar
    public class GetAllVehicleModel
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _vehicleName;
        [DataMember]
        public string VehicleName
        {
            get => _vehicleName;
            set => _vehicleName = value;
        }
        private string _vehicleDisplay;
        [DataMember]
        public string VehicleDisplay
        {
            get => _vehicleDisplay;
            set => _vehicleDisplay = value;
        }
    }
}

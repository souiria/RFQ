using System;
using System.Collections.Generic;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.SharedKernel;

namespace UX.Module.Edi.Core.Messages.Requests
{
    public class EdiCustomerParameterRequest : RequestBase
    {
        //"userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        //"isCompressed": false,
        //"hasHeartBeat": true,
        //"moduleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        //"requestType": 1
        public EdiCustomerParameterRequestType RequestType { get; set; }
        public List<EdiCustomerParameterDto> CustomerParameters { get; set; }

        public EdiCustomerParameterRequest()
        {
            UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            IsCompressed = false;
            HasHeartBeat = true;
            ModuleId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            RequestType = EdiCustomerParameterRequestType.GetAllEdiCustomerParameters;
            CustomerParameters = new List<EdiCustomerParameterDto>();
        }

    }

    public enum EdiCustomerParameterRequestType
    {
        CheckForHeartBeat,
        GetAllEdiCustomerParameters,
        SaveEdiCustomerParameters
    }
}

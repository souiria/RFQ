using System;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingTariffContentEmailModel
    {
        private string _tariffContentEmail;
        [DataMember]
        public string TariffContentEmail
        {
            get { return _tariffContentEmail; }
            set { _tariffContentEmail = value; }
        }

        private Guid _contactGuid;
        [DataMember]
        public Guid ContactGuid
        {
            get { return _contactGuid; }
            set { _contactGuid = value; }
        }
    }
}

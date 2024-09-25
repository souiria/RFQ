using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("BranchInsulationThroughNode")]
    public class BranchInsulationThroughNodeModel : BaseModel<Guid>
    {
        private string _pieceCode;
        [DataMember]
        public string PieceCode
        {
            get => _pieceCode;
            set => SetProperty(ref _pieceCode, value);
        }

        private double _throughOrder;
        [DataMember]
        public double ThroughOrder
        {
            get => _throughOrder;
            set => SetProperty(ref _throughOrder, value);
        }

        private string _throughNode;
        [DataMember]
        public string ThroughNode
        {
            get => _throughNode;
            set => SetProperty(ref _throughNode, value);
        }

        private string _throughRoute;
        [DataMember]
        public string ThroughRoute
        {
            get => _throughRoute;
            set => SetProperty(ref _throughRoute, value);
        }

        private bool _isThroughFlag;
        [DataMember]
        public bool IsThroughFlag
        {
            get => _isThroughFlag;
            set => SetProperty(ref _isThroughFlag, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }
    }
}

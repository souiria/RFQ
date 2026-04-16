using System.ComponentModel.DataAnnotations;

namespace SalesSystem.Rfq.Models
{
    public class RfqNprRequestSampleSiteDataUxModel
    {
        #region API Properties
        /// <summary>Business Unit Code</summary>
        [MaxLength(4)]
        public string? BusinessUnitCode
        { get; set; }

        /// <summary>Sample Qty</summary>
        public int? SampleQty
        { get; set; }

        /// <summary>Username (Master)</summary>
        [MaxLength(100)]
        public string? SendSampleContactPersonName
        { get; set; }

        /// <summary>yyyy-MM-dd</summary>
        public DateTime? RequiredDate
        { get; set; }

        /// <summary>(Free Text)</summary>
        public string? FreightAccount
        { get; set; }

        #endregion

        #region Local Properties

        UxObjectStatus _UxStatus;
        public UxObjectStatus UxStatus
        {
            get
            {
                return _UxStatus;
            }
            set
            {
                if (_UxStatus != value)
                {
                    _UxStatus = value;
                    if (_UxStatus == UxObjectStatus.Deleted)
                    {
                        _IsActive = false;
                    }
                    else
                    {
                        _IsActive = true;
                    }
                }
            }
        }

        bool _IsActive;
        public bool IsActive => _IsActive;

        #endregion

        #region Constructors

        public RfqNprRequestSampleSiteDataUxModel()
        {
            UxStatus = UxObjectStatus.Created;
        }

        #endregion
    }
}
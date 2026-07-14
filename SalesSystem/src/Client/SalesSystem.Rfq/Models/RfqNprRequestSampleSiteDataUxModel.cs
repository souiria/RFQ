// version History:
// 1.0 - Initial development - NPR_RFQ_API_Documentation_v1.pdf - 20260415
// 1.2 - No changes - NPR_RFQ_API_Documentation_v1.2.pdf - 20260416
// 1.3 - Description change - NPR_RFQ_API_Documentation_v1.3.pdf - 20260416
//       BusinessUnitCode sourced from Master data, description updated to reflect that

namespace SalesSystem.Rfq.Models
{
    public class RfqNprRequestSampleSiteDataUxModel
    {
        #region API Properties
        /// <summary>Business Unit Code (Master)</summary>
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
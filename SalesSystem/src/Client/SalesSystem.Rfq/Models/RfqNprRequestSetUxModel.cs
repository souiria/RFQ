using DocumentFormat.OpenXml.Office2010.Excel;

namespace SalesSystem.Rfq.Models
{
    public class RfqNprRequestSetUxModel
    {
        readonly List<RfqNprRequestUxModel> _NprRequests;

        #region Properties

        public Guid Id
        { get; set; }

        public string? RfqNumber
        { get; set; }
        public DateTime Created
        { get; internal set; }
        public NprSetRequestStatus Status
        { get; internal set; }
        public DateTime Updated
        { get; internal set; }
        public ReadOnlyCollection<RfqNprRequestUxModel> NprRequests => _NprRequests.AsReadOnly();

        #endregion

        #region Constructors

        public RfqNprRequestSetUxModel()
        {
            Id = Guid.NewGuid();
            _NprRequests = new();
            Status = NprSetRequestStatus.LocalUpdated; // needs to be saved
        }

        internal void AddNprRequest(RfqNprRequestUxModel newRequest)
        {
            _NprRequests.Add(newRequest);
            Updated = DateTime.Now;
            Status = NprSetRequestStatus.LocalUpdated;
        }

        internal bool ReplaceNprRequest(RfqNprRequestUxModel updatedRequest)
        {
            if (updatedRequest == null)
            {
                throw new ArgumentNullException(nameof(updatedRequest));
            }

            RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(x => x.Id == updatedRequest.Id);
            if (request == null)
            {
                return false;
            }

            _NprRequests.Remove(request);
            _NprRequests.Add(updatedRequest);

            Updated = DateTime.UtcNow;
            Status = NprSetRequestStatus.LocalUpdated;
            return true;
        }

        internal bool RemoveNprRequest(Guid requestId)
        {
            RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(x => x.Id == requestId);
            if (request == null)
            {
                return false;
            }

            _NprRequests.Remove(request);

            Updated = DateTime.UtcNow;
            Status = NprSetRequestStatus.LocalUpdated;
            return true;
  
        }

        #endregion
    }
}

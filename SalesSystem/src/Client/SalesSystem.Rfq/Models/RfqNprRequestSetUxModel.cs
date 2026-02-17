namespace SalesSystem.Rfq.Models
{
    public class RfqNprRequestSetUxModel
    {
        #region Fields
        List<RfqNprRequestUxModel> _NprRequests;
        #endregion

        #region Properties

        public Guid Id
        { get; set; }

        public string? RfqNumber
        { get; set; }
        public DateTime Created
        { get; set; }
        public NprSetRequestStatus Status
        { get; set; }
        public DateTime Updated
        { get; set; }
        //public ReadOnlyCollection<RfqNprRequestUxModel> NprRequests => _NprRequests.AsReadOnly();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "While in Dev/Test mode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "While in Dev/Test mode")]
        public List<RfqNprRequestUxModel> NprRequests
        {
            get => _NprRequests;
            set => _NprRequests = value ?? new List<RfqNprRequestUxModel>();
        }
        public DateTime? Closed
        { get; set; }

        public Guid ProjectId
        { get; set; }

        public RfqProjectUx? Project
        { get; set; }

        #endregion

        #region Constructors

        public RfqNprRequestSetUxModel()
        {
            Id = Guid.NewGuid();
            _NprRequests = new();
            Status = NprSetRequestStatus.LocalUpdated; // needs to be saved
        }
        #endregion

        #region Operations
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

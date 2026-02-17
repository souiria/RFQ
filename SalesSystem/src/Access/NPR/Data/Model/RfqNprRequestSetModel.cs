namespace NPR.Data.Model
{
    public class RfqNprRequestSetModel
    {
        #region Fields
        List<RfqNprRequestModel> _NprRequests;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "While in Dev/Test mode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "While in Dev/Test mode")]
        public List<RfqNprRequestModel> NprRequests
        {
            get => _NprRequests;
            set => _NprRequests = value ?? new List<RfqNprRequestModel>();
        }

        public DateTime? Closed 
        { get; set; }

        public Guid ProjectId 
        { get; set; }
        public RfqProjectInfo? Project 
        { get; set; }

        #endregion

        #region Constructors

        public RfqNprRequestSetModel()
        {
            Id = Guid.NewGuid();
            _NprRequests = new();
            Status = NprSetRequestStatus.LocalUpdated; // needs to be saved
        }

        #endregion

        #region Operations
        internal void AddNprRequest(RfqNprRequestModel newRequest)
        {
            _NprRequests.Add(newRequest);
            Updated = DateTime.UtcNow;
            Status = NprSetRequestStatus.LocalUpdated;
        }

        internal bool ReplaceNprRequest(RfqNprRequestModel updatedRequest)
        {
            ArgumentNullException.ThrowIfNull(updatedRequest);

            RfqNprRequestModel? existing = _NprRequests.FirstOrDefault(x => x.Id == updatedRequest.Id);
            if (existing == null)
            {
                return false;
            }

            _NprRequests.Remove(existing);
            _NprRequests.Add(updatedRequest);

            Updated = DateTime.UtcNow;
            Status = NprSetRequestStatus.LocalUpdated;
            return true;
        }

        internal bool RemoveNprRequest(Guid requestId)
        {
            RfqNprRequestModel? existing = _NprRequests.FirstOrDefault(x => x.Id == requestId);
            if (existing == null)
            {
                return false;
            }

            _NprRequests.Remove(existing);

            Updated = DateTime.UtcNow;
            Status = NprSetRequestStatus.LocalUpdated;
            return true;
        }
        #endregion
    }
}
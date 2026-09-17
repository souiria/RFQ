namespace SalesSystem.Rfq.Models
{
    public class RfqProjectUxModel
    {
        #region Fields
        List<RfqNprRequestUxModel> _NprRequests;
        #endregion

        #region Properties
        public long RowId
        { get; set; }
        public string RfqNumber
        { get; set; }
        public string CustomerBusinessUnitId
        { get; set; }
        public string? CustomerBusinessUnit
        { get; set; }
        public string CustomerLocationId
        { get; set; }
        public string? CustomerLocation
        { get; set; }
        public string ProjectId
        { get; set; }
        public string? Project
        { get; set; }
        public int RfqReasonId
        { get; set; }
        public string? RfqReasonName
        { get; set; }
        public DateTime? RfqResponseDeadline
        { get; set; }
        public string CarModelId
        { get; set; }
        public string? CarModel
        { get; set; }
        public int VehicleVolume
        { get; set; }
        public bool IsActive
        { get; set; }
        public string CustomerCode
        { get; set; }
        public string? ProjectName
        { get; set; }
        public string? CustomerBusinessGroupCode
        { get; set; }
        public string? CustomerLocationName
        { get; set; }
        public string? CarModelName
        { get; set; }
        public string? JsonData 
        { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "While in Dev/Test mode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "While in Dev/Test mode")]
        public List<RfqNprRequestUxModel> NprRequests
        {
            get => _NprRequests;
            set => _NprRequests = value ?? new List<RfqNprRequestUxModel>();
        }
        #endregion

        #region Ctor
        public RfqProjectUxModel()
        {
            RfqNumber = "";
            CustomerBusinessUnitId = string.Empty;
            CustomerLocationId = string.Empty;
            ProjectId = string.Empty;
            CarModelId = string.Empty;
            VehicleVolume = 0;
            ProjectId = string.Empty;
            RfqReasonId = 0;
            IsActive = false;
            CustomerCode = string.Empty;
            ProjectName = string.Empty;
            JsonData = string.Empty;
            _NprRequests = new();

        }
        #endregion

        #region Npr Requests

        #region Derived Properties
        public bool HasLocalChanges => _NprRequests.Any(r => r.UxStatus == UxObjectStatus.Updated);
        public DateTime? LastUpdated => 0 <= _NprRequests.Count
            ? _NprRequests.Max(r => r.Updated)
            : null;

        public DateTime? EarliestCreated => 0 <= _NprRequests.Count
            ? _NprRequests.Min(r => r.Created)
            : null;
        #endregion

        #region Operations
        public void AddNprRequest(RfqNprRequestUxModel newRequest)
        {
            ArgumentNullException.ThrowIfNull(newRequest);

            newRequest.Updated = DateTime.UtcNow;
            newRequest.UxStatus = UxObjectStatus.Created;

            _NprRequests.Add(newRequest);
        }

        public bool ReplaceNprRequest(RfqNprRequestUxModel updatedRequest)
        {
            ArgumentNullException.ThrowIfNull(updatedRequest);

            RfqNprRequestUxModel? existing = _NprRequests.FirstOrDefault(x => x.Id == updatedRequest.Id);
            if (existing == null)
            {
                return false;
            }

            _NprRequests.Remove(existing);

            updatedRequest.Updated = DateTime.UtcNow;
            updatedRequest.UxStatus = UxObjectStatus.Updated;

            _NprRequests.Add(updatedRequest);

            return true;
        }

        public bool RemoveNprRequest(Guid requestId)
        {
            RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(x => x.Id == requestId);
            if (request == null)
            {
                return false;
            }

            _NprRequests.Remove(request);

            return true;
        }

        public void SetAllStatus(RfqNprRequestSet status)
        {
            DateTime now = DateTime.UtcNow;
            foreach (RfqNprRequestUxModel request in _NprRequests)
            {
                request.Status = status;
                request.Updated = now;
            }
        }

        #endregion

        #endregion
    }
}

namespace SalesSystem.Rfq.Components.Pages.Components
{
    /// <summary>
    ///     Renders the "In progress" / "Completed" part-number lists for an RFQ and
    ///     owns the per-item add/move/delete bookkeeping between the two lists.
    ///     The parent page still owns the underlying lists (so it can combine/save/
    ///     search/reload them) and is notified via <see cref="OnPartsChanged" />
    ///     whenever this component changes their contents.
    /// </summary>
    public partial class RfqPartsListPanel
    {
        [Parameter]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Shared mutable list owned by parent page")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Parameter must be settable by Blazor component framework")]
        public List<RfqDrawingPartNumberUxModel> CompletedParts { get; set; } = new List<RfqDrawingPartNumberUxModel>();

        [Parameter]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Shared mutable list owned by parent page")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Parameter must be settable by Blazor component framework")]
        public List<RfqDrawingPartNumberUxModel> InProgressParts { get; set; } = new List<RfqDrawingPartNumberUxModel>();

        /// <summary>
        ///     Raised after a part is deleted, moved between lists, or updated in place.
        /// </summary>
        [Parameter]
        public EventCallback OnPartsChanged { get; set; }

        [Inject]
        ILogger<RfqPartsListPanel> Logger { get; set; } = null!;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task HandlePartNumberDeleted(RfqDrawingPartNumberUxModel deletedItem)
        {
            try
            {
                if (deletedItem.IsCompleted)
                {
                    CompletedParts.Remove(deletedItem);
                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberDeleted - Removed matched part: {deletedItem.CustomerPartNumber}");
                }
                else
                {
                    InProgressParts.Remove(deletedItem);
                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberDeleted - Removed unmatched part: {deletedItem.CustomerPartNumber}");
                }

                await OnPartsChanged.InvokeAsync();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"RfqPartsListPanel.HandlePartNumberDeleted - Invalid operation error handling deletion of part: {deletedItem.CustomerPartNumber}", ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"RfqPartsListPanel.HandlePartNumberDeleted - Argument null error handling deletion of part: {deletedItem.CustomerPartNumber}", ex);
                throw;
            }
        }

        async Task HandlePartNumberUpdated(RfqDrawingPartNumberUxModel updatedItem)
        {
            try
            {
                RfqDrawingPartNumberUxModel? matchedItem =
                    CompletedParts.FirstOrDefault(p =>
                        ReferenceEquals(p, updatedItem) ||
                        (updatedItem.RowId != 0 && p?.RowId == updatedItem.RowId));

                RfqDrawingPartNumberUxModel? unmatchedItem =
                    InProgressParts.FirstOrDefault(p =>
                        ReferenceEquals(p, updatedItem) ||
                        (updatedItem.RowId != 0 && p?.RowId == updatedItem.RowId));

                bool isInCompletedList = matchedItem != null;
                bool isInInProgressList = unmatchedItem != null;

                if (updatedItem.IsCompleted && isInInProgressList && unmatchedItem is not null)
                {
                    InProgressParts.Remove(unmatchedItem);

                    if (!CompletedParts.Contains(updatedItem))
                    {
                        CompletedParts.Add(updatedItem);
                    }

                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberUpdated - Moved part to matched: {updatedItem.CustomerPartNumber}");
                }
                else if (!updatedItem.IsCompleted && isInCompletedList && matchedItem is not null)
                {
                    CompletedParts.Remove(matchedItem);

                    if (!InProgressParts.Contains(updatedItem))
                    {
                        InProgressParts.Add(updatedItem);
                    }

                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberUpdated - Moved part to unmatched: {updatedItem.CustomerPartNumber}");
                }
                else if (isInCompletedList && matchedItem is not null)
                {
                    int index = CompletedParts.IndexOf(matchedItem);
                    if (index >= 0)
                    {
                        CompletedParts[index] = updatedItem;
                    }

                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberUpdated - Updated matched part: {updatedItem.CustomerPartNumber}");
                }
                else if (isInInProgressList && unmatchedItem is not null)
                {
                    int index = InProgressParts.IndexOf(unmatchedItem);
                    if (index >= 0)
                    {
                        InProgressParts[index] = updatedItem;
                    }

                    Logger.GenericLogInformation($"RfqPartsListPanel.HandlePartNumberUpdated - Updated unmatched part: {updatedItem.CustomerPartNumber}");
                }

                await OnPartsChanged.InvokeAsync();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"RfqPartsListPanel.HandlePartNumberUpdated - Invalid operation error handling update of part: {updatedItem.CustomerPartNumber}", ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"RfqPartsListPanel.HandlePartNumberUpdated - Argument null error handling update of part: {updatedItem.CustomerPartNumber}", ex);
            }
        }
    }
}

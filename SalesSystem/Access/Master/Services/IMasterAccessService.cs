namespace Master.Services
{
    public interface IMasterAccessService
    {
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
    }
}

namespace SFS.Services
{
    public class SFSAccessService : ISFSAccessService
    {
        #region In Memory Datasets

        CarModelListViewGrpc _CarModelGrpcs;

        #endregion

        #region Fields and Properties
        bool _CarModelRefreshInProgress;
        #endregion
        readonly IServiceProvider _ServiceProvider;
        public SFSAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            _CarModelGrpcs = new CarModelListViewGrpc();
            _CarModelRefreshInProgress = false;

            _ServiceProvider = serviceProvider;
            if (testing)
            {

            }
        }
          async Task<bool> PopulateCarModelData(CancellationToken cancellationToken)
        {

            // TBD: Implement database loading logic here.
            await Task.Delay(1, cancellationToken);

            if (!_CarModelRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                  _CarModelRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        public async Task<CarModelListViewGrpc> GetAllCarModel(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            await PopulateCarModelData(cancellationToken);
            return _CarModelGrpcs;
        }
    }
}

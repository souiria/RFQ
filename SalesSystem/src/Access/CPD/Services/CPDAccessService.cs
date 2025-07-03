namespace CPD.Services
{
    public class CPDAccessService : ICPDAccessService
    {
        #region In Memory Datasets

        #region MatSuppMst

        ListMatSuppMstGrpc _ListMatSuppMstView;
        #endregion
        #endregion

        #region Fields and Properties

        #region MatSuppMst

        IQueryHandler<GetMattSuppMstViewQuery, List<MatSuppMstViewGrpc>>? _MatSuppMstViewHandler;
        bool _MatSuppMstViewRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public CPDAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region MatSuppMst
            _ListMatSuppMstView = new ListMatSuppMstGrpc();
            _MatSuppMstViewRefreshInProgress = false;
            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region MatSuppMst
        public async Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMatSuppMstView.MatSuppMstViewGrpc.Any())
            {
                return _ListMatSuppMstView;
            }
            else
            {
                await PopulateMatSuppMstView(cancellationToken);
                return _ListMatSuppMstView;
            }
        }
        #endregion
        #endregion

        #region Data Imports
        #region MatSuppMst
        public async Task<bool> PopulateMatSuppMstView(CancellationToken cancellationToken)
        {
            if (!_MatSuppMstViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _MatSuppMstViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMattSuppMstViewQuery, List<MatSuppMstViewGrpc>>>();
                    _MatSuppMstViewRefreshInProgress = true;
                    GetMattSuppMstViewQuery query = new GetMattSuppMstViewQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MatSuppMstViewGrpc>> results = await _MatSuppMstViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMatSuppMstView.MatSuppMstViewGrpc.Clear();
                        _ListMatSuppMstView.MatSuppMstViewGrpc.AddRange(results.Value);
                    }

                    _MatSuppMstViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        void PopulateSampleData()
        {
            _ListMatSuppMstView = SampleCPDDataService.PopulatetMatSuppMstView();
        }
    }
}

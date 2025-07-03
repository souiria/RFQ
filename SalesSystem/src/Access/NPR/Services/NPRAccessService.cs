namespace NPR.Services
{
    public sealed class NPRAccessService : INPRAccessService
    {
        #region In Memory Datasets

        #region H1NPRView

        ListH1NPRViewGrpc _H1NPRView;

        #endregion
        #endregion

        #region Fields and Properties

        #region H1NPRView

        IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>? _H1NPRViewHandler;
        bool _H1NPRViewRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor

        public NPRAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region Currency

            _H1NPRView = new ListH1NPRViewGrpc();
            _H1NPRViewRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region H1NPRView
        public async Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_H1NPRView.H1NPRViewGrpc.Any())
            {
                return _H1NPRView;
            }
            else
            {
                await PopulateH1NPRViewAsync(cancellationToken);
                return _H1NPRView;
            }
        }
        #endregion
        #endregion

        #region Data Imports
        public async Task<bool> PopulateH1NPRViewAsync(CancellationToken cancellationToken)
        {
            if (!_H1NPRViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _H1NPRViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>>();
                    _H1NPRViewRefreshInProgress = true;
                    GetH1NPRViewQuery query = new GetH1NPRViewQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<H1NPRViewGrpc>> results = await _H1NPRViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _H1NPRView.H1NPRViewGrpc.Clear();
                        _H1NPRView.H1NPRViewGrpc.AddRange(results.Value);
                    }

                    _H1NPRViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        void PopulateSampleData()
        {
            _H1NPRView = SampleNPRDataService.PopulateH1NPRViewGrpc();
        }
    }
}

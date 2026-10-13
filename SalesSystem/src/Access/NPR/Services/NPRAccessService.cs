namespace NPR.Services
{
    public sealed class NPRAccessService : INPRAccessService
    {
        #region In Memory Datasets
        #region H1NPRView

        ListH1NPRViewGrpc _H1NPRView;

        #endregion
        #region RFQStatus

        ListRFQStatusGrpc _RFQStatus;

        #endregion
        #region NprApiData

        List<NprApiReturnData> _NprApiData;

        #endregion
        #endregion

        #region Fields and Properties

        #region H1NPRView

        IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>? _H1NPRViewHandler;
        bool _H1NPRViewRefreshInProgress;

        #endregion
        #region RFQStatus

        IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>? _RFQStatusHandler;
        bool _RFQStatusRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        readonly IHttpClientFactory _HttpClientFactory;
        readonly IConfiguration _Configuration;

        #endregion

        #region Constructor

        public NPRAccessService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory, IConfiguration configuration, bool testing = false)
        {
            #region H1NPRView

            _H1NPRView = new ListH1NPRViewGrpc();
            _H1NPRViewRefreshInProgress = false;

            #endregion

            #region RFQStatus

            _RFQStatus = new ListRFQStatusGrpc();
            _RFQStatusRefreshInProgress = false;

            #endregion

            #region NprApiData

            _NprApiData = new List<NprApiReturnData>();

            #endregion

            _ServiceProvider = serviceProvider;
            _HttpClientFactory = httpClientFactory;
            _Configuration = configuration;

            if (testing)
            {
                PopulateSampleData();
            }
         }
        #endregion

        #region Handlers

        #region H1NPRView
        public async Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(0, cancellationToken);
            if (_H1NPRView.H1NPRViewGrpc.Any())
            {
                if(takeAmount <= 0)
                {
                    return _H1NPRView;
                }

                ListH1NPRViewGrpc returnList = new ListH1NPRViewGrpc();
                IQueryable<H1NPRViewGrpc> query = _H1NPRView.H1NPRViewGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.H1NPRViewGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateH1NPRViewAsync(cancellationToken);
                return _H1NPRView;
            }
        }
        #endregion

        #region RFQStatus
        public async Task<ListRFQStatusGrpc> GetAllRFQStatus(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(0, cancellationToken);
            if (_RFQStatus.RFQStatusGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _RFQStatus;
                }

                ListRFQStatusGrpc returnList = new ListRFQStatusGrpc();
                IQueryable<RFQStatusGrpc> query = _RFQStatus.RFQStatusGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.RFQStatusGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateRFQStatusAsync(cancellationToken);
                return _RFQStatus;
            }
        }
        #endregion

        #region NprApiData
        public async Task<CreateNprApiGrpcResponse> CreateNpr(CreateNprApiGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            CreateNprApiGrpcResponse response = new CreateNprApiGrpcResponse();

            if (request.NprApiData == null || !request.NprApiData.Any())
            {
                return response;
            }

            List<NprApiRequestData> requestDataList = new List<NprApiRequestData>();
            int count = 1;
            foreach (NprApiDataGrpc data in request.NprApiData)
            {
                NprApiRequestData apiData = data.ToNprApiData();
                apiData.NPRUploadSeqNo = count;
                requestDataList.Add(apiData);
                count++;
            }

            HttpClient httpClient = _HttpClientFactory.CreateClient("MyClient");
            string? uri = _Configuration["NprApi:Url"];
            HttpResponseMessage httpResponse;
            //httpResponse = await httpClient.PostAsJsonAsync(uri, requestDataList, cancellationToken);
            try
            {
                httpResponse = await httpClient.PostAsJsonAsync(uri, requestDataList, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                // The caller (gRPC client) canceled the request or its deadline expired.
                response.Message = "Request to NprApi was canceled by the caller or exceeded the deadline.";
                response.HttpStatusCode = HttpStatusCode.RequestTimeout.ToString();
                return response;
            }
            catch (OperationCanceledException ex)
            {
                // Cancellation not requested by our token: underlying connection was aborted unexpectedly.
                response.Message = $"Request to NprApi failed unexpectedly: {ex.Message}";
                response.HttpStatusCode = HttpStatusCode.ServiceUnavailable.ToString();
                return response;
                }

                response.HttpStatusCode = httpResponse.StatusCode.ToString();

            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                await PopulateH1NPRViewAsync(cancellationToken);
                return await HandleSuccess(httpResponse, request, response, cancellationToken);

                case HttpStatusCode.UnprocessableContent:
                return await HandleAuthFailure(httpResponse, response, cancellationToken); ;

                case HttpStatusCode.InternalServerError:
                return await HandleServerError(httpResponse, response, cancellationToken);

                case HttpStatusCode.BadRequest:
                return await HandleBadRequest(httpResponse, response, cancellationToken);

                default:
                return await HandleUnexpectedStatus(httpResponse, response, cancellationToken);
            }
        }

        async Task<CreateNprApiGrpcResponse> HandleSuccess(
            HttpResponseMessage httpResponse,
            CreateNprApiGrpcRequest request,
            CreateNprApiGrpcResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                string httpJsonString = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                //List<NprApiReturnData>? nprApiDatas = JsonConvert.DeserializeObject<List<NprApiReturnData>>(httpJsonString);
                NprApiResponseData? nprApiData = JsonConvert.DeserializeObject<NprApiResponseData>(httpJsonString);
                if (nprApiData != null && nprApiData.Data != null)
                {
                    foreach (NprApiReturnData data in nprApiData.Data)
                    {
                        NprApiDataGrpc grpc = data.ToNprApiDataGrpc();
                        NprApiDataGrpc requestData = request.NprApiData
                            .Where(x => x.CustomerPartNumber == data.CustomerPartNumber)
                            .First();
                        grpc.RfqNprRequestId = requestData.RfqNprRequestId;
                        response.NprApiData.Add(grpc);
                    }
                }
            }
            catch (JsonException e)
            {
                response.Message = $"Failed to deserialize success response: {e.Message}";
            }

            return response;
        }

        async Task<CreateNprApiGrpcResponse> HandleBadRequest(
            HttpResponseMessage httpResponse,
            CreateNprApiGrpcResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                string errorBody = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                NprApiResponseData? nprApiData = JsonConvert.DeserializeObject<NprApiResponseData>(errorBody);
                if (nprApiData != null && nprApiData.Data != null)
                {
                    NprApiReturnData data = nprApiData.Data.First();
                    response.Message = $"Validation error: {data.Error}";
                }

                response.Message = $"Validation error: {errorBody}";
            }
            catch (InvalidOperationException e)
            {
                // Thrown when the response content has already been read or disposed
                response.Message = $"Bad request — response content unavailable: {e.Message}";
            }
            catch (OperationCanceledException e)
            {
                response.Message = $"Bad request — reading error body was cancelled: {e.Message}";
            }

            return response;
        }

        async Task<CreateNprApiGrpcResponse> HandleAuthFailure(
            HttpResponseMessage httpResponse,
            CreateNprApiGrpcResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                string httpJsonString = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                NprApiResponseData? nprApiData = JsonConvert.DeserializeObject<NprApiResponseData>(httpJsonString);
                if (nprApiData != null && nprApiData.Data != null)
                {
                    //List<NprApiReturnData>? returnDatas =  JsonConvert.DeserializeObject<List<NprApiReturnData>>(nprApiData.Data);
                    NprApiReturnData data = nprApiData.Data.First();
                    response.Message = $"UnprocessableContent: Error Message: {data.Error}";
                }
            }catch (JsonException e)
            {
                response.Message = $"Failed to deserialize auth failure response: {e.Message}";
            }

            return response;
        }

        async Task<CreateNprApiGrpcResponse> HandleServerError(
            HttpResponseMessage httpResponse,
            CreateNprApiGrpcResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                string errorBody = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                response.Message = $"Server error (500): {errorBody}";
            }
            catch (InvalidOperationException e)
            {
                // Thrown when the response content has already been read or disposed
                response.Message = $"Server error (500) — response content unavailable: {e.Message}";
            }
            catch (OperationCanceledException e)
            {
                response.Message = $"Server error (500) — reading error body was cancelled: {e.Message}";
            }

            return response;
        }

        async Task<CreateNprApiGrpcResponse> HandleUnexpectedStatus(
            HttpResponseMessage httpResponse,
            CreateNprApiGrpcResponse response,
            CancellationToken cancellationToken)
        {
            try
            {
                string errorBody = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                NprApiResponseData? nprApiData = JsonConvert.DeserializeObject<NprApiResponseData>(errorBody);
                if (nprApiData != null && nprApiData.Data != null)
                {
                    NprApiReturnData data = nprApiData.Data.First();
                    response.Message = $"Unexpected status ({httpResponse.StatusCode}): {data.Error}";
                }
            }
            catch (InvalidOperationException e)
            {
                // Thrown when the response content has already been read or disposed
                response.Message = $"Unexpected status ({httpResponse.StatusCode}) — response content unavailable: {e.Message}";
            }
            catch (OperationCanceledException e)
            {
                response.Message = $"Unexpected status ({httpResponse.StatusCode}) — reading error body was cancelled: {e.Message}";
            }

            return response;
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
                    await Task.Delay(0, cancellationToken);
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
        public async Task<bool> PopulateRFQStatusAsync(CancellationToken cancellationToken)
        {
            if (!_RFQStatusRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RFQStatusHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>>();
                    _RFQStatusRefreshInProgress = true;
                    GetRFQStatusQuery query = new GetRFQStatusQuery();
                    await Task.Delay(0, cancellationToken);
                    Result<List<RFQStatusGrpc>> results = await _RFQStatusHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _RFQStatus.RFQStatusGrpc.Clear();
                        _RFQStatus.RFQStatusGrpc.AddRange(results.Value);
                    }

                    _RFQStatusRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        public async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig, Action<IEnumerable<T>> setResponseCollection,
        CancellationToken cancellationToken)
        {
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = new List<T>();
            filteredList = await Filter(compiledExpression, cancellationToken);
            setResponseCollection(filteredList);
        }

        public async Task<IEnumerable<T>> Filter<T>(Func<T, bool> func, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return typeof(T).Name.ToUpperInvariant() switch
                {
                    "H1NPRVIEWGRPC" => _H1NPRView.H1NPRViewGrpc.Cast<T>().Where(func).ToList(),
                    "RFQSTATUS" => _RFQStatus.RFQStatusGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }
        void PopulateSampleData()
        {
            _H1NPRView = SampleNPRDataService.PopulateH1NPRViewGrpc();
            _RFQStatus = SampleNPRDataService.PopulateRFQStatusGrpc();
        }
    }
}

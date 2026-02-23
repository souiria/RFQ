namespace NPR.Services
{
    public sealed class NPRAccessService : INPRAccessService, IDisposable
    {
         string _NprRequestSetsFilePath;
         JsonSerializerOptions _NprJsonOptions;
         SemaphoreSlim _NprSetsGate;
         List<RfqNprRequestSetModel> _NprSetsCache;
        #region In Memory Datasets
        #region H1NPRView

        ListH1NPRViewGrpc _H1NPRView;

        #endregion
        #region RFQStatus

        ListRFQStatusGrpc _RFQStatus;

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

        #endregion

        #region Constructor

        public NPRAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region H1NPRView

            _H1NPRView = new ListH1NPRViewGrpc();
            _H1NPRViewRefreshInProgress = false;

            #endregion

            #region RFQStatus

            _RFQStatus = new ListRFQStatusGrpc();
            _RFQStatusRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }

            _NprRequestSetsFilePath = @"C:\temp\npr_request_sets.json";

            _NprJsonOptions = new JsonSerializerOptions();
            _NprJsonOptions.PropertyNamingPolicy = null;                   
             _NprJsonOptions.WriteIndented = false;
            _NprSetsGate = new SemaphoreSlim(1, 1);
            _NprSetsCache = new List<RfqNprRequestSetModel>();
         }
        #endregion

        #region Handlers

        #region H1NPRView
        public async Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
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
            await Task.Delay(1, cancellationToken);
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
        public async Task<bool> PopulateRFQStatusAsync(CancellationToken cancellationToken)
        {
            if (!_RFQStatusRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RFQStatusHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>>();
                    _RFQStatusRefreshInProgress = true;
                    GetRFQStatusQuery query = new GetRFQStatusQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RFQStatusGrpc>> results = await _RFQStatusHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _RFQStatus.RFQStatusGrpc.Clear();
                        _RFQStatus.RFQStatusGrpc.AddRange(results.Value);
                    }

                    _H1NPRViewRefreshInProgress = false;
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
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }
        #region NPR Request Sets (JSON persistence - service)
        public async Task<List<RfqNprRequestSetModel>> LoadNprRequestSetsFromBackendAsync(CancellationToken cancellationToken)
        {
            await _NprSetsGate.WaitAsync(cancellationToken);
            try
            {
                if (!File.Exists(_NprRequestSetsFilePath))
                {
                   _NprSetsCache.Clear();
                    return [.. _NprSetsCache];
                }

                string json = await File.ReadAllTextAsync(_NprRequestSetsFilePath, cancellationToken);
                if (string.IsNullOrWhiteSpace(json))
                {
                    _NprSetsCache.Clear();
                    return [.. _NprSetsCache];
                }

                List<RfqNprRequestSetModel>? sets =
                    JsonSerializer.Deserialize<List<RfqNprRequestSetModel>>(json, _NprJsonOptions);

                _NprSetsCache.Clear();
                if (sets is not null)
                {
                    _NprSetsCache.AddRange(sets);
                }

                // After load => align to LocalUnchanged
                foreach (RfqNprRequestSetModel s in _NprSetsCache)
                {
                    s.Status = NprSetRequestStatus.LocalUnchanged;
                }

                return [.. _NprSetsCache];
            }
            catch (Exception)
            {
               
                throw;
            }
            finally
            {
                _NprSetsGate.Release();
            }
        }

        public async Task SaveNprRequestSetsToBackendAsync(ReadOnlyCollection<RfqNprRequestSetModel> sets, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(sets);

            await _NprSetsGate.WaitAsync(cancellationToken);
            try
            {
                string? directory = Path.GetDirectoryName(_NprRequestSetsFilePath);
                bool needDirectory = !string.IsNullOrEmpty(directory) && !Directory.Exists(directory!);
                if (needDirectory)
                {
                    Directory.CreateDirectory(directory!);
                 
                }

         
                List<RfqNprRequestSetModel> working = new List<RfqNprRequestSetModel>(sets);

             
                foreach (RfqNprRequestSetModel set in working)
                {
                    set.Status = NprSetRequestStatus.LocalUpdated;
                }

                string json = JsonSerializer.Serialize(working, _NprJsonOptions);
                await File.WriteAllTextAsync(_NprRequestSetsFilePath, json, cancellationToken);

                _NprSetsCache.Clear();
                _NprSetsCache.AddRange(working);
                   
            }
            catch
            {
        
                throw;
            }
            finally
            {
                _NprSetsGate.Release();
            }
        }
        public async Task<List<RfqNprRequestModel>> LoadDuplicatedNprRequestsAsync(    CancellationToken cancellationToken,    bool includeEmptyKeys = false,    bool removeFormatting = true)
        {
            // Load all sets 
            List<RfqNprRequestSetModel> sets =
                await LoadNprRequestSetsFromBackendAsync(cancellationToken);

            // Normalize helper
            static string Normalize(string? value, bool removeFmt)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                string v;
                v = value.Trim().ToUpperInvariant();

                if (removeFmt)
                {
                    string noSpaces;
                    noSpaces = v.Replace(" ", "", StringComparison.Ordinal);

                    string noDashes;
                    noDashes = noSpaces.Replace("-", "", StringComparison.Ordinal);

                    return noDashes;
                }

                return v;
            }

            // Flatten NPR requests with grouping keys
            var rows =
                sets.SelectMany(set =>
                    set.NprRequests.Select(req => new
                    {
                        Request = req,
                        KeyCPN = Normalize(req.CustomerPartNumber, removeFormatting),
                        KeySNO = Normalize(req.SumitomoNumber, removeFormatting)
                    }))
                .Where(x => includeEmptyKeys ||
                    (!string.IsNullOrEmpty(x.KeyCPN) && !string.IsNullOrEmpty(x.KeySNO)))
                .ToList();

            // Find duplicate groups
            List<RfqNprRequestModel> duplicates =
                rows.GroupBy(x => new { x.KeyCPN, x.KeySNO })
                   .Where(g =>
                   {
                       int count;
                       count = g.Count();
                       bool isDuplicate;
                       isDuplicate = 1 < count;
                       return isDuplicate;
                   })

                    .SelectMany(g => g.Select(x => x.Request))
                    .ToList();

            return duplicates;
        }
        public async Task<List<RfqNprRequestSetModel>> LoadNprSetsWithoutDuplicatesAndSaveRemovedAsync(CancellationToken cancellationToken, bool includeEmptyKeys = false, bool removeFormatting = true, string? duplicatesOutputPath = null)
        {
            // 1) Load current sets
            List<RfqNprRequestSetModel> sets =
                await LoadNprRequestSetsFromBackendAsync(cancellationToken);

            // 2) Build key tracker across the WHOLE file (intra-set + cross-set)
            HashSet<string> seen = new HashSet<string>(StringComparer.Ordinal);

            // 3) collect removed items to a list for JSON export
            List<RemovedNprDuplicate> removed = new List<RemovedNprDuplicate>();

            // 4) Deduplicate set-by-set, preserving order of first occurrence
            foreach (RfqNprRequestSetModel set in sets)
            {
                List<RfqNprRequestModel> original = set.NprRequests;
                List<RfqNprRequestModel> cleaned = new List<RfqNprRequestModel>(original.Count);

                foreach (RfqNprRequestModel req in original)
                {
                    string cpn = NormalizePart(req.CustomerPartNumber, removeFormatting);
                    string sno = NormalizePart(req.SumitomoNumber, removeFormatting);

                  bool isKeyValid = !string.IsNullOrEmpty(cpn) && !string.IsNullOrEmpty(sno);
                    if (!includeEmptyKeys && !isKeyValid)
                    {
                        // keep items with incomplete keys as-is
                        cleaned.Add(req);
                        continue;
                    }

                    // Build the pair key and check duplicates
                    string key = $"{cpn}|{sno}";
                    if (seen.Add(key))
                    {
                        // first occurrence → keep
                        cleaned.Add(req);
                    }
                    else
                    {
                        RemovedNprDuplicate duplicate;
                        duplicate = new RemovedNprDuplicate(
                            set.Id,
                            set.RfqNumber,
                            req.CustomerPartNumber ?? string.Empty,
                            req.SumitomoNumber ?? string.Empty,
                            req
                        );

                        removed.Add(duplicate);

                    }
                }

                // Replace with cleaned list
                set.NprRequests = cleaned;
                set.Updated = DateTime.UtcNow;
                set.Status = NprSetRequestStatus.LocalUpdated; // mark as "needs save"
            }

            // 5) Persist the removed duplicates to a separate JSON file
            try
            {
                string mainDir = Path.GetDirectoryName(_NprRequestSetsFilePath) ?? @"C:\temp";
                string duplicatesDir = mainDir;

                if (!Directory.Exists(duplicatesDir))
                {
                    Directory.CreateDirectory(duplicatesDir);
                }

                string outPath = duplicatesOutputPath ??
                                 Path.Combine(duplicatesDir, $"npr_request_sets_duplicates_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json");

                // Write a small envelope with metadata + raw removed items
                var envelope = new
                {
                    generatedUtc = DateTime.UtcNow,
                    rule = "CustomerPartNumber+SumitomoNumber",
                    includeEmptyKeys,
                    removeFormatting,
                    count = removed.Count,
                    items = removed
                };

                string dupJson = JsonSerializer.Serialize(envelope, _NprJsonOptions);
                await File.WriteAllTextAsync(outPath, dupJson, cancellationToken);
            }
            catch (IOException)
            {
              
            }
            catch (UnauthorizedAccessException)
            {
              
            }
            // 6) Return the de-duplicated sets so the caller can SaveAllNprRequestSets(...)
            return sets;
        }
        #endregion
        void PopulateSampleData()
        {
            _H1NPRView = SampleNPRDataService.PopulateH1NPRViewGrpc();
            _RFQStatus = SampleNPRDataService.PopulateRFQStatusGrpc();
        }
        #region IDisposable

        public void Dispose()
        {
            SemaphoreSlim? gate = _NprSetsGate;
            if (gate is not null)
            {
                gate.Dispose();
            }
        }

        #endregion

        static string NormalizePart(string? value, bool removeFormatting)
        {
            bool isNullOrWhite;
            isNullOrWhite = string.IsNullOrWhiteSpace(value);

            if (isNullOrWhite)
            {
                return string.Empty;
            }

            string trimmed;
            trimmed = value!.Trim();

            string upper;
            upper = trimmed.ToUpperInvariant();

            if (removeFormatting)
            {
                string noSpaces;
                noSpaces = upper.Replace(" ", string.Empty, StringComparison.Ordinal);

                string noDashes;
                noDashes = noSpaces.Replace("-", string.Empty, StringComparison.Ordinal);

                return noDashes;
            }

            return upper;
        }
    }
}

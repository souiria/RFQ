using EDI.CQRS.Command;
using EDI.Data.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EDI.Services
{
    public class EdiAccessService : IEdiAccessService
    {
        #region In Memory Datasets

        ListEdiCustomerParameterGrpc _ListEdiCustomerParameters;
        ListEdiFileDataUploadDuplicatesGrpc _ListEdiFileDataUploadDuplicates;
        ListEdiFileDataUploadGrpc _ListEdiFileDataUpload;
        ListEdiGlobalParametersGrpc _ListEdiGlobalParameters;
        ListEdiInvoiceInformationDuplicatesGrpc _ListEdiInvoiceInformationDuplicates;
        ListEdiInvoiceInformationGrpc _ListEdiInvoiceInformation;
        ListEdiInvoiceUnit4Grpc _ListEdiInvoiceUnit4;
        ListEdiZeroPriceExceptionsGrpc _ListEdiZeroPriceExceptions;

        #endregion

        #region Fields and Properties

        #region EdiCustomerParameters

        IQueryHandler<GetCustomerParameterQuery, List<EdiCustomerParameterGrpc>>? _EdiCustomerParameterHandler;
        bool _EdiCustomerParameterRefreshInProgress;
        ICommandHandler<AddEdiCustomerParameterCommand, bool>? _EdiCustomerParameterCommandHandler;

        #endregion

        #region EdiFileUpload

        IQueryHandler<GetEdiFileDataUploadDuplicatesQuery, List<EdiFileDataUploadDuplicatesGrpc>>? _EdiFileDataUploadDuplicatesHandler;
        bool _EdiFileDataUploadDuplicatesRefreshInProgress;
        IQueryHandler<GetEdiFileDataUploadQuery, List<EdiFileDataUploadGrpc>>? _EdiFileDataUploadHandler;
        bool _EdiFileDataUploadRefreshInProgress;
        ICommandHandler<AddEdiFileDuplicateDataCommand, bool>? _EdiFileDuplicateDataCommandHandler;
        ICommandHandler<AddEdiFileDataCommand, bool>? _EdiFileDataCommandHandler;

        #endregion

        #region GlobalParameters

        IQueryHandler<GetEdiGlobalParameterQuery, List<EdiGlobalParametersGrpc>>? _EdiGlobalParameterHandler;
        bool _EdiGlobalParametersRefreshInProgress;
        ICommandHandler<AddEdiGlobalParameterCommand, bool>? _EdiGlobalParameterCommandHandler;

        #endregion

        #region EdiInvoiceInformation

        IQueryHandler<GetEdiInvoiceInformationDuplicatesQuery, List<EdiInvoiceInformationDuplicateGrpc>>? _EdiInvoiceInformationDuplicatesHandler;
        bool _EdiInvoiceInformationDuplicatesRefreshInProgress;
        IQueryHandler<GetEdiInvoiceInformationQuery, List<EdiInvoiceInformationGrpc>>? _EdiInvoiceInformationHandler;
        bool _EdiInvoiceInformationRefreshInProgress;
        ICommandHandler<AddEdiInvoiceInformationCommand, bool>? _EdiInvoiceInformationCommandHandler;
        ICommandHandler<AddEdiInvoiceInformationDuplicatesCommand, bool>? _EdiInvoiceInformationDuplicatesCommandHandler;

        #endregion

        #region EdiInvoiceUnit4

        IQueryHandler<GetEdiInvoiceUnit4Query, List<EdiInvoiceUnit4Grpc>>? _EdiInvoiceUnit4Handler;
        bool _EdiInvoiceUnit4RefreshInProgress;
        IQueryHandler<GetZeroPriceExceptionsQuery, List<EdiZeroPriceExceptionsGrpc>>? _ZeroPriceExceptionsHandler;
        bool _ZeroPriceExceptionsRefreshInProgress;
        ICommandHandler<AddEdiInvoiceUnit4Command, bool>? _EdiInvoiceUnit4CommandHandler;
        ICommandHandler<AddZeroPriceExceptionsCommand, bool>? _ZeroPriceExceptionsCommandHandler;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public EdiAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region EdiCustomerParameters

            _ListEdiCustomerParameters = new ListEdiCustomerParameterGrpc();
            _EdiCustomerParameterRefreshInProgress = false;

            #endregion

            #region EdiFileUpload

            _ListEdiFileDataUploadDuplicates = new ListEdiFileDataUploadDuplicatesGrpc();
            _ListEdiFileDataUpload = new ListEdiFileDataUploadGrpc();
            _EdiFileDataUploadDuplicatesRefreshInProgress = false;
            _EdiFileDataUploadRefreshInProgress = false;

            #endregion

            #region GlobalParameters

            _ListEdiGlobalParameters = new ListEdiGlobalParametersGrpc();
            _EdiGlobalParametersRefreshInProgress = false;

            #endregion

            #region EdiInvoiceInformation

            _ListEdiInvoiceInformationDuplicates = new ListEdiInvoiceInformationDuplicatesGrpc();
            _ListEdiInvoiceInformation = new ListEdiInvoiceInformationGrpc();
            _EdiInvoiceInformationDuplicatesRefreshInProgress = false;
            _EdiInvoiceInformationRefreshInProgress = false;

            #endregion

            #region EdiInvoiceUnit4

            _ListEdiInvoiceUnit4 = new ListEdiInvoiceUnit4Grpc();
            _ListEdiZeroPriceExceptions = new ListEdiZeroPriceExceptionsGrpc();
            _EdiInvoiceUnit4RefreshInProgress = false;
            _ZeroPriceExceptionsRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Query Handlers

        #region EdiCustomerParameters
        public async Task<ListEdiCustomerParameterGrpc> GetEdiCustomerParametersGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiCustomerParameters.EdiCustomerParameterGrpc.Any())
            {
                return _ListEdiCustomerParameters;
            }
            else
            {
                await PopulateEdiCustomerParametersAsync(cancellationToken);
                return _ListEdiCustomerParameters;
            }
        }

        #endregion

        #region EdiFileUpload

        public async Task<ListEdiFileDataUploadDuplicatesGrpc> GetEdiFileDataUploadDuplicatesGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiFileDataUploadDuplicates.EdiFileDataUploadDuplicatesGrpc.Any())
            {
                return _ListEdiFileDataUploadDuplicates;
            }
            else
            {
                await PopulateEdiFileDataUploadDuplicatesGrpcAsync(cancellationToken);
                return _ListEdiFileDataUploadDuplicates;
            }
        }

        public async Task<ListEdiFileDataUploadGrpc> GetEdiFileDataUploadGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiFileDataUpload.EdiFileDataUploadGrpc.Any())
            {
                return _ListEdiFileDataUpload;
            }
            else
            {
                await PopulateEdiFileDataUploadGrpcAsync(cancellationToken);
                return _ListEdiFileDataUpload;
            }
        }

        #endregion

        #region GlobalParameters

        public async Task<ListEdiGlobalParametersGrpc> GetEdiGlobalParametersGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiGlobalParameters.EdiGlobalParametersGrpc.Any())
            {
                return _ListEdiGlobalParameters;
            }
            else
            {
                await PopulateEdiGlobalParametersGrpcAsync(cancellationToken);
                return _ListEdiGlobalParameters;
            }
        }

        #endregion

        #region EdiInvoiceInformation

        public async Task<ListEdiInvoiceInformationGrpc> GetEdiInvoiceInformationGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiInvoiceInformation.EdiInvoiceInformationGrpc.Any())
            {
                return _ListEdiInvoiceInformation;
            }
            else
            {
                await PopulateEdiInvoiceInformationGrpcAsync(cancellationToken);
                return _ListEdiInvoiceInformation;
            }
        }

        public async Task<ListEdiInvoiceInformationDuplicatesGrpc> GetEdiInvoiceInformationDuplicatesGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiInvoiceInformationDuplicates.EdiInvoiceInformationDuplicateGrpc.Any())
            {
                return _ListEdiInvoiceInformationDuplicates;
            }
            else
            {
                await PopulateEdiInvoiceInformationDuplicatesGrpcAsync(cancellationToken);
                return _ListEdiInvoiceInformationDuplicates;
            }
        }

        #endregion

        #region EdiInvoiceUnit4

        public async Task<ListEdiInvoiceUnit4Grpc> GetEdiInvoiceUnit4GrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiInvoiceUnit4.EdiInvoiceUnit4Grpc.Any())
            {
                return _ListEdiInvoiceUnit4;
            }
            else
            {
                await PopulateEdiInvoiceUnit4GrpcAsync(cancellationToken);
                return _ListEdiInvoiceUnit4;
            }
        }

        public async Task<ListEdiZeroPriceExceptionsGrpc> GetEdiZeroPriceExceptionsGrpcAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEdiZeroPriceExceptions.EdiZeroPriceExceptionsGrpc.Any())
            {
                return _ListEdiZeroPriceExceptions;
            }
            else
            {
                await PopulateEdiZeroPriceExceptionsGrpcAsync(cancellationToken);
                return _ListEdiZeroPriceExceptions;
            }
        }

        #endregion

        #endregion

        #region Command Handlers

        public async Task<bool> SaveEdiCustomerParametersGrpcAsync(ListEdiCustomerParameterGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiCustomerParameterCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiCustomerParameterCommand, bool>>();
                List<DbEdiCustomerParameter> dbData = new List<DbEdiCustomerParameter>();
                foreach (EdiCustomerParameterGrpc? item in data.EdiCustomerParameterGrpc)
                {
                    DbEdiCustomerParameter parameter = item.MapToDbEdiCustomerParameter();
                    dbData.Add(parameter);
                }

                AddEdiCustomerParameterCommand command = new AddEdiCustomerParameterCommand(dbData);
                result = await _EdiCustomerParameterCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiFileDataUploadDuplicatesGrpcAsync(ListEdiFileDataUploadDuplicatesGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiFileDuplicateDataCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiFileDuplicateDataCommand, bool>>();
                List<DbEdiFileDataUploadDuplicate> dbData = new List<DbEdiFileDataUploadDuplicate>();
                foreach (EdiFileDataUploadDuplicatesGrpc? item in data.EdiFileDataUploadDuplicatesGrpc)
                {
                    DbEdiFileDataUploadDuplicate parameter = item.MapToDbEdiFileDataUploadDuplicates();
                    dbData.Add(parameter);
                }

                AddEdiFileDuplicateDataCommand command = new AddEdiFileDuplicateDataCommand(dbData);
                result = await _EdiFileDuplicateDataCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiFileDataUploadGrpcAsync(ListEdiFileDataUploadGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiFileDataCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiFileDataCommand, bool>>();
                List<DbEdiFileDataUpload> dbData = new List<DbEdiFileDataUpload>();
                foreach (EdiFileDataUploadGrpc? item in data.EdiFileDataUploadGrpc)
                {
                    DbEdiFileDataUpload parameter = item.MapToDbEdiFileDataUpload();
                    dbData.Add(parameter);
                }

                AddEdiFileDataCommand command = new AddEdiFileDataCommand(dbData);
                result = await _EdiFileDataCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiGlobalParametersGrpcAsync(ListEdiGlobalParametersGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiGlobalParameterCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiGlobalParameterCommand, bool>>();
                List<DbEdiGlobalParameter> dbData = new List<DbEdiGlobalParameter>();
                foreach (EdiGlobalParametersGrpc? item in data.EdiGlobalParametersGrpc)
                {
                    DbEdiGlobalParameter parameter = item.MapToDbEdiGlobalParameters();
                    dbData.Add(parameter);
                }

                AddEdiGlobalParameterCommand command = new AddEdiGlobalParameterCommand(dbData);
                result = await _EdiGlobalParameterCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiInvoiceInformationGrpcAsync(ListEdiInvoiceInformationGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiInvoiceInformationCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiInvoiceInformationCommand, bool>>();
                List<DbEdiInvoiceInformation> dbData = new List<DbEdiInvoiceInformation>();
                foreach (EdiInvoiceInformationGrpc? item in data.EdiInvoiceInformationGrpc)
                {
                    DbEdiInvoiceInformation parameter = item.MapToDbEdiInvoiceInformation();
                    dbData.Add(parameter);
                }

                AddEdiInvoiceInformationCommand command = new AddEdiInvoiceInformationCommand(dbData);
                result = await _EdiInvoiceInformationCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiInvoiceInformationDuplicatesGrpcAsync(ListEdiInvoiceInformationDuplicatesGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiInvoiceInformationDuplicatesCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiInvoiceInformationDuplicatesCommand, bool>>();
                List<DbEdiInvoiceInformationDuplicate> dbData = new List<DbEdiInvoiceInformationDuplicate>();
                foreach (EdiInvoiceInformationDuplicateGrpc? item in data.EdiInvoiceInformationDuplicateGrpc)
                {
                    DbEdiInvoiceInformationDuplicate parameter = item.MapToDbEdiInvoiceInformationDuplicate();
                    dbData.Add(parameter);
                }

                AddEdiInvoiceInformationDuplicatesCommand command = new AddEdiInvoiceInformationDuplicatesCommand(dbData);
                result = await _EdiInvoiceInformationDuplicatesCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiInvoiceUnit4GrpcAsync(ListEdiInvoiceUnit4Grpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _EdiInvoiceUnit4CommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddEdiInvoiceUnit4Command, bool>>();
                List<DbEdiInvoiceUnit4> dbData = new List<DbEdiInvoiceUnit4>();
                foreach (EdiInvoiceUnit4Grpc? item in data.EdiInvoiceUnit4Grpc)
                {
                    DbEdiInvoiceUnit4 parameter = item.MapToDbEdiInvoiceUnit4();
                    dbData.Add(parameter);
                }

                AddEdiInvoiceUnit4Command command = new AddEdiInvoiceUnit4Command(dbData);
                result = await _EdiInvoiceUnit4CommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        public async Task<bool> SaveEdiZeroPriceExceptionsGrpcAsync(ListEdiZeroPriceExceptionsGrpc data, CancellationToken cancellationToken)
        {
            Result<bool> result;
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _ZeroPriceExceptionsCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddZeroPriceExceptionsCommand, bool>>();
                List<DbZeroPriceExceptions> dbData = new List<DbZeroPriceExceptions>();
                foreach (EdiZeroPriceExceptionsGrpc? item in data.EdiZeroPriceExceptionsGrpc)
                {
                    DbZeroPriceExceptions parameter = item.MapToDbEdiZeroPriceExceptions();
                    dbData.Add(parameter);
                }

                AddZeroPriceExceptionsCommand command = new AddZeroPriceExceptionsCommand(dbData);
                result = await _ZeroPriceExceptionsCommandHandler.Handle(command, cancellationToken);
            }

            return result.Value;
        }

        #endregion

        #region Data Imports

        #region EdiCustomerParameters
        public async Task<bool> PopulateEdiCustomerParametersAsync(CancellationToken cancellationToken)
        {
            if (!_EdiCustomerParameterRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiCustomerParameterHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerParameterQuery, List<EdiCustomerParameterGrpc>>>();
                    _EdiCustomerParameterRefreshInProgress = true;
                    GetCustomerParameterQuery query = new GetCustomerParameterQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiCustomerParameterGrpc>> results = await _EdiCustomerParameterHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiCustomerParameters.EdiCustomerParameterGrpc.Clear();
                        _ListEdiCustomerParameters.EdiCustomerParameterGrpc.AddRange(results.Value);
                    }

                    _EdiCustomerParameterRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region EdiFileUpload

        public async Task<bool> PopulateEdiFileDataUploadDuplicatesGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiFileDataUploadDuplicatesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiFileDataUploadDuplicatesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiFileDataUploadDuplicatesQuery, List<EdiFileDataUploadDuplicatesGrpc>>>();
                    _EdiFileDataUploadDuplicatesRefreshInProgress = true;
                    GetEdiFileDataUploadDuplicatesQuery query = new GetEdiFileDataUploadDuplicatesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiFileDataUploadDuplicatesGrpc>> results = await _EdiFileDataUploadDuplicatesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiFileDataUploadDuplicates.EdiFileDataUploadDuplicatesGrpc.Clear();
                        _ListEdiFileDataUploadDuplicates.EdiFileDataUploadDuplicatesGrpc.AddRange(results.Value);
                    }

                    _EdiFileDataUploadDuplicatesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateEdiFileDataUploadGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiFileDataUploadRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiFileDataUploadHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiFileDataUploadQuery, List<EdiFileDataUploadGrpc>>>();
                    _EdiFileDataUploadRefreshInProgress = true;
                    GetEdiFileDataUploadQuery query = new GetEdiFileDataUploadQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiFileDataUploadGrpc>> results = await _EdiFileDataUploadHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiFileDataUpload.EdiFileDataUploadGrpc.Clear();
                        _ListEdiFileDataUpload.EdiFileDataUploadGrpc.AddRange(results.Value);
                    }

                    _EdiFileDataUploadRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region GlobalParameters

        public async Task<bool> PopulateEdiGlobalParametersGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiGlobalParametersRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiGlobalParameterHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiGlobalParameterQuery, List<EdiGlobalParametersGrpc>>>();
                    _EdiGlobalParametersRefreshInProgress = true;
                    GetEdiGlobalParameterQuery query = new GetEdiGlobalParameterQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiGlobalParametersGrpc>> results = await _EdiGlobalParameterHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiGlobalParameters.EdiGlobalParametersGrpc.Clear();
                        _ListEdiGlobalParameters.EdiGlobalParametersGrpc.AddRange(results.Value);
                    }

                    _EdiGlobalParametersRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region EdiInvoiceInformation

        public async Task<bool> PopulateEdiInvoiceInformationGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiInvoiceInformationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiInvoiceInformationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiInvoiceInformationQuery, List<EdiInvoiceInformationGrpc>>>();
                    _EdiInvoiceInformationRefreshInProgress = true;
                    GetEdiInvoiceInformationQuery query = new GetEdiInvoiceInformationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiInvoiceInformationGrpc>> results = await _EdiInvoiceInformationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiInvoiceInformation.EdiInvoiceInformationGrpc.Clear();
                        _ListEdiInvoiceInformation.EdiInvoiceInformationGrpc.AddRange(results.Value);
                    }

                    _EdiInvoiceInformationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateEdiInvoiceInformationDuplicatesGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiInvoiceInformationDuplicatesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiInvoiceInformationDuplicatesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiInvoiceInformationDuplicatesQuery, List<EdiInvoiceInformationDuplicateGrpc>>>();
                    _EdiInvoiceInformationDuplicatesRefreshInProgress = true;
                    GetEdiInvoiceInformationDuplicatesQuery query = new GetEdiInvoiceInformationDuplicatesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiInvoiceInformationDuplicateGrpc>> results = await _EdiInvoiceInformationDuplicatesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiInvoiceInformationDuplicates.EdiInvoiceInformationDuplicateGrpc.Clear();
                        _ListEdiInvoiceInformationDuplicates.EdiInvoiceInformationDuplicateGrpc.AddRange(results.Value);
                    }

                    _EdiInvoiceInformationDuplicatesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region EdiInvoiceUnit4

        public async Task<bool> PopulateEdiInvoiceUnit4GrpcAsync(CancellationToken cancellationToken)
        {
            if (!_EdiInvoiceUnit4RefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EdiInvoiceUnit4Handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEdiInvoiceUnit4Query, List<EdiInvoiceUnit4Grpc>>>();
                    _EdiInvoiceUnit4RefreshInProgress = true;
                    GetEdiInvoiceUnit4Query query = new GetEdiInvoiceUnit4Query();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiInvoiceUnit4Grpc>> results = await _EdiInvoiceUnit4Handler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiInvoiceUnit4.EdiInvoiceUnit4Grpc.Clear();
                        _ListEdiInvoiceUnit4.EdiInvoiceUnit4Grpc.AddRange(results.Value);
                    }

                    _EdiInvoiceUnit4RefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateEdiZeroPriceExceptionsGrpcAsync(CancellationToken cancellationToken)
        {
            if (!_ZeroPriceExceptionsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _ZeroPriceExceptionsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetZeroPriceExceptionsQuery, List<EdiZeroPriceExceptionsGrpc>>>();
                    _ZeroPriceExceptionsRefreshInProgress = true;
                    GetZeroPriceExceptionsQuery query = new GetZeroPriceExceptionsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EdiZeroPriceExceptionsGrpc>> results = await _ZeroPriceExceptionsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEdiZeroPriceExceptions.EdiZeroPriceExceptionsGrpc.Clear();
                        _ListEdiZeroPriceExceptions.EdiZeroPriceExceptionsGrpc.AddRange(results.Value);
                    }

                    _ZeroPriceExceptionsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion

        void PopulateSampleData()
        {
            _ListEdiCustomerParameters = SampleEdiDataService.PopulateEdiCustomerParameters();
        }
    }
}

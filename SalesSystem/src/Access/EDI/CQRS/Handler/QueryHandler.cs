namespace EDI.CQRS.Handler
{
    sealed class QueryHandler : IQueryHandler<GetCustomerParameterQuery, List<EdiCustomerParameterGrpc>>,
        IQueryHandler<GetEdiFileDataUploadDuplicatesQuery, List<EdiFileDataUploadDuplicatesGrpc>>,
        IQueryHandler<GetEdiFileDataUploadQuery, List<EdiFileDataUploadGrpc>>,
        IQueryHandler<GetEdiGlobalParameterQuery, List<EdiGlobalParametersGrpc>>,
        IQueryHandler<GetEdiInvoiceInformationDuplicatesQuery, List<EdiInvoiceInformationDuplicateGrpc>>,
        IQueryHandler<GetEdiInvoiceInformationQuery, List<EdiInvoiceInformationGrpc>>,
        IQueryHandler<GetEdiInvoiceUnit4Query, List<EdiInvoiceUnit4Grpc>>,
        IQueryHandler<GetZeroPriceExceptionsQuery, List<EdiZeroPriceExceptionsGrpc>>
    {
        readonly IEdiReadRepository<DbEdiCustomerParameter> _CustomerParameterRepository;
        readonly IEdiReadRepository<DbEdiFileDataUploadDuplicate> _EdiFileDataUploadDuplicateRepository;
        readonly IEdiReadRepository<DbEdiFileDataUpload> _EdiFileDataUploadRepository;
        readonly IEdiReadRepository<DbEdiGlobalParameter> _EdiGlobalParameterRepository;
        readonly IEdiReadRepository<DbEdiInvoiceInformationDuplicate> _EdiInvoiceInformationDuplicateRepository;
        readonly IEdiReadRepository<DbEdiInvoiceInformation> _EdiInvoiceInformationRepository;
        readonly IEdiReadRepository<DbEdiInvoiceUnit4> _EdiInvoiceUnit4Repository;
        readonly IEdiReadRepository<DbZeroPriceExceptions> _EdiZeroPriceExceptionsRepository;

        List<EdiCustomerParameterGrpc> _CustomerParameters;
        List<EdiFileDataUploadDuplicatesGrpc> _EdiFileDataUploadDuplicate;
        List<EdiFileDataUploadGrpc> _EdiFileDataUpload;
        List<EdiGlobalParametersGrpc> _EdiGlobalParameters;
        List<EdiInvoiceInformationDuplicateGrpc> _EdiInvoiceInformationDuplicates;
        List<EdiInvoiceInformationGrpc> _EdiInvoiceInformation;
        List<EdiInvoiceUnit4Grpc> _EdiInvoiceUnit4;
        List<EdiZeroPriceExceptionsGrpc> _EdiZeroPriceExceptions;

        public QueryHandler(IEdiReadRepository<DbEdiCustomerParameter> customerParameterRepository,
            IEdiReadRepository<DbEdiFileDataUploadDuplicate> ediFileDataUploadDuplicateRepository,
            IEdiReadRepository<DbEdiFileDataUpload> ediFileDataUploadRepository,
            IEdiReadRepository<DbEdiGlobalParameter> ediGlobalParameterRepository,
            IEdiReadRepository<DbEdiInvoiceInformationDuplicate> ediInvoiceInformationDuplicateRepository,
            IEdiReadRepository<DbEdiInvoiceInformation> ediInvoiceInformationRepository,
            IEdiReadRepository<DbEdiInvoiceUnit4> ediInvoiceUnit4nRepository,
            IEdiReadRepository<DbZeroPriceExceptions> ediZeroPriceExceptionsRepository)
        {
            _CustomerParameterRepository = customerParameterRepository;
            _EdiFileDataUploadDuplicateRepository = ediFileDataUploadDuplicateRepository;
            _EdiFileDataUploadRepository = ediFileDataUploadRepository;
            _EdiGlobalParameterRepository = ediGlobalParameterRepository;
            _EdiInvoiceInformationDuplicateRepository = ediInvoiceInformationDuplicateRepository;
            _EdiInvoiceInformationRepository = ediInvoiceInformationRepository;
            _EdiInvoiceUnit4Repository = ediInvoiceUnit4nRepository;
            _EdiZeroPriceExceptionsRepository = ediZeroPriceExceptionsRepository;

            _CustomerParameters = [];
            _EdiFileDataUploadDuplicate = [];
            _EdiFileDataUpload = [];
            _EdiGlobalParameters = [];
            _EdiInvoiceInformationDuplicates = [];
            _EdiInvoiceInformation = [];
            _EdiInvoiceUnit4 = [];
            _EdiZeroPriceExceptions = [];
            
        }

        async Task<Result<List<EdiCustomerParameterGrpc>>> IQueryHandler<GetCustomerParameterQuery, List<EdiCustomerParameterGrpc>>.Handle(GetCustomerParameterQuery query, CancellationToken cancellationToken)
        {
            _CustomerParameters.Clear();
            GetCustomerParameterReadOnlySpec spec = new GetCustomerParameterReadOnlySpec();
            List<DbEdiCustomerParameter> results = await _CustomerParameterRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiCustomerParameter result in results)
            {
                EdiCustomerParameterGrpc mapping = result.MapToCustomerParameterGrpc();
                _CustomerParameters.Add(mapping);
            }

            return _CustomerParameters;
        }

        async Task<Result<List<EdiFileDataUploadDuplicatesGrpc>>> IQueryHandler<GetEdiFileDataUploadDuplicatesQuery, List<EdiFileDataUploadDuplicatesGrpc>>.Handle(GetEdiFileDataUploadDuplicatesQuery query, CancellationToken cancellationToken)
        {
            _EdiFileDataUploadDuplicate.Clear();
            GetEdiFileDataUploadDuplicatesReadOnlySpec spec = new GetEdiFileDataUploadDuplicatesReadOnlySpec();
            List<DbEdiFileDataUploadDuplicate> results = await _EdiFileDataUploadDuplicateRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiFileDataUploadDuplicate result in results)
            {
                EdiFileDataUploadDuplicatesGrpc mapping = result.MapToEdiFileDataUploadDuplicatesGrpc();
                _EdiFileDataUploadDuplicate.Add(mapping);
            }

            return _EdiFileDataUploadDuplicate;
        }

        async Task<Result<List<EdiFileDataUploadGrpc>>> IQueryHandler<GetEdiFileDataUploadQuery, List<EdiFileDataUploadGrpc>>.Handle(GetEdiFileDataUploadQuery query, CancellationToken cancellationToken)
        {
            _EdiFileDataUpload.Clear();
            GetEdiFileDataUploadReadOnlySpec spec = new GetEdiFileDataUploadReadOnlySpec();
            List<DbEdiFileDataUpload> results = await _EdiFileDataUploadRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiFileDataUpload result in results)
            {
                EdiFileDataUploadGrpc mapping = result.MapToEdiFileDataUploadGrpc();
                _EdiFileDataUpload.Add(mapping);
            }

            return _EdiFileDataUpload;
        }

        async Task<Result<List<EdiGlobalParametersGrpc>>> IQueryHandler<GetEdiGlobalParameterQuery, List<EdiGlobalParametersGrpc>>.Handle(GetEdiGlobalParameterQuery query, CancellationToken cancellationToken)
        {
            _EdiFileDataUpload.Clear();
            GetGlobalParameterReadOnlySpec spec = new GetGlobalParameterReadOnlySpec();
            List<DbEdiGlobalParameter> results = await _EdiGlobalParameterRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiGlobalParameter result in results)
            {
                EdiGlobalParametersGrpc mapping = result.MapToEdiGlobalParametersGrpc();
                _EdiGlobalParameters.Add(mapping);
            }

            return _EdiGlobalParameters;
        }

        async Task<Result<List<EdiInvoiceInformationDuplicateGrpc>>> IQueryHandler<GetEdiInvoiceInformationDuplicatesQuery, List<EdiInvoiceInformationDuplicateGrpc>>.Handle(GetEdiInvoiceInformationDuplicatesQuery query, CancellationToken cancellationToken)
        {
            _EdiInvoiceInformationDuplicates.Clear();
            GetEdiInvoiceInformationDuplicateReadOnlySpec spec = new GetEdiInvoiceInformationDuplicateReadOnlySpec();
            List<DbEdiInvoiceInformationDuplicate> results = await _EdiInvoiceInformationDuplicateRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiInvoiceInformationDuplicate result in results)
            {
                EdiInvoiceInformationDuplicateGrpc mapping = result.MapToEdiInvoiceInformationDuplicateGrpc();
                _EdiInvoiceInformationDuplicates.Add(mapping);
            }

            return _EdiInvoiceInformationDuplicates;
        }

        async Task<Result<List<EdiInvoiceInformationGrpc>>> IQueryHandler<GetEdiInvoiceInformationQuery, List<EdiInvoiceInformationGrpc>>.Handle(GetEdiInvoiceInformationQuery query, CancellationToken cancellationToken)
        {
            _EdiInvoiceInformation.Clear();
            GetEdiInvoiceInformationReadOnlySpec spec = new GetEdiInvoiceInformationReadOnlySpec();
            List<DbEdiInvoiceInformation> results = await _EdiInvoiceInformationRepository.ListAsync(spec, cancellationToken);
            foreach (DbEdiInvoiceInformation result in results)
            {
                EdiInvoiceInformationGrpc mapping = result.MapToEdiInvoiceInformationGrpc();
                _EdiInvoiceInformation.Add(mapping);
            }

            return _EdiInvoiceInformation;
        }

        async Task<Result<List<EdiInvoiceUnit4Grpc>>> IQueryHandler<GetEdiInvoiceUnit4Query, List<EdiInvoiceUnit4Grpc>>.Handle(GetEdiInvoiceUnit4Query query, CancellationToken cancellationToken)
        {
            _EdiInvoiceUnit4.Clear();
            GetEdiInvoiceUnit4ReadOnlySpec spec = new GetEdiInvoiceUnit4ReadOnlySpec();
            List<DbEdiInvoiceUnit4> results = await _EdiInvoiceUnit4Repository.ListAsync(spec, cancellationToken);
            foreach (DbEdiInvoiceUnit4 result in results)
            {
                EdiInvoiceUnit4Grpc mapping = result.MapToEdiInvoiceUnit4Grpc();
                _EdiInvoiceUnit4.Add(mapping);
            }

            return _EdiInvoiceUnit4;
        }

        async Task<Result<List<EdiZeroPriceExceptionsGrpc>>> IQueryHandler<GetZeroPriceExceptionsQuery, List<EdiZeroPriceExceptionsGrpc>>.Handle(GetZeroPriceExceptionsQuery query, CancellationToken cancellationToken)
        {
            _EdiZeroPriceExceptions.Clear();
            GetZeroPriceExceptionReadOnlySpec spec = new GetZeroPriceExceptionReadOnlySpec();
            List<DbZeroPriceExceptions> results = await _EdiZeroPriceExceptionsRepository.ListAsync(spec, cancellationToken);
            foreach (DbZeroPriceExceptions result in results)
            {
                EdiZeroPriceExceptionsGrpc mapping = result.MapToEdiZeroPriceExceptionsGrpc();
                _EdiZeroPriceExceptions.Add(mapping);
            }

            return _EdiZeroPriceExceptions;
        }
    }
}

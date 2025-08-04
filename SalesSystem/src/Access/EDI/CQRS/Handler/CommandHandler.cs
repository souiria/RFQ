namespace EDI.CQRS.Handler
{
    sealed class CommandHandler : ICommandHandler<AddEdiFileDataCommand, bool>,
        ICommandHandler<AddEdiFileDuplicateDataCommand, bool>,
        ICommandHandler<AddEdiInvoiceInformationCommand, bool>,
        ICommandHandler<AddEdiInvoiceInformationDuplicatesCommand, bool>,
        ICommandHandler<AddEdiCustomerParameterCommand, bool>,
        ICommandHandler<AddEdiGlobalParameterCommand, bool>,
        ICommandHandler<AddEdiInvoiceUnit4Command, bool>,
        ICommandHandler<AddZeroPriceExceptionsCommand, bool>
    {
        readonly ILogger<CommandHandler> _Logger;
        readonly IEdiRepository<DbEdiFileDataUpload> _FileUploadRepository;
        readonly IEdiRepository<DbEdiFileDataUploadDuplicate> _FileUploadDuplicateRepository;
        readonly IEdiRepository<DbEdiInvoiceInformation> _EdiInvoiceInformationRepository;
        readonly IEdiRepository<DbEdiInvoiceInformationDuplicate> _EdiInvoiceInformationDuplicateRepository;
        readonly IEdiRepository<DbEdiCustomerParameter> _EdiCustomerParameterRepository;
        readonly IEdiRepository<DbEdiGlobalParameter> _EdiGlobalParameterRepository;
        readonly IEdiRepository<DbEdiInvoiceUnit4> _EdiInvoiceUnit4Repository;
        readonly IEdiRepository<DbZeroPriceExceptions> _ZeroPriceExceptionRepository;

        public CommandHandler(ILogger<CommandHandler> logger, IEdiRepository<DbEdiFileDataUpload> fileUploadRepository,
            IEdiRepository<DbEdiFileDataUploadDuplicate> fileUploadDuplicateRepository,
            IEdiRepository<DbEdiInvoiceInformation> ediInvoiceInformationRepository, 
            IEdiRepository<DbEdiInvoiceInformationDuplicate> ediInvoiceInformationDuplicateRepository, 
            IEdiRepository<DbEdiCustomerParameter> ediCustomerParameterRepository, 
            IEdiRepository<DbEdiGlobalParameter> ediGlobalParameterRepository, 
            IEdiRepository<DbEdiInvoiceUnit4> ediInvoiceUnit4Repository, 
            IEdiRepository<DbZeroPriceExceptions> zeroPriceExceptionRepository)
        {
            _Logger = logger;
            _FileUploadRepository = fileUploadRepository;
            _FileUploadDuplicateRepository = fileUploadDuplicateRepository;
            _EdiInvoiceInformationRepository = ediInvoiceInformationRepository;
            _EdiInvoiceInformationDuplicateRepository = ediInvoiceInformationDuplicateRepository;
            _EdiCustomerParameterRepository = ediCustomerParameterRepository;
            _EdiGlobalParameterRepository = ediGlobalParameterRepository;
            _EdiInvoiceUnit4Repository = ediInvoiceUnit4Repository;
            _ZeroPriceExceptionRepository = zeroPriceExceptionRepository;
        }

        public async Task<Result<bool>> Handle(AddEdiFileDataCommand command, CancellationToken cancellationToken)
        {
            await _FileUploadRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiFileDuplicateDataCommand command, CancellationToken cancellationToken)
        {
            await _FileUploadDuplicateRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiInvoiceInformationCommand command, CancellationToken cancellationToken)
        {
            await _EdiInvoiceInformationRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiInvoiceInformationDuplicatesCommand command, CancellationToken cancellationToken)
        {
            await _EdiInvoiceInformationDuplicateRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiCustomerParameterCommand command, CancellationToken cancellationToken)
        {
            await _EdiCustomerParameterRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiGlobalParameterCommand command, CancellationToken cancellationToken)
        {
            await _EdiGlobalParameterRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddEdiInvoiceUnit4Command command, CancellationToken cancellationToken)
        {
            await _EdiInvoiceUnit4Repository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }

        public async Task<Result<bool>> Handle(AddZeroPriceExceptionsCommand command, CancellationToken cancellationToken)
        {
            await _ZeroPriceExceptionRepository.AddRangeAsync(command.Data, cancellationToken);
            return true;
        }
    }
}

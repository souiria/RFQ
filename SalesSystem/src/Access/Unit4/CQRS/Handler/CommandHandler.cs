namespace Unit4.CQRS.Handler
{
    class CommandHandler: ICommandHandler<AddDispatchToUnit4Command, bool>,
        ICommandHandler<AddUnit4ProductCommand, bool>
    {
        readonly IUnit4Repository<DbAlgBatchInput> _AlgBatchInputRepository;
        readonly IUnit4Repository<DbAlgProductInput> _AlgProductInputRepository;
        readonly ILogger<CommandHandler> _Logger;

        public CommandHandler(ILogger<CommandHandler> logger, IUnit4Repository<DbAlgBatchInput> algBatchInputRepository, IUnit4Repository<DbAlgProductInput> algProductInputRepository)
        {
            _Logger = logger;
            _AlgBatchInputRepository = algBatchInputRepository;
            _AlgProductInputRepository = algProductInputRepository;
        }

        public async Task<Result<bool>> Handle(AddDispatchToUnit4Command command, CancellationToken cancellationToken)
        {
            try
            {
                await _AlgBatchInputRepository.AddRangeAsync(command.Unit4AlgBatchInput, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Result<bool>> Handle(AddUnit4ProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _AlgProductInputRepository.AddAsync(command.ProductData, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }
    }
}

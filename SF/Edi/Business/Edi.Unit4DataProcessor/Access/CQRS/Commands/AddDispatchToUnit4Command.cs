namespace Edi.Unit4DataProcessor.Access.CQRS.Commands;
internal record AddDispatchToUnit4Command(IEnumerable<DbAlgBatchInput> Unit4AlgBatchInput) : IRequest<bool>;

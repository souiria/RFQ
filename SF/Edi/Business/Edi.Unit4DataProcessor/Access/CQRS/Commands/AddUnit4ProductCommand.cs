namespace Edi.Unit4DataProcessor.Access.CQRS.Commands;
internal record AddUnit4ProductCommand(DbAlgProductInput ProductData) : IRequest<bool>;

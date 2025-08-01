namespace EDI.CQRS.Query
{
    class GetZeroPriceExceptionsQuery : IQuery<List<EdiZeroPriceExceptionsGrpc>>;
}

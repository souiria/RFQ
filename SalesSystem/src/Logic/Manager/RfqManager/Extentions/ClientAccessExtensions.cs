namespace RfqModule.Extentions
{
    public static class ClientAccessExtensions
    {
        public static RfqDrawingPartNumbersGrpc ToAccessDto(this RfqDrawingPartNumberGrpc clientDto)
        {
            RfqDrawingPartNumbersGrpc accessDto = new RfqDrawingPartNumbersGrpc();
            accessDto.RowId = clientDto.RowId;
            accessDto.RfqId = clientDto.RfqId;
            accessDto.OriginalPartNumber = clientDto.OriginalPartNumber;
            accessDto.SumitomoPartNumber = clientDto.SumitomoPartNumber;
            accessDto.OriginalPartNumberPrice = clientDto.OriginalPartNumberPrice;
            accessDto.SwappedPartNumber = clientDto.SwappedPartNumber;
            accessDto.SwappedPartNumberPrice = clientDto.SwappedPartNumberPrice;
            accessDto.PriceSource = clientDto.PriceSource;
            accessDto.IsExactMatch = clientDto.IsExactMatch;
            accessDto.IsSwapped = clientDto.IsSwapped;
            accessDto.Comments = clientDto.Comments;
            accessDto.SumitomoPartNumber = clientDto.SumitomoPartNumber;
            accessDto.Quantity = clientDto.Quantity;

            return accessDto;
        }
        public static RfqDrawingPartNumberGrpc ToClientDto(this RfqDrawingPartNumbersGrpc accessDto)
        {
            RfqDrawingPartNumberGrpc clientDto = new RfqDrawingPartNumberGrpc();
            clientDto.RowId = accessDto.RowId;
            clientDto.RfqId = accessDto.RfqId;
            clientDto.OriginalPartNumber = accessDto.OriginalPartNumber;
            clientDto.SumitomoPartNumber = accessDto.SumitomoPartNumber;
            clientDto.OriginalPartNumberPrice = accessDto.OriginalPartNumberPrice ?? 0.0;
            clientDto.SwappedPartNumber = accessDto.SwappedPartNumber;
            clientDto.SwappedPartNumberPrice = accessDto.SwappedPartNumberPrice ?? 0.0;
            clientDto.PriceSource = accessDto.PriceSource;
            clientDto.IsExactMatch = accessDto.IsExactMatch ?? false;
            clientDto.IsSwapped = accessDto.IsSwapped ?? false;
            clientDto.Comments = accessDto.Comments;
            clientDto.SumitomoPartNumber = accessDto.SumitomoPartNumber;
            clientDto.Quantity = accessDto.Quantity ?? 0.0;
            return clientDto;
        }
    }
}

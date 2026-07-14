namespace SharedModels.DocumentConverter.EDI.Aggregates
{
    public class EdiFileDataAggregate
    {
        public IEnumerable<DTO.EdiFileDataDto> EdiFileDataDtos
        { get; set; } = new List<DTO.EdiFileDataDto>();

        public IEnumerable<DTO.EdiFileDataDto> DuplicateEdiFileDataDtos
        { get; set; } = new List<DTO.EdiFileDataDto>();

    }
}

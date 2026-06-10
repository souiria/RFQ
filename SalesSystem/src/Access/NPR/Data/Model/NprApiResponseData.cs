namespace NPR.Data.Model
{
    public class NprApiResponseData
    {
        [JsonProperty("data")]
        public Collection<NprApiReturnData> Data 
        { get; } = new();
    }
}

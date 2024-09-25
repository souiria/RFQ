namespace CommercialService2.Api.Common.Exceptions;
public class SafeExceptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsSubclassOf(typeof(Exception)); //Alternative all exceptions to safe.
        //return objectType.FullName == "AutoMapper.AutoMapperMappingException";
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is Exception ex)
        {
            var safeException = new CopyToSafeException(ex);
            var objectToken = JObject.FromObject(safeException);
            objectToken.WriteTo(writer);
        }
    }
}

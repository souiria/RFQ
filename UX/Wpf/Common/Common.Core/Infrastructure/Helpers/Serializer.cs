using System;
using System.Collections.Generic;
using Common.Core.Infrastructure.Converters;
using Newtonsoft.Json;

namespace Common.Core.Infrastructure.Helpers
{
    public static class Serializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new JsonNodeCollectionConverter() },
            TypeNameHandling = TypeNameHandling.Auto,
            SerializationBinder = new HarnessOneSerializationBinder(),
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }

        public static object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, Settings);
        }

        public static TType Deserialize<TType>(string json)
        {
            return JsonConvert.DeserializeObject<TType>(json, Settings);
        }
    }
}

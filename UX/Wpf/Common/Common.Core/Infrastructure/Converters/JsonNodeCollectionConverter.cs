using System;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.Core.Infrastructure.Converters
{
    public class JsonNodeCollectionConverter : JsonConverter<NodeCollection>
    {
        public override void WriteJson(JsonWriter writer, NodeCollection value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("$type");
            writer.WriteValue(value.Value.GetType().AssemblyQualifiedName);
            writer.WritePropertyName("value");
            serializer.Serialize(writer, value.Value);
            writer.WritePropertyName("nodes");
            serializer.Serialize(writer, value.Nodes);
            writer.WriteEndObject();
        }

        public override NodeCollection ReadJson(JsonReader reader, Type objectType, NodeCollection existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var token = JObject.Load(reader);

            return ReadJson(token, serializer);
        }

        public NodeCollection ReadJson(JObject token, JsonSerializer serializer)
        {
            var node = new NodeCollection();
            Type valueType = null;

            foreach (var property in token.Properties())
            {
                switch (property.Name)
                {
                    case "$type":
                        var type = property.Value.Value<string>();
                        valueType = Type.GetType(type);
                        break;

                    case "value":
                        node.Value = property.Value.ToObject(valueType, serializer);
                        break;

                    case "nodes":
                        node.Nodes = new ObservableCollection<NodeCollection>();
                        foreach (var child in property.Value.Children<JObject>())
                        {
                            var childNode = ReadJson(child, serializer);
                            node.AddChild(childNode);
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(property), "Could not read unknown property type.");
                }
            }

            return node;
        }
    }
}

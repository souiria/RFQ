using System;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.Core.Infrastructure.Extensions
{
    /// <inheritdoc />
    public class NodeCollectionJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case TreeCollection tree:
                    writer.WriteStartArray();
                    foreach (var node in tree)
                        WriteJson(writer, node, serializer);

                    writer.WriteEndArray();
                    break;

                case NodeCollection node:
                    writer.WriteStartObject();
                    writer.WritePropertyName("ValueType");
                    writer.WriteValue(node.Value.GetType().FullName);
                    writer.WritePropertyName("Value");
                    serializer.Serialize(writer, node.Value);
                    writer.WritePropertyName("CombinedId");
                    writer.WriteValue(node.CombinedId);
                    writer.WritePropertyName("Nodes");
                    writer.WriteStartArray();

                    foreach (var inner in node)
                        WriteJson(writer, inner, serializer);

                    writer.WriteEndArray();
                    writer.WriteEndObject();
                    break;

                default:
                    throw new JsonSerializationException("Expected TreeCollection, NodeCollection or EndNode object value.");
            }
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(TreeCollection))
            {
                var tree = new TreeCollection();
                foreach (var inner in JArray.Load(reader))
                {
                    tree.Add(ReadNodeCollection((JObject)inner, serializer));
                }

                return tree;
            }

            if (objectType != typeof(NodeCollection))
                throw new JsonSerializationException("Expected TreeCollection or NodeCollection.");

            var jObject = JObject.Load(reader);
            var type = Type.GetType(jObject["ValueType"].Value<string>());

            var value = jObject["Value"].ToObject(type, serializer);
            var combinedId = jObject["CombinedId"].Value<Guid?>();

            var node = combinedId.HasValue ? new NodeCollection(value, combinedId.Value) : new NodeCollection(value);
            foreach (var inner in jObject["Nodes"].AsJEnumerable())
            {
                node.Add(ReadNodeCollection((JObject)inner, serializer));
            }

            return node;
        }

        private static INode ReadNodeCollection(JObject jObject, JsonSerializer serializer)
        {
            var type = Type.GetType(jObject["ValueType"].Value<string>());

            var value = jObject["Value"].ToObject(type, serializer);
            var combinedId = jObject["CombinedId"].Value<Guid?>();

            var node = combinedId.HasValue ? new NodeCollection(value, combinedId.Value) : new NodeCollection(value);
            foreach (var inner in jObject["Nodes"].AsJEnumerable())
            {
                node.Add(ReadNodeCollection((JObject)inner, serializer));
            }

            return node;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) =>
            typeof(TreeCollection) == objectType || typeof(NodeCollection) == objectType;
    }
}

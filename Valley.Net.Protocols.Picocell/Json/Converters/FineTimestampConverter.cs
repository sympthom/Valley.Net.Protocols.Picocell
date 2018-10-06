using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Lora.Simulator.Protocols.Json.Converters
{
    internal sealed class FineTimestampConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(uint) || objectType == typeof(ulong) || objectType == typeof(long);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;

                var jsonToken = JToken.Load(reader);

                JValue jsonValue;// = new JArray();

                if (jsonToken is JValue)
                    jsonValue = jsonToken as JValue;
                else
                    return null;

                var value = jsonValue.Value<long>();

                return value;
            }
            catch { }

            return null;
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json.Converters
{
    internal sealed class CodeRateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var codeRate = (CodeRate)value;

            switch (codeRate)
            {
                case CodeRate.DEFAULT: writer.WriteValue("?"); break;
                case CodeRate.OFF: writer.WriteValue("OFF"); break;
                case CodeRate.CR_LORA_4_5: writer.WriteValue("4/5"); break;
                case CodeRate.CR_LORA_4_6: writer.WriteValue("4/6"); break;
                case CodeRate.CR_LORA_4_7: writer.WriteValue("4/7"); break;
                case CodeRate.CR_LORA_4_8: writer.WriteValue("4/8"); break;
                default: throw new NotImplementedException($"The enum value '{codeRate.ToString()}' could not be serialized to a string.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch (enumString)
            {
                case "?": return CodeRate.DEFAULT;
                case "OFF": return CodeRate.OFF;
                case "4/5": return CodeRate.CR_LORA_4_5;
                case "4/6": return CodeRate.CR_LORA_4_6;
                case "4/7": return CodeRate.CR_LORA_4_7;
                case "4/8": return CodeRate.CR_LORA_4_8;
                default: throw new NotImplementedException($"The string value '{enumString}' could not be deserialized to enum of type '{objectType.Name}'.");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json.Converters
{
    internal sealed class StatConverter_IdentifyByPayload : JsonCreationConverter<Stat>
    {
        protected override Stat Create(Type objectType, JObject jObject)
        {
            if (!FieldExists("fpga", jObject) && !FieldExists("temp", jObject) && !FieldExists("hal", jObject))
            {
                return new StatV1();
            }
            else
            {
                return new StatV2();
            }
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}

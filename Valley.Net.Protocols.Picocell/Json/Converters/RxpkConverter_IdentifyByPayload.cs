using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json.Converters
{
    internal sealed class RxpkConverter_IdentifyByPayload : JsonCreationConverter<Rxpk>
    {
        protected override Rxpk Create(Type objectType, JObject jObject)
        {
            if (!FieldExists("rsig", jObject))
            {
                return new RxpkV1();
            }
            else
            {
                return new RxpkV2();
            }
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}

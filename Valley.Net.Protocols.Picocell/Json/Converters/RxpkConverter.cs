using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json.Converters
{
    internal sealed class RxpkConverter : JsonCreationConverter<Rxpk>
    {
        private readonly int _protocolVersion;

        public RxpkConverter(int protocolVersion)
        {
            _protocolVersion = protocolVersion;
        }

        protected override Rxpk Create(Type objectType, JObject jObject)
        {
            switch (_protocolVersion)
            {
                case 1: return new RxpkV1();
                case 2: return new RxpkV2();
                default: throw new NotImplementedException($"The protocol version '{_protocolVersion}' is not implemented.");
            }
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }   
}

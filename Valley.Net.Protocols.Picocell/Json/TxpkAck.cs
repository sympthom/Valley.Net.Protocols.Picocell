using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class TxpkAck
    {
        /// <summary>
        /// Indication about success or type of failure that occured for downlink request.
        /// </summary>
        [JsonProperty(PropertyName = "error", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Error Error { get; set; }
    }
}

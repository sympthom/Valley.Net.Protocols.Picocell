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
    public sealed class TxAckPacketPayload : IPacketPayload
    {
        [JsonProperty(PropertyName = "txpk_ack", Required = Required.DisallowNull)]
        public TxpkAck TxpkAck { get; set; }
    }
}

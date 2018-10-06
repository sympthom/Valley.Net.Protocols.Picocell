using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class PushDataPacketPayload : IPacketPayload
    {
        [JsonProperty(PropertyName = "rxpk", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IList<Rxpk> Rxpk { get; set; }

        [JsonProperty(PropertyName = "stat", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Stat Stat { get; set; }
    }   
}

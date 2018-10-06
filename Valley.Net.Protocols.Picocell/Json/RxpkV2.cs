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
    public sealed class RxpkV2 : Rxpk
    {
        /// <summary>
        /// The "rsig" array contains a JSON object per antenna, each object contains the metadata associated with the received signal with following fields.
        /// </summary>
        [JsonProperty(PropertyName = "rsig", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Rsig> RadioSignals { get; set; }
    }
}

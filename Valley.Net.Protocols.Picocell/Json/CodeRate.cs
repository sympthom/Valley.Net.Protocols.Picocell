using Valley.Net.Protocols.Picocell.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    /// <summary>
    /// Packet ECC coding rate.
    /// </summary>
    [JsonConverter(typeof(CodeRateConverter))]
    public enum CodeRate
    {
        OFF,

        DEFAULT,

        CR_LORA_4_5,

        CR_LORA_4_6,

        CR_LORA_4_7,

        CR_LORA_4_8,
    }
}

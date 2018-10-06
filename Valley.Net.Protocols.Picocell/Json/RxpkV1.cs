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
    public sealed class RxpkV1 : Rxpk
    {
        /// <summary>
        /// Concentrator "IF" channel used for RX(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "chan", Required = Required.Default)]
        public short Channel { get; set; }

        /// <summary>
        /// RSSI in dBm(signed integer, 1 dB precision).
        /// </summary>
        [JsonProperty(PropertyName = "rssi", Required = Required.Default)]
        public double ReceivedSignalStrength { get; set; }

        /// <summary>
        /// Lora SNR ratio in dB(signed float, 0.1 dB precision).
        /// </summary>
        [JsonProperty(PropertyName = "lsnr", Required = Required.Default)]
        public double LoraSignalToNoiseRatio { get; set; }
    }
}

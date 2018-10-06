using Valley.Net.Protocols.Picocell.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Rxpk
    {
        /// <summary>
        /// UTC time of pkt RX, us precision, ISO 8601 'compact' format.
        /// </summary>
        [JsonProperty(PropertyName = "time", Required = Required.Default)]
        public DateTime? Time { get; set; }

        /// <summary>
        /// Internal timestamp of "RX finished" event (32b unsigned).
        /// </summary>
        [JsonProperty(PropertyName = "tmst", Required = Required.Default)]
        public long Timestamp { get; set; }

        /// <summary>
        /// RX central frequency in MHz (unsigned float, Hz precision).
        /// </summary>
        [JsonProperty(PropertyName = "freq", Required = Required.Default)]
        public double Frequency { get; set; }

        /// <summary>
        /// Concentrator "RF chain" used for RX(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "rfch", Required = Required.Default)]
        public short RadioFrequencyChain { get; set; }

        /// <summary>
        /// CRC status: 1 = OK, -1 = fail, 0 = no CRC
        /// </summary>
        [JsonProperty(PropertyName = "stat", Required = Required.Default)]
        public CrcStatus CrcStatus { get; set; }

        /// <summary>
        /// Modulation identifier "LORA" or "FSK".
        /// </summary>
        [JsonProperty(PropertyName = "modu", Required = Required.Default)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Modulation Modulation { get; set; }

        /// <summary>
        /// LoRa datarate identifier(eg.SF12BW500).
        /// </summary>
        [JsonProperty(PropertyName = "datr", Required = Required.Default)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DatarateIdentifier DataRate { get; set; }

        /// <summary>
        /// FSK datarate(unsigned, in bits per second).
        /// </summary>
        //[JsonProperty(PropertyName = "datr")]
        //public string Datr { get; set; }

        /// <summary>
        /// LoRa ECC coding rate identifier
        /// </summary>
        [JsonProperty(PropertyName = "codr", Required = Required.Default)]
        public CodeRate CodingRate { get; set; }

        /// <summary>
        /// RF packet payload size in bytes(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "size", Required = Required.Always)]
        public uint Size { get; set; }

        /// <summary>
        /// Base64 encoded RF packet payload, padded.
        /// </summary>
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public string Data { get; set; }
    }
}

using Valley.Net.Protocols.Picocell.Json.Converters;
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
    public sealed class Txpk
    {
        /// <summary>
        /// UTC time of pkt RX, us precision, ISO 8601 'compact' format.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public DateTime? Time { get; set; }

        /// <summary>
        /// Send packet immediately(will ignore tmst & time).
        /// </summary>
        [JsonProperty(PropertyName = "imme")]
        public bool Imme { get; set; }

        /// <summary>
        /// Send packet on a certain timestamp value(will ignore time).
        /// </summary>
        [JsonProperty(PropertyName = "tmst")]
        public long Tmst { get; set; }

        /// <summary>
        /// Send packet at a certain GPS time(GPS synchronization required).
        /// </summary>
        [JsonProperty(PropertyName = "tmms")]
        public long Tmms { get; set; }

        /// <summary>
        /// TX central frequency in MHz(unsigned float, Hz precision).
        /// </summary>
        [JsonProperty(PropertyName = "freq")]
        public double Freq { get; set; }

        /// <summary>
        /// Concentrator "RF chain" used for TX(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "rfch")]
        public uint Rfch { get; set; }

        /// <summary>
        /// TX output power in dBm(unsigned integer, dBm precision).
        /// </summary>
        [JsonProperty(PropertyName = "powe")]
        public uint Powe { get; set; }

        /// <summary>
        /// Modulation identifier "LORA" or "FSK".
        /// </summary>
        [JsonProperty(PropertyName = "modu")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Modulation Modu { get; set; }

        /// <summary>
        /// LoRa datarate identifier(eg.SF12BW500).
        /// </summary>
        [JsonProperty(PropertyName = "datr")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DatarateIdentifier Datr { get; set; }

        /// <summary>
        /// FSK datarate(unsigned, in bits per second).
        /// </summary>
        //public uint datr { get; set; }

        /// <summary>
        /// LoRa ECC coding rate identifier
        /// </summary>
        [JsonProperty(PropertyName = "codr")]
        public CodeRate Codr { get; set; }

        /// <summary>
        /// FSK frequency deviation(unsigned integer, in Hz).
        /// </summary>
        [JsonProperty(PropertyName = "fdev")]
        public uint Fdev { get; set; }

        /// <summary>
        /// Lora modulation polarization inversion.
        /// </summary>
        [JsonProperty(PropertyName = "ipol")]
        public bool Ipol { get; set; }

        /// <summary>
        /// RF preamble size(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "prea")]
        public uint Prea { get; set; }

        /// <summary>
        /// RF packet payload size in bytes(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public uint Size { get; set; }

        /// <summary>
        /// Base64 encoded RF packet payload, padding optional.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        /// <summary>
        /// If true, disable the CRC of the physical layer(optional).
        /// </summary>
        [JsonProperty(PropertyName = "ncrc")]
        public bool Ncrc { get; set; }
    }
}

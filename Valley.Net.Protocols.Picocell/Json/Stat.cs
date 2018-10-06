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
    //[JsonConverter(typeof(StatConverter))]
    public abstract class Stat
    {
        /// <summary>
        /// UTC 'system' time of the gateway, ISO 8601 'expanded' format.
        /// </summary>
        [JsonProperty(PropertyName = "time", Required = Required.Default)]
        public DateTime? Time { get; set; }

        /// <summary>
        /// GPS latitude of the gateway in degree (float, N is +).
        /// </summary>
        [JsonProperty(PropertyName = "lati", Required = Required.Default)]
        public double Lati { get; set; }

        /// <summary>
        /// GPS latitude of the gateway in degree (float, E is +).
        /// </summary>
        [JsonProperty(PropertyName = "long", Required = Required.Default)]
        public double Long { get; set; }

        /// <summary>
        /// GPS altitude of the gateway in meter RX (integer).
        /// </summary>
        [JsonProperty(PropertyName = "alti", Required = Required.Default)]
        public int Alti { get; set; }

        /// <summary>
        /// Number of radio packets received (unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "rxnb", Required = Required.Default)]
        public uint Rxnb { get; set; }

        /// <summary>
        /// Number of radio packets received with a valid PHY CRC.
        /// </summary>
        [JsonProperty(PropertyName = "rxok", Required = Required.Default)]
        public uint Rxok { get; set; }

        /// <summary>
        /// Number of radio packets forwarded (unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "rxfw", Required = Required.Default)]
        public uint Rxfw { get; set; }

        /// <summary>
        /// Percentage of upstream datagrams that were acknowledged.
        /// </summary>
        [JsonProperty(PropertyName = "ackr", Required = Required.Default)]
        public double Ackr { get; set; }

        /// <summary>
        /// Number of downlink datagrams received (unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "dwnb", Required = Required.Default)]
        public uint Dwnb { get; set; }

        /// <summary>
        /// Number of packets emitted (unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "txnb", Required = Required.Default)]
        public uint Txnb { get; set; }
    }
}

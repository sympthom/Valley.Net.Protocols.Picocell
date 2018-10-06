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
    public sealed class StatV2 : Stat
    {
        /// <summary>
        /// Number of packets received from link testing mote, with CRC OK(unsigned inteter).
        /// </summary>
        [JsonProperty(PropertyName = "lmok", Required = Required.Default)]
        public uint Lmok { get; set; }

        /// <summary>
        /// Sequence number of the first packet received from link testing mote(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "lmst", Required = Required.Default)]
        public uint Lmst { get; set; }

        /// <summary>
        /// Sequence number of the last packet received from link testing mote(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "lmnw", Required = Required.Default)]
        public uint Lmnw { get; set; }

        /// <summary>
        /// Number of lost PPS pulses(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "lpps", Required = Required.Default)]
        public uint Lpps { get; set; }

        /// <summary>
        /// Temperature of the Gateway(signed integer).
        /// </summary>
        [JsonProperty(PropertyName = "temp", Required = Required.Default)]
        public int Temp { get; set; }

        /// <summary>
        /// Version of Gateway FPGA(unsigned integer).
        /// </summary>
        [JsonProperty(PropertyName = "fpga", Required = Required.Default)]
        public uint Fpga { get; set; }

        /// <summary>
        /// Version of Gateway DSP software(unsigned interger).
        /// </summary>
        [JsonProperty(PropertyName = "dsp", Required = Required.Default)]
        public uint Dsp { get; set; }

        /// <summary>
        /// Version of Gateway driver(format X.X.X).
        /// </summary>
        [JsonProperty(PropertyName = "hal", Required = Required.Default)]
        public string Hal { get; set; }
    }
}

using Lora.Simulator.Protocols.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Valley.Net.Protocols.Picocell.Json
{
    public sealed class Rsig
    {
        /// <summary>
        /// Gets or sets the luminance signal to noise ratio.
        /// </summary>
        /// <value>
        /// The luminance signal to noise ratio.
        /// </value>
        [JsonProperty(PropertyName = "ant", Required = Required.Default)]
        public uint Antenna { get; set; }

        /// <summary>
        /// Gets or sets the luminance signal to noise ratio.
        /// </summary>
        /// <value>
        /// The luminance signal to noise ratio.
        /// </value>
        [JsonProperty(PropertyName = "chan", Required = Required.Default)]
        public uint Channel { get; set; }

        /// <summary>
        /// Gets or sets the luminance signal to noise ratio.
        /// </summary>
        /// <value>
        /// The luminance signal to noise ratio.
        /// </value>
        [JsonProperty(PropertyName = "lsnr", Required = Required.Default)]
        public double LoraSignalToNoiseRatio { get; set; }

        /// <summary>
        /// Gets or sets the received signal strength indicator of the signal. (Optional)
        /// </summary>
        /// <value>
        /// The received signal strength indicator of the signal.
        /// </value>
        [JsonProperty(PropertyName = "rssis", Required = Required.Default)]
        public double ReceivedSignalStrengthIndicatorSignal { get; set; }

        /// <summary>
        /// Gets or sets the received signal strength indicator of the channel.
        /// </summary>
        /// <value>
        /// The received signal strength indicator of the channel.
        /// </value>
        [JsonProperty(PropertyName = "rssic", Required = Required.Default)]
        public double ReceivedSignalStrengthChannel { get; set; }

        /// <summary>
        /// Gets or sets the received signal strength indicator deviation. (Optional)
        /// </summary>
        /// <value>
        /// The received signal strength indicator.
        /// </value>
        [JsonProperty(PropertyName = "rssisd", Required = Required.Default)]
        public uint ReceivedSignalStrengthIndicatorStandardDeviation { get; set; }

        /// <summary>
        /// Gets or sets the Encrypted timestamp, ns precision
        /// </summary>
        /// <value>
        /// The Encrypted timestamp, ns precision
        /// </value>
        [JsonProperty(PropertyName = "etime", Required = Required.Default)]
        public string EncryptedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the frequency offset in Hz [-125kHz..+125Khz]
        /// </summary>
        /// <value>
        /// The frequency offset in Hz [-125kHz..+125Khz]
        /// </value>
        [JsonProperty(PropertyName = "foff", Required = Required.Default)]
        public double FrequencyOffset { get; set; }

        /// <summary>
        /// Fine timestamp of reception in microseconds
        /// </summary>
        /// <value>
        /// Fine timestamp of reception in microseconds
        /// </value>
        [JsonProperty(PropertyName = "ftime", Required = Required.Default)]
        [JsonConverter(typeof(FineTimestampConverter))]
        public Int64? FineTimestamp { get; set; }

        // TODO: Investigate these
        /// <summary>
        /// I dont know, needs investigating
        /// </summary>
        /// <value>
        /// I dont know, needs investigating
        /// </value>
        [JsonProperty(PropertyName = "ft2d", Required = Required.Default)]
        public int Ft2d { get; set; }

        /// <summary>
        /// I dont know, needs investigating
        /// </summary>
        /// <value>
        /// I dont know, needs investigating
        /// </value>
        [JsonProperty(PropertyName = "rfbsb", Required = Required.Default)]
        public int Rfbsb { get; set; }

        /// <summary>
        /// I dont know, needs investigating
        /// </summary>
        /// <value>
        /// I dont know, needs investigating
        /// </value>
        [JsonProperty(PropertyName = "rs2s1", Required = Required.Default)]
        public int Rs2s1 { get; set; }
    }
}

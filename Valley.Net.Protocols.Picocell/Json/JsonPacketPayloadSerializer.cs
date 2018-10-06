using Valley.Net.Protocols.Picocell.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    public sealed class JsonPacketPayloadSerializer
    {
        private readonly JsonSerializer _jsonSerialiser;
        private readonly JsonSerializerSettings _serializeSettings;

        /// <summary>
        /// Constructor for PicocellPacketPayloadSerializer.
        /// </summary>
        public JsonPacketPayloadSerializer()
        {
            _serializeSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                //Formatting = Formatting.Indented,                 
            };

            _jsonSerialiser = JsonSerializer.Create(_serializeSettings);
        }

        public byte[] Serialize(IPacketPayload payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            var json = JsonConvert.SerializeObject(payload, _serializeSettings);
            var data = Encoding.ASCII.GetBytes(json);

            return data;
        }

        public T Deserialize<T>(byte[] data) where T : IPacketPayload
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var json = Encoding.Default.GetString(data);

            return Deserialize<T>(json);
        }

        public T Deserialize<T>(string json) where T : IPacketPayload
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(nameof(json));

            var message = JsonConvert.DeserializeObject<T>(json, new RxpkConverter_IdentifyByPayload(), new StatConverter_IdentifyByPayload());

            return message;
        }

        public T Deserialize<T>(byte[] data, int protocolVersion) where T : IPacketPayload
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var json = Encoding.Default.GetString(data);

            return Deserialize<T>(json, protocolVersion);
        }

        public T Deserialize<T>(string json, int protocolVersion) where T : IPacketPayload
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(nameof(json));

            if (protocolVersion == 0)
                throw new ArgumentNullException(nameof(protocolVersion));

            if (protocolVersion < 0)
                throw new ArgumentOutOfRangeException(nameof(protocolVersion));

            if (protocolVersion > 2)
                throw new ArgumentOutOfRangeException(nameof(protocolVersion));

            //var message = JsonConvert.DeserializeObject<T>(json, new RxpkConverter_IdentifyByProtocolVersion(protocolVersion), new StatConverter_IdentifyByProtocolVersion(protocolVersion));
            var message = JsonConvert.DeserializeObject<T>(json, new RxpkConverter_IdentifyByPayload(), new StatConverter_IdentifyByPayload());
            
            return message;
        }
    }
}

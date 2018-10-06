using Valley.Net.Protocols.Picocell.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    /// <summary>
    /// That packet type is used by the server to send RF packets and associated 
    /// metadata that will have to be emitted by the gateway.
    /// Bytes   | Function
    /// :------:| ---------------------------------------------------------------------
    /// 0 | protocol version = 1
    /// 1 - 2 | unused bytes
    /// 3 | PULL_RESP identifier 0x03
    /// 4 - end | JSON object, starting with {, ending with }, see section 6
    /// </summary>
    public sealed class PullRespPacket : PicocellPacket
    {
        public PullRespPacketPayload Payload { get; set; }

        /// <summary>
        /// Constructor for PullRespPacket.
        /// </summary>
        public PullRespPacket() : base(MessageType.PULL_RESP)
        {

        }
    }
}

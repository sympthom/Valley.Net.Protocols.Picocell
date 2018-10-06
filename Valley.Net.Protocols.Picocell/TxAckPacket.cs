using Valley.Net.Protocols.Picocell.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class TxAckPacket : PicocellPacket
    {
        /// <summary>
        /// Gateway unique identifier (MAC address)
        /// </summary>
        public string Eui { get; set; }

        public TxAckPacketPayload Payload { get; set; }

        /// <summary>
        /// Constructor for TxAckPacket.
        /// </summary>
        public TxAckPacket() : base(MessageType.TX_ACK)
        {

        }
    }
}

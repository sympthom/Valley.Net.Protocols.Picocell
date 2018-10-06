using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    /// <summary>
    /// That packet type is used by the server to acknowledge immediately all the 
    /// PUSH_DATA packets received.
    /// 
    /// Bytes  | Function
    /// :------:|---------------------------------------------------------------------
    /// 0      | protocol version = 2
    /// 1-2    | same token as the PUSH_DATA packet to acknowledge
    /// 3      | PUSH_ACK identifier 0x01
    /// </summary>
    public sealed class PushAckPacket : PicocellPacket
    {
        /// <summary>
        /// Constructor for PushAckPacket.
        /// </summary>
        public PushAckPacket() : base(MessageType.PUSH_ACK)
        {

        }
    }
}

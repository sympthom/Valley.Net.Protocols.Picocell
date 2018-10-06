using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class PullAckPacket : PicocellPacket
    {
        /// <summary>
        /// Constructor for PullAckPacket.
        /// </summary>
        public PullAckPacket() : base(MessageType.PULL_ACK)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    public enum MessageType : ushort
    {
        /// <summary>
        /// Upstream.
        /// </summary>
        PUSH_DATA = 0x00,

        /// <summary>
        /// Upstream.
        /// </summary>
        PUSH_ACK = 0x01,

        /// <summary>
        /// Downstream.
        /// </summary>
        PULL_DATA = 0x02,

        /// <summary>
        /// Upstream.
        /// </summary>
        PULL_RESP = 0x03,

        /// <summary>
        /// Upstream.
        /// </summary>
        PULL_ACK = 0x04,

        /// <summary>
        /// Upstream.
        /// </summary>
        TX_ACK = 0x05
    }
}

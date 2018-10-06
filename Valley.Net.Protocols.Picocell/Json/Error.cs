using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    public enum Error
    {
        /// <summary>
        /// Packet has been programmed for downlink
        /// </summary>
        NONE,

        /// <summary>
        /// Rejected because it was already too late to program this packet for downlink
        /// </summary>
        TOO_LATE,

        /// <summary>
        /// Rejected because downlink packet timestamp is too much in advance
        /// </summary>
        TOO_EARLY,

        /// <summary>
        /// Rejected because there was already a packet programmed in requested timeframe
        /// </summary>
        COLLISION_PACKET,

        /// <summary>
        /// Rejected because there was already a beacon planned in requested timeframe
        /// </summary>
        COLLISION_BEACON,

        /// <summary>
        /// Rejected because requested frequency is not supported by TX RF chain
        /// </summary>
        TX_FREQ,

        /// <summary>
        /// Rejected because requested power is not supported by gateway
        /// </summary>
        TX_POWER,

        /// <summary>
        /// Rejected because GPS is unlocked, so GPS timestamp cannot be used
        /// </summary>
        GPS_UNLOCKED
    }
}

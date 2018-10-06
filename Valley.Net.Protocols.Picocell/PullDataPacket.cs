using Valley.Net.Protocols.Picocell.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    /// <summary>
    /// That packet type is used by the gateway to poll data from the server.
    /// 
    /// This data exchange is initialized by the gateway because it might be
    /// impossible for the server to send packets to the gateway if the gateway is 
    /// behind a NAT.
    /// 
    /// When the gateway initialize the exchange, the network route towards the
    /// server will open and will allow for packets to flow both directions.
    /// The gateway must periodically send PULL_DATA packets to be sure the network
    /// route stays open for the server to be used at any time.
    /// 
    /// Bytes  | Function
    /// :------:|---------------------------------------------------------------------
    /// 0      | protocol version = 2
    /// 1-2    | random token
    /// 3      | PULL_DATA identifier 0x02
    /// 4-11   | Gateway unique identifier (MAC address)
    /// </summary>
    public sealed class PullDataPacket : PicocellPacket
    {
        /// <summary>
        /// Gateway unique identifier (MAC address)
        /// </summary>
        [MaxLength(16, ErrorMessage = "Has to be 16 length.")]
        [MinLength(16, ErrorMessage = "Has to be 16 length.")]
        public string Eui { get; set; }

        /// <summary>
        /// Constructor for PullDataPacket.
        /// </summary>
        public PullDataPacket() : base(MessageType.PULL_DATA)
        {

        }
    }
}

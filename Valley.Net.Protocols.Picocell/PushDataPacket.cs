using Valley.Net.Protocols.Picocell.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class PushDataPacket : PicocellPacket
    {
        /// <summary>
        /// Gateway unique identifier (MAC address)
        /// </summary>
        [MaxLength(16, ErrorMessage = "Has to be 16 length.")]
        [MinLength(16, ErrorMessage = "Has to be 16 length.")]
        public string Eui { get; set; }

        public PushDataPacketPayload Payload { get; set; }

        /// <summary>
        /// Constructor for PushDataPacket.
        /// </summary>
        public PushDataPacket() : base(MessageType.PUSH_DATA)
        {

        }
    }
}

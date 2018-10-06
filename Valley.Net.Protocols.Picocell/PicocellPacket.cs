using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valley.Net.Bindings;

namespace Valley.Net.Protocols.Picocell
{
    public abstract class PicocellPacket : INetworkPacket
    {
        private int _protocolVersion;

        /// <summary>
        /// Gets or sets the protocol version of the packet payload.
        /// </summary>
        [Display(Name = "Protocol Version", Description = "An integer between 1 and 2.")]
        [Range(1, 2)]
        public int ProtocolVersion
        {
            get { return _protocolVersion; }
            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = nameof(ProtocolVersion) });

                _protocolVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType MessageType { get; private set; }

        /// <summary>
        /// Random token
        /// </summary>
        public ushort Token { get; set; }

        public PicocellPacket(MessageType messageType)
        {
            MessageType = messageType;
        }
    }
}

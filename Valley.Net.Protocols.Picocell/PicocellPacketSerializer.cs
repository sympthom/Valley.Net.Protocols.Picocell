using System;
using System.IO;
using System.Linq;
using System.Text;
using Valley.Net.Bindings;
using Valley.Net.Protocols.Picocell.Json;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class PicocellPacketSerializer : IPacketSerializer
    {
        private readonly JsonPacketPayloadSerializer _payloadSerialiser;

        /// <summary>
        /// Constructor for PicocellPacketSerializer.
        /// </summary>
        public PicocellPacketSerializer()
        {
            _payloadSerialiser = new JsonPacketPayloadSerializer();
        }

        public INetworkPacket Deserialize(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            using (var stream = new MemoryStream(data))
                return Deserialize(stream);
        }

        public T Deserialize<T>(byte[] data) where T : INetworkPacket
        {
            return (T)Deserialize(data);
        }

        public INetworkPacket Deserialize(byte[] data, int index, int count)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            using (var stream = new MemoryStream(data, index, count))
                return Deserialize(stream);
        }

        public T Deserialize<T>(byte[] data, int index, int count) where T : INetworkPacket
        {
            return (T)Deserialize(data, index, count);
        }

        public INetworkPacket Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (var reader = new BinaryReader(stream))
                return Deserialize(reader);
        }

        public T Deserialize<T>(Stream stream) where T : INetworkPacket
        {
            return (T)Deserialize(stream);
        }

        public INetworkPacket Deserialize(BinaryReader reader)
        {
            var buffer = reader.ReadBytes((int)reader.BaseStream.Length);

            var messageType = (MessageType)buffer[3];

            try
            {
                switch (messageType)
                {
                    case MessageType.PUSH_ACK:
                        {
                            var protocolVersion = (int)buffer[0];

                            var packet = new PushAckPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                            };

                            return packet;
                        }
                    case MessageType.PULL_ACK:
                        {
                            var protocolVersion = (int)buffer[0];

                            var packet = new PullAckPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                            };

                            return packet;
                        }
                    case MessageType.PULL_RESP:
                        {
                            var json = Encoding.ASCII.GetString(buffer, 4, buffer.Length - 4);

                            var protocolVersion = (int)buffer[0];

                            var packet = new PullRespPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                                Payload = _payloadSerialiser.Deserialize<PullRespPacketPayload>(json, protocolVersion)
                            };

                            return packet;
                        }
                    case MessageType.PUSH_DATA:
                        {
                            var json = Encoding.ASCII.GetString(buffer, 12, buffer.Length - 12);

                            var eui = buffer.Skip(4).Take(8).ToArray().ToHex(string.Empty);

                            var protocolVersion = (int)buffer[0];

                            var packet = new PushDataPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                                Eui = eui,
                                Payload = _payloadSerialiser.Deserialize<PushDataPacketPayload>(json, protocolVersion)
                            };

                            return packet;
                        }
                    case MessageType.PULL_DATA:
                        {
                            var protocolVersion = (int)buffer[0];

                            var json = Encoding.ASCII.GetString(buffer, 12, buffer.Length - 12);

                            var eui = buffer.Skip(4).Take(8).ToArray().ToHex(string.Empty);

                            var packet = new PullDataPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                                Eui = eui,
                            };

                            return packet;
                        }
                    case MessageType.TX_ACK:
                        {
                            var json = Encoding.ASCII.GetString(buffer, 12, buffer.Length - 12);

                            var eui = buffer.Skip(4).Take(8).ToArray().ToHex(string.Empty);

                            var protocolVersion = (int)buffer[0];

                            var packet = new TxAckPacket
                            {
                                ProtocolVersion = protocolVersion,
                                Token = BitConverter.ToUInt16(buffer, 1),
                                Eui = eui,
                                Payload = _payloadSerialiser.Deserialize<TxAckPacketPayload>(json, protocolVersion)
                            };

                            return packet;
                        }
                    default: throw new NotImplementedException($"Message type '{messageType.GetType().Name}' is not yet implemented.");
                }
            }
            catch (Exception ex)
            {
                throw new PicocellDeserializeException($"Could not deserialize message with message type {messageType.ToString()}.", buffer, ex);
            }
        }

        public T Deserialize<T>(BinaryReader reader) where T : INetworkPacket
        {
            throw new NotImplementedException();
        }

        public int Serialize(INetworkPacket packet, Stream stream)
        {
            if (packet == null)
                throw new ArgumentNullException(nameof(packet));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            return Serialize(packet, new BinaryWriter(stream));
        }

        public int Serialize(INetworkPacket packet, BinaryWriter writer)
        {
            if (packet == null)
                throw new ArgumentNullException(nameof(packet));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            var length = 0;

            try
            {
                switch (packet)
                {
                    case PushAckPacket pushAckPacket:
                        {
                            writer.Write((byte)pushAckPacket.ProtocolVersion);

                            var token = BitConverter.GetBytes(pushAckPacket.Token);
                            writer.Write(token, 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)pushAckPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    case PullAckPacket pullAckPacket:
                        {
                            writer.Write((byte)pullAckPacket.ProtocolVersion);

                            var token = BitConverter.GetBytes(pullAckPacket.Token);
                            writer.Write(token, 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)pullAckPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    case PullRespPacket pullRespPacket:
                        {
                            writer.Write((byte)pullRespPacket.ProtocolVersion);

                            writer.Write(new byte[2], 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)pullRespPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            if (pullRespPacket.Payload == null)
                                throw new NullReferenceException(nameof(pullRespPacket.Payload));

                            var data = _payloadSerialiser.Serialize(pullRespPacket.Payload);
                            writer.Write(data, 0, data.Length);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    case PushDataPacket pushDataPacket:
                        {
                            writer.Write((byte)pushDataPacket.ProtocolVersion);

                            var token = BitConverter.GetBytes(pushDataPacket.Token);
                            writer.Write(token, 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)pushDataPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            var eui = pushDataPacket.Eui.HexToBytes();
                            writer.Write(eui, 0, 8);

                            if (pushDataPacket.Payload == null)
                                throw new NullReferenceException(nameof(pushDataPacket.Payload));

                            var data = _payloadSerialiser.Serialize(pushDataPacket.Payload);
                            writer.Write(data, 0, data.Length);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    case PullDataPacket pullDataPacket:
                        {
                            writer.Write((byte)pullDataPacket.ProtocolVersion);

                            var token = BitConverter.GetBytes(pullDataPacket.Token);
                            writer.Write(token, 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)pullDataPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            var eui = pullDataPacket.Eui.HexToBytes();
                            writer.Write(eui, 0, 8);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    case TxAckPacket txAckPacket:
                        {
                            writer.Write((byte)txAckPacket.ProtocolVersion);

                            var token = BitConverter.GetBytes(txAckPacket.Token);
                            writer.Write(token, 0, 2);

                            var messageType = BitConverter.GetBytes((ushort)txAckPacket.MessageType);
                            writer.Write(messageType, 0, 1);

                            var eui = txAckPacket.Eui.HexToBytes();
                            writer.Write(eui, 0, 8);

                            length = (int)writer.BaseStream.Length;
                        }
                        break;
                    default: throw new NotImplementedException($"Packet type '{packet.GetType().Name}' is not yet implemented.");
                }

                return length;
            }
            catch (Exception ex)
            {
                throw new PicocellSerializeException($"Could not serialize message.", ex);
            }
        }
    }
}

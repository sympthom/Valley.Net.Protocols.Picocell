using System;
using System.Collections.Generic;
using System.IO;
using Valley.Net.Protocols.Picocell.Json;
using Xunit;

namespace Valley.Net.Protocols.Picocell.Test
{
    public sealed class SerializationTests
    {
        [Fact]
        public void Test_Serialize_And_Deserialize_PushDataPacket_Version_1()
        {
            var gatewayId = "0000000000000001";

            /* Create a unique correlation token for the unit test */
            ushort correlationToken = 3;

            /* Create the packet for the network server */
            var packet = new PushDataPacket
            {
                ProtocolVersion = 1,
                Token = correlationToken,
                Eui = gatewayId,
                Payload = new PushDataPacketPayload
                {
                    Rxpk = new List<Rxpk>()
                    {
                        new RxpkV1
                        {
                            Time = DateTime.UtcNow,
                            Timestamp = GpsTime.Time,
                            Channel = 7,
                            RadioFrequencyChain = 1,
                            Frequency = 868.500000,
                            CrcStatus = CrcStatus.OK,
                            Modulation = Modulation.LORA,
                            DataRate = DatarateIdentifier.SF7BW125,
                            CodingRate = CodeRate.CR_LORA_4_8,
                            ReceivedSignalStrength = 112,
                            LoraSignalToNoiseRatio = 1.2,
                            Size = 14,
                            Data = "Wg3qoMwpJ5T372B9pxLIs0kbvUs=",
                        }
                    },
                    Stat = new StatV1
                    {
                        Lati = 46.24,
                        Long = 3.2523,
                        Alti = 100,
                        Time = DateTime.UtcNow,
                    },
                }
            };

            var serializer = new PicocellPacketSerializer();

            using (var stream = new MemoryStream())
            {
                var length = serializer.Serialize(packet, stream);

                stream.Position = 0;

                var result = serializer.Deserialize(stream);
            }
        }

        [Fact]
        public void Test_Serialize_And_Deserialize_PushDataPacket_Version_2()
        {
            var gatewayId = "0000000000000001";

            /* Create a unique correlation token for the unit test */
            ushort correlationToken = 3;

            /* Create the packet for the network server */
            var packet = new PushDataPacket
            {
                ProtocolVersion = 1,
                Token = correlationToken,
                Eui = gatewayId,
                Payload = new PushDataPacketPayload
                {
                    Rxpk = new List<Rxpk>()
                    {
                        new RxpkV2
                        {
                            Time = DateTime.UtcNow,
                            Timestamp = GpsTime.Time,
                            RadioFrequencyChain = 1,
                            Frequency = 868.500000,
                            CrcStatus = CrcStatus.OK,
                            Modulation = Modulation.LORA,
                            DataRate = DatarateIdentifier.SF7BW125,
                            CodingRate = CodeRate.CR_LORA_4_8,
                            Size = 14,
                            Data = "Wg3qoMwpJ5T372B9pxLIs0kbvUs=",
                            RadioSignals = new List<Rsig>()
                            {
                                new Rsig
                                {
                                    Antenna = 0,
                                    Channel = 7,
                                    FineTimestamp = 50000,
                                    EncryptedTimestamp = "asd",
                                    ReceivedSignalStrengthChannel = -75,
                                    LoraSignalToNoiseRatio = 30,
                                }
                            }
                        },
                        new RxpkV2
                        {
                            Time = DateTime.UtcNow,
                            Timestamp = GpsTime.Time,
                            RadioFrequencyChain = 1,
                            Frequency = 868.500000,
                            CrcStatus = CrcStatus.OK,
                            Modulation = Modulation.LORA,
                            DataRate = DatarateIdentifier.SF7BW125,
                            CodingRate = CodeRate.CR_LORA_4_8,
                            Size = 14,
                            Data = "Wg3qoMwpJ5T372B9pxLIs0kbvUs=",
                            RadioSignals = new List<Rsig>()
                            {
                                new Rsig
                                {
                                    Antenna = 1,
                                    Channel = 7,
                                    FineTimestamp = 50000,
                                    EncryptedTimestamp = "asd",
                                    ReceivedSignalStrengthChannel = -75,
                                    LoraSignalToNoiseRatio = 30,
                                }
                            }
                        }
                    },
                    Stat = new StatV2
                    {
                        Lati = 46.24,
                        Long = 3.2523,
                        Alti = 100,
                        Time = DateTime.UtcNow,
                    },
                }
            };

            var serializer = new PicocellPacketSerializer();

            using (var stream = new MemoryStream())
            {
                var length = serializer.Serialize(packet, stream);

                stream.Position = 0;

                //var message = Encoding.Default.GetString(data);

                var result = serializer.Deserialize(stream);
            }
        }

        [Fact]
        public void Test_Deserialize_Rxpk_Version_2()
        {
            var messageType = MessageType.PUSH_DATA;
            var message = "{\"rxpk\":[{\"rsig\":[{\"ant\":0,\"chan\":0,\"lsnr\":30.0,\"rssis\":0.0,\"rssic\":-75.0,\"rssisd\":0,\"etime\":\"asd\",\"foff\":0.0,\"ftime\":50000,\"ft2d\":0,\"rfbsb\":0,\"rs2s1\":0}],\"time\":\"2018-03-27T14:15:00.1849262Z\",\"tmms\":0,\"tmst\":1206195300185,\"freq\":868.5,\"chan\":7,\"rfch\":1,\"stat\":1,\"modu\":\"LORA\",\"datr\":\"SF7BW125\",\"codr\":\"4/8\",\"rssi\":112.0,\"lsnr\":1.2,\"size\":14,\"data\":\"Wg3qoMwpJ5T372B9pxLIs0kbvUs=\"},{\"rsig\":[{\"ant\":0,\"chan\":0,\"lsnr\":30.0,\"rssis\":0.0,\"rssic\":-75.0,\"rssisd\":0,\"etime\":\"asd\",\"foff\":0.0,\"ftime\":50000,\"ft2d\":0,\"rfbsb\":0,\"rs2s1\":0}],\"time\":\"2018-03-27T14:15:00.1869312Z\",\"tmms\":0,\"tmst\":1206195300186,\"freq\":868.5,\"chan\":7,\"rfch\":1,\"stat\":1,\"modu\":\"LORA\",\"datr\":\"SF7BW125\",\"codr\":\"4/8\",\"rssi\":112.0,\"lsnr\":1.2,\"size\":14,\"data\":\"Wg3qoMwpJ5T372B9pxLIs0kbvUs=\"}],\"stat\":{\"lmok\":0,\"lmst\":0,\"lmnw\":0,\"lpps\":0,\"temp\":0,\"fpga\":0,\"dsp\":0,\"time\":\"2018-03-27T14:15:00.1869312Z\",\"lati\":46.24,\"long\":3.2523,\"alti\":100,\"rxnb\":0,\"rxok\":0,\"rxfw\":0,\"ackr\":0.0,\"dwnb\":0,\"txnb\":0}}";
            var protocolVersion = 2;

            IPacketPayload payload = null;

            switch (messageType)
            {
                case MessageType.PUSH_DATA: payload = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion); break;
                case MessageType.PULL_RESP: payload = new JsonPacketPayloadSerializer().Deserialize<PullRespPacketPayload>(message, protocolVersion); break;
                case MessageType.TX_ACK: payload = new JsonPacketPayloadSerializer().Deserialize<TxAckPacketPayload>(message, protocolVersion); break;
            }

            switch (payload)
            {
                case PushDataPacketPayload pushDataPacketPayload: { } break;
                case PullRespPacketPayload pullRespPacketPayload: { } break;
                case TxAckPacketPayload txAckPacketPayload: { } break;
            }
        }

        [Fact]
        public void Test_Deserialize_Txpk_Version_2()
        {
            var messageType = MessageType.PULL_RESP;
            var message = "{\"txpk\":{\"tmst\":1207995511768,\"freq\":868.0,\"rfch\":0,\"powe\":14,\"modu\":\"LORA\",\"datr\":\"SF10BW125\",\"codr\":\"4/8\",\"ipol\":true,\"ncrc\":true,\"size\":12,\"data\":\"YAEAAAAgUK8I3BXl\"}}";
            var protocolVersion = 2;

            IPacketPayload payload = null;

            switch (messageType)
            {
                case MessageType.PUSH_DATA: payload = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion); break;
                case MessageType.PULL_RESP: payload = new JsonPacketPayloadSerializer().Deserialize<PullRespPacketPayload>(message, protocolVersion); break;
                case MessageType.TX_ACK: payload = new JsonPacketPayloadSerializer().Deserialize<TxAckPacketPayload>(message, protocolVersion); break;
            }

            switch (payload)
            {
                case PushDataPacketPayload pushDataPacketPayload: { } break;
                case PullRespPacketPayload pullRespPacketPayload: { } break;
                case TxAckPacketPayload txAckPacketPayload: { } break;
            }
        }

        [Fact]
        public void Test_Serialize_And_Deserialize_PullRespPacket()
        {
            var networkPacket = new PullRespPacket
            {
                ProtocolVersion = 1,
                Payload = new PullRespPacketPayload
                {
                    Txpk = new Txpk
                    {
                        Time = DateTime.UtcNow,
                        Tmst = GpsTime.Time,
                        Codr = CodeRate.CR_LORA_4_5,
                        Data = "asd",
                        Datr = DatarateIdentifier.SF10BW125,
                        Rfch = 1,
                        Freq = 868.500000,
                        Fdev = 1,
                    }
                }
            };

            var serializer = new PicocellPacketSerializer();

            using (var stream = new MemoryStream())
            {
                var length = serializer.Serialize(networkPacket, stream);

                stream.Position = 0;

                //var message = Encoding.Default.GetString(data);

                var result = serializer.Deserialize(stream);
            }
        }

        [Fact]
        public void Can_Deserialize_PUSH_DATA_With_Null_stat_Version_1()
        {
            var message = "{\"stat\":null,\"rxpk\":[{\"rsig\":[{\"ant\":0,\"chan\":0,\"lsnr\":8.5,\"rssis\":-114.0,\"rssic\":-114,\"rssisd\":0,\"etime\":null,\"foff\":0.0,\"ftime\":null,\"ft2d\":0,\"rfbsb\":0,\"rs2s1\":0}],\"tmst\":2214587506,\"time\":\"2018-04-25T15:09:47.5060049Z\",\"freq\":868.5,\"rfch\":0,\"did\":0,\"stat\":1,\"modu\":\"LORA\",\"datr\":\"SF7BW250\",\"codr\":\"4/5\",\"size\":10,\"data\":\"gBAAABEAAQABU7mLhJc=\"}],\"txpk_ack\":null}";
            var serializer = new PicocellPacketSerializer();
            var protocolVersion = 1;
            var result = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion);

            Assert.Null(result.Stat);
            Assert.NotNull(result.Rxpk);
        }

        [Fact]
        public void Can_Deserialize_PUSH_DATA_With_Null_rxpk_Version_1()
        {
            var message = "{\"stat\":null,\"rxpk\":null}";
            var serializer = new PicocellPacketSerializer();
            var protocolVersion = 1;
            var result = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion);

            Assert.Null(result.Rxpk);
            Assert.Null(result.Stat);
        }

        [Fact]
        public void Can_Deserialize_PUSH_DATA_With_stat_missing_Version_1()
        {
            var message = "{\"rxpk\":[{\"rsig\":[{\"ant\":0,\"chan\":0,\"lsnr\":8.5,\"rssis\":-114.0,\"rssic\":-114,\"rssisd\":0,\"etime\":null,\"foff\":0.0,\"ftime\":null,\"ft2d\":0,\"rfbsb\":0,\"rs2s1\":0}],\"tmst\":2214587506,\"time\":\"2018-04-25T15:09:47.5060049Z\",\"freq\":868.5,\"rfch\":0,\"did\":0,\"stat\":1,\"modu\":\"LORA\",\"datr\":\"SF7BW250\",\"codr\":\"4/5\",\"size\":10,\"data\":\"gBAAABEAAQABU7mLhJc=\"}],\"txpk_ack\":null}";
            var serializer = new PicocellPacketSerializer();
            var protocolVersion = 1;
            var result = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion);

            Assert.NotNull(result.Rxpk);
            Assert.Null(result.Stat);
        }

        [Fact]
        public void Can_Deserialize_PUSH_DATA_With_rxpk_missing_Version_1()
        {
            var message = "{\"stat\":null}";
            var serializer = new PicocellPacketSerializer();
            var protocolVersion = 1;
            var result = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion);

            Assert.Null(result.Rxpk);
            Assert.Null(result.Stat);
        }

        [Fact]
        public void Can_Deserialize_PUSH_DATA_empty_object_Version_1()
        {
            var message = "{}";
            var serializer = new PicocellPacketSerializer();
            var protocolVersion = 1;
            var result = new JsonPacketPayloadSerializer().Deserialize<PushDataPacketPayload>(message, protocolVersion);

            Assert.Null(result.Rxpk);
            Assert.Null(result.Stat);
        }
    }
}

using System;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class PicocellDeserializeException : Exception
    {
        public byte[] Buffer { get; private set; }

        public PicocellDeserializeException(string message, byte[] buffer, Exception innerException) : base(message, innerException)
        {
            Buffer = buffer;
        }
    }
}

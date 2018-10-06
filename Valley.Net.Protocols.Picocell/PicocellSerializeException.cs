using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell
{
    public sealed class PicocellSerializeException : Exception
    {
        public PicocellSerializeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}

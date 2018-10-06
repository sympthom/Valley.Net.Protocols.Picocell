using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valley.Net.Protocols.Picocell
{
    public static class ByteExtensions
    {
        public static string ToHex(this byte[] source, string separator = " ")
        {
            return source != null ? string.Join(separator, source.Select(x => x.ToString("x2"))) : null;
        }
    }
}

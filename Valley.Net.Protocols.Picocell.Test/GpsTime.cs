using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Test
{
    internal static class GpsTime
    {
        public static long Time => (long)DateTime.UtcNow.Subtract(new DateTime(1980, 1, 6, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
    }
}

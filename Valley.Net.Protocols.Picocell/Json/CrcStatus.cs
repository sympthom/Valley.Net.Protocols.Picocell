using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valley.Net.Protocols.Picocell.Json
{
    public enum CrcStatus : short
    {
        Fail = -1,
        NoCrc = 0,
        OK = 1
    }
}

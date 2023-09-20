using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models;

public class IpAddress : BaseAddress
{
    public IpAddress(byte[] octets)
    {
        Octets = octets;
    }

    public IpAddress(string octets)
    {
        Octets = OctetsStringToByteArray(octets);
    }
}

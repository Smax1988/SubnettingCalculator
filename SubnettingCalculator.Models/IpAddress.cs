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

    public static IpAddress operator &(IpAddress ipAddress, SubnetMask subnetMask)
    {
        byte[] result = new byte[4];

        for (int i = 0; i < 4;  i++)
        {
            result[i] = (byte)(ipAddress.Octets[i] & subnetMask.Octets[i]);
        }
        return new IpAddress(result);
    }

    public static IpAddress operator |(IpAddress ipAddress, SubnetMask subnetMask)
    {
        byte[] result = new byte[4];

        for (int i = 0; i < 4; i++)
        {
            result[i] = (byte)(ipAddress.Octets[i] | subnetMask.Octets[i]);
        }
        return new IpAddress(result);
    }
}

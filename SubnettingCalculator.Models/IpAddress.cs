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

    public static IpAddress operator +(IpAddress netId, int value)
    {
        byte[] result = new byte[netId.Octets.Length];

        for (int i = 0; i < 4; i++)
        {
            if (i == netId.Octets.Length - 1)
                result[i] = (byte)(netId.Octets[i] + value);
            else
                result[i] = (byte)netId.Octets[i];
        }
        return new IpAddress(result);
    }

    public static IpAddress operator -(IpAddress broadCastAddress, int value)
    {
        byte[] result = new byte[4];

        for (int i = 0; i < broadCastAddress.Octets.Length; i++)
        {
            if (i == broadCastAddress.Octets.Length - 1)
                result[i] = (byte)(broadCastAddress.Octets[i] - value);
            else
                result[i] = (byte)broadCastAddress.Octets[i];
        }
        return new IpAddress(result);
    }
}

﻿using System.Text.RegularExpressions;

namespace SubnettingCalculator.Models;

public class SubnetMask : BaseAddress
{
    public int CidrSuffix { get; private set; }

    public SubnetMask() {}

    public SubnetMask(byte[] octets)
    {
        Octets = octets;
        CidrSuffix = GetCidrSuffix(octets);
    }

    public SubnetMask(string octets)
    {
        Octets = OctetsStringToByteArray(octets);
        CidrSuffix = GetCidrSuffix(Octets);
    }

    public SubnetMask(int cidrSuffix)
    {
        Octets = ConvertCidrSuffixToOctets(cidrSuffix);
        CidrSuffix = cidrSuffix;
    }

    public static int GetCidrSuffix(byte[] octets)
    {
        string binaryOctets = string.Empty;

        for (int i = 0; i < octets.Length; i++)
        {
            binaryOctets += Convert.ToString(octets[i], 2);
        }

        string pattern = @"01";
        MatchCollection matches = Regex.Matches(binaryOctets, pattern);


        int count = 0;
        foreach (char character in binaryOctets)
        {
            if (character == '1')
                count++;
        }

        return count;
    }

    public byte[] ConvertCidrSuffixToOctets(int cidrSuffix)
    {
        // construct the binary string:
        string binarySuffix = string.Empty;

        // as many '1's as cidrSuffix
        for (int i = 0; i < cidrSuffix; i++)
        {
            binarySuffix += "1";
        }
        // fill up with '0's till string length is 32
        for (int i = 0; i< 32-cidrSuffix; i++)
        {
            binarySuffix += "0";
        }

        // convert binary string to byte[]:
        byte[] result = new byte[4];

        for(int i = 0; i < 4; ++i)
        {
            result[i] = Convert.ToByte(binarySuffix.Substring(8 * i, 8), 2);
        }

        return result;
    }
}
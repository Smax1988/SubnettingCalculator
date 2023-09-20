﻿namespace SubnettingCalculator.Models;

public abstract class BaseAddress
{
    public byte[] Octets { get; protected set; } = new byte[4];

    protected byte[] OctetsStringToByteArray(string octets)
    {
        string[] octetsStrings = octets.Split('.');
        byte[] result = new byte[4];

        if (octetsStrings.Length != 4) 
            throw new ArgumentOutOfRangeException(nameof(octetsStrings));

        for (int i = 0; i < octetsStrings.Length; i++)
        {
            result[i] = byte.Parse(octetsStrings[i]);
        }
        return result;
    }
}
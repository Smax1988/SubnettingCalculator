namespace SubnettingCalculator.Models;

public class SubnetMask : BaseAddress
{
    public int Suffix { get; private set; }

    public SubnetMask() {}

    public SubnetMask(byte[] octets)
    {
        Octets = octets;
        Suffix = GetSuffix(octets);
    }

    public SubnetMask(string octets)
    {
        Octets = OctetsStringToByteArray(octets);
        Suffix = GetSuffix(Octets);
    }

    public int GetSuffix(byte[] octets)
    {
        string binaryOctets = string.Empty;

        for (int i = 0; i < octets.Length; i++)
        {
            binaryOctets += Convert.ToString(octets[i], 2);
        }

        int count = 0;
        foreach (char character in binaryOctets)
        {
            if (character == '1')
                count++;
        }

        return count;
    }
}

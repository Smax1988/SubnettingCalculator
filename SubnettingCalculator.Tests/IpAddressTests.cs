namespace SubnettingCalculator.Models.Tests;

[TestFixture]
public class IpAddressTests
{
    [TestCase(new byte[] { 192, 160, 0, 0 }, new byte[] { 192, 160, 0, 0 })]
    [TestCase(new byte[] { 193, 162, 1, 1 }, new byte[] { 193, 162, 1, 1 })]
    [TestCase(new byte[] { 194, 163, 2, 2 }, new byte[] { 194, 163, 2, 2 })]
    [TestCase(new byte[] { 195, 164, 3, 3 }, new byte[] { 195, 164, 3, 3 })]
    [TestCase(new byte[] { 196, 165, 4, 4 }, new byte[] { 196, 165, 4, 4 })]
    [TestCase(new byte[] { 197, 166, 5, 5 }, new byte[] { 197, 166, 5, 5 })]
    [TestCase(new byte[] { 198, 167, 6, 6 }, new byte[] { 198, 167, 6, 6 })]
    [TestCase(new byte[] { 199, 168, 7, 7 }, new byte[] { 199, 168, 7, 7 })]
    [TestCase(new byte[] { 190, 169, 8, 8 }, new byte[] { 190, 169, 8, 8 })]
    public void IpAdressTest(byte[] inputIpAddress, byte[] expected)
    {
        IpAddress ipAdress = new IpAddress(inputIpAddress);

        byte[] bytes = new byte[] { 192, 168, 10, 10 };

        Assert.That(ipAdress.Octets, Is.EqualTo(expected));
    }

    [TestCase("192.168.2.1", new byte[] { 192, 168, 2, 1 })]
    [TestCase("89.13.4.2", new byte[] { 89, 13, 4, 2 })]
    [TestCase("172.128.50.2", new byte[] { 172, 128, 50, 2 })]
    [TestCase("112.18.53.12", new byte[] { 112, 18, 53, 12 })]
    [TestCase("10.10.05.07", new byte[] { 10, 10, 5, 7 })]
    public void OctetsStringToByteArrayTest(string inputOctet, byte[] expected)
    {
        IpAddress ipAddress = new IpAddress(inputOctet);

        Assert.That(ipAddress.Octets, Is.EqualTo(expected));
    }

    [TestCase("1.1.1")]
    [TestCase("1.1.1.1.1.1")]
    public void OctetsStringToByteArray_ThrowsException(string input)
    {
        IpAddress ipAddress;

        Assert.Throws<ArgumentOutOfRangeException>(() => ipAddress = new IpAddress(input));
    }
}
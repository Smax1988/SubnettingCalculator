using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models.Tests
{
    [TestFixture]
    public class NetworkTests
    {
        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, new byte[] { 192, 168, 0, 0 })]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, new byte[] { 172, 0, 0, 0 })]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, new byte[] { 85, 45, 10, 0 })]

        public void NetIdTest(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.NetworkId.Octets));
        }

        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, new byte[] { 255, 255, 255, 0 })]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, new byte[] { 255, 0, 0, 0 })]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, new byte[] { 255, 255, 255, 240 })]
        public void SubnetMaskTest(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.SubnetMask.Octets));
        }

        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, new byte[] { 192, 168, 0, 255 })]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, new byte[] { 172, 255, 255, 255 })]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, new byte[] { 85, 45, 10, 15 })]
        public void BroadCastAddressTest(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.BroadCastAddress.Octets));
        }

        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, new byte[] { 192, 168, 0, 1 })]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, new byte[] { 172, 0, 0, 1 })]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, new byte[] { 85, 45, 10, 1 })]
        public void FirstHostTest(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.FirstHost.Octets));
        }

        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, new byte[] { 192, 168, 0, 254 })]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, new byte[] { 172, 255, 255, 254 })]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, new byte[] { 85, 45, 10, 14 })]
        public void LastHostTest(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.LastHost.Octets));
        }

        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 }, 254)]
        [TestCase(new byte[] { 172, 30, 50, 1 }, new byte[] { 255, 0, 0, 0 }, 16777214)]
        [TestCase(new byte[] { 85, 45, 10, 0 }, new byte[] { 255, 255, 255, 240 }, 14)]
        public void NumberOfHostsTest(byte[] ipAddress, byte[] subnetMask, int expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.NumberOfHosts));
        }
    }
}

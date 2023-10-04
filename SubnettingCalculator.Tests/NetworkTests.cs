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
        public void NetworkId_IsCorrec(byte[] ipAddress, byte[] subnetMask, byte[] expected)
        {
            IpAddress ip = new IpAddress(ipAddress);
            SubnetMask snm = new SubnetMask(subnetMask);
            Network network = new Network(ip, snm);

            Assert.That(expected, Is.EqualTo(network.NetworkId.Octets));
        }
    }
}

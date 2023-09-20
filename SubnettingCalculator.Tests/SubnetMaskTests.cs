using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models.Tests
{
    [TestFixture]
    public class SubnetMaskTests
    {
        SubnetMask subnetMask = new SubnetMask();

        [TestCase(new byte[] { 255, 255, 255, 0 }, 24)]
        [TestCase(new byte[] { 255, 255, 0, 0 }, 16)]
        [TestCase(new byte[] { 255, 255, 255, 254 }, 31)]
        public void Should_GetSuffix(byte[] inputOctets, int expected)
        {
            var result = subnetMask.GetSuffix(inputOctets);

            Assert.That(result, Is.EqualTo(expected));
        }


    }
}

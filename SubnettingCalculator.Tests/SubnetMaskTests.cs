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
        private readonly SubnetMask SubnetMask = new SubnetMask();

        [TestCase(new byte[] { 255, 255, 255, 0 }, 24)]
        [TestCase(new byte[] { 255, 255, 0, 0 }, 16)]
        [TestCase(new byte[] { 255, 255, 255, 254 }, 31)]
        public void Should_GetCidrSuffix(byte[] inputOctets, int expected)
        {
            var result = SubnetMask.GetCidrSuffix(inputOctets);
            SubnetMask subnetMask = new SubnetMask(inputOctets);

            Assert.That(subnetMask.CidrSuffix, Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 255, 254, 255, 0 })]
        [TestCase(new byte[] { 254, 255, 255, 0 })]
        [TestCase(new byte[] { 250, 245, 255, 0 })]
        public void GetCidrSuffix_ThrowsArgumentOutOfRangeException(byte[] inputOctet)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SubnetMask.GetCidrSuffix(inputOctet));
        }


        [TestCase(30, new byte[] { 255, 255, 255, 252 })]
        [TestCase(24, new byte[] { 255, 255, 255, 0 })]
        [TestCase(16, new byte[] { 255, 255, 0, 0 })]
        [TestCase(25, new byte[] { 255, 255, 255, 128 })]
        [TestCase(1, new byte[] { 128, 0, 0, 0 })]
        [TestCase(0, new byte[] { 0, 0, 0, 0 })]
        public void Should_ConvertCidrSuffixToOctets(int cidrSuffix, byte[] expected)
        {
            var result = SubnetMask.ConvertCidrSuffixToOctets(cidrSuffix);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(50)]
        [TestCase(31)]
        [TestCase(0)]
        [TestCase(-8)]
        public void ConvertCidrSuffixToOctets_ThrowsArgumentOutOfRangeException(int cidrSuffix)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SubnetMask.ConvertCidrSuffixToOctets(cidrSuffix));
        }
    }
}

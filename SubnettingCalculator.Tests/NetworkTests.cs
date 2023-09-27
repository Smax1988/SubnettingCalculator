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
        [TestCase(new byte[] { 192, 168, 0, 1 }, new byte[] { 255, 255, 255, 0 })]
        public void Should_CalcNetId(byte[] ipAddress, byte[] subnetMask)
        {
            var result = 
        }
    }
}

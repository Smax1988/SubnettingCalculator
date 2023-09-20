using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models
{
    public class SubnetMask : BaseAddress
    {
        int Suffix { get; set; }

        public SubnetMask(byte[] octets)
        {
            Octets = octets;
        }

        public SubnetMask(string octets)
        {
            Octets = OctetsStringToByteArray(octets);
        }
    }
}

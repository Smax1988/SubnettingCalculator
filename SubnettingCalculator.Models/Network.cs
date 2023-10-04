using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models
{
    public class Network
    {
        public IpAddress NetworkId { get; set; }

        public SubnetMask SubnetMask { get; set; }

        public IpAddress FirstHost { get; set; }

        public IpAddress LastHost { get; set; }

        public IpAddress BroadCastAddress { get; set; }

        public int NumberOfHosts {  get; set; }

        public Network(IpAddress ipAddress, SubnetMask subnetMask)
        {
            NetworkId = ipAddress & subnetMask;
            SubnetMask = subnetMask;
            BroadCastAddress = NetworkId | ~SubnetMask;
            FirstHost = NetworkId + 1;
            LastHost = BroadCastAddress - 1;
            NumberOfHosts = (int)(Math.Pow(2, 32 - SubnetMask.CidrSuffix) - 2);
        }
    }
}

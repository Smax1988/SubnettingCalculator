using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models
{
    public class Network
    {
        public IpAddress IpAddress { get; init; }

        public SubnetMask SubnetMask { get; init; }

        public IpAddress NetworkId { get; init; }

        public IpAddress FirstHost { get; init; }

        public IpAddress LastHost { get; init; }

        public IpAddress BroadCastAddress { get; init; }

        public int NumberOfHosts {  get; init; }

        public Network(IpAddress ipAddress, SubnetMask subnetMask)
        {
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
            NetworkId = ipAddress & subnetMask;
            BroadCastAddress = NetworkId | ~SubnetMask;
            FirstHost = NetworkId + 1;
            LastHost = BroadCastAddress - 1;
            NumberOfHosts = (int)(Math.Pow(2, 32 - SubnetMask.CidrSuffix) - 2);
        }
    }
}

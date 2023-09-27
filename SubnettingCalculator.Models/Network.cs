using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.Models
{
    public class Network
    {
        public byte[] NetworkId { get; set; }

        public byte[] FirstHost { get; set; }

        public byte[] LastHost { get; set; }

        public byte[] BroadCastAddress { get; set; }

        public int NumberOfHosts {  get; set; }

        public byte[] SubnetMask { get; set; }

        public Network(IpAddress ipAddress, SubnetMask subnetMask)
        {
            NetworkId = CalcNetId(ipAddress.Octets, subnetMask.Octets);
            BroadCastAddress = CalcBca(ipAddress.Octets, subnetMask.Octets);
            FirstHost = CalcFirstHost(NetworkId);
            LastHost = CalcLastHost(BroadCastAddress);
            NumberOfHosts = CalcNumberOfHosts();
            SubnetMask = subnetMask.Octets;
        }

        private byte[] CalcNetId(byte[] ipAdress, byte[] subnetMask)
        {
            byte[] netId = new byte[4];

            for (int i = 0; i < ipAdress.Length; i++)
            {
                netId[i] = Convert.ToByte(ipAdress[i] & subnetMask[i]);
            }

            return netId;
        }

        private byte[] CalcBca(byte[] ipAdress, byte[] subnetMask)
        {
            throw new NotImplementedException();
        }

        private byte[] CalcFirstHost(byte[] networkId)
        {
            throw new NotImplementedException();
        }

        private byte[] CalcLastHost(byte[] broadcastAddress)
        {
            throw new NotImplementedException();
        }

        private int CalcNumberOfHosts()
        {
            throw new NotImplementedException();
        }
    }
}

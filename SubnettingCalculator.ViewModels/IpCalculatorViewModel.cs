using SubnettingCalculator.Models;
using SubnettingCalculator.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingCalculator.ViewModels
{
    public class IpCalculatorViewModel : ObservableObject
    {

        private Network _network;

        public Network Network
        {
            get { return _network; }
            set
            {
                _network = value;
                OnPropertyChanged();
            }
        }

        //    private IpAddress _ipAddress;

        //    public IpAddress IpAddress
        //    {
        //        get { return _ipAddress; }
        //        set 
        //        { 
        //            _ipAddress = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private SubnetMask _subnetMask;

        //    public SubnetMask MyProperty
        //    {
        //        get { return _subnetMask; }
        //        set 
        //        { 
        //            _subnetMask = value; 
        //            OnPropertyChanged();
        //        }
        //    }

        //    private IpAddress _broadcastAddress;

        //    public IpAddress BroadcastAddress
        //    {
        //        get { return _broadcastAddress; }
        //        set 
        //        { 
        //            _broadcastAddress = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private IpAddress _firstHost;

        //    public IpAddress FirstHost
        //    {
        //        get { return _firstHost; }
        //        set 
        //        { 
        //            _firstHost = value; 
        //            OnPropertyChanged();
        //        }
        //    }

        //    private IpAddress _lastHost;

        //    public IpAddress LastHost
        //    {
        //        get { return _lastHost; }
        //        set 
        //        { 
        //            _lastHost = value; 
        //            OnPropertyChanged();
        //        }
        //    }

        //    private IpAddress _netId;

        //    public IpAddress NetId
        //    {
        //        get { return _netId; }
        //        set 
        //        { 
        //            _netId = value; 
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int _numberOfHosts;

        //    public int NumberOfHosts
        //    {
        //        get { return _numberOfHosts; }
        //        set 
        //        { 
        //            _numberOfHosts = value; 
        //            OnPropertyChanged();
        //        }
        //    }
        //}
    }
}

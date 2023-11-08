using SubnettingCalculator.Models;
using SubnettingCalculator.ViewModels.Core;

namespace SubnettingCalculator.ViewModels;

public class IpCalculatorViewModel : ObservableObject
{
    private bool _snmWarning = false;
    private bool _ipWarning = false;
    private bool _sfxWarning = false;
    private string _warning = string.Empty;
    private int _cidrSuffix;
    private string _ipAddress;
    private string _subnetMask;
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

    public string IpAddress
    {
        get { return _ipAddress; }
        set 
        {
            _ipAddress = value;
            try
            {
                Network = new Network(new IpAddress(IpAddress), new SubnetMask(SubnetMask));
                _ipWarning = false;
            }
            catch (Exception)
            {
                if (!_ipWarning) 
                    Warning += "Ungültige IP Adresse. \r\n";
                _ipWarning = true;
            }

            if (!_ipWarning && !_snmWarning && !_sfxWarning)
                Warning = string.Empty;

            OnPropertyChanged();
        }
    }

    public string SubnetMask
    {
        get { return _subnetMask; }
        set 
        {
            if (_subnetMask == value) return;
            _subnetMask = value;

            try
            {
                Network = new Network(new IpAddress(IpAddress), new SubnetMask(SubnetMask));
                CidrSuffix = Network.SubnetMask.CidrSuffix;
                _snmWarning = false;
            }
            catch (Exception)
            {
                if (!_snmWarning) 
                    Warning += "Ungültige Subnetzmaske. \r\n";
                _snmWarning = true;
            }

            if (!_snmWarning && !_ipWarning && !_sfxWarning) 
                Warning = string.Empty;

            OnPropertyChanged(); 
        }
    }


    public int CidrSuffix
    {
        get { return _cidrSuffix; }
        set 
        {
            if (value == _cidrSuffix) return;
            _cidrSuffix = value;

            try
            {
                Network = new Network(new IpAddress(_ipAddress), new SubnetMask(_cidrSuffix));
                SubnetMask = Network.SubnetMask.ToString();
                _sfxWarning = false;
            }
            catch (Exception)
            {
                if (!_sfxWarning)
                    Warning += "Ungültiges Cidr Suffix. Suffix muss mindestens 1 und höchsten 31 sein. \r\n";
                _sfxWarning = true;
            }

            if (!_sfxWarning && !_ipWarning && _snmWarning)
                Warning = string.Empty;

            OnPropertyChanged();
        }
    }

    public IpCalculatorViewModel()
    {
        _ipAddress = "192.168.15.0";
        _cidrSuffix = 24;
        _network = new Network(new IpAddress(IpAddress), new SubnetMask(CidrSuffix));
        _subnetMask = Network.SubnetMask.ToString();
    }

    public string Warning
    {
        get { return _warning;  }
        set
        {
            _warning = value;
            OnPropertyChanged();
        }
    }
}

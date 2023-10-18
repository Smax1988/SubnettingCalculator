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
    }
}

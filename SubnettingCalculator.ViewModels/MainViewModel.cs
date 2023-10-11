using SubnettingCalculator.ViewModels.Core;

namespace SubnettingCalculator.ViewModels;

public class MainViewModel : ObservableObject
{
    public RelayCommand IpCalculatorViewCommand { get; set; }
    public RelayCommand SubnettingViewCommand { get; set; }
    public IpCalculatorViewModel IpCalculatorViewModel { get; set; }
    public SubnettingViewModel SubnettingViewModel { get; set; }

    private object _currentView;

	public object CurrentView
	{
		get { return _currentView; }
		set 
        { 
            _currentView = value;
            OnPropertyChanged();
        }
	}

    public MainViewModel()
    {
        IpCalculatorViewModel = new IpCalculatorViewModel();
        SubnettingViewModel = new SubnettingViewModel();

        CurrentView = IpCalculatorViewModel;

        IpCalculatorViewCommand = new RelayCommand(x => 
        {
            CurrentView = IpCalculatorViewModel;
        });

        SubnettingViewCommand = new RelayCommand(x =>
        {
            CurrentView = SubnettingViewModel;
        });
    }
}
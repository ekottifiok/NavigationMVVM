using System.Windows.Input;
using Ch07NavigationMVVM.Commands;
using Ch07NavigationMVVM.Services;

namespace Ch07NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService navigationService)
    {
        NavigateLoginCommand = new NavigateCommand(navigationService);
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
using System.Windows.Input;
using Ch09NavigationMVVM.Commands;
using Ch09NavigationMVVM.Services;

namespace Ch09NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService navigationService)
    {
        NavigateLoginCommand = new NavigateCommand(navigationService);
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
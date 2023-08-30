using System.Windows.Input;
using Ch08NavigationMVVM.Commands;
using Ch08NavigationMVVM.Services;

namespace Ch08NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService navigationService)
    {
        NavigateLoginCommand = new NavigateCommand(navigationService);
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
using System.Windows.Input;
using Ch05NavigationMVVM.Commands;
using Ch05NavigationMVVM.Services;

namespace Ch05NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService<LoginViewModel> navigationService)
    {
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationService);
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
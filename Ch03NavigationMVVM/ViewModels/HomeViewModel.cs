using System.Windows.Input;
using Ch03NavigationMVVM.Commands;
using Ch03NavigationMVVM.Services;
using Ch03NavigationMVVM.Stores;

namespace Ch03NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(NavigationStore navigationStore, AccountStore accountStore)
    {
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
            new NavigationService<LoginViewModel>(
                navigationStore, () => new LoginViewModel(navigationStore, accountStore)));
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
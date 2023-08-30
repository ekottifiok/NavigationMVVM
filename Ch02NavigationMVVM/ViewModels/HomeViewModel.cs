using System.Windows.Input;
using Ch02NavigationMVVM.Commands;
using Ch02NavigationMVVM.Services;
using Ch02NavigationMVVM.Stores;

namespace Ch02NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(NavigationStore navigationStore)
    {
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
            new NavigationService<LoginViewModel>(
                navigationStore, () => new LoginViewModel(navigationStore)));
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}
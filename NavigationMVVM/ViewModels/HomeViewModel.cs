using System.Windows.Input;
using NavigationMVVM.Commands;
using NavigationMVVM.Stores;

namespace NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(NavigationStore navigationStore)
    {
        NavigateAccountCommand = new NavigateCommand<AccountViewModel>(
            navigationStore, () => new AccountViewModel(navigationStore));
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateAccountCommand { get; }
    
}
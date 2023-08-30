using System.Windows.Input;
using NavigationMVVM.Commands;
using NavigationMVVM.Stores;

namespace NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{
    public AccountViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(
            navigationStore, () => new HomeViewModel(navigationStore));
    }

    public string WelcomeMessage => "SingletonSean";
    public ICommand NavigateHomeCommand { get; }
}
using System.Windows.Input;
using Ch02NavigationMVVM.Commands;
using Ch02NavigationMVVM.Services;
using Ch02NavigationMVVM.Stores;

namespace Ch02NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{
    public AccountViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(
            new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
    }

    public string WelcomeMessage => "SingletonSean";
    public ICommand NavigateHomeCommand { get; }
}
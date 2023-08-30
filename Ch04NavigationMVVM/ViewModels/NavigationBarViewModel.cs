using System.Windows.Input;
using Ch04NavigationMVVM.Commands;
using Ch04NavigationMVVM.Services;
using Ch04NavigationMVVM.Stores;

namespace Ch04NavigationMVVM.ViewModels;

public class NavigationBarViewModel : ViewModelBase
{
    public NavigationBarViewModel(AccountStore accountStore,
        NavigationService<AccountViewModel> accountNavigationService,
        NavigationService<HomeViewModel> homeNavigationService,
        NavigationService<LoginViewModel> loginNavigationService)
    {
        _accountStore = accountStore;
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
    }

    private readonly AccountStore _accountStore;
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateLoginCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public bool IsLoggedIn => _accountStore.IsLoggedIn;
}
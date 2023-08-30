using System.Windows.Input;
using Ch05NavigationMVVM.Commands;
using Ch05NavigationMVVM.Services;
using Ch05NavigationMVVM.Stores;

namespace Ch05NavigationMVVM.ViewModels;

public class NavigationBarViewModel : ViewModelBase
{
    public NavigationBarViewModel(AccountStore accountStore,
        INavigationService<AccountViewModel> accountNavigationService,
        INavigationService<HomeViewModel> homeNavigationService,
        INavigationService<LoginViewModel> loginNavigationService)
    {
        _accountStore = accountStore;
        _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        LogoutCommand = new LogoutCommand(_accountStore);
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
    }

    private void OnCurrentAccountChanged() => OnPropertyChanged(nameof(IsLoggedIn));

    public override void Dispose()
    {
        _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
        base.Dispose();
    }

    private readonly AccountStore _accountStore;
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateLoginCommand { get; }
    public ICommand LogoutCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public bool IsLoggedIn => _accountStore.IsLoggedIn;
    public bool IsNotLoggedIn => !_accountStore.IsLoggedIn;
}
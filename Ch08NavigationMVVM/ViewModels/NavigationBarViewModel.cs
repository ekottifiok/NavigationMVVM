using System.Windows.Input;
using Ch08NavigationMVVM.Commands;
using Ch08NavigationMVVM.Services;
using Ch08NavigationMVVM.Stores;

namespace Ch08NavigationMVVM.ViewModels;

public class NavigationBarViewModel : ViewModelBase
{
    public NavigationBarViewModel(AccountStore accountStore,
        INavigationService accountNavigationService,
        INavigationService homeNavigationService,
        INavigationService loginNavigationService)
    {
        _accountStore = accountStore;
        _accountStore.CurrentAccountChanged += () => OnPropertyChanged(nameof(IsLoggedIn));;
        LogoutCommand = new LogoutCommand(_accountStore);
        NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        NavigateAccountCommand = new NavigateCommand(accountNavigationService);
    }

    public override void Dispose()
    {
        _accountStore.CurrentAccountChanged -= () => OnPropertyChanged(nameof(IsLoggedIn));;
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
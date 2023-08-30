using System.Windows.Input;
using Ch09NavigationMVVM.Commands;
using Ch09NavigationMVVM.Services;
using Ch09NavigationMVVM.Stores;

namespace Ch09NavigationMVVM.ViewModels;

public class NavigationBarViewModel : ViewModelBase
{
    public NavigationBarViewModel(AccountStore accountStore,
        INavigationService accountNavigationService,
        INavigationService homeNavigationService,
        INavigationService loginNavigationService,
        INavigationService peopleNavigationService)
    {
        _accountStore = accountStore;
        _accountStore.CurrentAccountChanged += SubscribeToEvents;
        LogoutCommand = new LogoutCommand(_accountStore);
        NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        NavigateAccountCommand = new NavigateCommand(accountNavigationService);
        NavigatePeopleListingCommand = new NavigateCommand(peopleNavigationService);
    }
    
    private void SubscribeToEvents() => OnPropertyChanged(nameof(IsLoggedIn));

    public override void Dispose()
    {
        _accountStore.CurrentAccountChanged -= SubscribeToEvents;
        base.Dispose();
    }

    private readonly AccountStore _accountStore;
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateLoginCommand { get; }
    public ICommand LogoutCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public ICommand NavigatePeopleListingCommand { get; }
    public bool IsLoggedIn => _accountStore.IsLoggedIn;
    public bool IsNotLoggedIn => !_accountStore.IsLoggedIn;
}
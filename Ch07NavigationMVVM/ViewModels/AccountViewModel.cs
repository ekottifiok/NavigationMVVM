using System.Windows.Input;
using Ch07NavigationMVVM.Commands;
using Ch07NavigationMVVM.Services;
using Ch07NavigationMVVM.Stores;

namespace Ch07NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{ 
    public AccountViewModel(AccountStore accountStore, 
        INavigationService navigationService)
    {
        _account = accountStore;
        NavigateHomeCommand = new NavigateCommand(navigationService);
        _account.CurrentAccountChanged += OnCurrentAccountChanged;
    }

    private void OnCurrentAccountChanged()
    {
        OnPropertyChanged(nameof(Email));
        OnPropertyChanged(nameof(Username));
    }

    public override void Dispose()
    {
        _account.CurrentAccountChanged -= OnCurrentAccountChanged;
        base.Dispose();
    }

    private readonly AccountStore _account;

    public string? Email => _account.CurrentAccount?.Email;
    public string? Username => _account.CurrentAccount?.Username;
    public ICommand NavigateHomeCommand { get; }
}
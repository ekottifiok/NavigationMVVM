using System.Windows.Input;
using Ch05NavigationMVVM.Commands;
using Ch05NavigationMVVM.Services;
using Ch05NavigationMVVM.Stores;

namespace Ch05NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{ 
    public AccountViewModel(AccountStore accountStore, 
        INavigationService<HomeViewModel> navigationService)
    {
        _account = accountStore;
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationService);
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
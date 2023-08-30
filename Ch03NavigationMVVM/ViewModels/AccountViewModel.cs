using System.Windows.Input;
using Ch03NavigationMVVM.Commands;
using Ch03NavigationMVVM.Models;
using Ch03NavigationMVVM.Services;
using Ch03NavigationMVVM.Stores;

namespace Ch03NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{ 
    public AccountViewModel( NavigationStore navigationStore, AccountStore accountStore)
    {
        _account = accountStore;
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(
            new NavigationService<HomeViewModel>(navigationStore, 
                () => new HomeViewModel(navigationStore, accountStore)));
    }
    private readonly AccountStore _account;

    public string Email => _account.CurrentAccount?.Email;
    public string Username => _account.CurrentAccount?.Username;
    public ICommand NavigateHomeCommand { get; }
}
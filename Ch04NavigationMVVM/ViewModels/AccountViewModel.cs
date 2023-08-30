using System.Windows.Input;
using Ch04NavigationMVVM.Commands;
using Ch04NavigationMVVM.Services;
using Ch04NavigationMVVM.Stores;

namespace Ch04NavigationMVVM.ViewModels;

public class AccountViewModel : ViewModelBase
{ 
    public AccountViewModel(AccountStore accountStore, 
        NavigationBarViewModel navigationBarViewModel, 
        NavigationService<HomeViewModel> navigationService)
    {
        _account = accountStore;
        NavigationBarViewModel = navigationBarViewModel;
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationService);
    }
    private readonly AccountStore _account;
    public NavigationBarViewModel NavigationBarViewModel { get; }

    public string Email => _account.CurrentAccount?.Email;
    public string Username => _account.CurrentAccount?.Username;
    public ICommand NavigateHomeCommand { get; }
}
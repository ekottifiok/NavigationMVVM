using System.Windows.Input;
using Ch03NavigationMVVM.Commands;
using Ch03NavigationMVVM.Models;
using Ch03NavigationMVVM.Services;
using Ch03NavigationMVVM.Stores;

namespace Ch03NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public LoginViewModel(NavigationStore navigationStore, AccountStore accountStore)
    {
        _username = _password = "";
        NavigationService<AccountViewModel> navigationService =
            new NavigationService<AccountViewModel>(
                navigationStore, 
                () => new AccountViewModel(navigationStore, accountStore));
        LoginCommand = new LoginCommand(this, accountStore, navigationService);
    }

    public ICommand LoginCommand { get; }
    public string Username
    {
        get => _username;
        set => SetField(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetField(ref _password, value);
    }
}
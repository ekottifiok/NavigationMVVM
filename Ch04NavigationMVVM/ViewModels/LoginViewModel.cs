using System.Windows.Input;
using Ch04NavigationMVVM.Commands;
using Ch04NavigationMVVM.Services;
using Ch04NavigationMVVM.Stores;

namespace Ch04NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public LoginViewModel(AccountStore accountStore, 
        NavigationService<AccountViewModel> navigationService)
    {
        _username = _password = "";
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
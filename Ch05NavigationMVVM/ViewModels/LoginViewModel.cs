using System.Windows.Input;
using Ch05NavigationMVVM.Commands;
using Ch05NavigationMVVM.Services;
using Ch05NavigationMVVM.Stores;

namespace Ch05NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public LoginViewModel(AccountStore accountStore, 
        INavigationService<AccountViewModel> navigationService)
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
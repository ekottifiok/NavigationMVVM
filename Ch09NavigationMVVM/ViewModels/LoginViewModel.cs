using System.Windows.Input;
using Ch09NavigationMVVM.Commands;
using Ch09NavigationMVVM.Services;
using Ch09NavigationMVVM.Stores;

namespace Ch09NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;
    public ICommand LoginCommand { get; }
    public LoginViewModel(AccountStore accountStore, 
        INavigationService navigationService)
    {
        _username = _password = "";
        LoginCommand = new LoginCommand(
            this, accountStore, navigationService);
    }
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
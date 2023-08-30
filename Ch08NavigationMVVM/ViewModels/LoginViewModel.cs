using System.Windows.Input;
using Ch08NavigationMVVM.Commands;
using Ch08NavigationMVVM.Services;
using Ch08NavigationMVVM.Stores;

namespace Ch08NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public LoginViewModel(AccountStore accountStore, 
        INavigationService navigationService)
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
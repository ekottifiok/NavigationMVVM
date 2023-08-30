using System.Windows.Input;
using Ch02NavigationMVVM.Commands;
using Ch02NavigationMVVM.Services;
using Ch02NavigationMVVM.Stores;

namespace Ch02NavigationMVVM.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public LoginViewModel(NavigationStore navigationStore)
    {
        _username = "";
        _password = "";
        LoginCommand = new NavigateCommand<AccountViewModel>(
            new NavigationService<AccountViewModel>(
                navigationStore, () => new AccountViewModel(navigationStore)));
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
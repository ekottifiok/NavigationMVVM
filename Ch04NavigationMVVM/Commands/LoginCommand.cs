using Ch04NavigationMVVM.Models;
using Ch04NavigationMVVM.Services;
using Ch04NavigationMVVM.Stores;
using Ch04NavigationMVVM.ViewModels;

namespace Ch04NavigationMVVM.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _viewModel;
    private readonly AccountStore _accountStore;
    private readonly NavigationService<AccountViewModel> _navigationService;

    public LoginCommand(LoginViewModel viewModel, AccountStore accountStore,
       NavigationService<AccountViewModel> navigationService)
    {
        _viewModel = viewModel;
        _accountStore = accountStore;
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        // Navigate to account page
        _accountStore.CurrentAccount = new Account()
        {
            Email = $"{_viewModel.Username}@test.com",
            Username = _viewModel.Username
        };
        _navigationService.Navigate();
    }
}
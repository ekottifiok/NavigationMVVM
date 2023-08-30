using Ch05NavigationMVVM.Models;
using Ch05NavigationMVVM.Services;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _viewModel;
    private readonly AccountStore _accountStore;
    private readonly INavigationService<AccountViewModel> _navigationService;

    public LoginCommand(LoginViewModel viewModel, AccountStore accountStore,
       INavigationService<AccountViewModel> navigationService)
    {
        _viewModel = viewModel;
        _accountStore = accountStore;
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        // Navigate to account page
        _accountStore.SetCurrentAccount(new Account()
        {
            Email = $"{_viewModel.Username}@test.com",
            Username = _viewModel.Username
        });
        _navigationService.Navigate();
    }
}
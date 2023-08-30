using Ch07NavigationMVVM.Models;
using Ch07NavigationMVVM.Services;
using Ch07NavigationMVVM.Stores;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _viewModel;
    private readonly AccountStore _accountStore;
    private readonly INavigationService _navigationService;

    public LoginCommand(LoginViewModel viewModel, AccountStore accountStore,
       INavigationService navigationService)
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
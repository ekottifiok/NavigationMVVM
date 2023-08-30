using Ch08NavigationMVVM.Models;
using Ch08NavigationMVVM.Services;
using Ch08NavigationMVVM.Stores;
using Ch08NavigationMVVM.ViewModels;

namespace Ch08NavigationMVVM.Commands;

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
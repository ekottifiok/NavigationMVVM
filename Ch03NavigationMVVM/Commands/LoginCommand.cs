using System.Windows;
using Ch03NavigationMVVM.Models;
using Ch03NavigationMVVM.Services;
using Ch03NavigationMVVM.Stores;
using Ch03NavigationMVVM.ViewModels;

namespace Ch03NavigationMVVM.Commands;

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
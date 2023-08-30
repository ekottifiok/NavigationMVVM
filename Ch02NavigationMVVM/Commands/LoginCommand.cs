using System.Windows;
using Ch02NavigationMVVM.Services;
using Ch02NavigationMVVM.Stores;
using Ch02NavigationMVVM.ViewModels;

namespace Ch02NavigationMVVM.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _viewModel;
    private readonly NavigationService<AccountViewModel> _navigationService;

    public LoginCommand(LoginViewModel viewModel, NavigationService<AccountViewModel> navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        MessageBox.Show($"Logging in {_viewModel.Username}");
        // Navigate to account page
        _navigationService.Navigate();
    }
}
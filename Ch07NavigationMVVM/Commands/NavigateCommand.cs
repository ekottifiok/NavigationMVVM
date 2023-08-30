using Ch07NavigationMVVM.Services;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Commands;

public class NavigateCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public NavigateCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter) => _navigationService.Navigate();
}
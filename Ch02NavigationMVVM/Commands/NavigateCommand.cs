using System;
using Ch02NavigationMVVM.Services;
using Ch02NavigationMVVM.Stores;
using Ch02NavigationMVVM.ViewModels;

namespace Ch02NavigationMVVM.Commands;

public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
{
    private readonly NavigationService<TViewModel> _navigationService;

    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter) => _navigationService.Navigate();
}
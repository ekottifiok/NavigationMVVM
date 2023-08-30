using System;
using Ch07NavigationMVVM.Stores;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Services;

public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public override void Navigate() => _navigationStore.SetCurrentViewModel(_createViewModel());
}
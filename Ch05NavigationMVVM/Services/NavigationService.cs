using System;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Services;

public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
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
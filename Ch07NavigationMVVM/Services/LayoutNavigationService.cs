using System;
using Ch07NavigationMVVM.Stores;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Services;

public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;
    private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

    public LayoutNavigationService(NavigationStore navigationStore, 
        Func<TViewModel> createViewModel, Func<NavigationBarViewModel> navigationBarViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
        _createNavigationBarViewModel = navigationBarViewModel;
    }

    public override void Navigate() =>
        _navigationStore.SetCurrentViewModel(new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel()));
}
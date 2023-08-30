using System;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Services;

public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
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
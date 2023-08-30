using System;
using Ch04NavigationMVVM.Stores;
using Ch04NavigationMVVM.ViewModels;

namespace Ch04NavigationMVVM.Services;

public class NavigationService<TViewModel> where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate() => _navigationStore.SetCurrentViewModel(_createViewModel());
}
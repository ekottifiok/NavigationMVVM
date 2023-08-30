using System;
using Ch03NavigationMVVM.Stores;
using Ch03NavigationMVVM.ViewModels;

namespace Ch03NavigationMVVM.Services;

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
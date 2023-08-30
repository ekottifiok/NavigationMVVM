using System;
using Ch03NavigationMVVM.Stores;
using Ch03NavigationMVVM.ViewModels;

namespace Ch03NavigationMVVM.Services;

public class ParameterNavigationService<TParameter, TViewModel> 
    where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private Func<TParameter, TViewModel> _createViewModel;

    public ParameterNavigationService(NavigationStore navigationStore, 
        Func<TParameter, TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate(TParameter parameter) => _navigationStore.SetCurrentViewModel(
        _createViewModel(parameter));
}
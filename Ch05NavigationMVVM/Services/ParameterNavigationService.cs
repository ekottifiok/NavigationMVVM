using System;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Services;

public class ParameterNavigationService<TParameter, TViewModel> 
    where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TParameter, TViewModel> _createViewModel;

    public ParameterNavigationService(NavigationStore navigationStore, 
        Func<TParameter, TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate(TParameter parameter) => _navigationStore.SetCurrentViewModel(
        _createViewModel(parameter));
}
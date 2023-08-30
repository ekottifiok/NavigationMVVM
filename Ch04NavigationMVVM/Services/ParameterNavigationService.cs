using System;
using Ch04NavigationMVVM.Stores;
using Ch04NavigationMVVM.ViewModels;

namespace Ch04NavigationMVVM.Services;

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
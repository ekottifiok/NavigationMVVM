using System;
using Ch09NavigationMVVM.Stores;
using Ch09NavigationMVVM.ViewModels;

namespace Ch09NavigationMVVM.Services;

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
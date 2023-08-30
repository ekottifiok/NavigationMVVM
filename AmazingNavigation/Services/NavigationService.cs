using System;
using AmazingNavigation.Core;
using AmazingNavigation.MVVM.ViewModels;

namespace AmazingNavigation.Services;

public class NavigationService : ObservableObject, INavigationService
{
    private readonly Func<Type, ViewModelBase> _viewModelFactory;
    private ViewModelBase _currentView;

    public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    {
        this._viewModelFactory = viewModelFactory;
        _currentView = new ViewModelBase();
    }

    public ViewModelBase CurrentView
    {
        get => _currentView; 
        private set => SetField(ref _currentView, value);
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase => CurrentView = _viewModelFactory.Invoke(
        typeof(TViewModel));
}
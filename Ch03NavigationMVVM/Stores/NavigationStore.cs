using System;
using Ch03NavigationMVVM.ViewModels;

namespace Ch03NavigationMVVM.Stores;

public class NavigationStore
{
    public event Action? CurrentViewModelChanged;
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => _currentViewModel = value;
    }

    public void SetCurrentViewModel(ViewModelBase value)
    {
        _currentViewModel = value;
        CurrentViewModelChanged?.Invoke();
    }

}
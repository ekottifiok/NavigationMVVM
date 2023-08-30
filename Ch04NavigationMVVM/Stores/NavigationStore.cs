using System;
using Ch04NavigationMVVM.ViewModels;

namespace Ch04NavigationMVVM.Stores;

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